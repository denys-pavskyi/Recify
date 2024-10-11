using DAL.Entities.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities;

public class LinkedDatabase: BaseEntity
{
    public Guid ClientId { get; set; }

    [ForeignKey(nameof(ClientId))]
    public Client? Client { get; set; }

    public DatabaseType DatabaseType { get; set; }
    public string DatabaseCredentials { get; set; } = string.Empty;
}