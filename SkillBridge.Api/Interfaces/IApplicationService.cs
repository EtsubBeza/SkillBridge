using SkillBridge.Api.Records;

namespace SkillBridge.Api.Interfaces;

public interface IApplicationService
{
    IEnumerable<ApplicationResponseRecord> GetAll();

    ApplicationResponseRecord? GetById(int id);

    ApplicationResponseRecord Create(
        CreateApplicationRecord record);

    ApplicationResponseRecord? Update(
        int id,
        UpdateApplicationRecord record);

    bool Delete(int id);
}