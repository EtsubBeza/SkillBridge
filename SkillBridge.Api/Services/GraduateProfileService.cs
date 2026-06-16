using SkillBridge.Api.Interfaces;
using SkillBridge.Api.Models;
using SkillBridge.Api.Records;

namespace SkillBridge.Api.Services;

public class GraduateProfileService : IGraduateProfileService
{
    private readonly List<GraduateProfile> _profiles = new();

    private readonly ILogger<GraduateProfileService> _logger;

    private int _nextId = 1;

    public GraduateProfileService(
        ILogger<GraduateProfileService> logger)
    {
        _logger = logger;
    }

    public IEnumerable<GraduateProfileResponseRecord> GetAll()
    {
        _logger.LogInformation(
            "Retrieving all graduate profiles.");

        return _profiles.Select(p =>
            new GraduateProfileResponseRecord(
                p.Id,
                p.UserId,
                p.Headline,
                p.Bio,
                p.Education,
                p.University,
                p.GraduationYear,
                p.PortfolioUrl,
                p.IsAvailableForWork,
                p.CreatedAt));
    }

    public GraduateProfileResponseRecord? GetById(int id)
    {
        _logger.LogInformation(
            "Retrieving graduate profile {ProfileId}",
            id);

        var profile = _profiles.FirstOrDefault(
            p => p.Id == id);

        if (profile is null)
        {
            _logger.LogWarning(
                "Graduate profile {ProfileId} not found.",
                id);

            return null;
        }

        return new GraduateProfileResponseRecord(
            profile.Id,
            profile.UserId,
            profile.Headline,
            profile.Bio,
            profile.Education,
            profile.University,
            profile.GraduationYear,
            profile.PortfolioUrl,
            profile.IsAvailableForWork,
            profile.CreatedAt);
    }

    public GraduateProfileResponseRecord Create(
        CreateGraduateProfileRecord record)
    {
        var duplicate = _profiles.FirstOrDefault(
            p => p.UserId == record.UserId);

        if (duplicate is not null)
        {
            _logger.LogWarning(
                "Graduate profile already exists for User {UserId}",
                record.UserId);

            throw new InvalidOperationException(
                $"Graduate profile already exists for User {record.UserId}");
        }

        var profile = new GraduateProfile
        {
            Id = _nextId++,
            UserId = record.UserId,
            Headline = record.Headline,
            Bio = record.Bio,
            Education = record.Education,
            University = record.University,
            GraduationYear = record.GraduationYear,
            PortfolioUrl = record.PortfolioUrl,
            IsAvailableForWork = true,
            CreatedAt = DateTime.UtcNow
        };

        _profiles.Add(profile);

        _logger.LogInformation(
            "Graduate profile created for User {UserId}",
            profile.UserId);

        return new GraduateProfileResponseRecord(
            profile.Id,
            profile.UserId,
            profile.Headline,
            profile.Bio,
            profile.Education,
            profile.University,
            profile.GraduationYear,
            profile.PortfolioUrl,
            profile.IsAvailableForWork,
            profile.CreatedAt);
    }

    public GraduateProfileResponseRecord? Update(
        int id,
        UpdateGraduateProfileRecord record)
    {
        var profile = _profiles.FirstOrDefault(
            p => p.Id == id);

        if (profile is null)
        {
            _logger.LogWarning(
                "Graduate profile {ProfileId} not found for update.",
                id);

            return null;
        }

        profile.Headline = record.Headline;
        profile.Bio = record.Bio;
        profile.Education = record.Education;
        profile.University = record.University;
        profile.GraduationYear = record.GraduationYear;
        profile.PortfolioUrl = record.PortfolioUrl;
        profile.IsAvailableForWork = record.IsAvailableForWork;

        _logger.LogInformation(
            "Graduate profile {ProfileId} updated successfully.",
            id);

        return new GraduateProfileResponseRecord(
            profile.Id,
            profile.UserId,
            profile.Headline,
            profile.Bio,
            profile.Education,
            profile.University,
            profile.GraduationYear,
            profile.PortfolioUrl,
            profile.IsAvailableForWork,
            profile.CreatedAt);
    }

    public bool Delete(int id)
    {
        var profile = _profiles.FirstOrDefault(
            p => p.Id == id);

        if (profile is null)
        {
            _logger.LogWarning(
                "Graduate profile {ProfileId} not found.",
                id);

            return false;
        }

        _profiles.Remove(profile);

        _logger.LogInformation(
            "Graduate profile {ProfileId} deleted successfully.",
            id);

        return true;
    }
}