using Microsoft.AspNetCore.Mvc;
using SkillBridge.Api.Interfaces;
using SkillBridge.Api.Records;

namespace SkillBridge.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PortfolioProjectsController : ControllerBase
{
    private readonly IPortfolioProjectService _portfolioProjectService;

    public PortfolioProjectsController(
        IPortfolioProjectService portfolioProjectService)
    {
        _portfolioProjectService = portfolioProjectService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_portfolioProjectService.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var project = _portfolioProjectService.GetById(id);

        if (project is null)
        {
            return NotFound();
        }

        return Ok(project);
    }

    [HttpPost]
    public IActionResult Create(
        CreatePortfolioProjectRecord record)
    {
        var created =
            _portfolioProjectService.Create(record);

        return CreatedAtAction(
            nameof(GetById),
            new { id = created.Id },
            created);
    }

    [HttpPut("{id}")]
    public IActionResult Update(
        int id,
        UpdatePortfolioProjectRecord record)
    {
        var updated =
            _portfolioProjectService.Update(id, record);

        if (updated is null)
        {
            return NotFound();
        }

        return Ok(updated);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var deleted =
            _portfolioProjectService.Delete(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}