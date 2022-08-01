// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using Cthangband.ActivationPowers;
using Cthangband.ArtifactBiases;
using Cthangband.Enumerations;
using Cthangband.ItemCategories;
using Cthangband.StaticData;
using Cthangband.UI;
using System;
using System.IO;
using static Cthangband.Extensions;

namespace Cthangband
{
    [Serializable]
    internal class Item
    {
        public static int CoinType;
        public readonly FlagSet IdentifyFlags = new FlagSet();
        public readonly FlagSet RandartFlags1 = new FlagSet();
        public readonly FlagSet RandartFlags2 = new FlagSet();
        public readonly FlagSet RandartFlags3 = new FlagSet();
        public int BaseArmourClass;
        public int BonusArmourClass;
        public int BonusDamage;
        public IActivationPower BonusPowerSubType;
        public Enumerations.RareItemType BonusPowerType;
        public int BonusToHit;
        public IItemCategory BaseCategory = null;
        public int Count;
        public int DamageDice;
        public int DamageDiceSides;
        public int Discount;
        public FixedArtifactId FixedArtifactIndex;
        public int HoldingMonsterIndex;
        public string Inscription = "";
        public int ItemSubCategory;
        public ItemType ItemType;
        public bool Marked;
        public int NextInStack;
        public string RandartName = "";
        public Enumerations.RareItemType RareItemTypeIndex;
        public int RechargeTimeLeft;
        public int TypeSpecificValue;
        public int Weight;
        public int X;
        public int Y;

        public Item()
        {
        }

        public bool IsKnownArtifact => IsKnown() && (IsFixedArtifact() || !string.IsNullOrEmpty(RandartName));

        public ItemCategory Category => BaseCategory == null ? ItemCategory.None : BaseCategory.CategoryEnum;

        public bool IsBlessed()
        {
            FlagSet f1 = new FlagSet();
            FlagSet f2 = new FlagSet();
            FlagSet f3 = new FlagSet();
            GetMergedFlags(f1, f2, f3);
            return f3.IsSet(ItemFlag3.Blessed);
        }

        public Item(Item original)
        {
            BaseArmourClass = original.BaseArmourClass;
            RandartFlags1.Copy(original.RandartFlags1);
            RandartFlags2.Copy(original.RandartFlags2);
            RandartFlags3.Copy(original.RandartFlags3);
            RandartName = original.RandartName;
            DamageDice = original.DamageDice;
            Discount = original.Discount;
            DamageDiceSides = original.DamageDiceSides;
            HoldingMonsterIndex = original.HoldingMonsterIndex;
            IdentifyFlags.Copy(original.IdentifyFlags);
            X = original.X;
            Y = original.Y;
            ItemType = original.ItemType;
            Marked = original.Marked;
            FixedArtifactIndex = original.FixedArtifactIndex;
            RareItemTypeIndex = original.RareItemTypeIndex;
            NextInStack = original.NextInStack;
            Inscription = original.Inscription;
            Count = original.Count;
            TypeSpecificValue = original.TypeSpecificValue;
            ItemSubCategory = original.ItemSubCategory;
            RechargeTimeLeft = original.RechargeTimeLeft;
            BonusArmourClass = original.BonusArmourClass;
            BonusDamage = original.BonusDamage;
            BonusToHit = original.BonusToHit;
            BaseCategory = BaseItemCategory.CreateFromEnum(original.Category);
            Weight = original.Weight;
            BonusPowerType = original.BonusPowerType;
            BonusPowerSubType = original.BonusPowerSubType;
        }

        public void Absorb(Item other)
        {
            int total = Count + other.Count;
            Count = total < Constants.MaxStackSize ? total : Constants.MaxStackSize - 1;
            if (other.IsKnown())
            {
                BecomeKnown();
            }
            if (IdentifyFlags.IsSet(Constants.IdentStoreb) || (other.IdentifyFlags.IsSet(Constants.IdentStoreb) &&
                !(IdentifyFlags.IsSet(Constants.IdentStoreb) && other.IdentifyFlags.IsSet(Constants.IdentStoreb))))
            {
                if (other.IdentifyFlags.IsSet(Constants.IdentStoreb))
                {
                    other.IdentifyFlags.Clear(Constants.IdentStoreb);
                }
                if (IdentifyFlags.IsSet(Constants.IdentStoreb))
                {
                    IdentifyFlags.Clear(Constants.IdentStoreb);
                }
            }
            if (other.IdentifyFlags.IsSet(Constants.IdentMental))
            {
                IdentifyFlags.Set(Constants.IdentMental);
            }
            if (!string.IsNullOrEmpty(other.Inscription))
            {
                Inscription = other.Inscription;
            }
            if (Discount < other.Discount)
            {
                Discount = other.Discount;
            }
        }

        public int AdjustDamageForMonsterType(int tdam, Monster mPtr)
        {
            int mult = 1;
            MonsterRace rPtr = mPtr.Race;
            FlagSet f1 = new FlagSet();
            FlagSet f2 = new FlagSet();
            FlagSet f3 = new FlagSet();
            GetMergedFlags(f1, f2, f3);
            switch (Category)
            {
                case ItemCategory.Shot:
                case ItemCategory.Arrow:
                case ItemCategory.Bolt:
                case ItemCategory.Hafted:
                case ItemCategory.Polearm:
                case ItemCategory.Sword:
                case ItemCategory.Digging:
                    {
                        if (f1.IsSet(ItemFlag1.SlayAnimal) && (rPtr.Flags3 & MonsterFlag3.Animal) != 0)
                        {
                            if (mPtr.IsVisible)
                            {
                                rPtr.Knowledge.RFlags3 |= MonsterFlag3.Animal;
                            }
                            if (mult < 2)
                            {
                                mult = 2;
                            }
                        }
                        if (f1.IsSet(ItemFlag1.SlayEvil) && (rPtr.Flags3 & MonsterFlag3.Evil) != 0)
                        {
                            if (mPtr.IsVisible)
                            {
                                rPtr.Knowledge.RFlags3 |= MonsterFlag3.Evil;
                            }
                            if (mult < 2)
                            {
                                mult = 2;
                            }
                        }
                        if (f1.IsSet(ItemFlag1.SlayUndead) && (rPtr.Flags3 & MonsterFlag3.Undead) != 0)
                        {
                            if (mPtr.IsVisible)
                            {
                                rPtr.Knowledge.RFlags3 |= MonsterFlag3.Undead;
                            }
                            if (mult < 3)
                            {
                                mult = 3;
                            }
                        }
                        if (f1.IsSet(ItemFlag1.SlayDemon) && (rPtr.Flags3 & MonsterFlag3.Demon) != 0)
                        {
                            if (mPtr.IsVisible)
                            {
                                rPtr.Knowledge.RFlags3 |= MonsterFlag3.Demon;
                            }
                            if (mult < 3)
                            {
                                mult = 3;
                            }
                        }
                        if (f1.IsSet(ItemFlag1.SlayOrc) && (rPtr.Flags3 & MonsterFlag3.Orc) != 0)
                        {
                            if (mPtr.IsVisible)
                            {
                                rPtr.Knowledge.RFlags3 |= MonsterFlag3.Orc;
                            }
                            if (mult < 3)
                            {
                                mult = 3;
                            }
                        }
                        if (f1.IsSet(ItemFlag1.SlayTroll) && (rPtr.Flags3 & MonsterFlag3.Troll) != 0)
                        {
                            if (mPtr.IsVisible)
                            {
                                rPtr.Knowledge.RFlags3 |= MonsterFlag3.Troll;
                            }
                            if (mult < 3)
                            {
                                mult = 3;
                            }
                        }
                        if (f1.IsSet(ItemFlag1.SlayGiant) && (rPtr.Flags3 & MonsterFlag3.Giant) != 0)
                        {
                            if (mPtr.IsVisible)
                            {
                                rPtr.Knowledge.RFlags3 |= MonsterFlag3.Giant;
                            }
                            if (mult < 3)
                            {
                                mult = 3;
                            }
                        }
                        if (f1.IsSet(ItemFlag1.SlayDragon) && (rPtr.Flags3 & MonsterFlag3.Dragon) != 0)
                        {
                            if (mPtr.IsVisible)
                            {
                                rPtr.Knowledge.RFlags3 |= MonsterFlag3.Dragon;
                            }
                            if (mult < 3)
                            {
                                mult = 3;
                            }
                        }
                        if (f1.IsSet(ItemFlag1.KillDragon) && (rPtr.Flags3 & MonsterFlag3.Dragon) != 0)
                        {
                            if (mPtr.IsVisible)
                            {
                                rPtr.Knowledge.RFlags3 |= MonsterFlag3.Dragon;
                            }
                            if (mult < 5)
                            {
                                mult = 5;
                            }
                            if (FixedArtifactIndex == FixedArtifactId.SwordLightning)
                            {
                                mult *= 3;
                            }
                        }
                        if (f1.IsSet(ItemFlag1.BrandAcid))
                        {
                            if ((rPtr.Flags3 & MonsterFlag3.ImmuneAcid) != 0)
                            {
                                if (mPtr.IsVisible)
                                {
                                    rPtr.Knowledge.RFlags3 |= MonsterFlag3.ImmuneAcid;
                                }
                            }
                            else
                            {
                                if (mult < 3)
                                {
                                    mult = 3;
                                }
                            }
                        }
                        if (f1.IsSet(ItemFlag1.BrandElec))
                        {
                            if ((rPtr.Flags3 & MonsterFlag3.ImmuneLightning) != 0)
                            {
                                if (mPtr.IsVisible)
                                {
                                    rPtr.Knowledge.RFlags3 |= MonsterFlag3.ImmuneLightning;
                                }
                            }
                            else
                            {
                                if (mult < 3)
                                {
                                    mult = 3;
                                }
                            }
                        }
                        if (f1.IsSet(ItemFlag1.BrandFire))
                        {
                            if ((rPtr.Flags3 & MonsterFlag3.ImmuneFire) != 0)
                            {
                                if (mPtr.IsVisible)
                                {
                                    rPtr.Knowledge.RFlags3 |= MonsterFlag3.ImmuneFire;
                                }
                            }
                            else
                            {
                                if (mult < 3)
                                {
                                    mult = 3;
                                }
                            }
                        }
                        if (f1.IsSet(ItemFlag1.BrandCold))
                        {
                            if ((rPtr.Flags3 & MonsterFlag3.ImmuneCold) != 0)
                            {
                                if (mPtr.IsVisible)
                                {
                                    rPtr.Knowledge.RFlags3 |= MonsterFlag3.ImmuneCold;
                                }
                            }
                            else
                            {
                                if (mult < 3)
                                {
                                    mult = 3;
                                }
                            }
                        }
                        if (f1.IsSet(ItemFlag1.BrandPois))
                        {
                            if ((rPtr.Flags3 & MonsterFlag3.ImmunePoison) != 0)
                            {
                                if (mPtr.IsVisible)
                                {
                                    rPtr.Knowledge.RFlags3 |= MonsterFlag3.ImmunePoison;
                                }
                            }
                            else
                            {
                                if (mult < 3)
                                {
                                    mult = 3;
                                }
                            }
                        }
                        break;
                    }
            }
            return tdam * mult;
        }

        public void ApplyRandomResistance(int specific)
        {
            IArtifactBias artifactBias = null;
            ApplyRandomResistance(ref artifactBias, specific); // TODO: We has to inject 0 for the ArtifactBias because the constructor would have initialized the _artifactBias to 0.
        }

        public void AssignItemType(ItemType kIdx)
        {
            ItemType kPtr = kIdx;
            ItemType = kIdx;
            BaseCategory = BaseItemCategory.CreateFromEnum(kPtr.Category);
            ItemSubCategory = kPtr.SubCategory;
            TypeSpecificValue = kPtr.Pval;
            Count = 1;
            Weight = kPtr.Weight;
            BonusToHit = kPtr.ToH;
            BonusDamage = kPtr.ToD;
            BonusArmourClass = kPtr.ToA;
            BaseArmourClass = kPtr.Ac;
            DamageDice = kPtr.Dd;
            DamageDiceSides = kPtr.Ds;
            if (kPtr.Cost <= 0)
            {
                IdentifyFlags.Set(Constants.IdentBroken);
            }
            if (kPtr.Flags3.IsSet(ItemFlag3.Cursed))
            {
                IdentifyFlags.Set(Constants.IdentCursed);
            }
        }

        public void BecomeFlavourAware()
        {
            ItemType.FlavourAware = true;
        }

        public void BecomeKnown()
        {
            if (!string.IsNullOrEmpty(Inscription) && IdentifyFlags.IsSet(Constants.IdentSense))
            {
                string q = Inscription;
                if (q == "cursed" || q == "broken" || q == "good" || q == "average" || q == "excellent" ||
                    q == "worthless" || q == "special" || q == "terrible")
                {
                    Inscription = string.Empty;
                }
            }
            IdentifyFlags.Clear(Constants.IdentSense);
            IdentifyFlags.Clear(Constants.IdentEmpty);
            IdentifyFlags.Set(Constants.IdentKnown);
        }

        public int BreakageChance()
        {
            switch (Category)
            {
                case ItemCategory.Flask:
                case ItemCategory.Potion:
                case ItemCategory.Bottle:
                case ItemCategory.Food:
                case ItemCategory.Junk:
                    return 100;

                case ItemCategory.Light:
                case ItemCategory.Scroll:
                case ItemCategory.Skeleton:
                    {
                        return 50;
                    }
                case ItemCategory.Wand:
                case ItemCategory.Arrow:
                case ItemCategory.Shot:
                case ItemCategory.Bolt:
                    {
                        return 25;
                    }
            }
            return 10;
        }

        public bool CanAbsorb(Item other)
        {
            int total = Count + other.Count;
            if (ItemType != other.ItemType)
            {
                return false;
            }
            switch (Category)
            {
                case ItemCategory.Chest:
                    return false;

                case ItemCategory.Food:
                case ItemCategory.Potion:
                case ItemCategory.Scroll:
                    break;

                case ItemCategory.Staff:
                case ItemCategory.Wand:
                    if (!IsKnown() || !other.IsKnown())
                    {
                        return false;
                    }
                    if (TypeSpecificValue != other.TypeSpecificValue)
                    {
                        return false;
                    }
                    break;

                case ItemCategory.Rod:
                    if (TypeSpecificValue != other.TypeSpecificValue)
                    {
                        return false;
                    }
                    break;

                case ItemCategory.Bow:
                case ItemCategory.Digging:
                case ItemCategory.Hafted:
                case ItemCategory.Polearm:
                case ItemCategory.Sword:
                case ItemCategory.Boots:
                case ItemCategory.Gloves:
                case ItemCategory.Helm:
                case ItemCategory.Crown:
                case ItemCategory.Shield:
                case ItemCategory.Cloak:
                case ItemCategory.SoftArmor:
                case ItemCategory.HardArmor:
                case ItemCategory.DragArmor:
                case ItemCategory.Ring:
                case ItemCategory.Amulet:
                case ItemCategory.Light:
                    if (!IsKnown() || !other.IsKnown())
                    {
                        return false;
                    }
                    if (IsKnown() != other.IsKnown())
                    {
                        return false;
                    }
                    if (BonusToHit != other.BonusToHit)
                    {
                        return false;
                    }
                    if (BonusDamage != other.BonusDamage)
                    {
                        return false;
                    }
                    if (BonusArmourClass != other.BonusArmourClass)
                    {
                        return false;
                    }
                    if (TypeSpecificValue != other.TypeSpecificValue)
                    {
                        return false;
                    }
                    if (FixedArtifactIndex != other.FixedArtifactIndex)
                    {
                        return false;
                    }
                    if (!string.IsNullOrEmpty(RandartName) || !string.IsNullOrEmpty(other.RandartName))
                    {
                        return false;
                    }
                    if (RareItemTypeIndex != other.RareItemTypeIndex)
                    {
                        return false;
                    }
                    if (BonusPowerType != 0 || other.BonusPowerType != 0)
                    {
                        return false;
                    }
                    if (RechargeTimeLeft != 0 || other.RechargeTimeLeft != 0)
                    {
                        return false;
                    }
                    if (BaseArmourClass != other.BaseArmourClass)
                    {
                        return false;
                    }
                    if (DamageDice != other.DamageDice)
                    {
                        return false;
                    }
                    if (DamageDiceSides != other.DamageDiceSides)
                    {
                        return false;
                    }
                    break;

                case ItemCategory.Bolt:
                case ItemCategory.Arrow:
                case ItemCategory.Shot:
                    if (IsKnown() != other.IsKnown())
                    {
                        return false;
                    }
                    if (BonusToHit != other.BonusToHit)
                    {
                        return false;
                    }
                    if (BonusDamage != other.BonusDamage)
                    {
                        return false;
                    }
                    if (BonusArmourClass != other.BonusArmourClass)
                    {
                        return false;
                    }
                    if (TypeSpecificValue != other.TypeSpecificValue)
                    {
                        return false;
                    }
                    if (FixedArtifactIndex != other.FixedArtifactIndex)
                    {
                        return false;
                    }
                    if (!string.IsNullOrEmpty(RandartName) || !string.IsNullOrEmpty(other.RandartName))
                    {
                        return false;
                    }
                    if (RareItemTypeIndex != other.RareItemTypeIndex)
                    {
                        return false;
                    }
                    if (BonusPowerType != 0 || other.BonusPowerType != 0)
                    {
                        return false;
                    }
                    if (RechargeTimeLeft != 0 || other.RechargeTimeLeft != 0)
                    {
                        return false;
                    }
                    if (BaseArmourClass != other.BaseArmourClass)
                    {
                        return false;
                    }
                    if (DamageDice != other.DamageDice)
                    {
                        return false;
                    }
                    if (DamageDiceSides != other.DamageDiceSides)
                    {
                        return false;
                    }
                    break;

                default:
                    if (!IsKnown() || !other.IsKnown())
                    {
                        return false;
                    }
                    break;
            }
            if (RandartFlags1.Value != other.RandartFlags1.Value || RandartFlags2.Value != other.RandartFlags2.Value ||
                RandartFlags3.Value != other.RandartFlags3.Value)
            {
                return false;
            }
            if (!IdentifyFlags.Matches(other.IdentifyFlags, Constants.IdentCursed))
            {
                return false;
            }
            if (!IdentifyFlags.Matches(other.IdentifyFlags, Constants.IdentBroken))
            {
                return false;
            }
            if (!string.IsNullOrEmpty(Inscription) && !string.IsNullOrEmpty(other.Inscription) &&
                Inscription != other.Inscription)
            {
                return false;
            }
            if (Discount != other.Discount)
            {
                return false;
            }
            return total < Constants.MaxStackSize;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="includeCountPrefix">Specify true, to prefix the description with the number of items (e.g. 5 Brown Dragon Scale Mails);
        /// false, otherwise (e.g. Brown Dragon Scale Mails).  When false, the item will still be pluralized (e.g. stole one of your Brown Dragon Scale Mails).</param>
        /// <param name="mode"></param>
        /// <returns></returns>
        private string NewDescription(bool includeCountPrefix, int mode)
        {
            FlagSet f1 = new FlagSet();
            FlagSet f2 = new FlagSet();
            FlagSet f3 = new FlagSet();
            GetMergedFlags(f1, f2, f3);
            if (ItemType == null || BaseCategory == null)
            {
                return "(nothing)";
            }
            string basenm = BaseCategory.GetDescription(this, includeCountPrefix);
            if (IsKnown())
            {
                if (!string.IsNullOrEmpty(RandartName))
                {
                    basenm += ' ';
                    basenm += RandartName;
                }
                else if (FixedArtifactIndex != 0)
                {
                    FixedArtifact aPtr = Profile.Instance.FixedArtifacts[FixedArtifactIndex];
                    basenm += ' ';
                    basenm += aPtr.Name;
                }
                else if (RareItemTypeIndex != Enumerations.RareItemType.None)
                {
                    RareItemType ePtr = Profile.Instance.RareItemTypes[RareItemTypeIndex];
                    basenm += ' ';
                    basenm += ePtr.Name;
                }
            }
            if (mode < 1)
            {
                return basenm;
            }

            if (Category == ItemCategory.Chest)
            {
                if (!IsKnown())
                {
                }
                else if (TypeSpecificValue == 0)
                {
                    basenm += " (empty)";
                }
                else if (TypeSpecificValue < 0)
                {
                    if (GlobalData.ChestTraps[-TypeSpecificValue] != 0)
                    {
                        basenm += " (disarmed)";
                    }
                    else
                    {
                        basenm += " (unlocked)";
                    }
                }
                else
                {
                    switch (GlobalData.ChestTraps[TypeSpecificValue])
                    {
                        case 0:
                            {
                                basenm += " (Locked)";
                                break;
                            }
                        case ChestTrap.ChestLoseStr:
                            {
                                basenm += " (Poison Needle)";
                                break;
                            }
                        case ChestTrap.ChestLoseCon:
                            {
                                basenm += " (Poison Needle)";
                                break;
                            }
                        case ChestTrap.ChestPoison:
                            {
                                basenm += " (Gas Trap)";
                                break;
                            }
                        case ChestTrap.ChestParalyze:
                            {
                                basenm += " (Gas Trap)";
                                break;
                            }
                        case ChestTrap.ChestExplode:
                            {
                                basenm += " (Explosion Device)";
                                break;
                            }
                        case ChestTrap.ChestSummon:
                            {
                                basenm += " (Summoning Runes)";
                                break;
                            }
                        default:
                            {
                                basenm += " (Multiple Traps)";
                                break;
                            }
                    }
                }
            }
            switch (Category)
            {
                case ItemCategory.Shot:
                case ItemCategory.Bolt:
                case ItemCategory.Arrow:
                case ItemCategory.Hafted:
                case ItemCategory.Polearm:
                case ItemCategory.Sword:
                case ItemCategory.Digging:
                    basenm += $" ({DamageDice}d{DamageDiceSides})";
                    break;

                case ItemCategory.Bow:
                    int power = ItemSubCategory % 10;
                    if (f3.IsSet(ItemFlag3.XtraMight))
                    {
                        power++;
                    }
                    basenm += $" (x{power})";
                    break;
            }
            if (IsKnown())
            {
                if (f3.IsSet(ItemFlag3.ShowMods) || (BonusToHit != 0 && BonusDamage != 0) || Category == ItemCategory.Shot
                    || Category == ItemCategory.Bolt || Category == ItemCategory.Arrow || Category == ItemCategory.Bow 
                    || Category == ItemCategory.Hafted || Category == ItemCategory.Polearm || Category == ItemCategory.Sword || Category == ItemCategory.Digging)
                {
                    basenm += $" ({GetSignedValue(BonusToHit)},{GetSignedValue(BonusDamage)})";
                }
                else if (BonusToHit != 0)
                {
                    basenm += $" ({GetSignedValue(BonusToHit)})";
                }
                else if (BonusDamage != 0)
                {
                    basenm += $" ({GetSignedValue(BonusDamage)})";
                }

                if (BaseArmourClass != 0 
                    || Category == ItemCategory.Boots 
                    || Category == ItemCategory.Gloves
                    || Category == ItemCategory.Cloak
                    || Category == ItemCategory.Crown
                    || Category == ItemCategory.Helm
                    || Category == ItemCategory.Shield
                    || Category == ItemCategory.SoftArmor
                    || Category == ItemCategory.HardArmor
                    || Category == ItemCategory.DragArmor)
                {
                    // Add base armour class for all types of armour and when the base armour class is greater than zero.
                    basenm += $" [{BaseArmourClass},{GetSignedValue(BonusArmourClass)}]";
                }
                else if (BonusArmourClass != 0)
                {
                    // This is not armour, only show bonus armour class, if it is not zero and we know about it.
                    basenm += $" [{GetSignedValue(BonusArmourClass)}]";
                }
            }
            else if (Category == ItemCategory.Boots
                    || Category == ItemCategory.Gloves
                    || Category == ItemCategory.Cloak
                    || Category == ItemCategory.Crown
                    || Category == ItemCategory.Helm
                    || Category == ItemCategory.Shield
                    || Category == ItemCategory.SoftArmor
                    || Category == ItemCategory.HardArmor
                    || Category == ItemCategory.DragArmor)
            {
                basenm += $" [{BaseArmourClass}]";
            }
            if (mode < 2)
            {
                return basenm;
            }
            if (IsKnown() && (Category == ItemCategory.Staff || Category == ItemCategory.Wand))
            {
                basenm += $" ({TypeSpecificValue} {Pluralize("charge", TypeSpecificValue)})";
            }
            else if (IsKnown() && Category == ItemCategory.Rod)
            {
                if (TypeSpecificValue != 0)
                {
                    basenm += " (charging)";
                }
            }
            else if (Category == ItemCategory.Light &&
                     (ItemSubCategory == Enumerations.LightType.Torch || ItemSubCategory == Enumerations.LightType.Lantern))
            {
                basenm += $" (with {TypeSpecificValue} turns of light)";
            }
            if (IsKnown() && f1.IsSet(ItemFlag1.PvalMask))
            {
                basenm += $" ({GetSignedValue(TypeSpecificValue)}";
                if (f3.IsSet(ItemFlag3.HideType))
                {
                }
                else if (f1.IsSet(ItemFlag1.Speed))
                {
                    basenm += " speed";
                }
                else if (f1.IsSet(ItemFlag1.Blows))
                {
                    if (TypeSpecificValue > 1)
                    {
                        basenm += " attacks";
                    }
                    else
                    {
                        basenm += " attack";
                    }
                }
                else if (f1.IsSet(ItemFlag1.Stealth))
                {
                    basenm += " stealth";
                }
                else if (f1.IsSet(ItemFlag1.Search))
                {
                    basenm += " searching";
                }
                else if (f1.IsSet(ItemFlag1.Infra))
                {
                    basenm += " infravision";
                }
                else if (f1.IsSet(ItemFlag1.Tunnel))
                {
                }
                basenm += ")";
            }
            if (IsKnown() && RechargeTimeLeft != 0)
            {
                basenm += " (charging)";
            }
            if (mode < 3)
            {
                return basenm;
            }
            string tmpVal2 = "";
            if (!string.IsNullOrEmpty(Inscription))
            {
                tmpVal2 = Inscription;
            }
            else if (IsCursed() && (IsKnown() || IdentifyFlags.IsSet(Constants.IdentSense)))
            {
                tmpVal2 = "cursed";
            }
            else if (!IsKnown() && IdentifyFlags.IsSet(Constants.IdentEmpty))
            {
                tmpVal2 = "empty";
            }
            else if (!IsFlavourAware() && IsTried())
            {
                tmpVal2 = "tried";
            }
            else if (Discount != 0)
            {
                tmpVal2 = Discount.ToString();
                tmpVal2 += "% off";
            }
            if (!string.IsNullOrEmpty(tmpVal2))
            {
                basenm += $" {{{tmpVal2}}}";
            }
            if (basenm.Length > 75)
            {
                basenm = basenm.Substring(0, 75);
            }
            return basenm;
        }

        private string OriginalDescription(bool pref, int mode)
        {
            bool aware = false;
            bool known = false;
            bool appendName = false;
            bool showWeapon = false;
            bool showArmour = false;
            string s;
            const char p1 = '(';
            const char p2 = ')';
            const char b1 = '[';
            const char b2 = ']';
            const char c1 = '{';
            const char c2 = '}';
            const string tmpVal = "";
            string tmpVal2 = "";
            FlagSet f1 = new FlagSet();
            FlagSet f2 = new FlagSet();
            FlagSet f3 = new FlagSet();
            ItemType kPtr = ItemType;
            if (kPtr == null)
            {
                return "(nothing)";
            }
            GetMergedFlags(f1, f2, f3);
            if (IsFlavourAware())
            {
                aware = true;
            }
            if (IsKnown())
            {
                known = true;
            }
            int indexx = ItemSubCategory;
            string basenm = kPtr.Name;
            string modstr = "";
            switch (Category)
            {
                case ItemCategory.Skeleton:
                case ItemCategory.Bottle:
                case ItemCategory.Junk:
                case ItemCategory.Spike:
                case ItemCategory.Flask:
                case ItemCategory.Chest:
                    break;

                case ItemCategory.Shot:
                case ItemCategory.Bolt:
                case ItemCategory.Arrow:
                case ItemCategory.Bow:
                case ItemCategory.Hafted:
                case ItemCategory.Polearm:
                case ItemCategory.Sword:
                case ItemCategory.Digging:
                    showWeapon = true;
                    break;

                case ItemCategory.Boots:
                case ItemCategory.Gloves:
                case ItemCategory.Cloak:
                case ItemCategory.Crown:
                case ItemCategory.Helm:
                case ItemCategory.Shield:
                case ItemCategory.SoftArmor:
                case ItemCategory.HardArmor:
                case ItemCategory.DragArmor:
                    showArmour = true;
                    break;

                case ItemCategory.Light:
                    break;

                case ItemCategory.Amulet:
                    if (IsFixedArtifact() && aware)
                    {
                        break;
                    }
                    modstr = SaveGame.Instance.AmuletFlavours[indexx].Name;
                    if (aware)
                    {
                        appendName = true;
                    }
                    basenm = IdentifyFlags.IsSet(Constants.IdentStoreb) ? "& Amulet~" : "& # Amulet~";
                    break;

                case ItemCategory.Ring:
                    if (IsFixedArtifact() && aware)
                    {
                        break;
                    }
                    modstr = SaveGame.Instance.RingFlavours[indexx].Name;
                    if (aware)
                    {
                        appendName = true;
                    }
                    basenm = IdentifyFlags.IsSet(Constants.IdentStoreb) ? "& Ring~" : "& # Ring~";
                    if (!aware && ItemSubCategory == Enumerations.RingType.Power)
                    {
                        modstr = "Plain Gold";
                    }
                    break;

                case ItemCategory.Staff:
                    modstr = SaveGame.Instance.StaffFlavours[indexx].Name;
                    if (aware)
                    {
                        appendName = true;
                    }
                    basenm = IdentifyFlags.IsSet(Constants.IdentStoreb) ? "& Staff~" : "& # Staff~";
                    break;

                case ItemCategory.Wand:
                    modstr = SaveGame.Instance.WandFlavours[indexx].Name;
                    if (aware)
                    {
                        appendName = true;
                    }
                    basenm = IdentifyFlags.IsSet(Constants.IdentStoreb) ? "& Wand~" : "& # Wand~";
                    break;

                case ItemCategory.Rod:
                    modstr = SaveGame.Instance.RodFlavours[indexx].Name;
                    if (aware)
                    {
                        appendName = true;
                    }
                    basenm = IdentifyFlags.IsSet(Constants.IdentStoreb) ? "& Rod~" : "& # Rod~";
                    break;

                case ItemCategory.Scroll:
                    modstr = SaveGame.Instance.ScrollFlavours[indexx].Name;
                    if (aware)
                    {
                        appendName = true;
                    }
                    basenm = IdentifyFlags.IsSet(Constants.IdentStoreb) ? "& Scroll~" : "& Scroll~ titled \"#\"";
                    break;

                case ItemCategory.Potion:
                    modstr = SaveGame.Instance.PotionFlavours[indexx].Name;
                    if (aware)
                    {
                        appendName = true;
                    }
                    basenm = IdentifyFlags.IsSet(Constants.IdentStoreb) ? "& Potion~" : "& # Potion~";
                    break;

                case ItemCategory.Food:
                    if (ItemSubCategory >= Enumerations.FoodType.MinFood)
                    {
                        break;
                    }
                    modstr = SaveGame.Instance.MushroomFlavours[indexx].Name;
                    if (aware)
                    {
                        appendName = true;
                    }
                    basenm = IdentifyFlags.IsSet(Constants.IdentStoreb) ? "& Mushroom~" : "& # Mushroom~";
                    break;

                case ItemCategory.LifeBook:
                    modstr = basenm;
                    basenm = SaveGame.Instance.Player.Spellcasting.Type == CastingType.Divine
                        ? "& Book~ of Life Magic #"
                        : "& Life Spellbook~ #";
                    break;

                case ItemCategory.SorceryBook:
                    modstr = basenm;
                    basenm = SaveGame.Instance.Player.Spellcasting.Type == CastingType.Divine
                        ? "& Book~ of Sorcery #"
                        : "& Sorcery Spellbook~ #";
                    break;

                case ItemCategory.NatureBook:
                    modstr = basenm;
                    basenm = SaveGame.Instance.Player.Spellcasting.Type == CastingType.Divine
                        ? "& Book~ of Nature Magic #"
                        : "& Nature Spellbook~ #";
                    break;

                case ItemCategory.ChaosBook:
                    modstr = basenm;
                    basenm = SaveGame.Instance.Player.Spellcasting.Type == CastingType.Divine
                        ? "& Book~ of Chaos Magic #"
                        : "& Chaos Spellbook~ #";
                    break;

                case ItemCategory.DeathBook:
                    modstr = basenm;
                    basenm = SaveGame.Instance.Player.Spellcasting.Type == CastingType.Divine
                        ? "& Book~ of Death Magic #"
                        : "& Death Spellbook~ #";
                    break;

                case ItemCategory.TarotBook:
                    modstr = basenm;
                    basenm = SaveGame.Instance.Player.Spellcasting.Type == CastingType.Divine
                        ? "& Book~ of Tarot Magic #"
                        : "& Tarot Spellbook~ #";
                    break;

                case ItemCategory.FolkBook:
                    modstr = basenm;
                    basenm = SaveGame.Instance.Player.Spellcasting.Type == CastingType.Divine
                        ? "& Book~ of Folk Magic #"
                        : "& Folk Spellbook~ #";
                    break;

                case ItemCategory.CorporealBook:
                    modstr = basenm;
                    basenm = SaveGame.Instance.Player.Spellcasting.Type == CastingType.Divine
                        ? "& Book~ of Corporeal Magic #"
                        : "& Corporeal Spellbook~ #";
                    break;

                case ItemCategory.Gold:
                    return basenm;

                default:
                    return "(nothing)";
            }
            string t = tmpVal;
            if (basenm[0] == '&')
            {
                s = basenm.Substring(2);
                if (!pref)
                {
                }
                else if (Count <= 0)
                {
                    t += "no more ";
                }
                else if (Count > 1)
                {
                    t += Count;
                    t += ' ';
                }
                else if (known && (IsFixedArtifact() || !string.IsNullOrEmpty(RandartName)))
                {
                    t += "The ";
                }
                else if (s.StartsWith("#") && modstr[0].IsVowel())
                {
                    t += "an ";
                }
                else if (s[0].IsVowel())
                {
                    t += "an ";
                }
                else
                {
                    t += "a ";
                }
            }
            else
            {
                s = basenm;
                if (!pref)
                {
                }
                else if (Count <= 0)
                {
                    t += "no more ";
                }
                else if (Count > 1)
                {
                    t += Count;
                    t += ' ';
                }
                else if (known && (IsFixedArtifact() || !string.IsNullOrEmpty(RandartName)))
                {
                    t += "The ";
                }
            }
            foreach (char ch in s)
            {
                if (ch == '~')
                {
                    if (Count != 1)
                    {
                        char k = t[t.Length - 1];
                        if (k == 's' || k == 'h')
                        {
                            t += 'e';
                        }
                        t += 's';
                    }
                }
                else if (ch == '#')
                {
                    t += modstr;
                }
                else
                {
                    t += ch;
                }
            }
            if (appendName)
            {
                t += " of ";
                t += kPtr.Name;
            }
            if (known)
            {
                if (!string.IsNullOrEmpty(RandartName))
                {
                    t += ' ';
                    t += RandartName;
                }
                else if (FixedArtifactIndex != 0)
                {
                    FixedArtifact aPtr = Profile.Instance.FixedArtifacts[FixedArtifactIndex];
                    t += ' ';
                    t += aPtr.Name;
                }
                else if (RareItemTypeIndex != Enumerations.RareItemType.None)
                {
                    RareItemType ePtr = Profile.Instance.RareItemTypes[RareItemTypeIndex];
                    t += ' ';
                    t += ePtr.Name;
                }
            }
            if (mode < 1)
            {
                return t;
            }
            if (Category == ItemCategory.Chest)
            {
                if (!known)
                {
                }
                else if (TypeSpecificValue == 0)
                {
                    t += " (empty)";
                }
                else if (TypeSpecificValue < 0)
                {
                    if (GlobalData.ChestTraps[-TypeSpecificValue] != 0)
                    {
                        t += " (disarmed)";
                    }
                    else
                    {
                        t += " (unlocked)";
                    }
                }
                else
                {
                    switch (GlobalData.ChestTraps[TypeSpecificValue])
                    {
                        case 0:
                            {
                                t += " (Locked)";
                                break;
                            }
                        case ChestTrap.ChestLoseStr:
                            {
                                t += " (Poison Needle)";
                                break;
                            }
                        case ChestTrap.ChestLoseCon:
                            {
                                t += " (Poison Needle)";
                                break;
                            }
                        case ChestTrap.ChestPoison:
                            {
                                t += " (Gas Trap)";
                                break;
                            }
                        case ChestTrap.ChestParalyze:
                            {
                                t += " (Gas Trap)";
                                break;
                            }
                        case ChestTrap.ChestExplode:
                            {
                                t += " (Explosion Device)";
                                break;
                            }
                        case ChestTrap.ChestSummon:
                            {
                                t += " (Summoning Runes)";
                                break;
                            }
                        default:
                            {
                                t += " (Multiple Traps)";
                                break;
                            }
                    }
                }
            }
            if (f3.IsSet(ItemFlag3.ShowMods))
            {
                showWeapon = true;
            }
            if (BonusToHit != 0 && BonusDamage != 0)
            {
                showWeapon = true;
            }
            if (BaseArmourClass != 0)
            {
                showArmour = true;
            }
            switch (Category)
            {
                case ItemCategory.Shot:
                case ItemCategory.Bolt:
                case ItemCategory.Arrow:
                case ItemCategory.Hafted:
                case ItemCategory.Polearm:
                case ItemCategory.Sword:
                case ItemCategory.Digging:
                    t += ' ';
                    t += p1;
                    t += DamageDice;
                    t += 'd';
                    t += DamageDiceSides;
                    t += p2;
                    break;

                case ItemCategory.Bow:
                    int power = ItemSubCategory % 10;
                    if (f3.IsSet(ItemFlag3.XtraMight))
                    {
                        power++;
                    }
                    t += ' ';
                    t += p1;
                    t += 'x';
                    t += power;
                    t += p2;
                    break;
            }
            if (known)
            {
                if (showWeapon)
                {
                    t += ' ';
                    t += p1;
                    if (BonusToHit >= 0)
                    {
                        t += "+";
                    }
                    t += BonusToHit;
                    t += ',';
                    if (BonusDamage >= 0)
                    {
                        t += "+";
                    }
                    t += BonusDamage;
                    t += p2;
                }
                else if (BonusToHit != 0)
                {
                    t += ' ';
                    t += p1;
                    if (BonusToHit >= 0)
                    {
                        t += "+";
                    }
                    t += BonusToHit;
                    t += p2;
                }
                else if (BonusDamage != 0)
                {
                    t += ' ';
                    t += p1;
                    if (BonusDamage >= 0)
                    {
                        t += "+";
                    }
                    t += BonusDamage;
                    t += p2;
                }
            }
            if (known)
            {
                if (showArmour)
                {
                    t += ' ';
                    t += b1;
                    t += BaseArmourClass;
                    t += ',';
                    if (BonusArmourClass >= 0)
                    {
                        t += "+";
                    }
                    t += BonusArmourClass;
                    t += b2;
                }
                else if (BonusArmourClass != 0)
                {
                    t += ' ';
                    t += b1;
                    if (BonusArmourClass >= 0)
                    {
                        t += "+";
                    }
                    t += BonusArmourClass;
                    t += b2;
                }
            }
            else if (showArmour)
            {
                t += ' ';
                t += b1;
                t += BaseArmourClass;
                t += b2;
            }
            if (mode < 2)
            {
                return t;
            }
            if (known && (Category == ItemCategory.Staff || Category == ItemCategory.Wand))
            {
                t += ' ';
                t += p1;
                t += TypeSpecificValue;
                t += " charge";
                if (TypeSpecificValue != 1)
                {
                    t += 's';
                }
                t += p2;
            }
            else if (known && Category == ItemCategory.Rod)
            {
                if (TypeSpecificValue != 0)
                {
                    t += " (charging)";
                }
            }
            else if (Category == ItemCategory.Light &&
                     (ItemSubCategory == Enumerations.LightType.Torch || ItemSubCategory == Enumerations.LightType.Lantern))
            {
                t += " (with ";
                t += TypeSpecificValue;
                t += " turns of light)";
            }
            if (known && f1.IsSet(ItemFlag1.PvalMask))
            {
                t += ' ';
                t += p1;
                if (TypeSpecificValue >= 0)
                {
                    t += "+";
                }
                t += TypeSpecificValue;
                if (f3.IsSet(ItemFlag3.HideType))
                {
                }
                else if (f1.IsSet(ItemFlag1.Speed))
                {
                    t += " speed";
                }
                else if (f1.IsSet(ItemFlag1.Blows))
                {
                    if (TypeSpecificValue > 1)
                    {
                        t += " attacks";
                    }
                    else
                    {
                        t += " attack";
                    }
                }
                else if (f1.IsSet(ItemFlag1.Stealth))
                {
                    t += " stealth";
                }
                else if (f1.IsSet(ItemFlag1.Search))
                {
                    t += " searching";
                }
                else if (f1.IsSet(ItemFlag1.Infra))
                {
                    t += " infravision";
                }
                else if (f1.IsSet(ItemFlag1.Tunnel))
                {
                }
                t += p2;
            }
            if (known && RechargeTimeLeft != 0)
            {
                t += " (charging)";
            }
            if (mode < 3)
            {
                return t;
            }
            if (!string.IsNullOrEmpty(Inscription))
            {
                tmpVal2 = Inscription;
            }
            else if (IsCursed() && (known || IdentifyFlags.IsSet(Constants.IdentSense)))
            {
                tmpVal2 = "cursed";
            }
            else if (!known && IdentifyFlags.IsSet(Constants.IdentEmpty))
            {
                tmpVal2 = "empty";
            }
            else if (!aware && IsTried())
            {
                tmpVal2 = "tried";
            }
            else if (Discount != 0)
            {
                tmpVal2 = Discount.ToString();
                tmpVal2 += "% off";
            }
            if (!string.IsNullOrEmpty(tmpVal2))
            {
                t += ' ';
                t += c1;
                t += tmpVal2;
                t += c2;
            }
            if (t.Length > 75)
            {
                t = t.Substring(0, 75);
            }
            return t;
        }

        public string Description(bool pref, int mode)
        {
            string originalDescription = OriginalDescription(pref, mode);
            string newDescription = NewDescription(pref, mode);
            if (originalDescription == newDescription)
            {
                //Profile.Instance.MsgPrint("Inventory descriptions confirmed.");
            }
            else
            {
                Profile.Instance.MsgPrint("DESCRIPTION FAILED!");
            }
            return originalDescription;
        }

        public int FlagBasedCost(int plusses)
        {
            int total = 0;
            FlagSet f1 = new FlagSet();
            FlagSet f2 = new FlagSet();
            FlagSet f3 = new FlagSet();
            GetMergedFlags(f1, f2, f3);
            if (f1.IsSet(ItemFlag1.Str))
            {
                total += 1000 * plusses;
            }
            if (f1.IsSet(ItemFlag1.Int))
            {
                total += 1000 * plusses;
            }
            if (f1.IsSet(ItemFlag1.Wis))
            {
                total += 1000 * plusses;
            }
            if (f1.IsSet(ItemFlag1.Dex))
            {
                total += 1000 * plusses;
            }
            if (f1.IsSet(ItemFlag1.Con))
            {
                total += 1000 * plusses;
            }
            if (f1.IsSet(ItemFlag1.Cha))
            {
                total += 250 * plusses;
            }
            if (f1.IsSet(ItemFlag1.Chaotic))
            {
                total += 10000;
            }
            if (f1.IsSet(ItemFlag1.Vampiric))
            {
                total += 13000;
            }
            if (f1.IsSet(ItemFlag1.Stealth))
            {
                total += 250 * plusses;
            }
            if (f1.IsSet(ItemFlag1.Search))
            {
                total += 100 * plusses;
            }
            if (f1.IsSet(ItemFlag1.Infra))
            {
                total += 150 * plusses;
            }
            if (f1.IsSet(ItemFlag1.Tunnel))
            {
                total += 175 * plusses;
            }
            if (f1.IsSet(ItemFlag1.Speed) && plusses > 0)
            {
                total += 30000 * plusses;
            }
            if (f1.IsSet(ItemFlag1.Blows) && plusses > 0)
            {
                total += 2000 * plusses;
            }
            if (f1.IsSet(ItemFlag3.AntiTheft))
            {
                total += 0;
            }
            if (f1.IsSet(ItemFlag1.Xxx2))
            {
                total += 0;
            }
            if (f1.IsSet(ItemFlag1.SlayAnimal))
            {
                total += 3500;
            }
            if (f1.IsSet(ItemFlag1.SlayEvil))
            {
                total += 4500;
            }
            if (f1.IsSet(ItemFlag1.SlayUndead))
            {
                total += 3500;
            }
            if (f1.IsSet(ItemFlag1.SlayDemon))
            {
                total += 3500;
            }
            if (f1.IsSet(ItemFlag1.SlayOrc))
            {
                total += 3000;
            }
            if (f1.IsSet(ItemFlag1.SlayTroll))
            {
                total += 3500;
            }
            if (f1.IsSet(ItemFlag1.SlayGiant))
            {
                total += 3500;
            }
            if (f1.IsSet(ItemFlag1.SlayDragon))
            {
                total += 3500;
            }
            if (f1.IsSet(ItemFlag1.KillDragon))
            {
                total += 5500;
            }
            if (f1.IsSet(ItemFlag1.Vorpal))
            {
                total += 5000;
            }
            if (f1.IsSet(ItemFlag1.Impact))
            {
                total += 5000;
            }
            if (f1.IsSet(ItemFlag1.BrandPois))
            {
                total += 7500;
            }
            if (f1.IsSet(ItemFlag1.BrandAcid))
            {
                total += 7500;
            }
            if (f1.IsSet(ItemFlag1.BrandElec))
            {
                total += 7500;
            }
            if (f1.IsSet(ItemFlag1.BrandFire))
            {
                total += 5000;
            }
            if (f1.IsSet(ItemFlag1.BrandCold))
            {
                total += 5000;
            }
            if (f2.IsSet(ItemFlag2.SustStr))
            {
                total += 850;
            }
            if (f2.IsSet(ItemFlag2.SustInt))
            {
                total += 850;
            }
            if (f2.IsSet(ItemFlag2.SustWis))
            {
                total += 850;
            }
            if (f2.IsSet(ItemFlag2.SustDex))
            {
                total += 850;
            }
            if (f2.IsSet(ItemFlag2.SustCon))
            {
                total += 850;
            }
            if (f2.IsSet(ItemFlag2.SustCha))
            {
                total += 250;
            }
            if (f2.IsSet(ItemFlag2.Xxx1))
            {
                total += 0;
            }
            if (f2.IsSet(ItemFlag2.Xxx2))
            {
                total += 0;
            }
            if (f2.IsSet(ItemFlag2.ImAcid))
            {
                total += 10000;
            }
            if (f2.IsSet(ItemFlag2.ImElec))
            {
                total += 10000;
            }
            if (f2.IsSet(ItemFlag2.ImFire))
            {
                total += 10000;
            }
            if (f2.IsSet(ItemFlag2.ImCold))
            {
                total += 10000;
            }
            if (f2.IsSet(ItemFlag2.Xxx3))
            {
                total += 0;
            }
            if (f2.IsSet(ItemFlag2.Reflect))
            {
                total += 10000;
            }
            if (f2.IsSet(ItemFlag2.FreeAct))
            {
                total += 4500;
            }
            if (f2.IsSet(ItemFlag2.HoldLife))
            {
                total += 8500;
            }
            if (f2.IsSet(ItemFlag2.ResAcid))
            {
                total += 1250;
            }
            if (f2.IsSet(ItemFlag2.ResElec))
            {
                total += 1250;
            }
            if (f2.IsSet(ItemFlag2.ResFire))
            {
                total += 1250;
            }
            if (f2.IsSet(ItemFlag2.ResCold))
            {
                total += 1250;
            }
            if (f2.IsSet(ItemFlag2.ResPois))
            {
                total += 2500;
            }
            if (f2.IsSet(ItemFlag2.ResFear))
            {
                total += 2500;
            }
            if (f2.IsSet(ItemFlag2.ResLight))
            {
                total += 1750;
            }
            if (f2.IsSet(ItemFlag2.ResDark))
            {
                total += 1750;
            }
            if (f2.IsSet(ItemFlag2.ResBlind))
            {
                total += 2000;
            }
            if (f2.IsSet(ItemFlag2.ResConf))
            {
                total += 2000;
            }
            if (f2.IsSet(ItemFlag2.ResSound))
            {
                total += 2000;
            }
            if (f2.IsSet(ItemFlag2.ResShards))
            {
                total += 2000;
            }
            if (f2.IsSet(ItemFlag2.ResNether))
            {
                total += 2000;
            }
            if (f2.IsSet(ItemFlag2.ResNexus))
            {
                total += 2000;
            }
            if (f2.IsSet(ItemFlag2.ResChaos))
            {
                total += 2000;
            }
            if (f2.IsSet(ItemFlag2.ResDisen))
            {
                total += 10000;
            }
            if (f3.IsSet(ItemFlag3.ShFire))
            {
                total += 5000;
            }
            if (f3.IsSet(ItemFlag3.ShElec))
            {
                total += 5000;
            }
            if (f3.IsSet(ItemFlag3.Xxx3))
            {
                total += 0;
            }
            if (f3.IsSet(ItemFlag1.Xxx1))
            {
                total += 0;
            }
            if (f3.IsSet(ItemFlag3.NoTele))
            {
                total += 2500;
            }
            if (f3.IsSet(ItemFlag3.NoMagic))
            {
                total += 2500;
            }
            if (f3.IsSet(ItemFlag3.Wraith))
            {
                total += 250000;
            }
            if (f3.IsSet(ItemFlag3.DreadCurse))
            {
                total -= 15000;
            }
            if (f3.IsSet(ItemFlag3.EasyKnow))
            {
                total += 0;
            }
            if (f3.IsSet(ItemFlag3.HideType))
            {
                total += 0;
            }
            if (f3.IsSet(ItemFlag3.ShowMods))
            {
                total += 0;
            }
            if (f3.IsSet(ItemFlag3.InstaArt))
            {
                total += 0;
            }
            if (f3.IsSet(ItemFlag3.Feather))
            {
                total += 1250;
            }
            if (f3.IsSet(ItemFlag3.Lightsource))
            {
                total += 1250;
            }
            if (f3.IsSet(ItemFlag3.SeeInvis))
            {
                total += 2000;
            }
            if (f3.IsSet(ItemFlag3.Telepathy))
            {
                total += 12500;
            }
            if (f3.IsSet(ItemFlag3.SlowDigest))
            {
                total += 750;
            }
            if (f3.IsSet(ItemFlag3.Regen))
            {
                total += 2500;
            }
            if (f3.IsSet(ItemFlag3.XtraMight))
            {
                total += 2250;
            }
            if (f3.IsSet(ItemFlag3.XtraShots))
            {
                total += 10000;
            }
            if (f3.IsSet(ItemFlag3.IgnoreAcid))
            {
                total += 100;
            }
            if (f3.IsSet(ItemFlag3.IgnoreElec))
            {
                total += 100;
            }
            if (f3.IsSet(ItemFlag3.IgnoreFire))
            {
                total += 100;
            }
            if (f3.IsSet(ItemFlag3.IgnoreCold))
            {
                total += 100;
            }
            if (f3.IsSet(ItemFlag3.Activate))
            {
                total += 100;
            }
            if (f3.IsSet(ItemFlag3.DrainExp))
            {
                total -= 12500;
            }
            if (f3.IsSet(ItemFlag3.Teleport))
            {
                if (IdentifyFlags.IsSet(Constants.IdentCursed))
                {
                    total -= 7500;
                }
                else
                {
                    total += 250;
                }
            }
            if (f3.IsSet(ItemFlag3.Aggravate))
            {
                total -= 10000;
            }
            if (f3.IsSet(ItemFlag3.Blessed))
            {
                total += 750;
            }
            if (f3.IsSet(ItemFlag3.Cursed))
            {
                total -= 5000;
            }
            if (f3.IsSet(ItemFlag3.HeavyCurse))
            {
                total -= 12500;
            }
            if (f3.IsSet(ItemFlag3.PermaCurse))
            {
                total -= 15000;
            }
            if (!string.IsNullOrEmpty(RandartName) && RandartFlags3.IsSet(ItemFlag3.Activate))
            {
                total += BonusPowerSubType.Value;
            }
            return total;
        }

        public string GetDetailedFeeling()
        {
            if (IsFixedArtifact() || !string.IsNullOrEmpty(RandartName))
            {
                if (IsCursed() || IsBroken())
                {
                    return "terrible";
                }
                return "special";
            }
            if (IsRare())
            {
                if (IsCursed() || IsBroken())
                {
                    return "worthless";
                }
                return "excellent";
            }
            if (IsCursed())
            {
                return "cursed";
            }
            if (IsBroken())
            {
                return "broken";
            }
            if (BonusArmourClass > 0)
            {
                return "good";
            }
            if (BonusToHit + BonusDamage > 0)
            {
                return "good";
            }
            return "average";
        }

        public void GetMergedFlags(FlagSet f1, FlagSet f2, FlagSet f3)
        {
            f1.Clear();
            f2.Clear();
            f3.Clear();
            if (ItemType == null)
            {
                return;
            }
            f1.Set(ItemType.Flags1);
            f2.Set(ItemType.Flags2);
            f3.Set(ItemType.Flags3);
            if (FixedArtifactIndex != 0)
            {
                FixedArtifact aPtr = Profile.Instance.FixedArtifacts[FixedArtifactIndex];
                f1.Set(aPtr.Flags1);
                f2.Set(aPtr.Flags2);
                f3.Set(aPtr.Flags3);
            }
            if (RareItemTypeIndex != Enumerations.RareItemType.None)
            {
                RareItemType ePtr = Profile.Instance.RareItemTypes[RareItemTypeIndex];
                f1.Set(ePtr.Flags1);
                f2.Set(ePtr.Flags2);
                f3.Set(ePtr.Flags3);
            }
            if (RandartFlags1.IsSet() || RandartFlags2.IsSet() || RandartFlags3.IsSet())
            {
                f1.Set(RandartFlags1);
                f2.Set(RandartFlags2);
                f3.Set(RandartFlags3);
            }
            if (!string.IsNullOrEmpty(RandartName))
            {
                switch (BonusPowerType)
                {
                    case Enumerations.RareItemType.SpecialSustain:
                        {
                            f2.Set(BonusPowerSubType.SpecialSustainFlag);
                            break;
                        }
                    case Enumerations.RareItemType.SpecialPower:
                        {
                            f2.Set(BonusPowerSubType.SpecialPowerFlag);
                            break;
                        }
                    case Enumerations.RareItemType.SpecialAbility:
                        {
                            f2.Set(BonusPowerSubType.SpecialAbilityFlag);
                            break;
                        }
                }
            }
        }

        public string GetVagueFeeling()
        {
            if (IsCursed())
            {
                return "cursed";
            }
            if (IsBroken())
            {
                return "broken";
            }
            if (IsFixedArtifact() || !string.IsNullOrEmpty(RandartName))
            {
                return "special";
            }
            if (IsRare())
            {
                return "good";
            }
            if (BonusArmourClass > 0)
            {
                return "good";
            }
            if (BonusToHit + BonusDamage > 0)
            {
                return "good";
            }
            return null;
        }

        public bool HatesAcid()
        {
            switch (Category)
            {
                case ItemCategory.Arrow:
                case ItemCategory.Bolt:
                case ItemCategory.Bow:
                case ItemCategory.Sword:
                case ItemCategory.Hafted:
                case ItemCategory.Polearm:
                case ItemCategory.Helm:
                case ItemCategory.Crown:
                case ItemCategory.Shield:
                case ItemCategory.Boots:
                case ItemCategory.Gloves:
                case ItemCategory.Cloak:
                case ItemCategory.SoftArmor:
                case ItemCategory.HardArmor:
                case ItemCategory.DragArmor:
                    {
                        return true;
                    }
                case ItemCategory.Staff:
                case ItemCategory.Scroll:
                    {
                        return true;
                    }
                case ItemCategory.Chest:
                    {
                        return true;
                    }
                case ItemCategory.Skeleton:
                case ItemCategory.Bottle:
                case ItemCategory.Junk:
                    {
                        return true;
                    }
            }
            return false;
        }

        public bool HatesCold()
        {
            switch (Category)
            {
                case ItemCategory.Potion:
                case ItemCategory.Flask:
                case ItemCategory.Bottle:
                    {
                        return true;
                    }
            }
            return false;
        }

        public bool HatesElec()
        {
            switch (Category)
            {
                case ItemCategory.Ring:
                case ItemCategory.Wand:
                    {
                        return true;
                    }
            }
            return false;
        }

        public bool HatesFire()
        {
            switch (Category)
            {
                case ItemCategory.Light:
                case ItemCategory.Arrow:
                case ItemCategory.Bow:
                case ItemCategory.Hafted:
                case ItemCategory.Polearm:
                case ItemCategory.Boots:
                case ItemCategory.Gloves:
                case ItemCategory.Cloak:
                case ItemCategory.SoftArmor:
                    {
                        return true;
                    }
                case ItemCategory.LifeBook:
                case ItemCategory.SorceryBook:
                case ItemCategory.NatureBook:
                case ItemCategory.ChaosBook:
                case ItemCategory.DeathBook:
                case ItemCategory.TarotBook:
                case ItemCategory.FolkBook:
                case ItemCategory.CorporealBook:
                    {
                        return true;
                    }
                case ItemCategory.Chest:
                    {
                        return true;
                    }
                case ItemCategory.Staff:
                case ItemCategory.Scroll:
                    {
                        return true;
                    }
            }
            return false;
        }

        public bool IdentifyFully()
        {
            int i = 0, j, k;
            FlagSet f1 = new FlagSet();
            FlagSet f2 = new FlagSet();
            FlagSet f3 = new FlagSet();
            string[] info = new string[128];
            GetMergedFlags(f1, f2, f3);
            if (f3.IsSet(ItemFlag3.Activate))
            {
                info[i++] = "It can be activated for...";
                info[i++] = DescribeActivationEffect();
                info[i++] = "...if it is being worn.";
            }
            if (Category == ItemCategory.Light)
            {
                if (IsFixedArtifact())
                {
                    info[i++] = "It provides light (radius 3) forever.";
                }
                else if (ItemSubCategory == Enumerations.LightType.Lantern)
                {
                    info[i++] = "It provides light (radius 2) when fueled.";
                }
                else if (ItemSubCategory == Enumerations.LightType.Torch)
                {
                    info[i++] = "It provides light (radius 1) when fueled.";
                }
                else
                {
                    info[i++] = "It provides light (radius 2) forever.";
                }
            }
            if (f1.IsSet(ItemFlag1.Str))
            {
                info[i++] = "It affects your strength.";
            }
            if (f1.IsSet(ItemFlag1.Int))
            {
                info[i++] = "It affects your intelligence.";
            }
            if (f1.IsSet(ItemFlag1.Wis))
            {
                info[i++] = "It affects your wisdom.";
            }
            if (f1.IsSet(ItemFlag1.Dex))
            {
                info[i++] = "It affects your dexterity.";
            }
            if (f1.IsSet(ItemFlag1.Con))
            {
                info[i++] = "It affects your constitution.";
            }
            if (f1.IsSet(ItemFlag1.Cha))
            {
                info[i++] = "It affects your charisma.";
            }
            if (f1.IsSet(ItemFlag1.Stealth))
            {
                info[i++] = "It affects your stealth.";
            }
            if (f1.IsSet(ItemFlag1.Search))
            {
                info[i++] = "It affects your searching.";
            }
            if (f1.IsSet(ItemFlag1.Infra))
            {
                info[i++] = "It affects your infravision.";
            }
            if (f1.IsSet(ItemFlag1.Tunnel))
            {
                info[i++] = "It affects your ability to tunnel.";
            }
            if (f1.IsSet(ItemFlag1.Speed))
            {
                info[i++] = "It affects your movement speed.";
            }
            if (f1.IsSet(ItemFlag1.Blows))
            {
                info[i++] = "It affects your attack speed.";
            }
            if (f1.IsSet(ItemFlag1.BrandAcid))
            {
                info[i++] = "It does extra damage from acid.";
            }
            if (f1.IsSet(ItemFlag1.BrandElec))
            {
                info[i++] = "It does extra damage from electricity.";
            }
            if (f1.IsSet(ItemFlag1.BrandFire))
            {
                info[i++] = "It does extra damage from fire.";
            }
            if (f1.IsSet(ItemFlag1.BrandCold))
            {
                info[i++] = "It does extra damage from frost.";
            }
            if (f1.IsSet(ItemFlag1.BrandPois))
            {
                info[i++] = "It poisons your foes.";
            }
            if (f1.IsSet(ItemFlag1.Chaotic))
            {
                info[i++] = "It produces chaotic effects.";
            }
            if (f1.IsSet(ItemFlag1.Vampiric))
            {
                info[i++] = "It drains life from your foes.";
            }
            if (f1.IsSet(ItemFlag1.Impact))
            {
                info[i++] = "It can cause earthquakes.";
            }
            if (f1.IsSet(ItemFlag1.Vorpal))
            {
                info[i++] = "It is very sharp and can cut your foes.";
            }
            if (f1.IsSet(ItemFlag1.KillDragon))
            {
                info[i++] = "It is a great bane of dragons.";
            }
            else if (f1.IsSet(ItemFlag1.SlayDragon))
            {
                info[i++] = "It is especially deadly against dragons.";
            }
            if (f1.IsSet(ItemFlag1.SlayOrc))
            {
                info[i++] = "It is especially deadly against orcs.";
            }
            if (f1.IsSet(ItemFlag1.SlayTroll))
            {
                info[i++] = "It is especially deadly against trolls.";
            }
            if (f1.IsSet(ItemFlag1.SlayGiant))
            {
                info[i++] = "It is especially deadly against giants.";
            }
            if (f1.IsSet(ItemFlag1.SlayDemon))
            {
                info[i++] = "It strikes at demons with holy wrath.";
            }
            if (f1.IsSet(ItemFlag1.SlayUndead))
            {
                info[i++] = "It strikes at undead with holy wrath.";
            }
            if (f1.IsSet(ItemFlag1.SlayEvil))
            {
                info[i++] = "It fights against evil with holy fury.";
            }
            if (f1.IsSet(ItemFlag1.SlayAnimal))
            {
                info[i++] = "It is especially deadly against natural creatures.";
            }
            if (f2.IsSet(ItemFlag2.SustStr))
            {
                info[i++] = "It sustains your strength.";
            }
            if (f2.IsSet(ItemFlag2.SustInt))
            {
                info[i++] = "It sustains your intelligence.";
            }
            if (f2.IsSet(ItemFlag2.SustWis))
            {
                info[i++] = "It sustains your wisdom.";
            }
            if (f2.IsSet(ItemFlag2.SustDex))
            {
                info[i++] = "It sustains your dexterity.";
            }
            if (f2.IsSet(ItemFlag2.SustCon))
            {
                info[i++] = "It sustains your constitution.";
            }
            if (f2.IsSet(ItemFlag2.SustCha))
            {
                info[i++] = "It sustains your charisma.";
            }
            if (f2.IsSet(ItemFlag2.ImAcid))
            {
                info[i++] = "It provides immunity to acid.";
            }
            if (f2.IsSet(ItemFlag2.ImElec))
            {
                info[i++] = "It provides immunity to electricity.";
            }
            if (f2.IsSet(ItemFlag2.ImFire))
            {
                info[i++] = "It provides immunity to fire.";
            }
            if (f2.IsSet(ItemFlag2.ImCold))
            {
                info[i++] = "It provides immunity to cold.";
            }
            if (f2.IsSet(ItemFlag2.FreeAct))
            {
                info[i++] = "It provides immunity to paralysis.";
            }
            if (f2.IsSet(ItemFlag2.HoldLife))
            {
                info[i++] = "It provides resistance to life draining.";
            }
            if (f2.IsSet(ItemFlag2.ResFear))
            {
                info[i++] = "It makes you completely fearless.";
            }
            if (f2.IsSet(ItemFlag2.ResAcid))
            {
                info[i++] = "It provides resistance to acid.";
            }
            if (f2.IsSet(ItemFlag2.ResElec))
            {
                info[i++] = "It provides resistance to electricity.";
            }
            if (f2.IsSet(ItemFlag2.ResFire))
            {
                info[i++] = "It provides resistance to fire.";
            }
            if (f2.IsSet(ItemFlag2.ResCold))
            {
                info[i++] = "It provides resistance to cold.";
            }
            if (f2.IsSet(ItemFlag2.ResPois))
            {
                info[i++] = "It provides resistance to poison.";
            }
            if (f2.IsSet(ItemFlag2.ResLight))
            {
                info[i++] = "It provides resistance to light.";
            }
            if (f2.IsSet(ItemFlag2.ResDark))
            {
                info[i++] = "It provides resistance to dark.";
            }
            if (f2.IsSet(ItemFlag2.ResBlind))
            {
                info[i++] = "It provides resistance to blindness.";
            }
            if (f2.IsSet(ItemFlag2.ResConf))
            {
                info[i++] = "It provides resistance to confusion.";
            }
            if (f2.IsSet(ItemFlag2.ResSound))
            {
                info[i++] = "It provides resistance to sound.";
            }
            if (f2.IsSet(ItemFlag2.ResShards))
            {
                info[i++] = "It provides resistance to shards.";
            }
            if (f2.IsSet(ItemFlag2.ResNether))
            {
                info[i++] = "It provides resistance to nether.";
            }
            if (f2.IsSet(ItemFlag2.ResNexus))
            {
                info[i++] = "It provides resistance to nexus.";
            }
            if (f2.IsSet(ItemFlag2.ResChaos))
            {
                info[i++] = "It provides resistance to chaos.";
            }
            if (f2.IsSet(ItemFlag2.ResDisen))
            {
                info[i++] = "It provides resistance to disenchantment.";
            }
            if (f3.IsSet(ItemFlag3.Wraith))
            {
                info[i++] = "It renders you incorporeal.";
            }
            if (f3.IsSet(ItemFlag3.Feather))
            {
                info[i++] = "It allows you to levitate.";
            }
            if (f3.IsSet(ItemFlag3.Lightsource))
            {
                info[i++] = "It provides permanent light.";
            }
            if (f3.IsSet(ItemFlag3.SeeInvis))
            {
                info[i++] = "It allows you to see invisible monsters.";
            }
            if (f3.IsSet(ItemFlag3.Telepathy))
            {
                info[i++] = "It gives telepathic powers.";
            }
            if (f3.IsSet(ItemFlag3.SlowDigest))
            {
                info[i++] = "It slows your metabolism.";
            }
            if (f3.IsSet(ItemFlag3.Regen))
            {
                info[i++] = "It speeds your regenerative powers.";
            }
            if (f2.IsSet(ItemFlag2.Reflect))
            {
                info[i++] = "It reflects bolts and arrows.";
            }
            if (f3.IsSet(ItemFlag3.ShFire))
            {
                info[i++] = "It produces a fiery sheath.";
            }
            if (f3.IsSet(ItemFlag3.ShElec))
            {
                info[i++] = "It produces an electric sheath.";
            }
            if (f3.IsSet(ItemFlag3.NoMagic))
            {
                info[i++] = "It produces an anti-magic shell.";
            }
            if (f3.IsSet(ItemFlag3.NoTele))
            {
                info[i++] = "It prevents teleportation.";
            }
            if (f3.IsSet(ItemFlag3.XtraMight))
            {
                info[i++] = "It fires missiles with extra might.";
            }
            if (f3.IsSet(ItemFlag3.XtraShots))
            {
                info[i++] = "It fires missiles excessively fast.";
            }
            if (f3.IsSet(ItemFlag3.DrainExp))
            {
                info[i++] = "It drains experience.";
            }
            if (f3.IsSet(ItemFlag3.Teleport))
            {
                info[i++] = "It induces random teleportation.";
            }
            if (f3.IsSet(ItemFlag3.Aggravate))
            {
                info[i++] = "It aggravates nearby creatures.";
            }
            if (f3.IsSet(ItemFlag3.Blessed))
            {
                info[i++] = "It has been blessed by the gods.";
            }
            if (IsCursed())
            {
                if (f3.IsSet(ItemFlag3.PermaCurse))
                {
                    info[i++] = "It is permanently cursed.";
                }
                else if (f3.IsSet(ItemFlag3.HeavyCurse))
                {
                    info[i++] = "It is heavily cursed.";
                }
                else
                {
                    info[i++] = "It is cursed.";
                }
            }
            if (f3.IsSet(ItemFlag3.DreadCurse))
            {
                info[i++] = "It carries an ancient foul curse.";
            }
            if (f3.IsSet(ItemFlag3.IgnoreAcid))
            {
                info[i++] = "It cannot be harmed by acid.";
            }
            if (f3.IsSet(ItemFlag3.IgnoreElec))
            {
                info[i++] = "It cannot be harmed by electricity.";
            }
            if (f3.IsSet(ItemFlag3.IgnoreFire))
            {
                info[i++] = "It cannot be harmed by fire.";
            }
            if (f3.IsSet(ItemFlag3.IgnoreCold))
            {
                info[i++] = "It cannot be harmed by cold.";
            }
            if (i == 0)
            {
                return false;
            }
            Gui.Save();
            for (k = 1; k < 24; k++)
            {
                Gui.PrintLine("", k, 13);
            }
            Gui.PrintLine("     Item Attributes:", 1, 15);
            for (k = 2, j = 0; j < i; j++)
            {
                Gui.PrintLine(info[j], k++, 15);
                if (k == 22 && j + 1 < i)
                {
                    Gui.PrintLine("-- more --", k, 15);
                    Gui.Inkey();
                    for (; k > 2; k--)
                    {
                        Gui.PrintLine("", k, 15);
                    }
                }
            }
            Gui.PrintLine("[Press any key to continue]", k, 15);
            Gui.Inkey();
            Gui.Load();
            return true;
        }

        public bool IsBroken()
        {
            return IdentifyFlags.IsSet(Constants.IdentBroken);
        }

        public bool IsCursed()
        {
            return IdentifyFlags.IsSet(Constants.IdentCursed);
        }

        public bool IsFixedArtifact()
        {
            return FixedArtifactIndex != 0;
        }

        public bool IsFlavourAware()
        {
            if (ItemType == null)
            {
                return false;
            }
            return ItemType.FlavourAware;
        }

        public bool IsKnown()
        {
            if (ItemType == null)
            {
                return false;
            }
            if (IdentifyFlags.IsSet(Constants.IdentKnown))
            {
                return true;
            }
            if (ItemType.EasyKnow && ItemType.FlavourAware)
            {
                return true;
            }
            return false;
        }

        public bool IsRare()
        {
            return RareItemTypeIndex != 0;
        }

        public bool MakeGold()
        {
            int i = ((Program.Rng.DieRoll(SaveGame.Instance.Level.ObjectLevel + 2) + 2) / 2) - 1;
            if (Program.Rng.RandomLessThan(Constants.GreatObj) == 0)
            {
                i += Program.Rng.DieRoll(SaveGame.Instance.Level.ObjectLevel + 1);
            }
            if (CoinType != 0)
            {
                i = CoinType;
            }
            if (i >= Constants.MaxGold)
            {
                i = Constants.MaxGold - 1;
            }
            ItemType kPtr = null;
            switch (i)
            {
                case 0:
                    kPtr = Profile.Instance.ItemTypes.LookupKind(ItemCategory.Gold, Enumerations.MoneyType.CopperLow);
                    break;

                case 1:
                    kPtr = Profile.Instance.ItemTypes.LookupKind(ItemCategory.Gold, Enumerations.MoneyType.CopperMed);
                    break;

                case 2:
                    kPtr = Profile.Instance.ItemTypes.LookupKind(ItemCategory.Gold, Enumerations.MoneyType.CopperHi);
                    break;

                case 3:
                    kPtr = Profile.Instance.ItemTypes.LookupKind(ItemCategory.Gold, Enumerations.MoneyType.SilverLow);
                    break;

                case 4:
                    kPtr = Profile.Instance.ItemTypes.LookupKind(ItemCategory.Gold, Enumerations.MoneyType.SilverMed);
                    break;

                case 5:
                    kPtr = Profile.Instance.ItemTypes.LookupKind(ItemCategory.Gold, Enumerations.MoneyType.SilverHi);
                    break;

                case 6:
                    kPtr = Profile.Instance.ItemTypes.LookupKind(ItemCategory.Gold, Enumerations.MoneyType.GarnetsLow);
                    break;

                case 7:
                    kPtr = Profile.Instance.ItemTypes.LookupKind(ItemCategory.Gold, Enumerations.MoneyType.GarnetsHi);
                    break;

                case 8:
                    kPtr = Profile.Instance.ItemTypes.LookupKind(ItemCategory.Gold, Enumerations.MoneyType.GoldLow);
                    break;

                case 9:
                    kPtr = Profile.Instance.ItemTypes.LookupKind(ItemCategory.Gold, Enumerations.MoneyType.GoldMed);
                    break;

                case 10:
                    kPtr = Profile.Instance.ItemTypes.LookupKind(ItemCategory.Gold, Enumerations.MoneyType.GoldHigh);
                    break;

                case 11:
                    kPtr = Profile.Instance.ItemTypes.LookupKind(ItemCategory.Gold, Enumerations.MoneyType.Opals);
                    break;

                case 12:
                    kPtr = Profile.Instance.ItemTypes.LookupKind(ItemCategory.Gold, Enumerations.MoneyType.Sapphires);
                    break;

                case 13:
                    kPtr = Profile.Instance.ItemTypes.LookupKind(ItemCategory.Gold, Enumerations.MoneyType.Rubies);
                    break;

                case 14:
                    kPtr = Profile.Instance.ItemTypes.LookupKind(ItemCategory.Gold, Enumerations.MoneyType.Diamonds);
                    break;

                case 15:
                    kPtr = Profile.Instance.ItemTypes.LookupKind(ItemCategory.Gold, Enumerations.MoneyType.Emeralds);
                    break;

                case 16:
                    kPtr = Profile.Instance.ItemTypes.LookupKind(ItemCategory.Gold, Enumerations.MoneyType.Mithril);
                    break;

                case 17:
                    kPtr = Profile.Instance.ItemTypes.LookupKind(ItemCategory.Gold, Enumerations.MoneyType.Adamantite);
                    break;
            }
            if (kPtr == null)
            {
                return false;
            }
            AssignItemType(kPtr);
            int bbase = kPtr.Cost;
            TypeSpecificValue = bbase + (8 * Program.Rng.DieRoll(bbase)) + Program.Rng.DieRoll(8);
            return true;
        }

        public void ObjectFlagsKnown(FlagSet f1, FlagSet f2, FlagSet f3)
        {
            f1.Clear();
            f2.Clear();
            f3.Clear();
            if (!IsKnown())
            {
                return;
            }
            GetMergedFlags(f1, f2, f3);
        }

        public void ObjectTried()
        {
            ItemType.Tried = true;
        }

        public int RealValue()
        {
            FlagSet f1 = new FlagSet();
            FlagSet f2 = new FlagSet();
            FlagSet f3 = new FlagSet();
            ItemType kPtr = ItemType;
            if (kPtr.Cost == 0)
            {
                return 0;
            }
            int value = kPtr.Cost;
            GetMergedFlags(f1, f2, f3);
            if (RandartFlags1.IsSet() || RandartFlags2.IsSet() || RandartFlags3.IsSet())
            {
                value += FlagBasedCost(TypeSpecificValue);
            }
            else if (FixedArtifactIndex != 0)
            {
                FixedArtifact aPtr = Profile.Instance.FixedArtifacts[FixedArtifactIndex];
                if (aPtr.Cost == 0)
                {
                    return 0;
                }
                value = aPtr.Cost;
            }
            else if (RareItemTypeIndex != Enumerations.RareItemType.None)
            {
                RareItemType ePtr = Profile.Instance.RareItemTypes[RareItemTypeIndex];
                if (ePtr.Cost == 0)
                {
                    return 0;
                }
                value += ePtr.Cost;
            }
            switch (Category)
            {
                case ItemCategory.Shot:
                case ItemCategory.Arrow:
                case ItemCategory.Bolt:
                case ItemCategory.Bow:
                case ItemCategory.Digging:
                case ItemCategory.Hafted:
                case ItemCategory.Polearm:
                case ItemCategory.Sword:
                case ItemCategory.Boots:
                case ItemCategory.Gloves:
                case ItemCategory.Helm:
                case ItemCategory.Crown:
                case ItemCategory.Shield:
                case ItemCategory.Cloak:
                case ItemCategory.SoftArmor:
                case ItemCategory.HardArmor:
                case ItemCategory.DragArmor:
                case ItemCategory.Light:
                case ItemCategory.Amulet:
                case ItemCategory.Ring:
                    {
                        if (TypeSpecificValue < 0)
                        {
                            return 0;
                        }
                        if (TypeSpecificValue == 0)
                        {
                            break;
                        }
                        if (f1.IsSet(ItemFlag1.Str))
                        {
                            value += TypeSpecificValue * 200;
                        }
                        if (f1.IsSet(ItemFlag1.Int))
                        {
                            value += TypeSpecificValue * 200;
                        }
                        if (f1.IsSet(ItemFlag1.Wis))
                        {
                            value += TypeSpecificValue * 200;
                        }
                        if (f1.IsSet(ItemFlag1.Dex))
                        {
                            value += TypeSpecificValue * 200;
                        }
                        if (f1.IsSet(ItemFlag1.Con))
                        {
                            value += TypeSpecificValue * 200;
                        }
                        if (f1.IsSet(ItemFlag1.Cha))
                        {
                            value += TypeSpecificValue * 200;
                        }
                        if (f1.IsSet(ItemFlag1.Stealth))
                        {
                            value += TypeSpecificValue * 100;
                        }
                        if (f1.IsSet(ItemFlag1.Search))
                        {
                            value += TypeSpecificValue * 100;
                        }
                        if (f1.IsSet(ItemFlag1.Infra))
                        {
                            value += TypeSpecificValue * 50;
                        }
                        if (f1.IsSet(ItemFlag1.Tunnel))
                        {
                            value += TypeSpecificValue * 50;
                        }
                        if (f1.IsSet(ItemFlag1.Blows))
                        {
                            value += TypeSpecificValue * 5000;
                        }
                        if (f1.IsSet(ItemFlag1.Speed))
                        {
                            value += TypeSpecificValue * 3000;
                        }
                        break;
                    }
            }
            switch (Category)
            {
                case ItemCategory.Wand:
                case ItemCategory.Staff:
                    {
                        value += value / 20 * TypeSpecificValue;
                        break;
                    }
                case ItemCategory.Ring:
                case ItemCategory.Amulet:
                    {
                        if (BonusArmourClass < 0)
                        {
                            return 0;
                        }
                        if (BonusToHit < 0)
                        {
                            return 0;
                        }
                        if (BonusDamage < 0)
                        {
                            return 0;
                        }
                        value += (BonusToHit + BonusDamage + BonusArmourClass) * 100;
                        break;
                    }
                case ItemCategory.Boots:
                case ItemCategory.Gloves:
                case ItemCategory.Cloak:
                case ItemCategory.Crown:
                case ItemCategory.Helm:
                case ItemCategory.Shield:
                case ItemCategory.SoftArmor:
                case ItemCategory.HardArmor:
                case ItemCategory.DragArmor:
                    {
                        if (BonusArmourClass < 0)
                        {
                            return 0;
                        }
                        value += (BonusToHit + BonusDamage + BonusArmourClass) * 100;
                        break;
                    }
                case ItemCategory.Bow:
                case ItemCategory.Digging:
                case ItemCategory.Hafted:
                case ItemCategory.Sword:
                case ItemCategory.Polearm:
                    {
                        if (BonusToHit + BonusDamage < 0)
                        {
                            return 0;
                        }
                        value += (BonusToHit + BonusDamage + BonusArmourClass) * 100;
                        if (DamageDice > kPtr.Dd && DamageDiceSides == kPtr.Ds)
                        {
                            value += (DamageDice - kPtr.Dd) * DamageDiceSides * 100;
                        }
                        break;
                    }
                case ItemCategory.Shot:
                case ItemCategory.Arrow:
                case ItemCategory.Bolt:
                    {
                        if (BonusToHit + BonusDamage < 0)
                        {
                            return 0;
                        }
                        value += (BonusToHit + BonusDamage) * 5;
                        if (DamageDice > kPtr.Dd && DamageDiceSides == kPtr.Ds)
                        {
                            value += (DamageDice - kPtr.Dd) * DamageDiceSides * 5;
                        }
                        break;
                    }
            }
            return value;
        }

        public bool Stompable()
        {
            var t = this;
            ItemType kPtr = ItemType;
            if (!IsKnown())
            {
                if (Inventory.ObjectHasFlavor(ItemType))
                {
                    if (IsFlavourAware())
                    {
                        return kPtr.Stompable[0];
                    }
                }
                if (IdentifyFlags.IsClear(Constants.IdentSense))
                {
                    return false;
                }
            }
            if (kPtr.Category == ItemCategory.Ring || kPtr.Category == ItemCategory.Amulet)
            {
                if (BonusDamage < 0 || BonusArmourClass < 0 || BonusToHit < 0 || TypeSpecificValue < 0)
                {
                    return true;
                }
            }
            if (kPtr.HasQuality())
            {
                switch (GetDetailedFeeling())
                {
                    case "terrible":
                    case "worthless":
                    case "cursed":
                    case "broken":
                        return kPtr.Stompable[0];

                    case "average":
                        return kPtr.Stompable[1];

                    case "good":
                        return kPtr.Stompable[2];

                    case "excellent":
                        return kPtr.Stompable[3];

                    case "special":
                        return false;

                    default:
                        throw new InvalidDataException($"Unrecognised item quality ({GetDetailedFeeling()})");
                }
            }
            if (kPtr.Category == ItemCategory.Chest)
            {
                if (!IsKnown())
                {
                    return false;
                }
                else if (TypeSpecificValue == 0)
                {
                    return kPtr.Stompable[0];
                }
                else if (TypeSpecificValue < 0)
                {
                    return kPtr.Stompable[1];
                }
                else
                {
                    switch (GlobalData.ChestTraps[TypeSpecificValue])
                    {
                        case 0:
                            {
                                return kPtr.Stompable[2];
                            }
                        default:
                            {
                                return kPtr.Stompable[3];
                            }
                    }
                }
            }
            return kPtr.Stompable[0];
        }

        public string StoreDescription(bool pref, int mode)
        {
            bool hackAware = ItemType.FlavourAware;
            bool hackKnown = IdentifyFlags.IsSet(Constants.IdentKnown);
            IdentifyFlags.Set(Constants.IdentKnown);
            ItemType.FlavourAware = true;
            string buf = Description(pref, mode);
            ItemType.FlavourAware = hackAware;
            if (!hackKnown)
            {
                IdentifyFlags.Clear(Constants.IdentKnown);
            }
            return buf;
        }

        public override string ToString()
        {
            return Description(false, 0);
        }

        public int Value()
        {
            int value;
            if (IsKnown())
            {
                if (IsBroken())
                {
                    return 0;
                }
                if (IsCursed())
                {
                    return 0;
                }
                value = RealValue();
            }
            else
            {
                if (IdentifyFlags.IsSet(Constants.IdentSense) && IsBroken())
                {
                    return 0;
                }
                if (IdentifyFlags.IsSet(Constants.IdentSense) && IsCursed())
                {
                    return 0;
                }
                value = BaseValue();
            }
            if (Discount != 0)
            {
                value -= value * Discount / 100;
            }
            return value;
        }

        private int BaseValue()
        {
            ItemType kPtr = ItemType;
            if (IsFlavourAware())
            {
                return kPtr.Cost;
            }
            switch (Category)
            {
                case ItemCategory.Food:
                    return 5;

                case ItemCategory.Potion:
                    return 20;

                case ItemCategory.Scroll:
                    return 20;

                case ItemCategory.Staff:
                    return 70;

                case ItemCategory.Wand:
                    return 50;

                case ItemCategory.Rod:
                    return 90;

                case ItemCategory.Ring:
                    return 45;

                case ItemCategory.Amulet:
                    return 45;
            }
            return 0;
        }

        private string DescribeActivationEffect()
        {
            FlagSet f1 = new FlagSet();
            FlagSet f2 = new FlagSet();
            FlagSet f3 = new FlagSet();
            GetMergedFlags(f1, f2, f3);
            if (f3.IsClear(ItemFlag3.Activate))
            {
                return null;
            }
            if (FixedArtifactIndex == 0 && RareItemTypeIndex == 0 && BonusPowerType == 0 && BonusPowerSubType != null)
            {
                return BonusPowerSubType.Description;
            }
            switch (FixedArtifactIndex)
            {
                case FixedArtifactId.DaggerOfFaith:
                    {
                        return "fire bolt (9d8) every 8+d8 turns";
                    }
                case FixedArtifactId.DaggerOfHope:
                    {
                        return "frost bolt (6d8) every 7+d7 turns";
                    }
                case FixedArtifactId.DaggerOfCharity:
                    {
                        return "lightning bolt (4d8) every 6+d6 turns";
                    }
                case FixedArtifactId.DaggerOfThoth:
                    {
                        return "stinking cloud (12) every 4+d4 turns";
                    }
                case FixedArtifactId.DaggerIcicle:
                    {
                        return "frost ball (48) every 5+d5 turns";
                    }
                case FixedArtifactId.BootsOfDancing:
                    {
                        return "remove fear and cure poison every 5 turns";
                    }
                case FixedArtifactId.SwordExcalibur:
                    {
                        return "frost ball (100) every 300 turns";
                    }
                case FixedArtifactId.SwordOfTheDawn:
                    {
                        return "summon a Black Reaver every 500+d500 turns";
                    }
                case FixedArtifactId.SwordOfEverflame:
                    {
                        return "fire ball (72) every 400 turns";
                    }
                case FixedArtifactId.MorningStarFirestarter:
                    {
                        return "large fire ball (72) every 100 turns";
                    }
                case FixedArtifactId.BootsOfIthaqua:
                    {
                        return "haste self (20+d20 turns) every 200 turns";
                    }
                case FixedArtifactId.AxeOfTheoden:
                    {
                        return "drain life (120) every 400 turns";
                    }
                case FixedArtifactId.HammerJustice:
                    {
                        return "drain life (90) every 70 turns";
                    }
                case FixedArtifactId.ArmourOfTheOgreLords:
                    {
                        return "door and trap destruction every 10 turns";
                    }
                case FixedArtifactId.ScytheOfGharne:
                    {
                        return "word of recall every 200 turns";
                    }
                case FixedArtifactId.MaceThunder:
                    {
                        return "haste self (20+d20 turns) every 100+d100 turns";
                    }
                case FixedArtifactId.QuarterstaffEriril:
                    {
                        return "identify every 10 turns";
                    }
                case FixedArtifactId.QuarterstaffOfAtal:
                    {
                        return "probing, detection and full id  every 1000 turns";
                    }
                case FixedArtifactId.AxeOfTheTrolls:
                    {
                        return "mass carnage every 1000 turns";
                    }
                case FixedArtifactId.AxeSpleenSlicer:
                    {
                        return "cure wounds (4d7) every 3+d3 turns";
                    }
                case FixedArtifactId.CrossbowOfDeath:
                    {
                        return "fire branding of bolts every 999 turns";
                    }
                case FixedArtifactId.SwordOfKarakal:
                    {
                        return "a getaway every 35 turns";
                    }
                case FixedArtifactId.SpearGungnir:
                    {
                        return "lightning ball (100) every 500 turns";
                    }
                case FixedArtifactId.SpearOfDestiny:
                    {
                        return "stone to mud every 5 turns";
                    }
                case FixedArtifactId.PlateMailSoulkeeper:
                    {
                        return "heal (1000) every 888 turns";
                    }
                case FixedArtifactId.ArmourOfTheVampireHunter:
                    {
                        return "heal (777), curing and heroism every 300 turns";
                    }
                case FixedArtifactId.ArmourOfTheOrcs:
                    {
                        return "carnage every 500 turns";
                    }
                case FixedArtifactId.ShadowCloakOfNyogtha:
                    {
                        return "restore life levels every 450 turns";
                    }
                case FixedArtifactId.TridentOfTheGnorri:
                    {
                        return "teleport away every 150 turns";
                    }
                case FixedArtifactId.CloakOfBarzai:
                    {
                        return "resistance (20+d20 turns) every 111 turns";
                    }
                case FixedArtifactId.CloakDarkness:
                    {
                        return "Sleep II every 55 turns";
                    }
                case FixedArtifactId.CloakOfTheSwashbuckler:
                    {
                        return "recharge item I every 70 turns";
                    }
                case FixedArtifactId.CloakShifter:
                    {
                        return "teleport every 45 turns";
                    }
                case FixedArtifactId.FlailTotila:
                    {
                        return "confuse monster every 15 turns";
                    }
                case FixedArtifactId.GlovesOfLight:
                    {
                        return "magic missile (2d6) every 2 turns";
                    }
                case FixedArtifactId.GauntletIronfist:
                    {
                        return "fire bolt (9d8) every 8+d8 turns";
                    }
                case FixedArtifactId.GauntletsOfGhouls:
                    {
                        return "frost bolt (6d8) every 7+d7 turns";
                    }
                case FixedArtifactId.GauntletsWhiteSpark:
                    {
                        return "lightning bolt (4d8) every 6+d6 turns";
                    }
                case FixedArtifactId.GauntletsOfTheDead:
                    {
                        return "acid bolt (5d8) every 5+d5 turns";
                    }
                case FixedArtifactId.CestiOfCombat:
                    {
                        return "a magical arrow (150) every 90+d90 turns";
                    }
                case FixedArtifactId.HelmSkullkeeper:
                    {
                        return "detection every 55+d55 turns";
                    }
                case FixedArtifactId.CrownOfTheSun:
                    {
                        return "heal (700) every 250 turns";
                    }
                case FixedArtifactId.DragonScaleRazorback:
                    {
                        return "star ball (150) every 1000 turns";
                    }
                case FixedArtifactId.DragonScaleBladeturner:
                    {
                        return "breathe elements (300), berserk rage, bless, and resistance";
                    }
                case FixedArtifactId.StarEssenceOfPolaris:
                    {
                        return "illumination every 10+d10 turns";
                    }
                case FixedArtifactId.StarEssenceOfXoth:
                    {
                        return "magic mapping and light every 50+d50 turns";
                    }
                case FixedArtifactId.ShiningTrapezohedron:
                    {
                        return "clairvoyance and recall, draining you";
                    }
                case FixedArtifactId.AmuletOfAbdulAlhazred:
                    {
                        return "dispel evil (x5) every 300+d300 turns";
                    }
                case FixedArtifactId.AmuletOfLobon:
                    {
                        return "protection from evil every 225+d225 turns";
                    }
                case FixedArtifactId.RingOfMagic:
                    {
                        return "a strangling attack (100) every 100+d100 turns";
                    }
                case FixedArtifactId.RingOfBast:
                    {
                        return "haste self (75+d75 turns) every 150+d150 turns";
                    }
                case FixedArtifactId.RingOfElementalPowerFire:
                    {
                        return "large fire ball (120) every 225+d225 turns";
                    }
                case FixedArtifactId.RingOfElementalPowerIce:
                    {
                        return "large frost ball (200) every 325+d325 turns";
                    }
                case FixedArtifactId.RingOfElementalPowerStorm:
                    {
                        return "large lightning ball (250) every 425+d425 turns";
                    }
                case FixedArtifactId.RingOfSet:
                    {
                        return "bizarre things every 450+d450 turns";
                    }
                case FixedArtifactId.DragonHelmOfPower:
                case FixedArtifactId.HelmTerrorMask:
                    {
                        return "rays of fear in every direction";
                    }
            }
            if (RareItemTypeIndex == Enumerations.RareItemType.WeaponPlanarWeapon)
            {
                return "teleport every 50+d50 turns";
            }
            if (Category == ItemCategory.Ring)
            {
                switch (ItemSubCategory)
                {
                    case Enumerations.RingType.Flames:
                        return "ball of fire and resist fire";

                    case Enumerations.RingType.Ice:
                        return "ball of cold and resist cold";

                    case Enumerations.RingType.Acid:
                        return "ball of acid and resist acid";

                    default:
                        return null;
                }
            }
            if (Category != ItemCategory.DragArmor)
            {
                return null;
            }
            switch (ItemSubCategory)
            {
                case Enumerations.DragonArmour.SvDragonBlue:
                    {
                        return "breathe lightning (100) every 450+d450 turns";
                    }
                case Enumerations.DragonArmour.SvDragonWhite:
                    {
                        return "breathe frost (110) every 450+d450 turns";
                    }
                case Enumerations.DragonArmour.SvDragonBlack:
                    {
                        return "breathe acid (130) every 450+d450 turns";
                    }
                case Enumerations.DragonArmour.SvDragonGreen:
                    {
                        return "breathe poison gas (150) every 450+d450 turns";
                    }
                case Enumerations.DragonArmour.SvDragonRed:
                    {
                        return "breathe fire (200) every 450+d450 turns";
                    }
                case Enumerations.DragonArmour.SvDragonMultihued:
                    {
                        return "breathe multi-hued (250) every 225+d225 turns";
                    }
                case Enumerations.DragonArmour.SvDragonBronze:
                    {
                        return "breathe confusion (120) every 450+d450 turns";
                    }
                case Enumerations.DragonArmour.SvDragonGold:
                    {
                        return "breathe sound (130) every 450+d450 turns";
                    }
                case Enumerations.DragonArmour.SvDragonChaos:
                    {
                        return "breathe chaos/disenchant (220) every 300+d300 turns";
                    }
                case Enumerations.DragonArmour.SvDragonLaw:
                    {
                        return "breathe sound/shards (230) every 300+d300 turns";
                    }
                case Enumerations.DragonArmour.SvDragonBalance:
                    {
                        return "You breathe balance (250) every 300+d300 turns";
                    }
                case Enumerations.DragonArmour.SvDragonShining:
                    {
                        return "breathe light/darkness (200) every 300+d300 turns";
                    }
                case Enumerations.DragonArmour.SvDragonPower:
                    {
                        return "breathe the elements (300) every 300+d300 turns";
                    }
            }
            return string.Empty;
        }

        private bool IsTried()
        {
            return ItemType.Tried;
        }

        private delegate bool GetObjNumHookDelegate(int kIdx);

        public void ApplyMagic(int lev, bool okay, bool good, bool great)
        {
            if (lev > Constants.MaxDepth - 1)
            {
                lev = Constants.MaxDepth - 1;
            }
            int f1 = lev + 10;
            if (f1 > 75)
            {
                f1 = 75;
            }
            int f2 = f1 / 2;
            if (f2 > 20)
            {
                f2 = 20;
            }
            int power = 0;
            if (good || Program.Rng.PercentileRoll(f1))
            {
                power = 1;
                if (great || Program.Rng.PercentileRoll(f2))
                {
                    power = 2;
                }
            }
            else if (Program.Rng.PercentileRoll(f1))
            {
                power = -1;
                if (Program.Rng.PercentileRoll(f2))
                {
                    power = -2;
                }
            }
            int rolls = 0;
            if (power >= 2)
            {
                rolls = 1;
            }
            if (great)
            {
                rolls = 4;
            }
            if (!okay || FixedArtifactIndex != 0)
            {
                rolls = 0;
            }
            for (int i = 0; i < rolls; i++)
            {
                if (ApplyFixedArtifact())
                {
                    break;
                }
            }
            if (FixedArtifactIndex != 0)
            {
                FixedArtifact aPtr = Profile.Instance.FixedArtifacts[FixedArtifactIndex];
                aPtr.CurNum = 1;
                TypeSpecificValue = aPtr.Pval;
                BaseArmourClass = aPtr.Ac;
                DamageDice = aPtr.Dd;
                DamageDiceSides = aPtr.Ds;
                BonusArmourClass = aPtr.ToA;
                BonusToHit = aPtr.ToH;
                BonusDamage = aPtr.ToD;
                Weight = aPtr.Weight;
                if (aPtr.Cost == 0)
                {
                    IdentifyFlags.Set(Constants.IdentBroken);
                }
                if (aPtr.Flags3.IsSet(ItemFlag3.Cursed))
                {
                    IdentifyFlags.Set(Constants.IdentCursed);
                }
                if (SaveGame.Instance.Level != null)
                {
                    SaveGame.Instance.Level.TreasureRating += 10;
                    if (aPtr.Cost > 50000)
                    {
                        SaveGame.Instance.Level.TreasureRating += 10;
                    }
                    SaveGame.Instance.Level.SpecialTreasure = true;
                }
                return;
            }
            switch (Category)
            {
                case ItemCategory.Digging:
                case ItemCategory.Hafted:
                case ItemCategory.Polearm:
                case ItemCategory.Sword:
                case ItemCategory.Bow:
                case ItemCategory.Shot:
                case ItemCategory.Arrow:
                case ItemCategory.Bolt:
                    {
                        if (power != 0)
                        {
                            ApplyMagicToWeapon(lev, power);
                        }
                        break;
                    }
                case ItemCategory.DragArmor:
                case ItemCategory.HardArmor:
                case ItemCategory.SoftArmor:
                case ItemCategory.Shield:
                case ItemCategory.Helm:
                case ItemCategory.Crown:
                case ItemCategory.Cloak:
                case ItemCategory.Gloves:
                case ItemCategory.Boots:
                    {
                        if (power != 0 ||
                            (Category == ItemCategory.Helm && ItemSubCategory == HelmType.SvDragonHelm) ||
                            (Category == ItemCategory.Shield && ItemSubCategory == ShieldType.SvDragonShield) ||
                            (Category == ItemCategory.Cloak && ItemSubCategory == CloakType.SvElvenCloak))
                        {
                            ApplyMagicToArmour(lev, power);
                        }
                        break;
                    }
                case ItemCategory.Ring:
                case ItemCategory.Amulet:
                    {
                        if (power == 0 && Program.Rng.RandomLessThan(100) < 50)
                        {
                            power = -1;
                        }
                        ApplyMagicToJewellery(lev, power);
                        break;
                    }
                case ItemCategory.Light:
                    {
                        ApplyMagicToLightSource(power);
                        break;
                    }
                default:
                    {
                        ApplyMagicToMiscItem();
                        break;
                    }
            }
            if (!string.IsNullOrEmpty(RandartName))
            {
                if (SaveGame.Instance.Level != null)
                {
                    SaveGame.Instance.Level.TreasureRating += 40;
                }
            }
            else if (RareItemTypeIndex != Enumerations.RareItemType.None)
            {
                RareItemType ePtr = Profile.Instance.RareItemTypes[RareItemTypeIndex];
                switch (RareItemTypeIndex)
                {
                    case Enumerations.RareItemType.WeaponElderSign:
                        {
                            BonusPowerType = Enumerations.RareItemType.SpecialSustain;
                            break;
                        }
                    case Enumerations.RareItemType.WeaponDefender:
                        {
                            BonusPowerType = Enumerations.RareItemType.SpecialSustain;
                            break;
                        }
                    case Enumerations.RareItemType.WeaponBlessed:
                        {
                            BonusPowerType = Enumerations.RareItemType.SpecialAbility;
                            break;
                        }
                    case Enumerations.RareItemType.WeaponPlanarWeapon:
                        {
                            if (Program.Rng.DieRoll(7) == 1)
                            {
                                BonusPowerType = Enumerations.RareItemType.SpecialAbility;
                            }
                            break;
                        }
                    case Enumerations.RareItemType.ArmourOfPermanence:
                        {
                            BonusPowerType = Enumerations.RareItemType.SpecialPower;
                            break;
                        }
                    case Enumerations.RareItemType.ArmourOfYith:
                        {
                            BonusPowerType = Enumerations.RareItemType.SpecialPower;
                            break;
                        }
                    case Enumerations.RareItemType.HatOfTheMagi:
                        {
                            BonusPowerType = Enumerations.RareItemType.SpecialAbility;
                            break;
                        }
                    case Enumerations.RareItemType.CloakOfAman:
                        {
                            BonusPowerType = Enumerations.RareItemType.SpecialPower;
                            break;
                        }
                }
                if (BonusPowerType != 0 && string.IsNullOrEmpty(RandartName))
                {
                    BonusPowerSubType = ActivationPowerManager.GetRandom();
                }
                if (ePtr.Cost == 0)
                {
                    IdentifyFlags.Set(Constants.IdentBroken);
                }
                if (ePtr.Flags3.IsSet(ItemFlag3.Cursed))
                {
                    IdentifyFlags.Set(Constants.IdentCursed);
                }
                if (IsCursed() || IsBroken())
                {
                    if (ePtr.MaxToH != 0)
                    {
                        BonusToHit -= Program.Rng.DieRoll(ePtr.MaxToH);
                    }
                    if (ePtr.MaxToD != 0)
                    {
                        BonusDamage -= Program.Rng.DieRoll(ePtr.MaxToD);
                    }
                    if (ePtr.MaxToA != 0)
                    {
                        BonusArmourClass -= Program.Rng.DieRoll(ePtr.MaxToA);
                    }
                    if (ePtr.MaxPval != 0)
                    {
                        TypeSpecificValue -= Program.Rng.DieRoll(ePtr.MaxPval);
                    }
                }
                else
                {
                    if (ePtr.MaxToH != 0)
                    {
                        BonusToHit += Program.Rng.DieRoll(ePtr.MaxToH);
                    }
                    if (ePtr.MaxToD != 0)
                    {
                        BonusDamage += Program.Rng.DieRoll(ePtr.MaxToD);
                    }
                    if (ePtr.MaxToA != 0)
                    {
                        BonusArmourClass += Program.Rng.DieRoll(ePtr.MaxToA);
                    }
                    if (ePtr.MaxPval != 0)
                    {
                        TypeSpecificValue += Program.Rng.DieRoll(ePtr.MaxPval);
                    }
                }
                if (SaveGame.Instance.Level != null)
                {
                    SaveGame.Instance.Level.TreasureRating += ePtr.Rating;
                }
                return;
            }
            if (ItemType != null)
            {
                ItemType kPtr = ItemType;
                if (kPtr.Cost == 0)
                {
                    IdentifyFlags.Set(Constants.IdentBroken);
                }
                if (kPtr.Flags3.IsSet(ItemFlag3.Cursed))
                {
                    IdentifyFlags.Set(Constants.IdentCursed);
                }
            }
        }

        public void ApplyRandomResistance(ref IArtifactBias artifactBias, int specific)
        {
            if (specific == 0 && artifactBias != null)
            {
                if (artifactBias.ApplyRandomResistances(this))
                {
                    return;
                }

            }
            switch (specific != 0 ? specific : Program.Rng.DieRoll(41))
            {
                case 1:
                    if (Program.Rng.DieRoll(Constants.WeirdLuck) != 1)
                    {
                        ApplyRandomResistance(ref artifactBias, 0);
                    }
                    else
                    {
                        RandartFlags2.Set(ItemFlag2.ImAcid);
                        if (artifactBias == null)
                        {
                            artifactBias = new AcidArtifactBias();
                        }
                    }
                    break;

                case 2:
                    if (Program.Rng.DieRoll(Constants.WeirdLuck) != 1)
                    {
                        ApplyRandomResistance(ref artifactBias, 0);
                    }
                    else
                    {
                        RandartFlags2.Set(ItemFlag2.ImElec);
                        if (artifactBias == null)
                        {
                            artifactBias = new ElectricityArtifactBias();
                        }
                    }
                    break;

                case 3:
                    if (Program.Rng.DieRoll(Constants.WeirdLuck) != 1)
                    {
                        ApplyRandomResistance(ref artifactBias, 0);
                    }
                    else
                    {
                        RandartFlags2.Set(ItemFlag2.ImCold);
                        if (artifactBias == null)
                        {
                            artifactBias = new ColdArtifactBias();
                        }
                    }
                    break;

                case 4:
                    if (Program.Rng.DieRoll(Constants.WeirdLuck) != 1)
                    {
                        ApplyRandomResistance(ref artifactBias, 0);
                    }
                    else
                    {
                        RandartFlags2.Set(ItemFlag2.ImFire);
                        if (artifactBias == null)
                        {
                            artifactBias = new FireArtifactBias();
                        }
                    }
                    break;

                case 5:
                case 6:
                case 13:
                    RandartFlags2.Set(ItemFlag2.ResAcid);
                    if (artifactBias == null)
                    {
                        artifactBias = new AcidArtifactBias();
                    }
                    break;

                case 7:
                case 8:
                case 14:
                    RandartFlags2.Set(ItemFlag2.ResElec);
                    if (artifactBias == null)
                    {
                        artifactBias = new ElectricityArtifactBias();
                    }
                    break;

                case 9:
                case 10:
                case 15:
                    RandartFlags2.Set(ItemFlag2.ResFire);
                    if (artifactBias == null)
                    {
                        artifactBias = new FireArtifactBias();
                    }
                    break;

                case 11:
                case 12:
                case 16:
                    RandartFlags2.Set(ItemFlag2.ResCold);
                    if (artifactBias == null)
                    {
                        artifactBias = new ColdArtifactBias();
                    }
                    break;

                case 17:
                case 18:
                    RandartFlags2.Set(ItemFlag2.ResPois);
                    if (artifactBias == null && Program.Rng.DieRoll(4) != 1)
                    {
                        artifactBias = new PoisonArtifactBias();
                    }
                    else if (artifactBias == null && Program.Rng.DieRoll(2) == 1)
                    {
                        artifactBias = new NecromanticArtifactBias();
                    }
                    else if (artifactBias == null && Program.Rng.DieRoll(2) == 1)
                    {
                        artifactBias = new RogueArtifactBias();
                    }
                    break;

                case 19:
                case 20:
                    RandartFlags2.Set(ItemFlag2.ResFear);
                    if (artifactBias == null && Program.Rng.DieRoll(3) == 1)
                    {
                        artifactBias = new WarriorArtifactBias();
                    }
                    break;

                case 21:
                    RandartFlags2.Set(ItemFlag2.ResLight);
                    break;

                case 22:
                    RandartFlags2.Set(ItemFlag2.ResDark);
                    break;

                case 23:
                case 24:
                    RandartFlags2.Set(ItemFlag2.ResBlind);
                    break;

                case 25:
                case 26:
                    RandartFlags2.Set(ItemFlag2.ResConf);
                    if (artifactBias == null && Program.Rng.DieRoll(6) == 1)
                    {
                        artifactBias = new ChaosArtifactBias();
                    }
                    break;

                case 27:
                case 28:
                    RandartFlags2.Set(ItemFlag2.ResSound);
                    break;

                case 29:
                case 30:
                    RandartFlags2.Set(ItemFlag2.ResShards);
                    break;

                case 31:
                case 32:
                    RandartFlags2.Set(ItemFlag2.ResNether);
                    if (artifactBias == null && Program.Rng.DieRoll(3) == 1)
                    {
                        artifactBias = new NecromanticArtifactBias();
                    }
                    break;

                case 33:
                case 34:
                    RandartFlags2.Set(ItemFlag2.ResNexus);
                    break;

                case 35:
                case 36:
                    RandartFlags2.Set(ItemFlag2.ResChaos);
                    if (artifactBias == null && Program.Rng.DieRoll(2) == 1)
                    {
                        artifactBias = new ChaosArtifactBias();
                    }
                    break;

                case 37:
                case 38:
                    RandartFlags2.Set(ItemFlag2.ResDisen);
                    break;

                case 39:
                    if (Category >= ItemCategory.Cloak &&
                        Category <= ItemCategory.HardArmor)
                    {
                        RandartFlags3.Set(ItemFlag3.ShElec);
                    }
                    else
                    {
                        ApplyRandomResistance(ref artifactBias, 0);
                    }
                    if (artifactBias == null)
                    {
                        artifactBias = new ElectricityArtifactBias();
                    }
                    break;

                case 40:
                    if (Category >= ItemCategory.Cloak &&
                        Category <= ItemCategory.HardArmor)
                    {
                        RandartFlags3.Set(ItemFlag3.ShFire);
                    }
                    else
                    {
                        ApplyRandomResistance(ref artifactBias, 0);
                    }
                    if (artifactBias == null)
                    {
                        artifactBias = new FireArtifactBias();
                    }
                    break;

                case 41:
                    if (Category == ItemCategory.Shield ||
                        Category == ItemCategory.Cloak || Category == ItemCategory.Helm ||
                        Category == ItemCategory.HardArmor)
                    {
                        RandartFlags2.Set(ItemFlag2.Reflect);
                    }
                    else
                    {
                        ApplyRandomResistance(ref artifactBias, 0);
                    }
                    break;
            }
        }

        public bool CreateRandart(bool fromScroll)
        {
            bool hasPval = false;
            int powers = Program.Rng.DieRoll(5) + 1;
            int maxType = Category < ItemCategory.Boots ? 7 : 5;
            bool aCursed = false;
            int warriorArtifactBias = 0;
            IArtifactBias artifactBias = null;
            if (fromScroll && Program.Rng.DieRoll(4) == 1)
            {
                switch (SaveGame.Instance.Player.ProfessionIndex)
                {
                    case CharacterClass.Warrior:
                    case CharacterClass.ChosenOne:
                        artifactBias = new WarriorArtifactBias();
                        break;

                    case CharacterClass.Mage:
                    case CharacterClass.HighMage:
                    case CharacterClass.Cultist:
                    case CharacterClass.Channeler:
                        artifactBias = new MageArtifactBias();
                        break;

                    case CharacterClass.Priest:
                    case CharacterClass.Druid:
                        artifactBias = new PriestlyArtifactBias();
                        break;

                    case CharacterClass.Rogue:
                        artifactBias = new RogueArtifactBias();
                        warriorArtifactBias = 25;
                        break;

                    case CharacterClass.Ranger:
                        artifactBias = new RangerArtifactBias();
                        warriorArtifactBias = 30;
                        break;

                    case CharacterClass.Paladin:
                        artifactBias = new PriestlyArtifactBias();
                        warriorArtifactBias = 40;
                        break;

                    case CharacterClass.WarriorMage:
                        artifactBias = new MageArtifactBias();
                        warriorArtifactBias = 40;
                        break;

                    case CharacterClass.Fanatic:
                        artifactBias = new ChaosArtifactBias();
                        warriorArtifactBias = 40;
                        break;

                    case CharacterClass.Monk:
                    case CharacterClass.Mystic:
                        artifactBias = new PriestlyArtifactBias();
                        break;

                    case CharacterClass.Mindcrafter:
                        if (Program.Rng.DieRoll(5) > 2)
                        {
                            artifactBias = new PriestlyArtifactBias();
                        }
                        break;
                }
            }
            if (Program.Rng.DieRoll(100) <= warriorArtifactBias && fromScroll)
            {
                artifactBias = new WarriorArtifactBias();
            }
            string newName;
            if (!fromScroll && Program.Rng.DieRoll(Constants.ArifactCurseChance) == 1)
            {
                aCursed = true;
            }
            while (Program.Rng.DieRoll(powers) == 1 || Program.Rng.DieRoll(7) == 1 || Program.Rng.DieRoll(10) == 1)
            {
                powers++;
            }
            if (!aCursed && Program.Rng.DieRoll(Constants.WeirdLuck) == 1)
            {
                powers *= 2;
            }
            if (aCursed)
            {
                powers /= 2;
            }
            while (powers-- != 0)
            {
                switch (Program.Rng.DieRoll(maxType))
                {
                    case 1:
                    case 2:
                        ApplyRandomBonuses(ref artifactBias);
                        hasPval = true;
                        break;

                    case 3:
                    case 4:
                        ApplyRandomResistance(ref artifactBias, 0);
                        break;

                    case 5:
                        ApplyRandomMiscPower(ref artifactBias);
                        break;

                    case 6:
                    case 7:
                        ApplyRandomSlaying(ref artifactBias);
                        break;

                    default:
                        powers++;
                        break;
                }
            }
            if (hasPval)
            {
                if (RandartFlags1.IsSet(ItemFlag1.Blows))
                {
                    TypeSpecificValue = Program.Rng.DieRoll(2) + 1;
                }
                else
                {
                    do
                    {
                        TypeSpecificValue++;
                    } while (TypeSpecificValue < Program.Rng.DieRoll(5) ||
                             Program.Rng.DieRoll(TypeSpecificValue) == 1);
                }
                if (TypeSpecificValue > 4 && Program.Rng.DieRoll(Constants.WeirdLuck) != 1)
                {
                    TypeSpecificValue = 4;
                }
            }
            if (Category >= ItemCategory.Boots)
            {
                BonusArmourClass +=
                    Program.Rng.DieRoll(BonusArmourClass > 19 ? 1 : 20 - BonusArmourClass);
            }
            else
            {
                BonusToHit += Program.Rng.DieRoll(BonusToHit > 19 ? 1 : 20 - BonusToHit);
                BonusDamage += Program.Rng.DieRoll(BonusDamage > 19 ? 1 : 20 - BonusDamage);
            }
            RandartFlags3.Set(ItemFlag3.IgnoreAcid | ItemFlag3.IgnoreElec | ItemFlag3.IgnoreFire |
                                    ItemFlag3.IgnoreCold);
            int totalFlags = FlagBasedCost(TypeSpecificValue);
            if (aCursed)
            {
                CurseRandart();
            }
            if (!aCursed && Program.Rng.DieRoll(Category >= ItemCategory.Boots
                    ? Constants.ActivationChance * 2
                    : Constants.ActivationChance) == 1)
            {
                BonusPowerSubType = null;
                GiveActivationPower(ref artifactBias);
            }
            if (fromScroll)
            {
                IdentifyFully();
                IdentifyFlags.Set(Constants.IdentStoreb);
                if (!Gui.GetString("What do you want to call the artifact? ", out string dummyName, "(a DIY artifact)",
                    80))
                {
                    newName = "(a DIY artifact)";
                }
                else
                {
                    newName = "called '" + dummyName + "'";
                }
                BecomeFlavourAware();
                BecomeKnown();
                IdentifyFlags.Set(Constants.IdentMental);
            }
            else
            {
                newName = GetTableName();
            }
            RandartName = newName;
            return true;
        }

        public void GetFixedArtifactResistances()
        {
            bool giveResistance = false, givePower = false;
            if (FixedArtifactIndex == FixedArtifactId.HelmTerrorMask)
            {
                if (SaveGame.Instance.Player.ProfessionIndex == CharacterClass.Warrior)
                {
                    givePower = true;
                    giveResistance = true;
                }
                else
                {
                    RandartFlags3.Set(ItemFlag3.Cursed | ItemFlag3.HeavyCurse | ItemFlag3.Aggravate |
                                            ItemFlag3.DreadCurse);
                    IdentifyFlags.Set(Constants.IdentCursed);
                    return;
                }
            }
            switch (FixedArtifactIndex)
            {
                case FixedArtifactId.ArmourOfTheOrcs:
                case FixedArtifactId.ChainMailHeartguard:
                case FixedArtifactId.ArmourOfTheOgreLords:
                case FixedArtifactId.ArmourOfTheKoboldChief:
                case FixedArtifactId.ArmourOfSerpents:
                case FixedArtifactId.ShieldRawhide:
                case FixedArtifactId.ShieldOfStability:
                case FixedArtifactId.CapOfTheMindcrafter:
                case FixedArtifactId.ShadowCloakOfNyogtha:
                case FixedArtifactId.BootsOfTheBlackReaver:
                case FixedArtifactId.ShieldVitriol:
                case FixedArtifactId.DaggerOfHope:
                case FixedArtifactId.DaggerOfCharity:
                case FixedArtifactId.DaggerOfFaith:
                case FixedArtifactId.SmallSwordSting:
                case FixedArtifactId.HammerJustice:
                case FixedArtifactId.ScaleMailWyvernscale:
                    {
                        giveResistance = true;
                    }
                    break;

                case FixedArtifactId.MainGaucheOfDefence:
                case FixedArtifactId.SwordBrightblade:
                case FixedArtifactId.SwordBlackIce:
                case FixedArtifactId.SwordOfEverflame:
                case FixedArtifactId.SwordFiretongue:
                case FixedArtifactId.SwordDragonSlayer:
                case FixedArtifactId.ScimitarSoulsword:
                case FixedArtifactId.BowOfSerpents:
                case FixedArtifactId.CrossbowOfDeath:
                    {
                        if (Program.Rng.DieRoll(2) == 1)
                        {
                            giveResistance = true;
                        }
                        else
                        {
                            givePower = true;
                        }
                    }
                    break;

                case FixedArtifactId.RingOfElementalPowerIce:
                case FixedArtifactId.RingOfElementalPowerStorm:
                case FixedArtifactId.CrownOfMisery:
                case FixedArtifactId.CestiOfCombat:
                case FixedArtifactId.CloakOfTheSwashbuckler:
                case FixedArtifactId.TridentOfTheGnorri:
                case FixedArtifactId.QuarterstaffOfAtal:
                    {
                        givePower = true;
                    }
                    break;

                case FixedArtifactId.RingOfSet:
                case FixedArtifactId.CrownOfTheSun:
                case FixedArtifactId.HammerMjolnir:
                    {
                        givePower = true;
                        giveResistance = true;
                    }
                    break;
            }
            if (givePower)
            {
                BonusPowerType = Enumerations.RareItemType.SpecialAbility;
                if (BonusPowerType != 0)
                {
                    BonusPowerSubType = ActivationPowerManager.GetRandom();
                }
            }
            IArtifactBias artifactBias = null;
            if (giveResistance)
            {
                ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(22) + 16);
            }
        }

        public bool MakeObject(bool good, bool great)
        {
            int prob = good ? 10 : 1000;
            int baselevel = good ? SaveGame.Instance.Level.ObjectLevel + 10 : SaveGame.Instance.Level.ObjectLevel;
            if (Program.Rng.RandomLessThan(prob) != 0 || !MakeFixedArtifact())
            {
                if (good)
                {
                    PrepareAllocationTable(ItemType.KindIsGood);
                }
                ItemType kIdx = ItemType.RandomItemType(baselevel);
                if (good)
                {
                    PrepareAllocationTable(null);
                }
                if (kIdx == null)
                {
                    return false;
                }
                AssignItemType(kIdx);
            }
            ApplyMagic(SaveGame.Instance.Level.ObjectLevel, true, good, great);
            switch (Category)
            {
                case ItemCategory.Spike:
                case ItemCategory.Shot:
                case ItemCategory.Arrow:
                case ItemCategory.Bolt:
                    {
                        Count = Program.Rng.DiceRoll(6, 7);
                        break;
                    }
            }
            if (!IsCursed() && !IsBroken() &&
                ItemType.Level > SaveGame.Instance.Difficulty)
            {
                if (SaveGame.Instance.Level != null)
                {
                    SaveGame.Instance.Level.TreasureRating +=
                        ItemType.Level - SaveGame.Instance.Difficulty;
                }
            }
            return true;
        }

        private void ApplyDragonscaleResistance()
        {
            do
            {
                IArtifactBias artifactBias = null;
                if (Program.Rng.DieRoll(4) == 1)
                {
                    ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(14) + 4);
                }
                else
                {
                    ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(22) + 16);
                }
            } while (Program.Rng.DieRoll(2) == 1);
        }

        private bool ApplyFixedArtifact()
        {
            if (Count != 1)
            {
                return false;
            }
            foreach (System.Collections.Generic.KeyValuePair<FixedArtifactId, FixedArtifact> pair in Profile.Instance.FixedArtifacts)
            {
                FixedArtifact aPtr = pair.Value;
                if (aPtr.HasOwnType)
                {
                    continue;
                }
                if (aPtr.CurNum != 0)
                {
                    continue;
                }
                if (aPtr.Tval != Category)
                {
                    continue;
                }
                if (aPtr.Sval != ItemSubCategory)
                {
                    continue;
                }
                if (aPtr.Level > SaveGame.Instance.Difficulty)
                {
                    int d = (aPtr.Level - SaveGame.Instance.Difficulty) * 2;
                    if (Program.Rng.RandomLessThan(d) != 0)
                    {
                        continue;
                    }
                }
                if (Program.Rng.RandomLessThan(aPtr.Rarity) != 0)
                {
                    continue;
                }
                FixedArtifactIndex = pair.Key;
                GetFixedArtifactResistances();
                return true;
            }
            return false;
        }

        private void ApplyMagicToArmour(int level, int power)
        {
            int toac1 = Program.Rng.DieRoll(5) + GetBonusValue(5, level);
            int toac2 = GetBonusValue(10, level);
            IArtifactBias artifactBias = null;
            if (power > 0)
            {
                BonusArmourClass += toac1;
                if (power > 1)
                {
                    BonusArmourClass += toac2;
                }
            }
            else if (power < 0)
            {
                BonusArmourClass -= toac1;
                if (power < -1)
                {
                    BonusArmourClass -= toac2;
                }
                if (BonusArmourClass < 0)
                {
                    IdentifyFlags.Set(Constants.IdentCursed);
                }
            }
            switch (Category)
            {
                case ItemCategory.DragArmor:
                    {
                        if (SaveGame.Instance.Level != null)
                        {
                            SaveGame.Instance.Level.TreasureRating += 30;
                        }
                        break;
                    }
                case ItemCategory.HardArmor:
                case ItemCategory.SoftArmor:
                    {
                        if (power > 1)
                        {
                            if (Category == ItemCategory.SoftArmor &&
                                ItemSubCategory == SoftArmourType.SvRobe && Program.Rng.RandomLessThan(100) < 10)
                            {
                                RareItemTypeIndex = Enumerations.RareItemType.ArmourOfPermanence;
                                break;
                            }
                            switch (Program.Rng.DieRoll(21))
                            {
                                case 1:
                                case 2:
                                case 3:
                                case 4:
                                    {
                                        RareItemTypeIndex = Enumerations.RareItemType.ArmourOfResistAcid;
                                        break;
                                    }
                                case 5:
                                case 6:
                                case 7:
                                case 8:
                                    {
                                        RareItemTypeIndex = Enumerations.RareItemType.ArmourOfResistLightning;
                                        break;
                                    }
                                case 9:
                                case 10:
                                case 11:
                                case 12:
                                    {
                                        RareItemTypeIndex = Enumerations.RareItemType.ArmourOfResistFire;
                                        break;
                                    }
                                case 13:
                                case 14:
                                case 15:
                                case 16:
                                    {
                                        RareItemTypeIndex = Enumerations.RareItemType.ArmourOfResistCold;
                                        break;
                                    }
                                case 17:
                                case 18:
                                    {
                                        RareItemTypeIndex = Enumerations.RareItemType.ArmourOfResistance;
                                        if (Program.Rng.DieRoll(4) == 1)
                                        {
                                            RandartFlags2.Set(ItemFlag2.ResPois);
                                        }
                                        ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(22) + 16);
                                        break;
                                    }
                                case 20:
                                case 21:
                                    {
                                        RareItemTypeIndex = Enumerations.RareItemType.ArmourOfYith;
                                        break;
                                    }
                                default:
                                    {
                                        CreateRandart(false);
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                case ItemCategory.Shield:
                    {
                        if (ItemSubCategory == ShieldType.SvDragonShield)
                        {
                            if (SaveGame.Instance.Level != null)
                            {
                                SaveGame.Instance.Level.TreasureRating += 5;
                            }
                            ApplyDragonscaleResistance();
                        }
                        else
                        {
                            if (power > 1)
                            {
                                switch (Program.Rng.DieRoll(23))
                                {
                                    case 1:
                                    case 11:
                                        {
                                            RareItemTypeIndex = Enumerations.RareItemType.ShieldOfResistAcid;
                                            break;
                                        }
                                    case 2:
                                    case 3:
                                    case 4:
                                    case 12:
                                    case 13:
                                    case 14:
                                        {
                                            RareItemTypeIndex = Enumerations.RareItemType.ShieldOfResistLightning;
                                            break;
                                        }
                                    case 5:
                                    case 6:
                                    case 15:
                                    case 16:
                                        {
                                            RareItemTypeIndex = Enumerations.RareItemType.ShieldOfResistFire;
                                            break;
                                        }
                                    case 7:
                                    case 8:
                                    case 9:
                                    case 17:
                                    case 18:
                                    case 19:
                                        {
                                            RareItemTypeIndex = Enumerations.RareItemType.ShieldOfResistCold;
                                            break;
                                        }
                                    case 10:
                                    case 20:
                                        {
                                            ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(34) + 4);
                                            if (Program.Rng.DieRoll(4) == 1)
                                            {
                                                RandartFlags2.Set(ItemFlag2.ResPois);
                                            }
                                            RareItemTypeIndex = Enumerations.RareItemType.ShieldOfResistance;
                                            break;
                                        }
                                    case 21:
                                    case 22:
                                        {
                                            RareItemTypeIndex = Enumerations.RareItemType.ShieldOfReflection;
                                            break;
                                        }
                                    default:
                                        {
                                            CreateRandart(false);
                                            break;
                                        }
                                }
                            }
                        }
                        break;
                    }
                case ItemCategory.Gloves:
                    {
                        if (power > 1)
                        {
                            if (Program.Rng.DieRoll(20) == 1)
                            {
                                CreateRandart(false);
                            }
                            else
                            {
                                switch (Program.Rng.DieRoll(10))
                                {
                                    case 1:
                                    case 2:
                                    case 3:
                                    case 4:
                                        {
                                            RareItemTypeIndex = Enumerations.RareItemType.GlovesOfFreeAction;
                                            break;
                                        }
                                    case 5:
                                    case 6:
                                    case 7:
                                        {
                                            RareItemTypeIndex = Enumerations.RareItemType.GlovesOfSlaying;
                                            break;
                                        }
                                    case 8:
                                    case 9:
                                        {
                                            RareItemTypeIndex = Enumerations.RareItemType.GlovesOfAgility;
                                            break;
                                        }
                                    case 10:
                                        {
                                            RareItemTypeIndex = Enumerations.RareItemType.GlovesOfPower;
                                            ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(22) + 16);
                                            break;
                                        }
                                }
                            }
                        }
                        else if (power < -1)
                        {
                            switch (Program.Rng.DieRoll(2))
                            {
                                case 1:
                                    {
                                        RareItemTypeIndex = Enumerations.RareItemType.GlovesOfClumsiness;
                                        break;
                                    }
                                default:
                                    {
                                        RareItemTypeIndex = Enumerations.RareItemType.GlovesOfWeakness;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                case ItemCategory.Boots:
                    {
                        if (power > 1)
                        {
                            if (Program.Rng.DieRoll(20) == 1)
                            {
                                CreateRandart(false);
                            }
                            else
                            {
                                switch (Program.Rng.DieRoll(24))
                                {
                                    case 1:
                                        {
                                            RareItemTypeIndex = Enumerations.RareItemType.BootsOfSpeed;
                                            break;
                                        }
                                    case 2:
                                    case 3:
                                    case 4:
                                    case 5:
                                        {
                                            RareItemTypeIndex = Enumerations.RareItemType.BootsOfFreeAction;
                                            break;
                                        }
                                    case 6:
                                    case 7:
                                    case 8:
                                    case 9:
                                    case 10:
                                    case 11:
                                    case 12:
                                    case 13:
                                        {
                                            RareItemTypeIndex = Enumerations.RareItemType.BootsOfStealth;
                                            break;
                                        }
                                    default:
                                        {
                                            RareItemTypeIndex = Enumerations.RareItemType.BootsWinged;
                                            if (Program.Rng.DieRoll(2) == 1)
                                            {
                                                ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(22) + 16);
                                            }
                                            break;
                                        }
                                }
                            }
                        }
                        else if (power < -1)
                        {
                            switch (Program.Rng.DieRoll(3))
                            {
                                case 1:
                                    {
                                        RareItemTypeIndex = Enumerations.RareItemType.BootsOfNoise;
                                        break;
                                    }
                                case 2:
                                    {
                                        RareItemTypeIndex = Enumerations.RareItemType.BootsOfSlowness;
                                        break;
                                    }
                                case 3:
                                    {
                                        RareItemTypeIndex = Enumerations.RareItemType.BootsOfAnnoyance;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                case ItemCategory.Crown:
                    {
                        if (power > 1)
                        {
                            if (Program.Rng.DieRoll(20) == 1)
                            {
                                CreateRandart(false);
                            }
                            else
                            {
                                switch (Program.Rng.DieRoll(8))
                                {
                                    case 1:
                                        {
                                            RareItemTypeIndex = Enumerations.RareItemType.HatOfTheMagi;
                                            ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(22) + 16);
                                            break;
                                        }
                                    case 2:
                                        {
                                            RareItemTypeIndex = Enumerations.RareItemType.HatOfMight;
                                            ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(22) + 16);
                                            break;
                                        }
                                    case 3:
                                        {
                                            RareItemTypeIndex = Enumerations.RareItemType.HatOfTelepathy;
                                            break;
                                        }
                                    case 4:
                                        {
                                            RareItemTypeIndex = Enumerations.RareItemType.HatOfRegeneration;
                                            break;
                                        }
                                    case 5:
                                    case 6:
                                        {
                                            RareItemTypeIndex = Enumerations.RareItemType.HatOfLordliness;
                                            ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(22) + 16);
                                            break;
                                        }
                                    default:
                                        {
                                            RareItemTypeIndex = Enumerations.RareItemType.HatOfSeeing;
                                            if (Program.Rng.DieRoll(3) == 1)
                                            {
                                                RandartFlags3.Set(ItemFlag3.Telepathy);
                                            }
                                            break;
                                        }
                                }
                            }
                        }
                        else if (power < -1)
                        {
                            switch (Program.Rng.DieRoll(7))
                            {
                                case 1:
                                case 2:
                                    {
                                        RareItemTypeIndex = Enumerations.RareItemType.HatOfStupidity;
                                        break;
                                    }
                                case 3:
                                case 4:
                                    {
                                        RareItemTypeIndex = Enumerations.RareItemType.HatOfNaivety;
                                        break;
                                    }
                                case 5:
                                    {
                                        RareItemTypeIndex = Enumerations.RareItemType.HatOfUgliness;
                                        break;
                                    }
                                case 6:
                                    {
                                        RareItemTypeIndex = Enumerations.RareItemType.HatOfSickliness;
                                        break;
                                    }
                                case 7:
                                    {
                                        RareItemTypeIndex = Enumerations.RareItemType.HatOfTeleportation;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                case ItemCategory.Helm:
                    {
                        if (ItemSubCategory == HelmType.SvDragonHelm)
                        {
                            if (SaveGame.Instance.Level != null)
                            {
                                SaveGame.Instance.Level.TreasureRating += 5;
                            }
                            ApplyDragonscaleResistance();
                        }
                        else
                        {
                            if (power > 1)
                            {
                                if (Program.Rng.DieRoll(20) == 1)
                                {
                                    CreateRandart(false);
                                }
                                else
                                {
                                    switch (Program.Rng.DieRoll(14))
                                    {
                                        case 1:
                                        case 2:
                                            {
                                                RareItemTypeIndex = Enumerations.RareItemType.HatOfIntelligence;
                                                break;
                                            }
                                        case 3:
                                        case 4:
                                            {
                                                RareItemTypeIndex = Enumerations.RareItemType.HatOfWisdom;
                                                break;
                                            }
                                        case 5:
                                        case 6:
                                            {
                                                RareItemTypeIndex = Enumerations.RareItemType.HatOfBeauty;
                                                break;
                                            }
                                        case 7:
                                        case 8:
                                            {
                                                RareItemTypeIndex = Enumerations.RareItemType.HatOfSeeing;
                                                if (Program.Rng.DieRoll(7) == 1)
                                                {
                                                    RandartFlags3.Set(ItemFlag3.Telepathy);
                                                }
                                                break;
                                            }
                                        case 9:
                                        case 10:
                                            {
                                                RareItemTypeIndex = Enumerations.RareItemType.HatOfLight;
                                                break;
                                            }
                                        default:
                                            {
                                                RareItemTypeIndex = Enumerations.RareItemType.HatOfInfravision;
                                                break;
                                            }
                                    }
                                }
                            }
                            else if (power < -1)
                            {
                                switch (Program.Rng.DieRoll(7))
                                {
                                    case 1:
                                    case 2:
                                        {
                                            RareItemTypeIndex = Enumerations.RareItemType.HatOfStupidity;
                                            break;
                                        }
                                    case 3:
                                    case 4:
                                        {
                                            RareItemTypeIndex = Enumerations.RareItemType.HatOfNaivety;
                                            break;
                                        }
                                    case 5:
                                        {
                                            RareItemTypeIndex = Enumerations.RareItemType.HatOfUgliness;
                                            break;
                                        }
                                    case 6:
                                        {
                                            RareItemTypeIndex = Enumerations.RareItemType.HatOfSickliness;
                                            break;
                                        }
                                    case 7:
                                        {
                                            RareItemTypeIndex = Enumerations.RareItemType.HatOfTeleportation;
                                            break;
                                        }
                                }
                            }
                        }
                        break;
                    }
                case ItemCategory.Cloak:
                    {
                        if (ItemSubCategory == CloakType.SvElvenCloak)
                        {
                            TypeSpecificValue = Program.Rng.DieRoll(4);
                        }
                        if (power > 1)
                        {
                            if (Program.Rng.DieRoll(20) == 1)
                            {
                                CreateRandart(false);
                            }
                            else
                            {
                                switch (Program.Rng.DieRoll(19))
                                {
                                    case 1:
                                    case 2:
                                    case 3:
                                    case 4:
                                    case 5:
                                    case 6:
                                    case 7:
                                    case 8:
                                        {
                                            RareItemTypeIndex = Enumerations.RareItemType.CloakOfProtection;
                                            break;
                                        }
                                    case 9:
                                    case 10:
                                    case 11:
                                    case 12:
                                    case 13:
                                    case 14:
                                    case 15:
                                    case 16:
                                        {
                                            RareItemTypeIndex = Enumerations.RareItemType.CloakOfStealth;
                                            break;
                                        }
                                    case 17:
                                        {
                                            RareItemTypeIndex = Enumerations.RareItemType.CloakOfAman;
                                            break;
                                        }
                                    case 18:
                                        {
                                            RareItemTypeIndex = Enumerations.RareItemType.CloakOfElectricity;
                                            break;
                                        }
                                    default:
                                        {
                                            RareItemTypeIndex = Enumerations.RareItemType.CloakOfImmolation;
                                            break;
                                        }
                                }
                            }
                        }
                        else if (power < -1)
                        {
                            switch (Program.Rng.DieRoll(3))
                            {
                                case 1:
                                    {
                                        RareItemTypeIndex = Enumerations.RareItemType.CloakOfIrritation;
                                        break;
                                    }
                                case 2:
                                    {
                                        RareItemTypeIndex = Enumerations.RareItemType.CloakOfVulnerability;
                                        break;
                                    }
                                case 3:
                                    {
                                        RareItemTypeIndex = Enumerations.RareItemType.CloakOfEnveloping;
                                        break;
                                    }
                            }
                        }
                        break;
                    }
            }
        }

        private void ApplyMagicToJewellery(int level, int power)
        {
            IArtifactBias artifactBias = null;
            switch (Category)
            {
                case ItemCategory.Ring:
                    {
                        switch (ItemSubCategory)
                        {
                            case RingType.Attacks:
                                {
                                    TypeSpecificValue = GetBonusValue(3, level);
                                    if (TypeSpecificValue < 1)
                                    {
                                        TypeSpecificValue = 1;
                                    }
                                    if (power < 0)
                                    {
                                        IdentifyFlags.Set(Constants.IdentBroken);
                                        IdentifyFlags.Set(Constants.IdentCursed);
                                        TypeSpecificValue = 0 - TypeSpecificValue;
                                    }
                                    break;
                                }
                            case RingType.Str:
                            case RingType.Con:
                            case RingType.Dex:
                            case RingType.Int:
                                {
                                    TypeSpecificValue = 1 + GetBonusValue(5, level);
                                    if (power < 0)
                                    {
                                        IdentifyFlags.Set(Constants.IdentBroken);
                                        IdentifyFlags.Set(Constants.IdentCursed);
                                        TypeSpecificValue = 0 - TypeSpecificValue;
                                    }
                                    break;
                                }
                            case RingType.Speed:
                                {
                                    TypeSpecificValue = Program.Rng.DieRoll(5) + GetBonusValue(5, level);
                                    while (Program.Rng.RandomLessThan(100) < 50)
                                    {
                                        TypeSpecificValue++;
                                    }
                                    if (power < 0)
                                    {
                                        IdentifyFlags.Set(Constants.IdentBroken);
                                        IdentifyFlags.Set(Constants.IdentCursed);
                                        TypeSpecificValue = 0 - TypeSpecificValue;
                                        break;
                                    }
                                    if (SaveGame.Instance.Level != null)
                                    {
                                        SaveGame.Instance.Level.TreasureRating += 25;
                                    }
                                    break;
                                }
                            case RingType.Lordly:
                                {
                                    do
                                    {
                                        ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(20) + 18);
                                    } while (Program.Rng.DieRoll(4) == 1);
                                    BonusArmourClass = 10 + Program.Rng.DieRoll(5) + GetBonusValue(10, level);
                                    if (SaveGame.Instance.Level != null)
                                    {
                                        SaveGame.Instance.Level.TreasureRating += 5;
                                    }
                                }
                                break;

                            case RingType.Searching:
                                {
                                    TypeSpecificValue = 1 + GetBonusValue(5, level);
                                    if (power < 0)
                                    {
                                        IdentifyFlags.Set(Constants.IdentBroken);
                                        IdentifyFlags.Set(Constants.IdentCursed);
                                        TypeSpecificValue = 0 - TypeSpecificValue;
                                    }
                                    break;
                                }
                            case RingType.Flames:
                            case RingType.Acid:
                            case RingType.Ice:
                                {
                                    BonusArmourClass = 5 + Program.Rng.DieRoll(5) + GetBonusValue(10, level);
                                    break;
                                }
                            case RingType.Weakness:
                            case RingType.Stupidity:
                                {
                                    IdentifyFlags.Set(Constants.IdentBroken);
                                    IdentifyFlags.Set(Constants.IdentCursed);
                                    TypeSpecificValue = 0 - (1 + GetBonusValue(5, level));
                                    break;
                                }
                            case RingType.Woe:
                                {
                                    IdentifyFlags.Set(Constants.IdentBroken);
                                    IdentifyFlags.Set(Constants.IdentCursed);
                                    BonusArmourClass = 0 - (5 + GetBonusValue(10, level));
                                    TypeSpecificValue = 0 - (1 + GetBonusValue(5, level));
                                    break;
                                }
                            case RingType.Damage:
                                {
                                    BonusDamage = 5 + Program.Rng.DieRoll(8) + GetBonusValue(10, level);
                                    if (power < 0)
                                    {
                                        IdentifyFlags.Set(Constants.IdentBroken);
                                        IdentifyFlags.Set(Constants.IdentCursed);
                                        BonusDamage = 0 - BonusDamage;
                                    }
                                    break;
                                }
                            case RingType.Accuracy:
                                {
                                    BonusToHit = 5 + Program.Rng.DieRoll(8) + GetBonusValue(10, level);
                                    if (power < 0)
                                    {
                                        IdentifyFlags.Set(Constants.IdentBroken);
                                        IdentifyFlags.Set(Constants.IdentCursed);
                                        BonusToHit = 0 - BonusToHit;
                                    }
                                    break;
                                }
                            case RingType.Protection:
                                {
                                    BonusArmourClass = 5 + Program.Rng.DieRoll(8) + GetBonusValue(10, level);
                                    if (power < 0)
                                    {
                                        IdentifyFlags.Set(Constants.IdentBroken);
                                        IdentifyFlags.Set(Constants.IdentCursed);
                                        BonusArmourClass = 0 - BonusArmourClass;
                                    }
                                    break;
                                }
                            case RingType.Slaying:
                                {
                                    BonusDamage = Program.Rng.DieRoll(7) + GetBonusValue(10, level);
                                    BonusToHit = Program.Rng.DieRoll(7) + GetBonusValue(10, level);
                                    if (power < 0)
                                    {
                                        IdentifyFlags.Set(Constants.IdentBroken);
                                        IdentifyFlags.Set(Constants.IdentCursed);
                                        BonusToHit = 0 - BonusToHit;
                                        BonusDamage = 0 - BonusDamage;
                                    }
                                    break;
                                }
                        }
                        break;
                    }
                case ItemCategory.Amulet:
                    {
                        switch (ItemSubCategory)
                        {
                            case AmuletType.Wisdom:
                            case AmuletType.Charisma:
                                {
                                    TypeSpecificValue = 1 + GetBonusValue(5, level);
                                    if (power < 0)
                                    {
                                        IdentifyFlags.Set(Constants.IdentBroken);
                                        IdentifyFlags.Set(Constants.IdentCursed);
                                        TypeSpecificValue = 0 - TypeSpecificValue;
                                    }
                                    break;
                                }
                            case AmuletType.NoMagic:
                            case AmuletType.NoTele:
                                {
                                    if (power < 0)
                                    {
                                        IdentifyFlags.Set(Constants.IdentCursed);
                                    }
                                    break;
                                }
                            case AmuletType.Resistance:
                                {
                                    if (Program.Rng.DieRoll(3) == 1)
                                    {
                                        ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(34) + 4);
                                    }
                                    if (Program.Rng.DieRoll(5) == 1)
                                    {
                                        RandartFlags2.Set(ItemFlag2.ResPois);
                                    }
                                }
                                break;

                            case AmuletType.Searching:
                                {
                                    TypeSpecificValue = Program.Rng.DieRoll(5) + GetBonusValue(5, level);
                                    if (power < 0)
                                    {
                                        IdentifyFlags.Set(Constants.IdentBroken);
                                        IdentifyFlags.Set(Constants.IdentCursed);
                                        TypeSpecificValue = 0 - TypeSpecificValue;
                                    }
                                    break;
                                }
                            case AmuletType.TheMagi:
                                {
                                    TypeSpecificValue = Program.Rng.DieRoll(5) + GetBonusValue(5, level);
                                    BonusArmourClass = Program.Rng.DieRoll(5) + GetBonusValue(5, level);
                                    if (Program.Rng.DieRoll(3) == 1)
                                    {
                                        RandartFlags3.Set(ItemFlag3.SlowDigest);
                                    }
                                    if (SaveGame.Instance.Level != null)
                                    {
                                        SaveGame.Instance.Level.TreasureRating += 25;
                                    }
                                    break;
                                }
                            case AmuletType.Doom:
                                {
                                    IdentifyFlags.Set(Constants.IdentBroken);
                                    IdentifyFlags.Set(Constants.IdentCursed);
                                    TypeSpecificValue = 0 - (Program.Rng.DieRoll(5) + GetBonusValue(5, level));
                                    BonusArmourClass = 0 - (Program.Rng.DieRoll(5) + GetBonusValue(5, level));
                                    break;
                                }
                        }
                        break;
                    }
            }
        }

        private void ApplyMagicToLightSource(int power)
        {
            if (ItemSubCategory == LightType.Torch)
            {
                if (TypeSpecificValue != 0)
                {
                    TypeSpecificValue = Program.Rng.DieRoll(TypeSpecificValue);
                }
                return;
            }
            if (ItemSubCategory == LightType.Lantern)
            {
                if (TypeSpecificValue != 0)
                {
                    TypeSpecificValue = Program.Rng.DieRoll(TypeSpecificValue);
                }
                return;
            }
            if (power < 0) // Cursed
            {
                switch (Program.Rng.DieRoll(2)) // Cursed
                {
                    case 1:
                        {
                            RareItemTypeIndex = Enumerations.RareItemType.OrbOfIrritation;
                            IdentifyFlags.Set(Constants.IdentBroken);
                            IdentifyFlags.Set(Constants.IdentCursed);
                            break;
                        }
                    case 2:
                        {
                            RareItemTypeIndex = Enumerations.RareItemType.OrbOfInstability;
                            IdentifyFlags.Set(Constants.IdentBroken);
                            IdentifyFlags.Set(Constants.IdentCursed);
                            break;
                        }
                }
            }
            else if (power == 1) // Good
            {
                switch (Program.Rng.DieRoll(30))
                {
                    case 1:
                        {
                            RareItemTypeIndex = Enumerations.RareItemType.OrbOfFlame;
                            break;
                        }
                    case 2:
                        {
                            RareItemTypeIndex = Enumerations.RareItemType.OrbOfFrost;
                            break;
                        }
                    case 3:
                        {
                            RareItemTypeIndex = Enumerations.RareItemType.OrbOfAcid;
                            break;
                        }
                    case 4:
                        {
                            RareItemTypeIndex = Enumerations.RareItemType.OrbOfLightning;
                            break;
                        }
                    case 5:
                        {
                            RareItemTypeIndex = Enumerations.RareItemType.OrbOfLight;
                            break;
                        }
                    case 6:
                        {
                            RareItemTypeIndex = Enumerations.RareItemType.OrbOfDarkness;
                            break;
                        }
                    case 7:
                        {
                            RareItemTypeIndex = Enumerations.RareItemType.OrbOfLife;
                            break;
                        }
                    case 8:
                        {
                            RareItemTypeIndex = Enumerations.RareItemType.OrbOfSight;
                            break;
                        }
                    case 9:
                        {
                            RareItemTypeIndex = Enumerations.RareItemType.OrbOfCourage;
                            break;
                        }
                    case 10:
                        {
                            RareItemTypeIndex = Enumerations.RareItemType.OrbOfCourage;
                            break;
                        }
                    case 11:
                        {
                            RareItemTypeIndex = Enumerations.RareItemType.OrbOfVenom;
                            break;
                        }
                    case 12:
                        {
                            RareItemTypeIndex = Enumerations.RareItemType.OrbOfClarity;
                            break;
                        }
                    case 13:
                        {
                            RareItemTypeIndex = Enumerations.RareItemType.OrbOfSound;
                            break;
                        }
                    case 14:
                        {
                            RareItemTypeIndex = Enumerations.RareItemType.OrbOfChaos;
                            break;
                        }
                    case 15:
                        {
                            RareItemTypeIndex = Enumerations.RareItemType.OrbOfShards;
                            break;
                        }
                    case 16:
                        {
                            RareItemTypeIndex = Enumerations.RareItemType.OrbOfUnlife;
                            break;
                        }
                    case 17:
                        {
                            RareItemTypeIndex = Enumerations.RareItemType.OrbOfStability;
                            break;
                        }
                    case 18:
                        {
                            RareItemTypeIndex = Enumerations.RareItemType.OrbOfMagic;
                            break;
                        }
                    case 19:
                        {
                            RareItemTypeIndex = Enumerations.RareItemType.OrbOfFreedom;
                            break;
                        }
                    case 20:
                        {
                            RareItemTypeIndex = Enumerations.RareItemType.OrbOfStrength;
                            break;
                        }
                    case 21:
                        {
                            RareItemTypeIndex = Enumerations.RareItemType.OrbOfIntelligence;
                            break;
                        }
                    case 22:
                        {
                            RareItemTypeIndex = Enumerations.RareItemType.OrbOfWisdom;
                            break;
                        }
                    case 23:
                        {
                            RareItemTypeIndex = Enumerations.RareItemType.OrbOfDexterity;
                            break;
                        }
                    case 24:
                        {
                            RareItemTypeIndex = Enumerations.RareItemType.OrbOfConstitution;
                            break;
                        }
                    case 25:
                        {
                            RareItemTypeIndex = Enumerations.RareItemType.OrbOfCharisma;
                            break;
                        }
                    case 26:
                        {
                            RareItemTypeIndex = Enumerations.RareItemType.OrbOfLightness;
                            break;
                        }
                    case 27:
                        {
                            RareItemTypeIndex = Enumerations.RareItemType.OrbOfInsight;
                            break;
                        }
                    case 28:
                        {
                            RareItemTypeIndex = Enumerations.RareItemType.OrbOfTheMind;
                            break;
                        }
                    case 29:
                        {
                            RareItemTypeIndex = Enumerations.RareItemType.OrbOfSustenance;
                            break;
                        }
                    case 30:
                        {
                            RareItemTypeIndex = Enumerations.RareItemType.OrbOfHealth;
                            break;
                        }
                }
            }
            else if (power == 2) // Great
            {
                RareItemTypeIndex = Enumerations.RareItemType.OrbOfPower;
                for (int i = 0; i < 3; i++)
                {
                    switch (Program.Rng.DieRoll(30))
                    {
                        case 1:
                        case 2:
                            {
                                RandartFlags2.Set(ItemFlag2.ResDark);
                                break;
                            }
                        case 3:
                            {
                                RandartFlags2.Set(ItemFlag2.ResLight);
                                break;
                            }
                        case 4:
                            {
                                RandartFlags2.Set(ItemFlag2.ResBlind);
                                break;
                            }
                        case 5:
                            {
                                RandartFlags2.Set(ItemFlag2.ResFear);
                                break;
                            }
                        case 6:
                            {
                                RandartFlags2.Set(ItemFlag2.ResAcid);
                                break;
                            }
                        case 7:
                            {
                                RandartFlags2.Set(ItemFlag2.ResElec);
                                break;
                            }
                        case 8:
                            {
                                RandartFlags2.Set(ItemFlag2.ResFire);
                                break;
                            }
                        case 9:
                            {
                                RandartFlags2.Set(ItemFlag2.ResCold);
                                break;
                            }
                        case 10:
                            {
                                RandartFlags2.Set(ItemFlag2.ResPois);
                                break;
                            }
                        case 11:
                            {
                                RandartFlags2.Set(ItemFlag2.ResConf);
                                break;
                            }
                        case 12:
                            {
                                RandartFlags2.Set(ItemFlag2.ResSound);
                                break;
                            }
                        case 13:
                            {
                                RandartFlags2.Set(ItemFlag2.ResShards);
                                break;
                            }
                        case 14:
                            {
                                RandartFlags2.Set(ItemFlag2.ResNether);
                                break;
                            }
                        case 15:
                            {
                                RandartFlags2.Set(ItemFlag2.ResNexus);
                                break;
                            }
                        case 16:
                            {
                                RandartFlags2.Set(ItemFlag2.ResChaos);
                                break;
                            }
                        case 17:
                            {
                                RandartFlags2.Set(ItemFlag2.ResDisen);
                                break;
                            }
                        case 18:
                            {
                                RandartFlags2.Set(ItemFlag2.FreeAct);
                                break;
                            }
                        case 19:
                            {
                                RandartFlags2.Set(ItemFlag2.HoldLife);
                                break;
                            }
                        case 20:
                            {
                                RandartFlags2.Set(ItemFlag2.SustStr);
                                break;
                            }
                        case 21:
                            {
                                RandartFlags2.Set(ItemFlag2.SustInt);
                                break;
                            }
                        case 22:
                            {
                                RandartFlags2.Set(ItemFlag2.SustWis);
                                break;
                            }
                        case 23:
                            {
                                RandartFlags2.Set(ItemFlag2.SustDex);
                                break;
                            }
                        case 24:
                            {
                                RandartFlags2.Set(ItemFlag2.SustCon);
                                break;
                            }
                        case 25:
                            {
                                RandartFlags2.Set(ItemFlag2.SustCha);
                                break;
                            }
                        case 26:
                            {
                                RandartFlags3.Set(ItemFlag3.Feather);
                                break;
                            }
                        case 27:
                            {
                                RandartFlags3.Set(ItemFlag3.SeeInvis);
                                break;
                            }
                        case 28:
                            {
                                RandartFlags3.Set(ItemFlag3.Telepathy);
                                break;
                            }
                        case 29:
                            {
                                RandartFlags3.Set(ItemFlag3.SlowDigest);
                                break;
                            }
                        case 30:
                            {
                                RandartFlags3.Set(ItemFlag3.Regen);
                                break;
                            }
                    }
                }
            }
        }

        private void ApplyMagicToMiscItem()
        {
            switch (Category)
            {
                case ItemCategory.Wand:
                    {
                        ChargeWand();
                        break;
                    }
                case ItemCategory.Staff:
                    {
                        ChargeStaff();
                        break;
                    }
                case ItemCategory.Chest:
                    {
                        if (ItemType.Level <= 0)
                        {
                            break;
                        }
                        TypeSpecificValue =
                            Program.Rng.DieRoll(ItemType.Level);
                        if (TypeSpecificValue > 55)
                        {
                            TypeSpecificValue = (short)(55 + Program.Rng.RandomLessThan(5));
                        }
                        break;
                    }
            }
        }

        private void ApplyMagicToWeapon(int level, int power)
        {
            int tohit1 = Program.Rng.DieRoll(5) + GetBonusValue(5, level);
            int todam1 = Program.Rng.DieRoll(5) + GetBonusValue(5, level);
            int tohit2 = GetBonusValue(10, level);
            int todam2 = GetBonusValue(10, level);
            IArtifactBias artifactBias = null;
            if (power > 0)
            {
                BonusToHit += tohit1;
                BonusDamage += todam1;
                if (power > 1)
                {
                    BonusToHit += tohit2;
                    BonusDamage += todam2;
                }
            }
            else if (power < 0)
            {
                BonusToHit -= tohit1;
                BonusDamage -= todam1;
                if (power < -1)
                {
                    BonusToHit -= tohit2;
                    BonusDamage -= todam2;
                }
                if (BonusToHit + BonusDamage < 0)
                {
                    IdentifyFlags.Set(Constants.IdentCursed);
                }
            }
            switch (Category)
            {
                case ItemCategory.Digging:
                    {
                        if (power > 1)
                        {
                            RareItemTypeIndex = Enumerations.RareItemType.WeaponOfDigging;
                        }
                        else if (power < -1)
                        {
                            TypeSpecificValue = 0 - (5 + Program.Rng.DieRoll(5));
                        }
                        else if (power < 0)
                        {
                            TypeSpecificValue = 0 - TypeSpecificValue;
                        }
                        break;
                    }
                case ItemCategory.Hafted:
                case ItemCategory.Polearm:
                case ItemCategory.Sword:
                    {
                        if (power > 1)
                        {
                            switch (Program.Rng.DieRoll(Category == ItemCategory.Polearm ? 40 : 42))
                            {
                                case 1:
                                    {
                                        RareItemTypeIndex = Enumerations.RareItemType.WeaponElderSign;
                                        if (Program.Rng.DieRoll(4) == 1)
                                        {
                                            RandartFlags1.Set(ItemFlag1.Blows);
                                            if (TypeSpecificValue > 2)
                                            {
                                                TypeSpecificValue -= Program.Rng.DieRoll(2);
                                            }
                                        }
                                        break;
                                    }
                                case 2:
                                    {
                                        RareItemTypeIndex = Enumerations.RareItemType.WeaponDefender;
                                        if (Program.Rng.DieRoll(3) == 1)
                                        {
                                            RandartFlags2.Set(ItemFlag2.ResPois);
                                        }
                                        ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(22) + 16);
                                        break;
                                    }
                                case 3:
                                    {
                                        RareItemTypeIndex = Enumerations.RareItemType.WeaponOfVitriol;
                                        break;
                                    }
                                case 4:
                                    {
                                        RareItemTypeIndex = Enumerations.RareItemType.WeaponOfShocking;
                                        break;
                                    }
                                case 5:
                                    {
                                        RareItemTypeIndex = Enumerations.RareItemType.WeaponOfBurning;
                                        break;
                                    }
                                case 6:
                                    {
                                        RareItemTypeIndex = Enumerations.RareItemType.WeaponOfFreezing;
                                        break;
                                    }
                                case 7:
                                case 8:
                                    {
                                        RareItemTypeIndex = Enumerations.RareItemType.WeaponOfSlayAnimal;
                                        if (Program.Rng.RandomLessThan(100) < 20)
                                        {
                                            RareItemTypeIndex = Enumerations.RareItemType.WeaponOfAnimalBane;
                                        }
                                        break;
                                    }
                                case 9:
                                case 10:
                                    {
                                        RareItemTypeIndex = Enumerations.RareItemType.WeaponOfSlayDragon;
                                        ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(12) + 4);
                                        if (Program.Rng.RandomLessThan(100) < 20)
                                        {
                                            if (Program.Rng.DieRoll(3) == 1)
                                            {
                                                RandartFlags2.Set(ItemFlag2.ResPois);
                                            }
                                            ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(14) + 4);
                                            RareItemTypeIndex = Enumerations.RareItemType.WeaponOfDragonBane;
                                        }
                                        break;
                                    }
                                case 11:
                                case 12:
                                    {
                                        RareItemTypeIndex = Enumerations.RareItemType.WeaponOfSlayEvil;
                                        if (Program.Rng.RandomLessThan(100) < 20)
                                        {
                                            RandartFlags2.Set(ItemFlag2.ResFear);
                                            RandartFlags3.Set(ItemFlag3.Blessed);
                                            RareItemTypeIndex = Enumerations.RareItemType.WeaponOfEvilBane;
                                        }
                                        break;
                                    }
                                case 13:
                                case 14:
                                    {
                                        RareItemTypeIndex = Enumerations.RareItemType.WeaponOfSlayUndead;
                                        RandartFlags2.Set(ItemFlag2.HoldLife);
                                        if (Program.Rng.RandomLessThan(100) < 20)
                                        {
                                            RandartFlags2.Set(ItemFlag2.ResNether);
                                            RareItemTypeIndex = Enumerations.RareItemType.WeaponOfUndeadBane;
                                        }
                                        break;
                                    }
                                case 15:
                                case 16:
                                case 17:
                                    {
                                        RareItemTypeIndex = Enumerations.RareItemType.WeaponOfSlayOrc;
                                        break;
                                    }
                                case 18:
                                case 19:
                                case 20:
                                    {
                                        RareItemTypeIndex = Enumerations.RareItemType.WeaponOfSlayTroll;
                                        break;
                                    }
                                case 21:
                                case 22:
                                case 23:
                                    {
                                        RareItemTypeIndex = Enumerations.RareItemType.WeaponOfSlayGiant;
                                        break;
                                    }
                                case 24:
                                case 25:
                                case 26:
                                    {
                                        RareItemTypeIndex = Enumerations.RareItemType.WeaponOfSlayDemon;
                                        break;
                                    }
                                case 27:
                                    {
                                        RareItemTypeIndex = Enumerations.RareItemType.WeaponOfKadath;
                                        if (Program.Rng.DieRoll(3) == 1)
                                        {
                                            RandartFlags2.Set(ItemFlag2.ResFear);
                                        }
                                        break;
                                    }
                                case 28:
                                    {
                                        RareItemTypeIndex = Enumerations.RareItemType.WeaponBlessed;
                                        break;
                                    }
                                case 29:
                                case 30:
                                    {
                                        RareItemTypeIndex = Enumerations.RareItemType.WeaponOfExtraAttacks;
                                        break;
                                    }
                                case 31:
                                case 32:
                                    {
                                        RareItemTypeIndex = Enumerations.RareItemType.WeaponVampiric;
                                        break;
                                    }
                                case 33:
                                    {
                                        RareItemTypeIndex = Enumerations.RareItemType.WeaponOfPoisoning;
                                        break;
                                    }
                                case 34:
                                    {
                                        RareItemTypeIndex = Enumerations.RareItemType.WeaponChaotic;
                                        ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(34) + 4);
                                        break;
                                    }
                                case 35:
                                    {
                                        CreateRandart(false);
                                        break;
                                    }
                                case 36:
                                case 37:
                                    {
                                        RareItemTypeIndex = Enumerations.RareItemType.WeaponOfSlaying;
                                        if (Program.Rng.DieRoll(3) == 1)
                                        {
                                            DamageDice *= 2;
                                        }
                                        else
                                        {
                                            do
                                            {
                                                DamageDice++;
                                            } while (Program.Rng.DieRoll(DamageDice) == 1);
                                            do
                                            {
                                                DamageDiceSides++;
                                            } while (Program.Rng.DieRoll(DamageDiceSides) == 1);
                                        }
                                        if (Program.Rng.DieRoll(5) == 1)
                                        {
                                            RandartFlags1.Set(ItemFlag1.BrandPois);
                                        }
                                        if (Category == ItemCategory.Sword && Program.Rng.DieRoll(3) == 1)
                                        {
                                            RandartFlags1.Set(ItemFlag1.Vorpal);
                                        }
                                        break;
                                    }
                                case 38:
                                case 39:
                                    {
                                        RareItemTypeIndex = Enumerations.RareItemType.WeaponPlanarWeapon;
                                        ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(22) + 16);
                                        if (Program.Rng.DieRoll(5) == 1)
                                        {
                                            RandartFlags1.Set(ItemFlag1.SlayDemon);
                                        }
                                        break;
                                    }
                                case 40:
                                    {
                                        RareItemTypeIndex = Enumerations.RareItemType.WeaponOfLaw;
                                        if (Program.Rng.DieRoll(3) == 1)
                                        {
                                            RandartFlags2.Set(ItemFlag2.HoldLife);
                                        }
                                        if (Program.Rng.DieRoll(3) == 1)
                                        {
                                            RandartFlags1.Set(ItemFlag1.Dex);
                                        }
                                        if (Program.Rng.DieRoll(5) == 1)
                                        {
                                            RandartFlags2.Set(ItemFlag2.ResFear);
                                        }
                                        ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(22) + 16);
                                        break;
                                    }
                                default:
                                    {
                                        if (Category == ItemCategory.Sword)
                                        {
                                            RareItemTypeIndex = Enumerations.RareItemType.WeaponOfSharpness;
                                            TypeSpecificValue = GetBonusValue(5, level) + 1;
                                        }
                                        else
                                        {
                                            RareItemTypeIndex = Enumerations.RareItemType.WeaponOfEarthquakes;
                                            if (Program.Rng.DieRoll(3) == 1)
                                            {
                                                RandartFlags1.Set(ItemFlag1.Blows);
                                            }
                                            TypeSpecificValue = GetBonusValue(3, level);
                                        }
                                        break;
                                    }
                            }
                            while (Program.Rng.RandomLessThan(10 * DamageDice * DamageDiceSides) == 0)
                            {
                                DamageDice++;
                            }
                            if (DamageDice > 9)
                            {
                                DamageDice = 9;
                            }
                        }
                        else if (power < -1)
                        {
                            if (Program.Rng.RandomLessThan(Constants.MaxDepth) < level)
                            {
                                RareItemTypeIndex = Enumerations.RareItemType.WeaponOfLeng;
                                if (Program.Rng.DieRoll(6) == 1)
                                {
                                    RandartFlags3.Set(ItemFlag3.DreadCurse);
                                }
                            }
                        }
                        break;
                    }
                case ItemCategory.Bow:
                    {
                        if (power > 1)
                        {
                            switch (Program.Rng.DieRoll(21))
                            {
                                case 1:
                                case 11:
                                    {
                                        RareItemTypeIndex = Enumerations.RareItemType.BowOfExtraMight;
                                        ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(34) + 4);
                                        break;
                                    }
                                case 2:
                                case 12:
                                    {
                                        RareItemTypeIndex = Enumerations.RareItemType.BowOfExtraShots;
                                        break;
                                    }
                                case 3:
                                case 4:
                                case 5:
                                case 6:
                                case 13:
                                case 14:
                                case 15:
                                case 16:
                                    {
                                        RareItemTypeIndex = Enumerations.RareItemType.BowOfVelocity;
                                        break;
                                    }
                                case 7:
                                case 8:
                                case 9:
                                case 10:
                                case 17:
                                case 18:
                                case 19:
                                case 20:
                                    {
                                        RareItemTypeIndex = Enumerations.RareItemType.BowOfAccuracy;
                                        break;
                                    }
                                default:
                                    {
                                        CreateRandart(false);
                                        break;
                                    }
                            }
                        }
                        break;
                    }
                case ItemCategory.Bolt:
                case ItemCategory.Arrow:
                case ItemCategory.Shot:
                    {
                        if (power > 1)
                        {
                            switch (Program.Rng.DieRoll(12))
                            {
                                case 1:
                                case 2:
                                case 3:
                                    {
                                        RareItemTypeIndex = Enumerations.RareItemType.AmmoOfWounding;
                                        break;
                                    }
                                case 4:
                                    {
                                        RareItemTypeIndex = Enumerations.RareItemType.AmmoOfFlame;
                                        break;
                                    }
                                case 5:
                                    {
                                        RareItemTypeIndex = Enumerations.RareItemType.AmmoOfFrost;
                                        break;
                                    }
                                case 6:
                                case 7:
                                    {
                                        RareItemTypeIndex = Enumerations.RareItemType.AmmoOfHurtAnimal;
                                        break;
                                    }
                                case 8:
                                case 9:
                                    {
                                        RareItemTypeIndex = Enumerations.RareItemType.AmmoOfHurtEvil;
                                        break;
                                    }
                                case 10:
                                    {
                                        RareItemTypeIndex = Enumerations.RareItemType.AmmoOfHurtDragon;
                                        break;
                                    }
                                case 11:
                                    {
                                        RareItemTypeIndex = Enumerations.RareItemType.AmmoOfShocking;
                                        break;
                                    }
                                case 12:
                                    {
                                        RareItemTypeIndex = Enumerations.RareItemType.AmmoOfSlaying;
                                        DamageDice++;
                                        break;
                                    }
                            }
                            while (Program.Rng.RandomLessThan(10 * DamageDice * DamageDiceSides) == 0)
                            {
                                DamageDice++;
                            }
                            if (DamageDice > 9)
                            {
                                DamageDice = 9;
                            }
                        }
                        else if (power < -1)
                        {
                            if (Program.Rng.RandomLessThan(Constants.MaxDepth) < level)
                            {
                                RareItemTypeIndex = Enumerations.RareItemType.AmmoOfBackbiting;
                            }
                        }
                        break;
                    }
            }
        }

        private void ApplyRandomBonuses(ref IArtifactBias artifactBias)
        {
            int thisType = Category < ItemCategory.Boots ? 23 : 19;
            if (artifactBias != null)
            {
                if (artifactBias.ApplyBonuses(this))
                {
                    return;
                }
            }
            switch (Program.Rng.DieRoll(thisType))
            {
                case 1:
                case 2:
                    RandartFlags1.Set(ItemFlag1.Str);
                    if (artifactBias == null && Program.Rng.DieRoll(13) != 1)
                    {
                        artifactBias = new StrengthArtifactBias();
                    }
                    else if (artifactBias == null && Program.Rng.DieRoll(7) == 1)
                    {
                        artifactBias = new WarriorArtifactBias();
                    }
                    break;

                case 3:
                case 4:
                    RandartFlags1.Set(ItemFlag1.Int);
                    if (artifactBias == null && Program.Rng.DieRoll(13) != 1)
                    {
                        artifactBias = new IntelligenceArtifactBias();
                    }
                    else if (artifactBias == null && Program.Rng.DieRoll(7) == 1)
                    {
                        artifactBias = new MageArtifactBias();
                    }
                    break;

                case 5:
                case 6:
                    RandartFlags1.Set(ItemFlag1.Wis);
                    if (artifactBias == null && Program.Rng.DieRoll(13) != 1)
                    {
                        artifactBias = new WisdomArtifactBias();
                    }
                    else if (artifactBias == null && Program.Rng.DieRoll(7) == 1)
                    {
                        artifactBias = new PriestlyArtifactBias();
                    }
                    break;

                case 7:
                case 8:
                    RandartFlags1.Set(ItemFlag1.Dex);
                    if (artifactBias == null && Program.Rng.DieRoll(13) != 1)
                    {
                        artifactBias = new DexterityArtifactBias();
                    }
                    else if (artifactBias == null && Program.Rng.DieRoll(7) == 1)
                    {
                        artifactBias = new RogueArtifactBias();
                    }
                    break;

                case 9:
                case 10:
                    RandartFlags1.Set(ItemFlag1.Con);
                    if (artifactBias == null && Program.Rng.DieRoll(13) != 1)
                    {
                        artifactBias = new ConstitutionArtifactBias();
                    }
                    else if (artifactBias == null && Program.Rng.DieRoll(9) == 1)
                    {
                        artifactBias = new RangerArtifactBias();
                    }
                    break;

                case 11:
                case 12:
                    RandartFlags1.Set(ItemFlag1.Cha);
                    if (artifactBias == null && Program.Rng.DieRoll(13) != 1)
                    {
                        artifactBias = new CharismaArtifactBias();
                    }
                    break;

                case 13:
                case 14:
                    RandartFlags1.Set(ItemFlag1.Stealth);
                    if (artifactBias == null && Program.Rng.DieRoll(3) == 1)
                    {
                        artifactBias = new RogueArtifactBias();
                    }
                    break;

                case 15:
                case 16:
                    RandartFlags1.Set(ItemFlag1.Search);
                    if (artifactBias == null && Program.Rng.DieRoll(9) == 1)
                    {
                        artifactBias = new RangerArtifactBias();
                    }
                    break;

                case 17:
                case 18:
                    RandartFlags1.Set(ItemFlag1.Infra);
                    break;

                case 19:
                    RandartFlags1.Set(ItemFlag1.Speed);
                    if (artifactBias == null && Program.Rng.DieRoll(11) == 1)
                    {
                        artifactBias = new RogueArtifactBias();
                    }
                    break;

                case 20:
                case 21:
                    RandartFlags1.Set(ItemFlag1.Tunnel);
                    break;

                case 22:
                case 23:
                    if (Category == ItemCategory.Bow)
                    {
                        ApplyRandomBonuses(ref artifactBias);
                    }
                    else
                    {
                        RandartFlags1.Set(ItemFlag1.Blows);
                        if (artifactBias == null && Program.Rng.DieRoll(11) == 1)
                        {
                            artifactBias = new WarriorArtifactBias();
                        }
                    }
                    break;
            }
        }

        private void ApplyRandomMiscPower(ref IArtifactBias artifactBias)
        {
            if (artifactBias != null)
            {
                artifactBias.ApplyMiscPowers(this);
            }
            switch (Program.Rng.DieRoll(31))
            {
                case 1:
                    RandartFlags2.Set(ItemFlag2.SustStr);
                    if (artifactBias == null)
                    {
                        artifactBias = new StrengthArtifactBias();
                    }
                    break;

                case 2:
                    RandartFlags2.Set(ItemFlag2.SustInt);
                    if (artifactBias == null)
                    {
                        artifactBias = new IntelligenceArtifactBias();
                    }
                    break;

                case 3:
                    RandartFlags2.Set(ItemFlag2.SustWis);
                    if (artifactBias == null)
                    {
                        artifactBias = new WisdomArtifactBias();
                    }
                    break;

                case 4:
                    RandartFlags2.Set(ItemFlag2.SustDex);
                    if (artifactBias == null)
                    {
                        artifactBias = new DexterityArtifactBias();
                    }
                    break;

                case 5:
                    RandartFlags2.Set(ItemFlag2.SustCon);
                    if (artifactBias == null)
                    {
                        artifactBias = new ConstitutionArtifactBias();
                    }
                    break;

                case 6:
                    RandartFlags2.Set(ItemFlag2.SustCha);
                    if (artifactBias == null)
                    {
                        artifactBias = new CharismaArtifactBias();
                    }
                    break;

                case 7:
                case 8:
                case 14:
                    RandartFlags2.Set(ItemFlag2.FreeAct);
                    break;

                case 9:
                    RandartFlags2.Set(ItemFlag2.HoldLife);
                    if (artifactBias == null && Program.Rng.DieRoll(5) == 1)
                    {
                        artifactBias = new PriestlyArtifactBias();
                    }
                    else if (artifactBias == null && Program.Rng.DieRoll(6) == 1)
                    {
                        artifactBias = new NecromanticArtifactBias();
                    }
                    break;

                case 10:
                case 11:
                    RandartFlags3.Set(ItemFlag3.Lightsource);
                    break;

                case 12:
                case 13:
                    RandartFlags3.Set(ItemFlag3.Feather);
                    break;

                case 15:
                case 16:
                case 17:
                    RandartFlags3.Set(ItemFlag3.SeeInvis);
                    break;

                case 18:
                    RandartFlags3.Set(ItemFlag3.Telepathy);
                    if (artifactBias == null && Program.Rng.DieRoll(9) == 1)
                    {
                        artifactBias = new MageArtifactBias();
                    }
                    break;

                case 19:
                case 20:
                    RandartFlags3.Set(ItemFlag3.SlowDigest);
                    break;

                case 21:
                case 22:
                    RandartFlags3.Set(ItemFlag3.Regen);
                    break;

                case 23:
                    RandartFlags3.Set(ItemFlag3.Teleport);
                    break;

                case 24:
                case 25:
                case 26:
                    if (Category >= ItemCategory.Boots)
                    {
                        ApplyRandomMiscPower(ref artifactBias);
                    }
                    else
                    {
                        RandartFlags3.Set(ItemFlag3.ShowMods);
                        BonusArmourClass = 4 + Program.Rng.DieRoll(11);
                    }
                    break;

                case 27:
                case 28:
                case 29:
                    RandartFlags3.Set(ItemFlag3.ShowMods);
                    BonusToHit += 4 + Program.Rng.DieRoll(11);
                    BonusDamage += 4 + Program.Rng.DieRoll(11);
                    break;

                case 30:
                    RandartFlags3.Set(ItemFlag3.NoMagic);
                    break;

                case 31:
                    RandartFlags3.Set(ItemFlag3.NoTele);
                    break;
            }
        }

        private void ApplyRandomSlaying(ref IArtifactBias artifactBias)
        {
            if (artifactBias != null)
            {
                if (artifactBias.ApplySlaying(this))
                {
                    return;
                }
            }
            if (Category != ItemCategory.Bow)
            {
                switch (Program.Rng.DieRoll(34))
                {
                    case 1:
                    case 2:
                        RandartFlags1.Set(ItemFlag1.SlayAnimal);
                        break;

                    case 3:
                    case 4:
                        RandartFlags1.Set(ItemFlag1.SlayEvil);
                        if (artifactBias == null && Program.Rng.DieRoll(2) == 1)
                        {
                            artifactBias = new LawArtifactBias();
                        }
                        else if (artifactBias == null && Program.Rng.DieRoll(9) == 1)
                        {
                            artifactBias = new PriestlyArtifactBias();
                        }
                        break;

                    case 5:
                    case 6:
                        RandartFlags1.Set(ItemFlag1.SlayUndead);
                        if (artifactBias == null && Program.Rng.DieRoll(9) == 1)
                        {
                            artifactBias = new PriestlyArtifactBias();
                        }
                        break;

                    case 7:
                    case 8:
                        RandartFlags1.Set(ItemFlag1.SlayDemon);
                        if (artifactBias == null && Program.Rng.DieRoll(9) == 1)
                        {
                            artifactBias = new PriestlyArtifactBias();
                        }
                        break;

                    case 9:
                    case 10:
                        RandartFlags1.Set(ItemFlag1.SlayOrc);
                        break;

                    case 11:
                    case 12:
                        RandartFlags1.Set(ItemFlag1.SlayTroll);
                        break;

                    case 13:
                    case 14:
                        RandartFlags1.Set(ItemFlag1.SlayGiant);
                        break;

                    case 15:
                    case 16:
                        RandartFlags1.Set(ItemFlag1.SlayDragon);
                        break;

                    case 17:
                        RandartFlags1.Set(ItemFlag1.KillDragon);
                        break;

                    case 18:
                    case 19:
                        if (Category == ItemCategory.Sword)
                        {
                            RandartFlags1.Set(ItemFlag1.Vorpal);
                            if (artifactBias == null && Program.Rng.DieRoll(9) == 1)
                            {
                                artifactBias = new WarriorArtifactBias();
                            }
                        }
                        else
                        {
                            ApplyRandomSlaying(ref artifactBias);
                        }
                        break;

                    case 20:
                        RandartFlags1.Set(ItemFlag1.Impact);
                        break;

                    case 21:
                    case 22:
                        RandartFlags1.Set(ItemFlag1.BrandFire);
                        if (artifactBias == null)
                        {
                            artifactBias = new FireArtifactBias();
                        }
                        break;

                    case 23:
                    case 24:
                        RandartFlags1.Set(ItemFlag1.BrandCold);
                        if (artifactBias == null)
                        {
                            artifactBias = new ColdArtifactBias();
                        }
                        break;

                    case 25:
                    case 26:
                        RandartFlags1.Set(ItemFlag1.BrandElec);
                        if (artifactBias == null)
                        {
                            artifactBias = new ElectricityArtifactBias();
                        }
                        break;

                    case 27:
                    case 28:
                        RandartFlags1.Set(ItemFlag1.BrandAcid);
                        if (artifactBias == null)
                        {
                            artifactBias = new AcidArtifactBias();
                        }
                        break;

                    case 29:
                    case 30:
                        RandartFlags1.Set(ItemFlag1.BrandPois);
                        if (artifactBias == null && Program.Rng.DieRoll(3) != 1)
                        {
                            artifactBias = new PoisonArtifactBias();
                        }
                        else if (artifactBias == null && Program.Rng.DieRoll(6) == 1)
                        {
                            artifactBias = new NecromanticArtifactBias();
                        }
                        else if (artifactBias == null)
                        {
                            artifactBias = new RogueArtifactBias();
                        }
                        break;

                    case 31:
                    case 32:
                        RandartFlags1.Set(ItemFlag1.Vampiric);
                        if (artifactBias == null)
                        {
                            artifactBias = new NecromanticArtifactBias();
                        }
                        break;

                    default:
                        RandartFlags1.Set(ItemFlag1.Chaotic);
                        if (artifactBias == null)
                        {
                            artifactBias = new ChaosArtifactBias();
                        }
                        break;
                }
            }
            else
            {
                switch (Program.Rng.DieRoll(6))
                {
                    case 1:
                    case 2:
                    case 3:
                        RandartFlags3.Set(ItemFlag3.XtraMight);
                        if (artifactBias == null && Program.Rng.DieRoll(9) == 1)
                        {
                            artifactBias = new RangerArtifactBias();
                        }
                        break;

                    default:
                        RandartFlags3.Set(ItemFlag3.XtraShots);
                        if (artifactBias == null && Program.Rng.DieRoll(9) == 1)
                        {
                            artifactBias = new RangerArtifactBias();
                        }
                        break;
                }
            }
        }

        private void ChargeStaff()
        {
            switch (ItemSubCategory)
            {
                case StaffType.Darkness:
                    TypeSpecificValue = Program.Rng.DieRoll(8) + 8;
                    break;

                case StaffType.Slowness:
                    TypeSpecificValue = Program.Rng.DieRoll(8) + 8;
                    break;

                case StaffType.HasteMonsters:
                    TypeSpecificValue = Program.Rng.DieRoll(8) + 8;
                    break;

                case StaffType.Summoning:
                    TypeSpecificValue = Program.Rng.DieRoll(3) + 1;
                    break;

                case StaffType.Teleportation:
                    TypeSpecificValue = Program.Rng.DieRoll(4) + 5;
                    break;

                case StaffType.Identify:
                    TypeSpecificValue = Program.Rng.DieRoll(15) + 5;
                    break;

                case StaffType.RemoveCurse:
                    TypeSpecificValue = Program.Rng.DieRoll(3) + 4;
                    break;

                case StaffType.Starlight:
                    TypeSpecificValue = Program.Rng.DieRoll(5) + 6;
                    break;

                case StaffType.Light:
                    TypeSpecificValue = Program.Rng.DieRoll(20) + 8;
                    break;

                case StaffType.Mapping:
                    TypeSpecificValue = Program.Rng.DieRoll(5) + 5;
                    break;

                case StaffType.DetectGold:
                    TypeSpecificValue = Program.Rng.DieRoll(20) + 8;
                    break;

                case StaffType.DetectItem:
                    TypeSpecificValue = Program.Rng.DieRoll(15) + 6;
                    break;

                case StaffType.DetectTrap:
                    TypeSpecificValue = Program.Rng.DieRoll(5) + 6;
                    break;

                case StaffType.DetectDoor:
                    TypeSpecificValue = Program.Rng.DieRoll(8) + 6;
                    break;

                case StaffType.DetectInvis:
                    TypeSpecificValue = Program.Rng.DieRoll(15) + 8;
                    break;

                case StaffType.DetectEvil:
                    TypeSpecificValue = Program.Rng.DieRoll(15) + 8;
                    break;

                case StaffType.CureLight:
                    TypeSpecificValue = Program.Rng.DieRoll(5) + 6;
                    break;

                case StaffType.Curing:
                    TypeSpecificValue = Program.Rng.DieRoll(3) + 4;
                    break;

                case StaffType.Healing:
                    TypeSpecificValue = Program.Rng.DieRoll(2) + 1;
                    break;

                case StaffType.TheMagi:
                    TypeSpecificValue = Program.Rng.DieRoll(2) + 2;
                    break;

                case StaffType.SleepMonsters:
                    TypeSpecificValue = Program.Rng.DieRoll(5) + 6;
                    break;

                case StaffType.SlowMonsters:
                    TypeSpecificValue = Program.Rng.DieRoll(5) + 6;
                    break;

                case StaffType.Speed:
                    TypeSpecificValue = Program.Rng.DieRoll(3) + 4;
                    break;

                case StaffType.Probing:
                    TypeSpecificValue = Program.Rng.DieRoll(6) + 2;
                    break;

                case StaffType.DispelEvil:
                    TypeSpecificValue = Program.Rng.DieRoll(3) + 4;
                    break;

                case StaffType.Power:
                    TypeSpecificValue = Program.Rng.DieRoll(3) + 1;
                    break;

                case StaffType.Holiness:
                    TypeSpecificValue = Program.Rng.DieRoll(2) + 2;
                    break;

                case StaffType.Carnage:
                    TypeSpecificValue = Program.Rng.DieRoll(2) + 1;
                    break;

                case StaffType.Earthquakes:
                    TypeSpecificValue = Program.Rng.DieRoll(5) + 3;
                    break;

                case StaffType.Destruction:
                    TypeSpecificValue = Program.Rng.DieRoll(3) + 1;
                    break;
            }
        }

        private void ChargeWand()
        {
            switch (ItemSubCategory)
            {
                case WandType.HealMonster:
                    TypeSpecificValue = Program.Rng.DieRoll(20) + 8;
                    break;

                case WandType.HasteMonster:
                    TypeSpecificValue = Program.Rng.DieRoll(20) + 8;
                    break;

                case WandType.CloneMonster:
                    TypeSpecificValue = Program.Rng.DieRoll(5) + 3;
                    break;

                case WandType.TeleportAway:
                    TypeSpecificValue = Program.Rng.DieRoll(5) + 6;
                    break;

                case WandType.Disarming:
                    TypeSpecificValue = Program.Rng.DieRoll(5) + 4;
                    break;

                case WandType.TrapDoorDest:
                    TypeSpecificValue = Program.Rng.DieRoll(8) + 6;
                    break;

                case WandType.StoneToMud:
                    TypeSpecificValue = Program.Rng.DieRoll(8) + 3;
                    break;

                case WandType.Light:
                    TypeSpecificValue = Program.Rng.DieRoll(10) + 6;
                    break;

                case WandType.SleepMonster:
                    TypeSpecificValue = Program.Rng.DieRoll(15) + 8;
                    break;

                case WandType.SlowMonster:
                    TypeSpecificValue = Program.Rng.DieRoll(10) + 6;
                    break;

                case WandType.ConfuseMonster:
                    TypeSpecificValue = Program.Rng.DieRoll(12) + 6;
                    break;

                case WandType.FearMonster:
                    TypeSpecificValue = Program.Rng.DieRoll(5) + 3;
                    break;

                case WandType.DrainLife:
                    TypeSpecificValue = Program.Rng.DieRoll(3) + 3;
                    break;

                case WandType.Polymorph:
                    TypeSpecificValue = Program.Rng.DieRoll(8) + 6;
                    break;

                case WandType.StinkingCloud:
                    TypeSpecificValue = Program.Rng.DieRoll(8) + 6;
                    break;

                case WandType.MagicMissile:
                    TypeSpecificValue = Program.Rng.DieRoll(10) + 6;
                    break;

                case WandType.AcidBolt:
                    TypeSpecificValue = Program.Rng.DieRoll(8) + 6;
                    break;

                case WandType.CharmMonster:
                    TypeSpecificValue = Program.Rng.DieRoll(6) + 2;
                    break;

                case WandType.FireBolt:
                    TypeSpecificValue = Program.Rng.DieRoll(8) + 6;
                    break;

                case WandType.ColdBolt:
                    TypeSpecificValue = Program.Rng.DieRoll(5) + 6;
                    break;

                case WandType.AcidBall:
                    TypeSpecificValue = Program.Rng.DieRoll(5) + 2;
                    break;

                case WandType.ElecBall:
                    TypeSpecificValue = Program.Rng.DieRoll(8) + 4;
                    break;

                case WandType.FireBall:
                    TypeSpecificValue = Program.Rng.DieRoll(4) + 2;
                    break;

                case WandType.ColdBall:
                    TypeSpecificValue = Program.Rng.DieRoll(6) + 2;
                    break;

                case WandType.Wonder:
                    TypeSpecificValue = Program.Rng.DieRoll(15) + 8;
                    break;

                case WandType.Annihilation:
                    TypeSpecificValue = Program.Rng.DieRoll(2) + 1;
                    break;

                case WandType.DragonFire:
                    TypeSpecificValue = Program.Rng.DieRoll(3) + 1;
                    break;

                case WandType.DragonCold:
                    TypeSpecificValue = Program.Rng.DieRoll(3) + 1;
                    break;

                case WandType.DragonBreath:
                    TypeSpecificValue = Program.Rng.DieRoll(3) + 1;
                    break;

                case WandType.Shard:
                    TypeSpecificValue = Program.Rng.DieRoll(2) + 1;
                    break;
            }
        }

        private void CurseRandart()
        {
            if (TypeSpecificValue != 0)
            {
                TypeSpecificValue = 0 - (TypeSpecificValue + Program.Rng.DieRoll(4));
            }
            if (BonusArmourClass != 0)
            {
                BonusArmourClass = 0 - (BonusArmourClass + Program.Rng.DieRoll(4));
            }
            if (BonusToHit != 0)
            {
                BonusToHit = 0 - (BonusToHit + Program.Rng.DieRoll(4));
            }
            if (BonusDamage != 0)
            {
                BonusDamage = 0 - (BonusDamage + Program.Rng.DieRoll(4));
            }
            RandartFlags3.Set(ItemFlag3.HeavyCurse | ItemFlag3.Cursed);
            if (Program.Rng.DieRoll(4) == 1)
            {
                RandartFlags3.Set(ItemFlag3.PermaCurse);
            }
            if (Program.Rng.DieRoll(3) == 1)
            {
                RandartFlags3.Set(ItemFlag3.DreadCurse);
            }
            if (Program.Rng.DieRoll(2) == 1)
            {
                RandartFlags3.Set(ItemFlag3.Aggravate);
            }
            if (Program.Rng.DieRoll(3) == 1)
            {
                RandartFlags3.Set(ItemFlag3.DrainExp);
            }
            if (Program.Rng.DieRoll(2) == 1)
            {
                RandartFlags3.Set(ItemFlag3.Teleport);
            }
            else if (Program.Rng.DieRoll(3) == 1)
            {
                RandartFlags3.Set(ItemFlag3.NoTele);
            }
            if (SaveGame.Instance.Player.ProfessionIndex != CharacterClass.Warrior && Program.Rng.DieRoll(3) == 1)
            {
                RandartFlags3.Set(ItemFlag3.NoMagic);
            }
            IdentifyFlags.Set(Constants.IdentCursed);
        }

        private int GetBonusValue(int max, int level)
        {
            if (level > Constants.MaxDepth - 1)
            {
                level = Constants.MaxDepth - 1;
            }
            int bonus = max * level / Constants.MaxDepth;
            int extra = max * level % Constants.MaxDepth;
            if (Program.Rng.RandomLessThan(Constants.MaxDepth) < extra)
            {
                bonus++;
            }
            int stand = max / 4;
            extra = max % 4;
            if (Program.Rng.RandomLessThan(4) < extra)
            {
                stand++;
            }
            int value = Program.Rng.RandomNormal(bonus, stand);
            if (value < 0)
            {
                return 0;
            }
            if (value > max)
            {
                return max;
            }
            return value;
        }

        private string GetRndLineInternal(string[] list)
        {
            return list[Program.Rng.RandomLessThan(list.Length)];
        }

        private string GetTableName()
        {
            int testcounter = Program.Rng.DieRoll(3) + 1;
            string outString = "";
            if (Program.Rng.DieRoll(3) == 2)
            {
                while (testcounter-- != 0)
                {
                    outString += ScrollFlavour.Syllables[Program.Rng.RandomLessThan(ScrollFlavour.Syllables.Length)];
                }
            }
            else
            {
                testcounter = Program.Rng.DieRoll(2) + 1;
                while (testcounter-- != 0)
                {
                    outString += GetRndLineInternal(GlobalData.TextElvish);
                }
            }
            return "'" + outString.Substring(0, 1).ToUpper() + outString.Substring(1) + "'";
        }

        private void GiveActivationPower(ref IArtifactBias artifactBias)
        {
            IActivationPower type = null;
            if (artifactBias != null)
            {
                if (Program.Rng.DieRoll(100) < artifactBias.ActivationPowerChance)
                {
                    type = artifactBias.GetActivationPowerType(this);
                }
            }
            if (type == null)
            {
                int chance = 0;
                while (type == null || Program.Rng.DieRoll(100) >= chance)
                {
                    type = ActivationPowerManager.GetRandom();
                    chance = type.RandomChance;
                }
            }
            BonusPowerSubType = type;
            RandartFlags3.Set(ItemFlag3.Activate);
            RechargeTimeLeft = 0;
        }

        private bool MakeFixedArtifact()
        {
            foreach (System.Collections.Generic.KeyValuePair<FixedArtifactId, FixedArtifact> pair in Profile.Instance.FixedArtifacts)
            {
                FixedArtifact aPtr = pair.Value;
                if (!aPtr.HasOwnType)
                {
                    continue;
                }
                if (aPtr.CurNum != 0)
                {
                    continue;
                }
                if (aPtr.Level > SaveGame.Instance.Difficulty)
                {
                    int d = (aPtr.Level - SaveGame.Instance.Difficulty) * 2;
                    if (Program.Rng.RandomLessThan(d) != 0)
                    {
                        continue;
                    }
                }
                if (Program.Rng.RandomLessThan(aPtr.Rarity) != 0)
                {
                    return false;
                }
                ItemType kIdx = Profile.Instance.ItemTypes.LookupKind(aPtr.Tval, aPtr.Sval);
                if (kIdx.Level > SaveGame.Instance.Level.ObjectLevel)
                {
                    int d = (kIdx.Level - SaveGame.Instance.Level.ObjectLevel) * 5;
                    if (Program.Rng.RandomLessThan(d) != 0)
                    {
                        continue;
                    }
                }
                AssignItemType(kIdx);
                FixedArtifactIndex = pair.Key;
                return true;
            }
            return false;
        }

        private void PrepareAllocationTable(GetObjNumHookDelegate getObjNumHook)
        {
            AllocationEntry[] table = SaveGame.Instance.AllocKindTable;
            for (int i = 0; i < SaveGame.Instance.AllocKindSize; i++)
            {
                if (getObjNumHook == null || getObjNumHook(table[i].Index))
                {
                    table[i].FilteredProbabiity = table[i].BaseProbability;
                }
                else
                {
                    table[i].FilteredProbabiity = 0;
                }
            }
        }
    }
}