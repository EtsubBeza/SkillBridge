using Microsoft.AspNetCore.Mvc;
using SkillBridge.Api.Interfaces;
using SkillBridge.Api.Records;

namespace SkillBridge.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ApplicationsController : ControllerBase
{
    private readonly IApplicationService _applicationService;

    public ApplicationsController(
        IApplicationService applicationService)
    {
        _applicationService = applicationService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_applicationService.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var application =
            _applicationService.GetById(id);

        if (application is null)
        {
            return NotFound();
        }

        return Ok(application);
    }

    [HttpPost]
    public IActionResult Create(
        CreateApplicationRecord record)
    {
        try
        {
            var created =
                _applicationService.Create(record);

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
        UpdateApplicationRecord record)
    {
        var updated =
            _applicationService.Update(id, record);

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
            _applicationService.Delete(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}