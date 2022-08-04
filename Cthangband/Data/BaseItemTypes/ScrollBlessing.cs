using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class ScrollBlessing : ScrollItemCategory
    {
        public override char Character => '?';
        public override Colour Colour => Colour.Background;
        public override string Name => "Scroll:Blessing";

        public override int Chance1 => 1;
        public override int Cost => 15;
        public override string FriendlyName => "Blessing";
        public override int Level => 1;
        public override int Locale1 => 1;
        public override int SubCategory => 33;
        public override int Weight => 5;
    }
}
