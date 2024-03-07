using Microsoft.AspNetCore.Identity;

namespace Replyment.Domain.Entities;

public class AppUser:IdentityUser
{
    public string? Fullname { get; set; }
    public string UserName { get; set; } = null!;
    public bool isActive { get; set; }
    public DateTime? BirthDate { get; set; }
    public DateTime RefreshTokenExpration { get; set; }
    public string? RefreshToken { get; set; }
    public Subscription? Subscription { get; set; }
    public List<Domain>? Domains { get; set; }
}
