namespace AngbandOS.Core.ItemClasses
{
    [Serializable]
    internal abstract class LightSourceItemClass : ItemClass
    {
        public LightSourceItemClass(SaveGame saveGame) : base(saveGame) { }
        public override int WieldSlot => InventorySlot.Lightsource;
        public override BaseInventorySlot BaseWieldSlot => SaveGame.SingletonRepository.InventorySlots.Get<LightsourceInventorySlot>();
        public override bool IsWorthless(Item item) => item.TypeSpecificValue < 0;

        public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Light;
        public override bool HatesFire => true;
        public override Colour Colour => Colour.BrightYellow;

        /// <summary>
        /// Returns an intensity of 3, if the item is an artifact; otherwise, 0 is returned.
        /// </summary>
        /// <param name="oPtr"></param>
        /// <returns></returns>
        public override int CalcTorch(Item oPtr)
        {
            if (oPtr.IsFixedArtifact())
            {
                return 3;
            }
            else
            {
                return 0;
            }
        }
        public virtual void Refill(SaveGame saveGame, Item item)
        {
            saveGame.MsgPrint("Your light cannot be refilled.");
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

        public override void ApplyMagic(Item item, int level, int power)
        {
            if (power < 0) // Cursed
            {
                switch (Program.Rng.DieRoll(2)) // Cursed
                {
                    case 1:
                        {
                            item.RareItemTypeIndex = RareItemTypeEnum.OrbOfIrritation;
                            item.IdentBroken = true;
                            item.IdentCursed = true;
                            break;
                        }
                    case 2:
                        {
                            item.RareItemTypeIndex = RareItemTypeEnum.OrbOfInstability;
                            item.IdentBroken = true;
                            item.IdentCursed = true;
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
                item.RareItemTypeIndex = weightedRandom.Choose();
            }
            else if (power == 2) // Great
            {
                item.RareItemTypeIndex = RareItemTypeEnum.OrbOfPower;
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
        public override int PackSort => 18;
    }
}
