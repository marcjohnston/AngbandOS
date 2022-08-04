using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class SkeletonItemCategory : BaseItemCategory
    {
        public override bool HatesAcid => true;

        public override Colour Colour => Colour.Beige;
        public override int PercentageBreakageChance => 50;
    }
}
