// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.WizardCommands;

[Serializable]
internal class LearnAboutObjectsWizardCommand : WizardCommand
{
    private LearnAboutObjectsWizardCommand(Game game) : base(game) { } // This object is a singleton.

    public override char KeyChar => 'l';

    public override string HelpDescription => "Learn About Objects";

    protected override string? HelpGroupName => nameof(WizardObjectCommandsHelpGroup);

    protected override string? ExecuteScriptName => nameof(LearnScript);
}
