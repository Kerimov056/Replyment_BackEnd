using Replyment.Domain.Entities.Common;

namespace Replyment.Domain.Entities;

public class CustomButton:BaseEntity
{
    public string AddressUrl { get; set; }
    public string Name { get; set; }
    public bool IsWhatsapp { get; set; } = false;  //defaul false edek eger wahtsapp secerse true olar

    //Relation
    public WidgetAllStyle WidgetAllStyle { get; set; }
    public Guid WidgetAllStyleId { get; set; }
    public List<Agents>? Agents { get; set; }
}
