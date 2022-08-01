using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class SpikeItemCategory : BaseItemCategory
    {
        public SpikeItemCategory() : base(ItemCategory.Spike)
        {
        }

        public override Colour Colour => Colour.Grey;
        //public override bool GeneratesMultipleCount => true;
    }
}
