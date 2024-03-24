using Replyment.Domain.Entities.Common;
using Replyment.Domain.Enums.Trigger;

namespace Replyment.Domain.Entities;

public class TriggerStatus:BaseEntity
{
    public string StatusText { get; set; }
    public TriggerStatusType TriggerStatusType { get; set; }
}
