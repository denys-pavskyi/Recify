using DAL.Entities;

namespace DAL.Repositories.Interfaces;

public interface IClientRepository
{
    Task<Client?> GetByIdAsync(string clientId);
    Task<Client?> GetByEmailAsync(string email);
}