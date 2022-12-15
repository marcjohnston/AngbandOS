using AngbandOS.Core.Interface;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class PolearmLochaberAxe : PolearmItemClass
    {
        public override char Character => '/';
        public override Colour Colour => Colour.Black;
        public override string Name => "Lochaber Axe";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 750;
        public override int Dd => 3;
        public override int Ds => 8;
        public override string FriendlyName => "& Lochaber Axe~";
        public override int Level => 45;
        public override int[] Locale => new int[] { 45, 0, 0, 0 };
        public override bool ShowMods => true;
        public override int? SubCategory => 28;
        public override int Weight => 250;
    }
}
