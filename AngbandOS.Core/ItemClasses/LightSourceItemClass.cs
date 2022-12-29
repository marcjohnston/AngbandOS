using AngbandOS.Core.Interface;
using AngbandOS.Enumerations;
using static AngbandOS.Extensions;

namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class LightSourceItemClass : ItemClass
    {
        public LightSourceItemClass(SaveGame saveGame) : base(saveGame) { }
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
                WeightedRandom<Enumerations.RareItemType> weightedRandom = new WeightedRandom<Enumerations.RareItemType>();
                weightedRandom.Add(1, Enumerations.RareItemType.OrbOfFlame);
                weightedRandom.Add(1, Enumerations.RareItemType.OrbOfFrost);
                weightedRandom.Add(1, Enumerations.RareItemType.OrbOfAcid);
                weightedRandom.Add(1, Enumerations.RareItemType.OrbOfLightning);
                weightedRandom.Add(1, Enumerations.RareItemType.OrbOfLight);
                weightedRandom.Add(1, Enumerations.RareItemType.OrbOfDarkness);
                weightedRandom.Add(1, Enumerations.RareItemType.OrbOfLife);
                weightedRandom.Add(1, Enumerations.RareItemType.OrbOfSight);
                weightedRandom.Add(2, Enumerations.RareItemType.OrbOfCourage);
                weightedRandom.Add(1, Enumerations.RareItemType.OrbOfVenom);
                weightedRandom.Add(1, Enumerations.RareItemType.OrbOfClarity);
                weightedRandom.Add(1, Enumerations.RareItemType.OrbOfSound);
                weightedRandom.Add(1, Enumerations.RareItemType.OrbOfChaos);
                weightedRandom.Add(1, Enumerations.RareItemType.OrbOfShards);
                weightedRandom.Add(1, Enumerations.RareItemType.OrbOfUnlife);
                weightedRandom.Add(1, Enumerations.RareItemType.OrbOfStability);
                weightedRandom.Add(1, Enumerations.RareItemType.OrbOfMagic);
                weightedRandom.Add(1, Enumerations.RareItemType.OrbOfFreedom);
                weightedRandom.Add(1, Enumerations.RareItemType.OrbOfStrength);
                weightedRandom.Add(1, Enumerations.RareItemType.OrbOfIntelligence);
                weightedRandom.Add(1, Enumerations.RareItemType.OrbOfWisdom);
                weightedRandom.Add(1, Enumerations.RareItemType.OrbOfDexterity);
                weightedRandom.Add(1, Enumerations.RareItemType.OrbOfConstitution);
                weightedRandom.Add(1, Enumerations.RareItemType.OrbOfCharisma);
                weightedRandom.Add(1, Enumerations.RareItemType.OrbOfLightness);
                weightedRandom.Add(1, Enumerations.RareItemType.OrbOfInsight);
                weightedRandom.Add(1, Enumerations.RareItemType.OrbOfTheMind);
                weightedRandom.Add(1, Enumerations.RareItemType.OrbOfSustenance);
                weightedRandom.Add(1, Enumerations.RareItemType.OrbOfHealth);
                item.RareItemTypeIndex = weightedRandom.Choose();
            }
            else if (power == 2) // Great
            {
                item.RareItemTypeIndex = Enumerations.RareItemType.OrbOfPower;
                for (int i = 0; i < 3; i++)
                {
                    WeightedRandomAction weightedRandomAction = new WeightedRandomAction();
                    weightedRandomAction.Add(2, () => item.RandartItemCharacteristics.ResDark = true);
                    weightedRandomAction.Add(1, () => item.RandartItemCharacteristics.ResLight = true);
                    weightedRandomAction.Add(1, () => item.RandartItemCharacteristics.ResBlind = true);
                    weightedRandomAction.Add(1, () => item.RandartItemCharacteristics.ResFear = true);
                    weightedRandomAction.Add(1, () => item.RandartItemCharacteristics.ResAcid = true);
                    weightedRandomAction.Add(1, () => item.RandartItemCharacteristics.ResElec = true);
                    weightedRandomAction.Add(1, () => item.RandartItemCharacteristics.ResFire = true);
                    weightedRandomAction.Add(1, () => item.RandartItemCharacteristics.ResCold = true);
                    weightedRandomAction.Add(1, () => item.RandartItemCharacteristics.ResPois = true);
                    weightedRandomAction.Add(1, () => item.RandartItemCharacteristics.ResConf = true);
                    weightedRandomAction.Add(1, () => item.RandartItemCharacteristics.ResSound = true);
                    weightedRandomAction.Add(1, () => item.RandartItemCharacteristics.ResShards = true);
                    weightedRandomAction.Add(1, () => item.RandartItemCharacteristics.ResNether = true);
                    weightedRandomAction.Add(1, () => item.RandartItemCharacteristics.ResNexus = true);
                    weightedRandomAction.Add(1, () => item.RandartItemCharacteristics.ResChaos = true);
                    weightedRandomAction.Add(1, () => item.RandartItemCharacteristics.ResDisen = true);
                    weightedRandomAction.Add(1, () => item.RandartItemCharacteristics.FreeAct = true);
                    weightedRandomAction.Add(1, () => item.RandartItemCharacteristics.HoldLife = true);
                    weightedRandomAction.Add(1, () => item.RandartItemCharacteristics.SustStr = true);
                    weightedRandomAction.Add(1, () => item.RandartItemCharacteristics.SustInt = true);
                    weightedRandomAction.Add(1, () => item.RandartItemCharacteristics.SustWis = true);
                    weightedRandomAction.Add(1, () => item.RandartItemCharacteristics.SustDex = true);
                    weightedRandomAction.Add(1, () => item.RandartItemCharacteristics.SustCon = true);
                    weightedRandomAction.Add(1, () => item.RandartItemCharacteristics.SustCha = true);
                    weightedRandomAction.Add(1, () => item.RandartItemCharacteristics.Feather = true);
                    weightedRandomAction.Add(1, () => item.RandartItemCharacteristics.SeeInvis = true);
                    weightedRandomAction.Add(1, () => item.RandartItemCharacteristics.Telepathy = true);
                    weightedRandomAction.Add(1, () => item.RandartItemCharacteristics.SlowDigest = true);
                    weightedRandomAction.Add(1, () => item.RandartItemCharacteristics.Regen = true);
                    weightedRandomAction.Choose();
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
