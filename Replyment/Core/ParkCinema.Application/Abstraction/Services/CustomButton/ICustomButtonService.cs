using Replyment.Application.DTOs.CustomButton;

namespace Replyment.Application.Abstraction.Services.CustomButton;

public interface ICustomButtonService
{
    Task CreateAsync(List<CreateCustomButtonDto> createCustomButtonDto, Guid widgetId);
}
