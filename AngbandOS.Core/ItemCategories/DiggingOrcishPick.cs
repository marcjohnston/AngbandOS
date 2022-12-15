using AngbandOS.Core.Interface;

using AngbandOS.Core.ItemClasses;

namespace AngbandOS.Core.ItemCategories
{
    [Serializable]
    internal class DiggingOrcishPick : DiggingItemClass
    {
        public override char Character => '\\';
        public override Colour Colour => Colour.Green;
        public override string Name => "Orcish Pick";

        public override int[] Chance => new int[] { 4, 0, 0, 0 };
        public override int Cost => 300;
        public override int Dd => 1;
        public override int Ds => 3;
        public override string FriendlyName => "& Orcish Pick~";
        public override int Level => 30;
        public override int[] Locale => new int[] { 30, 0, 0, 0 };
        public override int Pval => 2;
        public override bool ShowMods => true;
        public override bool Tunnel => true;
        public override int Weight => 150;
    }
}
