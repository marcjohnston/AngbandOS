namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class RingProtection : RingItemClass
    {
        private RingProtection(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '=';
        public override string Name => "Protection";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 500;
        public override string FriendlyName => "Protection";
        public override int Level => 10;
        public override int[] Locale => new int[] { 10, 0, 0, 0 };
        public override int? SubCategory => 16;
        public override int Weight => 2;
        public override Item CreateItem() => new ProtectionRingItem(SaveGame);
    }
}