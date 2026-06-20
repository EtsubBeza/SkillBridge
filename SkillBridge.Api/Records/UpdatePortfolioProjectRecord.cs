namespace SkillBridge.Api.Records;

public record UpdatePortfolioProjectRecord(
    string Title,
    string Description,
    string TechnologiesUsed,
    string ProjectUrl,
    string GithubUrl
);