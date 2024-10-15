using DAL.Data;
using DAL.Entities;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories;

public class UploadedCsvRepository: IUploadedCsvRepository
{
    private readonly RecifyDbContext _dbContext;

    public UploadedCsvRepository(RecifyDbContext recifyDbContext)
    {
        _dbContext = recifyDbContext;
    }

    public async Task AddUploadedCsvAsync(UploadedCSV uploadedCsv)
    {
        await _dbContext.UploadedCSVs.AddAsync(uploadedCsv);
        await _dbContext.SaveChangesAsync();
    }
}