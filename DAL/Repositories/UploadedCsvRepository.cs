using DAL.Data;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories;

public class UploadedCsvRepository: IUploadedCsvRepository
{
    private readonly RecifyDbContext _dbContext;

    public UploadedCsvRepository(RecifyDbContext recifyDbContext)
    {
        _dbContext = recifyDbContext;
    }
}