using Replyment.Application.Abstraction.Repositories.IEntityRepository.SubscriptionRepo;
using Replyment.Domain.Entities;
using Replyment.Persistance.Context;

namespace Replyment.Persistance.Implementations.Repositories.IEntityRepository.SubscriptionRepo;

public class SubscriptionWriteRepository : WriteRepository<Subscription>, ISubscriptionWriteRepository
{
    public SubscriptionWriteRepository(AppDbContext context) : base(context)
    {
    }
}
