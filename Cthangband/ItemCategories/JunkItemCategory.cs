using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal abstract class JunkItemCategory : BaseItemCategory
    {
        public override ItemCategory CategoryEnum => ItemCategory.Junk;
        public override bool HatesAcid => true;

        public override int PercentageBreakageChance => 100;
    }
}
