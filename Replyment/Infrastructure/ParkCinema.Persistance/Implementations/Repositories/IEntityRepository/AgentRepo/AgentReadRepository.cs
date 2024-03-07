using Replyment.Application.Abstraction.Repositories.IEntityRepository.AgentRepo;
using Replyment.Domain.Entities;
using Replyment.Persistance.Context;

namespace Replyment.Persistance.Implementations.Repositories.IEntityRepository.AgentRepo;

public class AgentReadRepository : ReadRepository<Agents>, IAgentReadRepository
{
    public AgentReadRepository(AppDbContext context) : base(context)
    {
    }
}
