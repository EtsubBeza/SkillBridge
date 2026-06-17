using SkillBridge.Api.Records;

namespace SkillBridge.Api.Interfaces;

public interface IOpportunityService
{
    IEnumerable<OpportunityResponseRecord> GetAll();

    OpportunityResponseRecord? GetById(int id);

    OpportunityResponseRecord Create(
        CreateOpportunityRecord record);

    OpportunityResponseRecord? Update(
        int id,
        UpdateOpportunityRecord record);

    bool Delete(int id);
}