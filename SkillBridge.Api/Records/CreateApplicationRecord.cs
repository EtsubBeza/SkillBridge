namespace SkillBridge.Api.Records;

public record CreateApplicationRecord(
    int OpportunityId,
    int GraduateProfileId,
    string CoverLetter
);