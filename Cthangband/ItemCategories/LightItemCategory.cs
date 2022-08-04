using Cthangband.Enumerations;
using Cthangband.StaticData;
using System;
using static Cthangband.Extensions;

namespace Cthangband.ItemCategories
{
    [Serializable]
    internal class LightItemCategory : LightSourceItemCategory
    {
        public override bool HatesFire => true;
        public override Colour Colour => Colour.BrightYellow;

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
                            item.IdentifyFlags.Set(Constants.IdentBroken);
                            item.IdentifyFlags.Set(Constants.IdentCursed);
                            break;
                        }
                    case 2:
                        {
                            item.RareItemTypeIndex = Enumerations.RareItemType.OrbOfInstability;
                            item.IdentifyFlags.Set(Constants.IdentBroken);
                            item.IdentifyFlags.Set(Constants.IdentCursed);
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
                            item.RandartFlags2.Set(ItemFlag2.ResDark);
                            break;
                        case 3:
                            item.RandartFlags2.Set(ItemFlag2.ResLight);
                            break;
                        case 4:
                            item.RandartFlags2.Set(ItemFlag2.ResBlind);
                            break;
                        case 5:
                            item.RandartFlags2.Set(ItemFlag2.ResFear);
                            break;
                        case 6:
                            item.RandartFlags2.Set(ItemFlag2.ResAcid);
                            break;
                        case 7:
                            item.RandartFlags2.Set(ItemFlag2.ResElec);
                            break;
                        case 8:
                            item.RandartFlags2.Set(ItemFlag2.ResFire);
                            break;
                        case 9:
                            item.RandartFlags2.Set(ItemFlag2.ResCold);
                            break;
                        case 10:
                            item.RandartFlags2.Set(ItemFlag2.ResPois);
                            break;
                        case 11:
                            item.RandartFlags2.Set(ItemFlag2.ResConf);
                            break;
                        case 12:
                            item.RandartFlags2.Set(ItemFlag2.ResSound);
                            break;
                        case 13:
                            item.RandartFlags2.Set(ItemFlag2.ResShards);
                            break;
                        case 14:
                            item.RandartFlags2.Set(ItemFlag2.ResNether);
                            break;
                        case 15:
                            item.RandartFlags2.Set(ItemFlag2.ResNexus);
                            break;
                        case 16:
                            item.RandartFlags2.Set(ItemFlag2.ResChaos);
                            break;
                        case 17:
                            item.RandartFlags2.Set(ItemFlag2.ResDisen);
                            break;
                        case 18:
                            item.RandartFlags2.Set(ItemFlag2.FreeAct);
                            break;
                        case 19:
                            item.RandartFlags2.Set(ItemFlag2.HoldLife);
                            break;
                        case 20:
                            item.RandartFlags2.Set(ItemFlag2.SustStr);
                            break;
                        case 21:
                            item.RandartFlags2.Set(ItemFlag2.SustInt);
                            break;
                        case 22:
                            item.RandartFlags2.Set(ItemFlag2.SustWis);
                            break;
                        case 23:
                            item.RandartFlags2.Set(ItemFlag2.SustDex);
                            break;
                        case 24:
                            item.RandartFlags2.Set(ItemFlag2.SustCon);
                            break;
                        case 25:
                            item.RandartFlags2.Set(ItemFlag2.SustCha);
                            break;
                        case 26:
                            item.RandartFlags3.Set(ItemFlag3.Feather);
                            break;
                        case 27:
                            item.RandartFlags3.Set(ItemFlag3.SeeInvis);
                            break;
                        case 28:
                            item.RandartFlags3.Set(ItemFlag3.Telepathy);
                            break;
                        case 29:
                            item.RandartFlags3.Set(ItemFlag3.SlowDigest);
                            break;
                        case 30:
                            item.RandartFlags3.Set(ItemFlag3.Regen);
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
