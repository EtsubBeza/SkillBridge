using SkillBridge.Api.Interfaces;
using SkillBridge.Api.Models;
using SkillBridge.Api.Records;

namespace SkillBridge.Api.Services;

public class SkillService : ISkillService
{
    private readonly List<Skill> _skills = new();

    private readonly ILogger<SkillService> _logger;

    private int _nextId = 1;

    public SkillService(
        ILogger<SkillService> logger)
    {
        _logger = logger;
    }

    public IEnumerable<SkillResponseRecord> GetAll()
    {
        _logger.LogInformation(
            "Retrieving all skills.");

        return _skills.Select(s =>
            new SkillResponseRecord(
                s.Id,
                s.GraduateProfileId,
                s.Name,
                s.Level,
                s.YearsOfExperience,
                s.CreatedAt));
    }

    public SkillResponseRecord? GetById(int id)
    {
        _logger.LogInformation(
            "Retrieving skill {SkillId}",
            id);

        var skill = _skills.FirstOrDefault(
            s => s.Id == id);

        if (skill is null)
        {
            _logger.LogWarning(
                "Skill {SkillId} not found.",
                id);

            return null;
        }

        return new SkillResponseRecord(
            skill.Id,
            skill.GraduateProfileId,
            skill.Name,
            skill.Level,
            skill.YearsOfExperience,
            skill.CreatedAt);
    }

    public SkillResponseRecord Create(
        CreateSkillRecord record)
    {
        var duplicate = _skills.FirstOrDefault(
            s => s.GraduateProfileId == record.GraduateProfileId &&
                 s.Name.Equals(
                     record.Name,
                     StringComparison.OrdinalIgnoreCase));

        if (duplicate is not null)
        {
            _logger.LogWarning(
                "Skill {SkillName} already exists for GraduateProfile {GraduateProfileId}",
                record.Name,
                record.GraduateProfileId);

            throw new InvalidOperationException(
                $"Skill '{record.Name}' already exists for this graduate profile.");
        }

        var skill = new Skill
        {
            Id = _nextId++,
            GraduateProfileId = record.GraduateProfileId,
            Name = record.Name,
            Level = record.Level,
            YearsOfExperience = record.YearsOfExperience,
            CreatedAt = DateTime.UtcNow
        };

        _skills.Add(skill);

        _logger.LogInformation(
            "Skill {SkillName} created successfully.",
            skill.Name);

        return new SkillResponseRecord(
            skill.Id,
            skill.GraduateProfileId,
            skill.Name,
            skill.Level,
            skill.YearsOfExperience,
            skill.CreatedAt);
    }

    public SkillResponseRecord? Update(
        int id,
        UpdateSkillRecord record)
    {
        var skill = _skills.FirstOrDefault(
            s => s.Id == id);

        if (skill is null)
        {
            _logger.LogWarning(
                "Skill {SkillId} not found for update.",
                id);

            return null;
        }

        skill.Name = record.Name;
        skill.Level = record.Level;
        skill.YearsOfExperience = record.YearsOfExperience;

        _logger.LogInformation(
            "Skill {SkillId} updated successfully.",
            id);

        return new SkillResponseRecord(
            skill.Id,
            skill.GraduateProfileId,
            skill.Name,
            skill.Level,
            skill.YearsOfExperience,
            skill.CreatedAt);
    }

    public bool Delete(int id)
    {
        var skill = _skills.FirstOrDefault(
            s => s.Id == id);

        if (skill is null)
        {
            _logger.LogWarning(
                "Skill {SkillId} not found.",
                id);

            return false;
        }

        _skills.Remove(skill);

        _logger.LogInformation(
            "Skill {SkillId} deleted successfully.",
            id);

        return true;
    }
}