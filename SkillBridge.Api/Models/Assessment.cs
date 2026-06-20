namespace SkillBridge.Api.Models;

public class Assessment
{
    public int Id { get; set; }

    public int OpportunityId { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public int PassingScore { get; set; }

    public DateTime CreatedAt { get; set; }
}