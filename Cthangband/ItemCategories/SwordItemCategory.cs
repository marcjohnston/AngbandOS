using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class SwordItemCategory : WeaponItemCategory
    {
        public SwordItemCategory() : base(ItemCategory.Sword)
        {
        }
        //public override bool HatesAcid => true;

        //public override Colour Colour => Colour.BrightWhite;

        //public override void ApplyMagic(Item item, int level, int power)
        //{
        //    if (power != 0)
        //    {
        //        ApplyMagicToWeapon(item, level, power);
        //    }
        //}

        //public override bool GetsDamageMultiplier => true;
    }
}
