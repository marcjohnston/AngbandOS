using AngbandOS.Core.Interface;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class HardArmorMithrilChainMail : HardArmorItemClass
    {
        private HardArmorMithrilChainMail(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

        public override char Character => '[';
        public override Colour Colour => Colour.BrightBlue;
        public override string Name => "Mithril Chain Mail";

        public override int Ac => 28;
        public override int[] Chance => new int[] { 4, 0, 0, 0 };
        public override int Cost => 7000;
        public override int Dd => 1;
        public override int Ds => 4;
        public override string FriendlyName => "Mithril Chain Mail~";
        public override bool IgnoreAcid => true;
        public override int Level => 55;
        public override int[] Locale => new int[] { 55, 0, 0, 0 };
        public override int? SubCategory => 20;
        public override int ToH => -1;
        public override int Weight => 150;
    }
}
