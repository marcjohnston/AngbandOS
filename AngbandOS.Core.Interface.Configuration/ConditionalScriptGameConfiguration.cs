// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

[ConfigurationEntityAttribute(
    Title = "Conditional Script",
    EntityNoun = "Conditional Script")]
public class ConditionalScriptGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationMetadataAttribute(
        Title = "Conditional Key",
        Summary = "The key identifying the conditional evaluated by the script.",
        DataType = "string")]
    public virtual string ConditionalKey { get; set; }

    [ConfigurationMetadataAttribute(
        Title = "True Script Binding Keys",
        Summary = "The binding keys of the scripts executed when the conditional evaluates to true.",
        DataType = "string[]?")]
    public virtual string[]? TrueScriptBindingKeys { get; set; } = null;

    [ConfigurationMetadataAttribute(
        Title = "False Script Binding Keys",
        Summary = "The binding keys of the scripts executed when the conditional evaluates to false.",
        DataType = "string[]?")]
    public virtual string[]? FalseScriptBindingKeys { get; set; } = null;
}