using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal abstract class SwordItemCategory : WeaponItemCategory
    {
        public override ItemCategory CategoryEnum => ItemCategory.Sword;
        public override bool HatesAcid => true;

        public override Colour Colour => Colour.BrightWhite;

        public override bool CanVorpalSlay => true;

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
