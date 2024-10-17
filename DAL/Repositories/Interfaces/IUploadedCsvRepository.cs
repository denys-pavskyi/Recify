using DAL.Entities;

namespace DAL.Repositories.Interfaces;

public interface IUploadedCsvRepository
{
    Task AddUploadedCsvAsync(UploadedCSV uploadedCsv);
    Task<IEnumerable<UploadedCSV>> GetUploadedCsvForClientAsync(string clientId);
    Task RemoveUploadedCsvAsync(UploadedCSV uploadedCsv);
    Task<UploadedCSV?> GetUploadedCsvById(string uploadedCsvId);
}