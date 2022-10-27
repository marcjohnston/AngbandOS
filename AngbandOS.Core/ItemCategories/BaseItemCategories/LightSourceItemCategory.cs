using AngbandOS.Enumerations;
using AngbandOS.StaticData;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal abstract class LightSourceItemCategory : BaseItemCategory
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
