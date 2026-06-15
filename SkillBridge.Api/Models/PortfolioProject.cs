namespace SkillBridge.Api.Models;

public class PortfolioProject
{
    public int Id { get; set; }

    public int GraduateProfileId { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string GithubUrl { get; set; } = string.Empty;

    public string DemoUrl { get; set; } = string.Empty;

    public DateTime CreatedDate { get; set; }
}