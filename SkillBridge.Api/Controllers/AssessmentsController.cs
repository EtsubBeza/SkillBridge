using Microsoft.AspNetCore.Mvc;
using SkillBridge.Api.Interfaces;
using SkillBridge.Api.Records;

namespace SkillBridge.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AssessmentsController : ControllerBase
{
    private readonly IAssessmentService _assessmentService;

    public AssessmentsController(
        IAssessmentService assessmentService)
    {
        _assessmentService = assessmentService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_assessmentService.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var assessment = _assessmentService.GetById(id);

        if (assessment is null)
        {
            return NotFound();
        }

        return Ok(assessment);
    }

    [HttpPost]
    public IActionResult Create(
        CreateAssessmentRecord record)
    {
        try
        {
            var created =
                _assessmentService.Create(record);

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
        UpdateAssessmentRecord record)
    {
        try
        {
            var updated =
                _assessmentService.Update(id, record);

            if (updated is null)
            {
                return NotFound();
            }

            return Ok(updated);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new
            {
                message = ex.Message
            });
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var deleted =
            _assessmentService.Delete(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}