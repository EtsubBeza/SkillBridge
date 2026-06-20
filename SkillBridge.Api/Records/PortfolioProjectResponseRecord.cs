namespace SkillBridge.Api.Records;

public record PortfolioProjectResponseRecord(
    int Id,
    int GraduateProfileId,
    string Title,
    string Description,
    string TechnologiesUsed,
    string ProjectUrl,
    string GithubUrl,
    DateTime CreatedAt
);