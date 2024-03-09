using Replyment.Domain.Entities.Common;
using Replyment.Domain.Enums.BackgroundStyle;
using Replyment.Domain.Enums.ButtonStyle;
using Replyment.Domain.Enums.Display;

namespace Replyment.Domain.Entities;

public class WidgetAllStyle:BaseEntity
{
    public string WidgetColor { get; set; } = "#DA1C5C";  //widgeti ozune aid'dir 
    public string? WidgetButtonImage { get; set; } //widgeti ozune aid'dir 
    public ButtonStyle ButtonStyle { get; set; } = ButtonStyle.Classic;  //butun buttonlara aiddir //Classi qalarsa x,x nisbetidir 
    public BackgroundStyle BackgroundStyle { get; set; } = BackgroundStyle.Solid; //butun buttonlara aiddir
    /// <summary>
    /// Demeli  ButtonSize enin-uzunluga x,3x nisbetinde olur ve 
    /// eger ki ButtonStyle Classic secilerse enin-uzunluga x,x nisbetinde olur !!!
    /// </summary>
    public double ButtonSize { get; set; } = 33.25; //butun buttonlara aiddir  max 100% miniumum 25% olmalidi
    public double BorderRadius { get; set; } //butun buttonlara aiddir
    public double Shadow { get; set; } = 0; //butun buttonlara aiddir min 0% max 100%
    public double Opacity { get; set; } = 0; //butun buttonlara aiddir min 0% max 100%
    public bool Position { get; set; } = true; //true=Left   false=right  //butun buttonlara aiddir
    /// <summary>
    /// Demeli display nedi gorsenmesidir display'de ya desktop secer ya mobile ya her iksinde //butun buttonlara aiddir
    /// </summary>
    public Display Display { get; set; } = Display.Desktop;

    /// <summary>
    /// Demeli Greeting orda elaqe ucun  cixan user kimi fikirles Agent 
    /// </summary>
    public bool Greeting { get; set; } = true;
    public string? AvatarImage { get; set; }
    public string? AgentName { get; set; }
    public string? AgentPosition { get; set; }
    public string? GreetingMessage { get; set; }
    public string? CallToAction { get; set; }
    public bool GoogleAnalytics { get; set; } = false;    //GoogleAnalytics'di default false'du 

    //Relation
    public Domain Domain { get; set; }
    public Guid DomainId { get; set; }
    public List<CustomButton>? CustomButtons { get; set; } 

}
