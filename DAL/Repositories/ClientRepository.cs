using DAL.Data;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories;

public class ClientRepository: IClientRepository
{
    private readonly RecifyDbContext _dbContext;

    public ClientRepository(RecifyDbContext recifyDbContext)
    {
        _dbContext = recifyDbContext;
    }
}