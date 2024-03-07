using Replyment.Application.Abstraction.Repositories.IEntityRepository.AgentRepo;
using Replyment.Domain.Entities;
using Replyment.Persistance.Context;

namespace Replyment.Persistance.Implementations.Repositories.IEntityRepository.AgentRepo;

public class AgentWriteRepository : WriteRepository<Agents>, IAgentWriteRepository
{
    public AgentWriteRepository(AppDbContext context) : base(context)
    {
    }
}
