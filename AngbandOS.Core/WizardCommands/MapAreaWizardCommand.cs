namespace AngbandOS.Core.WizardCommands;

[Serializable]
internal class MapAreaWizardCommand : WizardCommand
{
    private MapAreaWizardCommand(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Key => 'm';

    public override string HelpDescription => "Map Area";

    public override HelpGroup? HelpGroup => SaveGame.SingletonRepository.HelpGroups.Get<WizardGeneralCommandsHelpGroup>();

    public override void Execute()
    {
        SaveGame.Level.MapArea();
    }
}
