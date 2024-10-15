using DAL.Entities;

namespace DAL.Repositories.Interfaces;

public interface IUploadedCsvRepository
{
    Task AddUploadedCsvAsync(UploadedCSV uploadedCsv);
}