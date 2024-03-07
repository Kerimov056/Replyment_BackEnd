using Replyment.Domain.Enums.SubscriptionLevel;

namespace Replyment.Application.DTOs.Subscription;

public class GetSubscriptionDto
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public SubscriptionLevel SubscriptionLevel { get; set; }
    public string AppUserId { get; set; }
}
