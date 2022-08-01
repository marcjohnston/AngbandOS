using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class ShotItemCategory : WeaponItemCategory
    {
        public ShotItemCategory() : base(ItemCategory.Shot)
        {
        }
        public override Colour Colour => Colour.BrightBrown;
        public override int GetBonusValue(Item item, int value)
        {
            int bonusValue = 0;
            bonusValue = (item.BonusToHit + item.BonusDamage) * 5;
            if (item.DamageDice > item.ItemType.Dd && item.DamageDiceSides == item.ItemType.Ds)
            {
                bonusValue += (item.DamageDice - item.ItemType.Dd) * item.DamageDiceSides * 5;
            }
            bonusValue += GetTypeSpecificValue(item, value); // Apply type specific values;
            return bonusValue;
        }

        //public override void ApplyMagic(Item item, int level, int power)
        //{
        //    if (power != 0)
        //    {
        //        ApplyMagicToWeapon(item, level, power);
        //    }
        //}

        //public override bool GeneratesMultipleCount => true;

        //public override bool GetsDamageMultiplier => true;
        public override int PercentageBreakageChance => 25;

    }
}
