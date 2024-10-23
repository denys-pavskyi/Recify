using DAL.Entities.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities;

public class LinkedDatabase: BaseEntity
{
    public Guid ClientId { get; set; }

    [ForeignKey(nameof(ClientId))]
    public Client? Client { get; set; }

    public DatabaseType DatabaseType { get; set; }

    // Configuration of additional tables

    public bool HasViews { get; set; }
    public bool HasRatings { get; set; }

    public string? DatabaseConfigurationId { get; set; }
    public string? DatabaseLink { get; set; }

    public string? Structure { get; set; }
}