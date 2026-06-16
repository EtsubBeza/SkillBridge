using SkillBridge.Api.Interfaces;
using SkillBridge.Api.Models;
using SkillBridge.Api.Records;

namespace SkillBridge.Api.Services;

public class UserService : IUserService
{
    private readonly List<User> _users = new();

    private readonly ILogger<UserService> _logger;

    private int _nextId = 1;

    public UserService(ILogger<UserService> logger)
    {
        _logger = logger;
    }

    public IEnumerable<UserResponseRecord> GetAll()
    {
        _logger.LogInformation("Retrieving all users.");

        return _users.Select(u =>
            new UserResponseRecord(
                u.Id,
                u.FirstName,
                u.LastName,
                u.Email,
                u.PhoneNumber,
                u.RoleId,
                u.CreatedAt,
                u.IsActive));
    }

    public UserResponseRecord? GetById(int id)
    {
        _logger.LogInformation(
            "Retrieving user {UserId}",
            id);

        var user = _users.FirstOrDefault(u => u.Id == id);

        if (user is null)
        {
            _logger.LogWarning(
                "User {UserId} not found.",
                id);

            return null;
        }

        return new UserResponseRecord(
            user.Id,
            user.FirstName,
            user.LastName,
            user.Email,
            user.PhoneNumber,
            user.RoleId,
            user.CreatedAt,
            user.IsActive);
    }

    public UserResponseRecord Create(CreateUserRecord record)
    {
        var duplicate = _users.FirstOrDefault(u =>
            u.Email.Equals(
                record.Email,
                StringComparison.OrdinalIgnoreCase));

        if (duplicate is not null)
        {
            _logger.LogWarning(
                "Duplicate email registration attempted: {Email}",
                record.Email);

            throw new InvalidOperationException(
                $"User with email '{record.Email}' already exists.");
        }

        var user = new User
        {
            Id = _nextId++,
            FirstName = record.FirstName,
            LastName = record.LastName,
            Email = record.Email,
            Password = record.Password,
            PhoneNumber = record.PhoneNumber,
            RoleId = record.RoleId,
            CreatedAt = DateTime.UtcNow,
            IsActive = true
        };

        _users.Add(user);

        _logger.LogInformation(
            "User created successfully: {Email}",
            user.Email);

        return new UserResponseRecord(
            user.Id,
            user.FirstName,
            user.LastName,
            user.Email,
            user.PhoneNumber,
            user.RoleId,
            user.CreatedAt,
            user.IsActive);
    }

    public UserResponseRecord? Update(
        int id,
        UpdateUserRecord record)
    {
        var user = _users.FirstOrDefault(u => u.Id == id);

        if (user is null)
        {
            _logger.LogWarning(
                "User {UserId} not found for update.",
                id);

            return null;
        }

        var duplicate = _users.FirstOrDefault(u =>
            u.Id != id &&
            u.Email.Equals(
                record.Email,
                StringComparison.OrdinalIgnoreCase));

        if (duplicate is not null)
        {
            _logger.LogWarning(
                "Duplicate email update attempted: {Email}",
                record.Email);

            throw new InvalidOperationException(
                $"User with email '{record.Email}' already exists.");
        }

        user.FirstName = record.FirstName;
        user.LastName = record.LastName;
        user.Email = record.Email;
        user.PhoneNumber = record.PhoneNumber;
        user.RoleId = record.RoleId;
        user.IsActive = record.IsActive;

        _logger.LogInformation(
            "User {UserId} updated successfully.",
            id);

        return new UserResponseRecord(
            user.Id,
            user.FirstName,
            user.LastName,
            user.Email,
            user.PhoneNumber,
            user.RoleId,
            user.CreatedAt,
            user.IsActive);
    }

    public bool Delete(int id)
    {
        var user = _users.FirstOrDefault(u => u.Id == id);

        if (user is null)
        {
            _logger.LogWarning(
                "User {UserId} not found.",
                id);

            return false;
        }

        _users.Remove(user);

        _logger.LogInformation(
            "User {UserId} deleted successfully.",
            id);

        return true;
    }
}