namespace AngbandOS.Core.HelpGroups;

[Serializable]
internal class WizardMonstersHelpGroup : HelpGroup
{
    private WizardMonstersHelpGroup(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string Title => "Monsters";

    public override int SortIndex => 3;
}
