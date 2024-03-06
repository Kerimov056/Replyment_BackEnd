using Replyment.Application.DTOs.Auth;
using Replyment.Domain.Entities;

namespace Replyment.Application.Abstraction.Services;

public interface ITokenHandler
{
    public Task<TokenResponseDTO> CreateAccessToken(int minutes, int refreshTokenMinutes, AppUser appUser);
}
