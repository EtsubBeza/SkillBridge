namespace SkillBridge.Api.Records;

public record OpportunityResponseRecord(
    int Id,
    int EmployerProfileId,
    string Title,
    string Description,
    string RequiredSkills,
    string Location,
    string EmploymentType,
    decimal Salary,
    bool IsActive,
    DateTime CreatedAt
);