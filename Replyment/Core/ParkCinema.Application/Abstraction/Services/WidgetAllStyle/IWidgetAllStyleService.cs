using Replyment.Application.DTOs.WidgetAllStyle;

namespace Replyment.Application.Abstraction.Services.WidgetAllStyle;

public interface IWidgetAllStyleService
{
    Task CreateWidget(CreateWidgetAllStyleDto createWidgetAllStyleDto);
}
