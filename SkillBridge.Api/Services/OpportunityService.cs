using SkillBridge.Api.Interfaces;
using SkillBridge.Api.Models;
using SkillBridge.Api.Records;

namespace SkillBridge.Api.Services;

public class OpportunityService : IOpportunityService
{
    private readonly List<Opportunity> _opportunities = new();

    private readonly ILogger<OpportunityService> _logger;

    private int _nextId = 1;

    public OpportunityService(
        ILogger<OpportunityService> logger)
    {
        _logger = logger;
    }

    public IEnumerable<OpportunityResponseRecord> GetAll()
    {
        _logger.LogInformation(
            "Retrieving all opportunities.");

        return _opportunities.Select(o =>
            new OpportunityResponseRecord(
                o.Id,
                o.EmployerProfileId,
                o.Title,
                o.Description,
                o.RequiredSkills,
                o.Location,
                o.EmploymentType,
                o.Salary,
                o.IsActive,
                o.CreatedAt));
    }

    public OpportunityResponseRecord? GetById(int id)
    {
        _logger.LogInformation(
            "Retrieving opportunity {OpportunityId}",
            id);

        var opportunity = _opportunities.FirstOrDefault(
            o => o.Id == id);

        if (opportunity is null)
        {
            _logger.LogWarning(
                "Opportunity {OpportunityId} not found.",
                id);

            return null;
        }

        return new OpportunityResponseRecord(
            opportunity.Id,
            opportunity.EmployerProfileId,
            opportunity.Title,
            opportunity.Description,
            opportunity.RequiredSkills,
            opportunity.Location,
            opportunity.EmploymentType,
            opportunity.Salary,
            opportunity.IsActive,
            opportunity.CreatedAt);
    }

    public OpportunityResponseRecord Create(
        CreateOpportunityRecord record)
    {
        var opportunity = new Opportunity
        {
            Id = _nextId++,
            EmployerProfileId = record.EmployerProfileId,
            Title = record.Title,
            Description = record.Description,
            RequiredSkills = record.RequiredSkills,
            Location = record.Location,
            EmploymentType = record.EmploymentType,
            Salary = record.Salary,
            IsActive = true,
            CreatedAt = DateTime.UtcNow
        };

        _opportunities.Add(opportunity);

        _logger.LogInformation(
            "Opportunity {Title} created successfully.",
            opportunity.Title);

        return new OpportunityResponseRecord(
            opportunity.Id,
            opportunity.EmployerProfileId,
            opportunity.Title,
            opportunity.Description,
            opportunity.RequiredSkills,
            opportunity.Location,
            opportunity.EmploymentType,
            opportunity.Salary,
            opportunity.IsActive,
            opportunity.CreatedAt);
    }

    public OpportunityResponseRecord? Update(
        int id,
        UpdateOpportunityRecord record)
    {
        var opportunity = _opportunities.FirstOrDefault(
            o => o.Id == id);

        if (opportunity is null)
        {
            _logger.LogWarning(
                "Opportunity {OpportunityId} not found for update.",
                id);

            return null;
        }

        opportunity.Title = record.Title;
        opportunity.Description = record.Description;
        opportunity.RequiredSkills = record.RequiredSkills;
        opportunity.Location = record.Location;
        opportunity.EmploymentType = record.EmploymentType;
        opportunity.Salary = record.Salary;
        opportunity.IsActive = record.IsActive;

        _logger.LogInformation(
            "Opportunity {OpportunityId} updated successfully.",
            id);

        return new OpportunityResponseRecord(
            opportunity.Id,
            opportunity.EmployerProfileId,
            opportunity.Title,
            opportunity.Description,
            opportunity.RequiredSkills,
            opportunity.Location,
            opportunity.EmploymentType,
            opportunity.Salary,
            opportunity.IsActive,
            opportunity.CreatedAt);
    }

    public bool Delete(int id)
    {
        var opportunity = _opportunities.FirstOrDefault(
            o => o.Id == id);

        if (opportunity is null)
        {
            _logger.LogWarning(
                "Opportunity {OpportunityId} not found.",
                id);

            return false;
        }

        _opportunities.Remove(opportunity);

        _logger.LogInformation(
            "Opportunity {OpportunityId} deleted successfully.",
            id);

        return true;
    }
}