// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.WizardCommands;

[Serializable]
internal class GainExperienceWizardCommand : WizardCommand
{
    private GainExperienceWizardCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Key => 'x';

    public override string HelpDescription => "Gain Experience";

    public override HelpGroup? HelpGroup => SaveGame.SingletonRepository.HelpGroups.Get<WizardCharacterEditingHelpGroup>();

    public override void Execute()
    {
        if (SaveGame.CommandArgument != 0)
        {
            SaveGame.Player.GainExperience(SaveGame.CommandArgument);
        }
        else
        {
            SaveGame.Player.GainExperience(SaveGame.Player.ExperiencePoints + 1);
        }
    }
}
