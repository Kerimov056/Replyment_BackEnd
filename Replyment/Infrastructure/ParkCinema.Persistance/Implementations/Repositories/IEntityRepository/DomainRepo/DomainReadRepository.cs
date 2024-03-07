using Replyment.Application.Abstraction.Repositories.IEntityRepository.DomainRepo;
using Replyment.Persistance.Context;

namespace Replyment.Persistance.Implementations.Repositories.IEntityRepository.DomainRepo;

public class DomainReadRepository : ReadRepository<Replyment.Domain.Entities.Domain>, IDomainReadRepository
{
    public DomainReadRepository(AppDbContext context) : base(context)
    {
    }
}
