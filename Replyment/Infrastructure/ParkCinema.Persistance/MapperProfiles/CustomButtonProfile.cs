using AutoMapper;
using Replyment.Application.DTOs.CustomButton;
using Replyment.Application.DTOs.Domain;
using Replyment.Domain.Entities;

namespace Replyment.Persistance.MapperProfiles;

public class CustomButtonProfile : Profile
{
    public CustomButtonProfile()
    {
        CreateMap<CustomButton, CreateCustomButtonDto>().ReverseMap();
        CreateMap<CustomButton, GetCustomButtonDto>()
                 .ForMember(dest => dest.GetAgentDtos, opt => opt.MapFrom(src => src.Agents)).ReverseMap();

    }
}
