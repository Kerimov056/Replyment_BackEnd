namespace Replyment.Application.DTOs.Domain;

public class GetDomainDto
{
    public Guid Id { get; set; }
    public string DomainUrl { get; set; }
    public string AppUserId { get; set; }
}
