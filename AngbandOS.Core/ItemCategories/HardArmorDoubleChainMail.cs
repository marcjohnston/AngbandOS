namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class HardArmorDoubleChainMail : HardArmorItemClass
    {
        private HardArmorDoubleChainMail(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '[';
        public override Colour Colour => Colour.Grey;
        public override string Name => "Double Chain Mail";

        public override int Ac => 16;
        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 850;
        public override int Dd => 1;
        public override int Ds => 4;
        public override string FriendlyName => "Double Chain Mail~";
        public override int Level => 30;
        public override int[] Locale => new int[] { 30, 0, 0, 0 };
        public override int? SubCategory => 7;
        public override int ToH => -2;
        public override int Weight => 250;
    }
}
