using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Replyment.Application.Abstraction.Repositories.IEntityRepository.CustomizeButtonRepo;
using Replyment.Application.Abstraction.Repositories.IEntityRepository.DomainRepo;
using Replyment.Application.Abstraction.Services.CustomButton;
using Replyment.Application.Abstraction.Services.WidgetAllStyle;
using Replyment.Application.DTOs.WidgetAllStyle;
using Replyment.Domain.Entities;
using Replyment.Domain.Enums.BackgroundStyle;
using Replyment.Domain.Enums.ButtonStyle;
using Replyment.Domain.Enums.Display;
using Replyment.Persistance.Exceptions;
using Replyment.Persistance.ExtensionsMethods;

namespace Replyment.Persistance.Implementations.Services.WidgetAllStyle;

public class WidgetAllStyleService : IWidgetAllStyleService
{
    private readonly ICustomizeButtonReadRepository _customizeButtonReadRepository;
    private readonly ICustomizeButtonWriteRepository _customizeButtonWriteRepository;
    private readonly IDomainReadRepository _domainReadRepository;
    private readonly ICustomButtonService _customButtonService;
    private readonly UserManager<AppUser> _userManager;
    private readonly IMapper _mapper;

    public WidgetAllStyleService(ICustomizeButtonReadRepository customizeButtonReadRepository,
                                 ICustomizeButtonWriteRepository customizeButtonWriteRepository,
                                 UserManager<AppUser> userManager,
                                 IDomainReadRepository domainReadRepository,
                                 ICustomButtonService customButtonService,
                                 IMapper mapper)
    {
        _customizeButtonReadRepository = customizeButtonReadRepository;
        _customizeButtonWriteRepository = customizeButtonWriteRepository;
        _userManager = userManager;
        _domainReadRepository = domainReadRepository;
        _customButtonService = customButtonService;
        _mapper = mapper;
    }

    public async Task CreateAsync(CreateWidgetAllStyleDto createWidgetAllStyleDto)
    {
        var byDomain = await _domainReadRepository.GetByIdAsync(createWidgetAllStyleDto.DomainId);
        if (byDomain is null) throw new NotFoundException("Domain not found");

        var newWidgets = _mapper.Map<Replyment.Domain.Entities.WidgetAllStyle>(createWidgetAllStyleDto);
       
        if (createWidgetAllStyleDto.Greeting is false)
        {
            newWidgets.AvatarImage = null;
            newWidgets.AgentName = null;
            newWidgets.AgentPosition = null;
            newWidgets.GreetingMessage = null;
            newWidgets.CallToAction = null;
        }

        await _customizeButtonWriteRepository.AddAsync(newWidgets);
        await _customizeButtonWriteRepository.SaveChangeAsync();

        await _customButtonService.CreateAsync(createWidgetAllStyleDto.CreateCustomButtonDtos, newWidgets.Id);
    }

    public async Task<List<GetWidgetAllStyleDto>> GetAllAsync(string AppUserId)
    {
        var byUser = await _userManager.FindByIdAsync(AppUserId);
        if (byUser is null) throw new NotFoundException("User not found");

        var byUserWidgets = _customizeButtonReadRepository.GetAll()
                                     .Include(x => x.Domain)
                                     .ThenInclude(x => x.AppUser)
                                     .Where(x => x.Domain.AppUserId == AppUserId);
        var toMapper = _mapper.Map<List<GetWidgetAllStyleDto>>(byUserWidgets);
        return toMapper;
    }
}
