using SkillBridge.Api.Interfaces;
using SkillBridge.Api.Models;
using SkillBridge.Api.Records;

namespace SkillBridge.Api.Services;

public class ApplicationService : IApplicationService
{
    private readonly List<Application> _applications = new();

    private readonly ILogger<ApplicationService> _logger;

    private int _nextId = 1;

    public ApplicationService(
        ILogger<ApplicationService> logger)
    {
        _logger = logger;
    }

    public IEnumerable<ApplicationResponseRecord> GetAll()
    {
        _logger.LogInformation(
            "Retrieving all applications.");

        return _applications.Select(a =>
            new ApplicationResponseRecord(
                a.Id,
                a.OpportunityId,
                a.GraduateProfileId,
                a.CoverLetter,
                a.Status,
                a.AppliedAt));
    }

    public ApplicationResponseRecord? GetById(int id)
    {
        _logger.LogInformation(
            "Retrieving application {ApplicationId}",
            id);

        var application = _applications.FirstOrDefault(
            a => a.Id == id);

        if (application is null)
        {
            _logger.LogWarning(
                "Application {ApplicationId} not found.",
                id);

            return null;
        }

        return new ApplicationResponseRecord(
            application.Id,
            application.OpportunityId,
            application.GraduateProfileId,
            application.CoverLetter,
            application.Status,
            application.AppliedAt);
    }

    public ApplicationResponseRecord Create(
        CreateApplicationRecord record)
    {
        var duplicate = _applications.FirstOrDefault(
            a => a.OpportunityId == record.OpportunityId &&
                 a.GraduateProfileId == record.GraduateProfileId);

        if (duplicate is not null)
        {
            _logger.LogWarning(
                "GraduateProfile {GraduateProfileId} has already applied to Opportunity {OpportunityId}",
                record.GraduateProfileId,
                record.OpportunityId);

            throw new InvalidOperationException(
                "You have already applied to this opportunity.");
        }

        var application = new Application
        {
            Id = _nextId++,
            OpportunityId = record.OpportunityId,
            GraduateProfileId = record.GraduateProfileId,
            CoverLetter = record.CoverLetter,
            Status = "Pending",
            AppliedAt = DateTime.UtcNow
        };

        _applications.Add(application);

        _logger.LogInformation(
            "Application {ApplicationId} created successfully.",
            application.Id);

        return new ApplicationResponseRecord(
            application.Id,
            application.OpportunityId,
            application.GraduateProfileId,
            application.CoverLetter,
            application.Status,
            application.AppliedAt);
    }

    public ApplicationResponseRecord? Update(
        int id,
        UpdateApplicationRecord record)
    {
        var application = _applications.FirstOrDefault(
            a => a.Id == id);

        if (application is null)
        {
            _logger.LogWarning(
                "Application {ApplicationId} not found for update.",
                id);

            return null;
        }

        application.Status = record.Status;

        _logger.LogInformation(
            "Application {ApplicationId} status updated to {Status}",
            id,
            record.Status);

        return new ApplicationResponseRecord(
            application.Id,
            application.OpportunityId,
            application.GraduateProfileId,
            application.CoverLetter,
            application.Status,
            application.AppliedAt);
    }

    public bool Delete(int id)
    {
        var application = _applications.FirstOrDefault(
            a => a.Id == id);

        if (application is null)
        {
            _logger.LogWarning(
                "Application {ApplicationId} not found.",
                id);

            return false;
        }

        _applications.Remove(application);

        _logger.LogInformation(
            "Application {ApplicationId} deleted successfully.",
            id);

        return true;
    }
}