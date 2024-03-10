using AutoMapper;
using Replyment.Application.DTOs.WidgetAllStyle;
using Replyment.Domain.Entities;

namespace Replyment.Persistance.MapperProfiles;

public class WidgetAllStyleProfile:Profile
{
    public WidgetAllStyleProfile()
    {
        CreateMap<WidgetAllStyle, CreateWidgetAllStyleDto>().ReverseMap();
        CreateMap<WidgetAllStyle, GetWidgetAllStyleDto>()
            .ForMember(dest => dest.GetCustomButtons, opt => opt.MapFrom(src => src.CustomButtons)).ReverseMap();
    }
}
