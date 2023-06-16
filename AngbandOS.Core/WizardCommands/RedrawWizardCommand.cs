namespace AngbandOS.Core.WizardCommands;

[Serializable]
internal class RedrawWizardCommand : WizardCommand
{
    private RedrawWizardCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Key => 'R';

    public override string HelpDescription => "Force Redraw";

    public override HelpGroup? HelpGroup => SaveGame.SingletonRepository.HelpGroups.Get<WizardGeneralCommandsHelpGroup>();

    public override void Execute()
    {
        SaveGame.DoCmdRedraw();
    }
}
