namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class PolearmScytheOfSlicing : PolearmItemClass
    {
        private PolearmScytheOfSlicing(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '/';
        public override Colour Colour => Colour.Red;
        public override string Name => "Scythe of Slicing";

        public override int[] Chance => new int[] { 4, 0, 0, 0 };
        public override int Cost => 3500;
        public override int Dd => 8;
        public override int Ds => 4;
        public override string FriendlyName => "& Scythe~ of Slicing";
        public override int Level => 60;
        public override int[] Locale => new int[] { 60, 0, 0, 0 };
        public override bool ShowMods => true;
        public override int? SubCategory => 30;
        public override int Weight => 250;
        public override Item CreateItem() => new ScytheOfSlicingPolearmWeaponItem(SaveGame);
    }
}