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

    protected override string[] StoreOwnerNames => new string[]
    {
        nameof(FalilmawenTheFriendlyStoreOwner),
        nameof(VoirinTheCowardlyStoreOwner),
        nameof(ErashnakTheMidgetStoreOwner),
        nameof(GrugTheComelyStoreOwner),
        nameof(ForovirTheCheapStoreOwner),
        nameof(EllisTheFoolStoreOwner),
        nameof(FilbertTheHungryStoreOwner),
        nameof(FthnarglPsathigguaStoreOwner),
        nameof(EloiseLongDeadStoreOwner),
        nameof(FundiTheSlowStoreOwner),
        nameof(GranthusStoreOwner),
        nameof(LoraxTheSuaveStoreOwner),
        nameof(ButchStoreOwner),
        nameof(ElberethTheBeautifulStoreOwner),
        nameof(SarlethTheSneakyStoreOwner),
        nameof(NarlockStoreOwner),
        nameof(HanekaTheSmallStoreOwner),
        nameof(LoirinTheMadStoreOwner),
        nameof(WutoPoisonbreathStoreOwner),
        nameof(AraakaTheRotundStoreOwner),
        nameof(PoogorTheDumbStoreOwner),
        nameof(FelorfiliandStoreOwner),
        nameof(MarokaTheAgedStoreOwner),
        nameof(SasinTheBoldStoreOwner),
        nameof(AbiemarThePeasantStoreOwner),
        nameof(HurkThePoorStoreOwner),
        nameof(SoalinTheWretchedStoreOwner),
        nameof(MerullaTheHumbleStoreOwner)
    };

    public override string FeatureType => "GeneralStore";
    public override ColorEnum Color => ColorEnum.BrightBrown;
    protected override string SymbolName => nameof(NumberOneSymbol);
    public override string Description => "General Store";

    public override StockStoreInventoryItem[] GetStoreTable()
    {
        return new[]
        {
            new StockStoreInventoryItem(typeof(WoodenArrowAmmunitionItemFactory), 2),
            new StockStoreInventoryItem(typeof(SteelBoltAmmunitionItemFactory), 2),
            new StockStoreInventoryItem(typeof(ClothCloakCloakArmorItemFactory), 3),
            new StockStoreInventoryItem(typeof(PickDiggingWeaponItemFactory)),
            new StockStoreInventoryItem(typeof(ShovelDiggingWeaponItemFactory), 2),
            new StockStoreInventoryItem(typeof(OilFlaskItemFactory), 10),
            new StockStoreInventoryItem(typeof(HardBiscuitFoodItemFactory)),
            new StockStoreInventoryItem(typeof(PintOfFineAleFoodItemFactory)),
            new StockStoreInventoryItem(typeof(PintOfFineWineFoodItemFactory)),
            new StockStoreInventoryItem(typeof(RationFoodItemFactory), 9),
            new StockStoreInventoryItem(typeof(StripOfVenisonFoodItemFactory), 2),
            new StockStoreInventoryItem(typeof(BrassLanternLightSourceItemFactory), 4),
            new StockStoreInventoryItem(typeof(OrbLightSourceItemFactory)),
            new StockStoreInventoryItem(typeof(WoodenTorchLightSourceItemFactory), 5),
            new StockStoreInventoryItem(typeof(IronShotAmmunitionItemFactory), 2),
            new StockStoreInventoryItem(typeof(IronSpikeItemFactory), 2),
        };
    }

    /// <summary>
    /// Returns the name of the item matching criteria for shots, bolts, arrows, bows, digging tools, hafted weapons, pole arms and swords of value.
    /// </summary>
    protected override string[] ItemFilterNames => new string[]
{
        nameof(FoodItemFilter),
        nameof(LightSourceItemFilter),
        nameof(FlaskItemFilter),
        nameof(SpikeItemFilter),
        nameof(ShotAmmunitionItemFilter),
        nameof(ArrowAmmunitionItemFilter),
        nameof(BoltAmmunitionItemFilter),
        nameof(DiggingItemFilter),
        nameof(CloakArmorItemFilter),
        nameof(BottleItemFilter)
    };

    protected override string? AdvertisedStoreCommand4Name => nameof(HireEscortStoreCommand);
}
