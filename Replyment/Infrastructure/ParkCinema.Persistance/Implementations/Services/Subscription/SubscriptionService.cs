using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Replyment.Application.Abstraction.Repositories.IEntityRepository.SubscriptionRepo;
using Replyment.Application.Abstraction.Services.Subscription;
using Replyment.Application.DTOs.Subscription;
using Replyment.Domain.Entities;
using Replyment.Domain.Enums.SubscriptionLevel;
using Replyment.Persistance.Exceptions;

namespace Replyment.Persistance.Implementations.Services.Subscription;

public class SubscriptionService : ISubscriptionService
{
    private readonly ISubscriptionReadRepository _subscriptionReadRepository;
    private readonly ISubscriptionWriteRepository _subscriptionWriteRepository;
    private readonly UserManager<AppUser> _userManager;
    private readonly IMapper _mapper;
    public SubscriptionService(ISubscriptionReadRepository subscriptionReadRepository,
                               ISubscriptionWriteRepository subscriptionWriteRepository,
                               UserManager<AppUser> userManager,
                               IMapper mapper)
    {
        _subscriptionReadRepository = subscriptionReadRepository;
        _subscriptionWriteRepository = subscriptionWriteRepository;
        _userManager = userManager;
        _mapper = mapper;
    }

    public async Task ChangeSubscriptionLevel(Replyment.Domain.Entities.Subscription subscription)
    {
        subscription.SubscriptionLevel = SubscriptionLevel.UnSubscribed;
        _subscriptionWriteRepository.Update(subscription);
        await _subscriptionWriteRepository.SaveChangeAsync();
    }

    public async Task CreateAsync(CreateSubscriptionDto createSubscriptionDto)
    {
        if (createSubscriptionDto.IsPayment is not true) throw new Exception("Payment Failed");

        var user = await _userManager.FindByIdAsync(createSubscriptionDto.AppUserId);
        if (user is null)
            throw new Exception("User not found");

        Replyment.Domain.Entities.Subscription subscription = new();
        subscription.AppUserId = createSubscriptionDto.AppUserId;
        
        if (createSubscriptionDto.Price == 3.99)
        {
            subscription.SubscriptionLevel = SubscriptionLevel.OneYear;
            subscription.EndDate = DateTime.UtcNow.AddYears(1);
        }

        if (createSubscriptionDto.Price == 144.39)
            subscription.SubscriptionLevel = SubscriptionLevel.EndlessSubscriptio;

        await _subscriptionWriteRepository.AddAsync(subscription);
        await _subscriptionWriteRepository.SaveChangeAsync();
    }

    public async Task<GetSubscriptionDto> GetByIdAsync(string AppUserId)
    {
        var byUser = await _userManager.FindByIdAsync(AppUserId);
        if (byUser is null) throw new NotFoundException("User not found");

        var byUserSubscription = await _subscriptionReadRepository.GetAll().Where(x=>x.AppUserId==AppUserId).FirstOrDefaultAsync();
        var toMapperSubscription = _mapper.Map<GetSubscriptionDto>(byUserSubscription);
        return toMapperSubscription;
    }
}
