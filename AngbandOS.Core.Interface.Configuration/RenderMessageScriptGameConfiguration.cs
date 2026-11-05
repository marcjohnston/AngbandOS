using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class RenderMessageScriptGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationProperty(
        Title = "Message",
        Summary = "Specifies the message rendered by the script.",
        DataType = "string")]
    public virtual string Message { get; set; }

    [ConfigurationProperty(
        Title = "Uses Item",
        Summary = "Determines whether the script uses an item.",
        DataType = "bool")]
    public virtual bool UsesItem { get; set; } = false;

    [ConfigurationProperty(
        Title = "Identifies Item",
        Summary = "Determines whether the script identifies an item.",
        DataType = "bool")]
    public virtual bool IdentifiesItem { get; set; } = false;
}