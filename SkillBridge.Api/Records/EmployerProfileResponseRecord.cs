namespace SkillBridge.Api.Records;

public record EmployerProfileResponseRecord(
    int Id,
    int UserId,
    string CompanyName,
    string Industry,
    string CompanyDescription,
    string WebsiteUrl,
    string Location,
    bool IsVerified,
    DateTime CreatedAt
);