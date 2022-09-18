using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal class ScrollSatisfyHunger : ScrollItemCategory
    {
        public override char Character => '?';
        public override string Name => "Scroll:Satisfy Hunger";

        public override int Chance1 => 1;
        public override int Chance2 => 1;
        public override int Chance3 => 1;
        public override int Chance4 => 1;
        public override int Cost => 10;
        public override string FriendlyName => "Satisfy Hunger";
        public override int Level => 5;
        public override int Locale1 => 5;
        public override int Locale2 => 20;
        public override int Locale3 => 50;
        public override int Locale4 => 75;
        public override int SubCategory => 32;
        public override int Weight => 5;
    }
}
