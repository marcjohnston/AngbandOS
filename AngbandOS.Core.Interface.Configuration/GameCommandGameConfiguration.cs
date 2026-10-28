
using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

[ConfigurationEntityAttribute(
    Title = "Game Command",
    EntityNoun = "Game Command")]
public class GameCommandGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationMetadataAttribute(
        Title = "Key Character",
        Summary = "The character used to invoke the game command.",
        DataType = "char")]
    public virtual char KeyChar { get; set; }

    [ConfigurationMetadataAttribute(
        Title = "Repeat",
        Summary = "The number of times the command is repeated, or null when no repeat count is specified.",
        DataType = "int?")]
    public virtual int? Repeat { get; set; } = 0;

    [ConfigurationMetadataAttribute(
        Title = "Is Enabled",
        Summary = "Determines whether the game command is enabled.",
        DataType = "bool")]
    public virtual bool IsEnabled { get; set; } = true;

    [ConfigurationMetadataAttribute(
        Title = "Execute Script Name",
        Summary = "The name of the script executed by the game command.",
        DataType = "string?")]
    public virtual string? ExecuteScriptName { get; set; }
}