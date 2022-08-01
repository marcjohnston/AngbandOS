using Cthangband.Enumerations;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class DiggingItemCategory : WeaponItemCategory
    {
        public DiggingItemCategory() : base(ItemCategory.Digging)
        {
        }
        public override Colour Colour => Colour.Grey;

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
