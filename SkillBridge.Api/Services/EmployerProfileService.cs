using SkillBridge.Api.Interfaces;
using SkillBridge.Api.Models;
using SkillBridge.Api.Records;

namespace SkillBridge.Api.Services;

public class EmployerProfileService : IEmployerProfileService
{
    private readonly List<EmployerProfile> _profiles = new();

    private readonly ILogger<EmployerProfileService> _logger;

    private int _nextId = 1;

    public EmployerProfileService(
        ILogger<EmployerProfileService> logger)
    {
        _logger = logger;
    }

    public IEnumerable<EmployerProfileResponseRecord> GetAll()
    {
        _logger.LogInformation(
            "Retrieving all employer profiles.");

        return _profiles.Select(p =>
            new EmployerProfileResponseRecord(
                p.Id,
                p.UserId,
                p.CompanyName,
                p.Industry,
                p.CompanyDescription,
                p.WebsiteUrl,
                p.Location,
                p.IsVerified,
                p.CreatedAt));
    }

    public EmployerProfileResponseRecord? GetById(int id)
    {
        _logger.LogInformation(
            "Retrieving employer profile {ProfileId}",
            id);

        var profile = _profiles.FirstOrDefault(
            p => p.Id == id);

        if (profile is null)
        {
            _logger.LogWarning(
                "Employer profile {ProfileId} not found.",
                id);

            return null;
        }

        return new EmployerProfileResponseRecord(
            profile.Id,
            profile.UserId,
            profile.CompanyName,
            profile.Industry,
            profile.CompanyDescription,
            profile.WebsiteUrl,
            profile.Location,
            profile.IsVerified,
            profile.CreatedAt);
    }

    public EmployerProfileResponseRecord Create(
        CreateEmployerProfileRecord record)
    {
        var duplicate = _profiles.FirstOrDefault(
            p => p.UserId == record.UserId);

        if (duplicate is not null)
        {
            _logger.LogWarning(
                "Employer profile already exists for User {UserId}",
                record.UserId);

            throw new InvalidOperationException(
                $"Employer profile already exists for User {record.UserId}");
        }

        var profile = new EmployerProfile
        {
            Id = _nextId++,
            UserId = record.UserId,
            CompanyName = record.CompanyName,
            Industry = record.Industry,
            CompanyDescription = record.CompanyDescription,
            WebsiteUrl = record.WebsiteUrl,
            Location = record.Location,
            IsVerified = false,
            CreatedAt = DateTime.UtcNow
        };

        _profiles.Add(profile);

        _logger.LogInformation(
            "Employer profile created for User {UserId}",
            profile.UserId);

        return new EmployerProfileResponseRecord(
            profile.Id,
            profile.UserId,
            profile.CompanyName,
            profile.Industry,
            profile.CompanyDescription,
            profile.WebsiteUrl,
            profile.Location,
            profile.IsVerified,
            profile.CreatedAt);
    }

    public EmployerProfileResponseRecord? Update(
        int id,
        UpdateEmployerProfileRecord record)
    {
        var profile = _profiles.FirstOrDefault(
            p => p.Id == id);

        if (profile is null)
        {
            _logger.LogWarning(
                "Employer profile {ProfileId} not found for update.",
                id);

            return null;
        }

        profile.CompanyName = record.CompanyName;
        profile.Industry = record.Industry;
        profile.CompanyDescription = record.CompanyDescription;
        profile.WebsiteUrl = record.WebsiteUrl;
        profile.Location = record.Location;
        profile.IsVerified = record.IsVerified;

        _logger.LogInformation(
            "Employer profile {ProfileId} updated successfully.",
            id);

        return new EmployerProfileResponseRecord(
            profile.Id,
            profile.UserId,
            profile.CompanyName,
            profile.Industry,
            profile.CompanyDescription,
            profile.WebsiteUrl,
            profile.Location,
            profile.IsVerified,
            profile.CreatedAt);
    }

    public bool Delete(int id)
    {
        var profile = _profiles.FirstOrDefault(
            p => p.Id == id);

        if (profile is null)
        {
            _logger.LogWarning(
                "Employer profile {ProfileId} not found.",
                id);

            return false;
        }

        _profiles.Remove(profile);

        _logger.LogInformation(
            "Employer profile {ProfileId} deleted successfully.",
            id);

        return true;
    }
}