namespace AngbandOS.Core.HelpGroups
{
    internal class MonstersHelpGroup : HelpGroup
    {
        private MonstersHelpGroup(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
        public override string Title => "Monsters";

        public override int SortIndex => 3;
    }
}
