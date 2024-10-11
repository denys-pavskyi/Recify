using AutoMapper;
using BLL.Interfaces;
using DAL.UnitOfWork;

namespace BLL.Services;

public class ClientService: IClientService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ClientService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
}