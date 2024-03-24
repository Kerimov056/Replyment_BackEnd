using Replyment.Application.Abstraction.Repositories.IEntityRepository.Trigger;
using Replyment.Domain.Entities;
using Replyment.Persistance.Context;

namespace Replyment.Persistance.Implementations.Repositories.IEntityRepository.Trigger;

public class WriteTriggerStatusRepository : WriteRepository<TriggerStatus>, IWriteTriggerStatusRepository
{
    public WriteTriggerStatusRepository(AppDbContext context) : base(context)
    {
    }
}
