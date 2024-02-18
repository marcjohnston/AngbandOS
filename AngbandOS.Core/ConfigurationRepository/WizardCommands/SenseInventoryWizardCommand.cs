// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.WizardCommands;

[Serializable]
internal class SenseInventoryWizardCommand : WizardCommand
{
    private SenseInventoryWizardCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char KeyChar => 'S';

    public override string HelpDescription => "Sense Inventory";

    public override HelpGroup? HelpGroup => SaveGame.SingletonRepository.HelpGroups.Get(nameof(WizardObjectCommandsHelpGroup));

    protected override string? ExecuteScriptName => nameof(SenseInventoryScript);
}
