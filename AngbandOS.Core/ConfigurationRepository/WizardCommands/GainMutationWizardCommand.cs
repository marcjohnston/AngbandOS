// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.WizardCommands;

[Serializable]
internal class GainMutationWizardCommand : WizardCommand
{
    private GainMutationWizardCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char KeyChar => 'M';

    public override string HelpDescription => "Gain Mutation";

    public override HelpGroup? HelpGroup => SaveGame.SingletonRepository.HelpGroups.Get(nameof(WizardCharacterEditingHelpGroup));

    public override void Execute()
    {
        SaveGame.Dna.GainMutation();
    }
}
