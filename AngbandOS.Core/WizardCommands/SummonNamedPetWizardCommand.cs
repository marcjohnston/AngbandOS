namespace AngbandOS.Core.WizardCommands;

[Serializable]
internal class SummonNamedPetWizardCommand : WizardCommand
{
    private SummonNamedPetWizardCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Key => 'N';

    public override string HelpDescription => "Summon Named Pet";

    public override HelpGroup? HelpGroup => SaveGame.SingletonRepository.HelpGroups.Get<WizardMonstersHelpGroup>();

    public override void Execute()
    {
        SaveGame.DoCmdWizNamedFriendly(SaveGame.CommandArgument, true);
    }
}
