using Replyment.Application.Abstraction.Repositories.IEntityRepository.DomainRepo;
using Replyment.Persistance.Context;

namespace Replyment.Persistance.Implementations.Repositories.IEntityRepository.DomainRepo;

public class DomainWriteRepository : WriteRepository<Replyment.Domain.Entities.Domain>, IDomainWriteRepository
{
    public DomainWriteRepository(AppDbContext context) : base(context)
    {
    }
}
