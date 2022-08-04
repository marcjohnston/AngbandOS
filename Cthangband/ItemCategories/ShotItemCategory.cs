using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class ShotItemCategory : WeaponItemCategory
    {
        public override Colour Colour => Colour.BrightBrown;
        public override int GetBonusRealValue(Item item, int value)
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
        public override bool CanAbsorb(Item item, Item other)
        {
            if (!item.StatsAreSame(other))
            {
                return false;
            }
            return true;
        }

        public override int MakeObjectCount => Program.Rng.DiceRoll(6, 7);

        public override bool GetsDamageMultiplier => true;
        public override int PercentageBreakageChance => 25;

    }
}
