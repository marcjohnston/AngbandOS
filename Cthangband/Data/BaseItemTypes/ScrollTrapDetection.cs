using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class ScrollTrapDetection : ScrollItemCategory
    {
        public override char Character => '?';
        public override string Name => "Scroll:Trap Detection";

        public override int Chance1 => 1;
        public override int Chance2 => 1;
        public override int Cost => 35;
        public override string FriendlyName => "Trap Detection";
        public override int Level => 5;
        public override int Locale1 => 5;
        public override int Locale2 => 10;
        public override int SubCategory => 28;
        public override int Weight => 5;
    }
}
