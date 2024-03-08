using Replyment.Domain.Entities.Common;
using Replyment.Domain.Enums.SubscriptionLevel;

namespace Replyment.Domain.Entities;

public class Subscription:BaseEntity
{
    public DateTime StartDate { get; set; } = DateTime.Now;
    public DateTime EndDate { get; set; } = DateTime.Now;
    public SubscriptionLevel SubscriptionLevel { get; set; }
    public string AppUserId { get; set; }
    public AppUser AppUser { get; set; }
}
