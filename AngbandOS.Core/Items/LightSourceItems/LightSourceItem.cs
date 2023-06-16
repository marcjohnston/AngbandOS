namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class LightSourceItem : ArmourItem
    {
        public override int WieldSlot => InventorySlot.Lightsource;
        public LightSourceItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }

        public override int PercentageBreakageChance => 50;

        /// <summary>
        /// Returns an intensity of 3, if the item is an artifact; otherwise, 0 is returned.
        /// </summary>
        /// <param name="oPtr"></param>
        /// <returns></returns>
        public override int CalculateTorch()
        {
            if (FixedArtifact != null)
            {
                return 3;
            }
            else
            {
                return 0;
            }
        }

        protected override void ApplyMagic(int level, int power, Store? store)
        {
            if (power < 0) // Cursed
            {
                switch (Program.Rng.DieRoll(2)) // Cursed
                {
                    case 1:
                        {
                            RareItemTypeIndex = RareItemTypeEnum.OrbOfIrritation;
                            IdentBroken = true;
                            IdentCursed = true;
                            break;
                        }
                    case 2:
                        {
                            RareItemTypeIndex = RareItemTypeEnum.OrbOfInstability;
                            IdentBroken = true;
                            IdentCursed = true;
                            break;
                        }
                }
            }
            else if (power == 1) // Good
            {
                WeightedRandom<RareItemTypeEnum> weightedRandom = new WeightedRandom<RareItemTypeEnum>();
                weightedRandom.Add(1, RareItemTypeEnum.OrbOfFlame);
                weightedRandom.Add(1, RareItemTypeEnum.OrbOfFrost);
                weightedRandom.Add(1, RareItemTypeEnum.OrbOfAcid);
                weightedRandom.Add(1, RareItemTypeEnum.OrbOfLightning);
                weightedRandom.Add(1, RareItemTypeEnum.OrbOfLight);
                weightedRandom.Add(1, RareItemTypeEnum.OrbOfDarkness);
                weightedRandom.Add(1, RareItemTypeEnum.OrbOfLife);
                weightedRandom.Add(1, RareItemTypeEnum.OrbOfSight);
                weightedRandom.Add(2, RareItemTypeEnum.OrbOfCourage);
                weightedRandom.Add(1, RareItemTypeEnum.OrbOfVenom);
                weightedRandom.Add(1, RareItemTypeEnum.OrbOfClarity);
                weightedRandom.Add(1, RareItemTypeEnum.OrbOfSound);
                weightedRandom.Add(1, RareItemTypeEnum.OrbOfChaos);
                weightedRandom.Add(1, RareItemTypeEnum.OrbOfShards);
                weightedRandom.Add(1, RareItemTypeEnum.OrbOfUnlife);
                weightedRandom.Add(1, RareItemTypeEnum.OrbOfStability);
                weightedRandom.Add(1, RareItemTypeEnum.OrbOfMagic);
                weightedRandom.Add(1, RareItemTypeEnum.OrbOfFreedom);
                weightedRandom.Add(1, RareItemTypeEnum.OrbOfStrength);
                weightedRandom.Add(1, RareItemTypeEnum.OrbOfIntelligence);
                weightedRandom.Add(1, RareItemTypeEnum.OrbOfWisdom);
                weightedRandom.Add(1, RareItemTypeEnum.OrbOfDexterity);
                weightedRandom.Add(1, RareItemTypeEnum.OrbOfConstitution);
                weightedRandom.Add(1, RareItemTypeEnum.OrbOfCharisma);
                weightedRandom.Add(1, RareItemTypeEnum.OrbOfLightness);
                weightedRandom.Add(1, RareItemTypeEnum.OrbOfInsight);
                weightedRandom.Add(1, RareItemTypeEnum.OrbOfTheMind);
                weightedRandom.Add(1, RareItemTypeEnum.OrbOfSustenance);
                weightedRandom.Add(1, RareItemTypeEnum.OrbOfHealth);
                RareItemTypeIndex = weightedRandom.Choose();
            }
            else if (power == 2) // Great
            {
                RareItemTypeIndex = RareItemTypeEnum.OrbOfPower;
                for (int i = 0; i < 3; i++)
                {
                    WeightedRandomAction weightedRandomAction = new WeightedRandomAction();
                    weightedRandomAction.Add(2, () => RandartItemCharacteristics.ResDark = true);
                    weightedRandomAction.Add(1, () => RandartItemCharacteristics.ResLight = true);
                    weightedRandomAction.Add(1, () => RandartItemCharacteristics.ResBlind = true);
                    weightedRandomAction.Add(1, () => RandartItemCharacteristics.ResFear = true);
                    weightedRandomAction.Add(1, () => RandartItemCharacteristics.ResAcid = true);
                    weightedRandomAction.Add(1, () => RandartItemCharacteristics.ResElec = true);
                    weightedRandomAction.Add(1, () => RandartItemCharacteristics.ResFire = true);
                    weightedRandomAction.Add(1, () => RandartItemCharacteristics.ResCold = true);
                    weightedRandomAction.Add(1, () => RandartItemCharacteristics.ResPois = true);
                    weightedRandomAction.Add(1, () => RandartItemCharacteristics.ResConf = true);
                    weightedRandomAction.Add(1, () => RandartItemCharacteristics.ResSound = true);
                    weightedRandomAction.Add(1, () => RandartItemCharacteristics.ResShards = true);
                    weightedRandomAction.Add(1, () => RandartItemCharacteristics.ResNether = true);
                    weightedRandomAction.Add(1, () => RandartItemCharacteristics.ResNexus = true);
                    weightedRandomAction.Add(1, () => RandartItemCharacteristics.ResChaos = true);
                    weightedRandomAction.Add(1, () => RandartItemCharacteristics.ResDisen = true);
                    weightedRandomAction.Add(1, () => RandartItemCharacteristics.FreeAct = true);
                    weightedRandomAction.Add(1, () => RandartItemCharacteristics.HoldLife = true);
                    weightedRandomAction.Add(1, () => RandartItemCharacteristics.SustStr = true);
                    weightedRandomAction.Add(1, () => RandartItemCharacteristics.SustInt = true);
                    weightedRandomAction.Add(1, () => RandartItemCharacteristics.SustWis = true);
                    weightedRandomAction.Add(1, () => RandartItemCharacteristics.SustDex = true);
                    weightedRandomAction.Add(1, () => RandartItemCharacteristics.SustCon = true);
                    weightedRandomAction.Add(1, () => RandartItemCharacteristics.SustCha = true);
                    weightedRandomAction.Add(1, () => RandartItemCharacteristics.Feather = true);
                    weightedRandomAction.Add(1, () => RandartItemCharacteristics.SeeInvis = true);
                    weightedRandomAction.Add(1, () => RandartItemCharacteristics.Telepathy = true);
                    weightedRandomAction.Add(1, () => RandartItemCharacteristics.SlowDigest = true);
                    weightedRandomAction.Add(1, () => RandartItemCharacteristics.Regen = true);
                    weightedRandomAction.Choose();
                }
            }
        }

        /// <summary>
        /// Returns the factory that created this light source item.
        /// </summary>
        public override LightSourceItemFactory Factory => (LightSourceItemFactory)base.Factory;

        public override string Identify()
        {
            if (FixedArtifact != null)
            {
                return "It provides light (radius 3) forever.";
            }
            else
            {
                string burnRate = Factory.BurnRate == 0 ? "forever" : "when fueled";
                return $"It provides light (radius {Factory.Radius}) {burnRate}.";
            }
        }
        protected override bool FactoryCanAbsorbItem(Item other)
        {
            if (!IsKnown() || !other.IsKnown())
            {
                return false;
            }
            if (!StatsAreSame(other))
            {
                return false;
            }
            return true;
        }

        public override int? GetTypeSpecificRealValue(int value)
        {
            return ComputeTypeSpecificRealValue(value);
        }
        public override int GetAdditionalMassProduceCount()
        {
            int cost = Value();
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

        public override string GetVerboseDescription()
        {
            string s = "";
            if (Factory.BurnRate > 0)
            {
                s += $" (with {TypeSpecificValue} {Pluralize("turn", TypeSpecificValue)} of light)";
            }
            s += base.GetVerboseDescription();
            return s;
        }
        public override bool IsWorthless() => TypeSpecificValue < 0;
    }
}