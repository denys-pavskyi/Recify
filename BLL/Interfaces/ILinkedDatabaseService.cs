using OneOf.Types;
using OneOf;
using BLL.ResponseModels;

namespace BLL.Interfaces;

public interface ILinkedDatabaseService
{
    Task CreateLinkedDatabaseAsync(string clientId, string jsonConfig);
    Task<OneOf<Success, ErrorResponse>> DeleteLinkedDatabaseAsync(string linkedDatabaseId);

    Task<OneOf<Success, ErrorResponse>> AddDataToCollectionAsync(string linkedDatabaseId, string collectionType,
        string jsonData);
}