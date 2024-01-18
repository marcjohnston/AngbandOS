// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.WizardCommands;

[Serializable]
internal class GenerateSpoilersWizardCommand : WizardCommand
{
    private GenerateSpoilersWizardCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char KeyChar => '"';

    public override string HelpDescription => "Generate Spoilers";

    public override HelpGroup? HelpGroup => SaveGame.SingletonRepository.HelpGroups.Get(nameof(WizardGeneralCommandsHelpGroup));

    public override bool IsEnabled => false;

    public override void Execute()
    {
    }
}
