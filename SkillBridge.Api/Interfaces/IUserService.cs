using SkillBridge.Api.Records;

namespace SkillBridge.Api.Interfaces;

public interface IUserService
{
    IEnumerable<UserResponseRecord> GetAll();

    UserResponseRecord? GetById(int id);

    UserResponseRecord Create(CreateUserRecord record);

    UserResponseRecord? Update(
        int id,
        UpdateUserRecord record);

    bool Delete(int id);
}