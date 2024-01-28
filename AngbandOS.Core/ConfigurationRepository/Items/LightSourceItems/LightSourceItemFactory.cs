// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal abstract class LightSourceItemFactory : ItemFactory
{
    /// <summary>
    /// Returns the lightsource inventory slot for light sources.
    /// </summary>
    public override int WieldSlot => InventorySlot.Lightsource;
    public LightSourceItemFactory(SaveGame saveGame) : base(saveGame) { }
    public override ItemClass ItemClass => SaveGame.SingletonRepository.ItemClasses.Get(nameof(LightSourcesItemClass));
    public override BaseInventorySlot BaseWieldSlot => SaveGame.SingletonRepository.InventorySlots.Get(nameof(LightsourceInventorySlot));
    public override bool IsWorthless(Item item) => item.TypeSpecificValue < 0;


    public override void ApplyMagic(Item item, int level, int power, Store? store)
    {
        if (power < 0) // Cursed
        {
            switch (SaveGame.Rng.DieRoll(2)) // Cursed
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
            WeightedRandom<RareItemTypeEnum> weightedRandom = new WeightedRandom<RareItemTypeEnum>(SaveGame);
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
                WeightedRandomAction weightedRandomAction = new WeightedRandomAction(SaveGame);
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

    public override bool ItemsCanBeMerged(Item a, Item b)
    {
        if (!base.ItemsCanBeMerged(a, b))
        {
            return false;
        }
        if (!StatsAreSame(a, b))
        {
            return false;
        }
        return true;
    }

    public virtual void Refill(SaveGame saveGame, Item item)
    {
        saveGame.MsgPrint("Your light cannot be refilled.");
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
}
