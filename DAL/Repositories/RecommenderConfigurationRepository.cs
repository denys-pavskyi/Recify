using DAL.Data;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories;

public class RecommenderConfigurationRepository: IRecommenderConfigurationRepository
{
    private readonly RecifyDbContext _dbContext;

    public RecommenderConfigurationRepository(RecifyDbContext recifyDbContext)
    {
        _dbContext = recifyDbContext;
    }
}