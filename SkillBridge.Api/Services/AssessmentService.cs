using SkillBridge.Api.Interfaces;
using SkillBridge.Api.Models;
using SkillBridge.Api.Records;

namespace SkillBridge.Api.Services;

public class AssessmentService : IAssessmentService
{
    private readonly List<Assessment> _assessments = new();

    private readonly ILogger<AssessmentService> _logger;

    private int _nextId = 1;

    public AssessmentService(
        ILogger<AssessmentService> logger)
    {
        _logger = logger;
    }

    public IEnumerable<AssessmentResponseRecord> GetAll()
    {
        _logger.LogInformation(
            "Retrieving all assessments.");

        return _assessments.Select(a =>
            new AssessmentResponseRecord(
                a.Id,
                a.OpportunityId,
                a.Title,
                a.Description,
                a.PassingScore,
                a.CreatedAt));
    }

    public AssessmentResponseRecord? GetById(int id)
    {
        _logger.LogInformation(
            "Retrieving assessment {AssessmentId}",
            id);

        var assessment = _assessments.FirstOrDefault(
            a => a.Id == id);

        if (assessment is null)
        {
            _logger.LogWarning(
                "Assessment {AssessmentId} not found.",
                id);

            return null;
        }

        return new AssessmentResponseRecord(
            assessment.Id,
            assessment.OpportunityId,
            assessment.Title,
            assessment.Description,
            assessment.PassingScore,
            assessment.CreatedAt);
    }

    public AssessmentResponseRecord Create(
        CreateAssessmentRecord record)
    {
        if (record.PassingScore < 0 ||
            record.PassingScore > 100)
        {
            throw new InvalidOperationException(
                "Passing score must be between 0 and 100.");
        }

        var assessment = new Assessment
        {
            Id = _nextId++,
            OpportunityId = record.OpportunityId,
            Title = record.Title,
            Description = record.Description,
            PassingScore = record.PassingScore,
            CreatedAt = DateTime.UtcNow
        };

        _assessments.Add(assessment);

        _logger.LogInformation(
            "Assessment {Title} created successfully.",
            assessment.Title);

        return new AssessmentResponseRecord(
            assessment.Id,
            assessment.OpportunityId,
            assessment.Title,
            assessment.Description,
            assessment.PassingScore,
            assessment.CreatedAt);
    }

    public AssessmentResponseRecord? Update(
        int id,
        UpdateAssessmentRecord record)
    {
        var assessment = _assessments.FirstOrDefault(
            a => a.Id == id);

        if (assessment is null)
        {
            _logger.LogWarning(
                "Assessment {AssessmentId} not found.",
                id);

            return null;
        }

        if (record.PassingScore < 0 ||
            record.PassingScore > 100)
        {
            throw new InvalidOperationException(
                "Passing score must be between 0 and 100.");
        }

        assessment.Title = record.Title;
        assessment.Description = record.Description;
        assessment.PassingScore = record.PassingScore;

        _logger.LogInformation(
            "Assessment {AssessmentId} updated successfully.",
            id);

        return new AssessmentResponseRecord(
            assessment.Id,
            assessment.OpportunityId,
            assessment.Title,
            assessment.Description,
            assessment.PassingScore,
            assessment.CreatedAt);
    }

    public bool Delete(int id)
    {
        var assessment = _assessments.FirstOrDefault(
            a => a.Id == id);

        if (assessment is null)
        {
            _logger.LogWarning(
                "Assessment {AssessmentId} not found.",
                id);

            return false;
        }

        _assessments.Remove(assessment);

        _logger.LogInformation(
            "Assessment {AssessmentId} deleted successfully.",
            id);

        return true;
    }
}