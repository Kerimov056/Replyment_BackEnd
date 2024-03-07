using Replyment.Application.Abstraction.Repositories.IEntityRepository.CustomizeButtonRepo;
using Replyment.Domain.Entities;
using Replyment.Persistance.Context;

namespace Replyment.Persistance.Implementations.Repositories.IEntityRepository.CustomizeButtonRepo;

public class CustomizeButtonReadRepository : ReadRepository<WidgetAllStyle>, ICustomizeButtonReadRepository
{
    public CustomizeButtonReadRepository(AppDbContext context) : base(context)
    {
    }
}
