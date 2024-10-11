using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities;

public class RecommenderToUploadedCSVs: BaseEntity
{
    public Guid ConfigurationId { get; set; }

    [ForeignKey(nameof(ConfigurationId))]
    public RecommenderConfiguration? RecommenderConfiguration { get; set; }

    public Guid UploadedCsvId { get; set; }

    [ForeignKey(nameof(UploadedCsvId))]
    public UploadedCSV? UploadedCsv { get; set; }
}