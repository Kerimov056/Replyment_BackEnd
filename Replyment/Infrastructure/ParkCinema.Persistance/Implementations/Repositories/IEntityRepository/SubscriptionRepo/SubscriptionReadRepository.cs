using Replyment.Application.Abstraction.Repositories.IEntityRepository.SubscriptionRepo;
using Replyment.Domain.Entities;
using Replyment.Persistance.Context;

namespace Replyment.Persistance.Implementations.Repositories.IEntityRepository.SubscriptionRepo;

public class SubscriptionReadRepository : ReadRepository<Subscription>, ISubscriptionReadRepository
{
    public SubscriptionReadRepository(AppDbContext context) : base(context)
    {
    }
}
