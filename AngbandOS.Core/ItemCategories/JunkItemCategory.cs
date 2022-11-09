using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal abstract class JunkItemCategory : ItemClass
    {
        public override bool EasyKnow => true;
        public override ItemCategory CategoryEnum => ItemCategory.Junk;
        public override bool HatesAcid => true;

        public override int PercentageBreakageChance => 100;
    }
}
