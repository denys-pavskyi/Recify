using AutoMapper;
using BLL.Interfaces;
using DAL.UnitOfWork;

namespace BLL.Services;

public class LinkedDatabaseService: ILinkedDatabaseService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public LinkedDatabaseService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
}