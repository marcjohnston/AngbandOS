// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.WizardCommands;

[Serializable]
internal class GenerateVeryGoodObjectWizardCommand : WizardCommand
{
    private GenerateVeryGoodObjectWizardCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Key => 'v';

    public override string HelpDescription => "Generate Very Good Object";

    public override HelpGroup? HelpGroup => SaveGame.SingletonRepository.HelpGroups.Get<WizardObjectCommandsHelpGroup>();

    public override void Execute()
    {
        if (SaveGame.CommandArgument <= 0)
        {
            SaveGame.CommandArgument = 1;
        }
        SaveGame.Acquirement(SaveGame.MapY, SaveGame.MapX, SaveGame.CommandArgument, true);
    }
}
