namespace SkillBridge.Api.Records;

public record UpdateUserRecord(
    string FirstName,
    string LastName,
    string Email,
    string PhoneNumber,
    int RoleId,
    bool IsActive
);