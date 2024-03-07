using Replyment.Application.DTOs.Agents;

namespace Replyment.Application.DTOs.CustomButton;

public class CreateCustomButtonDto
{
    public string AddressUrl { get; set; }
    public string Name { get; set; }
    public bool IsWhatsapp { get; set; } = false;
    public List<CreateAgentsDto> CreateAgentsDtos { get; set; }
}
