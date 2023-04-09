namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class RingFlames : RingItemClass
    {
        private RingFlames(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '=';
        public override string Name => "Flames";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 3000;
        public override string FriendlyName => "Flames";
        public override int Level => 50;
        public override int[] Locale => new int[] { 50, 0, 0, 0 };
        public override int? SubCategory => 18;
        public override int ToA => 15;
        public override int Weight => 2;
        public override Item CreateItem(SaveGame saveGame) => new FlamesRingItem(saveGame);
    }
}
