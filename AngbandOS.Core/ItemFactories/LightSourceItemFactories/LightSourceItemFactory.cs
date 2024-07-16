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

    protected override (int, string)[]? MassProduceTupleNames => new (int, string)[]
    {
        (20, "3d5-3")
    };

    public override void EnchantItem(Item item, bool usedOkay, int level, int power)
    {
        if (power < 0) // Cursed
        {
            switch (Game.DieRoll(2)) // Cursed
            {
                case 1:
                    {
                        item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(OrbOfIrritationRareItem));
                        item.IsBroken = true;
                        item.IsCursed = true;
                        break;
                    }
                case 2:
                    {
                        item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(OrbOfInstabilityRareItem));
                        item.IsBroken = true;
                        item.IsCursed = true;
                        break;
                    }
            }
        }
        else if (power == 1) // Good
        {
            WeightedRandom<ItemAdditiveBundle> weightedRandom = new WeightedRandom<ItemAdditiveBundle>(Game);
            weightedRandom.Add(1, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(OrbOfAcidRareItem)));
            weightedRandom.Add(1, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(OrbOfLightningRareItem)));
            weightedRandom.Add(1, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(OrbOfLightRareItem)));
            weightedRandom.Add(1, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(OrbOfDarknessRareItem)));
            weightedRandom.Add(1, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(OrbOfLifeRareItem)));
            weightedRandom.Add(1, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(OrbOfSightRareItem)));
            weightedRandom.Add(2, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(OrbOfCourageRareItem)));
            weightedRandom.Add(1, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(OrbOfVenomRareItem)));
            weightedRandom.Add(1, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(OrbOfClarityRareItem)));
            weightedRandom.Add(1, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(OrbOfSoundRareItem)));
            weightedRandom.Add(1, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(OrbOfChaosRareItem)));
            weightedRandom.Add(1, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(OrbOfShardsRareItem)));
            weightedRandom.Add(1, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(OrbOfUnlifeRareItem)));
            weightedRandom.Add(1, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(OrbOfStabilityRareItem)));
            weightedRandom.Add(1, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(OrbOfMagicRareItem)));
            weightedRandom.Add(1, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(OrbOfFreedomRareItem)));
            weightedRandom.Add(1, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(OrbOfStrengthRareItem)));
            weightedRandom.Add(1, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(OrbOfWisdomRareItem)));
            weightedRandom.Add(1, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(OrbOfFlameRareItem)));
            weightedRandom.Add(1, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(OrbOfDexterityRareItem)));
            weightedRandom.Add(1, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(OrbOfConstitutionRareItem)));
            weightedRandom.Add(1, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(OrbOfIntelligenceRareItem)));
            weightedRandom.Add(1, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(OrbOfCharismaRareItem)));
            weightedRandom.Add(1, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(OrbOfLightnessRareItem)));
            weightedRandom.Add(1, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(OrbOfInsightRareItem)));
            weightedRandom.Add(1, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(OrbOfTheMindRareItem)));
            weightedRandom.Add(1, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(OrbOfSustenanceRareItem)));
            weightedRandom.Add(1, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(OrbOfHealthRareItem)));
            weightedRandom.Add(1, Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(OrbOfFrostRareItem)));
            item.RareItem = weightedRandom.ChooseOrDefault();
        }
        else if (power == 2) // Great
        {
            item.RareItem = Game.SingletonRepository.Get<ItemAdditiveBundle>(nameof(OrbOfPowerRareItem));
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

    protected override string BreakageChanceProbabilityExpression => "50/100";
    public override int PackSort => 18;
    public override bool HatesFire => true;
    public override ColorEnum Color => ColorEnum.BrightYellow;

    /// <summary>
    /// Returns true, because all light sources can be worn/wielded.
    /// </summary>
    public override bool IsWearableOrWieldable => true;
}
