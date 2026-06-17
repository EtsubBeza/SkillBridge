namespace SkillBridge.Api.Records;

public record UpdateOpportunityRecord(
    string Title,
    string Description,
    string RequiredSkills,
    string Location,
    string EmploymentType,
    decimal Salary,
    bool IsActive
);