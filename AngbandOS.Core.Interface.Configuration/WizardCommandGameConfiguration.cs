// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

[ConfigurationEntity(
    Title = "Wizard Command",
    EntityNoun = "wizard command")]
public class WizardCommandGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationMetadata(
        Title = "Key Character",
        Summary = "Specifies the character used to invoke the wizard command.",
        DataType = "char")]
    public virtual char KeyChar { get; set; }

    [ConfigurationMetadata(
        Title = "Is Enabled",
        Summary = "Determines whether the wizard command is enabled.",
        DataType = "bool")]
    public virtual bool IsEnabled { get; set; } = true;

    [ConfigurationMetadata(
        Title = "Help Group Name",
        Summary = "Specifies the name of the help group containing the wizard command. When null, the command is not associated with a help group.",
        DataType = "string?")]
    public virtual string? HelpGroupName { get; set; } = null;

    [ConfigurationMetadata(
        Title = "Help Description",
        Summary = "Specifies the description displayed for the wizard command.",
        DataType = "string")]
    public virtual string HelpDescription { get; set; } = "";

    [ConfigurationMetadata(
        Title = "Execute Script Name",
        Summary = "Specifies the name of the script executed by the wizard command. When null, no script is executed.",
        DataType = "string?")]
    public virtual string? ExecuteScriptName { get; set; } = null;
}

