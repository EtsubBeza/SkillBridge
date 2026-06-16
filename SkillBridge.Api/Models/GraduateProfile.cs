namespace SkillBridge.Api.Models;

public class GraduateProfile
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string Headline { get; set; } = string.Empty;

    public string Bio { get; set; } = string.Empty;

    public string Education { get; set; } = string.Empty;

    public string University { get; set; } = string.Empty;

    public int GraduationYear { get; set; }

    public string PortfolioUrl { get; set; } = string.Empty;

    public bool IsAvailableForWork { get; set; }

    public DateTime CreatedAt { get; set; }
}