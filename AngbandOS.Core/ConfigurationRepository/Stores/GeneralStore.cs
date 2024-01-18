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
    private GeneralStore(SaveGame saveGame) : base(saveGame) { }

    protected override StoreOwner[] StoreOwners => new StoreOwner[]
    {
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(FalilmawenTheFriendlyStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(VoirinTheCowardlyStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(ErashnakTheMidgetStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(GrugTheComelyStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(ForovirTheCheapStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(EllisTheFoolStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(FilbertTheHungryStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(FthnarglPsathigguaStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(EloiseLongDeadStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(FundiTheSlowStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(GranthusStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(LoraxTheSuaveStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(ButchStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(ElberethTheBeautifulStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(SarlethTheSneakyStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(NarlockStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(HanekaTheSmallStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(LoirinTheMadStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(WutoPoisonbreathStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(AraakaTheRotundStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(PoogorTheDumbStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(FelorfiliandStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(MarokaTheAgedStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(SasinTheBoldStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(AbiemarThePeasantStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(HurkThePoorStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(SoalinTheWretchedStoreOwner)),
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(MerullaTheHumbleStoreOwner))
    };

    public override string FeatureType => "GeneralStore";
    public override ColourEnum Colour => ColourEnum.BrightBrown;
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

    protected override StoreCommand AdvertisedStoreCommand4 => SaveGame.SingletonRepository.StoreCommands.Get<HireEscortStoreCommand>();
}
