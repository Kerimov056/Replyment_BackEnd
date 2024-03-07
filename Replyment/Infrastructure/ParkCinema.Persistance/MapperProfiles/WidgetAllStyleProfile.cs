using AutoMapper;
using Replyment.Application.DTOs.WidgetAllStyle;
using Replyment.Domain.Entities;

namespace Replyment.Persistance.MapperProfiles;

public class WidgetAllStyleProfile:Profile
{
    public WidgetAllStyleProfile()
    {
        CreateMap<WidgetAllStyle, CreateWidgetAllStyleDto>().ReverseMap();
        CreateMap<WidgetAllStyle, GetWidgetAllStyleDto>().ReverseMap();
    }
}
