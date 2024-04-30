// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal abstract class LightSourceItemFactory : ItemFactory
{
    /// <summary>
    /// Returns the lightsource inventory slot for light sources.
    /// </summary>
    public override int WieldSlot => InventorySlot.Lightsource;
    public LightSourceItemFactory(Game game) : base(game) { }
    public override ItemClass ItemClass => Game.SingletonRepository.Get<ItemClass>(nameof(LightSourcesItemClass));
    public override BaseInventorySlot BaseWieldSlot => Game.SingletonRepository.InventorySlots.Get(nameof(LightsourceInventorySlot));
    public override bool IsWorthless(Item item) => item.TypeSpecificValue < 0;

    public override string GetVerboseDescription(Item item)
    {
        string s = "";
        if (BurnRate > 0)
        {
            s += $" (with {item.TypeSpecificValue} {Game.CountPluralize("turn", item.TypeSpecificValue)} of light)";
        }
        s += base.GetVerboseDescription(item);
        return s;
    }

    public override int GetAdditionalMassProduceCount(Item item)
    {
        // Rare items will not mass produce.
        if (item.RareItem != null)
        {
            return 0;
        }

        int cost = item.Value();
        if (cost <= 5)
        {
            return item.MassRoll(3, 5);
        }
        if (cost <= 20)
        {
            return item.MassRoll(3, 5);
        }
        return 0;
    }

    public override int? GetTypeSpecificRealValue(Item item, int value)
    {
        return item.ComputeTypeSpecificRealValue(value);
    }

    public override string Identify(Item item)
    {
        if (item.FixedArtifact != null)
        {
            return "It provides light (radius 3) forever.";
        }
        else
        {
            string burnRate = BurnRate == 0 ? "forever" : "when fueled";
            return $"It provides light (radius {Radius}) {burnRate}.";
        }
    }


    public override void ApplyMagic(Item item, int level, int power, Store? store)
    {
        if (power < 0) // Cursed
        {
            switch (Game.DieRoll(2)) // Cursed
            {
                case 1:
                    {
                        item.RareItem = Game.SingletonRepository.RareItems.Get(nameof(OrbOfIrritationRareItem));
                        item.IdentBroken = true;
                        item.IdentCursed = true;
                        break;
                    }
                case 2:
                    {
                        item.RareItem = Game.SingletonRepository.RareItems.Get(nameof(OrbOfInstabilityRareItem));
                        item.IdentBroken = true;
                        item.IdentCursed = true;
                        break;
                    }
            }
        }
        else if (power == 1) // Good
        {
            WeightedRandom<RareItem> weightedRandom = new WeightedRandom<RareItem>(Game);
            weightedRandom.Add(1, Game.SingletonRepository.RareItems.Get(nameof(OrbOfAcidRareItem)));
            weightedRandom.Add(1, Game.SingletonRepository.RareItems.Get(nameof(OrbOfLightningRareItem)));
            weightedRandom.Add(1, Game.SingletonRepository.RareItems.Get(nameof(OrbOfLightRareItem)));
            weightedRandom.Add(1, Game.SingletonRepository.RareItems.Get(nameof(OrbOfDarknessRareItem)));
            weightedRandom.Add(1, Game.SingletonRepository.RareItems.Get(nameof(OrbOfLifeRareItem)));
            weightedRandom.Add(1, Game.SingletonRepository.RareItems.Get(nameof(OrbOfSightRareItem)));
            weightedRandom.Add(2, Game.SingletonRepository.RareItems.Get(nameof(OrbOfCourageRareItem)));
            weightedRandom.Add(1, Game.SingletonRepository.RareItems.Get(nameof(OrbOfVenomRareItem)));
            weightedRandom.Add(1, Game.SingletonRepository.RareItems.Get(nameof(OrbOfClarityRareItem)));
            weightedRandom.Add(1, Game.SingletonRepository.RareItems.Get(nameof(OrbOfSoundRareItem)));
            weightedRandom.Add(1, Game.SingletonRepository.RareItems.Get(nameof(OrbOfChaosRareItem)));
            weightedRandom.Add(1, Game.SingletonRepository.RareItems.Get(nameof(OrbOfShardsRareItem)));
            weightedRandom.Add(1, Game.SingletonRepository.RareItems.Get(nameof(OrbOfUnlifeRareItem)));
            weightedRandom.Add(1, Game.SingletonRepository.RareItems.Get(nameof(OrbOfStabilityRareItem)));
            weightedRandom.Add(1, Game.SingletonRepository.RareItems.Get(nameof(OrbOfMagicRareItem)));
            weightedRandom.Add(1, Game.SingletonRepository.RareItems.Get(nameof(OrbOfFreedomRareItem)));
            weightedRandom.Add(1, Game.SingletonRepository.RareItems.Get(nameof(OrbOfStrengthRareItem)));
            weightedRandom.Add(1, Game.SingletonRepository.RareItems.Get(nameof(OrbOfWisdomRareItem)));
            weightedRandom.Add(1, Game.SingletonRepository.RareItems.Get(nameof(OrbOfFlameRareItem)));
            weightedRandom.Add(1, Game.SingletonRepository.RareItems.Get(nameof(OrbOfDexterityRareItem)));
            weightedRandom.Add(1, Game.SingletonRepository.RareItems.Get(nameof(OrbOfConstitutionRareItem)));
            weightedRandom.Add(1, Game.SingletonRepository.RareItems.Get(nameof(OrbOfIntelligenceRareItem)));
            weightedRandom.Add(1, Game.SingletonRepository.RareItems.Get(nameof(OrbOfCharismaRareItem)));
            weightedRandom.Add(1, Game.SingletonRepository.RareItems.Get(nameof(OrbOfLightnessRareItem)));
            weightedRandom.Add(1, Game.SingletonRepository.RareItems.Get(nameof(OrbOfInsightRareItem)));
            weightedRandom.Add(1, Game.SingletonRepository.RareItems.Get(nameof(OrbOfTheMindRareItem)));
            weightedRandom.Add(1, Game.SingletonRepository.RareItems.Get(nameof(OrbOfSustenanceRareItem)));
            weightedRandom.Add(1, Game.SingletonRepository.RareItems.Get(nameof(OrbOfHealthRareItem)));
            weightedRandom.Add(1, Game.SingletonRepository.RareItems.Get(nameof(OrbOfFrostRareItem)));
            item.RareItem = weightedRandom.ChooseOrDefault();
        }
        else if (power == 2) // Great
        {
            item.RareItem = Game.SingletonRepository.RareItems.Get(nameof(OrbOfPowerRareItem));
            for (int i = 0; i < 3; i++)
            {
                WeightedRandomAction weightedRandomAction = new WeightedRandomAction(Game);
                weightedRandomAction.Add(2, () => item.RandomArtifactItemCharacteristics.ResDark = true);
                weightedRandomAction.Add(1, () => item.RandomArtifactItemCharacteristics.ResLight = true);
                weightedRandomAction.Add(1, () => item.RandomArtifactItemCharacteristics.ResBlind = true);
                weightedRandomAction.Add(1, () => item.RandomArtifactItemCharacteristics.ResFear = true);
                weightedRandomAction.Add(1, () => item.RandomArtifactItemCharacteristics.ResAcid = true);
                weightedRandomAction.Add(1, () => item.RandomArtifactItemCharacteristics.ResElec = true);
                weightedRandomAction.Add(1, () => item.RandomArtifactItemCharacteristics.ResFire = true);
                weightedRandomAction.Add(1, () => item.RandomArtifactItemCharacteristics.ResCold = true);
                weightedRandomAction.Add(1, () => item.RandomArtifactItemCharacteristics.ResPois = true);
                weightedRandomAction.Add(1, () => item.RandomArtifactItemCharacteristics.ResConf = true);
                weightedRandomAction.Add(1, () => item.RandomArtifactItemCharacteristics.ResSound = true);
                weightedRandomAction.Add(1, () => item.RandomArtifactItemCharacteristics.ResShards = true);
                weightedRandomAction.Add(1, () => item.RandomArtifactItemCharacteristics.ResNether = true);
                weightedRandomAction.Add(1, () => item.RandomArtifactItemCharacteristics.ResNexus = true);
                weightedRandomAction.Add(1, () => item.RandomArtifactItemCharacteristics.ResChaos = true);
                weightedRandomAction.Add(1, () => item.RandomArtifactItemCharacteristics.ResDisen = true);
                weightedRandomAction.Add(1, () => item.RandomArtifactItemCharacteristics.FreeAct = true);
                weightedRandomAction.Add(1, () => item.RandomArtifactItemCharacteristics.HoldLife = true);
                weightedRandomAction.Add(1, () => item.RandomArtifactItemCharacteristics.SustStr = true);
                weightedRandomAction.Add(1, () => item.RandomArtifactItemCharacteristics.SustInt = true);
                weightedRandomAction.Add(1, () => item.RandomArtifactItemCharacteristics.SustWis = true);
                weightedRandomAction.Add(1, () => item.RandomArtifactItemCharacteristics.SustDex = true);
                weightedRandomAction.Add(1, () => item.RandomArtifactItemCharacteristics.SustCon = true);
                weightedRandomAction.Add(1, () => item.RandomArtifactItemCharacteristics.SustCha = true);
                weightedRandomAction.Add(1, () => item.RandomArtifactItemCharacteristics.Feather = true);
                weightedRandomAction.Add(1, () => item.RandomArtifactItemCharacteristics.SeeInvis = true);
                weightedRandomAction.Add(1, () => item.RandomArtifactItemCharacteristics.Telepathy = true);
                weightedRandomAction.Add(1, () => item.RandomArtifactItemCharacteristics.SlowDigest = true);
                weightedRandomAction.Add(1, () => item.RandomArtifactItemCharacteristics.Regen = true);
                weightedRandomAction.Choose();
            }
        }
    }

    /// <summary>
    /// Returns an intensity of 3, if the item is an artifact; otherwise, 0 is returned.
    /// </summary>
    /// <param name="oPtr"></param>
    /// <returns></returns>
    public override int CalculateTorch(Item item)
    {
        if (item.FixedArtifact != null)
        {
            return 3;
        }
        else
        {
            return 0;
        }
    }

    public override int PercentageBreakageChance => 50;
    public override int PackSort => 18;
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Light;
    public override bool HatesFire => true;
    public override ColorEnum Color => ColorEnum.BrightYellow;

    public virtual void Refill(Game game, Item item)
    {
        game.MsgPrint("Your light cannot be refilled.");
    }

    /// <summary>
    /// Returns the maximum fuel that can be used for phlogiston.  Returns null, by default, meaning that the light source cannot be used to create a phlogiston.
    /// </summary>
    public virtual int? MaxPhlogiston => null;

    /// <summary>
    /// Returns the number of turns of light that consumeds for each world turn.  Defaults to zero; which means there is no consumption and that the light source lasts forever.
    /// Torches and laterns have burn rates greater than zero.
    /// </summary>
    public virtual int BurnRate => 0;

    /// <summary>
    /// Returns the radius that the light source illuminates.  Default radius is 2.
    /// </summary>
    public virtual int Radius => 2;

    /// <summary>
    /// Returns true, because all light sources can be worn/wielded.
    /// </summary>
    public override bool IsWearable => true;
}
