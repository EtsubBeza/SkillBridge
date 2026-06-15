namespace SkillBridge.Api.Models;

public class Assessment
{
    public int Id { get; set; }

    public int GraduateProfileId { get; set; }

    public string Title { get; set; } = string.Empty;

    public double Score { get; set; }

    public string IssuedBy { get; set; } = string.Empty;

    public DateTime CompletedDate { get; set; }
}