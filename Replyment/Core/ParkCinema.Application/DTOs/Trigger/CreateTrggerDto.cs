using Replyment.Domain.Enums.Trigger;

namespace Replyment.Application.DTOs.Trigger;

public class CreateTrggerDto
{
    public string StatusText { get; set; } 
    public TriggerStatusType TriggerStatusType { get; set; }
}
