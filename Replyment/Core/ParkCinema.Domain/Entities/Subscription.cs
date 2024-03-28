using Replyment.Domain.Entities.Common;
using Replyment.Domain.Enums.SubscriptionLevel;

namespace Replyment.Domain.Entities;

public class Subscription:BaseEntity
{
    public DateTime StartDate { get; set; } = DateTime.UtcNow;
    public DateTime EndDate { get; set; } = DateTime.UtcNow;
    public SubscriptionLevel SubscriptionLevel { get; set; } = SubscriptionLevel.UnSubscribed;
    public string AppUserId { get; set; }
    public AppUser AppUser { get; set; }
}
