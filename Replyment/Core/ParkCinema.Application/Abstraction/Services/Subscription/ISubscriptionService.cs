using Replyment.Application.DTOs.Subscription;

namespace Replyment.Application.Abstraction.Services.Subscription;

public interface ISubscriptionService
{
    Task<GetSubscriptionDto> GetByIdAsync(string AppUserId);
    Task CreateAsync(CreateSubscriptionDto createSubscriptionDto);
}
