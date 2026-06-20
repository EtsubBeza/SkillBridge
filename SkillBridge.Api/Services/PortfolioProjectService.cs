using SkillBridge.Api.Interfaces;
using SkillBridge.Api.Models;
using SkillBridge.Api.Records;

namespace SkillBridge.Api.Services;

public class PortfolioProjectService : IPortfolioProjectService
{
    private readonly List<PortfolioProject> _projects = new();

    private readonly ILogger<PortfolioProjectService> _logger;

    private int _nextId = 1;

    public PortfolioProjectService(
        ILogger<PortfolioProjectService> logger)
    {
        _logger = logger;
    }

    public IEnumerable<PortfolioProjectResponseRecord> GetAll()
    {
        _logger.LogInformation(
            "Retrieving all portfolio projects.");

        return _projects.Select(p =>
            new PortfolioProjectResponseRecord(
                p.Id,
                p.GraduateProfileId,
                p.Title,
                p.Description,
                p.TechnologiesUsed,
                p.ProjectUrl,
                p.GithubUrl,
                p.CreatedAt));
    }

    public PortfolioProjectResponseRecord? GetById(int id)
    {
        _logger.LogInformation(
            "Retrieving portfolio project {ProjectId}",
            id);

        var project = _projects.FirstOrDefault(
            p => p.Id == id);

        if (project is null)
        {
            _logger.LogWarning(
                "Portfolio project {ProjectId} not found.",
                id);

            return null;
        }

        return new PortfolioProjectResponseRecord(
            project.Id,
            project.GraduateProfileId,
            project.Title,
            project.Description,
            project.TechnologiesUsed,
            project.ProjectUrl,
            project.GithubUrl,
            project.CreatedAt);
    }

    public PortfolioProjectResponseRecord Create(
        CreatePortfolioProjectRecord record)
    {
        var project = new PortfolioProject
        {
            Id = _nextId++,
            GraduateProfileId = record.GraduateProfileId,
            Title = record.Title,
            Description = record.Description,
            TechnologiesUsed = record.TechnologiesUsed,
            ProjectUrl = record.ProjectUrl,
            GithubUrl = record.GithubUrl,
            CreatedAt = DateTime.UtcNow
        };

        _projects.Add(project);

        _logger.LogInformation(
            "Portfolio project {ProjectTitle} created.",
            project.Title);

        return new PortfolioProjectResponseRecord(
            project.Id,
            project.GraduateProfileId,
            project.Title,
            project.Description,
            project.TechnologiesUsed,
            project.ProjectUrl,
            project.GithubUrl,
            project.CreatedAt);
    }

    public PortfolioProjectResponseRecord? Update(
        int id,
        UpdatePortfolioProjectRecord record)
    {
        var project = _projects.FirstOrDefault(
            p => p.Id == id);

        if (project is null)
        {
            _logger.LogWarning(
                "Portfolio project {ProjectId} not found.",
                id);

            return null;
        }

        project.Title = record.Title;
        project.Description = record.Description;
        project.TechnologiesUsed = record.TechnologiesUsed;
        project.ProjectUrl = record.ProjectUrl;
        project.GithubUrl = record.GithubUrl;

        _logger.LogInformation(
            "Portfolio project {ProjectId} updated.",
            id);

        return new PortfolioProjectResponseRecord(
            project.Id,
            project.GraduateProfileId,
            project.Title,
            project.Description,
            project.TechnologiesUsed,
            project.ProjectUrl,
            project.GithubUrl,
            project.CreatedAt);
    }

    public bool Delete(int id)
    {
        var project = _projects.FirstOrDefault(
            p => p.Id == id);

        if (project is null)
        {
            _logger.LogWarning(
                "Portfolio project {ProjectId} not found.",
                id);

            return false;
        }

        _projects.Remove(project);

        _logger.LogInformation(
            "Portfolio project {ProjectId} deleted.",
            id);

        return true;
    }
}