using Cthangband.Enumerations;
using Cthangband.StaticData;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class LightSourceItemCategory : BaseItemCategory
    {
        public LightSourceItemCategory(ItemCategory itemCategory) : base(itemCategory)
        {
        }
        //public override bool HasAdditionalTypeSpecificValue => true;
        //public override bool IsWorthless(Item item) => item.TypeSpecificValue < 0;
    }
}
