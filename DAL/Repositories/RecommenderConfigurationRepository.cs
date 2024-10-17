using DAL.Data;
using DAL.Entities;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class RecommenderConfigurationRepository: IRecommenderConfigurationRepository
{
    private readonly RecifyDbContext _dbContext;

    public RecommenderConfigurationRepository(RecifyDbContext recifyDbContext)
    {
        _dbContext = recifyDbContext;
    }

    public async Task<IEnumerable<RecommenderConfiguration>> GetConfigurationsForClientAsync(string clientId)
    {
        var configurations =
            await _dbContext.RecommenderConfigurations.Where(rc => string.Equals(rc.ClientId.ToString(), clientId))
                .ToListAsync();
        return configurations;
    }
    public async Task<RecommenderConfiguration> CreateAsync(RecommenderConfiguration configuration)
    {
        await _dbContext.RecommenderConfigurations.AddAsync(configuration);
        await _dbContext.SaveChangesAsync();
        return configuration;
    }

    public async Task<RecommenderConfiguration> UpdateAsync(RecommenderConfiguration configuration)
    {
        _dbContext.RecommenderConfigurations.Update(configuration);
        await _dbContext.SaveChangesAsync();
        return configuration;
    }

    public async Task<RecommenderConfiguration?> GetByIdASync(string configurationId)
    {
        var recommendationConfiguration = await _dbContext.RecommenderConfigurations.FirstOrDefaultAsync(rc =>
            string.Equals(rc.Id.ToString(), configurationId));

        return recommendationConfiguration;
    }
    public async Task DeleteAsync(RecommenderConfiguration recommenderConfiguration)
    {
        _dbContext.RecommenderConfigurations.Remove(recommenderConfiguration);
        await _dbContext.SaveChangesAsync();
    }
}