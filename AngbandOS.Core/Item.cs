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
        public readonly FlagSet RandartFlags1 = new FlagSet();
        public readonly FlagSet RandartFlags2 = new FlagSet();
        public readonly FlagSet RandartFlags3 = new FlagSet();
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
        public readonly SaveGame SaveGame; // TODO: ItemCategories need access

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
                if (SlayAnimal && (rPtr.Flags3 & MonsterFlag3.Animal) != 0)
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
                if (SlayEvil && (rPtr.Flags3 & MonsterFlag3.Evil) != 0)
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
                if (SlayUndead && (rPtr.Flags3 & MonsterFlag3.Undead) != 0)
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
                if (SlayDemon && (rPtr.Flags3 & MonsterFlag3.Demon) != 0)
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
                if (SlayOrc && (rPtr.Flags3 & MonsterFlag3.Orc) != 0)
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
                if (SlayTroll && (rPtr.Flags3 & MonsterFlag3.Troll) != 0)
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
                if (SlayGiant && (rPtr.Flags3 & MonsterFlag3.Giant) != 0)
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
                if (SlayDragon && (rPtr.Flags3 & MonsterFlag3.Dragon) != 0)
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
                if (KillDragon && (rPtr.Flags3 & MonsterFlag3.Dragon) != 0)
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
                if (BrandAcid)
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
                if (BrandElec)
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
                if (BrandFire)
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
                if (BrandCold)
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
                if (BrandPois)
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
            if (itemType.Flags3.IsSet(ItemFlag3.Cursed))
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
            GetMergedFlags(f1, f2, f3); // DO NOT REFACTOR THIS
            if (IsFlavourAware())
            {
                aware = true;
            }
            if (IsKnown())
            {
                known = true;
            }
            int indexx = ItemSubCategory;
            string basenm = kPtr.BaseItemCategory.FriendlyName;
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
                    modstr = SaveGame.AmuletFlavours[indexx].Name;
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
                    modstr = SaveGame.RingFlavours[indexx].Name;
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
                    modstr = SaveGame.StaffFlavours[indexx].Name;
                    if (aware)
                    {
                        appendName = true;
                    }
                    basenm = IdentifyFlags.IsSet(Constants.IdentStoreb) ? "& Staff~" : "& # Staff~";
                    break;

                case ItemCategory.Wand:
                    modstr = SaveGame.WandFlavours[indexx].Name;
                    if (aware)
                    {
                        appendName = true;
                    }
                    basenm = IdentifyFlags.IsSet(Constants.IdentStoreb) ? "& Wand~" : "& # Wand~";
                    break;

                case ItemCategory.Rod:
                    modstr = SaveGame.RodFlavours[indexx].Name;
                    if (aware)
                    {
                        appendName = true;
                    }
                    basenm = IdentifyFlags.IsSet(Constants.IdentStoreb) ? "& Rod~" : "& # Rod~";
                    break;

                case ItemCategory.Scroll:
                    modstr = SaveGame.ScrollFlavours[indexx].Name;
                    if (aware)
                    {
                        appendName = true;
                    }
                    basenm = IdentifyFlags.IsSet(Constants.IdentStoreb) ? "& Scroll~" : "& Scroll~ titled \"#\"";
                    break;

                case ItemCategory.Potion:
                    modstr = SaveGame.PotionFlavours[indexx].Name;
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
                    modstr = SaveGame.MushroomFlavours[indexx].Name;
                    if (aware)
                    {
                        appendName = true;
                    }
                    basenm = IdentifyFlags.IsSet(Constants.IdentStoreb) ? "& Mushroom~" : "& # Mushroom~";
                    break;

                case ItemCategory.LifeBook:
                    modstr = basenm;
                    basenm = SaveGame.Player.Spellcasting.Type == CastingType.Divine
                        ? "& Book~ of Life Magic #"
                        : "& Life Spellbook~ #";
                    break;

                case ItemCategory.SorceryBook:
                    modstr = basenm;
                    basenm = SaveGame.Player.Spellcasting.Type == CastingType.Divine
                        ? "& Book~ of Sorcery #"
                        : "& Sorcery Spellbook~ #";
                    break;

                case ItemCategory.NatureBook:
                    modstr = basenm;
                    basenm = SaveGame.Player.Spellcasting.Type == CastingType.Divine
                        ? "& Book~ of Nature Magic #"
                        : "& Nature Spellbook~ #";
                    break;

                case ItemCategory.ChaosBook:
                    modstr = basenm;
                    basenm = SaveGame.Player.Spellcasting.Type == CastingType.Divine
                        ? "& Book~ of Chaos Magic #"
                        : "& Chaos Spellbook~ #";
                    break;

                case ItemCategory.DeathBook:
                    modstr = basenm;
                    basenm = SaveGame.Player.Spellcasting.Type == CastingType.Divine
                        ? "& Book~ of Death Magic #"
                        : "& Death Spellbook~ #";
                    break;

                case ItemCategory.TarotBook:
                    modstr = basenm;
                    basenm = SaveGame.Player.Spellcasting.Type == CastingType.Divine
                        ? "& Book~ of Tarot Magic #"
                        : "& Tarot Spellbook~ #";
                    break;

                case ItemCategory.FolkBook:
                    modstr = basenm;
                    basenm = SaveGame.Player.Spellcasting.Type == CastingType.Divine
                        ? "& Book~ of Folk Magic #"
                        : "& Folk Spellbook~ #";
                    break;

                case ItemCategory.CorporealBook:
                    modstr = basenm;
                    basenm = SaveGame.Player.Spellcasting.Type == CastingType.Divine
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
                t += kPtr.BaseItemCategory.FriendlyName;
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
                    FixedArtifact aPtr = SaveGame.FixedArtifacts[FixedArtifactIndex];
                    t += ' ';
                    t += aPtr.Name;
                }
                else if (RareItemTypeIndex != Enumerations.RareItemType.None)
                {
                    RareItemType ePtr = SaveGame.RareItemTypes[RareItemTypeIndex];
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
                    if (GlobalData.ChestTraps[-TypeSpecificValue] != ChestTrap.ChestNotTrapped)
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
                        case ChestTrap.ChestNotTrapped:
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
            else if (Category == ItemCategory.Light && (ItemSubCategory == Enumerations.LightType.Torch || ItemSubCategory == Enumerations.LightType.Lantern))
            {
                if (TypeSpecificValue == 1)
                {
                    t += $" (with 1 turn of light)";
                }
                else
                {
                    t += $" (with {TypeSpecificValue} turns of light)";
                }
            }

            if (known && ItemType.BaseItemCategory.HasAnyPvalMask)
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
                //SaveGame.MsgPrint("Inventory descriptions confirmed.");
            }
            else
            {
                SaveGame.MsgPrint("DESCRIPTION FAILED!");
            }
            return newDescription;
        }

        public int FlagBasedCost(int plusses)
        {
            int total = 0;
            RefreshFlagBasedProperties();
            if (Str)
            {
                total += 1000 * plusses;
            }
            if (Int)
            {
                total += 1000 * plusses;
            }
            if (Wis)
            {
                total += 1000 * plusses;
            }
            if (Dex)
            {
                total += 1000 * plusses;
            }
            if (Con)
            {
                total += 1000 * plusses;
            }
            if (Cha)
            {
                total += 250 * plusses;
            }
            if (Chaotic)
            {
                total += 10000;
            }
            if (Vampiric)
            {
                total += 13000;
            }
            if (Stealth)
            {
                total += 250 * plusses;
            }
            if (Search)
            {
                total += 100 * plusses;
            }
            if (Infra)
            {
                total += 150 * plusses;
            }
            if (Tunnel)
            {
                total += 175 * plusses;
            }
            if (Speed && plusses > 0)
            {
                total += 30000 * plusses;
            }
            if (Blows && plusses > 0)
            {
                total += 2000 * plusses;
            }
            if (AntiTheft)
            {
                total += 0;
            }
            if (SlayAnimal)
            {
                total += 3500;
            }
            if (SlayEvil)
            {
                total += 4500;
            }
            if (SlayUndead)
            {
                total += 3500;
            }
            if (SlayDemon)
            {
                total += 3500;
            }
            if (SlayOrc)
            {
                total += 3000;
            }
            if (SlayTroll)
            {
                total += 3500;
            }
            if (SlayGiant)
            {
                total += 3500;
            }
            if (SlayDragon)
            {
                total += 3500;
            }
            if (KillDragon)
            {
                total += 5500;
            }
            if (Vorpal)
            {
                total += 5000;
            }
            if (Impact)
            {
                total += 5000;
            }
            if (BrandPois)
            {
                total += 7500;
            }
            if (BrandAcid)
            {
                total += 7500;
            }
            if (BrandElec)
            {
                total += 7500;
            }
            if (BrandFire)
            {
                total += 5000;
            }
            if (BrandCold)
            {
                total += 5000;
            }
            if (SustStr)
            {
                total += 850;
            }
            if (SustInt)
            {
                total += 850;
            }
            if (SustWis)
            {
                total += 850;
            }
            if (SustDex)
            {
                total += 850;
            }
            if (SustCon)
            {
                total += 850;
            }
            if (SustCha)
            {
                total += 250;
            }
            if (ImAcid)
            {
                total += 10000;
            }
            if (ImElec)
            {
                total += 10000;
            }
            if (ImFire)
            {
                total += 10000;
            }
            if (ImCold)
            {
                total += 10000;
            }
            if (Reflect)
            {
                total += 10000;
            }
            if (FreeAct)
            {
                total += 4500;
            }
            if (HoldLife)
            {
                total += 8500;
            }
            if (ResAcid)
            {
                total += 1250;
            }
            if (ResElec)
            {
                total += 1250;
            }
            if (ResFire)
            {
                total += 1250;
            }
            if (ResCold)
            {
                total += 1250;
            }
            if (ResPois)
            {
                total += 2500;
            }
            if (ResFear)
            {
                total += 2500;
            }
            if (ResLight)
            {
                total += 1750;
            }
            if (ResDark)
            {
                total += 1750;
            }
            if (ResBlind)
            {
                total += 2000;
            }
            if (ResConf)
            {
                total += 2000;
            }
            if (ResSound)
            {
                total += 2000;
            }
            if (ResShards)
            {
                total += 2000;
            }
            if (ResNether)
            {
                total += 2000;
            }
            if (ResNexus)
            {
                total += 2000;
            }
            if (ResChaos)
            {
                total += 2000;
            }
            if (ResDisen)
            {
                total += 10000;
            }
            if (ShFire)
            {
                total += 5000;
            }
            if (ShElec)
            {
                total += 5000;
            }
            if (NoTele)
            {
                total += 2500;
            }
            if (NoMagic)
            {
                total += 2500;
            }
            if (Wraith)
            {
                total += 250000;
            }
            if (DreadCurse)
            {
                total -= 15000;
            }
            if (EasyKnow)
            {
                total += 0;
            }
            if (HideType)
            {
                total += 0;
            }
            if (ShowMods)
            {
                total += 0;
            }
            if (InstaArt)
            {
                total += 0;
            }
            if (Feather)
            {
                total += 1250;
            }
            if (Lightsource)
            {
                total += 1250;
            }
            if (SeeInvis)
            {
                total += 2000;
            }
            if (Telepathy)
            {
                total += 12500;
            }
            if (SlowDigest)
            {
                total += 750;
            }
            if (Regen)
            {
                total += 2500;
            }
            if (XtraMight)
            {
                total += 2250;
            }
            if (XtraShots)
            {
                total += 10000;
            }
            if (IgnoreAcid)
            {
                total += 100;
            }
            if (IgnoreElec)
            {
                total += 100;
            }
            if (IgnoreFire)
            {
                total += 100;
            }
            if (IgnoreCold)
            {
                total += 100;
            }
            if (Activate)
            {
                total += 100;
            }
            if (DrainExp)
            {
                total -= 12500;
            }
            if (Teleport)
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
            if (Aggravate)
            {
                total -= 10000;
            }
            if (Blessed)
            {
                total += 750;
            }
            if (Cursed)
            {
                total -= 5000;
            }
            if (HeavyCurse)
            {
                total -= 12500;
            }
            if (PermaCurse)
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

        /// <summary>
        /// Returns whether or not the item affects the blows delivered by the player when being worn.  Returns true, when the base item category,
        /// fixed artifact or rare item type this item is based on is true.  Returns false, when the item is (nothing) and the base item category, fixed
        /// artifact and rare item type that the item is based on are all false.  This property is a replacement for the flag-based merged properties.
        /// </summary>
        public bool Blows { get; private set; }
        public bool BrandAcid { get; private set; }
        public bool BrandCold { get; private set; }
        public bool BrandElec { get; private set; }
        public bool BrandFire { get; private set; }
        public bool BrandPois { get; private set; }
        public bool Cha { get; private set; }
        public bool Chaotic { get; private set; }
        public bool Con { get; private set; }
        public bool Dex { get; private set; }
        public bool Impact { get; private set; }
        public bool Infra { get; private set; }
        public bool Int { get; private set; }
        public bool KillDragon { get; private set; }
        public bool Search { get; private set; }
        public bool SlayAnimal { get; private set; }
        public bool SlayDemon { get; private set; }
        public bool SlayDragon { get; private set; }
        public bool SlayEvil { get; private set; }
        public bool SlayGiant { get; private set; }
        public bool SlayOrc { get; private set; }
        public bool SlayTroll { get; private set; }
        public bool SlayUndead { get; private set; }
        public bool Speed { get; private set; }
        public bool Stealth { get; private set; }
        public bool Str { get; private set; }
        public bool Tunnel { get; private set; }
        public bool Vampiric { get; private set; }
        public bool Vorpal { get; private set; }
        public bool Wis { get; private set; }
        public bool FreeAct { get; private set; }
        public bool HoldLife { get; private set; }
        public bool ImAcid { get; private set; }
        public bool ImCold { get; private set; }
        public bool ImElec { get; private set; }
        public bool ImFire { get; private set; }
        public bool Reflect { get; private set; }
        public bool ResAcid { get; private set; }
        public bool ResBlind { get; private set; }
        public bool ResChaos { get; private set; }
        public bool ResCold { get; private set; }
        public bool ResConf { get; private set; }
        public bool ResDark { get; private set; }
        public bool ResDisen { get; private set; }
        public bool ResElec { get; private set; }
        public bool ResFear { get; private set; }
        public bool ResFire { get; private set; }
        public bool ResLight { get; private set; }
        public bool ResNether { get; private set; }
        public bool ResNexus { get; private set; }
        public bool ResPois { get; private set; }
        public bool ResShards { get; private set; }
        public bool ResSound { get; private set; }
        public bool SustCha { get; private set; }
        public bool SustCon { get; private set; }
        public bool SustDex { get; private set; }
        public bool SustInt { get; private set; }
        public bool SustStr { get; private set; }
        public bool SustWis { get; private set; }
        public bool AntiTheft { get; private set; }
        public bool Activate { get; private set; }
        public bool Aggravate { get; private set; }
        public bool Blessed { get; private set; }
        public bool Cursed { get; private set; }
        public bool DrainExp { get; private set; }
        public bool DreadCurse { get; private set; }
        public bool EasyKnow { get; private set; }
        public bool Feather { get; private set; }
        public bool HeavyCurse { get; private set; }
        public bool HideType { get; private set; }
        public bool IgnoreAcid { get; private set; }
        public bool IgnoreCold { get; private set; }
        public bool IgnoreElec { get; private set; }
        public bool IgnoreFire { get; private set; }
        public bool InstaArt { get; private set; }
        public bool Lightsource { get; private set; }
        public bool NoMagic { get; private set; }
        public bool NoTele { get; private set; }
        public bool PermaCurse { get; private set; }
        public bool Regen { get; private set; }
        public bool SeeInvis { get; private set; }
        public bool ShElec { get; private set; }
        public bool ShFire { get; private set; }
        public bool ShowMods { get; private set; }
        public bool SlowDigest { get; private set; }
        public bool Telepathy { get; private set; }
        public bool Teleport { get; private set; }
        public bool Wraith { get; private set; }
        public bool XtraMight { get; private set; }
        public bool XtraShots { get; private set; }

        /// <summary>
        /// Refreshes all of the flag-based properties.  This is an interim method that replaces the deprecated GetMergedFlags(f1, f2, f3).  This method will
        /// be deprecated once all of the flag-based properties are maintained when the FixedArtifactIndex, RareItemType and RandartFlags automatically update
        /// the flag-based properties.
        /// </summary>
        public void RefreshFlagBasedProperties()
        {
            FlagSet f1 = new FlagSet();
            FlagSet f2 = new FlagSet();
            FlagSet f3 = new FlagSet();
            GetMergedFlags(f1, f2, f3); // NO NEED TO REFACTOR THIS CALL

            Blows = f1.IsSet(ItemFlag1.Blows);
            BrandAcid = f1.IsSet(ItemFlag1.BrandAcid);
            BrandCold = f1.IsSet(ItemFlag1.BrandCold);
            BrandElec = f1.IsSet(ItemFlag1.BrandElec);
            BrandFire = f1.IsSet(ItemFlag1.BrandFire);
            BrandPois = f1.IsSet(ItemFlag1.BrandPois);
            Cha = f1.IsSet(ItemFlag1.Cha);
            Chaotic = f1.IsSet(ItemFlag1.Chaotic);
            Con = f1.IsSet(ItemFlag1.Con);
            Dex = f1.IsSet(ItemFlag1.Dex);
            Impact = f1.IsSet(ItemFlag1.Impact);
            Infra = f1.IsSet(ItemFlag1.Infra);
            Int = f1.IsSet(ItemFlag1.Int);
            KillDragon = f1.IsSet(ItemFlag1.KillDragon);
            Search = f1.IsSet(ItemFlag1.Search);
            SlayAnimal = f1.IsSet(ItemFlag1.SlayAnimal);
            SlayDemon = f1.IsSet(ItemFlag1.SlayDemon);
            SlayDragon = f1.IsSet(ItemFlag1.SlayDragon);
            SlayEvil = f1.IsSet(ItemFlag1.SlayEvil);
            SlayGiant = f1.IsSet(ItemFlag1.SlayGiant);
            SlayOrc = f1.IsSet(ItemFlag1.SlayOrc);
            SlayTroll = f1.IsSet(ItemFlag1.SlayTroll);
            SlayUndead = f1.IsSet(ItemFlag1.SlayUndead);
            Speed = f1.IsSet(ItemFlag1.Speed);
            Stealth = f1.IsSet(ItemFlag1.Stealth);
            Str = f1.IsSet(ItemFlag1.Str);
            Tunnel = f1.IsSet(ItemFlag1.Tunnel);
            Vampiric = f1.IsSet(ItemFlag1.Vampiric);
            Vorpal = f1.IsSet(ItemFlag1.Vorpal);
            Wis = f1.IsSet(ItemFlag1.Wis);
            FreeAct = f2.IsSet(ItemFlag2.FreeAct);
            HoldLife = f2.IsSet(ItemFlag2.HoldLife);
            ImAcid = f2.IsSet(ItemFlag2.ImAcid);
            ImCold = f2.IsSet(ItemFlag2.ImCold);
            ImElec = f2.IsSet(ItemFlag2.ImElec);
            ImFire = f2.IsSet(ItemFlag2.ImFire);
            Reflect = f2.IsSet(ItemFlag2.Reflect);
            ResAcid = f2.IsSet(ItemFlag2.ResAcid);
            ResBlind = f2.IsSet(ItemFlag2.ResBlind);
            ResChaos = f2.IsSet(ItemFlag2.ResChaos);
            ResCold = f2.IsSet(ItemFlag2.ResCold);
            ResConf = f2.IsSet(ItemFlag2.ResConf);
            ResDark = f2.IsSet(ItemFlag2.ResDark);
            ResDisen = f2.IsSet(ItemFlag2.ResDisen);
            ResElec = f2.IsSet(ItemFlag2.ResElec);
            ResFear = f2.IsSet(ItemFlag2.ResFear);
            ResFire = f2.IsSet(ItemFlag2.ResFire);
            ResLight = f2.IsSet(ItemFlag2.ResLight);
            ResNether = f2.IsSet(ItemFlag2.ResNether);
            ResNexus = f2.IsSet(ItemFlag2.ResNexus);
            ResPois = f2.IsSet(ItemFlag2.ResPois);
            ResShards = f2.IsSet(ItemFlag2.ResShards);
            ResSound = f2.IsSet(ItemFlag2.ResSound);
            SustCha = f2.IsSet(ItemFlag2.SustCha);
            SustCon = f2.IsSet(ItemFlag2.SustCon);
            SustDex = f2.IsSet(ItemFlag2.SustDex);
            SustInt = f2.IsSet(ItemFlag2.SustInt);
            SustStr = f2.IsSet(ItemFlag2.SustStr);
            SustWis = f2.IsSet(ItemFlag2.SustWis);
            AntiTheft = f3.IsSet(ItemFlag3.AntiTheft);
            Activate = f3.IsSet(ItemFlag3.Activate);
            Aggravate = f3.IsSet(ItemFlag3.Aggravate);
            Blessed = f3.IsSet(ItemFlag3.Blessed);
            Cursed = f3.IsSet(ItemFlag3.Cursed);
            DrainExp = f3.IsSet(ItemFlag3.DrainExp);
            DreadCurse = f3.IsSet(ItemFlag3.DreadCurse);
            EasyKnow = f3.IsSet(ItemFlag3.EasyKnow);
            Feather = f3.IsSet(ItemFlag3.Feather);
            HeavyCurse = f3.IsSet(ItemFlag3.HeavyCurse);
            HideType = f3.IsSet(ItemFlag3.HideType);
            IgnoreAcid = f3.IsSet(ItemFlag3.IgnoreAcid);
            IgnoreCold = f3.IsSet(ItemFlag3.IgnoreCold);
            IgnoreElec = f3.IsSet(ItemFlag3.IgnoreElec);
            IgnoreFire = f3.IsSet(ItemFlag3.IgnoreFire);
            InstaArt = f3.IsSet(ItemFlag3.InstaArt);
            Lightsource = f3.IsSet(ItemFlag3.Lightsource);
            NoMagic = f3.IsSet(ItemFlag3.NoMagic);
            NoTele = f3.IsSet(ItemFlag3.NoTele);
            PermaCurse = f3.IsSet(ItemFlag3.PermaCurse);
            Regen = f3.IsSet(ItemFlag3.Regen);
            SeeInvis = f3.IsSet(ItemFlag3.SeeInvis);
            ShElec = f3.IsSet(ItemFlag3.ShElec);
            ShFire = f3.IsSet(ItemFlag3.ShFire);
            ShowMods = f3.IsSet(ItemFlag3.ShowMods);
            SlowDigest = f3.IsSet(ItemFlag3.SlowDigest);
            Telepathy = f3.IsSet(ItemFlag3.Telepathy);
            Teleport = f3.IsSet(ItemFlag3.Teleport);
            Wraith = f3.IsSet(ItemFlag3.Wraith);
            XtraMight = f3.IsSet(ItemFlag3.XtraMight);
            XtraShots = f3.IsSet(ItemFlag3.XtraShots);
        }
        /// <summary>
        /// This method is deprecated as the flag based properties is being refactored into boolean based properties.  Call the RefreshFlagBasedProperties method
        /// instead of GetMergedFlags and then use any of the flag-based properties as replacement functionality.
        /// 
        /// Combines all of the boolean properties from the item category, the fixed artifact, the rare item type and the random artifact the item is based on.
        /// If the item is a random artifact it will also add the special sustain, power and ability flags from the bonus power type.  
        /// </summary>
        /// <param name="f1"></param>
        /// <param name="f2"></param>
        /// <param name="f3"></param>
        public void GetMergedFlags(FlagSet f1, FlagSet f2, FlagSet f3) // TODO: Refactor remaining calls into RefreshFlagBasedProperties
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
                FixedArtifact aPtr = SaveGame.FixedArtifacts[FixedArtifactIndex];
                f1.Set(aPtr.Flags1);
                f2.Set(aPtr.Flags2);
                f3.Set(aPtr.Flags3);
            }
            if (RareItemTypeIndex != Enumerations.RareItemType.None)
            {
                RareItemType ePtr = SaveGame.RareItemTypes[RareItemTypeIndex];
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
            if (Activate)
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
            if (Str)
            {
                info[i++] = "It affects your strength.";
            }
            if (Int)
            {
                info[i++] = "It affects your intelligence.";
            }
            if (Wis)
            {
                info[i++] = "It affects your wisdom.";
            }
            if (Dex)
            {
                info[i++] = "It affects your dexterity.";
            }
            if (Con)
            {
                info[i++] = "It affects your constitution.";
            }
            if (Cha)
            {
                info[i++] = "It affects your charisma.";
            }
            if (Stealth)
            {
                info[i++] = "It affects your stealth.";
            }
            if (Search)
            {
                info[i++] = "It affects your searching.";
            }
            if (Infra)
            {
                info[i++] = "It affects your infravision.";
            }
            if (Tunnel)
            {
                info[i++] = "It affects your ability to tunnel.";
            }
            if (Speed)
            {
                info[i++] = "It affects your movement speed.";
            }
            if (Blows)
            {
                info[i++] = "It affects your attack speed.";
            }
            if (BrandAcid)
            {
                info[i++] = "It does extra damage from acid.";
            }
            if (BrandElec)
            {
                info[i++] = "It does extra damage from electricity.";
            }
            if (BrandFire)
            {
                info[i++] = "It does extra damage from fire.";
            }
            if (BrandCold)
            {
                info[i++] = "It does extra damage from frost.";
            }
            if (BrandPois)
            {
                info[i++] = "It poisons your foes.";
            }
            if (Chaotic)
            {
                info[i++] = "It produces chaotic effects.";
            }
            if (Vampiric)
            {
                info[i++] = "It drains life from your foes.";
            }
            if (Impact)
            {
                info[i++] = "It can cause earthquakes.";
            }
            if (Vorpal)
            {
                info[i++] = "It is very sharp and can cut your foes.";
            }
            if (KillDragon)
            {
                info[i++] = "It is a great bane of dragons.";
            }
            else if (SlayDragon)
            {
                info[i++] = "It is especially deadly against dragons.";
            }
            if (SlayOrc)
            {
                info[i++] = "It is especially deadly against orcs.";
            }
            if (SlayTroll)
            {
                info[i++] = "It is especially deadly against trolls.";
            }
            if (SlayGiant)
            {
                info[i++] = "It is especially deadly against giants.";
            }
            if (SlayDemon)
            {
                info[i++] = "It strikes at demons with holy wrath.";
            }
            if (SlayUndead)
            {
                info[i++] = "It strikes at undead with holy wrath.";
            }
            if (SlayEvil)
            {
                info[i++] = "It fights against evil with holy fury.";
            }
            if (SlayAnimal)
            {
                info[i++] = "It is especially deadly against natural creatures.";
            }
            if (SustStr)
            {
                info[i++] = "It sustains your strength.";
            }
            if (SustInt)
            {
                info[i++] = "It sustains your intelligence.";
            }
            if (SustWis)
            {
                info[i++] = "It sustains your wisdom.";
            }
            if (SustDex)
            {
                info[i++] = "It sustains your dexterity.";
            }
            if (SustCon)
            {
                info[i++] = "It sustains your constitution.";
            }
            if (SustCha)
            {
                info[i++] = "It sustains your charisma.";
            }
            if (ImAcid)
            {
                info[i++] = "It provides immunity to acid.";
            }
            if (ImElec)
            {
                info[i++] = "It provides immunity to electricity.";
            }
            if (ImFire)
            {
                info[i++] = "It provides immunity to fire.";
            }
            if (ImCold)
            {
                info[i++] = "It provides immunity to cold.";
            }
            if (FreeAct)
            {
                info[i++] = "It provides immunity to paralysis.";
            }
            if (HoldLife)
            {
                info[i++] = "It provides resistance to life draining.";
            }
            if (ResFear)
            {
                info[i++] = "It makes you completely fearless.";
            }
            if (ResAcid)
            {
                info[i++] = "It provides resistance to acid.";
            }
            if (ResElec)
            {
                info[i++] = "It provides resistance to electricity.";
            }
            if (ResFire)
            {
                info[i++] = "It provides resistance to fire.";
            }
            if (ResCold)
            {
                info[i++] = "It provides resistance to cold.";
            }
            if (ResPois)
            {
                info[i++] = "It provides resistance to poison.";
            }
            if (ResLight)
            {
                info[i++] = "It provides resistance to light.";
            }
            if (ResDark)
            {
                info[i++] = "It provides resistance to dark.";
            }
            if (ResBlind)
            {
                info[i++] = "It provides resistance to blindness.";
            }
            if (ResConf)
            {
                info[i++] = "It provides resistance to confusion.";
            }
            if (ResSound)
            {
                info[i++] = "It provides resistance to sound.";
            }
            if (ResShards)
            {
                info[i++] = "It provides resistance to shards.";
            }
            if (ResNether)
            {
                info[i++] = "It provides resistance to nether.";
            }
            if (ResNexus)
            {
                info[i++] = "It provides resistance to nexus.";
            }
            if (ResChaos)
            {
                info[i++] = "It provides resistance to chaos.";
            }
            if (ResDisen)
            {
                info[i++] = "It provides resistance to disenchantment.";
            }
            if (Wraith)
            {
                info[i++] = "It renders you incorporeal.";
            }
            if (Feather)
            {
                info[i++] = "It allows you to levitate.";
            }
            if (Lightsource)
            {
                info[i++] = "It provides permanent light.";
            }
            if (SeeInvis)
            {
                info[i++] = "It allows you to see invisible monsters.";
            }
            if (Telepathy)
            {
                info[i++] = "It gives telepathic powers.";
            }
            if (SlowDigest)
            {
                info[i++] = "It slows your metabolism.";
            }
            if (Regen)
            {
                info[i++] = "It speeds your regenerative powers.";
            }
            if (Reflect)
            {
                info[i++] = "It reflects bolts and arrows.";
            }
            if (ShFire)
            {
                info[i++] = "It produces a fiery sheath.";
            }
            if (ShElec)
            {
                info[i++] = "It produces an electric sheath.";
            }
            if (NoMagic)
            {
                info[i++] = "It produces an anti-magic shell.";
            }
            if (NoTele)
            {
                info[i++] = "It prevents teleportation.";
            }
            if (XtraMight)
            {
                info[i++] = "It fires missiles with extra might.";
            }
            if (XtraShots)
            {
                info[i++] = "It fires missiles excessively fast.";
            }
            if (DrainExp)
            {
                info[i++] = "It drains experience.";
            }
            if (Teleport)
            {
                info[i++] = "It induces random teleportation.";
            }
            if (Aggravate)
            {
                info[i++] = "It aggravates nearby creatures.";
            }
            if (Blessed)
            {
                info[i++] = "It has been blessed by the gods.";
            }
            if (IsCursed())
            {
                if (PermaCurse)
                {
                    info[i++] = "It is permanently cursed.";
                }
                else if (HeavyCurse)
                {
                    info[i++] = "It is heavily cursed.";
                }
                else
                {
                    info[i++] = "It is cursed.";
                }
            }
            if (DreadCurse)
            {
                info[i++] = "It carries an ancient foul curse.";
            }
            if (IgnoreAcid)
            {
                info[i++] = "It cannot be harmed by acid.";
            }
            if (IgnoreElec)
            {
                info[i++] = "It cannot be harmed by electricity.";
            }
            if (IgnoreFire)
            {
                info[i++] = "It cannot be harmed by fire.";
            }
            if (IgnoreCold)
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

        public void ObjectFlagsKnown(FlagSet f1, FlagSet f2, FlagSet f3)
        {
            f1.Clear();
            f2.Clear();
            f3.Clear();
            if (!IsKnown())
            {
                return;
            }
            GetMergedFlags(f1, f2, f3); // THIS IS A MONKEY WRENCH WHERE THE FLAG-BASED PROPERTIES ARE SET TO FALSE -- THE CALLING LOGIC NEEDS TO BE UPDATED
        }

        public void ObjectTried()
        {
            ItemType.BaseItemCategory.Tried = true;
        }

        public int OriginalRealValue()
        {
            FlagSet f1 = new FlagSet();
            FlagSet f2 = new FlagSet();
            FlagSet f3 = new FlagSet();
            ItemType kPtr = ItemType;
            if (kPtr.BaseItemCategory.Cost == 0)
            {
                return 0;
            }
            int value = kPtr.BaseItemCategory.Cost;
            GetMergedFlags(f1, f2, f3); // DO NOT REFACTOR THIS CALL
            if (RandartFlags1.IsSet() || RandartFlags2.IsSet() || RandartFlags3.IsSet())
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
                        if (DamageDice > kPtr.BaseItemCategory.Dd && DamageDiceSides == kPtr.BaseItemCategory.Ds)
                        {
                            value += (DamageDice - kPtr.BaseItemCategory.Dd) * DamageDiceSides * 100;
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
                        if (DamageDice > kPtr.BaseItemCategory.Dd && DamageDiceSides == kPtr.BaseItemCategory.Ds)
                        {
                            value += (DamageDice - kPtr.BaseItemCategory.Dd) * DamageDiceSides * 5;
                        }
                        break;
                    }
            }
            return value;
        }

        public int NewRealValue()
        {
            ItemType kPtr = ItemType;
            if (kPtr.BaseItemCategory.Cost == 0)
            {
                return 0;
            }
            int value = kPtr.BaseItemCategory.Cost;
            if (RandartFlags1.IsSet() || RandartFlags2.IsSet() || RandartFlags3.IsSet())
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
            value += ItemType.BaseItemCategory.GetBonusRealValue(this, value);
            return value;
        }

        public int RealValue()
        {
            int originalValue = OriginalRealValue();
            int newValue = NewRealValue();
            if (originalValue == newValue)
            {
                //SaveGame.MsgPrint("Inventory descriptions confirmed.");
            }
            else
            {
                
                SaveGame.MsgPrint("REAL VALUE FAILED!");
            }
            return newValue;
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
            if (!Activate)
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
                    if (ItemType.BaseItemCategory.CanProvideSheathOfElectricity)
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
                    if (ItemType.BaseItemCategory.CanProvideSheathOfFire)
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
                    if (ItemType.BaseItemCategory.CanReflectBoltsAndArrows)
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
            ItemType.BaseItemCategory.ApplyRandartBonus(this);
            RandartFlags3.Set(ItemFlag3.IgnoreAcid | ItemFlag3.IgnoreElec | ItemFlag3.IgnoreFire | ItemFlag3.IgnoreCold);
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
                    if (!ItemType.BaseItemCategory.CanApplyTunnelBonus)
                    {
                        ApplyRandomBonuses(ref artifactBias);
                    }
                    else
                    {
                        RandartFlags1.Set(ItemFlag1.Tunnel);
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
                    if (!ItemType.BaseItemCategory.CanApplyBonusArmourClassMiscPower)
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
            if (SaveGame.Player.ProfessionIndex != CharacterClass.Warrior && Program.Rng.DieRoll(3) == 1)
            {
                RandartFlags3.Set(ItemFlag3.NoMagic);
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
            RandartFlags3.Set(ItemFlag3.Activate);
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