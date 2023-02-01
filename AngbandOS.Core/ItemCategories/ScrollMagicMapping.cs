namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class ScrollMagicMapping : ScrollItemClass
    {
        private ScrollMagicMapping(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '?';
        public override string Name => "Magic Mapping";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 40;
        public override string FriendlyName => "Magic Mapping";
        public override int Level => 5;
        public override int[] Locale => new int[] { 5, 0, 0, 0 };
        public override int? SubCategory => 25;
        public override int Weight => 5;

        public override void Read(ReadScrollEvent eventArgs)
        {
            eventArgs.SaveGame.Level.MapArea();
            eventArgs.Identified = true;
        }
    }
}
