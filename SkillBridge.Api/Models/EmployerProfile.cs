namespace SkillBridge.Api.Models;

public class EmployerProfile
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string CompanyName { get; set; } = string.Empty;

    public string Industry { get; set; } = string.Empty;

    public string CompanyDescription { get; set; } = string.Empty;

    public string Website { get; set; } = string.Empty;

    public string Location { get; set; } = string.Empty;
}