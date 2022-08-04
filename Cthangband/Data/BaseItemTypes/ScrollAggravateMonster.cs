using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class ScrollAggravateMonster : ScrollItemCategory
    {
        public override char Character => '?';
        public override Colour Colour => Colour.Background;
        public override string Name => "Scroll:Aggravate Monster";

        public override int Chance1 => 1;
        public override string FriendlyName => "Aggravate Monster";
        public override int Level => 5;
        public override int Locale1 => 5;
        public override int SubCategory => 1;
        public override int Weight => 5;
    }
}
