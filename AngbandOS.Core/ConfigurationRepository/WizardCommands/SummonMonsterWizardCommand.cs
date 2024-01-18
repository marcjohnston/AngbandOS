// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.WizardCommands;

[Serializable]
internal class SummonMonsterWizardCommand : WizardCommand
{
    private SummonMonsterWizardCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Key => 's';

    public override string HelpDescription => "Summon Monster";

    public override HelpGroup? HelpGroup => SaveGame.SingletonRepository.HelpGroups.Get(nameof(WizardMonstersHelpGroup));

    public override void Execute()
    {
        if (SaveGame.CommandArgument <= 0)
        {
            SaveGame.CommandArgument = 1;
        }
        SaveGame.DoCmdWizSummon(SaveGame.CommandArgument);
    }
}
