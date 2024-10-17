using BLL.Models;
using DAL.Entities;
using OneOf.Types;
using OneOf;
using System.Net;
using BLL.ResponseModels;

namespace BLL.Interfaces;

public interface IRecommenderConfigurationService
{
    Task<RecommenderConfigurationModel> CreateConfigurationAsync(RecommenderConfigurationModel configuration);
    Task<RecommenderConfigurationModel> UpdateConfigurationAsync(RecommenderConfigurationModel configuration);
    Task<OneOf<Success, ErrorResponse>> DeleteConfigurationAsync(string configurationId);
    Task<IEnumerable<RecommenderConfigurationModel>> GetConfigurationsForClientAsync(string clientId);
}