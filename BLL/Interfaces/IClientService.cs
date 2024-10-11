using BLL.RequestModels;
using BLL.ResponseModels;
using DAL.Entities;
using OneOf;

namespace BLL.Interfaces;

public interface IClientService
{
    Task<OneOf<Client, ErrorResponse>> LoginAsync(LoginModel loginModel);
}