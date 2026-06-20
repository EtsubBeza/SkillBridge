namespace SkillBridge.Api.Records;

public record CreatePortfolioProjectRecord(
    int GraduateProfileId,
    string Title,
    string Description,
    string TechnologiesUsed,
    string ProjectUrl,
    string GithubUrl
);