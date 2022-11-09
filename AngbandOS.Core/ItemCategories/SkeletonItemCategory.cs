using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal abstract class SkeletonItemCategory : ItemClass
    {
        public override bool EasyKnow => true;
        public override ItemCategory CategoryEnum => ItemCategory.Skeleton;
        public override bool HatesAcid => true;

        public override Colour Colour => Colour.Beige;
        public override int PercentageBreakageChance => 50;
    }
}
