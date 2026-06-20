namespace SkillBridge.Api.Records;

public record CreateAssessmentRecord(
    int OpportunityId,
    string Title,
    string Description,
    int PassingScore
);