using Microsoft.EntityFrameworkCore;
using SkillBridge.Api.Models;

namespace SkillBridge.Api.Data;

public class SkillBridgeDbContext : DbContext
{
    public SkillBridgeDbContext(
        DbContextOptions<SkillBridgeDbContext> options)
        : base(options)
    {
    }

    public DbSet<Role> Roles => Set<Role>();

    public DbSet<User> Users => Set<User>();

    public DbSet<GraduateProfile> GraduateProfiles => Set<GraduateProfile>();

    public DbSet<EmployerProfile> EmployerProfiles => Set<EmployerProfile>();

    public DbSet<Skill> Skills => Set<Skill>();

    public DbSet<Opportunity> Opportunities => Set<Opportunity>();

    public DbSet<Application> Applications => Set<Application>();

    public DbSet<PortfolioProject> PortfolioProjects => Set<PortfolioProject>();

    public DbSet<Assessment> Assessments => Set<Assessment>();

    public DbSet<Notification> Notifications => Set<Notification>();
}