using BLL.ResponseModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OneOf;
using OneOf.Types;

namespace BLL.Interfaces;

public interface IUploadCsvService
{
    Task<OneOf<Success, ErrorResponse>> UploadCsvAsync(string clientId, IFormFile file);
}