using AngbandOS.Core;
using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;
using System;

namespace AngbandOS.ItemCategories
{
    [Serializable]
   internal abstract class ChestItemCategory : BaseItemCategory
    {
        public override ItemCategory CategoryEnum => ItemCategory.Chest;
        public override bool HatesFire => true;
        public override bool HatesAcid => true;

        public override bool CanAbsorb(Item item, Item other)
        {
            return false;
        }

        public override Colour Colour => Colour.Grey;

        public override bool IsStompable(Item item)
        {
            if (!item.IsKnown())
            {
                return false;
            }
            else if (item.TypeSpecificValue == 0)
            {
                return item.ItemType.Stompable[StompableType.Broken];
            }
            else if (item.TypeSpecificValue < 0)
            {
                return item.ItemType.Stompable[StompableType.Average];
            }
            else
            {
                switch (GlobalData.ChestTraps[item.TypeSpecificValue])
                {
                    case 0:
                        {
                            return item.ItemType.Stompable[StompableType.Good];
                        }
                    default:
                        {
                            return item.ItemType.Stompable[StompableType.Excellent];
                        }
                }
            }
        }

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
