using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal abstract class DiggingItemCategory : WeaponItemCategory
    {
        public override ItemCategory CategoryEnum => ItemCategory.Digging;
        public override Colour Colour => Colour.Grey;

        //public override void ApplyMagic(Item item, int level, int power)
        //{
        //    if (power != 0)
        //    {
        //        ApplyMagicToWeapon(item, level, power);
        //    }
        //}

        public override bool GetsDamageMultiplier => true;
    }
}
