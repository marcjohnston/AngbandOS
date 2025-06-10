// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class GeneralStoreFactory : StoreFactoryGameConfiguration
{

    public override string[] ShopkeeperNames => new string[]
    {
        nameof(FalilmawenTheFriendlyShopkeeper),
        nameof(VoirinTheCowardlyShopkeeper),
        nameof(ErashnakTheMidgetShopkeeper),
        nameof(GrugTheComelyShopkeeper),
        nameof(ForovirTheCheapShopkeeper),
        nameof(EllisTheFoolShopkeeper),
        nameof(FilbertTheHungryShopkeeper),
        nameof(FthnarglPsathigguaShopkeeper),
        nameof(EloiseLongDeadShopkeeper),
        nameof(FundiTheSlowShopkeeper),
        nameof(GranthusShopkeeper),
        nameof(LoraxTheSuaveShopkeeper),
        nameof(ButchShopkeeper),
        nameof(ElberethTheBeautifulShopkeeper),
        nameof(SarlethTheSneakyShopkeeper),
        nameof(NarlockShopkeeper),
        nameof(HanekaTheSmallShopkeeper),
        nameof(LoirinTheMadShopkeeper),
        nameof(WutoPoisonbreathShopkeeper),
        nameof(AraakaTheRotundShopkeeper),
        nameof(PoogorTheDumbShopkeeper),
        nameof(FelorfiliandShopkeeper),
        nameof(MarokaTheAgedShopkeeper),
        nameof(SasinTheBoldShopkeeper),
        nameof(AbiemarThePeasantShopkeeper),
        nameof(HurkThePoorShopkeeper),
        nameof(SoalinTheWretchedShopkeeper),
        nameof(MerullaTheHumbleShopkeeper)
    };

    public override string TileName => nameof(GeneralStoreTile);

    public override (string ItemFactoryName, int Weight)[]? StoreStockManifestDefinitions => new (string, int)[]
    {
        (nameof(WoodenArrowAmmunitionItemFactory), 2),
        (nameof(SteelBoltAmmunitionItemFactory), 2),
        (nameof(ClothCloakItemFactory), 3),
        (nameof(PickDiggingWeaponItemFactory), 1),
        (nameof(ShovelDiggingWeaponItemFactory), 2),
        (nameof(FlaskOfOilItemFactory), 10),
        (nameof(HardBiscuitFoodItemFactory), 1),
        (nameof(PintOfFineAleFoodItemFactory), 1),
        (nameof(PintOfFineWineFoodItemFactory), 1),
        (nameof(RationFoodItemFactory), 9),
        (nameof(StripOfVenisonFoodItemFactory), 2),
        (nameof(BrassLanternLightSourceItemFactory), 4),
        (nameof(OrbLightSourceItemFactory), 1),
        (nameof(WoodenTorchLightSourceItemFactory), 5),
        (nameof(IronShotAmmunitionItemFactory), 2),
        (nameof(IronSpikeItemFactory), 2),
    };

    /// <summary>
    /// Returns the name of the item matching criteria for shots, bolts, arrows, bows, digging tools, hafted weapons, pole arms and swords of value.
    /// </summary>
    public override string[] ItemFilterNames => new string[]
{
        nameof(ItemFiltersEnum.FoodOfValueItemFilter),
        nameof(ItemFiltersEnum.LightSourcesOfValueItemFilter),
        nameof(ItemFiltersEnum.FlasksOfValueItemFilter),
        nameof(ItemFiltersEnum.SpikeOfValueItemFilter),
        nameof(ItemFiltersEnum.ShotsOfValueItemFilter),
        nameof(ItemFiltersEnum.ArrowsOfValueItemFilter),
        nameof(ItemFiltersEnum.BoltsOfValueItemFilter),
        nameof(ItemFiltersEnum.DiggersOfValueItemFilter),
        nameof(ItemFiltersEnum.CloaksOfValueItemFilter),
        nameof(ItemFiltersEnum.BottlesOfValueItemFilter)
    };

    public override string? AdvertisedStoreCommand4Name => nameof(HireEscortStoreCommand);
}
