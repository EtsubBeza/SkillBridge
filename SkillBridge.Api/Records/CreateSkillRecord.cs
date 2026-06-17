namespace SkillBridge.Api.Records;

public record CreateSkillRecord(
    int GraduateProfileId,
    string Name,
    string Level,
    int YearsOfExperience
);