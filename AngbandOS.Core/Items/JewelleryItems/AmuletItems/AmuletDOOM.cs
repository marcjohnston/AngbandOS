namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class AmuletDOOM : AmuletItemClass
    {
        private AmuletDOOM(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '"';
        public override string Name => "DOOM";

        public override bool Cha => true;
        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override bool Con => true;
        public override bool Cursed => true;
        public override bool Dex => true;
        public override string FriendlyName => "DOOM";
        public override bool HideType => true;
        public override bool Int => true;
        public override int Level => 50;
        public override int[] Locale => new int[] { 50, 0, 0, 0 };
        public override int Pval => -5;
        public override bool Str => true;
        public override int Weight => 3;
        public override bool Wis => true;
        public override Item CreateItem() => new DOOMAmuletItem(SaveGame);
    }
}