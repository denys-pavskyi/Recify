using DAL.Entities;

namespace DAL.Repositories.Interfaces;

public interface IRecommenderConfigurationRepository
{
    Task<RecommenderConfiguration> CreateAsync(RecommenderConfiguration configuration);
    Task<RecommenderConfiguration> UpdateAsync(RecommenderConfiguration configuration);
    Task<RecommenderConfiguration?> GetByIdASync(string configurationId);
    Task DeleteAsync(RecommenderConfiguration recommenderConfiguration);
    Task<IEnumerable<RecommenderConfiguration>> GetConfigurationsForClientAsync(string clientId);
}