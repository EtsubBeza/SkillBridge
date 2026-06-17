using SkillBridge.Api.Records;

namespace SkillBridge.Api.Interfaces;

public interface IEmployerProfileService
{
    IEnumerable<EmployerProfileResponseRecord> GetAll();

    EmployerProfileResponseRecord? GetById(int id);

    EmployerProfileResponseRecord Create(
        CreateEmployerProfileRecord record);

    EmployerProfileResponseRecord? Update(
        int id,
        UpdateEmployerProfileRecord record);

    bool Delete(int id);
}