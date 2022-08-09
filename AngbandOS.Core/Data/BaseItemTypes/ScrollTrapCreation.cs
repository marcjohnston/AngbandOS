using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class ScrollTrapCreation : ScrollItemCategory
    {
        public override char Character => '?';
        public override string Name => "Scroll:Trap Creation";

        public override int Chance1 => 1;
        public override string FriendlyName => "Trap Creation";
        public override int Level => 10;
        public override int Locale1 => 10;
        public override int SubCategory => 7;
        public override int Weight => 5;
    }
}
