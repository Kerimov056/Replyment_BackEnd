using AutoMapper;
using Replyment.Application.Abstraction.Repositories.IEntityRepository.AgentRepo;
using Replyment.Application.Abstraction.Services.Agent;
using Replyment.Application.DTOs.Agents;
using Replyment.Domain.Entities;

namespace Replyment.Persistance.Implementations.Services.Agent;

public class AgentService : IAgentService
{
    private readonly IAgentReadRepository _agentReadRepository;
    private readonly IAgentWriteRepository _agentWriteRepository;
    private readonly IMapper _mapper;

    public AgentService(IAgentReadRepository agentReadRepository,
                        IAgentWriteRepository agentWriteRepository,
                        IMapper mapper)
    {
        _agentReadRepository = agentReadRepository;
        _agentWriteRepository = agentWriteRepository;
        _mapper = mapper;
    }

    public async Task CreateAsync(List<CreateAgentsDto> createAgentsDto, Guid customButtonId)
    {
        var newAgents = new List<Agents>();
        newAgents = _mapper.Map<List<Agents>>(createAgentsDto);
        newAgents.ForEach(x => x.CustomButtonId = customButtonId);

        await _agentWriteRepository.AddRangeAsync(newAgents);
        await _agentWriteRepository.SaveChangeAsync();
    }
}
