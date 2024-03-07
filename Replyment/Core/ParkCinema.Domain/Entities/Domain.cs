using Replyment.Domain.Entities.Common;

namespace Replyment.Domain.Entities;

public class Domain:BaseEntity
{
    public string DomainUrl { get; set; }

    //Relation
    public string AppUserId { get; set; }
    public AppUser AppUser { get; set; }
    public WidgetAllStyle? WidgetAllStyle { get; set; }
}
