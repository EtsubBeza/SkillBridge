namespace SkillBridge.Api.Records;

public record UpdateGraduateProfileRecord(
    string Headline,
    string Bio,
    string Education,
    string University,
    int GraduationYear,
    string PortfolioUrl,
    bool IsAvailableForWork
);