using SkillBridge.Api.Records;

namespace SkillBridge.Api.Interfaces;

public interface INotificationService
{
    IEnumerable<NotificationResponseRecord> GetAll();

    NotificationResponseRecord? GetById(int id);

    NotificationResponseRecord Create(
        CreateNotificationRecord record);

    NotificationResponseRecord? Update(
        int id,
        UpdateNotificationRecord record);

    bool Delete(int id);
}