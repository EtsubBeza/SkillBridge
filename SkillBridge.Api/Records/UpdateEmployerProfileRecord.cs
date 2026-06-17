namespace SkillBridge.Api.Records;

public record UpdateEmployerProfileRecord(
    string CompanyName,
    string Industry,
    string CompanyDescription,
    string WebsiteUrl,
    string Location,
    bool IsVerified
);