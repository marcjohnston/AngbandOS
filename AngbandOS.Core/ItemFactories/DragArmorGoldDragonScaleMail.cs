namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class DragArmorGoldDragonScaleMail : DragArmorItemClass
    {
        private DragArmorGoldDragonScaleMail(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '[';
        public override Colour Colour => Colour.Gold;
        public override string Name => "Gold Dragon Scale Mail";

        public override int Ac => 30;
        public override bool Activate => true;
        public override int[] Chance => new int[] { 8, 0, 0, 0 };
        public override int Cost => 40000;
        public override int Dd => 2;
        public override int Ds => 4;
        public override string FriendlyName => "Gold Dragon Scale Mail~";
        public override bool IgnoreAcid => true;
        public override bool IgnoreCold => true;
        public override bool IgnoreElec => true;
        public override bool IgnoreFire => true;
        public override int Level => 65;
        public override int[] Locale => new int[] { 65, 0, 0, 0 };
        public override bool ResSound => true;
        public override int? SubCategory => 16;
        public override int ToA => 10;
        public override int ToH => -2;
        public override int Weight => 200;
        public override Item CreateItem(SaveGame saveGame) => new GoldDragonScaleMailDragArmorItem(saveGame);
    }
}
