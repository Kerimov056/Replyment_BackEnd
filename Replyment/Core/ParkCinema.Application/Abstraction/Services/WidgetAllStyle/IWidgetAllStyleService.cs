using Replyment.Application.DTOs.WidgetAllStyle;

namespace Replyment.Application.Abstraction.Services.WidgetAllStyle;

public interface IWidgetAllStyleService
{
    Task CreateAsync(CreateWidgetAllStyleDto createWidgetAllStyleDto);
    Task<List<GetWidgetAllStyleDto>> GetAllAsync(string AppUserId);
}
