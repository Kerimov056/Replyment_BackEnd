using Replyment.Application.DTOs.Agents;

namespace Replyment.Application.Abstraction.Services.Agent;

public interface IAgentService
{
    Task CreateAsync(List<CreateAgentsDto> createAgentsDto, Guid customButtonId);

}
