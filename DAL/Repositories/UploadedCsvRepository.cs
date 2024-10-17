using DAL.Data;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

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

    public async Task<IEnumerable<UploadedCSV>> GetUploadedCsvForClientAsync(string clientId)
    {
        return await _dbContext.UploadedCSVs
            .Where(csv => string.Equals(csv.ClientId.ToString(), clientId))
            .ToListAsync();
    }

    public async Task<UploadedCSV?> GetUploadedCsvById(string uploadedCsvId)
    {
        var uploadedCsv = await _dbContext.UploadedCSVs.FirstOrDefaultAsync(uc => string.Equals(uc.Id.ToString(), uploadedCsvId));
        return uploadedCsv;
    }

    public async Task RemoveUploadedCsvAsync(UploadedCSV uploadedCsv)
    {
        _dbContext.UploadedCSVs.Remove(uploadedCsv);
        await _dbContext.SaveChangesAsync();
    }
}