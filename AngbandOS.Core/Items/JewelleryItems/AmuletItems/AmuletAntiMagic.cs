namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class AmuletAntiMagic : AmuletItemClass
    {
        private AmuletAntiMagic(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '"';
        public override string Name => "Anti-Magic";

        public override int[] Chance => new int[] { 4, 0, 0, 0 };
        public override int Cost => 30000;
        public override string FriendlyName => "Anti-Magic";
        public override bool IgnoreAcid => true;
        public override bool IgnoreCold => true;
        public override bool IgnoreElec => true;
        public override bool IgnoreFire => true;
        public override int Level => 40;
        public override int[] Locale => new int[] { 40, 0, 0, 0 };
        public override bool NoMagic => true;
        public override int Weight => 3;

        public override Item CreateItem(SaveGame saveGame) => new AntiMagicAmuletItem(saveGame);
    }
}
