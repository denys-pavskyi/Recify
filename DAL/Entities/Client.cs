using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities;

public class Client: BaseEntity
{
    [EmailAddress]
    [Column(TypeName = "varchar(32)")]
    public string Email { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string? LastName { get; set; }


    public ICollection<LinkedDatabase> LinkedDatabases { get; set; } = new List<LinkedDatabase>();
    public ICollection<UploadedCSV> UploadedCSVs { get; set; } = new List<UploadedCSV>();

    public ICollection<RecommenderConfiguration> RecommenderConfigurations { get; set; } = new List<RecommenderConfiguration>();
}