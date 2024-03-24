using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Replyment.Application.Abstraction.Repositories.IEntityRepository.CustomBtn;
using Replyment.Application.Abstraction.Services.Agent;
using Replyment.Application.Abstraction.Services.CustomButton;
using Replyment.Application.DTOs.CustomButton;
using Replyment.Persistance.Context;

namespace Replyment.Persistance.Implementations.Services.CustomButton;

public class CustomButtonService : ICustomButtonService
{
    private readonly ICustomButtonReadRepository _customButtonReadRepository;
    private readonly ICustomButtonWriteRepository _customButtonWriteRepository;
    private readonly IAgentService _agentService;
    private readonly AppDbContext _appDbContext;
    private readonly IMapper _mapper;

    public CustomButtonService(ICustomButtonReadRepository customButtonReadRepository,
                               ICustomButtonWriteRepository customButtonWriteRepository,
                               IAgentService agentService,
                               AppDbContext appDbContext,
                               IMapper mapper)
    {
        _customButtonReadRepository = customButtonReadRepository;
        _customButtonWriteRepository = customButtonWriteRepository;
        _agentService = agentService;
        _appDbContext = appDbContext;
        _mapper = mapper;
    }

    public async Task CreateAsync(List<CreateCustomButtonDto> createCustomButtonDto, Guid widgetId)
    {
        var newCustomButtons = new List<Replyment.Domain.Entities.CustomButton>();
        newCustomButtons = _mapper.Map<List<Replyment.Domain.Entities.CustomButton>>(createCustomButtonDto);
        newCustomButtons.ForEach(x => x.WidgetAllStyleId = widgetId);

        await _customButtonWriteRepository.AddRangeAsync(newCustomButtons);
        await _customButtonWriteRepository.SaveChangeAsync();
      
        var IsWhatsappButton = await _appDbContext.CustomButtons
            .Where(x => x.IsWhatsapp == true && x.WidgetAllStyleId == widgetId)
            .FirstOrDefaultAsync();

        foreach (var custombuttondto in createCustomButtonDto)
        {
            if (custombuttondto.IsWhatsapp is true)
            {
                await _agentService.CreateAsync(custombuttondto.CreateAgentsDtos,IsWhatsappButton.Id);
            }
        }
    }


}
