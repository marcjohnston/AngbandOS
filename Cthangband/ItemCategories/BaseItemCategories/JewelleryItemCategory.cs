using Cthangband.ArtifactBiases;
using Cthangband.Enumerations;
using Cthangband.StaticData;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    /// <summary>
    /// Represents jewellery items.  Amulets and rings are both armour classes.
    /// </summary>
    internal class JewelleryItemCategory : BaseItemCategory
    {
        public JewelleryItemCategory(ItemCategory itemCategory) : base(itemCategory)
        {
        }
        public override int GetBonusValue(Item item, int value)
        {
            int bonusValue = 0;
            bonusValue += (item.BonusToHit + item.BonusDamage + item.BonusArmourClass) * 100;
            bonusValue += base.GetTypeSpecificValue(item, value); // Apply type specific values;
            return bonusValue;
        }
        public override bool IsWorthless(Item item)
        {
            if (item.TypeSpecificValue < 0 || item.BonusArmourClass < 0 || item.BonusToHit < 0 || item.BonusDamage < 0)
            {
                return true;
            }
            return false;
        }
    }
}
