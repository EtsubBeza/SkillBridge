namespace SkillBridge.Api.Records;

public record CreateNotificationRecord(
    int UserId,
    string Title,
    string Message
);