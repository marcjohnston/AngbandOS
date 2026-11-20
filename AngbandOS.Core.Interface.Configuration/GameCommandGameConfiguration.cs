
using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

public class GameCommandGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationProperty("char",
        Title = "Key Character",
        Summary = "The character used to invoke the game command.")]
    public virtual char KeyChar { get; set; }

    [ConfigurationProperty("int?",
        Title = "Repeat",
        Summary = "The number of times the command is repeated, or null when no repeat count is specified.")]
    public virtual int? Repeat { get; set; } = 0;

    [ConfigurationProperty("bool",
        Title = "Is Enabled",
        Summary = "Determines whether the game command is enabled.")]
    public virtual bool IsEnabled { get; set; } = true;

    [ConfigurationProperty("string?",
        Title = "Execute Script Name",
        Summary = "The name of the script executed by the game command.")]
    public virtual string? ExecuteScriptName { get; set; }
}