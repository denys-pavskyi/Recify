using DAL.Data;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories;

public class RecommenderToUploadedCsvRepository: IRecommenderToUploadedCsvRepository
{
    private readonly RecifyDbContext _dbContext;

    public RecommenderToUploadedCsvRepository(RecifyDbContext recifyDbContext)
    {
        _dbContext = recifyDbContext;
    }
}