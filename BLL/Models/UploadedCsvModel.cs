using DAL.Entities.Enums;
using DAL.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.Models;

public class UploadedCsvModel
{
    public string Id { get; set; }
    public string ClientId { get; set; }
    public string FileName { get; set; } = string.Empty;
    public string FilePath { get; set; } = string.Empty;
    public DateTime UploadDate { get; set; } = DateTime.Now;
    public CsvStatus Status { get; set; } = CsvStatus.Pending;

    public List<int> RecommenderToUploadedCsvIds { get; set; } = new();
}