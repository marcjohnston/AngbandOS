using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class ScrollIdentify : ScrollItemCategory
    {
        public override char Character => '?';
        public override Colour Colour => Colour.Background;
        public override string Name => "Scroll:Identify";

        public override int Chance1 => 1;
        public override int Chance2 => 1;
        public override int Chance3 => 1;
        public override int Chance4 => 1;
        public override int Cost => 50;
        public override string FriendlyName => "Identify";
        public override int Level => 1;
        public override int Locale1 => 1;
        public override int Locale2 => 5;
        public override int Locale3 => 10;
        public override int Locale4 => 30;
        public override int SubCategory => 12;
        public override int Weight => 5;
    }
}
