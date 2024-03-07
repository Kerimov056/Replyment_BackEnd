using AutoMapper;
using Replyment.Application.DTOs.Subscription;
using Replyment.Domain.Entities;

namespace Replyment.Persistance.MapperProfiles;

public class SubscriptionProfile:Profile
{
    public SubscriptionProfile()
    {
        CreateMap<Subscription, CreateSubscriptionDto>().ReverseMap();
        CreateMap<Subscription, GetSubscriptionDto>().ReverseMap();
    }
}
