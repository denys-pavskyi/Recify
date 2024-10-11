using DAL.Repositories.Interfaces;

namespace DAL.UnitOfWork;

public interface IUnitOfWork
{
    IClientRepository ClientRepository { get; }
    ILinkedDatabaseRepository LinkedDatabaseRepository { get; }
    IUploadedCsvRepository UploadedCsvRepository { get; }
    IRecommenderConfigurationRepository RecommenderConfigurationRepository { get; }
    IRecommenderToUploadedCsvRepository RecommenderToUploadedCsvRepository { get; }
    Task SaveAsync();
}