using System.Net;
using Amazon.S3;
using AutoMapper;
using BLL.Interfaces;
using DAL.Entities.Enums;
using DAL.Entities;
using DAL.UnitOfWork;
using Microsoft.AspNetCore.Http;
using OneOf.Types;
using BLL.ResponseModels;
using OneOf;
using DAL.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using DAL.Repositories;
using Amazon.S3.Transfer;
using Amazon.S3.Util;
using Amazon.S3.Model;
using BLL.Models;

namespace BLL.Services;

public class UploadCsvService: IUploadCsvService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    private readonly IAmazonS3 _s3Client;
    private readonly string _bucketName; 

    public UploadCsvService(IUnitOfWork unitOfWork, IMapper mapper, IAmazonS3 s3Client,  IConfiguration configuration)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _s3Client = s3Client;
        _bucketName = configuration["AWS_S3:BucketName"];
    }

    public async Task<OneOf<Success, ErrorResponse>> UploadCsvAsync(string clientId, IFormFile file)
    {
        var client = await _unitOfWork.ClientRepository.GetByIdAsync(clientId);
        if (client is null)
        {
            return new ErrorResponse
            {
                Message = "Client with this id does not exist",
                HttpCode = HttpStatusCode.NotFound
            };
        }


        var bucketExist = await AmazonS3Util.DoesS3BucketExistV2Async(_s3Client, _bucketName);
        if (!bucketExist)
        {
            return new ErrorResponse
            {
                Message = "S3 Bucket does not exist",
                HttpCode = HttpStatusCode.BadRequest
            };
        }

        var filePath = await UploadFileToS3Async(file, clientId);

        var uploadedCsv = new UploadedCSV
        {
            ClientId = Guid.Parse(clientId),
            FileName = file.FileName,
            FilePath = filePath,
            UploadDate = DateTime.Now,
            Status = CsvStatus.Pending
        };

        await _unitOfWork.UploadedCsvRepository.AddUploadedCsvAsync(uploadedCsv);

        return new Success();
    }

    public async Task<IEnumerable<UploadedCsvModel>> GetUploadedCsvForClientAsync(string clientId)
    {
        var uploadedCSVs = await _unitOfWork.UploadedCsvRepository.GetUploadedCsvForClientAsync(clientId);

        return _mapper.Map<List<UploadedCsvModel>>(uploadedCSVs);
    }

    public async Task<OneOf<Success, ErrorResponse>> RemoveUploadedCsvByIdAsync(string uploadedCsvId)
    {
        var uploadedCsv = await _unitOfWork.UploadedCsvRepository.GetUploadedCsvById(uploadedCsvId);

        if (uploadedCsv is null)
        {
            return new ErrorResponse
            {
                Message = "Uploaded CSV with this id was not found",
                HttpCode = HttpStatusCode.NotFound
            };
        }
        await DeleteFileFromS3Async(uploadedCsv.FilePath);
        await _unitOfWork.UploadedCsvRepository.RemoveUploadedCsvAsync(uploadedCsv);

        return new Success();
    }

    private async Task DeleteFileFromS3Async(string filePath)
    {
        var deleteRequest = new DeleteObjectRequest
        {
            BucketName = _bucketName,
            Key = filePath
        };

        await _s3Client.DeleteObjectAsync(deleteRequest);
    }

    private async Task<string> UploadFileToS3Async(IFormFile file, string folderName)
    {
        var key = $"{folderName}/{file.FileName}";
        using (var stream = file.OpenReadStream())
        {
            var uploadRequest = new TransferUtilityUploadRequest
            {
                InputStream = stream,
                Key = key,
                BucketName = _bucketName,
                ContentType = file.ContentType
            };

            var fileTransferUtility = new TransferUtility(_s3Client);
            await fileTransferUtility.UploadAsync(uploadRequest);
        }

        return key;
    }

}