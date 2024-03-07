using Replyment.Application.Abstraction.Repositories.IEntityRepository.CustomBtn;
using Replyment.Domain.Entities;
using Replyment.Persistance.Context;

namespace Replyment.Persistance.Implementations.Repositories.IEntityRepository.CustomBtn;

public class CustomButtonWriteRepository : WriteRepository<CustomButton>, ICustomButtonWriteRepository
{
    public CustomButtonWriteRepository(AppDbContext context) : base(context)
    {
    }
}
