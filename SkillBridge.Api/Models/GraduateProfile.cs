namespace SkillBridge.Api.Models;

public class GraduateProfile
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string University { get; set; } = string.Empty;

    public string FieldOfStudy { get; set; } = string.Empty;

    public int GraduationYear { get; set; }

    public string Bio { get; set; } = string.Empty;

    public string PortfolioLink { get; set; } = string.Empty;

    public string ResumeUrl { get; set; } = string.Empty;

    public string ExperienceLevel { get; set; } = string.Empty;
}