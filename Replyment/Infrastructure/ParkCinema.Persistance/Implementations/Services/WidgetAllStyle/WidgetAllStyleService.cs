using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Replyment.Application.Abstraction.Repositories.IEntityRepository.CustomizeButtonRepo;
using Replyment.Application.Abstraction.Repositories.IEntityRepository.DomainRepo;
using Replyment.Application.Abstraction.Repositories.IEntityRepository.SubscriptionRepo;
using Replyment.Application.Abstraction.Services.CustomButton;
using Replyment.Application.Abstraction.Services.WidgetAllStyle;
using Replyment.Application.DTOs.WidgetAllStyle;
using Replyment.Domain.Entities;
using Replyment.Domain.Enums.SubscriptionLevel;
using Replyment.Persistance.Exceptions;

namespace Replyment.Persistance.Implementations.Services.WidgetAllStyle;

public class WidgetAllStyleService : IWidgetAllStyleService
{
    private readonly ICustomizeButtonReadRepository _customizeButtonReadRepository;
    private readonly ICustomizeButtonWriteRepository _customizeButtonWriteRepository;
    private readonly IDomainReadRepository _domainReadRepository;
    private readonly ICustomButtonService _customButtonService;
    private readonly UserManager<AppUser> _userManager;
    private readonly ISubscriptionReadRepository _subscriptionReadRepository;
    private readonly IMapper _mapper;

    public WidgetAllStyleService(ICustomizeButtonReadRepository customizeButtonReadRepository,
                                 ICustomizeButtonWriteRepository customizeButtonWriteRepository,
                                 UserManager<AppUser> userManager,
                                 IDomainReadRepository domainReadRepository,
                                 ICustomButtonService customButtonService,
                                 ISubscriptionReadRepository subscriptionReadRepository,
                                 IMapper mapper)
    {
        _customizeButtonReadRepository = customizeButtonReadRepository;
        _customizeButtonWriteRepository = customizeButtonWriteRepository;
        _userManager = userManager;
        _domainReadRepository = domainReadRepository;
        _customButtonService = customButtonService;
        _subscriptionReadRepository = subscriptionReadRepository;
        _mapper = mapper;
    }

    public async Task CreateAsync(CreateWidgetAllStyleDto createWidgetAllStyleDto)
    {
        var byDomain = await _domainReadRepository.GetByIdAsync(createWidgetAllStyleDto.DomainId);
        if (byDomain is null) throw new NotFoundException("Domain not found");

        var subscription = await _subscriptionReadRepository.GetByIdAsyncExpression(x => x.AppUserId == byDomain.AppUserId);

        if (subscription is null)
            throw new PermissionException("Subscription Yoxdur !!!");
        if (subscription.SubscriptionLevel.ToString() != SubscriptionLevel.OneYear.ToString() &&
            subscription.SubscriptionLevel.ToString() != SubscriptionLevel.EndlessSubscriptio.ToString())
            throw new PermissionException("Subscription Yoxdur !!!");

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

        var byUserWidgets = await _customizeButtonReadRepository.GetAll()
                                      .Include(x => x.Domain)
                                      .ThenInclude(x => x.AppUser)
                                      .Include(x => x.CustomButtons)
                                      .ThenInclude(x => x.Agents)
                                      .Where(x => x.Domain.AppUserId == AppUserId).ToListAsync();

        var toMapper = _mapper.Map<List<GetWidgetAllStyleDto>>(byUserWidgets);
        return toMapper;
    }
}
