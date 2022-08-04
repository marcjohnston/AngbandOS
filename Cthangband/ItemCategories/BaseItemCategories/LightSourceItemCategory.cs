using Cthangband.Enumerations;
using Cthangband.StaticData;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class LightSourceItemCategory : BaseItemCategory
    {
        public override int GetBonusRealValue(Item item, int value)
        {
            int bonusValue = 0;
            bonusValue += base.GetTypeSpecificValue(item, value); // Apply type specific values;
            return bonusValue;
        }
        public override bool IsWorthless(Item item) => item.TypeSpecificValue < 0;
    }
}
