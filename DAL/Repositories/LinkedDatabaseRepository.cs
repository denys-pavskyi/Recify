using DAL.Data;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories;

public class LinkedDatabaseRepository: ILinkedDatabaseRepository
{
    private readonly RecifyDbContext _dbContext;

    public LinkedDatabaseRepository(RecifyDbContext recifyDbContext)
    {
        _dbContext = recifyDbContext;
    }
}