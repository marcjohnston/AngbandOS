// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Stores;

[Serializable]
internal class GeneralStore : Store
{
    public GeneralStore(SaveGame saveGame) : base(saveGame) { }
    public override StoreType StoreType => StoreType.StoreGeneral;

    protected override StoreOwner[] StoreOwners => new StoreOwner[]
    {
        SaveGame.SingletonRepository.StoreOwners.Get<FalilmawenTheFriendlyStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<VoirinTheCowardlyStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<ErashnakTheMidgetStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<GrugTheComelyStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<ForovirTheCheapStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<EllisTheFoolStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<FilbertTheHungryStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<FthnarglPsathigguaStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<EloiseLongDeadStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<FundiTheSlowStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<GranthusStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<LoraxTheSuaveStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<ButchStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<ElberethTheBeautifulStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<SarlethTheSneakyStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<NarlockStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<HanekaTheSmallStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<LoirinTheMadStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<WutoPoisonbreathStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<AraakaTheRotundStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<PoogorTheDumbStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<FelorfiliandStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<MarokaTheAgedStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<SasinTheBoldStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<AbiemarThePeasantStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<HurkThePoorStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<SoalinTheWretchedStoreOwner>(),
        SaveGame.SingletonRepository.StoreOwners.Get<MerullaTheHumbleStoreOwner>()
    };

    public override string FeatureType => "GeneralStore";
    public override Colour Colour => Colour.BrightBrown;
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<NumberOneSymbol>();
    public override string Description => "General Store";

    protected override StockStoreInventoryItem[] GetStoreTable()
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

    protected override BaseStoreCommand AdvertisedStoreCommand4 => SaveGame.SingletonRepository.StoreCommands.Get<HireEscortStoreCommand>();
}
