using DAL.Data;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class ClientRepository: IClientRepository
{
    private readonly RecifyDbContext _dbContext;

    public ClientRepository(RecifyDbContext recifyDbContext)
    {
        _dbContext = recifyDbContext;
    }

    public async Task<Client?> GetByIdAsync(string clientId)
    {
        var client = await _dbContext.Clients.FirstOrDefaultAsync(c => string.Equals(c.Id.ToString(), clientId));
        return client;
    }

    public async Task<Client?> GetByEmailAsync(string email)
    {
        var client = await _dbContext.Clients.FirstOrDefaultAsync(c => string.Equals(c.Email, email));
        return client;
    }
}