using SkillBridge.Api.Records;

namespace SkillBridge.Api.Interfaces;

public interface IRoleService
{
    IEnumerable<RoleResponseRecord> GetAll();

    RoleResponseRecord? GetById(int id);

    RoleResponseRecord Create(CreateRoleRecord record);

    RoleResponseRecord? Update(
        int id,
        UpdateRoleRecord record);

    bool Delete(int id);
}