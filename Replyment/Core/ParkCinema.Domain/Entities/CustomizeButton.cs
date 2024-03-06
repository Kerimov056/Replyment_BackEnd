using Replyment.Domain.Entities.Common;

namespace Replyment.Domain.Entities;

public class CustomizeButton:BaseEntity
{
    public double Width { get; set; }
    public double Height { get; set; }
    public double BorderRadius { get; set; }
    public string BackgroundColor { get; set; }
}
