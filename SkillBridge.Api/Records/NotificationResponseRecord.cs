namespace SkillBridge.Api.Records;

public record NotificationResponseRecord(
    int Id,
    int UserId,
    string Title,
    string Message,
    bool IsRead,
    DateTime CreatedAt
);