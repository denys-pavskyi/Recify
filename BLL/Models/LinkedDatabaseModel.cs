using DAL.Entities.Enums;
using DAL.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.Models;

public class LinkedDatabaseModel
{
    public string Id { get; set; }
    public string ClientId { get; set; }

    public string LinkedDatabaseId { get; set; }
    public DatabaseType DatabaseType { get; set; }

    // Configuration of additional tables

    public bool HasViews { get; set; }
    public bool HasRatings { get; set; }

    public string DatabaseConfigurationId { get; set; } = string.Empty;
    public string DatabaseLink { get; set; } = string.Empty;
}