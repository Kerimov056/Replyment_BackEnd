using Replyment.Application.DTOs.Domain;

namespace Replyment.Application.Abstraction.Services.Domain;

public interface IDomainService
{
    Task<List<GetDomainDto>> GetAllAsync(string AppUserId);
    Task<GetDomainDto> GetByIdAsync(Guid Id);
    Task CreateAsync(CreateDomainDto createDomainDto);
    Task RemoveAsync(Guid DomainId);
}
