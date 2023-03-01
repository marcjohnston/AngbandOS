namespace AngbandOS.Core.HelpGroups
{
    internal class MovementHelpGroup : HelpGroup
    {
        private MovementHelpGroup(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
        public override string Title => "Movement";
        public override int SortIndex => 4;
    }
}
