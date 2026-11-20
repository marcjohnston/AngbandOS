using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class ViewGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationProperty("string[]",
        Title = "Widget Names",
        Summary = "Specifies the names of the widgets displayed in the view.")]
    [ConfigurationForeignKey(
        "Widgets", 
        Inline = false)]
    public virtual string[] WidgetNames { get; set; }
}
