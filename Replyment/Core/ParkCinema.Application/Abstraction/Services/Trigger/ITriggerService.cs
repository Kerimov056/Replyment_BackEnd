using Replyment.Application.DTOs.Trigger;

namespace Replyment.Application.Abstraction.Services.Trigger;

public interface ITriggerService
{
    Task CreateAsync(CreateTrggerDto createTrggerDto);
    Task<List<GetTriggerDto>> GetAllAsync();
    Task Remove(Guid Id);
}
