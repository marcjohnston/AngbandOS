using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class ScrollSpecialIdentify : ScrollItemCategory
    {
        public override char Character => '?';
        public override Colour Colour => Colour.Background;
        public override string Name => "Scroll:*Identify*";

        public override int Chance1 => 1;
        public override int Chance2 => 2;
        public override int Chance3 => 1;
        public override int Chance4 => 1;
        public override int Cost => 1000;
        public override string FriendlyName => "*Identify*";
        public override int Level => 30;
        public override int Locale1 => 30;
        public override int Locale2 => 50;
        public override int Locale3 => 80;
        public override int Locale4 => 100;
        public override int SubCategory => 13;
        public override int Weight => 5;
    }
}
