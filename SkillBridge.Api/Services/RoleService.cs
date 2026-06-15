using SkillBridge.Api.Interfaces;
using SkillBridge.Api.Models;
using SkillBridge.Api.Records;

namespace SkillBridge.Api.Services;

public class RoleService : IRoleService
{
    private readonly List<Role> _roles = new();

    private readonly ILogger<RoleService> _logger;

    private int _nextId = 1;

    public RoleService(ILogger<RoleService> logger)
    {
        _logger = logger;
    }

    public IEnumerable<RoleResponseRecord> GetAll()
    {
        _logger.LogInformation("Retrieving all roles.");

        return _roles.Select(r =>
            new RoleResponseRecord(
                r.Id,
                r.Name,
                r.Description));
    }

    public RoleResponseRecord? GetById(int id)
    {
        _logger.LogInformation(
            "Retrieving role {RoleId}",
            id);

        var role = _roles.FirstOrDefault(r => r.Id == id);

        if (role is null)
        {
            _logger.LogWarning(
                "Role {RoleId} not found.",
                id);

            return null;
        }

        return new RoleResponseRecord(
            role.Id,
            role.Name,
            role.Description);
    }

    public RoleResponseRecord Create(CreateRoleRecord record)
    {
        var duplicate = _roles.FirstOrDefault(r =>
            r.Name.Equals(
                record.Name,
                StringComparison.OrdinalIgnoreCase));

        if (duplicate is not null)
        {
            _logger.LogWarning(
                "Duplicate role creation attempted: {RoleName}",
                record.Name);

            throw new InvalidOperationException(
                $"Role '{record.Name}' already exists.");
        }

        var role = new Role
        {
            Id = _nextId++,
            Name = record.Name,
            Description = record.Description
        };

        _roles.Add(role);

        _logger.LogInformation(
            "Role created successfully: {RoleName}",
            role.Name);

        return new RoleResponseRecord(
            role.Id,
            role.Name,
            role.Description);
    }

    public RoleResponseRecord? Update(
    int id,
    UpdateRoleRecord record)
{
    var role = _roles.FirstOrDefault(r => r.Id == id);

    if (role is null)
    {
        _logger.LogWarning(
            "Role {RoleId} not found for update.",
            id);

        return null;
    }

    var duplicate = _roles.FirstOrDefault(r =>
        r.Id != id &&
        r.Name.Equals(
            record.Name,
            StringComparison.OrdinalIgnoreCase));

    if (duplicate is not null)
    {
        _logger.LogWarning(
            "Duplicate role update attempted: {RoleName}",
            record.Name);

        throw new InvalidOperationException(
            $"Role '{record.Name}' already exists.");
    }

    role.Name = record.Name;
    role.Description = record.Description;

    _logger.LogInformation(
        "Role {RoleId} updated successfully.",
        id);

    return new RoleResponseRecord(
        role.Id,
        role.Name,
        role.Description);
}

    public bool Delete(int id)
    {
        var role = _roles.FirstOrDefault(r => r.Id == id);

        if (role is null)
        {
            _logger.LogWarning(
                "Role {RoleId} not found.",
                id);

            return false;
        }

        _roles.Remove(role);

        _logger.LogInformation(
            "Role {RoleId} deleted successfully.",
            id);

        return true;
    }
}