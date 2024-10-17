using BLL.Models;
using BLL.ResponseModels;
using DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OneOf;
using OneOf.Types;

namespace BLL.Interfaces;

public interface IUploadCsvService
{
    Task<OneOf<Success, ErrorResponse>> UploadCsvAsync(string clientId, IFormFile file);
    Task<IEnumerable<UploadedCsvModel>> GetUploadedCsvForClientAsync(string clientId);
    Task<OneOf<Success, ErrorResponse>> RemoveUploadedCsvByIdAsync(string uploadedCsvId);
}