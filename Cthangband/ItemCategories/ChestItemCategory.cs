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
        public override bool HatesFire => true;
        public override bool HatesAcid => true;

        public override Colour Colour => Colour.Grey;
        public override string GetDetailedDescription(Item item)
        {
            string s = string.Empty;
            if (!item.IsKnown())
            {
            }
            else if (item.TypeSpecificValue == 0)
            {
                s += " (empty)";
            }
            else if (item.TypeSpecificValue < 0)
            {
                if (GlobalData.ChestTraps[-item.TypeSpecificValue] != 0)
                {
                    s += " (disarmed)";
                }
                else
                {
                    s += " (unlocked)";
                }
            }
            else
            {
                switch (GlobalData.ChestTraps[item.TypeSpecificValue])
                {
                    case 0:
                        {
                            s += " (Locked)";
                            break;
                        }
                    case ChestTrap.ChestLoseStr:
                        {
                            s += " (Poison Needle)";
                            break;
                        }
                    case ChestTrap.ChestLoseCon:
                        {
                            s += " (Poison Needle)";
                            break;
                        }
                    case ChestTrap.ChestPoison:
                        {
                            s += " (Gas Trap)";
                            break;
                        }
                    case ChestTrap.ChestParalyze:
                        {
                            s += " (Gas Trap)";
                            break;
                        }
                    case ChestTrap.ChestExplode:
                        {
                            s += " (Explosion Device)";
                            break;
                        }
                    case ChestTrap.ChestSummon:
                        {
                            s += " (Summoning Runes)";
                            break;
                        }
                    default:
                        {
                            s += " (Multiple Traps)";
                            break;
                        }
                }
            }

            // Chests do not have Mods, Damage or Bonus.  We are omitting the description for those features.
            return s;
        }

        public override void ApplyMagic(Item item, int level, int power)
        {
            if (item.ItemType.Level > 0)
            {
                item.TypeSpecificValue = Program.Rng.DieRoll(item.ItemType.Level);
                if (item.TypeSpecificValue > 55)
                {
                    item.TypeSpecificValue = (short)(55 + Program.Rng.RandomLessThan(5));
                }
            }
        }
    }
}
