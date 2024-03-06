namespace Replyment.Application.Abstraction.Services.Email;

public interface IEmailService
{
    void Send(string to, string subject, string html, string form = null);
    Task SendPasswordResetMailAsync(string to, string userId, string resetToken);
}
