using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Replyment.Application.Abstraction.Repositories.IEntityRepository.Trigger;
using Replyment.Application.Abstraction.Services.Trigger;
using Replyment.Application.DTOs.Trigger;
using Replyment.Domain.Entities;
using Replyment.Persistance.Exceptions;

namespace Replyment.Persistance.Implementations.Services.Trigger;

public class TriggerService : ITriggerService
{
    private readonly IReadTriggerStatusRepository _statusReadRepository;
    private readonly IWriteTriggerStatusRepository  _statusWriteRepository;
    private readonly IMapper _mapper;

    public TriggerService(IReadTriggerStatusRepository statusReadRepository,
                          IWriteTriggerStatusRepository statusWriteRepository,
                          IMapper mapper)
    {
        _statusReadRepository = statusReadRepository;
        _statusWriteRepository = statusWriteRepository;
        _mapper = mapper;
    }

    public async Task CreateAsync(CreateTrggerDto createTrggerDto)
    {
        var newTrigger = _mapper.Map<TriggerStatus>(createTrggerDto);
        await _statusWriteRepository.AddAsync(newTrigger);
        await _statusWriteRepository.SaveChangeAsync();
    }

    public async Task<List<GetTriggerDto>> GetAllAsync()
    {
        var allTrigger = await _statusReadRepository.GetAll().ToListAsync();
        var toMapper = _mapper.Map<List<GetTriggerDto>>(allTrigger);
        return toMapper;
    }

    public async Task Remove(Guid Id)
    {
        var trigger = await _statusReadRepository.GetByIdAsyncExpression(x=>x.Id==Id);
        if (trigger is null)
            throw new NotFoundException("Not Found Trigger");

        _statusWriteRepository.Remove(trigger);
        await _statusWriteRepository.SaveChangeAsync();
    }
}
