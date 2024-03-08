using Replyment.Domain.Enums.SubscriptionLevel;

namespace Replyment.Application.DTOs.Subscription;

public class CreateSubscriptionDto
{
    public bool IsPayment { get; set; }
    public double Price { get; set; }
    public string AppUserId { get; set; }
}
