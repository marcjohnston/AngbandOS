namespace AngbandOS.Core.WizardCommands;

[Serializable]
internal class CreateItemWizardCommand : WizardCommand
{
    private CreateItemWizardCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Key => 'c';

    public override string HelpDescription => "Create Item";

    public override HelpGroup? HelpGroup => SaveGame.SingletonRepository.HelpGroups.Get<WizardObjectCommandsHelpGroup>();

    public override void Execute()
    {
        SaveGame.WizCreateItem();
    }
}
