namespace SkillBridge.Api.Records;

public record SkillResponseRecord(
    int Id,
    int GraduateProfileId,
    string Name,
    string Level,
    int YearsOfExperience,
    DateTime CreatedAt
);