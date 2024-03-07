using Replyment.Application.DTOs.Agents;

namespace Replyment.Application.DTOs.CustomButton;

public class GetCustomButtonDto
{
    public string AddressUrl { get; set; }
    public string Name { get; set; }
    public bool IsWhatsapp { get; set; } = false;
    public Guid WidgetAllStyleId { get; set; }
    public List<GetAgentDto>? GetAgentDtos { get; set; }
}
