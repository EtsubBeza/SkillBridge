namespace SkillBridge.Api.Records;

public record CreateEmployerProfileRecord(
    int UserId,
    string CompanyName,
    string Industry,
    string CompanyDescription,
    string WebsiteUrl,
    string Location
);