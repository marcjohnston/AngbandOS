using AngbandOS.Enumerations;
using System;
using static AngbandOS.Extensions;
using AngbandOS.ArtifactBiases;
using System.IO;
using System.ComponentModel;
using AngbandOS.Core.Interface;
using AngbandOS.Core;

namespace AngbandOS.ItemCategories
{
    [Serializable]

    internal abstract class BaseItemCategory
    {
        /// <summary>
        /// Returns whether or not an object is easy to know.  Returns false, by default.
        /// </summary>
        public virtual bool ObjectEasyKnow => false;

        /// <summary>
        /// Returns true, if the object has quality.  Returns false, by default.  Armour, weapons and orbs of light return true.
        /// </summary>
        public virtual bool HasQuality => false;

        /// <summary>
        /// Returns true, if the object type has flavors.  Returns false, by default.
        /// </summary>
        public virtual bool ObjectHasFlavor => false;

        /// <summary>
        /// The column from which to take the graphical tile.
        /// </summary>
        public abstract char Character { get; }

        /// <summary>
        /// The row from which to take the graphical tile
        /// </summary>
        public virtual Colour Colour => Colour.White;

        /// <summary>
        /// A unique identifier for the entity
        /// </summary>
        public abstract string Name { get; }

        public virtual int Ac => 0;
        public virtual bool Activate => false;
        public virtual bool Aggravate => false;
        public virtual bool AntiTheft => false;
        public virtual bool Blessed => false;

        /// <summary>
        /// Returns whether or not the item affects the blows delivered by the player when being worn.
        /// </summary>
        public virtual bool Blows => false;

        /// <summary>
        /// Returns whether or not the item does extra damage from acid when being wielded.
        /// </summary>
        public virtual bool BrandAcid => false;

        /// <summary>
        /// Returns whether or not the item does extra damage from frost when being wielded.
        /// </summary>
        public virtual bool BrandCold => false;

        /// <summary>
        /// Returns whether or not the item does extra damage from electricity when being wielded.
        /// </summary>
        public virtual bool BrandElec => false;

        /// <summary>
        /// Returns whether or not the item does extra damage from fire when being wielded.
        /// </summary>
        public virtual bool BrandFire => false;

        /// <summary>
        /// Returns whether or not the item poisons foes when being wielded.
        /// </summary>
        public virtual bool BrandPois => false;

        /// <summary>
        /// Returns whether or not the item affects the charisma of the player when being worn.
        /// </summary>
        public virtual bool Cha => false;
        public virtual int Chance1 => 0;
        public virtual int Chance2 => 0;
        public virtual int Chance3 => 0;
        public virtual int Chance4 => 0;

        /// <summary>
        /// Returns whether or not the item produced chaotic effects when being wielded.
        /// </summary>
        public virtual bool Chaotic => false;

        /// <summary>
        /// Returns whether or not the item affects the constitution of the player when being worn.
        /// </summary>
        public virtual bool Con => false;
        public virtual int Cost => 0;
        public virtual bool Cursed => false;
        public virtual int Dd => 0;

        /// <summary>
        /// Returns whether or not the item affects the dexterity of the player when being worn.
        /// </summary>
        public virtual bool Dex => false;
        public virtual bool DrainExp => false;
        public virtual bool DreadCurse => false;
        public virtual int Ds => 0;
        public virtual bool EasyKnow => false;
        public virtual bool Feather => false;
        public virtual bool FreeAct => false;
        public abstract string FriendlyName { get; }
        public virtual bool HeavyCurse => false;
        public virtual bool HideType => false;
        public virtual bool HoldLife => false;
        public virtual bool IgnoreAcid => false;
        public virtual bool IgnoreCold => false;
        public virtual bool IgnoreElec => false;
        public virtual bool IgnoreFire => false;
        public virtual bool ImAcid => false;
        public virtual bool ImCold => false;
        public virtual bool ImElec => false;
        public virtual bool ImFire => false;

        /// <summary>
        /// Returns whether or not the item causes earthquakes of the player when being worn.
        /// </summary>
        public virtual bool Impact => false;

        /// <summary>
        /// Returns whether or not the item affects the infravision of the player when being worn.
        /// </summary>
        public virtual bool Infra => false;
        public virtual bool InstaArt => false;

        /// <summary>
        /// Returns whether or not the item affects the intelligence of the player when being worn.
        /// </summary>
        public virtual bool Int => false;

        /// <summary>
        /// Returns whether or not the item is a great bane of dragons.
        /// </summary>
        public virtual bool KillDragon => false;

        public virtual bool KindIsGood => false;
        public virtual int Level => 0;
        public virtual bool Lightsource => false;
        public virtual int Locale1 => 0;
        public virtual int Locale2 => 0;
        public virtual int Locale3 => 0;
        public virtual int Locale4 => 0;
        public virtual bool NoMagic => false;
        public virtual bool NoTele => false;
        public virtual bool PermaCurse => false;
        public virtual int Pval => 0;
        public virtual bool Reflect => false;
        public virtual bool Regen => false;
        public virtual bool ResAcid => false;
        public virtual bool ResBlind => false;
        public virtual bool ResChaos => false;
        public virtual bool ResCold => false;
        public virtual bool ResConf => false;
        public virtual bool ResDark => false;
        public virtual bool ResDisen => false;
        public virtual bool ResElec => false;
        public virtual bool ResFear => false;
        public virtual bool ResFire => false;
        public virtual bool ResLight => false;
        public virtual bool ResNether => false;
        public virtual bool ResNexus => false;
        public virtual bool ResPois => false;
        public virtual bool ResShards => false;
        public virtual bool ResSound => false;

        /// <summary>
        /// Returns whether or not the item affects the search capabilities of the player when being worn.
        /// </summary>
        public virtual bool Search => false;

        public virtual bool SeeInvis => false;
        public virtual bool ShElec => false;
        public virtual bool ShFire => false;
        public virtual bool ShowMods => false;
        public virtual bool SlayAnimal => false;
        public virtual bool SlayDemon => false;
        public virtual bool SlayDragon => false;
        public virtual bool SlayEvil => false;
        public virtual bool SlayGiant => false;
        public virtual bool SlayOrc => false;
        public virtual bool SlayTroll => false;
        public virtual bool SlayUndead => false;
        public virtual bool SlowDigest => false;

        /// <summary>
        /// Returns whether or not the item affects the attack speed of the player when being worn.
        /// </summary>
        public virtual bool Speed => false;

        /// <summary>
        /// Returns whether or not the item affects the stealth of the player when being worn.
        /// </summary>
        public virtual bool Stealth => false;

        /// <summary>
        /// Returns whether or not the item affects the strength of the player when being worn.
        /// </summary>
        public virtual bool Str => false;

        /// <summary>
        /// Returns the subcategory enumeration that the item belongs to.  This property is to be deleted.  Returns null, when not in use.
        /// </summary>
        public abstract int? SubCategory { get; }

        public virtual bool SustCha => false;
        public virtual bool SustCon => false;
        public virtual bool SustDex => false;
        public virtual bool SustInt => false;
        public virtual bool SustStr => false;
        public virtual bool SustWis => false;
        public virtual bool Telepathy => false;
        public virtual bool Teleport => false;
        public virtual int ToA => 0;
        public virtual int ToD => 0;
        public virtual int ToH => 0;
        public virtual bool Tried => false;

        /// <summary>
        /// Returns whether or not the item affects the tunnelling capabilities of the player when being worn.
        /// </summary>
        public virtual bool Tunnel => false;

        public virtual bool Vampiric => false;

        /// <summary>
        /// Returns whether or not the item is very sharp and cuts foes of the player when being used.
        /// </summary>
        public virtual bool Vorpal => false;

        public virtual int Weight => 0;

        /// <summary>
        /// Returns whether or not the item affects the wisdom of the player when being worn.
        /// </summary>
        public virtual bool Wis => false;
        public virtual bool Wraith => false;
        public virtual bool XtraMight => false;
        public virtual bool XtraShots => false;

        /// <summary>
        /// Returns the ItemCategoryEnum value for backwards compatibility.  This property will be deleted.
        /// </summary>
        public virtual ItemCategory CategoryEnum { get; }

        /// <summary>
        /// Returns true, if the item is capable of vorpal slaying.  Only swords return true.  Returns false, by default.
        /// </summary>
        public virtual bool CanVorpalSlay => false;

        /// <summary>
        /// Returns true, if the item is capable of having slaying bonuses applied.  Only weapons return true.  Returns false by default.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public virtual bool CanApplySlayingBonus => false;

        /// <summary>
        /// Returns true, if the item can be stomped.  Returns the stompable status based on the item "Feeling", by default.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public virtual bool IsStompable(Item item)
        {
            if (item.ItemType.HasQuality())
            {
                switch (item.GetDetailedFeeling())
                {
                    case "terrible":
                    case "worthless":
                    case "cursed":
                    case "broken":
                        return item.ItemType.Stompable[StompableType.Broken];

                    case "average":
                        return item.ItemType.Stompable[StompableType.Average];

                    case "good":
                        return item.ItemType.Stompable[StompableType.Good];

                    case "excellent":
                        return item.ItemType.Stompable[StompableType.Excellent];

                    case "special":
                        return false;

                    default:
                        throw new InvalidDataException($"Unrecognised item quality ({item.GetDetailedFeeling()})");
                }
            }
            return item.ItemType.Stompable[StompableType.Broken];
        }

        //    public virtual bool CanSlay => false;

        /// <summary>
        /// Returns the number of additional items to be produced, when the item is mass produced for a store.  Returns 0, by default.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public virtual int GetAdditionalMassProduceCount(Item item) => 0;

        protected int MassRoll(int num, int max)
        {
            int t = 0;
            for (int i = 0; i < num; i++)
            {
                t += Program.Rng.RandomLessThan(max);
            }
            return t;
        }

        public virtual void ApplyRandomSlaying(ref IArtifactBias artifactBias, Item item)
        {
            switch (Program.Rng.DieRoll(34))
            {
                case 1:
                case 2:
                    item.RandartFlags1.Set(ItemFlag1.SlayAnimal);
                    break;

                case 3:
                case 4:
                    item.RandartFlags1.Set(ItemFlag1.SlayEvil);
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
                    item.RandartFlags1.Set(ItemFlag1.SlayUndead);
                    if (artifactBias == null && Program.Rng.DieRoll(9) == 1)
                    {
                        artifactBias = new PriestlyArtifactBias();
                    }
                    break;

                case 7:
                case 8:
                    item.RandartFlags1.Set(ItemFlag1.SlayDemon);
                    if (artifactBias == null && Program.Rng.DieRoll(9) == 1)
                    {
                        artifactBias = new PriestlyArtifactBias();
                    }
                    break;

                case 9:
                case 10:
                    item.RandartFlags1.Set(ItemFlag1.SlayOrc);
                    break;

                case 11:
                case 12:
                    item.RandartFlags1.Set(ItemFlag1.SlayTroll);
                    break;

                case 13:
                case 14:
                    item.RandartFlags1.Set(ItemFlag1.SlayGiant);
                    break;

                case 15:
                case 16:
                    item.RandartFlags1.Set(ItemFlag1.SlayDragon);
                    break;

                case 17:
                    item.RandartFlags1.Set(ItemFlag1.KillDragon);
                    break;

                case 18:
                case 19:
                    if (CanVorpalSlay)
                    {
                        item.RandartFlags1.Set(ItemFlag1.Vorpal);
                        if (artifactBias == null && Program.Rng.DieRoll(9) == 1)
                        {
                            artifactBias = new WarriorArtifactBias();
                        }
                    }
                    else
                    {
                        item.ApplyRandomSlaying(ref artifactBias);
                    }
                    break;

                case 20:
                    item.RandartFlags1.Set(ItemFlag1.Impact);
                    break;

                case 21:
                case 22:
                    item.RandartFlags1.Set(ItemFlag1.BrandFire);
                    if (artifactBias == null)
                    {
                        artifactBias = new FireArtifactBias();
                    }
                    break;

                case 23:
                case 24:
                    item.RandartFlags1.Set(ItemFlag1.BrandCold);
                    if (artifactBias == null)
                    {
                        artifactBias = new ColdArtifactBias();
                    }
                    break;

                case 25:
                case 26:
                    item.RandartFlags1.Set(ItemFlag1.BrandElec);
                    if (artifactBias == null)
                    {
                        artifactBias = new ElectricityArtifactBias();
                    }
                    break;

                case 27:
                case 28:
                    item.RandartFlags1.Set(ItemFlag1.BrandAcid);
                    if (artifactBias == null)
                    {
                        artifactBias = new AcidArtifactBias();
                    }
                    break;

                case 29:
                case 30:
                    item.RandartFlags1.Set(ItemFlag1.BrandPois);
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
                    item.RandartFlags1.Set(ItemFlag1.Vampiric);
                    if (artifactBias == null)
                    {
                        artifactBias = new NecromanticArtifactBias();
                    }
                    break;

                default:
                    item.RandartFlags1.Set(ItemFlag1.Chaotic);
                    if (artifactBias == null)
                    {
                        artifactBias = new ChaosArtifactBias();
                    }
                    break;
            }
        }

        /// <summary>
        /// Returns a description for the item.  Returns a macro processed description, by default.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="includeCountPrefix">Specify true, to include the number of items as the prefix; false, to excluse the count.  Pluralization will still
        /// occur when the count is not included.</param>
        /// <returns></returns>
        public virtual string GetDescription(Item item, bool includeCountPrefix)
        {
            string pluralizedName = ApplyPlurizationMacro(item.ItemType.Name, item.Count);
            return ApplyGetPrefixCountMacro(includeCountPrefix, pluralizedName, item.Count, item.IsKnownArtifact);
        }

        /// <summary>
        /// Returns an additional description of the item that is appended to the base description, when needed.  Returns string.empty by default.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public virtual string GetDetailedDescription(Item item)
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

                if (item.BaseArmourClass != 0)
                {
                    // Add base armour class for all types of armour and when the base armour class is greater than zero.
                    s += $" [{item.BaseArmourClass},{GetSignedValue(item.BonusArmourClass)}]";
                }
                else if (item.BonusArmourClass != 0)
                {
                    // This is not armour, only show bonus armour class, if it is not zero and we know about it.
                    s += $" [{GetSignedValue(item.BonusArmourClass)}]";
                }
            }
            return s;
        }

        /// <summary>
        /// Returns an additional description of the item that is appended to the detailed description, when needed.  
        /// By default, empty is returned, if the item is known; otherwise, the HideType, Speed, Blows, Stealth, Search, Infra, Tunnel and recharging time characteristics are returned.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public virtual string GetVerboseDescription(Item item)
        {
            string s = "";

            FlagSet f1 = new FlagSet();
            FlagSet f2 = new FlagSet();
            FlagSet f3 = new FlagSet();
            item.GetMergedFlags(f1, f2, f3);
            if (item.IsKnown() && f1.IsSet(ItemFlag1.PvalMask))
            {
                s += $" ({GetSignedValue(item.TypeSpecificValue)}";
                if (f3.IsSet(ItemFlag3.HideType))
                {
                }
                else if (f1.IsSet(ItemFlag1.Speed))
                {
                    s += " speed";
                }
                else if (f1.IsSet(ItemFlag1.Blows))
                {
                    if (item.TypeSpecificValue > 1)
                    {
                        s += " attacks";
                    }
                    else
                    {
                        s += " attack";
                    }
                }
                else if (f1.IsSet(ItemFlag1.Stealth))
                {
                    s += " stealth";
                }
                else if (f1.IsSet(ItemFlag1.Search))
                {
                    s += " searching";
                }
                else if (f1.IsSet(ItemFlag1.Infra))
                {
                    s += " infravision";
                }
                else if (f1.IsSet(ItemFlag1.Tunnel))
                {
                }
                s += ")";
            }
            if (item.IsKnown() && item.RechargeTimeLeft != 0)
            {
                s += " (charging)";
            }
            return s;
        }

        /// <summary>
        /// Returns an additional description to fully identify the item that is appended to the verbode description, when needed.  
        /// By default, returns the description for inscriptions, cursed, empty, tried and on discount.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public virtual string GetFullDescription(Item item)
        {
            string tmpVal2 = "";
            if (!string.IsNullOrEmpty(item.Inscription))
            {
                tmpVal2 = item.Inscription;
            }
            else if (item.IsCursed() && (item.IsKnown() || item.IdentifyFlags.IsSet(Constants.IdentSense)))
            {
                tmpVal2 = "cursed";
            }
            else if (!item.IsKnown() && item.IdentifyFlags.IsSet(Constants.IdentEmpty))
            {
                tmpVal2 = "empty";
            }
            else if (!item.IsFlavourAware() && item.ItemType.Tried)
            {
                tmpVal2 = "tried";
            }
            else if (item.Discount != 0)
            {
                tmpVal2 = item.Discount.ToString();
                tmpVal2 += "% off";
            }
            if (!string.IsNullOrEmpty(tmpVal2))
            {
                tmpVal2 = $" {{{tmpVal2}}}";
            }
            return tmpVal2;
        }

        /// <summary>
        /// Gets an additional bonus gold real value associated with the item.  Returns a type specific value by default.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public virtual int GetBonusRealValue(Item item, int value) => 0;

        protected int GetTypeSpecificValue(Item item, int value)
        {
            if (item.TypeSpecificValue == 0)
            {
                return 0;
            }

            int bonusValue = 0;
            FlagSet f1 = new FlagSet();
            FlagSet f2 = new FlagSet();
            FlagSet f3 = new FlagSet();
            item.GetMergedFlags(f1, f2, f3);
            if (f1.IsSet(ItemFlag1.Str))
            {
                bonusValue += item.TypeSpecificValue * 200;
            }
            if (f1.IsSet(ItemFlag1.Int))
            {
                bonusValue += item.TypeSpecificValue * 200;
            }
            if (f1.IsSet(ItemFlag1.Wis))
            {
                bonusValue += item.TypeSpecificValue * 200;
            }
            if (f1.IsSet(ItemFlag1.Dex))
            {
                bonusValue += item.TypeSpecificValue * 200;
            }
            if (f1.IsSet(ItemFlag1.Con))
            {
                bonusValue += item.TypeSpecificValue * 200;
            }
            if (f1.IsSet(ItemFlag1.Cha))
            {
                bonusValue += item.TypeSpecificValue * 200;
            }
            if (f1.IsSet(ItemFlag1.Stealth))
            {
                bonusValue += item.TypeSpecificValue * 100;
            }
            if (f1.IsSet(ItemFlag1.Search))
            {
                bonusValue += item.TypeSpecificValue * 100;
            }
            if (f1.IsSet(ItemFlag1.Infra))
            {
                bonusValue += item.TypeSpecificValue * 50;
            }
            if (f1.IsSet(ItemFlag1.Tunnel))
            {
                bonusValue += item.TypeSpecificValue * 50;
            }
            if (f1.IsSet(ItemFlag1.Blows))
            {
                bonusValue += item.TypeSpecificValue * 5000;
            }
            if (f1.IsSet(ItemFlag1.Speed))
            {
                bonusValue += item.TypeSpecificValue * 3000;
            }
            return bonusValue;
        }

        /// <summary>
        /// Returns true, if the item is deemed as worthless.  Worthless items will ignore their RealValue and will always have 0 real value.  Returns false by default.
        /// </summary>
        public virtual bool IsWorthless(Item item) => false;

        /// <summary>
        /// Returns a description of the items' activation.  Returns null by default.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public virtual string DescribeActivationEffect(Item item)
        {
            return null;
        }

        /// <summary>
        /// Returns an additional description when identified fully.  Returns null by default.  Only light sources provide an additional description.
        /// </summary>
        public virtual string Identify(Item item) => null;

        /// <summary>
        /// Returns the base value for a non flavor-aware item.  Returns 0, by default.
        /// </summary>
        public virtual int BaseValue => 0;

        /// <summary>
        /// Returns true, if the item is susceptible to electricity.  Returns false, by default.
        /// </summary>
        public virtual bool HatesElectricity => false;

        /// <summary>
        /// Returns true, if the item is susceptible to fire.  Returns false, by default.
        /// </summary>
        public virtual bool HatesFire => false;

        /// <summary>
        /// Returns true, if the item is susceptible to acid.  Returns false, by default.
        /// </summary>
        public virtual bool HatesAcid => false;

        /// <summary>
        /// Returns true, if the item is susceptible to cold.  Returns false, by default.
        /// </summary>
        public virtual bool HatesCold => false;

        //    public virtual bool IgnoredByMonsters => false;

        //    public virtual bool IsCharged => false;

        //    public virtual bool CanBeConsumed => false;

        /// <summary>
        /// Returns the realm a spellbook belongs to.  Returns Realm.None by default for non-book objects.
        /// </summary>
        public virtual Realm SpellBookToToRealm => Realm.None;

        /// <summary>
        /// Applies magic to the item.  Does nothing, by default.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="level"></param>
        /// <param name="power"></param>
        public virtual void ApplyMagic(Item item, int level, int power)
        {
        }

        /// <summary>
        /// Returns true, if an item can absorb another item of the same type.  Returns false, by default, if either item is known.
        /// </summary>
        public virtual bool CanAbsorb(Item item, Item other)
        {
            if (!item.IsKnown() || !other.IsKnown())
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Returns true, if the item can provide a sheath of electricity.  Returns false, by default.  Cloaks, soft and hard armor return true.
        /// </summary>
        public virtual bool CanProvideSheathOfElectricity => false;

        /// <summary>
        /// Returns true, if the item can provide a sheath of fire.  Returns false, by default.  Cloaks, soft and hard armor return true.
        /// </summary>
        public virtual bool CanProvideSheathOfFire => false;

        /// <summary>
        /// Returns true, if the item can reflect bolts and arrows.  Returns false, by default.  Shields, helms, cloaks and hard armor return true.
        /// </summary>
        public virtual bool CanReflectBoltsAndArrows => false;

        /// <summary>
        /// Returns a 1-in-chance for a random artifact to have activation applied.  Returns 3 by default.  Armour returns double the default.
        /// </summary>
        public virtual int RandartActivationChance => Constants.ActivationChance;

        /// <summary>
        /// Applies an additional bonus to random artifacts.  Does nothing by default.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public virtual void ApplyRandartBonus(Item item)
        {
        }

        /// <summary>
        /// Returns a count for the number of items to create during the MakeObject.  Returns 1, by default.  Spikes, shots, arrows and bolts return values greater than 1.
        /// </summary>
        public virtual int MakeObjectCount => 1;

        /// <summary>
        /// Returns true, if the item multiplies damages against a specific monster race.  Returns false, by default. Shots, arrows, bolts, hafted, polearms, swords and digging all return true.
        /// </summary>
        public virtual bool GetsDamageMultiplier => false;

        /// <summary>
        /// Returns the percentage chance that an thrown or fired item breaks.  Returns 10, or 10%, by default.  A value of 101, guarantees the item will break.
        /// </summary>
        public virtual int PercentageBreakageChance => 10;

        /// <summary>
        /// Returns true, if the item can apply a bonus armour class for miscellaneous power.  Only weapons return true.  Returns false, by default.
        /// </summary>
        public virtual bool CanApplyBonusArmourClassMiscPower => false;

        /// <summary>
        /// Returns true, if the item can apply a blows bonus.  All weapons, except for the bow, return true.  Returns false, by default.
        /// </summary>
        public virtual bool CanApplyBlowsBonus => false;

        /// <summary>
        /// Returns true, if the item can apply a tunnel bonus.  Only weapons, return true.  Returns false, by default.
        /// </summary>
        public virtual bool CanApplyTunnelBonus => false;

        protected int GetBonusValue(int max, int level)
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
    }
}
