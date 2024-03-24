using Microsoft.AspNetCore.Mvc;
using Replyment.Application.Abstraction.Services.Subscription;
using Replyment.Application.DTOs.Subscription;
using System.Net;

namespace Replyment.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubscriptionsController : ControllerBase
{
    private readonly ISubscriptionService _subscriptionService;
	public SubscriptionsController(ISubscriptionService subscriptionService)
     => _subscriptionService = subscriptionService;

    [HttpGet("{AppUserId:Guid}")]
    public async Task<IActionResult> GetById(string AppUserId)
    {
        var bySubscription = await _subscriptionService.GetByIdAsync(AppUserId);
        return Ok(bySubscription);
    }

    [HttpPost]
    public async Task<IActionResult> CreateSlider([FromForm] CreateSubscriptionDto createSubscriptionDto)
    {
        await _subscriptionService.CreateAsync(createSubscriptionDto);
        return StatusCode((int)HttpStatusCode.Created);
    }

}
