using AutoMapper;
using BLL.Interfaces;
using DAL.UnitOfWork;

namespace BLL.Services;

public class RecommenderConfigurationService:IRecommenderConfigurationService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public RecommenderConfigurationService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
}