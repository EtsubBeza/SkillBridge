namespace SkillBridge.Api.Models;

public class Opportunity
{
    public int Id { get; set; }

    public int EmployerProfileId { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string RequiredSkills { get; set; } = string.Empty;

    public string Location { get; set; } = string.Empty;

    public string Type { get; set; } = string.Empty;

    public DateTime Deadline { get; set; }
}