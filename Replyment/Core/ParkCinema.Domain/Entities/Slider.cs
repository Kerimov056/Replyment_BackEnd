using Replyment.Domain.Entities.Common;

namespace Replyment.Domain.Entities;

public class Slider: BaseEntity
{
    public byte[] ImagePath { get; set; }
    public string Name { get; set; }
}
