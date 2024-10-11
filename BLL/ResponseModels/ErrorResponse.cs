using System.Net;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BLL.ResponseModels;

public class ErrorResponse
{
    public string? Message { get; set; }
    [JsonIgnore]
    public HttpStatusCode? HttpCode { get; set; } = HttpStatusCode.BadRequest;
}

public static class ErrorResponseExtensions
{
    public static ActionResult ToActionResult(this ErrorResponse errorResponse)
    {
        var statusCode = errorResponse.HttpCode ?? HttpStatusCode.BadRequest;
        return statusCode switch
        {
            HttpStatusCode.OK => new OkObjectResult(errorResponse),
            _ => new ObjectResult(errorResponse) { StatusCode = (int)statusCode }
        };
    }
}