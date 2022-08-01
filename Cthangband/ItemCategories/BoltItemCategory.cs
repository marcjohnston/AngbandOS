using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class BoltItemCategory : WeaponItemCategory
    {
        public BoltItemCategory() : base(ItemCategory.Bolt)
        {
        }
        //public override Colour Colour => Colour.BrightBrown;
        //public override int GetBonusValue(Item item, int value)
        //{
        //    value = (item.BonusToHit + item.BonusDamage) * 5;
        //    if (item.DamageDice > item.ItemType.Dd && item.DamageDiceSides == item.ItemType.Ds)
        //    {
        //        value += (item.DamageDice - item.ItemType.Dd) * item.DamageDiceSides * 5;
        //    }
        //    return value;
        //}

        //public override bool HatesAcid => true;

        //public override void ApplyMagic(Item item, int level, int power)
        //{
        //    if (power != 0)
        //    {
        //        ApplyMagicToWeapon(item, level, power);
        //    }
        //}

        //public override bool GeneratesMultipleCount => true;

        //public override bool GetsDamageMultiplier => true;
        //public override int PercentageBreakageChance => 25;
    }
}
