using Replyment.Application.Abstraction.Repositories.IEntityRepository.Trigger;
using Replyment.Domain.Entities;
using Replyment.Persistance.Context;

namespace Replyment.Persistance.Implementations.Repositories.IEntityRepository.Trigger;

public class ReadTriggerStatusRepository : ReadRepository<TriggerStatus>, IReadTriggerStatusRepository
{
    public ReadTriggerStatusRepository(AppDbContext context) : base(context)
    {
    }
}
