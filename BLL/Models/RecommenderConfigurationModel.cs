using DAL.Entities.Enums;
using DAL.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.Models;

public class RecommenderConfigurationModel
{
    public string Id { get; set; }
    public string ClientId { get; set; }
    public RecommenderAlgorithmType AlgorithmType { get; set; }
    public DataSourceType DataSourceType { get; set; }
    public DateTime CreatedAt { get; set; }

    public List<int> RecommenderToUploadedCsvIds { get; set; } = new();
}