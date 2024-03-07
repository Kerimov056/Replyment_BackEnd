using AutoMapper;
using Replyment.Application.Abstraction.Repositories.IEntityRepository.CustomizeButtonRepo;
using Replyment.Application.Abstraction.Services.WidgetAllStyle;
using Replyment.Application.DTOs.WidgetAllStyle;

namespace Replyment.Persistance.Implementations.Services.WidgetAllStyle;

public class WidgetAllStyleService : IWidgetAllStyleService
{
    private readonly ICustomizeButtonReadRepository _customizeButtonReadRepository;
    private readonly ICustomizeButtonWriteRepository _customizeButtonWriteRepository;
    private readonly IMapper _mapper;

    public WidgetAllStyleService(ICustomizeButtonReadRepository customizeButtonReadRepository,
                                 ICustomizeButtonWriteRepository customizeButtonWriteRepository,
                                 IMapper mapper)
    {
        _customizeButtonReadRepository = customizeButtonReadRepository;
        _customizeButtonWriteRepository = customizeButtonWriteRepository;
        _mapper = mapper;
    }

    public Task CreateWidget(CreateWidgetAllStyleDto createWidgetAllStyleDto)
    {
        throw new NotImplementedException();
    }
}
