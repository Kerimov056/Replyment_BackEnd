using Replyment.Application.Abstraction.Repositories.IEntityRepository.CustomizeButtonRepo;
using Replyment.Domain.Entities;
using Replyment.Persistance.Context;

namespace Replyment.Persistance.Implementations.Repositories.IEntityRepository.CustomizeButtonRepo;

public class CustomizeButtonWriteRepository : WriteRepository<WidgetAllStyle>, ICustomizeButtonWriteRepository
{
    public CustomizeButtonWriteRepository(AppDbContext context) : base(context)
    {
    }
}
