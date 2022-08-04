using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class ScrollPhaseDoor : ScrollItemCategory
    {
        public override char Character => '?';
        public override Colour Colour => Colour.Background;
        public override string Name => "Scroll:Phase Door";

        public override int Chance1 => 1;
        public override int Cost => 15;
        public override string FriendlyName => "Phase Door";
        public override int Level => 1;
        public override int Locale1 => 1;
        public override int SubCategory => 8;
        public override int Weight => 5;
    }
}
