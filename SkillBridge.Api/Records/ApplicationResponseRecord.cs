namespace SkillBridge.Api.Records;

public record ApplicationResponseRecord(
    int Id,
    int OpportunityId,
    int GraduateProfileId,
    string CoverLetter,
    string Status,
    DateTime AppliedAt
);