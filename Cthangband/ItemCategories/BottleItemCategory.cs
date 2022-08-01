using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class BottleItemCategory : BaseItemCategory
    {
        public BottleItemCategory() : base(ItemCategory.Bottle)
        {
        }
        //public override bool HatesCold => true;
        public override bool HatesAcid => true;

        //public override int PercentageBreakageChance => 100;
    }
}
