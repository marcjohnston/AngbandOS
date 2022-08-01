using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class JunkItemCategory : BaseItemCategory
    {
        public JunkItemCategory() : base(ItemCategory.Junk)
        {
        }
        //public override bool HatesAcid => true;

        //public override int PercentageBreakageChance => 100;
    }
}
