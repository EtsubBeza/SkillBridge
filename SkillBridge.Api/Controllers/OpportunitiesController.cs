using Microsoft.AspNetCore.Mvc;
using SkillBridge.Api.Interfaces;
using SkillBridge.Api.Records;

namespace SkillBridge.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OpportunitiesController : ControllerBase
{
    private readonly IOpportunityService _opportunityService;

    public OpportunitiesController(
        IOpportunityService opportunityService)
    {
        _opportunityService = opportunityService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_opportunityService.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var opportunity = _opportunityService.GetById(id);

        if (opportunity is null)
        {
            return NotFound();
        }

        return Ok(opportunity);
    }

    [HttpPost]
    public IActionResult Create(
        CreateOpportunityRecord record)
    {
        var created =
            _opportunityService.Create(record);

        return CreatedAtAction(
            nameof(GetById),
            new { id = created.Id },
            created);
    }

    [HttpPut("{id}")]
    public IActionResult Update(
        int id,
        UpdateOpportunityRecord record)
    {
        var updated =
            _opportunityService.Update(id, record);

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
            _opportunityService.Delete(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}