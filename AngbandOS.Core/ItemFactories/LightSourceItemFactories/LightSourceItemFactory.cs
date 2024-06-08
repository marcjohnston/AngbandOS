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
    protected override string ItemClassName => nameof(LightSourcesItemClass);
    public override BaseInventorySlot BaseWieldSlot => Game.SingletonRepository.Get<BaseInventorySlot>(nameof(LightsourceInventorySlot));
    public override bool IsWorthless(Item item) => item.TurnsOfLightRemaining < 0;

    protected override (int, string)[]? MassProduceTupleNames => new (int, string)[]
    {
        (20, "3d5-3")
    };

    public override int? GetTypeSpecificRealValue(Item item, int value)
    {
        return item.ComputeTypeSpecificRealValue(value);
    }

    public override void ApplyMagic(Item item, int level, int power, Store? store)
    {
        if (power < 0) // Cursed
        {
            switch (Game.DieRoll(2)) // Cursed
            {
                case 1:
                    {
                        item.RareItem = Game.SingletonRepository.Get<RareItem>(nameof(OrbOfIrritationRareItem));
                        item.IsBroken = true;
                        item.IsCursed = true;
                        break;
                    }
                case 2:
                    {
                        item.RareItem = Game.SingletonRepository.Get<RareItem>(nameof(OrbOfInstabilityRareItem));
                        item.IsBroken = true;
                        item.IsCursed = true;
                        break;
                    }
            }
        }
        else if (power == 1) // Good
        {
            WeightedRandom<RareItem> weightedRandom = new WeightedRandom<RareItem>(Game);
            weightedRandom.Add(1, Game.SingletonRepository.Get<RareItem>(nameof(OrbOfAcidRareItem)));
            weightedRandom.Add(1, Game.SingletonRepository.Get<RareItem>(nameof(OrbOfLightningRareItem)));
            weightedRandom.Add(1, Game.SingletonRepository.Get<RareItem>(nameof(OrbOfLightRareItem)));
            weightedRandom.Add(1, Game.SingletonRepository.Get<RareItem>(nameof(OrbOfDarknessRareItem)));
            weightedRandom.Add(1, Game.SingletonRepository.Get<RareItem>(nameof(OrbOfLifeRareItem)));
            weightedRandom.Add(1, Game.SingletonRepository.Get<RareItem>(nameof(OrbOfSightRareItem)));
            weightedRandom.Add(2, Game.SingletonRepository.Get<RareItem>(nameof(OrbOfCourageRareItem)));
            weightedRandom.Add(1, Game.SingletonRepository.Get<RareItem>(nameof(OrbOfVenomRareItem)));
            weightedRandom.Add(1, Game.SingletonRepository.Get<RareItem>(nameof(OrbOfClarityRareItem)));
            weightedRandom.Add(1, Game.SingletonRepository.Get<RareItem>(nameof(OrbOfSoundRareItem)));
            weightedRandom.Add(1, Game.SingletonRepository.Get<RareItem>(nameof(OrbOfChaosRareItem)));
            weightedRandom.Add(1, Game.SingletonRepository.Get<RareItem>(nameof(OrbOfShardsRareItem)));
            weightedRandom.Add(1, Game.SingletonRepository.Get<RareItem>(nameof(OrbOfUnlifeRareItem)));
            weightedRandom.Add(1, Game.SingletonRepository.Get<RareItem>(nameof(OrbOfStabilityRareItem)));
            weightedRandom.Add(1, Game.SingletonRepository.Get<RareItem>(nameof(OrbOfMagicRareItem)));
            weightedRandom.Add(1, Game.SingletonRepository.Get<RareItem>(nameof(OrbOfFreedomRareItem)));
            weightedRandom.Add(1, Game.SingletonRepository.Get<RareItem>(nameof(OrbOfStrengthRareItem)));
            weightedRandom.Add(1, Game.SingletonRepository.Get<RareItem>(nameof(OrbOfWisdomRareItem)));
            weightedRandom.Add(1, Game.SingletonRepository.Get<RareItem>(nameof(OrbOfFlameRareItem)));
            weightedRandom.Add(1, Game.SingletonRepository.Get<RareItem>(nameof(OrbOfDexterityRareItem)));
            weightedRandom.Add(1, Game.SingletonRepository.Get<RareItem>(nameof(OrbOfConstitutionRareItem)));
            weightedRandom.Add(1, Game.SingletonRepository.Get<RareItem>(nameof(OrbOfIntelligenceRareItem)));
            weightedRandom.Add(1, Game.SingletonRepository.Get<RareItem>(nameof(OrbOfCharismaRareItem)));
            weightedRandom.Add(1, Game.SingletonRepository.Get<RareItem>(nameof(OrbOfLightnessRareItem)));
            weightedRandom.Add(1, Game.SingletonRepository.Get<RareItem>(nameof(OrbOfInsightRareItem)));
            weightedRandom.Add(1, Game.SingletonRepository.Get<RareItem>(nameof(OrbOfTheMindRareItem)));
            weightedRandom.Add(1, Game.SingletonRepository.Get<RareItem>(nameof(OrbOfSustenanceRareItem)));
            weightedRandom.Add(1, Game.SingletonRepository.Get<RareItem>(nameof(OrbOfHealthRareItem)));
            weightedRandom.Add(1, Game.SingletonRepository.Get<RareItem>(nameof(OrbOfFrostRareItem)));
            item.RareItem = weightedRandom.ChooseOrDefault();
        }
        else if (power == 2) // Great
        {
            item.RareItem = Game.SingletonRepository.Get<RareItem>(nameof(OrbOfPowerRareItem));
            for (int i = 0; i < 3; i++)
            {
                WeightedRandomAction weightedRandomAction = new WeightedRandomAction(Game);
                weightedRandomAction.Add(2, () => item.Characteristics.ResDark = true);
                weightedRandomAction.Add(1, () => item.Characteristics.ResLight = true);
                weightedRandomAction.Add(1, () => item.Characteristics.ResBlind = true);
                weightedRandomAction.Add(1, () => item.Characteristics.ResFear = true);
                weightedRandomAction.Add(1, () => item.Characteristics.ResAcid = true);
                weightedRandomAction.Add(1, () => item.Characteristics.ResElec = true);
                weightedRandomAction.Add(1, () => item.Characteristics.ResFire = true);
                weightedRandomAction.Add(1, () => item.Characteristics.ResCold = true);
                weightedRandomAction.Add(1, () => item.Characteristics.ResPois = true);
                weightedRandomAction.Add(1, () => item.Characteristics.ResConf = true);
                weightedRandomAction.Add(1, () => item.Characteristics.ResSound = true);
                weightedRandomAction.Add(1, () => item.Characteristics.ResShards = true);
                weightedRandomAction.Add(1, () => item.Characteristics.ResNether = true);
                weightedRandomAction.Add(1, () => item.Characteristics.ResNexus = true);
                weightedRandomAction.Add(1, () => item.Characteristics.ResChaos = true);
                weightedRandomAction.Add(1, () => item.Characteristics.ResDisen = true);
                weightedRandomAction.Add(1, () => item.Characteristics.FreeAct = true);
                weightedRandomAction.Add(1, () => item.Characteristics.HoldLife = true);
                weightedRandomAction.Add(1, () => item.Characteristics.SustStr = true);
                weightedRandomAction.Add(1, () => item.Characteristics.SustInt = true);
                weightedRandomAction.Add(1, () => item.Characteristics.SustWis = true);
                weightedRandomAction.Add(1, () => item.Characteristics.SustDex = true);
                weightedRandomAction.Add(1, () => item.Characteristics.SustCon = true);
                weightedRandomAction.Add(1, () => item.Characteristics.SustCha = true);
                weightedRandomAction.Add(1, () => item.Characteristics.Feather = true);
                weightedRandomAction.Add(1, () => item.Characteristics.SeeInvis = true);
                weightedRandomAction.Add(1, () => item.Characteristics.Telepathy = true);
                weightedRandomAction.Add(1, () => item.Characteristics.SlowDigest = true);
                weightedRandomAction.Add(1, () => item.Characteristics.Regen = true);
                weightedRandomAction.Choose();
            }
        }
    }

    public override int PercentageBreakageChance => 50;
    public override int PackSort => 18;
    public override ItemTypeEnum CategoryEnum => ItemTypeEnum.Light;
    public override bool HatesFire => true;
    public override ColorEnum Color => ColorEnum.BrightYellow;

    /// <summary>
    /// Returns true, because all light sources can be worn/wielded.
    /// </summary>
    public override bool IsWearable => true;
}
