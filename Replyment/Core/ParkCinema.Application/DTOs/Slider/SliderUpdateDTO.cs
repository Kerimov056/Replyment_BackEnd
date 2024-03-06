using Microsoft.AspNetCore.Http;

namespace Replyment.Application.DTOs.Slider;

public class SliderUpdateDTO
{
    public IFormFile Image { get; set; }
    public string Name { get; set; }
}
