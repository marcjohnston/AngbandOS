namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class RingSlaying : RingItemFactory
    {
        private RingSlaying(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '=';
        public override string Name => "Slaying";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 1000;
        public override string FriendlyName => "Slaying";
        public override int Level => 40;
        public override int[] Locale => new int[] { 40, 0, 0, 0 };
        public override bool ShowMods => true;
        public override int? SubCategory => 30;
        public override int Weight => 2;
        public override Item CreateItem() => new SlayingRingItem(SaveGame);
    }
}
