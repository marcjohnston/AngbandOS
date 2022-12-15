using AngbandOS.Core.Interface;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class SwordRapier : SwordItemClass
    {
        public override char Character => '|';
        public override Colour Colour => Colour.BrightWhite;
        public override string Name => "Rapier";

        public override int[] Chance => new int[] { 1, 0, 0, 0 };
        public override int Cost => 42;
        public override int Dd => 1;
        public override int Ds => 6;
        public override string FriendlyName => "& Rapier~";
        public override int Level => 5;
        public override int[] Locale => new int[] { 5, 0, 0, 0 };
        public override bool ShowMods => true;
        public override int? SubCategory => 7;
        public override int Weight => 40;
    }
}
