namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class DeathBookNecronomicon : DeathBookItemClass
    {
        private DeathBookNecronomicon(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '?';
        public override Colour Colour => Colour.Black;
        public override string Name => "[Necronomicon]";

        public override int[] Chance => new int[] { 3, 0, 0, 0 };
        public override int Cost => 100000;
        public override int Dd => 1;
        public override int Ds => 1;
        public override string FriendlyName => "[Necronomicon]";
        public override bool IgnoreAcid => true;
        public override bool IgnoreCold => true;
        public override bool IgnoreElec => true;
        public override bool IgnoreFire => true;
        public override int Level => 90;
        public override int[] Locale => new int[] { 90, 0, 0, 0 };
        public override int? SubCategory => 3;
        public override int Weight => 30;
        public override bool KindIsGood => true;
        public override Item CreateItem() => new NecronomiconDeathBookItem(SaveGame);
    }
}
