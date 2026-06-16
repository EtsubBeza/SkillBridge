using SkillBridge.Api.Records;

namespace SkillBridge.Api.Interfaces;

public interface IGraduateProfileService
{
    IEnumerable<GraduateProfileResponseRecord> GetAll();

    GraduateProfileResponseRecord? GetById(int id);

    GraduateProfileResponseRecord Create(
        CreateGraduateProfileRecord record);

    GraduateProfileResponseRecord? Update(
        int id,
        UpdateGraduateProfileRecord record);

    bool Delete(int id);
}