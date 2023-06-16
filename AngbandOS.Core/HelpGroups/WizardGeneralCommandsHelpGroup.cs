namespace AngbandOS.Core.HelpGroups;

[Serializable]
internal class WizardGeneralCommandsHelpGroup : HelpGroup
{
    private WizardGeneralCommandsHelpGroup(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string Title => "General Commands";
    public override int SortIndex => 1;
}
