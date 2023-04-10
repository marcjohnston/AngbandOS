namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class ShieldSmallMetalShield : ShieldItemClass
    {
        private ShieldSmallMetalShield(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => ')';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Small Metal Shield";

        public override int Ac => 3;
        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 50;
        public override int Dd => 1;
        public override int Ds => 2;
        public override string FriendlyName => "& Small Metal Shield~";
        public override int Level => 10;
        public override int[] Locale => new int[] { 10, 0, 0, 0 };
        public override int? SubCategory => 3;
        public override int Weight => 65;
        public override Item CreateItem() => new SmallMetalShieldArmorItem(SaveGame);
    }
}
