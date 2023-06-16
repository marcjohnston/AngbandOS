namespace AngbandOS.Core.WizardCommands;

[Serializable]
internal class JumpLevelsWizardCommand : WizardCommand
{
    private JumpLevelsWizardCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Key => 'j';

    public override string HelpDescription => "Teleport to Target";

    public override HelpGroup? HelpGroup => SaveGame.SingletonRepository.HelpGroups.Get<WizardMovementHelpGroup>();

    public override void Execute()
    {
        SaveGame.DoCmdWizJump();
    }
}
