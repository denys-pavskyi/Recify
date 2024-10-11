using AutoMapper;
using BLL.Interfaces;
using DAL.UnitOfWork;

namespace BLL.Services;

public class UploadCsvService: IUploadCsvService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UploadCsvService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
}