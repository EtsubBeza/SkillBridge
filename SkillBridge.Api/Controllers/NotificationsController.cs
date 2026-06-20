using Microsoft.AspNetCore.Mvc;
using SkillBridge.Api.Interfaces;
using SkillBridge.Api.Records;

namespace SkillBridge.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NotificationsController : ControllerBase
{
    private readonly INotificationService _notificationService;

    public NotificationsController(
        INotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_notificationService.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var notification =
            _notificationService.GetById(id);

        if (notification is null)
        {
            return NotFound();
        }

        return Ok(notification);
    }

    [HttpPost]
    public IActionResult Create(
        CreateNotificationRecord record)
    {
        var created =
            _notificationService.Create(record);

        return CreatedAtAction(
            nameof(GetById),
            new { id = created.Id },
            created);
    }

    [HttpPut("{id}")]
    public IActionResult Update(
        int id,
        UpdateNotificationRecord record)
    {
        var updated =
            _notificationService.Update(id, record);

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
            _notificationService.Delete(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}