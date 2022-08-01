using Cthangband.Enumerations;
using System;
using static Cthangband.Extensions;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class BowItemCategory : WeaponItemCategory
    {
        public BowItemCategory() : base(ItemCategory.Bow)
        {
        }
        //public override bool HatesFire => true;
        //public override bool HatesAcid => true;
        //public override string GetDetailedDescription(Item item)
        //{
        //    FlagSet f1 = new FlagSet();
        //    FlagSet f2 = new FlagSet();
        //    FlagSet f3 = new FlagSet();
        //    item.GetMergedFlags(f1, f2, f3);
        //    int power = item.ItemSubCategory % 10;
        //    if (f3.IsSet(ItemFlag3.XtraMight))
        //    {
        //        power++;
        //    }
        //    string s = $" (x{power})";
        //    if (item.IsKnown())
        //    {
        //        s += $" ({GetSignedValue(item.BonusToHit)},{GetSignedValue(item.BonusDamage)})";
        //    }
        //    return s;
        //}

        //public override Colour Colour => Colour.Brown;

        //public override void ApplyMagic(Item item, int level, int power)
        //{
        //    if (power != 0)
        //    {
        //        ApplyMagicToWeapon(item, level, power);
        //    }
        //}
    }
}
