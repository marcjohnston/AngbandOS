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

        /// <summary>
        /// Returns whether or not the chest is small.  Small chests have a 75% chance that the items in the chest are gold.  Large chest always return items.
        /// </summary>
        public abstract bool IsSmall { get; }
        public abstract int NumberOfItemsContained { get; }
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
                    case ChestTrap.ChestNotTrapped:
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
                if (GlobalData.ChestTraps[-item.TypeSpecificValue] != ChestTrap.ChestNotTrapped)
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
                    case ChestTrap.ChestNotTrapped:
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

        /// <summary>
        /// Assigns the TypeSpecificValue for this chest.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="level"></param>
        /// <param name="power"></param>
        /// <remarks>
        /// Logic:
        /// If the chest is on the town level (level == 0 [not sure where the wilderness is]), it is not trapped (default TypeSpecificValue).
        /// A die roll from 1 to the level of the chest is made.  Any value >55 will convert to a random chest trap between 55 and 63.
        /// </remarks>
        public override void ApplyMagic(Item item, int level, int power)
        {
            if (item.ItemType.Level > 0)
            {
                item.TypeSpecificValue = Program.Rng.DieRoll(item.ItemType.Level);
                if (item.TypeSpecificValue > 55)
                {
                    item.TypeSpecificValue = (55 + Program.Rng.RandomLessThan(5));
                }
            }
        }
    }
}
