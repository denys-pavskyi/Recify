using DAL.Data;
using DAL.Repositories;
using DAL.Repositories.Interfaces;

namespace DAL.UnitOfWork;

public class UnitOfWork: IUnitOfWork
{
    private readonly RecifyDbContext _dbContext;
    private ClientRepository? _clientRepository;
    private LinkedDatabaseRepository? _linkedDatabaseRepository;
    private UploadedCsvRepository? _uploadedCsvRepository;

    public UnitOfWork(RecifyDbContext context)
    {
        _dbContext = context;
    }

    public IClientRepository ClientRepository
    {
        get
        {
            if (_clientRepository is null)
            {
                _clientRepository = new ClientRepository(_dbContext);
            }
            return _clientRepository;
        }
    }
    public ILinkedDatabaseRepository LinkedDatabaseRepository
    {
        get
        {
            if (_linkedDatabaseRepository is null)
            {
                _linkedDatabaseRepository = new LinkedDatabaseRepository(_dbContext);
            }
            return _linkedDatabaseRepository;
        }
    }

    public IUploadedCsvRepository UploadedCsvRepository
    {
        get
        {
            if (_uploadedCsvRepository is null)
            {
                _uploadedCsvRepository = new UploadedCsvRepository(_dbContext);
            }
            return _uploadedCsvRepository;
        }
    }

    public async Task SaveAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}