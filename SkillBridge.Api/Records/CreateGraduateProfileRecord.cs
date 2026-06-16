namespace SkillBridge.Api.Records;

public record CreateGraduateProfileRecord(
    int UserId,
    string Headline,
    string Bio,
    string Education,
    string University,
    int GraduationYear,
    string PortfolioUrl
);