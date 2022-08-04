using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal abstract class BottleItemCategory : BaseItemCategory
    {
        public override ItemCategory CategoryEnum => ItemCategory.Bottle;
        public override bool HatesCold => true;
        public override bool HatesAcid => true;

        public override int PercentageBreakageChance => 100;
    }
}
