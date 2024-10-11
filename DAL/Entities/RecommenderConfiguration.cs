using System.ComponentModel.DataAnnotations.Schema;
using DAL.Entities.Enums;

namespace DAL.Entities;

public class RecommenderConfiguration: BaseEntity
{
    public Guid ClientId { get; set; }

    [ForeignKey(nameof(ClientId))]
    public Client? Client { get; set; }
    public RecommenderAlgorithmType AlgorithmType { get; set; }
    public DataSourceType DataSourceType { get; set; }
    public DateTime CreatedAt { get; set; }

    public ICollection<RecommenderToUploadedCSVs> RecommenderToUploadedCSVs { get; set; }
}