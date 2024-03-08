using Microsoft.AspNetCore.Mvc;
using Replyment.Application.Abstraction.Services.Domain;
using Replyment.Application.DTOs.Domain;
using System.Net;

namespace Replyment.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DomainsController : ControllerBase
{
    private readonly IDomainService _domainService;
    public DomainsController(IDomainService domainService)
     => _domainService = domainService;

    [HttpGet]
    public async Task<IActionResult> GetAll(string AppUserId)
    {
        var slider = await _domainService.GetAllAsync(AppUserId);
        return Ok(slider);
    }

    [HttpGet("{id:Guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var byDomain = await _domainService.GetByIdAsync(id);
        return Ok(byDomain);
    }

    [HttpPost]
    public async Task<IActionResult> CreateSlider([FromForm] CreateDomainDto createDomainDto)
    {
        await _domainService.CreateAsync(createDomainDto);
        return StatusCode((int)HttpStatusCode.Created);
    }

    [HttpDelete("{Id:Guid}")]
    public async Task<IActionResult> Remove(Guid Id)
    {
        await _domainService.RemoveAsync(Id);
        return Ok();
    }

}
