using System.ComponentModel.DataAnnotations.Schema;
using DAL.Entities.Enums;

namespace DAL.Entities;

public class UploadedCSV: BaseEntity
{
    public Guid ClientId { get; set; }

    [ForeignKey(nameof(ClientId))]
    public Client? Client { get; set; }

    public string FileName { get; set; } = string.Empty;
    public string FilePath { get; set; } = string.Empty;
    public DateTime UploadDate { get; set; } = DateTime.Now;
    public CsvStatus Status { get; set; } = CsvStatus.Pending;
}