using AngbandOS.Core;
using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;
using static AngbandOS.Extensions;

namespace AngbandOS.ItemCategories
{
    [Serializable]
    internal abstract class LightSourceItemClass : ItemClass
    {
        public override bool IsWorthless(Item item) => item.TypeSpecificValue < 0;

        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Light;
        public override bool HatesFire => true;
        public override Colour Colour => Colour.BrightYellow;

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

        public override void ApplyMagic(Item item, int level, int power)
        {
            if (item.ItemSubCategory == LightType.Torch)
            {
                if (item.TypeSpecificValue != 0)
                {
                    item.TypeSpecificValue = Program.Rng.DieRoll(item.TypeSpecificValue);
                }
                return;
            }
            if (item.ItemSubCategory == LightType.Lantern)
            {
                if (item.TypeSpecificValue != 0)
                {
                    item.TypeSpecificValue = Program.Rng.DieRoll(item.TypeSpecificValue);
                }
                return;
            }
            if (power < 0) // Cursed
            {
                switch (Program.Rng.DieRoll(2)) // Cursed
                {
                    case 1:
                        {
                            item.RareItemTypeIndex = Enumerations.RareItemType.OrbOfIrritation;
                            item.IdentBroken = true;
                            item.IdentCursed = true;
                            break;
                        }
                    case 2:
                        {
                            item.RareItemTypeIndex = Enumerations.RareItemType.OrbOfInstability;
                            item.IdentBroken = true;
                            item.IdentCursed = true;
                            break;
                        }
                }
            }
            else if (power == 1) // Good
            {
                switch (Program.Rng.DieRoll(30))
                {
                    case 1:
                        item.RareItemTypeIndex = Enumerations.RareItemType.OrbOfFlame;
                        break;
                    case 2:
                        item.RareItemTypeIndex = Enumerations.RareItemType.OrbOfFrost;
                        break;
                    case 3:
                        item.RareItemTypeIndex = Enumerations.RareItemType.OrbOfAcid;
                        break;
                    case 4:
                        item.RareItemTypeIndex = Enumerations.RareItemType.OrbOfLightning;
                        break;
                    case 5:
                        item.RareItemTypeIndex = Enumerations.RareItemType.OrbOfLight;
                        break;
                    case 6:
                        item.RareItemTypeIndex = Enumerations.RareItemType.OrbOfDarkness;
                        break;
                    case 7:
                        item.RareItemTypeIndex = Enumerations.RareItemType.OrbOfLife;
                        break;
                    case 8:
                        item.RareItemTypeIndex = Enumerations.RareItemType.OrbOfSight;
                        break;
                    case 9:
                        item.RareItemTypeIndex = Enumerations.RareItemType.OrbOfCourage;
                        break;
                    case 10:
                        item.RareItemTypeIndex = Enumerations.RareItemType.OrbOfCourage;
                        break;
                    case 11:
                        item.RareItemTypeIndex = Enumerations.RareItemType.OrbOfVenom;
                        break;
                    case 12:
                        item.RareItemTypeIndex = Enumerations.RareItemType.OrbOfClarity;
                        break;
                    case 13:
                        item.RareItemTypeIndex = Enumerations.RareItemType.OrbOfSound;
                        break;
                    case 14:
                        item.RareItemTypeIndex = Enumerations.RareItemType.OrbOfChaos;
                        break;
                    case 15:
                        item.RareItemTypeIndex = Enumerations.RareItemType.OrbOfShards;
                        break;
                    case 16:
                        item.RareItemTypeIndex = Enumerations.RareItemType.OrbOfUnlife;
                        break;
                    case 17:
                        item.RareItemTypeIndex = Enumerations.RareItemType.OrbOfStability;
                        break;
                    case 18:
                        item.RareItemTypeIndex = Enumerations.RareItemType.OrbOfMagic;
                        break;
                    case 19:
                        item.RareItemTypeIndex = Enumerations.RareItemType.OrbOfFreedom;
                        break;
                    case 20:
                        item.RareItemTypeIndex = Enumerations.RareItemType.OrbOfStrength;
                        break;
                    case 21:
                        item.RareItemTypeIndex = Enumerations.RareItemType.OrbOfIntelligence;
                        break;
                    case 22:
                        item.RareItemTypeIndex = Enumerations.RareItemType.OrbOfWisdom;
                        break;
                    case 23:
                        item.RareItemTypeIndex = Enumerations.RareItemType.OrbOfDexterity;
                        break;
                    case 24:
                        item.RareItemTypeIndex = Enumerations.RareItemType.OrbOfConstitution;
                        break;
                    case 25:
                        item.RareItemTypeIndex = Enumerations.RareItemType.OrbOfCharisma;
                        break;
                    case 26:
                        item.RareItemTypeIndex = Enumerations.RareItemType.OrbOfLightness;
                        break;
                    case 27:
                        item.RareItemTypeIndex = Enumerations.RareItemType.OrbOfInsight;
                        break;
                    case 28:
                        item.RareItemTypeIndex = Enumerations.RareItemType.OrbOfTheMind;
                        break;
                    case 29:
                        item.RareItemTypeIndex = Enumerations.RareItemType.OrbOfSustenance;
                        break;
                    case 30:
                        item.RareItemTypeIndex = Enumerations.RareItemType.OrbOfHealth;
                        break;
                }
            }
            else if (power == 2) // Great
            {
                item.RareItemTypeIndex = Enumerations.RareItemType.OrbOfPower;
                for (int i = 0; i < 3; i++)
                {
                    switch (Program.Rng.DieRoll(30))
                    {
                        case 1:
                        case 2:
                            item.RandartItemCharacteristics.ResDark = true;
                            break;
                        case 3:
                            item.RandartItemCharacteristics.ResLight = true;
                            break;
                        case 4:
                            item.RandartItemCharacteristics.ResBlind = true;
                            break;
                        case 5:
                            item.RandartItemCharacteristics.ResFear = true;
                            break;
                        case 6:
                            item.RandartItemCharacteristics.ResAcid = true;
                            break;
                        case 7:
                            item.RandartItemCharacteristics.ResElec = true;
                            break;
                        case 8:
                            item.RandartItemCharacteristics.ResFire = true;
                            break;
                        case 9:
                            item.RandartItemCharacteristics.ResCold = true;
                            break;
                        case 10:
                            item.RandartItemCharacteristics.ResPois = true;
                            break;
                        case 11:
                            item.RandartItemCharacteristics.ResConf = true;
                            break;
                        case 12:
                            item.RandartItemCharacteristics.ResSound = true;
                            break;
                        case 13:
                            item.RandartItemCharacteristics.ResShards = true;
                            break;
                        case 14:
                            item.RandartItemCharacteristics.ResNether = true;
                            break;
                        case 15:
                            item.RandartItemCharacteristics.ResNexus = true;
                            break;
                        case 16:
                            item.RandartItemCharacteristics.ResChaos = true;
                            break;
                        case 17:
                            item.RandartItemCharacteristics.ResDisen = true;
                            break;
                        case 18:
                            item.RandartItemCharacteristics.FreeAct = true;
                            break;
                        case 19:
                            item.RandartItemCharacteristics.HoldLife = true;
                            break;
                        case 20:
                            item.RandartItemCharacteristics.SustStr = true;
                            break;
                        case 21:
                            item.RandartItemCharacteristics.SustInt = true;
                            break;
                        case 22:
                            item.RandartItemCharacteristics.SustWis = true;
                            break;
                        case 23:
                            item.RandartItemCharacteristics.SustDex = true;
                            break;
                        case 24:
                            item.RandartItemCharacteristics.SustCon = true;
                            break;
                        case 25:
                            item.RandartItemCharacteristics.SustCha = true;
                            break;
                        case 26:
                            item.RandartItemCharacteristics.Feather = true;
                            break;
                        case 27:
                            item.RandartItemCharacteristics.SeeInvis = true;
                            break;
                        case 28:
                            item.RandartItemCharacteristics.Telepathy = true;
                            break;
                        case 29:
                            item.RandartItemCharacteristics.SlowDigest = true;
                            break;
                        case 30:
                            item.RandartItemCharacteristics.Regen = true;
                            break;
                    }
                }
            }
        }
        public override int GetAdditionalMassProduceCount(Item item)
        {
            int cost = item.Value();
            if (cost <= 5)
            {
                return MassRoll(3, 5);
            }
            if (cost <= 20)
            {
                return MassRoll(3, 5);
            }
            return 0;
        }

        public override int PercentageBreakageChance => 50;
        public override string GetVerboseDescription(Item item)
        {
            string s = "";
            if (item.ItemSubCategory == LightType.Torch || item.ItemSubCategory == LightType.Lantern)
            {
                s += $" (with {item.TypeSpecificValue} {Pluralize("turn", item.TypeSpecificValue)} of light)";
            }
            s += base.GetVerboseDescription(item);
            return s;
        }

        public override string Identify(Item item)
        {
            if (item.IsFixedArtifact())
            {
                return "It provides light (radius 3) forever.";
            }
            else if (item.ItemSubCategory == LightType.Lantern)
            {
                return "It provides light (radius 2) when fueled.";
            }
            else if (item.ItemSubCategory == LightType.Torch)
            {
                return "It provides light (radius 1) when fueled.";
            }
            else
            {
                return "It provides light (radius 2) forever.";
            }
        }
    }
}
