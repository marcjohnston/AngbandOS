namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class DragArmorPowerDragonScaleMail : DragArmorItemClass
    {
        private DragArmorPowerDragonScaleMail(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '[';
        public override Colour Colour => Colour.Yellow;
        public override string Name => "Power Dragon Scale Mail";

        public override int Ac => 40;
        public override int[] Chance => new int[] { 64, 0, 0, 0 };
        public override int Cost => 350000;
        public override int Dd => 2;
        public override int Ds => 4;
        public override string FriendlyName => "Power Dragon Scale Mail~";
        public override int Level => 110;
        public override int[] Locale => new int[] { 110, 0, 0, 0 };
        public override int? SubCategory => 30;
        public override int ToA => 15;
        public override int ToH => -3;
        public override int Weight => 250;
        public override Item CreateItem(SaveGame saveGame) => new PowerDragonScaleMailDragArmorItem(saveGame);
    }
}
