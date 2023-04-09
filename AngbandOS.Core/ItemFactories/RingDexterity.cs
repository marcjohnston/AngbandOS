namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class RingDexterity : RingItemClass
    {
        private RingDexterity(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '=';
        public override string Name => "Dexterity";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 500;
        public override string FriendlyName => "Dexterity";
        public override int Level => 30;
        public override int[] Locale => new int[] { 30, 0, 0, 0 };
        public override int? SubCategory => 26;
        public override int Weight => 2;
        public override Item CreateItem(SaveGame saveGame) => new DexterityRingItem(saveGame);
    }
}
