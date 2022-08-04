using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class JunkItemCategory : BaseItemCategory
    {
        public override bool HatesAcid => true;

        public override int PercentageBreakageChance => 100;
    }
}
