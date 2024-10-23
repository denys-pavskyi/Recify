using DAL.Entities;

namespace DAL.Repositories.Interfaces;

public interface ILinkedDatabaseRepository
{
    Task CreateAsync(LinkedDatabase linkedDatabase);
    Task DeleteAsync(LinkedDatabase linkedDatabase);
    Task<LinkedDatabase?> GetByIdAsync(string linkedDatabaseId);

    Task<LinkedDatabase?> GetByClientIdAsync(string clientId);
}