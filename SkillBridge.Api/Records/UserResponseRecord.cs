namespace SkillBridge.Api.Records;

public record UserResponseRecord(
    int Id,
    string FirstName,
    string LastName,
    string Email,
    string PhoneNumber,
    int RoleId,
    DateTime CreatedAt,
    bool IsActive
);