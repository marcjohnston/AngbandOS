namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class RingAcid : RingItemClass
    {
        private RingAcid(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '=';
        public override string Name => "Acid";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 3000;
        public override string FriendlyName => "Acid";
        public override int Level => 50;
        public override int[] Locale => new int[] { 50, 0, 0, 0 };
        public override int? SubCategory => 17;
        public override int ToA => 15;
        public override int Weight => 2;
        public override Item CreateItem(SaveGame saveGame) => new AcidRingItem(saveGame);
    }
}
