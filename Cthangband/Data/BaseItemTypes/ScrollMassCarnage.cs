using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class ScrollMassCarnage : ScrollItemCategory
    {
        public override char Character => '?';
        public override Colour Colour => Colour.Background;
        public override string Name => "Scroll:Mass Carnage";

        public override int Chance1 => 4;
        public override int Chance2 => 4;
        public override int Cost => 1000;
        public override string FriendlyName => "Mass Carnage";
        public override int Level => 50;
        public override int Locale1 => 50;
        public override int Locale2 => 100;
        public override int SubCategory => 45;
        public override int Weight => 5;
    }
}
