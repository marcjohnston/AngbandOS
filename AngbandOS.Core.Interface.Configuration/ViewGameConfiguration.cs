using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

[ConfigurationEntity(
    Title = "View",
    EntityNoun = "view")]
public class ViewGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationMetadata(
        Title = "Widget Names",
        Summary = "Specifies the names of the widgets displayed in the view.",
        DataType = "string[]")]
    public virtual string[] WidgetNames { get; set; }
}
