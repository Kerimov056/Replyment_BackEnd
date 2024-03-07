using AutoMapper;
using Replyment.Application.DTOs.Domain;

namespace Replyment.Persistance.MapperProfiles;

public class DomainProfile:Profile
{
    public DomainProfile()
    {
        CreateMap<Replyment.Domain.Entities.Domain, CreateDomainDto>().ReverseMap();
        CreateMap<Replyment.Domain.Entities.Domain, GetDomainDto>().ReverseMap();
    }
}
