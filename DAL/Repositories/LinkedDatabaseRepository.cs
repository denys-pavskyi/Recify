using DAL.Data;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class LinkedDatabaseRepository: ILinkedDatabaseRepository
{
    private readonly RecifyDbContext _dbContext;

    public LinkedDatabaseRepository(RecifyDbContext recifyDbContext)
    {
        _dbContext = recifyDbContext;
    }

    public async Task CreateAsync(LinkedDatabase linkedDatabase)
    {
        await _dbContext.LinkedDatabases.AddAsync(linkedDatabase);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(LinkedDatabase linkedDatabase)
    {
        _dbContext.LinkedDatabases.Remove(linkedDatabase);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<LinkedDatabase?> GetByIdAsync(string linkedDatabaseId)
    {
        var linkedDatabase = await _dbContext.LinkedDatabases.FirstOrDefaultAsync(ld =>
            string.Equals(ld.Id.ToString(), linkedDatabaseId));

        return linkedDatabase;
    }
}