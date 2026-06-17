using Microsoft.AspNetCore.Mvc;
using SkillBridge.Api.Interfaces;
using SkillBridge.Api.Records;

namespace SkillBridge.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployerProfilesController : ControllerBase
{
    private readonly IEmployerProfileService _employerProfileService;

    public EmployerProfilesController(
        IEmployerProfileService employerProfileService)
    {
        _employerProfileService = employerProfileService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_employerProfileService.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var profile = _employerProfileService.GetById(id);

        if (profile is null)
        {
            return NotFound();
        }

        return Ok(profile);
    }

    [HttpPost]
    public IActionResult Create(
        CreateEmployerProfileRecord record)
    {
        try
        {
            var created =
                _employerProfileService.Create(record);

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
        UpdateEmployerProfileRecord record)
    {
        var updated =
            _employerProfileService.Update(id, record);

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
            _employerProfileService.Delete(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}