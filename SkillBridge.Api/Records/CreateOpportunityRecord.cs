namespace SkillBridge.Api.Records;

public record CreateOpportunityRecord(
    int EmployerProfileId,
    string Title,
    string Description,
    string RequiredSkills,
    string Location,
    string EmploymentType,
    decimal Salary
);