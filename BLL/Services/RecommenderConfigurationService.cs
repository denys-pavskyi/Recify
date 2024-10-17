using System.Net;
using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using BLL.ResponseModels;
using DAL.Entities;
using DAL.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using OneOf;
using OneOf.Types;

namespace BLL.Services;

public class RecommenderConfigurationService : IRecommenderConfigurationService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public RecommenderConfigurationService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }


    public async Task<RecommenderConfigurationModel> CreateConfigurationAsync(RecommenderConfigurationModel configuration)
    {
        var mapped = _mapper.Map<RecommenderConfiguration>(configuration);

        var result = await _unitOfWork.RecommenderConfigurationRepository.CreateAsync(mapped);

        return _mapper.Map<RecommenderConfigurationModel>(result);
    }

    public async Task<RecommenderConfigurationModel> UpdateConfigurationAsync(RecommenderConfigurationModel configuration)
    {
        var mapped = _mapper.Map<RecommenderConfiguration>(configuration);

        var result = await _unitOfWork.RecommenderConfigurationRepository.UpdateAsync(mapped);

        return _mapper.Map<RecommenderConfigurationModel>(result);
    }

    public async Task<OneOf<Success, ErrorResponse>> DeleteConfigurationAsync(string configurationId)
    {
        var configuration = await _unitOfWork.RecommenderConfigurationRepository.GetByIdASync(configurationId);

        if (configuration is null)
        {
            return new ErrorResponse
            {
                Message = "Configuration was not found",
                HttpCode = HttpStatusCode.NotFound
            };
        }

        await _unitOfWork.RecommenderConfigurationRepository.DeleteAsync(configuration);
        return new Success();
    }

    public async Task<IEnumerable<RecommenderConfigurationModel>> GetConfigurationsForClientAsync(string clientId)
    {
        var configurations =
            await _unitOfWork.RecommenderConfigurationRepository.GetConfigurationsForClientAsync(clientId);

        var mappedConfigurations = _mapper.Map<List<RecommenderConfigurationModel>>(configurations);

        return mappedConfigurations;
    }

}