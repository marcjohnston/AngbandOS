using AngbandOS.ArtifactBiases;
using AngbandOS.Core;
using AngbandOS.Enumerations;
using System;
using static AngbandOS.Extensions;

namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    /// <summary>
    /// Represents armour items.  Boots, clocks, crowns, dragon armour, gloves, hard armour, helm, shield and soft armour are all armour classes.
    /// </summary>
    internal abstract class ArmourItemClass : ItemClass
    {
        public override bool HasQuality => true;

        public override void ApplyRandartBonus(Item item)
        {
            item.BonusArmourClass += Program.Rng.DieRoll(item.BonusArmourClass > 19 ? 1 : 20 - item.BonusArmourClass);
        }

        public override int RandartActivationChance => base.RandartActivationChance * 2;
        public override int GetAdditionalMassProduceCount(Item item)
        {
            int cost = item.Value();
            if (item.RareItemTypeIndex != 0)
            {
                return 0;
            }
            if (cost <= 10)
            {
                return MassRoll(3, 5);
            }
            if (cost <= 100)
            {
                return MassRoll(3, 5);
            }
            return 0;
        }

        /// <summary>
        /// Returns true, for all armour where the armour class (ToA) is greater than or equal to zero.
        /// </summary>
        public override bool KindIsGood => ToA >= 0;

        public override int? GetBonusRealValue(Item item, int value)
        {
            if (item.BonusArmourClass < 0)
                return null;

            return (item.BonusToHit + item.BonusDamage + item.BonusArmourClass) * 100;
        }

        public override int? GetTypeSpecificRealValue(Item item, int value)
        {
            return ComputeTypeSpecificRealValue(item, value);
        }

        public override bool CanAbsorb(Item item, Item other)
        {
            if (!item.IsKnown() || !other.IsKnown())
            {
                return false;
            }
            if (!item.StatsAreSame(other))
            {
                return false;
            }
            return true;
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

        private void ApplyDragonscaleResistance(Item item)
        {
            do
            {
                IArtifactBias artifactBias = null;
                if (Program.Rng.DieRoll(4) == 1)
                {
                    item.ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(14) + 4);
                }
                else
                {
                    item.ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(22) + 16);
                }
            } while (Program.Rng.DieRoll(2) == 1);
        }

        public override void ApplyMagic(Item item, int level, int power)
        {
            if (power != 0 ||
                item.Category == ItemTypeEnum.Helm && item.ItemSubCategory == HelmType.SvDragonHelm ||
                item.Category == ItemTypeEnum.Shield && item.ItemSubCategory == ShieldType.SvDragonShield ||
                item.Category == ItemTypeEnum.Cloak && item.ItemSubCategory == CloakType.SvElvenCloak)
            {
                int toac1 = Program.Rng.DieRoll(5) + GetBonusValue(5, level);
                int toac2 = GetBonusValue(10, level);
                IArtifactBias artifactBias = null;
                if (power > 0)
                {
                    item.BonusArmourClass += toac1;
                    if (power > 1)
                    {
                        item.BonusArmourClass += toac2;
                    }
                }
                else if (power < 0)
                {
                    item.BonusArmourClass -= toac1;
                    if (power < -1)
                    {
                        item.BonusArmourClass -= toac2;
                    }
                    if (item.BonusArmourClass < 0)
                    {
                        item.IdentCursed = true;
                    }
                }
                switch (item.Category)
                {
                    case ItemTypeEnum.DragArmor:
                        {
                            if (item.SaveGame.Level != null)
                            {
                                item.SaveGame.Level.TreasureRating += 30;
                            }
                            break;
                        }
                    case ItemTypeEnum.HardArmor:
                    case ItemTypeEnum.SoftArmor:
                        {
                            if (power > 1)
                            {
                                if (item.Category == ItemTypeEnum.SoftArmor &&
                                    item.ItemSubCategory == SoftArmourType.SvRobe && Program.Rng.RandomLessThan(100) < 10)
                                {
                                    item.RareItemTypeIndex = Enumerations.RareItemType.ArmourOfPermanence;
                                    break;
                                }
                                switch (Program.Rng.DieRoll(21))
                                {
                                    case 1:
                                    case 2:
                                    case 3:
                                    case 4:
                                        {
                                            item.RareItemTypeIndex = Enumerations.RareItemType.ArmourOfResistAcid;
                                            break;
                                        }
                                    case 5:
                                    case 6:
                                    case 7:
                                    case 8:
                                        {
                                            item.RareItemTypeIndex = Enumerations.RareItemType.ArmourOfResistLightning;
                                            break;
                                        }
                                    case 9:
                                    case 10:
                                    case 11:
                                    case 12:
                                        {
                                            item.RareItemTypeIndex = Enumerations.RareItemType.ArmourOfResistFire;
                                            break;
                                        }
                                    case 13:
                                    case 14:
                                    case 15:
                                    case 16:
                                        {
                                            item.RareItemTypeIndex = Enumerations.RareItemType.ArmourOfResistCold;
                                            break;
                                        }
                                    case 17:
                                    case 18:
                                        {
                                            item.RareItemTypeIndex = Enumerations.RareItemType.ArmourOfResistance;
                                            if (Program.Rng.DieRoll(4) == 1)
                                            {
                                                item.RandartItemCharacteristics.ResPois = true;
                                            }
                                            item.ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(22) + 16);
                                            break;
                                        }
                                    case 20:
                                    case 21:
                                        {
                                            item.RareItemTypeIndex = Enumerations.RareItemType.ArmourOfYith;
                                            break;
                                        }
                                    default:
                                        {
                                            item.CreateRandart(false);
                                            break;
                                        }
                                }
                            }
                            break;
                        }
                    case ItemTypeEnum.Shield:
                        {
                            if (item.ItemSubCategory == ShieldType.SvDragonShield)
                            {
                                if (item.SaveGame.Level != null)
                                {
                                    item.SaveGame.Level.TreasureRating += 5;
                                }
                                ApplyDragonscaleResistance(item);
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
                                                item.RareItemTypeIndex = Enumerations.RareItemType.ShieldOfResistAcid;
                                                break;
                                            }
                                        case 2:
                                        case 3:
                                        case 4:
                                        case 12:
                                        case 13:
                                        case 14:
                                            {
                                                item.RareItemTypeIndex = Enumerations.RareItemType.ShieldOfResistLightning;
                                                break;
                                            }
                                        case 5:
                                        case 6:
                                        case 15:
                                        case 16:
                                            {
                                                item.RareItemTypeIndex = Enumerations.RareItemType.ShieldOfResistFire;
                                                break;
                                            }
                                        case 7:
                                        case 8:
                                        case 9:
                                        case 17:
                                        case 18:
                                        case 19:
                                            {
                                                item.RareItemTypeIndex = Enumerations.RareItemType.ShieldOfResistCold;
                                                break;
                                            }
                                        case 10:
                                        case 20:
                                            {
                                                item.ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(34) + 4);
                                                if (Program.Rng.DieRoll(4) == 1)
                                                {
                                                    item.RandartItemCharacteristics.ResPois = true;
                                                }
                                                item.RareItemTypeIndex = Enumerations.RareItemType.ShieldOfResistance;
                                                break;
                                            }
                                        case 21:
                                        case 22:
                                            {
                                                item.RareItemTypeIndex = Enumerations.RareItemType.ShieldOfReflection;
                                                break;
                                            }
                                        default:
                                            {
                                                item.CreateRandart(false);
                                                break;
                                            }
                                    }
                                }
                            }
                            break;
                        }
                    case ItemTypeEnum.Gloves:
                        {
                            if (power > 1)
                            {
                                if (Program.Rng.DieRoll(20) == 1)
                                {
                                    item.CreateRandart(false);
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
                                                item.RareItemTypeIndex = Enumerations.RareItemType.GlovesOfFreeAction;
                                                break;
                                            }
                                        case 5:
                                        case 6:
                                        case 7:
                                            {
                                                item.RareItemTypeIndex = Enumerations.RareItemType.GlovesOfSlaying;
                                                break;
                                            }
                                        case 8:
                                        case 9:
                                            {
                                                item.RareItemTypeIndex = Enumerations.RareItemType.GlovesOfAgility;
                                                break;
                                            }
                                        case 10:
                                            {
                                                item.RareItemTypeIndex = Enumerations.RareItemType.GlovesOfPower;
                                                item.ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(22) + 16);
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
                                            item.RareItemTypeIndex = Enumerations.RareItemType.GlovesOfClumsiness;
                                            break;
                                        }
                                    default:
                                        {
                                            item.RareItemTypeIndex = Enumerations.RareItemType.GlovesOfWeakness;
                                            break;
                                        }
                                }
                            }
                            break;
                        }
                    case ItemTypeEnum.Boots:
                        {
                            if (power > 1)
                            {
                                if (Program.Rng.DieRoll(20) == 1)
                                {
                                    item.CreateRandart(false);
                                }
                                else
                                {
                                    switch (Program.Rng.DieRoll(24))
                                    {
                                        case 1:
                                            {
                                                item.RareItemTypeIndex = Enumerations.RareItemType.BootsOfSpeed;
                                                break;
                                            }
                                        case 2:
                                        case 3:
                                        case 4:
                                        case 5:
                                            {
                                                item.RareItemTypeIndex = Enumerations.RareItemType.BootsOfFreeAction;
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
                                                item.RareItemTypeIndex = Enumerations.RareItemType.BootsOfStealth;
                                                break;
                                            }
                                        default:
                                            {
                                                item.RareItemTypeIndex = Enumerations.RareItemType.BootsWinged;
                                                if (Program.Rng.DieRoll(2) == 1)
                                                {
                                                    item.ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(22) + 16);
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
                                            item.RareItemTypeIndex = Enumerations.RareItemType.BootsOfNoise;
                                            break;
                                        }
                                    case 2:
                                        {
                                            item.RareItemTypeIndex = Enumerations.RareItemType.BootsOfSlowness;
                                            break;
                                        }
                                    case 3:
                                        {
                                            item.RareItemTypeIndex = Enumerations.RareItemType.BootsOfAnnoyance;
                                            break;
                                        }
                                }
                            }
                            break;
                        }
                    case ItemTypeEnum.Crown:
                        {
                            if (power > 1)
                            {
                                if (Program.Rng.DieRoll(20) == 1)
                                {
                                    item.CreateRandart(false);
                                }
                                else
                                {
                                    switch (Program.Rng.DieRoll(8))
                                    {
                                        case 1:
                                            {
                                                item.RareItemTypeIndex = Enumerations.RareItemType.HatOfTheMagi;
                                                item.ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(22) + 16);
                                                break;
                                            }
                                        case 2:
                                            {
                                                item.RareItemTypeIndex = Enumerations.RareItemType.HatOfMight;
                                                item.ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(22) + 16);
                                                break;
                                            }
                                        case 3:
                                            {
                                                item.RareItemTypeIndex = Enumerations.RareItemType.HatOfTelepathy;
                                                break;
                                            }
                                        case 4:
                                            {
                                                item.RareItemTypeIndex = Enumerations.RareItemType.HatOfRegeneration;
                                                break;
                                            }
                                        case 5:
                                        case 6:
                                            {
                                                item.RareItemTypeIndex = Enumerations.RareItemType.HatOfLordliness;
                                                item.ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(22) + 16);
                                                break;
                                            }
                                        default:
                                            {
                                                item.RareItemTypeIndex = Enumerations.RareItemType.HatOfSeeing;
                                                if (Program.Rng.DieRoll(3) == 1)
                                                {
                                                    item.RandartItemCharacteristics.Telepathy = true;
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
                                            item.RareItemTypeIndex = Enumerations.RareItemType.HatOfStupidity;
                                            break;
                                        }
                                    case 3:
                                    case 4:
                                        {
                                            item.RareItemTypeIndex = Enumerations.RareItemType.HatOfNaivety;
                                            break;
                                        }
                                    case 5:
                                        {
                                            item.RareItemTypeIndex = Enumerations.RareItemType.HatOfUgliness;
                                            break;
                                        }
                                    case 6:
                                        {
                                            item.RareItemTypeIndex = Enumerations.RareItemType.HatOfSickliness;
                                            break;
                                        }
                                    case 7:
                                        {
                                            item.RareItemTypeIndex = Enumerations.RareItemType.HatOfTeleportation;
                                            break;
                                        }
                                }
                            }
                            break;
                        }
                    case ItemTypeEnum.Helm:
                        {
                            if (item.ItemSubCategory == HelmType.SvDragonHelm)
                            {
                                if (item.SaveGame.Level != null)
                                {
                                    item.SaveGame.Level.TreasureRating += 5;
                                }
                                ApplyDragonscaleResistance(item);
                            }
                            else
                            {
                                if (power > 1)
                                {
                                    if (Program.Rng.DieRoll(20) == 1)
                                    {
                                        item.CreateRandart(false);
                                    }
                                    else
                                    {
                                        switch (Program.Rng.DieRoll(14))
                                        {
                                            case 1:
                                            case 2:
                                                {
                                                    item.RareItemTypeIndex = Enumerations.RareItemType.HatOfIntelligence;
                                                    break;
                                                }
                                            case 3:
                                            case 4:
                                                {
                                                    item.RareItemTypeIndex = Enumerations.RareItemType.HatOfWisdom;
                                                    break;
                                                }
                                            case 5:
                                            case 6:
                                                {
                                                    item.RareItemTypeIndex = Enumerations.RareItemType.HatOfBeauty;
                                                    break;
                                                }
                                            case 7:
                                            case 8:
                                                {
                                                    item.RareItemTypeIndex = Enumerations.RareItemType.HatOfSeeing;
                                                    if (Program.Rng.DieRoll(7) == 1)
                                                    {
                                                        item.RandartItemCharacteristics.Telepathy = true;
                                                    }
                                                    break;
                                                }
                                            case 9:
                                            case 10:
                                                {
                                                    item.RareItemTypeIndex = Enumerations.RareItemType.HatOfLight;
                                                    break;
                                                }
                                            default:
                                                {
                                                    item.RareItemTypeIndex = Enumerations.RareItemType.HatOfInfravision;
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
                                                item.RareItemTypeIndex = Enumerations.RareItemType.HatOfStupidity;
                                                break;
                                            }
                                        case 3:
                                        case 4:
                                            {
                                                item.RareItemTypeIndex = Enumerations.RareItemType.HatOfNaivety;
                                                break;
                                            }
                                        case 5:
                                            {
                                                item.RareItemTypeIndex = Enumerations.RareItemType.HatOfUgliness;
                                                break;
                                            }
                                        case 6:
                                            {
                                                item.RareItemTypeIndex = Enumerations.RareItemType.HatOfSickliness;
                                                break;
                                            }
                                        case 7:
                                            {
                                                item.RareItemTypeIndex = Enumerations.RareItemType.HatOfTeleportation;
                                                break;
                                            }
                                    }
                                }
                            }
                            break;
                        }
                    case ItemTypeEnum.Cloak:
                        {
                            if (item.ItemSubCategory == CloakType.SvElvenCloak)
                            {
                                item.TypeSpecificValue = Program.Rng.DieRoll(4);
                            }
                            if (power > 1)
                            {
                                if (Program.Rng.DieRoll(20) == 1)
                                {
                                    item.CreateRandart(false);
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
                                                item.RareItemTypeIndex = Enumerations.RareItemType.CloakOfProtection;
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
                                                item.RareItemTypeIndex = Enumerations.RareItemType.CloakOfStealth;
                                                break;
                                            }
                                        case 17:
                                            {
                                                item.RareItemTypeIndex = Enumerations.RareItemType.CloakOfAman;
                                                break;
                                            }
                                        case 18:
                                            {
                                                item.RareItemTypeIndex = Enumerations.RareItemType.CloakOfElectricity;
                                                break;
                                            }
                                        default:
                                            {
                                                item.RareItemTypeIndex = Enumerations.RareItemType.CloakOfImmolation;
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
                                            item.RareItemTypeIndex = Enumerations.RareItemType.CloakOfIrritation;
                                            break;
                                        }
                                    case 2:
                                        {
                                            item.RareItemTypeIndex = Enumerations.RareItemType.CloakOfVulnerability;
                                            break;
                                        }
                                    case 3:
                                        {
                                            item.RareItemTypeIndex = Enumerations.RareItemType.CloakOfEnveloping;
                                            break;
                                        }
                                }
                            }
                            break;
                        }
                }
            }
        }

        public override string GetDetailedDescription(Item item)
        {
            string s = "";
            if (item.IsKnown())
            {
                item.RefreshFlagBasedProperties();
                if (ShowMods || item.BonusToHit != 0 && item.BonusDamage != 0)
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
