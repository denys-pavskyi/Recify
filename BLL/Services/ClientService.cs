using System.Net;
using AutoMapper;
using BLL.Helpers;
using BLL.Interfaces;
using BLL.Models;
using BLL.RequestModels;
using BLL.ResponseModels;
using DAL.Entities;
using DAL.UnitOfWork;
using OneOf;

namespace BLL.Services;

public class ClientService: IClientService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ClientService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }


    public async Task<OneOf<ClientModel, ErrorResponse>> LoginAsync(LoginModel loginModel)
    {
        var client = await _unitOfWork.ClientRepository.GetByEmailAsync(loginModel.Email);

        if (client is null)
        {
            return new ErrorResponse
            {
                Message = "User was not found",
                HttpCode = HttpStatusCode.NotFound
            };
        }

        if (!string.Equals(HashingHelper.HashUsingPbkdf2(loginModel.Password, "pOr3j7C38WjuDLp3SRIBEg=="), client.PasswordHash))
        {
            return new ErrorResponse
            {
                Message = "Invalid password",
                HttpCode = HttpStatusCode.BadRequest
            };
        }

        return _mapper.Map<ClientModel>(client);
    }
}