namespace SkillBridge.Api.Models;

public class Skill
{
    public int Id { get; set; }

    public int GraduateProfileId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Level { get; set; } = string.Empty;
}