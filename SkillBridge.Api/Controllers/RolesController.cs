using Microsoft.AspNetCore.Mvc;
using SkillBridge.Api.Interfaces;
using SkillBridge.Api.Records;

namespace SkillBridge.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RolesController : ControllerBase
{
    private readonly IRoleService _roleService;

    public RolesController(IRoleService roleService)
    {
        _roleService = roleService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_roleService.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var role = _roleService.GetById(id);

        if (role is null)
        {
            return NotFound();
        }

        return Ok(role);
    }

    [HttpPost]
    public IActionResult Create(CreateRoleRecord record)
    {
        var createdRole = _roleService.Create(record);

        return CreatedAtAction(
            nameof(GetById),
            new { id = createdRole.Id },
            createdRole);
    }

   [HttpPut("{id}")]
public IActionResult Update(
    int id,
    UpdateRoleRecord record)
{
    try
    {
        var updated = _roleService.Update(id, record);

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
        var deleted = _roleService.Delete(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}