using Cthangband.ArtifactBiases;
using Cthangband.Enumerations;
using Cthangband.StaticData;
using System;
using static Cthangband.Extensions;

namespace Cthangband.ItemCategories
{
    [Serializable]
    /// <summary>
    /// Represents armour items.  Boots, clocks, crowns, dragon armour, gloves, hard armour, helm, shield and soft armour are all armour classes.
    /// </summary>
    internal class ArmourItemCategory : BaseItemCategory
    {
        public ArmourItemCategory(ItemCategory itemCategory) : base(itemCategory)
        {
        }

        public override int GetBonusValue(Item item, int value)
        {
            int bonusValue = 0;
            bonusValue += (item.BonusToHit + item.BonusDamage + item.BonusArmourClass) * 100;
            bonusValue += GetTypeSpecificValue(item, value); // Apply type specific values;
            return bonusValue;
        }

        public override bool IsWorthless(Item item)
        {
            if (item.TypeSpecificValue < 0)
            {
                return true;
            }
            if (item.BonusArmourClass < 0)
            {
                return true;
            }
            return false;
        }

        ///// <summary>
        ///// Applies additional bonus armour class based on the power.
        ///// </summary>
        ///// <param name="item"></param>
        ///// <param name="level"></param>
        ///// <param name="power"></param>
        //public override void ApplyMagic(Item item, int level, int power)
        //{
        //    int toac1 = Program.Rng.DieRoll(5) + GetBonusValue(5, level);
        //    int toac2 = GetBonusValue(10, level);
        //    if (power > 0)
        //    {
        //        item.BonusArmourClass += toac1;
        //        if (power > 1)
        //        {
        //            item.BonusArmourClass += toac2;
        //        }
        //    }
        //    else if (power < 0)
        //    {
        //        item.BonusArmourClass -= toac1;
        //        if (power < -1)
        //        {
        //            item.BonusArmourClass -= toac2;
        //        }
        //        if (item.BonusArmourClass < 0)
        //        {
        //            item.IdentifyFlags.Set(Constants.IdentCursed);
        //        }
        //    }
        //}

        public override string GetDetailedDescription(Item item)
        {
            string s = "";
            if (item.IsKnown())
            {
                FlagSet f1 = new FlagSet();
                FlagSet f2 = new FlagSet();
                FlagSet f3 = new FlagSet();
                item.GetMergedFlags(f1, f2, f3);
                if (f3.IsSet(ItemFlag3.ShowMods) || (item.BonusToHit != 0 && item.BonusDamage != 0))
                {
                    s += $" ({GetSignedValue(item.BonusToHit)},{GetSignedValue(item.BonusDamage)})";
                }
                else if (item.BonusToHit != 0)
                {
                    s += $" ({GetSignedValue(item.BonusToHit)})";
                }
                else if (item.BonusDamage != 0)
                {
                    s += $" ({GetSignedValue(item.BonusDamage)})";
                }

                // Add base armour class for all types of armour and when the base armour class is greater than zero.
                s += $" [{item.BaseArmourClass},{GetSignedValue(item.BonusArmourClass)}]";
            }
            else if (item.BaseArmourClass != 0)
            {
                s += $" [{item.BaseArmourClass}]";
            }
            return s;
        }
    }
}
