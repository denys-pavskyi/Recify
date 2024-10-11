using AutoMapper;
using BLL.Interfaces;
using DAL.Repositories.Interfaces;
using DAL.UnitOfWork;

namespace BLL.Services;

public class RecommenderToUploadedCsvService: IRecommenderToUploadedCsvService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public RecommenderToUploadedCsvService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
}