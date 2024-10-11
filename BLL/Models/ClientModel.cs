namespace BLL.Models;

public class ClientModel
{
    public string Id { get; set; }

    public string Email { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string? LastName { get; set; }


    public List<string> LinkedDatabaseIds { get; set; } = new();
    public List<string> UploadedCsvIds { get; set; } = new();

    public List<string> RecommenderConfigurationIds { get; set; } = new();
}