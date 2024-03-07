using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Replyment.Application.Abstraction.Repositories.IEntityRepository.DomainRepo;
using Replyment.Application.Abstraction.Services.Domain;
using Replyment.Application.DTOs.Domain;
using Replyment.Domain.Entities;
using Replyment.Persistance.Exceptions;

namespace Replyment.Persistance.Implementations.Services.Domain;

public class DomainService : IDomainService
{
    private readonly IDomainReadRepository _domainReadRepository;
    private readonly IDomainWriteRepository _domainWriteRepository;
    private readonly UserManager<AppUser> _userManager;
    private readonly IMapper _mapper;

    public DomainService(IDomainReadRepository domainReadRepository,
                         IDomainWriteRepository domainWriteRepository,
                         UserManager<AppUser> userManager,
                         IMapper mapper)
    {
        _domainReadRepository = domainReadRepository;
        _domainWriteRepository = domainWriteRepository;
        _userManager = userManager;
        _mapper = mapper;
    }

    public async Task CreateAsync(CreateDomainDto createDomainDto)
    {
        var byUser = await _userManager.FindByIdAsync(createDomainDto.AppUserId);
        if (byUser is null) throw new NotFoundException("User not found");
        var newDomain = _mapper.Map<Replyment.Domain.Entities.Domain>(createDomainDto);

        await _domainWriteRepository.AddAsync(newDomain);
        await _domainWriteRepository.SaveChangeAsync();
    }

    public async Task<List<GetDomainDto>> GetAllAsync(string AppUserId)
    {
        var byUser = await _userManager.FindByIdAsync(AppUserId);
        if (byUser is null) throw new NotFoundException("User not found");

        var userDomains = await _domainReadRepository.GetAll().Where(x=>x.AppUserId==AppUserId).ToListAsync();
        var toMapperGetDomain = _mapper.Map<List<GetDomainDto>>(userDomains);
        return toMapperGetDomain;
    }

    public async Task<GetDomainDto> GetByIdAsync(Guid Id)
    {
        var thisDomain = await _domainReadRepository.GetByIdAsync(Id);
        if (thisDomain is null) throw new NotFoundException("Domain not found");

        var toMapperGetDomain = _mapper.Map<GetDomainDto>(thisDomain);
        return toMapperGetDomain;
    }

    public async Task RemoveAsync(Guid DomainId)
    {
        var thisDomain = await _domainReadRepository.GetByIdAsync(DomainId);
        if (thisDomain is null) throw new NotFoundException("Domain not found");

        _domainWriteRepository.Remove(thisDomain);
        await _domainWriteRepository.SaveChangeAsync();
    }
}
