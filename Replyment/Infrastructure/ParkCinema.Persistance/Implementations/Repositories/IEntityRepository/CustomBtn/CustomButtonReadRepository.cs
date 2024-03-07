using Replyment.Application.Abstraction.Repositories.IEntityRepository.CustomBtn;
using Replyment.Domain.Entities;
using Replyment.Persistance.Context;

namespace Replyment.Persistance.Implementations.Repositories.IEntityRepository.CustomBtn;

public class CustomButtonReadRepository : ReadRepository<CustomButton>, ICustomButtonReadRepository
{
    public CustomButtonReadRepository(AppDbContext context) : base(context)
    {
    }
}
