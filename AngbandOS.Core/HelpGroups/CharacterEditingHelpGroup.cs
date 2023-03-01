namespace AngbandOS.Core.HelpGroups
{

    internal class CharacterEditingHelpGroup : HelpGroup
    {
        private CharacterEditingHelpGroup(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
        public override string Title => "Character Editing";
        public override int SortIndex => 0;
    }
}
