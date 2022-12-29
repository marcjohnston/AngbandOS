namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class HardArmorMithrilPlateMail : HardArmorItemClass
    {
        private HardArmorMithrilPlateMail(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '[';
        public override Colour Colour => Colour.BrightBlue;
        public override string Name => "Mithril Plate Mail";

        public override int Ac => 35;
        public override int[] Chance => new int[] { 4, 0, 0, 0 };
        public override int Cost => 15000;
        public override int Dd => 2;
        public override int Ds => 4;
        public override string FriendlyName => "Mithril Plate Mail~";
        public override bool IgnoreAcid => true;
        public override int Level => 60;
        public override int[] Locale => new int[] { 60, 0, 0, 0 };
        public override int? SubCategory => 25;
        public override int ToH => -3;
        public override int Weight => 300;
    }
}
