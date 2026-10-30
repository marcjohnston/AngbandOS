using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class RenderMessageScriptGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationMetadata(
        Title = "Message",
        Summary = "Specifies the message rendered by the script.",
        DataType = "string")]
    public virtual string Message { get; set; }

    [ConfigurationMetadata(
        Title = "Uses Item",
        Summary = "Determines whether the script uses an item.",
        DataType = "bool")]
    public virtual bool UsesItem { get; set; } = false;

    [ConfigurationMetadata(
        Title = "Identifies Item",
        Summary = "Determines whether the script identifies an item.",
        DataType = "bool")]
    public virtual bool IdentifiesItem { get; set; } = false;
}