using Microsoft.AspNetCore.Mvc;
using SkillBridge.Api.Interfaces;
using SkillBridge.Api.Records;

namespace SkillBridge.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SkillsController : ControllerBase
{
    private readonly ISkillService _skillService;

    public SkillsController(ISkillService skillService)
    {
        _skillService = skillService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_skillService.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var skill = _skillService.GetById(id);

        if (skill is null)
        {
            return NotFound();
        }

        return Ok(skill);
    }

    [HttpPost]
    public IActionResult Create(CreateSkillRecord record)
    {
        try
        {
            var created = _skillService.Create(record);

            return CreatedAtAction(
                nameof(GetById),
                new { id = created.Id },
                created);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new
            {
                message = ex.Message
            });
        }
    }

    [HttpPut("{id}")]
    public IActionResult Update(
        int id,
        UpdateSkillRecord record)
    {
        var updated = _skillService.Update(id, record);

        if (updated is null)
        {
            return NotFound();
        }

        return Ok(updated);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var deleted = _skillService.Delete(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}