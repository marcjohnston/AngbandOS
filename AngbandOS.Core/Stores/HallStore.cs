// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Stores;

[Serializable]
internal class HallStore : Store
{
    public HallStore(SaveGame saveGame) : base(saveGame) { }
    public override StoreType StoreType => StoreType.StoreHall;

    protected override StoreOwner[] StoreOwners => new StoreOwner[]
    {
        SaveGame.SingletonRepository.StoreOwners.Get<HallOfRecordsStoreOwner>()
    };

    public override string FeatureType => "HallOfRecords";
    public override Colour Colour => Colour.Yellow;
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<NumberEightSymbol>();
    public override string Description => "Hall of Records";

    public override bool ItemMatches(Item item)
    {
        return false;
    }
    protected override bool MaintainsStockLevels => false;
    protected override StockStoreInventoryItem[] GetStoreTable()
    {
        return null;
    }

    public override bool ShufflesOwnersAndPricing => false;
    protected override string OwnerName => "";
    protected override string Title => "Hall Of Records";
    protected override StoreInventoryDisplayTypeEnum ShowInventoryDisplayType => StoreInventoryDisplayTypeEnum.DoNotShowInventory;
    protected override BaseStoreCommand AdvertisedStoreCommand1 => SaveGame.SingletonRepository.StoreCommands.Get<ViewRacialHeroesStoreCommand>();
    protected override BaseStoreCommand AdvertisedStoreCommand2 => SaveGame.SingletonRepository.StoreCommands.Get<ViewClassHeroesStoreCommand>();
    protected override BaseStoreCommand AdvertisedStoreCommand3 => null; // The examine command does not work here because there is no inventory.
    protected override BaseStoreCommand AdvertisedStoreCommand4 => SaveGame.SingletonRepository.StoreCommands.Get<BuyHouseStoreCommand>();
    protected override bool PerformsMaintenanceWhenResting => false;
}
