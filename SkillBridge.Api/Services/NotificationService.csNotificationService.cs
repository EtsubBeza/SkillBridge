using SkillBridge.Api.Interfaces;
using SkillBridge.Api.Models;
using SkillBridge.Api.Records;

namespace SkillBridge.Api.Services;

public class NotificationService : INotificationService
{
    private readonly List<Notification> _notifications = new();

    private readonly ILogger<NotificationService> _logger;

    private int _nextId = 1;

    public NotificationService(
        ILogger<NotificationService> logger)
    {
        _logger = logger;
    }

    public IEnumerable<NotificationResponseRecord> GetAll()
    {
        _logger.LogInformation(
            "Retrieving all notifications.");

        return _notifications.Select(n =>
            new NotificationResponseRecord(
                n.Id,
                n.UserId,
                n.Title,
                n.Message,
                n.IsRead,
                n.CreatedAt));
    }

    public NotificationResponseRecord? GetById(int id)
    {
        _logger.LogInformation(
            "Retrieving notification {NotificationId}",
            id);

        var notification = _notifications
            .FirstOrDefault(n => n.Id == id);

        if (notification is null)
        {
            _logger.LogWarning(
                "Notification {NotificationId} not found.",
                id);

            return null;
        }

        return new NotificationResponseRecord(
            notification.Id,
            notification.UserId,
            notification.Title,
            notification.Message,
            notification.IsRead,
            notification.CreatedAt);
    }

    public NotificationResponseRecord Create(
        CreateNotificationRecord record)
    {
        var notification = new Notification
        {
            Id = _nextId++,
            UserId = record.UserId,
            Title = record.Title,
            Message = record.Message,
            IsRead = false,
            CreatedAt = DateTime.UtcNow
        };

        _notifications.Add(notification);

        _logger.LogInformation(
            "Notification {NotificationId} created.",
            notification.Id);

        return new NotificationResponseRecord(
            notification.Id,
            notification.UserId,
            notification.Title,
            notification.Message,
            notification.IsRead,
            notification.CreatedAt);
    }

    public NotificationResponseRecord? Update(
        int id,
        UpdateNotificationRecord record)
    {
        var notification = _notifications
            .FirstOrDefault(n => n.Id == id);

        if (notification is null)
        {
            _logger.LogWarning(
                "Notification {NotificationId} not found.",
                id);

            return null;
        }

        notification.IsRead = record.IsRead;

        _logger.LogInformation(
            "Notification {NotificationId} updated.",
            id);

        return new NotificationResponseRecord(
            notification.Id,
            notification.UserId,
            notification.Title,
            notification.Message,
            notification.IsRead,
            notification.CreatedAt);
    }

    public bool Delete(int id)
    {
        var notification = _notifications
            .FirstOrDefault(n => n.Id == id);

        if (notification is null)
        {
            _logger.LogWarning(
                "Notification {NotificationId} not found.",
                id);

            return false;
        }

        _notifications.Remove(notification);

        _logger.LogInformation(
            "Notification {NotificationId} deleted.",
            id);

        return true;
    }
}