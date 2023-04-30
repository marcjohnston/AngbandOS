namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class NexusResistanceRingItemFactory : RingItemFactory
    {
        private NexusResistanceRingItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '=';
        public override string Name => "Nexus Resistance";

        public override int[] Chance => new int[] { 2, 0, 0, 0 };
        public override int Cost => 3000;
        public override bool EasyKnow => true;
        public override string FriendlyName => "Nexus Resistance";
        public override int Level => 24;
        public override int[] Locale => new int[] { 24, 0, 0, 0 };
        public override bool ResNexus => true;
        public override int? SubCategory => 41;
        public override int Weight => 2;
        public override Item CreateItem() => new NexusResistanceRingItem(SaveGame);
    }
}
