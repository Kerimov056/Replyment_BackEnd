using AutoMapper;
using Replyment.Application.DTOs.Agents;
using Replyment.Domain.Entities;

namespace Replyment.Persistance.MapperProfiles;

public class AgentProfile:Profile
{
    public AgentProfile()
    {
        CreateMap<Agents, CreateAgentsDto>().ReverseMap();
        CreateMap<Agents, GetAgentDto>().ReverseMap();
    }
}
