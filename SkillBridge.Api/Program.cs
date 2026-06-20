using SkillBridge.Api.Interfaces;
using SkillBridge.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependency Injection
builder.Services.AddSingleton<IRoleService, RoleService>();
builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddSingleton<IGraduateProfileService, GraduateProfileService>();
builder.Services.AddSingleton<IEmployerProfileService, EmployerProfileService>();
builder.Services.AddSingleton<ISkillService, SkillService>();
builder.Services.AddSingleton<IOpportunityService, OpportunityService>();
builder.Services.AddSingleton<IApplicationService, ApplicationService>();
builder.Services.AddSingleton<IPortfolioProjectService, PortfolioProjectService>();
var app = builder.Build();


// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();