using Replyment.Domain.Enums.Trigger;

namespace Replyment.Application.DTOs.Trigger;

public class GetTriggerDto
{
    public Guid Id { get; set; }
    public string StatusText { get; set; }
    public TriggerStatusType TriggerStatusType { get; set; }
}
