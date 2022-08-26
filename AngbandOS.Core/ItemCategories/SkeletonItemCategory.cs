using AngbandOS.Interface;
using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal abstract class SkeletonItemCategory : BaseItemCategory
    {
        public override ItemCategory CategoryEnum => ItemCategory.Skeleton;
        public override bool HatesAcid => true;

        public override Colour Colour => Colour.Beige;
        public override int PercentageBreakageChance => 50;
    }
}
