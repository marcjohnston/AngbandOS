using AngbandOS.Core.Interface;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class SwordBladeofChaos : SwordItemClass
    {
        public override char Character => '|';
        public override Colour Colour => Colour.Purple;
        public override string Name => "Blade of Chaos";

        public override int[] Chance => new int[] { 8, 0, 0, 0 };
        public override int Cost => 4000;
        public override int Dd => 6;
        public override int Ds => 5;
        public override string FriendlyName => "& Blade~ of Chaos";
        public override int Level => 70;
        public override int[] Locale => new int[] { 70, 0, 0, 0 };
        public override bool ResChaos => true;
        public override bool ShowMods => true;
        public override int? SubCategory => 30;
        public override int Weight => 180;
    }
}
