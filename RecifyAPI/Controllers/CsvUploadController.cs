using System.Net;
using Azure;
using BLL.Interfaces;
using BLL.ResponseModels;
using Microsoft.AspNetCore.Mvc;
using RecifyAPI.Helpers;

namespace RecifyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CsvUploadController : ControllerBase
    {
        private readonly IUploadCsvService _uploadCsvService;

        public CsvUploadController(IUploadCsvService uploadCsvService)
        {
            _uploadCsvService = uploadCsvService;
        }

        [HttpPost("upload")]
        [ValidateGuidParsable(nameof(clientId))]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> UploadCsv(string clientId, IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return new ErrorResponse
                {
                    Message = "No file uploaded",
                    HttpCode = HttpStatusCode.BadRequest,
                }.ToActionResult();
            }

            if (!file.FileName.EndsWith(".csv", StringComparison.OrdinalIgnoreCase))
            {
                return new ErrorResponse
                {
                    Message = "Only CSV files are allowed",
                    HttpCode = HttpStatusCode.BadRequest,
                }.ToActionResult();
            }

            var response = await _uploadCsvService.UploadCsvAsync(clientId, file);

            return response.Match<ActionResult>(
                _ => NoContent(),
                error => error.ToActionResult());
        }


    }
}
