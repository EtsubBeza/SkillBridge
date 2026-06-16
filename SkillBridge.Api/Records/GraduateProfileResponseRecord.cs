namespace SkillBridge.Api.Records;

public record GraduateProfileResponseRecord(
    int Id,
    int UserId,
    string Headline,
    string Bio,
    string Education,
    string University,
    int GraduationYear,
    string PortfolioUrl,
    bool IsAvailableForWork,
    DateTime CreatedAt
);