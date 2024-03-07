namespace Replyment.Application.DTOs.Agents;

public class GetAgentDto
{
    public string Name { get; set; }
    public string Posistion { get; set; }
    public string NumberOrLink { get; set; }
    public Guid CustomButtonId { get; set; }
}
