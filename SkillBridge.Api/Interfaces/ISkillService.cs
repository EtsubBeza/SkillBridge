using SkillBridge.Api.Records;

namespace SkillBridge.Api.Interfaces;

public interface ISkillService
{
    IEnumerable<SkillResponseRecord> GetAll();

    SkillResponseRecord? GetById(int id);

    SkillResponseRecord Create(
        CreateSkillRecord record);

    SkillResponseRecord? Update(
        int id,
        UpdateSkillRecord record);

    bool Delete(int id);
}