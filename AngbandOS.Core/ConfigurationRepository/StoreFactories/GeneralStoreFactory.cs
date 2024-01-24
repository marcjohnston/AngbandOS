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
    public override ColourEnum Colour => ColourEnum.BrightBrown;
    protected override string SymbolName => nameof(NumberOneSymbol);
    public override string Description => "General Store";

    public override StockStoreInventoryItem[] GetStoreTable()
    {
        return new[]
        {
            new StockStoreInventoryItem(typeof(WoodenArrowAmmunitionItemFactory), 2),
            new StockStoreInventoryItem(typeof(SteelBoltAmmunitionItemFactory), 2),
            new StockStoreInventoryItem(typeof(ClothCloakCloakArmorItemFactory), 3),
            new StockStoreInventoryItem(typeof(DiggingPick)),
            new StockStoreInventoryItem(typeof(DiggingShovel), 2),
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
            new StockStoreInventoryItem(typeof(SpikeIronSpike), 2),
        };
    }

    public override bool ItemMatches(Item item)
    {
        switch (item.Factory)
        {
            case FoodItemFactory _:
            case LightSourceItemFactory _:
            case FlaskItemFactory _:
            case SpikeItemClass _:
            case ShotAmmunitionItemFactory _:
            case ArrowAmmunitionItemFactory _:
            case BoltAmmunitionItemFactory _:
            case DiggingItemClass _:
            case CloakArmorItemFactory _:
            case BottleItemFactory _:
                return item.Value() > 0;
            default:
                return false;
        }
    }

    protected override string? AdvertisedStoreCommand4Name => nameof(HireEscortStoreCommand);
}
