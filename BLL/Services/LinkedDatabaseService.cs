using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using DAL.Entities.Enums;
using DAL.Entities;
using DAL.UnitOfWork;
using MongoDB.Bson;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using OneOf.Types;
using OneOf;
using BLL.ResponseModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BLL.Services;

public class LinkedDatabaseService: ILinkedDatabaseService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IMongoClient _mongoClient;

    public LinkedDatabaseService(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _mongoClient = new MongoClient(configuration.GetConnectionString("MongoDb")); ;
    }

    public async Task CreateLinkedDatabaseAsync(string clientId, string jsonConfig)
    {

        var config = Newtonsoft.Json.JsonConvert.DeserializeObject<DatabaseConfig>(jsonConfig);
        var mongoDatabaseName = $"Database_{clientId}";


        var mongoDatabase = _mongoClient.GetDatabase(mongoDatabaseName);

        var itemsCollection = mongoDatabase.GetCollection<BsonDocument>("Items");


        var initialDocument = new BsonDocument
        {
            { "placeholder", "initial" }
        };


        await itemsCollection.InsertOneAsync(initialDocument);
        await itemsCollection.DeleteOneAsync(Builders<BsonDocument>.Filter.Eq("placeholder", "initial"));

        if (config.Tables.Views)
        {
            var viewsCollection = mongoDatabase.GetCollection<BsonDocument>("Views");
            await viewsCollection.InsertOneAsync(initialDocument);
            await viewsCollection.DeleteOneAsync(Builders<BsonDocument>.Filter.Eq("placeholder", "initial"));
        }

        if (config.Tables.Ratings)
        {
            var ratingsCollection = mongoDatabase.GetCollection<BsonDocument>("Ratings");
            await ratingsCollection.InsertOneAsync(initialDocument);
            await ratingsCollection.DeleteOneAsync(Builders<BsonDocument>.Filter.Eq("placeholder", "initial"));
        }

        var linkedDatabase = new LinkedDatabase
        {
            ClientId = Guid.Parse(clientId),
            DatabaseType = DatabaseType.MongoDb,
            HasViews = config.Tables.Views,
            HasRatings = config.Tables.Ratings,
            DatabaseConfigurationId = mongoDatabaseName,
            DatabaseLink = $"mongodb://localhost:27017/{mongoDatabaseName}",
            Structure = jsonConfig
        };

        await _unitOfWork.LinkedDatabaseRepository.CreateAsync(linkedDatabase);
    }



    public async Task<OneOf<Success, ErrorResponse>> DeleteLinkedDatabaseAsync(string linkedDatabaseId)
    {
        var linkedDatabase = await _unitOfWork.LinkedDatabaseRepository.GetByIdAsync(linkedDatabaseId);

        if (linkedDatabase == null)
        {
            return new ErrorResponse
            {
                Message = "LinkedDatabase not found",
                HttpCode = System.Net.HttpStatusCode.NotFound
            };
        }

        try
        {

            var mongoDatabaseName = linkedDatabase.DatabaseConfigurationId;
            await _mongoClient.DropDatabaseAsync(mongoDatabaseName);

            await _unitOfWork.LinkedDatabaseRepository.DeleteAsync(linkedDatabase);

            return new Success();
        }
        catch (Exception ex)
        {
            return new ErrorResponse
            {
                Message = $"Failed to delete LinkedDatabase: {ex.Message}",
                HttpCode = System.Net.HttpStatusCode.InternalServerError
            };
        }
    }

    public async Task<OneOf<Success, ErrorResponse>> AddDataToCollectionAsync(string linkedDatabaseId, string collectionType, string jsonData)
    {

        var linkedDatabase = await _unitOfWork.LinkedDatabaseRepository.GetByIdAsync(linkedDatabaseId);

        if (linkedDatabase == null)
        {
            return new ErrorResponse
            {
                Message = "LinkedDatabase not found",
                HttpCode = System.Net.HttpStatusCode.NotFound
            };
        }

        // Check if the specified collection is allowed
        bool isValidCollection = (collectionType == "Items") ||
                                 (collectionType == "Views" && linkedDatabase.HasViews) ||
                                 (collectionType == "Ratings" && linkedDatabase.HasRatings);

        if (!isValidCollection)
        {
            return new ErrorResponse
            {
                Message = $"{collectionType} collection does not exist or is not allowed for this database.",
                HttpCode = System.Net.HttpStatusCode.BadRequest
            };
        }

        try
        {
            // Validate the JSON data based on collection type
            bool isJsonValid = ValidateJsonStructure(collectionType, jsonData, linkedDatabase);
            if (!isJsonValid)
            {
                return new ErrorResponse
                {
                    Message = "The JSON data structure is invalid for the specified collection.",
                    HttpCode = System.Net.HttpStatusCode.BadRequest
                };
            }

            // Create the MongoDB database and select the appropriate collection
            var mongoDatabase = _mongoClient.GetDatabase(linkedDatabase.DatabaseConfigurationId);
            var collection = mongoDatabase.GetCollection<BsonDocument>(collectionType);

            // Convert the incoming JSON data to a BsonDocument
            var document = BsonDocument.Parse(jsonData);

            // Insert the document into the collection
            await collection.InsertOneAsync(document);

            return new Success();
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., log error)
            return new ErrorResponse
            {
                Message = $"Failed to add data to {collectionType} collection: {ex.Message}",
                HttpCode = System.Net.HttpStatusCode.InternalServerError
            };
        }
    }

    public async Task<OneOf<LinkedDatabaseModel, ErrorResponse>> GetLinkedDatabaseByClientIdAsync(string clientId)
    {

        var linkedDatabase = await _unitOfWork.LinkedDatabaseRepository.GetByClientIdAsync(clientId);

        if (linkedDatabase == null)
        {
            return new ErrorResponse
            {
                Message = "LinkedDatabase not found",
                HttpCode = System.Net.HttpStatusCode.NotFound
            };
        }

        return _mapper.Map<LinkedDatabaseModel>(linkedDatabase);
    }



    private bool ValidateJsonStructure(string collectionType, string jsonData, LinkedDatabase linkedDatabase)
    {
        try
        {
            var json = JObject.Parse(jsonData);

            switch (collectionType)
            {
                case "Items":
                    var config = JsonConvert.DeserializeObject<DatabaseConfig>(linkedDatabase.Structure);
                    var expectedColumns = config.Tables.Items.Columns.Select(c => c.Name).ToList();
                    return json.Properties().All(p => expectedColumns.Contains(p.Name));

                case "Views":
                    return json.ContainsKey("user_id") && json.ContainsKey("item_id");

                case "Ratings":
                    return json.ContainsKey("user_id") && json.ContainsKey("item_id") && json.ContainsKey("rating");

                default:
                    return false;
            }
        }
        catch (Exception)
        {
            return false; // Invalid JSON
        }
    }

}


public class DatabaseConfig
{
    public TablesConfig Tables { get; set; }
}

public class TablesConfig
{
    public ItemsConfig Items { get; set; }
    public bool Views { get; set; }
    public bool Ratings { get; set; }
}

public class ItemsConfig
{
    public List<ColumnConfig> Columns { get; set; }
}

public class ColumnConfig
{
    public string Name { get; set; }
    public string Type { get; set; }
}