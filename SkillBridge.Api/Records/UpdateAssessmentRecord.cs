namespace SkillBridge.Api.Records;

public record UpdateAssessmentRecord(
    string Title,
    string Description,
    int PassingScore
);