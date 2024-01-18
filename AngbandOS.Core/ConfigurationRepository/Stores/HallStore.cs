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
    private HallStore(SaveGame saveGame) : base(saveGame) { }

    protected override StoreOwner[] StoreOwners => new StoreOwner[]
    {
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(HallOfRecordsStoreOwner))
    };

    public override string FeatureType => "HallOfRecords";
    public override ColourEnum Colour => ColourEnum.Yellow;
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(NumberEightSymbol));
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
    protected override StoreCommand AdvertisedStoreCommand1 => SaveGame.SingletonRepository.StoreCommands.Get(nameof(ViewRacialHeroesStoreCommand));
    protected override StoreCommand AdvertisedStoreCommand2 => SaveGame.SingletonRepository.StoreCommands.Get(nameof(ViewClassHeroesStoreCommand));
    protected override StoreCommand AdvertisedStoreCommand3 => null; // The examine command does not work here because there is no inventory.
    protected override StoreCommand AdvertisedStoreCommand4 => SaveGame.SingletonRepository.StoreCommands.Get(nameof(BuyHouseStoreCommand));
    protected override bool PerformsMaintenanceWhenResting => false;
}
