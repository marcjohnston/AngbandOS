using Cthangband.Enumerations;
using Cthangband.StaticData;
using System;

namespace Cthangband.ItemCategories
{
    [Serializable]
   internal class ChestItemCategory : BaseItemCategory
    {
        public ChestItemCategory() : base(ItemCategory.Chest)
        {
        }
        //public override bool HatesFire => true;
        //public override bool HatesAcid => true;

        //public override Colour Colour => Colour.Grey;
        //public override string GetDetailedDescription(Item item)
        //{
        //    string t = string.Empty;
        //    if (!item.IsKnown())
        //    {
        //    }
        //    else if (item.TypeSpecificValue == 0)
        //    {
        //        t += " (empty)";
        //    }
        //    else if (item.TypeSpecificValue < 0)
        //    {
        //        if (GlobalData.ChestTraps[-item.TypeSpecificValue] != 0)
        //        {
        //            t += " (disarmed)";
        //        }
        //        else
        //        {
        //            t += " (unlocked)";
        //        }
        //    }
        //    else
        //    {
        //        switch (GlobalData.ChestTraps[item.TypeSpecificValue])
        //        {
        //            case 0:
        //                {
        //                    t += " (Locked)";
        //                    break;
        //                }
        //            case ChestTrap.ChestLoseStr:
        //                {
        //                    t += " (Poison Needle)";
        //                    break;
        //                }
        //            case ChestTrap.ChestLoseCon:
        //                {
        //                    t += " (Poison Needle)";
        //                    break;
        //                }
        //            case ChestTrap.ChestPoison:
        //                {
        //                    t += " (Gas Trap)";
        //                    break;
        //                }
        //            case ChestTrap.ChestParalyze:
        //                {
        //                    t += " (Gas Trap)";
        //                    break;
        //                }
        //            case ChestTrap.ChestExplode:
        //                {
        //                    t += " (Explosion Device)";
        //                    break;
        //                }
        //            case ChestTrap.ChestSummon:
        //                {
        //                    t += " (Summoning Runes)";
        //                    break;
        //                }
        //            default:
        //                {
        //                    t += " (Multiple Traps)";
        //                    break;
        //                }
        //        }
        //    }
        //    return t;
        //}

        //public override void ApplyMagic(Item item, int level, int power)
        //{
        //    if (item.ItemType.Level > 0)
        //    {
        //        item.TypeSpecificValue = Program.Rng.DieRoll(item.ItemType.Level);
        //        if (item.TypeSpecificValue > 55)
        //        {
        //            item.TypeSpecificValue = (short)(55 + Program.Rng.RandomLessThan(5));
        //        }
        //    }
        //}
    }
}
