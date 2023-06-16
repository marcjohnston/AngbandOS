namespace AngbandOS.Core.WizardCommands;

[Serializable]
internal class SummonNamedMonsterWizardCommand : WizardCommand
{
    private SummonNamedMonsterWizardCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Key => 'n';

    public override string HelpDescription => "Summon Named Monster";

    public override HelpGroup? HelpGroup => SaveGame.SingletonRepository.HelpGroups.Get<WizardMonstersHelpGroup>();

    public override void Execute()
    {
        SaveGame.DoCmdWizNamed(SaveGame.CommandArgument, true);
    }
}
