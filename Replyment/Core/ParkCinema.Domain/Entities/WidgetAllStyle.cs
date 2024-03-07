using Replyment.Domain.Entities.Common;
using Replyment.Domain.Enums.BackgroundStyle;
using Replyment.Domain.Enums.ButtonStyle;
using Replyment.Domain.Enums.Display;

namespace Replyment.Domain.Entities;

public class WidgetAllStyle:BaseEntity
{
    public string WidgetColor { get; set; }  //widgeti ozune aid'dir 
    public byte[]? WidgetButtonImage { get; set; } //widgeti ozune aid'dir 
    public ButtonStyle ButtonStyle { get; set; }  //butun buttonlara aiddir
    public BackgroundStyle BackgroundStyle { get; set; } //butun buttonlara aiddir
    /// <summary>
    /// Demeli  ButtonSize enin-uzunluga x,3x nisbetinde olur ve 
    /// eger ki ButtonStyle Classic secilerse enin-uzunluga x,x nisbetinde olur !!!
    /// </summary>
    public double ButtonSize { get; set; } //butun buttonlara aiddir  
    public double BorderRadius { get; set; } //butun buttonlara aiddir
    public double Shadow { get; set; } //butun buttonlara aiddir
    public double Opacity { get; set; } //butun buttonlara aiddir
    public bool Position { get; set; } = true; //true=Left   false=right  //butun buttonlara aiddir
    /// <summary>
    /// Demeli display nedi gorsenmesidir display'de ya desktop secer ya mobile ya her iksinde //butun buttonlara aiddir
    /// </summary>
    public Display Display { get; set; }

    /// <summary>
    /// Demeli Greeting orda elaqe ucun  cixan user kimi fikirles Agent 
    /// </summary>
    public bool Greeting { get; set; } = true;
    public byte[]? AvatarImage { get; set; }
    public string AgentName { get; set; }
    public string AgentPosition { get; set; }
    public string GreetingMessage { get; set; }
    public string CallToAction { get; set; }
    public bool GoogleAnalytics { get; set; } = false;    //GoogleAnalytics'di default false'du 

    //Relation
    public Domain Domain { get; set; }
    public Guid DomainId { get; set; }
    public List<CustomButton> CustomButtons { get; set; } 

}
