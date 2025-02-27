// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core;

[Serializable]
internal class GenericWizardCommand : WizardCommand
{
    public GenericWizardCommand(Game game, WizardCommandGameConfiguration wizardCommandGameConfiguration) : base(game)
    {
        Key = wizardCommandGameConfiguration.Key ?? wizardCommandGameConfiguration.GetType().Name;
        KeyChar = wizardCommandGameConfiguration.KeyChar;
        IsEnabled = wizardCommandGameConfiguration.IsEnabled;
        ExecuteScriptName = wizardCommandGameConfiguration.ExecuteScriptName;
        HelpDescription = wizardCommandGameConfiguration.HelpDescription;
        HelpGroupName = wizardCommandGameConfiguration.HelpGroupName;
    }

    protected override string? HelpGroupName { get; }
    public override string HelpDescription { get; }
    public override string Key { get; }
    public override char KeyChar { get; }
    public override bool IsEnabled { get; }
    protected override string? ExecuteScriptName { get; }
}
