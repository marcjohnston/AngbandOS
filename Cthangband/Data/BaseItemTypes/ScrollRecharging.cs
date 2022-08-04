using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class ScrollRecharging : ScrollItemCategory
    {
        public override char Character => '?';
        public override Colour Colour => Colour.Background;
        public override string Name => "Scroll:Recharging";

        public override int Chance1 => 1;
        public override int Cost => 200;
        public override string FriendlyName => "Recharging";
        public override int Level => 40;
        public override int Locale1 => 40;
        public override int SubCategory => 22;
        public override int Weight => 5;
    }
}
