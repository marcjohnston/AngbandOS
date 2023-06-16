namespace AngbandOS.Core.WizardCommands;

[Serializable]
internal class NewLineWizardCommand : WizardCommand
{
    private NewLineWizardCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Key => '\n';

    public override void Execute()
    {
    }
}
