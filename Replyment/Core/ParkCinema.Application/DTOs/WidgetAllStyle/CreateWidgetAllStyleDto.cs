using Microsoft.AspNetCore.Http;
using Replyment.Application.DTOs.CustomButton;
using Replyment.Domain.Enums.BackgroundStyle;
using Replyment.Domain.Enums.ButtonStyle;
using Replyment.Domain.Enums.Display;

namespace Replyment.Application.DTOs.WidgetAllStyle;

public class CreateWidgetAllStyleDto
{
    public string WidgetColor { get; set; }
    public string? WidgetButtonImage { get; set; }
    public ButtonStyle ButtonStyle { get; set; }
    public BackgroundStyle BackgroundStyle { get; set; }
    public double ButtonSize { get; set; }
    public double BorderRadius { get; set; }
    public double Shadow { get; set; }
    public double Opacity { get; set; }
    public bool Position { get; set; } = true;
    public Display Display { get; set; }
    public bool Greeting { get; set; } = true;
    public string? AvatarImage { get; set; }
    public string AgentName { get; set; }
    public string AgentPosition { get; set; }
    public string GreetingMessage { get; set; }
    public string CallToAction { get; set; }
    public bool GoogleAnalytics { get; set; } = false;
    public Guid DomainId { get; set; }
    public List<CreateCustomButtonDto> CreateCustomButtonDtos { get; set; }
}
