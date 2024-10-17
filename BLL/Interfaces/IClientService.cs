using BLL.Models;
using BLL.RequestModels;
using BLL.ResponseModels;
using DAL.Entities;
using OneOf;

namespace BLL.Interfaces;

public interface IClientService
{
    Task<OneOf<ClientModel, ErrorResponse>> LoginAsync(LoginModel loginModel);
}