namespace AngbandOS.Core.HelpGroups;

[Serializable]
internal class WizardCharacterEditingHelpGroup : HelpGroup
{
    private WizardCharacterEditingHelpGroup(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string Title => "Character Editing";
    public override int SortIndex => 0;
}
