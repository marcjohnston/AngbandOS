namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class SeekerBoltAmmunitionItemFactory : BoltAmmunitionItemFactory
    {
        private SeekerBoltAmmunitionItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '{';
        public override Colour Colour => Colour.BrightBlue;
        public override string Name => "Seeker Bolt";

        public override int[] Chance => new int[] { 4, 0, 0, 0 };
        public override int Cost => 25;
        public override int Dd => 4;
        public override int Ds => 5;
        public override string FriendlyName => "& Seeker Bolt~";
        public override int Level => 65;
        public override int[] Locale => new int[] { 65, 0, 0, 0 };
        public override bool ShowMods => true;
        public override int? SubCategory => 2;
        public override int Weight => 3;
        public override Item CreateItem() => new SeekerBoltAmmunitionItem(SaveGame);
    }
}