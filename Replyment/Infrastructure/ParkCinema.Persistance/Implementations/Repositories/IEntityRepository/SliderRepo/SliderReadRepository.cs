using Replyment.Application.Abstraction.Repositories.IEntityRepository.SliderRepo;
using Replyment.Domain.Entities;
using Replyment.Persistance.Context;

namespace Replyment.Persistance.Implementations.Repositories.IEntityRepository.SliderRepo;

public class SliderReadRepository : ReadRepository<Slider>, ISliderReadRepository
{
    public SliderReadRepository(AppDbContext context) : base(context)
    {
    }
}
