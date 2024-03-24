using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Replyment.Application.Abstraction.Services.Trigger;
using Replyment.Application.DTOs.Slider;
using Replyment.Application.DTOs.Trigger;
using System.Net;

namespace Replyment.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TriggersController : ControllerBase
{
    private readonly ITriggerService _triggerService;

    public TriggersController(ITriggerService triggerService)
        => _triggerService = triggerService;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var trigers = await _triggerService.GetAllAsync();
        return Ok(trigers);
    }

    [HttpDelete("{id:Guid}")]
    public async Task<IActionResult> Remove(Guid id)
    {
        await _triggerService.Remove(id);
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> CreateSlider([FromForm] CreateTrggerDto createTrggerDto)
    {
        await _triggerService.CreateAsync(createTrggerDto);
        return StatusCode((int)HttpStatusCode.Created);
    }

}
