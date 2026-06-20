namespace SkillBridge.Api.Records;

public record AssessmentResponseRecord(
    int Id,
    int OpportunityId,
    string Title,
    string Description,
    int PassingScore,
    DateTime CreatedAt
);