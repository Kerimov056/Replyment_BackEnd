using Replyment.Application.Abstraction.Repositories.IEntityRepository.SliderRepo;
using Replyment.Domain.Entities;
using Replyment.Persistance.Context;

namespace Replyment.Persistance.Implementations.Repositories.IEntityRepository.SliderRepo;

public class SliderWriteRepository : WriteRepository<Slider>, ISliderWriteRepository
{
    public SliderWriteRepository(AppDbContext context) : base(context)
    {
    }
}
