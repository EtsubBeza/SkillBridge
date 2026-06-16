namespace SkillBridge.Api.Records;

public record CreateUserRecord(
    string FirstName,
    string LastName,
    string Email,
    string Password,
    string PhoneNumber,
    int RoleId
);