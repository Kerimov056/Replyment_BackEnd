using Microsoft.AspNetCore.Mvc;
using Replyment.Application.Abstraction.Services.WidgetAllStyle;
using Replyment.Application.DTOs.Slider;
using Replyment.Application.DTOs.WidgetAllStyle;
using System.Net;

namespace Replyment.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WidgetAllStylesController : ControllerBase
{
    private readonly IWidgetAllStyleService _widgetAllStyleService;
	public WidgetAllStylesController(IWidgetAllStyleService widgetAllStyleService)
        => _widgetAllStyleService = widgetAllStyleService;


    [HttpGet]
    public async Task<IActionResult> GetAll(string AppUserId)
    {
        var widget = await _widgetAllStyleService.GetAllAsync(AppUserId);
        return Ok(widget);
    }

    [HttpPost]
    public async Task<IActionResult> CreateSlider([FromBody] CreateWidgetAllStyleDto createWidgetAllStyleDto)
    {
        await _widgetAllStyleService.CreateAsync(createWidgetAllStyleDto);
        return StatusCode((int)HttpStatusCode.Created);
    }

}
