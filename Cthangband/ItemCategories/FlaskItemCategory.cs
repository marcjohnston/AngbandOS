using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class FlaskItemCategory : BaseItemCategory
    {
        public FlaskItemCategory() : base(ItemCategory.Flask)
        {
        }
        public override bool HatesCold => true;
        public override Colour Colour => Colour.Yellow;
        public override int PercentageBreakageChance => 100;
    }
}
