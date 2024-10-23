using BLL.Interfaces;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecifyAPI.Helpers;
using System.Net;
using BLL.ResponseModels;

namespace RecifyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {

        private readonly ILinkedDatabaseService _linkedDatabaseService;

        public DataController(ILinkedDatabaseService linkedDatabaseService)
        {
            _linkedDatabaseService = linkedDatabaseService;
        }

        [HttpPost("createDatabase")]
        [ValidateGuidParsable(nameof(clientId))]
        public async Task<IActionResult> CreateDatabase(string clientId, string jsonConfig)
        {
            await _linkedDatabaseService.CreateLinkedDatabaseAsync(clientId, jsonConfig);

            return NoContent();
        }

        [HttpPost("deleteDatabase")]
        [ValidateGuidParsable(nameof(linkedDatabaseId))]
        public async Task<IActionResult> CreateDatabase(string linkedDatabaseId)
        {
            await _linkedDatabaseService.DeleteLinkedDatabaseAsync(linkedDatabaseId);

            return NoContent();
        }


        [HttpPost("addDataToCollection")]
        public async Task<IActionResult> AddDataToCollection(string linkedDatabaseId, string collectionType, [FromBody] string jsonData)
        {
            var response = await _linkedDatabaseService.AddDataToCollectionAsync(linkedDatabaseId, collectionType, jsonData);

            return response.Match<ActionResult>(
                _ => Ok("Data added successfully."),
                error => error.ToActionResult()
            );
        }

    }
}
