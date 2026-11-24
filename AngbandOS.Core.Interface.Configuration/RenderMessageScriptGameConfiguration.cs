using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class RenderMessageScriptGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationProperty("string",
        Title = "Message",
        Description = "Specifies the message rendered by the script.")]
    public virtual string Message { get; set; }

    [ConfigurationProperty("bool",
        Title = "Uses Item",
        Description = "Determines whether the script uses an item.")]
    public virtual bool UsesItem { get; set; } = false;

    [ConfigurationProperty("bool",
        Title = "Identifies Item",
        Description = "Determines whether the script identifies an item.")]
    public virtual bool IdentifiesItem { get; set; } = false;
}