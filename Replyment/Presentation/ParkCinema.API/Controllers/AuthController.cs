using FluentValidation.Validators;
using Microsoft.AspNetCore.Mvc;
using Replyment.Application.Abstraction.Services;
using Replyment.Application.Abstraction.Services.Email;
using Replyment.Application.DTOs.Auth;
using Replyment.Domain.Helpers;

namespace Replyment.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly IEmailService _emailService;

    public AuthController(IAuthService authService, IEmailService emailService)
    {
        _authService = authService;
        _emailService = emailService;
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
    {
        var responseToken = await _authService.Login(loginDTO);
        return Ok(responseToken);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDTO registerDTO)
    {
        ArgumentNullException.ThrowIfNull(registerDTO, ExceptionResponseMessages.ParametrNotFoundMessage);

        SignUpResponse response = await _authService.Register(registerDTO)
                ?? throw new SystemException(ExceptionResponseMessages.NotFoundMessage);

        if (response.Errors != null)
        {
            if (response.Errors.Count > 0)
            {
                return BadRequest(response.Errors);
            }
        }
        else
        {
            string subject = "Register Confirmation";
            string html = string.Empty;
            string password = registerDTO.password;
            string username = registerDTO.Username;

            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "templates", "Register.html");
            html = System.IO.File.ReadAllText(filePath);

            html = html.Replace("{{password}}", password);
            html = html.Replace("{{username}}", password);

            _emailService.Send(registerDTO.Email, subject, html);

        }
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> RefreshToken([FromQuery] string ReRefreshtoken)
    {
        var response = await _authService.ValidRefleshToken(ReRefreshtoken);
        return Ok(response);
    }
}
