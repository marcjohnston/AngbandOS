// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.Core;
using AngbandOS.ActivationPowers;
using AngbandOS.ArtifactBiases;
using AngbandOS.Enumerations;
using AngbandOS.ItemCategories;
using AngbandOS.StaticData;

namespace AngbandOS
{
    [Serializable]
    internal class Item
    {
        public readonly FlagSet IdentifyFlags = new FlagSet();
        public readonly ItemCharacteristics RandartItemCharacteristics = new ItemCharacteristics();
        public int BaseArmourClass;
        public int BonusArmourClass;
        public int BonusDamage;
        public IActivationPower BonusPowerSubType;
        public Enumerations.RareItemType BonusPowerType;
        public int BonusToHit;
        public int Count;
        public int DamageDice;
        public int DamageDiceSides;
        public int Discount;
        public FixedArtifactId FixedArtifactIndex;
        public int HoldingMonsterIndex;
        public string Inscription = "";
        public int ItemSubCategory;

        /// <summary>
        /// Returns the item type that this item is based on.  Returns null, if the item is (nothing), as in the inventory.
        /// </summary>
        public ItemType? ItemType = null;

        public bool Marked;

        /// <summary>
        /// Returns the index of the next item, if this item is part of a stack of items.
        /// </summary>
        public int NextInStack;

        public string RandartName = "";
        public Enumerations.RareItemType RareItemTypeIndex;
        public int RechargeTimeLeft;
        public int TypeSpecificValue;
        public int Weight;
        public int X;
        public int Y;
        public readonly SaveGame SaveGame;
        public ItemCharacteristics Characteristics = new ItemCharacteristics();

        /// <summary>
        /// Creates a new (nothing) item.
        /// </summary>
        /// <param name="saveGame"></param>
        public Item(SaveGame saveGame)
        {
            SaveGame = saveGame;
        }

        public Item(SaveGame saveGame, Item original)
        {
            SaveGame = saveGame;
            BaseArmourClass = original.BaseArmourClass;
            RandartItemCharacteristics.Copy(original.RandartItemCharacteristics);
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
            Weight = original.Weight;
            BonusPowerType = original.BonusPowerType;
            BonusPowerSubType = original.BonusPowerSubType;
        }

        public bool IsKnownArtifact => IsKnown() && (IsFixedArtifact() || !string.IsNullOrEmpty(RandartName));

        public ItemCategory Category => ItemType == null ? ItemCategory.None : ItemType.BaseItemCategory.CategoryEnum; // Provided for backwards compatability.  Will be deleted.

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
            RefreshFlagBasedProperties();
            if (ItemType.BaseItemCategory.GetsDamageMultiplier)
            {
                if (Characteristics.SlayAnimal && (rPtr.Flags3 & MonsterFlag3.Animal) != 0)
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
                if (Characteristics.SlayEvil && (rPtr.Flags3 & MonsterFlag3.Evil) != 0)
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
                if (Characteristics.SlayUndead && (rPtr.Flags3 & MonsterFlag3.Undead) != 0)
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
                if (Characteristics.SlayDemon && (rPtr.Flags3 & MonsterFlag3.Demon) != 0)
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
                if (Characteristics.SlayOrc && (rPtr.Flags3 & MonsterFlag3.Orc) != 0)
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
                if (Characteristics.SlayTroll && (rPtr.Flags3 & MonsterFlag3.Troll) != 0)
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
                if (Characteristics.SlayGiant && (rPtr.Flags3 & MonsterFlag3.Giant) != 0)
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
                if (Characteristics.SlayDragon && (rPtr.Flags3 & MonsterFlag3.Dragon) != 0)
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
                if (Characteristics.KillDragon && (rPtr.Flags3 & MonsterFlag3.Dragon) != 0)
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
                if (Characteristics.BrandAcid)
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
                if (Characteristics.BrandElec)
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
                if (Characteristics.BrandFire)
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
                if (Characteristics.BrandCold)
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
                if (Characteristics.BrandPois)
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
            }
            return tdam * mult;
        }

        public void ApplyRandomResistance(int specific)
        {
            IArtifactBias artifactBias = null;
            ApplyRandomResistance(ref artifactBias, specific); // TODO: We has to inject 0 for the ArtifactBias because the constructor would have initialized the _artifactBias to 0.
        }

        public void AssignItemType(ItemType itemType)
        {
            ItemType = itemType;
            ItemSubCategory = itemType.BaseItemCategory.SubCategory ?? 0;
            TypeSpecificValue = itemType.BaseItemCategory.Pval;
            Count = 1;
            Weight = itemType.BaseItemCategory.Weight;
            BonusToHit = itemType.BaseItemCategory.ToH;
            BonusDamage = itemType.BaseItemCategory.ToD;
            BonusArmourClass = itemType.BaseItemCategory.ToA;
            BaseArmourClass = itemType.BaseItemCategory.Ac;
            DamageDice = itemType.BaseItemCategory.Dd;
            DamageDiceSides = itemType.BaseItemCategory.Ds;
            if (itemType.BaseItemCategory.Cost <= 0)
            {
                IdentifyFlags.Set(Constants.IdentBroken);
            }
            if (itemType.BaseItemCategory.Cursed)
            {
                IdentifyFlags.Set(Constants.IdentCursed);
            }
        }

        public void BecomeFlavourAware()
        {
            ItemType.BaseItemCategory.FlavourAware = true;
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
            return ItemType.BaseItemCategory.PercentageBreakageChance;
        }

        public bool StatsAreSame(Item other)
        {
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
            return true;
        }

        public bool CanAbsorb(Item other)
        {
            int total = Count + other.Count;
            if (ItemType != other.ItemType)
            {
                return false;
            }
            if (!ItemType.BaseItemCategory.CanAbsorb(this, other))
            {
                return false;
            }    

            if (RandartItemCharacteristics != other.RandartItemCharacteristics)
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
        public string Description(bool includeCountPrefix, int mode)
        {
            if (ItemType == null || ItemType.BaseItemCategory == null)
            {
                return "(nothing)";
            }
            string basenm = ItemType.BaseItemCategory.GetDescription(this, includeCountPrefix);
            if (IsKnown())
            {
                if (!string.IsNullOrEmpty(RandartName))
                {
                    basenm += ' ';
                    basenm += RandartName;
                }
                else if (FixedArtifactIndex != 0)
                {
                    FixedArtifact aPtr = SaveGame.FixedArtifacts[FixedArtifactIndex];
                    basenm += ' ';
                    basenm += aPtr.Name;
                }
                else if (RareItemTypeIndex != Enumerations.RareItemType.None)
                {
                    RareItemType ePtr = SaveGame.RareItemTypes[RareItemTypeIndex];
                    basenm += ' ';
                    basenm += ePtr.Name;
                }
            }
            if (mode < 1)
            {
                return basenm;
            }

            // This is the detailed description.
            basenm += ItemType.BaseItemCategory.GetDetailedDescription(this);
            if (mode < 2)
            {
                return basenm;
            }

            basenm += ItemType.BaseItemCategory.GetVerboseDescription(this);

            // This is the verbose description.
            if (mode < 3)
            {
                return basenm;
            }

            // This is the full description.
            basenm += ItemType.BaseItemCategory.GetFullDescription(this);

            // We can only render 75 characters max ... we are forced to truncate.
            if (basenm.Length > 75)
            {
                basenm = basenm.Substring(0, 75);
            }
            return basenm;
        }

        public int FlagBasedCost(int plusses)
        {
            int total = 0;
            RefreshFlagBasedProperties();
            if (Characteristics.Str)
            {
                total += 1000 * plusses;
            }
            if (Characteristics.Int)
            {
                total += 1000 * plusses;
            }
            if (Characteristics.Wis)
            {
                total += 1000 * plusses;
            }
            if (Characteristics.Dex)
            {
                total += 1000 * plusses;
            }
            if (Characteristics.Con)
            {
                total += 1000 * plusses;
            }
            if (Characteristics.Cha)
            {
                total += 250 * plusses;
            }
            if (Characteristics.Chaotic)
            {
                total += 10000;
            }
            if (Characteristics.Vampiric)
            {
                total += 13000;
            }
            if (Characteristics.Stealth)
            {
                total += 250 * plusses;
            }
            if (Characteristics.Search)
            {
                total += 100 * plusses;
            }
            if (Characteristics.Infra)
            {
                total += 150 * plusses;
            }
            if (Characteristics.Tunnel)
            {
                total += 175 * plusses;
            }
            if (Characteristics.Speed && plusses > 0)
            {
                total += 30000 * plusses;
            }
            if (Characteristics.Blows && plusses > 0)
            {
                total += 2000 * plusses;
            }
            if (Characteristics.AntiTheft)
            {
                total += 0;
            }
            if (Characteristics.SlayAnimal)
            {
                total += 3500;
            }
            if (Characteristics.SlayEvil)
            {
                total += 4500;
            }
            if (Characteristics.SlayUndead)
            {
                total += 3500;
            }
            if (Characteristics.SlayDemon)
            {
                total += 3500;
            }
            if (Characteristics.SlayOrc)
            {
                total += 3000;
            }
            if (Characteristics.SlayTroll)
            {
                total += 3500;
            }
            if (Characteristics.SlayGiant)
            {
                total += 3500;
            }
            if (Characteristics.SlayDragon)
            {
                total += 3500;
            }
            if (Characteristics.KillDragon)
            {
                total += 5500;
            }
            if (Characteristics.Vorpal)
            {
                total += 5000;
            }
            if (Characteristics.Impact)
            {
                total += 5000;
            }
            if (Characteristics.BrandPois)
            {
                total += 7500;
            }
            if (Characteristics.BrandAcid)
            {
                total += 7500;
            }
            if (Characteristics.BrandElec)
            {
                total += 7500;
            }
            if (Characteristics.BrandFire)
            {
                total += 5000;
            }
            if (Characteristics.BrandCold)
            {
                total += 5000;
            }
            if (Characteristics.SustStr)
            {
                total += 850;
            }
            if (Characteristics.SustInt)
            {
                total += 850;
            }
            if (Characteristics.SustWis)
            {
                total += 850;
            }
            if (Characteristics.SustDex)
            {
                total += 850;
            }
            if (Characteristics.SustCon)
            {
                total += 850;
            }
            if (Characteristics.SustCha)
            {
                total += 250;
            }
            if (Characteristics.ImAcid)
            {
                total += 10000;
            }
            if (Characteristics.ImElec)
            {
                total += 10000;
            }
            if (Characteristics.ImFire)
            {
                total += 10000;
            }
            if (Characteristics.ImCold)
            {
                total += 10000;
            }
            if (Characteristics.Reflect)
            {
                total += 10000;
            }
            if (Characteristics.FreeAct)
            {
                total += 4500;
            }
            if (Characteristics.HoldLife)
            {
                total += 8500;
            }
            if (Characteristics.ResAcid)
            {
                total += 1250;
            }
            if (Characteristics.ResElec)
            {
                total += 1250;
            }
            if (Characteristics.ResFire)
            {
                total += 1250;
            }
            if (Characteristics.ResCold)
            {
                total += 1250;
            }
            if (Characteristics.ResPois)
            {
                total += 2500;
            }
            if (Characteristics.ResFear)
            {
                total += 2500;
            }
            if (Characteristics.ResLight)
            {
                total += 1750;
            }
            if (Characteristics.ResDark)
            {
                total += 1750;
            }
            if (Characteristics.ResBlind)
            {
                total += 2000;
            }
            if (Characteristics.ResConf)
            {
                total += 2000;
            }
            if (Characteristics.ResSound)
            {
                total += 2000;
            }
            if (Characteristics.ResShards)
            {
                total += 2000;
            }
            if (Characteristics.ResNether)
            {
                total += 2000;
            }
            if (Characteristics.ResNexus)
            {
                total += 2000;
            }
            if (Characteristics.ResChaos)
            {
                total += 2000;
            }
            if (Characteristics.ResDisen)
            {
                total += 10000;
            }
            if (Characteristics.ShFire)
            {
                total += 5000;
            }
            if (Characteristics.ShElec)
            {
                total += 5000;
            }
            if (Characteristics.NoTele)
            {
                total += 2500;
            }
            if (Characteristics.NoMagic)
            {
                total += 2500;
            }
            if (Characteristics.Wraith)
            {
                total += 250000;
            }
            if (Characteristics.DreadCurse)
            {
                total -= 15000;
            }
            if (Characteristics.EasyKnow)
            {
                total += 0;
            }
            if (Characteristics.HideType)
            {
                total += 0;
            }
            if (Characteristics.ShowMods)
            {
                total += 0;
            }
            if (Characteristics.InstaArt)
            {
                total += 0;
            }
            if (Characteristics.Feather)
            {
                total += 1250;
            }
            if (Characteristics.Lightsource)
            {
                total += 1250;
            }
            if (Characteristics.SeeInvis)
            {
                total += 2000;
            }
            if (Characteristics.Telepathy)
            {
                total += 12500;
            }
            if (Characteristics.SlowDigest)
            {
                total += 750;
            }
            if (Characteristics.Regen)
            {
                total += 2500;
            }
            if (Characteristics.XtraMight)
            {
                total += 2250;
            }
            if (Characteristics.XtraShots)
            {
                total += 10000;
            }
            if (Characteristics.IgnoreAcid)
            {
                total += 100;
            }
            if (Characteristics.IgnoreElec)
            {
                total += 100;
            }
            if (Characteristics.IgnoreFire)
            {
                total += 100;
            }
            if (Characteristics.IgnoreCold)
            {
                total += 100;
            }
            if (Characteristics.Activate)
            {
                total += 100;
            }
            if (Characteristics.DrainExp)
            {
                total -= 12500;
            }
            if (Characteristics.Teleport)
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
            if (Characteristics.Aggravate)
            {
                total -= 10000;
            }
            if (Characteristics.Blessed)
            {
                total += 750;
            }
            if (Characteristics.Cursed)
            {
                total -= 5000;
            }
            if (Characteristics.HeavyCurse)
            {
                total -= 12500;
            }
            if (Characteristics.PermaCurse)
            {
                total -= 15000;
            }
            if (!string.IsNullOrEmpty(RandartName) && RandartItemCharacteristics.Activate)
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

        /// <summary>
        /// Refreshes all of the flag-based properties.  This is an interim method that replaces the deprecated GetMergedFlags(f1, f2, f3).  This method will
        /// be deprecated once all of the flag-based properties are maintained when the FixedArtifactIndex, RareItemType and RandartFlags automatically update
        /// the flag-based properties.
        /// </summary>
        public void RefreshFlagBasedProperties()
        {
            // All characteristics are set to false.
            Characteristics = new ItemCharacteristics();
            if (ItemType == null)
            {
                return;
            }

            // Merge the characteristics from the base item category.
            Characteristics.Merge(ItemType.BaseItemCategory);

            // Now merge the characteristics from the fixed artifact, if there is one.
            if (FixedArtifactIndex != 0)
            {
                FixedArtifact aPtr = SaveGame.FixedArtifacts[FixedArtifactIndex];
                Characteristics.Merge(aPtr.FixedArtifactItemCharacteristics);
            }

            // Now merge the characteristics from the rare item type, if there is one.
            if (RareItemTypeIndex != Enumerations.RareItemType.None)
            {
                RareItemType ePtr = SaveGame.RareItemTypes[RareItemTypeIndex];
                Characteristics.Merge(ePtr.RareItemCharacteristics);
            }

            Characteristics.Merge(RandartItemCharacteristics);

            if (!string.IsNullOrEmpty(RandartName))
            {
                switch (BonusPowerType)
                {
                    case Enumerations.RareItemType.SpecialSustain:
                        switch(BonusPowerSubType.SpecialSustainFlag)
                        {
                            case ItemFlag2.SustStr:
                                Characteristics.SustStr = true;
                                break;
                            case ItemFlag2.SustInt:
                                Characteristics.SustInt = true;
                                break;
                            case ItemFlag2.SustWis:
                                Characteristics.SustWis = true;
                                break;
                            case ItemFlag2.SustDex:
                                Characteristics.SustDex = true;
                                break;
                            case ItemFlag2.SustCon:
                                Characteristics.SustCon = true;
                                break;
                            case ItemFlag2.SustCha:
                                Characteristics.SustCha = true;
                                break;
                        }
                        break;
                    case Enumerations.RareItemType.SpecialPower:
                        switch (BonusPowerSubType.SpecialPowerFlag)
                        {
                            case ItemFlag2.ResSound:
                                Characteristics.ResSound = true;
                                break;
                            case ItemFlag2.ResPois:
                                Characteristics.ResPois = true;
                                break;
                            case ItemFlag2.ResBlind:
                                Characteristics.ResBlind = true;
                                break;
                            case ItemFlag2.ResChaos:
                                Characteristics.ResChaos = true;
                                break;
                            case ItemFlag2.ResConf:
                                Characteristics.ResConf = true;
                                break;
                            case ItemFlag2.ResDisen:
                                Characteristics.ResDisen = true;
                                break;
                            case ItemFlag2.ResDark:
                                Characteristics.ResDark = true;
                                break;
                            case ItemFlag2.ResNexus:
                                Characteristics.ResNexus = true;
                                break;
                            case ItemFlag2.ResShards:
                                Characteristics.ResShards = true;
                                break;
                            case ItemFlag2.ResNether:
                                Characteristics.ResNether = true;
                                break;
                            case ItemFlag2.ResLight:
                                Characteristics.ResLight = true;
                                break;
                        }
                        break;
                    case Enumerations.RareItemType.SpecialAbility:
                        switch (BonusPowerSubType.SpecialAbilityFlag)
                        {
                            case ItemFlag3.Telepathy:
                                Characteristics.Telepathy = true;
                                break;
                            case ItemFlag3.Feather:
                                Characteristics.Feather = true;
                                break;
                            case ItemFlag3.Lightsource:
                                Characteristics.Lightsource = true;
                                break;
                            case ItemFlag3.SlowDigest:
                                Characteristics.SlowDigest = true;
                                break;
                            case ItemFlag3.SeeInvis:
                                Characteristics.SeeInvis = true;
                                break;
                            case ItemFlag3.Regen:
                                Characteristics.Regen = true;
                                break;
                        }
                        break;
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
            return ItemType.BaseItemCategory.HatesAcid;
        }

        public bool HatesCold()
        {
            return ItemType.BaseItemCategory.HatesCold;
        }

        public bool HatesElec()
        {
            return ItemType.BaseItemCategory.HatesElectricity;
        }

        public bool HatesFire()
        {
            return ItemType.BaseItemCategory.HatesFire;
        }

        public bool IdentifyFully()
        {
            int i = 0, j, k;
            string[] info = new string[128];
            RefreshFlagBasedProperties();
            if (Characteristics.Activate)
            {
                info[i++] = "It can be activated for...";
                info[i++] = DescribeActivationEffect();
                info[i++] = "...if it is being worn.";
            }
            string categoryIdentity = ItemType.BaseItemCategory.Identify(this);
            if (categoryIdentity != null)
            {
                info[i++] = categoryIdentity;
            }
            if (Characteristics.Str)
            {
                info[i++] = "It affects your strength.";
            }
            if (Characteristics.Int)
            {
                info[i++] = "It affects your intelligence.";
            }
            if (Characteristics.Wis)
            {
                info[i++] = "It affects your wisdom.";
            }
            if (Characteristics.Dex)
            {
                info[i++] = "It affects your dexterity.";
            }
            if (Characteristics.Con)
            {
                info[i++] = "It affects your constitution.";
            }
            if (Characteristics.Cha)
            {
                info[i++] = "It affects your charisma.";
            }
            if (Characteristics.Stealth)
            {
                info[i++] = "It affects your stealth.";
            }
            if (Characteristics.Search)
            {
                info[i++] = "It affects your searching.";
            }
            if (Characteristics.Infra)
            {
                info[i++] = "It affects your infravision.";
            }
            if (Characteristics.Tunnel)
            {
                info[i++] = "It affects your ability to tunnel.";
            }
            if (Characteristics.Speed)
            {
                info[i++] = "It affects your movement speed.";
            }
            if (Characteristics.Blows)
            {
                info[i++] = "It affects your attack speed.";
            }
            if (Characteristics.BrandAcid)
            {
                info[i++] = "It does extra damage from acid.";
            }
            if (Characteristics.BrandElec)
            {
                info[i++] = "It does extra damage from electricity.";
            }
            if (Characteristics.BrandFire)
            {
                info[i++] = "It does extra damage from fire.";
            }
            if (Characteristics.BrandCold)
            {
                info[i++] = "It does extra damage from frost.";
            }
            if (Characteristics.BrandPois)
            {
                info[i++] = "It poisons your foes.";
            }
            if (Characteristics.Chaotic)
            {
                info[i++] = "It produces chaotic effects.";
            }
            if (Characteristics.Vampiric)
            {
                info[i++] = "It drains life from your foes.";
            }
            if (Characteristics.Impact)
            {
                info[i++] = "It can cause earthquakes.";
            }
            if (Characteristics.Vorpal)
            {
                info[i++] = "It is very sharp and can cut your foes.";
            }
            if (Characteristics.KillDragon)
            {
                info[i++] = "It is a great bane of dragons.";
            }
            else if (Characteristics.SlayDragon)
            {
                info[i++] = "It is especially deadly against dragons.";
            }
            if (Characteristics.SlayOrc)
            {
                info[i++] = "It is especially deadly against orcs.";
            }
            if (Characteristics.SlayTroll)
            {
                info[i++] = "It is especially deadly against trolls.";
            }
            if (Characteristics.SlayGiant)
            {
                info[i++] = "It is especially deadly against giants.";
            }
            if (Characteristics.SlayDemon)
            {
                info[i++] = "It strikes at demons with holy wrath.";
            }
            if (Characteristics.SlayUndead)
            {
                info[i++] = "It strikes at undead with holy wrath.";
            }
            if (Characteristics.SlayEvil)
            {
                info[i++] = "It fights against evil with holy fury.";
            }
            if (Characteristics.SlayAnimal)
            {
                info[i++] = "It is especially deadly against natural creatures.";
            }
            if (Characteristics.SustStr)
            {
                info[i++] = "It sustains your strength.";
            }
            if (Characteristics.SustInt)
            {
                info[i++] = "It sustains your intelligence.";
            }
            if (Characteristics.SustWis)
            {
                info[i++] = "It sustains your wisdom.";
            }
            if (Characteristics.SustDex)
            {
                info[i++] = "It sustains your dexterity.";
            }
            if (Characteristics.SustCon)
            {
                info[i++] = "It sustains your constitution.";
            }
            if (Characteristics.SustCha)
            {
                info[i++] = "It sustains your charisma.";
            }
            if (Characteristics.ImAcid)
            {
                info[i++] = "It provides immunity to acid.";
            }
            if (Characteristics.ImElec)
            {
                info[i++] = "It provides immunity to electricity.";
            }
            if (Characteristics.ImFire)
            {
                info[i++] = "It provides immunity to fire.";
            }
            if (Characteristics.ImCold)
            {
                info[i++] = "It provides immunity to cold.";
            }
            if (Characteristics.FreeAct)
            {
                info[i++] = "It provides immunity to paralysis.";
            }
            if (Characteristics.HoldLife)
            {
                info[i++] = "It provides resistance to life draining.";
            }
            if (Characteristics.ResFear)
            {
                info[i++] = "It makes you completely fearless.";
            }
            if (Characteristics.ResAcid)
            {
                info[i++] = "It provides resistance to acid.";
            }
            if (Characteristics.ResElec)
            {
                info[i++] = "It provides resistance to electricity.";
            }
            if (Characteristics.ResFire)
            {
                info[i++] = "It provides resistance to fire.";
            }
            if (Characteristics.ResCold)
            {
                info[i++] = "It provides resistance to cold.";
            }
            if (Characteristics.ResPois)
            {
                info[i++] = "It provides resistance to poison.";
            }
            if (Characteristics.ResLight)
            {
                info[i++] = "It provides resistance to light.";
            }
            if (Characteristics.ResDark)
            {
                info[i++] = "It provides resistance to dark.";
            }
            if (Characteristics.ResBlind)
            {
                info[i++] = "It provides resistance to blindness.";
            }
            if (Characteristics.ResConf)
            {
                info[i++] = "It provides resistance to confusion.";
            }
            if (Characteristics.ResSound)
            {
                info[i++] = "It provides resistance to sound.";
            }
            if (Characteristics.ResShards)
            {
                info[i++] = "It provides resistance to shards.";
            }
            if (Characteristics.ResNether)
            {
                info[i++] = "It provides resistance to nether.";
            }
            if (Characteristics.ResNexus)
            {
                info[i++] = "It provides resistance to nexus.";
            }
            if (Characteristics.ResChaos)
            {
                info[i++] = "It provides resistance to chaos.";
            }
            if (Characteristics.ResDisen)
            {
                info[i++] = "It provides resistance to disenchantment.";
            }
            if (Characteristics.Wraith)
            {
                info[i++] = "It renders you incorporeal.";
            }
            if (Characteristics.Feather)
            {
                info[i++] = "It allows you to levitate.";
            }
            if (Characteristics.Lightsource)
            {
                info[i++] = "It provides permanent light.";
            }
            if (Characteristics.SeeInvis)
            {
                info[i++] = "It allows you to see invisible monsters.";
            }
            if (Characteristics.Telepathy)
            {
                info[i++] = "It gives telepathic powers.";
            }
            if (Characteristics.SlowDigest)
            {
                info[i++] = "It slows your metabolism.";
            }
            if (Characteristics.Regen)
            {
                info[i++] = "It speeds your regenerative powers.";
            }
            if (Characteristics.Reflect)
            {
                info[i++] = "It reflects bolts and arrows.";
            }
            if (Characteristics.ShFire)
            {
                info[i++] = "It produces a fiery sheath.";
            }
            if (Characteristics.ShElec)
            {
                info[i++] = "It produces an electric sheath.";
            }
            if (Characteristics.NoMagic)
            {
                info[i++] = "It produces an anti-magic shell.";
            }
            if (Characteristics.NoTele)
            {
                info[i++] = "It prevents teleportation.";
            }
            if (Characteristics.XtraMight)
            {
                info[i++] = "It fires missiles with extra might.";
            }
            if (Characteristics.XtraShots)
            {
                info[i++] = "It fires missiles excessively fast.";
            }
            if (Characteristics.DrainExp)
            {
                info[i++] = "It drains experience.";
            }
            if (Characteristics.Teleport)
            {
                info[i++] = "It induces random teleportation.";
            }
            if (Characteristics.Aggravate)
            {
                info[i++] = "It aggravates nearby creatures.";
            }
            if (Characteristics.Blessed)
            {
                info[i++] = "It has been blessed by the gods.";
            }
            if (IsCursed())
            {
                if (Characteristics.PermaCurse)
                {
                    info[i++] = "It is permanently cursed.";
                }
                else if (Characteristics.HeavyCurse)
                {
                    info[i++] = "It is heavily cursed.";
                }
                else
                {
                    info[i++] = "It is cursed.";
                }
            }
            if (Characteristics.DreadCurse)
            {
                info[i++] = "It carries an ancient foul curse.";
            }
            if (Characteristics.IgnoreAcid)
            {
                info[i++] = "It cannot be harmed by acid.";
            }
            if (Characteristics.IgnoreElec)
            {
                info[i++] = "It cannot be harmed by electricity.";
            }
            if (Characteristics.IgnoreFire)
            {
                info[i++] = "It cannot be harmed by fire.";
            }
            if (Characteristics.IgnoreCold)
            {
                info[i++] = "It cannot be harmed by cold.";
            }
            if (i == 0)
            {
                return false;
            }
            SaveGame.SaveScreen();
            for (k = 1; k < 24; k++)
            {
                SaveGame.PrintLine("", k, 13);
            }
            SaveGame.PrintLine("     Item Attributes:", 1, 15);
            for (k = 2, j = 0; j < i; j++)
            {
                SaveGame.PrintLine(info[j], k++, 15);
                if (k == 22 && j + 1 < i)
                {
                    SaveGame.PrintLine("-- more --", k, 15);
                    SaveGame.Inkey();
                    for (; k > 2; k--)
                    {
                        SaveGame.PrintLine("", k, 15);
                    }
                }
            }
            SaveGame.PrintLine("[Press any key to continue]", k, 15);
            SaveGame.Inkey();
            SaveGame.Load();
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
            return ItemType.BaseItemCategory.FlavourAware;
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
            if (ItemType.BaseItemCategory.EasyKnow && ItemType.BaseItemCategory.FlavourAware)
            {
                return true;
            }
            return false;
        }

        public bool IsRare()
        {
            return RareItemTypeIndex != 0;
        }

        public bool MakeGold(int coinType)
        {
            int i = ((Program.Rng.DieRoll(SaveGame.Level.ObjectLevel + 2) + 2) / 2) - 1;
            if (Program.Rng.RandomLessThan(Constants.GreatObj) == 0)
            {
                i += Program.Rng.DieRoll(SaveGame.Level.ObjectLevel + 1);
            }
            if (coinType != 0)
            {
                i = coinType;
            }
            if (i >= Constants.MaxGold)
            {
                i = Constants.MaxGold - 1;
            }
            ItemType kPtr = null;
            switch (i)
            {
                case 0:
                    kPtr = new ItemType(new GoldCopper());
                    break;

                case 1:
                    kPtr = new ItemType(new GoldCopper1());
                    break;

                case 2:
                    kPtr = new ItemType(new GoldCopper2());
                    break;

                case 3:
                    kPtr = new ItemType(new GoldSilver());
                    break;

                case 4:
                    kPtr = new ItemType(new GoldSilver1());
                    break;

                case 5:
                    kPtr = new ItemType(new GoldSilver2());
                    break;

                case 6:
                    kPtr = new ItemType(new GoldGarnets());
                    break;

                case 7:
                    kPtr = new ItemType(new GoldGarnets1());
                    break;

                case 8:
                    kPtr = new ItemType(new GoldGold());
                    break;

                case 9:
                    kPtr = new ItemType(new GoldGold1());
                    break;

                case 10:
                    kPtr = new ItemType(new GoldGold2());
                    break;

                case 11:
                    kPtr = new ItemType(new GoldOpals());
                    break;

                case 12:
                    kPtr = new ItemType(new GoldSapphires());
                    break;

                case 13:
                    kPtr = new ItemType(new GoldRubies());
                    break;

                case 14:
                    kPtr = new ItemType(new GoldDiamonds());
                    break;

                case 15:
                    kPtr = new ItemType(new GoldEmeralds());
                    break;

                case 16:
                    kPtr = new ItemType(new GoldMithril());
                    break;

                case 17:
                    kPtr = new ItemType(new GoldAdamantite());
                    break;
            }
            if (kPtr == null)
            {
                return false;
            }
            AssignItemType(kPtr);
            int bbase = kPtr.BaseItemCategory.Cost;
            TypeSpecificValue = bbase + (8 * Program.Rng.DieRoll(bbase)) + Program.Rng.DieRoll(8);
            return true;
        }

        public ItemCharacteristics ObjectFlagsKnown()
        {
            if (!IsKnown())
            {
                return new ItemCharacteristics();
            }
            return Characteristics;
        }

        public void ObjectTried()
        {
            ItemType.BaseItemCategory.Tried = true;
        }

        public int RealValue()
        {
            ItemType kPtr = ItemType;
            if (kPtr.BaseItemCategory.Cost == 0)
            {
                return 0;
            }
            int value = kPtr.BaseItemCategory.Cost;
            if (RandartItemCharacteristics.IsSet)
            {
                value += FlagBasedCost(TypeSpecificValue);
            }
            else if (FixedArtifactIndex != 0)
            {
                FixedArtifact aPtr = SaveGame.FixedArtifacts[FixedArtifactIndex];
                if (aPtr.Cost == 0)
                {
                    return 0;
                }
                value = aPtr.Cost;
            }
            else if (RareItemTypeIndex != Enumerations.RareItemType.None)
            {
                RareItemType ePtr = SaveGame.RareItemTypes[RareItemTypeIndex];
                if (ePtr.Cost == 0)
                {
                    return 0;
                }
                value += ePtr.Cost;
            }
            if (ItemType.BaseItemCategory.IsWorthless(this))
            {
                return 0;
            }
            int? typeSpecificValue = ItemType.BaseItemCategory.GetTypeSpecificRealValue(this, value);
            if (typeSpecificValue == null)
                return 0;
            value += typeSpecificValue.Value;

            int? bonusValue = ItemType.BaseItemCategory.GetBonusRealValue(this, value);
            if (bonusValue == null)
                return 0;

            value += bonusValue.Value;
            return value;
        }

        public bool Stompable()
        {
            if (!IsKnown())
            {
                if (ItemType.BaseItemCategory.HasFlavor)
                {
                    if (IsFlavourAware())
                    {
                        return ItemType.BaseItemCategory.Stompable[StompableType.Broken];
                    }
                }
                if (IdentifyFlags.IsClear(Constants.IdentSense))
                {
                    return false;
                }
            }
            return ItemType.BaseItemCategory.IsStompable(this);
        }

        public string StoreDescription(bool pref, int mode)
        {
            bool hackAware = ItemType.BaseItemCategory.FlavourAware;
            bool hackKnown = IdentifyFlags.IsSet(Constants.IdentKnown);
            IdentifyFlags.Set(Constants.IdentKnown);
            ItemType.BaseItemCategory.FlavourAware = true;
            string buf = Description(pref, mode);
            ItemType.BaseItemCategory.FlavourAware = hackAware;
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
            if (IsFlavourAware())
            {
                return ItemType.BaseItemCategory.Cost;
            }
            return ItemType.BaseItemCategory.BaseValue;
        }

        private string DescribeActivationEffect()
        {
            RefreshFlagBasedProperties();
            if (!Characteristics.Activate)
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
            return ItemType.BaseItemCategory.DescribeActivationEffect(this);
        }

        private bool IsTried()
        {
            return ItemType.BaseItemCategory.Tried;
        }

        private delegate bool GetObjNumHookDelegate(ItemType kPtr);

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
                FixedArtifact aPtr = SaveGame.FixedArtifacts[FixedArtifactIndex];
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
                if (SaveGame.Level != null)
                {
                    SaveGame.Level.TreasureRating += 10;
                    if (aPtr.Cost > 50000)
                    {
                        SaveGame.Level.TreasureRating += 10;
                    }
                    SaveGame.Level.SpecialTreasure = true;
                }
                return;
            }
            ItemType.BaseItemCategory.ApplyMagic(this, lev, power);
            if (!string.IsNullOrEmpty(RandartName))
            {
                if (SaveGame.Level != null)
                {
                    SaveGame.Level.TreasureRating += 40;
                }
            }
            else if (RareItemTypeIndex != Enumerations.RareItemType.None)
            {
                RareItemType ePtr = SaveGame.RareItemTypes[RareItemTypeIndex];
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
                if (SaveGame.Level != null)
                {
                    SaveGame.Level.TreasureRating += ePtr.Rating;
                }
                return;
            }
            if (ItemType != null)
            {
                ItemType kPtr = ItemType;
                if (kPtr.BaseItemCategory.Cost == 0)
                {
                    IdentifyFlags.Set(Constants.IdentBroken);
                }
                if (kPtr.BaseItemCategory.Cursed)
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
                        RandartItemCharacteristics.ImAcid = true;
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
                        RandartItemCharacteristics.ImElec = true;
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
                        RandartItemCharacteristics.ImCold = true;
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
                        RandartItemCharacteristics.ImFire = true;
                        if (artifactBias == null)
                        {
                            artifactBias = new FireArtifactBias();
                        }
                    }
                    break;

                case 5:
                case 6:
                case 13:
                    RandartItemCharacteristics.ResAcid = true;
                    if (artifactBias == null)
                    {
                        artifactBias = new AcidArtifactBias();
                    }
                    break;

                case 7:
                case 8:
                case 14:
                    RandartItemCharacteristics.ResElec = true;
                    if (artifactBias == null)
                    {
                        artifactBias = new ElectricityArtifactBias();
                    }
                    break;

                case 9:
                case 10:
                case 15:
                    RandartItemCharacteristics.ResFire = true;
                    if (artifactBias == null)
                    {
                        artifactBias = new FireArtifactBias();
                    }
                    break;

                case 11:
                case 12:
                case 16:
                    RandartItemCharacteristics.ResCold = true;
                    if (artifactBias == null)
                    {
                        artifactBias = new ColdArtifactBias();
                    }
                    break;

                case 17:
                case 18:
                    RandartItemCharacteristics.ResPois = true;
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
                    RandartItemCharacteristics.ResFear = true;
                    if (artifactBias == null && Program.Rng.DieRoll(3) == 1)
                    {
                        artifactBias = new WarriorArtifactBias();
                    }
                    break;

                case 21:
                    RandartItemCharacteristics.ResLight = true;
                    break;

                case 22:
                    RandartItemCharacteristics.ResDark = true;
                    break;

                case 23:
                case 24:
                    RandartItemCharacteristics.ResBlind = true;
                    break;

                case 25:
                case 26:
                    RandartItemCharacteristics.ResConf = true;
                    if (artifactBias == null && Program.Rng.DieRoll(6) == 1)
                    {
                        artifactBias = new ChaosArtifactBias();
                    }
                    break;

                case 27:
                case 28:
                    RandartItemCharacteristics.ResSound = true;
                    break;

                case 29:
                case 30:
                    RandartItemCharacteristics.ResShards = true;
                    break;

                case 31:
                case 32:
                    RandartItemCharacteristics.ResNether = true;
                    if (artifactBias == null && Program.Rng.DieRoll(3) == 1)
                    {
                        artifactBias = new NecromanticArtifactBias();
                    }
                    break;

                case 33:
                case 34:
                    RandartItemCharacteristics.ResNexus = true;
                    break;

                case 35:
                case 36:
                    RandartItemCharacteristics.ResChaos = true;
                    if (artifactBias == null && Program.Rng.DieRoll(2) == 1)
                    {
                        artifactBias = new ChaosArtifactBias();
                    }
                    break;

                case 37:
                case 38:
                    RandartItemCharacteristics.ResDisen = true;
                    break;

                case 39:
                    if (ItemType.BaseItemCategory.CanProvideSheathOfElectricity)
                    {
                        RandartItemCharacteristics.ShElec = true;
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
                    if (ItemType.BaseItemCategory.CanProvideSheathOfFire)
                    {
                        RandartItemCharacteristics.ShFire = true;
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
                    if (ItemType.BaseItemCategory.CanReflectBoltsAndArrows)
                    {
                        RandartItemCharacteristics.Reflect = true;
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
            bool aCursed = false;
            int warriorArtifactBias = 0;
            IArtifactBias artifactBias = null;
            if (fromScroll && Program.Rng.DieRoll(4) == 1)
            {
                switch (SaveGame.Player.ProfessionIndex)
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
                int maxType = (ItemType.BaseItemCategory.CanApplySlayingBonus ? 7 : 5);
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
                if (RandartItemCharacteristics.Blows)
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
            ItemType.BaseItemCategory.ApplyRandartBonus(this);
            RandartItemCharacteristics.IgnoreAcid = true;
            RandartItemCharacteristics.IgnoreElec = true;
            RandartItemCharacteristics.IgnoreFire = true;
            RandartItemCharacteristics.IgnoreCold = true;
            int totalFlags = FlagBasedCost(TypeSpecificValue);
            if (aCursed)
            {
                CurseRandart();
            }
            if (!aCursed && Program.Rng.DieRoll(ItemType.BaseItemCategory.RandartActivationChance) == 1)
            {
                BonusPowerSubType = null;
                GiveActivationPower(ref artifactBias);
            }
            if (fromScroll)
            {
                IdentifyFully();
                IdentifyFlags.Set(Constants.IdentStoreb);
                if (!SaveGame.GetString("What do you want to call the artifact? ", out string dummyName, "(a DIY artifact)", 80))
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
                if (SaveGame.Player.ProfessionIndex == CharacterClass.Warrior)
                {
                    givePower = true;
                    giveResistance = true;
                }
                else
                {
                    RandartItemCharacteristics.Cursed = true;
                    RandartItemCharacteristics.HeavyCurse = true;
                    RandartItemCharacteristics.Aggravate = true;
                    RandartItemCharacteristics.DreadCurse = true;
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

        public bool MakeObject(bool good, bool great, bool doNotAllowChestToBeCreated)
        {
            int prob = good ? 10 : 1000;
            int baselevel = good ? SaveGame.Level.ObjectLevel + 10 : SaveGame.Level.ObjectLevel;
            if (Program.Rng.RandomLessThan(prob) != 0 || !MakeFixedArtifact())
            {
                if (good)
                {
                    PrepareAllocationTableForGoodObjects();
                }
                ItemType kIdx = SaveGame.RandomItemType(baselevel, doNotAllowChestToBeCreated);
                if (good)
                {
                    PrepareAllocationTable();
                }
                if (kIdx == null)
                {
                    return false;
                }
                AssignItemType(kIdx);
            }
            ApplyMagic(SaveGame.Level.ObjectLevel, true, good, great);
            Count = ItemType.BaseItemCategory.MakeObjectCount;
            if (!IsCursed() && !IsBroken() && ItemType.BaseItemCategory.Level > SaveGame.Difficulty)
            {
                if (SaveGame.Level != null)
                {
                    SaveGame.Level.TreasureRating +=
                        ItemType.BaseItemCategory.Level - SaveGame.Difficulty;
                }
            }
            return true;
        }

        private bool ApplyFixedArtifact()
        {
            if (Count != 1)
            {
                return false;
            }
            foreach (KeyValuePair<FixedArtifactId, FixedArtifact> pair in SaveGame.FixedArtifacts)
            {
                FixedArtifact aPtr = pair.Value;
                if (aPtr.HasOwnType)
                {
                    continue;
                }

                // Do not create another, if there is already one in the game.
                if (aPtr.CurNum != 0)
                {
                    continue;
                }

                if (aPtr.BaseItemCategory != ItemType.BaseItemCategory)
                {
                    continue;
                }
                if (aPtr.Level > SaveGame.Difficulty)
                {
                    int d = (aPtr.Level - SaveGame.Difficulty) * 2;
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

        private void ApplyRandomBonuses(ref IArtifactBias artifactBias)
        {
            if (artifactBias != null)
            {
                if (artifactBias.ApplyBonuses(this))
                {
                    return;
                }
            }
            switch (Program.Rng.DieRoll(23))
            {
                case 1:
                case 2:
                    RandartItemCharacteristics.Str = true;
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
                    RandartItemCharacteristics.Int = true;
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
                    RandartItemCharacteristics.Wis = true;
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
                    RandartItemCharacteristics.Dex = true;
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
                    RandartItemCharacteristics.Con = true;
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
                    RandartItemCharacteristics.Cha = true;
                    if (artifactBias == null && Program.Rng.DieRoll(13) != 1)
                    {
                        artifactBias = new CharismaArtifactBias();
                    }
                    break;

                case 13:
                case 14:
                    RandartItemCharacteristics.Stealth = true;
                    if (artifactBias == null && Program.Rng.DieRoll(3) == 1)
                    {
                        artifactBias = new RogueArtifactBias();
                    }
                    break;

                case 15:
                case 16:
                    RandartItemCharacteristics.Search = true;
                    if (artifactBias == null && Program.Rng.DieRoll(9) == 1)
                    {
                        artifactBias = new RangerArtifactBias();
                    }
                    break;

                case 17:
                case 18:
                    RandartItemCharacteristics.Infra = true;
                    break;

                case 19:
                    RandartItemCharacteristics.Speed = true;
                    if (artifactBias == null && Program.Rng.DieRoll(11) == 1)
                    {
                        artifactBias = new RogueArtifactBias();
                    }
                    break;

                case 20:
                case 21:
                    if (!ItemType.BaseItemCategory.CanApplyTunnelBonus)
                    {
                        ApplyRandomBonuses(ref artifactBias);
                    }
                    else
                    {
                        RandartItemCharacteristics.Tunnel = true;
                    }
                    break;

                case 22:
                case 23:
                    if (!ItemType.BaseItemCategory.CanApplyBlowsBonus)
                    {
                        ApplyRandomBonuses(ref artifactBias);
                    }
                    else
                    {
                        RandartItemCharacteristics.Blows = true;
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
                    RandartItemCharacteristics.SustStr = true;
                    if (artifactBias == null)
                    {
                        artifactBias = new StrengthArtifactBias();
                    }
                    break;

                case 2:
                    RandartItemCharacteristics.SustInt = true;
                    if (artifactBias == null)
                    {
                        artifactBias = new IntelligenceArtifactBias();
                    }
                    break;

                case 3:
                    RandartItemCharacteristics.SustWis = true;
                    if (artifactBias == null)
                    {
                        artifactBias = new WisdomArtifactBias();
                    }
                    break;

                case 4:
                    RandartItemCharacteristics.SustDex = true;
                    if (artifactBias == null)
                    {
                        artifactBias = new DexterityArtifactBias();
                    }
                    break;

                case 5:
                    RandartItemCharacteristics.SustCon = true;
                    if (artifactBias == null)
                    {
                        artifactBias = new ConstitutionArtifactBias();
                    }
                    break;

                case 6:
                    RandartItemCharacteristics.SustCha = true;
                    if (artifactBias == null)
                    {
                        artifactBias = new CharismaArtifactBias();
                    }
                    break;

                case 7:
                case 8:
                case 14:
                    RandartItemCharacteristics.FreeAct = true;
                    break;

                case 9:
                    RandartItemCharacteristics.HoldLife = true;
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
                    RandartItemCharacteristics.Lightsource = true;
                    break;

                case 12:
                case 13:
                    RandartItemCharacteristics.Feather = true;
                    break;

                case 15:
                case 16:
                case 17:
                    RandartItemCharacteristics.SeeInvis = true;
                    break;

                case 18:
                    RandartItemCharacteristics.Telepathy = true;
                    if (artifactBias == null && Program.Rng.DieRoll(9) == 1)
                    {
                        artifactBias = new MageArtifactBias();
                    }
                    break;

                case 19:
                case 20:
                    RandartItemCharacteristics.SlowDigest = true;
                    break;

                case 21:
                case 22:
                    RandartItemCharacteristics.Regen = true;
                    break;

                case 23:
                    RandartItemCharacteristics.Teleport = true;
                    break;

                case 24:
                case 25:
                case 26:
                    if (!ItemType.BaseItemCategory.CanApplyBonusArmourClassMiscPower)
                    {
                        ApplyRandomMiscPower(ref artifactBias);
                    }
                    else
                    {
                        RandartItemCharacteristics.ShowMods = true;
                        BonusArmourClass = 4 + Program.Rng.DieRoll(11);
                    }
                    break;

                case 27:
                case 28:
                case 29:
                    RandartItemCharacteristics.ShowMods = true;
                    BonusToHit += 4 + Program.Rng.DieRoll(11);
                    BonusDamage += 4 + Program.Rng.DieRoll(11);
                    break;

                case 30:
                    RandartItemCharacteristics.NoMagic = true;
                    break;

                case 31:
                    RandartItemCharacteristics.NoTele = true;
                    break;
            }
        }

        public void ApplyRandomSlaying(ref IArtifactBias artifactBias)
        {
            if (artifactBias != null)
            {
                if (artifactBias.ApplySlaying(this))
                {
                    return;
                }
            }
            ItemType.BaseItemCategory.ApplyRandomSlaying(ref artifactBias, this);
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
            RandartItemCharacteristics.HeavyCurse = true;
            RandartItemCharacteristics.Cursed = true;
            if (Program.Rng.DieRoll(4) == 1)
            {
                RandartItemCharacteristics.PermaCurse = true;
            }
            if (Program.Rng.DieRoll(3) == 1)
            {
                RandartItemCharacteristics.DreadCurse = true;
            }
            if (Program.Rng.DieRoll(2) == 1)
            {
                RandartItemCharacteristics.Aggravate = true;
            }
            if (Program.Rng.DieRoll(3) == 1)
            {
                RandartItemCharacteristics.DrainExp = true;
            }
            if (Program.Rng.DieRoll(2) == 1)
            {
                RandartItemCharacteristics.Teleport = true;
            }
            else if (Program.Rng.DieRoll(3) == 1)
            {
                RandartItemCharacteristics.NoTele = true;
            }
            if (SaveGame.Player.ProfessionIndex != CharacterClass.Warrior && Program.Rng.DieRoll(3) == 1)
            {
                RandartItemCharacteristics.NoMagic = true;
            }
            IdentifyFlags.Set(Constants.IdentCursed);
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
                    outString += BaseScrollFlavour.Syllables[Program.Rng.RandomLessThan(BaseScrollFlavour.Syllables.Length)];
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
            RandartItemCharacteristics.Activate = true;
            RechargeTimeLeft = 0;
        }

        private bool MakeFixedArtifact()
        {
            foreach (KeyValuePair<FixedArtifactId, FixedArtifact> pair in SaveGame.FixedArtifacts)
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
                if (aPtr.Level > SaveGame.Difficulty)
                {
                    int d = (aPtr.Level - SaveGame.Difficulty) * 2;
                    if (Program.Rng.RandomLessThan(d) != 0)
                    {
                        continue;
                    }
                }
                if (Program.Rng.RandomLessThan(aPtr.Rarity) != 0)
                {
                    return false;
                }
                ItemType kIdx = new ItemType(aPtr.BaseItemCategory);
                if (kIdx.BaseItemCategory.Level > SaveGame.Level.ObjectLevel)
                {
                    int d = (kIdx.BaseItemCategory.Level - SaveGame.Level.ObjectLevel) * 5;
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

        private void PrepareAllocationTable()
        {
            AllocationEntry[] table = SaveGame.AllocKindTable;
            for (int i = 0; i < SaveGame.AllocKindSize; i++)
            {
                table[i].FilteredProbabiity = table[i].BaseProbability;
            }
        }

        private void PrepareAllocationTableForGoodObjects()
        {
            AllocationEntry[] table = SaveGame.AllocKindTable;
            for (int i = 0; i < SaveGame.AllocKindSize; i++)
            {
                if (SaveGame.ItemTypes[table[i].Index].BaseItemCategory.KindIsGood)
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