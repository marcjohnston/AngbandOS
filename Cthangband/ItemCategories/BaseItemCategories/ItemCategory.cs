using Cthangband.Enumerations;
using Cthangband.StaticData;
using System;
using static Cthangband.Extensions;
using Cthangband.ArtifactBiases;
using System.IO;

namespace Cthangband.ItemCategories
{
    [Serializable]

    internal abstract class BaseItemCategory : IItemCategory
    {
        public BaseItemCategory()
        {
        }

        public virtual bool CanVorpalSlay => false;

        public virtual bool CanApplySlayingBonus => false;

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

        public static IItemCategory CreateFromEnum(ItemCategory itemCategory)
        {
            switch (itemCategory)
            {
                case ItemCategory.None:
                    return null;
                case ItemCategory.Skeleton:
                    return new SkeletonItemCategory();
                case ItemCategory.Bottle:
                    return new BottleItemCategory();
                case ItemCategory.Junk:
                    return new JunkItemCategory();
                case ItemCategory.Spike:
                    return new SpikeItemCategory();
                case ItemCategory.Chest:
                    return new ChestItemCategory();
                case ItemCategory.Shot:
                    return new ShotItemCategory();
                case ItemCategory.Arrow:
                    return new ArrowItemCategory();
                case ItemCategory.Bolt:
                    return new BoltItemCategory();
                case ItemCategory.Bow:
                    return new BowItemCategory();
                case ItemCategory.Digging:
                    return new DiggingItemCategory();
                case ItemCategory.Hafted:
                    return new HaftedItemCategory();
                case ItemCategory.Polearm:
                    return new PolearmItemCategory();
                case ItemCategory.Sword:
                    return new SwordItemCategory();
                case ItemCategory.Boots:
                    return new BootsItemCategory();
                case ItemCategory.Gloves:
                    return new GlovesItemCategory();
                case ItemCategory.Helm:
                    return new HelmItemCategory();
                case ItemCategory.Crown:
                    return new CrownItemCategory();
                case ItemCategory.Shield:
                    return new ShieldItemCategory();
                case ItemCategory.Cloak:
                    return new CloakItemCategory();
                case ItemCategory.SoftArmor:
                    return new SoftArmorItemCategory();
                case ItemCategory.HardArmor:
                    return new HardArmorItemCategory();
                case ItemCategory.DragArmor:
                    return new DragArmorItemCategory();
                case ItemCategory.Light:
                    return new LightItemCategory();
                case ItemCategory.Amulet:
                    return new AmuletItemCategory();
                case ItemCategory.Ring:
                    return new RingItemCategory();
                case ItemCategory.Staff:
                    return new StaffItemCategory();
                case ItemCategory.Wand:
                    return new WandItemCategory();
                case ItemCategory.Rod:
                    return new RodItemCategory();
                case ItemCategory.Scroll:
                    return new ScrollItemCategory();
                case ItemCategory.Potion:
                    return new PotionItemCategory();
                case ItemCategory.Flask:
                    return new FlaskItemCategory();
                case ItemCategory.Food:
                    return new FoodItemCategory();
                case ItemCategory.LifeBook:
                    return new LifeBookItemCategory();
                case ItemCategory.SorceryBook:
                    return new SorceryBookItemCategory();
                case ItemCategory.NatureBook:
                    return new NatureBookItemCategory();
                case ItemCategory.ChaosBook:
                    return new ChaosBookItemCategory();
                case ItemCategory.DeathBook:
                    return new DeathBookItemCategory();
                case ItemCategory.TarotBook:
                    return new TarotBookItemCategory();
                case ItemCategory.FolkBook:
                    return new FolkBookItemCategory();
                case ItemCategory.CorporealBook:
                    return new CorporealBookItemCategory();
                case ItemCategory.Gold:
                    return new GoldItemCategory();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        //    public virtual bool CanSlay => false;

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

        public virtual string GetDescription(Item item, bool includeCountPrefix)
        {
            string pluralizedName = ApplyPlurizationMacro(item.ItemType.Name, item.Count);
            return ApplyGetPrefixCountMacro(includeCountPrefix, pluralizedName, item.Count, item.IsKnownArtifact);
        }

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

        public virtual bool IsWorthless(Item item) => false;

        public virtual string DescribeActivationEffect(Item item)
        {
            return null;
        }

        public virtual string Identify(Item item) => null;

        public virtual int BaseValue => 0;
        public virtual bool HatesElectricity => false;
        public virtual bool HatesFire => false;
        public virtual bool HatesAcid => false;

        public virtual bool HatesCold => false;

        //    public virtual bool IgnoredByMonsters => false;

        //    public virtual bool IsCharged => false;

        //    public virtual bool CanBeConsumed => false;

        public virtual Colour Colour => Colour.White;

        //    public virtual Realm SpellBookToToRealm => Realm.None;


        public virtual void ApplyMagic(Item item, int level, int power)
        {
        }

        public virtual bool CanAbsorb(Item item, Item other)
        {
            if (!item.IsKnown() || !other.IsKnown())
            {
                return false;
            }
            return true;
        }

        public virtual bool CanProvideSheathOfElectricity => false;

        public virtual bool CanProvideSheathOfFire => false;

        public virtual bool CanReflectBoltsAndArrows => false;

        public virtual int RandartActivationChance => Constants.ActivationChance;

        public virtual void ApplyRandartBonus(Item item)
        {
        }

        public virtual int MakeObjectCount => 1;

        public virtual bool GetsDamageMultiplier => false;

        public virtual int PercentageBreakageChance => 10;

        public virtual bool CanApplyBonusArmourClassMiscPower => false;

        public virtual bool CanApplyBlowsBonus => false;
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
