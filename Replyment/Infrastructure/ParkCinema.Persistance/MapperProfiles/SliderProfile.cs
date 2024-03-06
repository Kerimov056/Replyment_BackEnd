using AutoMapper;
using Replyment.Application.DTOs.Slider;
using Replyment.Domain.Entities;

namespace Replyment.Persistance.MapperProfiles;

public class SliderProfile : Profile
{
    public SliderProfile()
    {
        CreateMap<Slider, SliderCreateDTO>().ReverseMap();
        CreateMap<Slider, SliderUpdateDTO>().ReverseMap();
        CreateMap<Slider, SliderGetDTO>().ReverseMap();
    }
}
