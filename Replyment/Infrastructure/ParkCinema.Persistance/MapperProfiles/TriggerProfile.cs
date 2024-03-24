using AutoMapper;
using Replyment.Application.DTOs.Trigger;
using Replyment.Domain.Entities;

namespace Replyment.Persistance.MapperProfiles;

public class TriggerProfile:Profile
{
    public TriggerProfile()
    {
        CreateMap<TriggerStatus, CreateTrggerDto>().ReverseMap();
        CreateMap<TriggerStatus, UpdateTrggerDto>().ReverseMap();
        CreateMap<TriggerStatus, GetTriggerDto>().ReverseMap();
    }
}
