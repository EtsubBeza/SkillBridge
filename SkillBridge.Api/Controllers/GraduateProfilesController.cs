using Microsoft.AspNetCore.Mvc;
using SkillBridge.Api.Interfaces;
using SkillBridge.Api.Records;

namespace SkillBridge.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GraduateProfilesController : ControllerBase
{
    private readonly IGraduateProfileService _graduateProfileService;

    public GraduateProfilesController(
        IGraduateProfileService graduateProfileService)
    {
        _graduateProfileService = graduateProfileService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_graduateProfileService.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var profile = _graduateProfileService.GetById(id);

        if (profile is null)
        {
            return NotFound();
        }

        return Ok(profile);
    }

    [HttpPost]
    public IActionResult Create(
        CreateGraduateProfileRecord record)
    {
        try
        {
            var created =
                _graduateProfileService.Create(record);

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
        UpdateGraduateProfileRecord record)
    {
        var updated =
            _graduateProfileService.Update(id, record);

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
            _graduateProfileService.Delete(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}