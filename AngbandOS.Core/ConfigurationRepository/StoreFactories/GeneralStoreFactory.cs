// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.StoreFactories;

[Serializable]
internal class GeneralStoreFactory : StoreFactory
{
    private GeneralStoreFactory(SaveGame saveGame) : base(saveGame) { }

    protected override string[] ShopkeeperNames => new string[]
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

    protected override string TileName => "GeneralStore";

    protected override StoreStockManifestDefinition[]? StoreStockManifestDefinitions => new[]
    {
        new StoreStockManifestDefinition(nameof(WoodenArrowAmmunitionItemFactory), 2),
        new StoreStockManifestDefinition(nameof(SteelBoltAmmunitionItemFactory), 2),
        new StoreStockManifestDefinition(nameof(ClothCloakCloakArmorItemFactory), 3),
        new StoreStockManifestDefinition(nameof(PickDiggingWeaponItemFactory)),
        new StoreStockManifestDefinition(nameof(ShovelDiggingWeaponItemFactory), 2),
        new StoreStockManifestDefinition(nameof(OilFlaskItemFactory), 10),
        new StoreStockManifestDefinition(nameof(HardBiscuitFoodItemFactory)),
        new StoreStockManifestDefinition(nameof(PintOfFineAleFoodItemFactory)),
        new StoreStockManifestDefinition(nameof(PintOfFineWineFoodItemFactory)),
        new StoreStockManifestDefinition(nameof(RationFoodItemFactory), 9),
        new StoreStockManifestDefinition(nameof(StripOfVenisonFoodItemFactory), 2),
        new StoreStockManifestDefinition(nameof(BrassLanternLightSourceItemFactory), 4),
        new StoreStockManifestDefinition(nameof(OrbLightSourceItemFactory)),
        new StoreStockManifestDefinition(nameof(WoodenTorchLightSourceItemFactory), 5),
        new StoreStockManifestDefinition(nameof(IronShotAmmunitionItemFactory), 2),
        new StoreStockManifestDefinition(nameof(IronSpikeItemFactory), 2),
    };

    /// <summary>
    /// Returns the name of the item matching criteria for shots, bolts, arrows, bows, digging tools, hafted weapons, pole arms and swords of value.
    /// </summary>
    protected override string[] ItemFilterNames => new string[]
{
        nameof(FoodItemFilter),
        nameof(LightSourcesOfValueFilter),
        nameof(FlaskItemFilter),
        nameof(SpikeOfValueItemFilter),
        nameof(ShotsOfValueItemFilter),
        nameof(ArrowsOfValueItemFilter),
        nameof(BoltsOfValueItemFilter),
        nameof(DiggingItemsOfValueItemFilter),
        nameof(CloaksOfValueItemFilter),
        nameof(BottlesOfValueItemFilter)
    };

    protected override string? AdvertisedStoreCommand4Name => nameof(HireEscortStoreCommand);
}
