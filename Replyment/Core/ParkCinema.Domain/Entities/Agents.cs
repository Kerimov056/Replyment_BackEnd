using Replyment.Domain.Entities.Common;

namespace Replyment.Domain.Entities;

public class Agents:BaseEntity
{
    public string Name { get; set; }
    public string Posistion { get; set; }
    public string NumberOrLink { get; set; }

    //Relation
    public CustomButton CustomButton { get; set; }
    public Guid CustomButtonId { get; set; }
}
