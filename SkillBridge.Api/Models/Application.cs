namespace SkillBridge.Api.Models;

public class Application
{
    public int Id { get; set; }

    public int OpportunityId { get; set; }

    public int GraduateProfileId { get; set; }

    public string Status { get; set; } = string.Empty;

    public DateTime AppliedDate { get; set; }

    public string CoverLetter { get; set; } = string.Empty;
}