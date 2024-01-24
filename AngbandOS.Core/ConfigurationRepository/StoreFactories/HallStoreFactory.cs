// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.StoreFactories;

[Serializable]
internal class HallStoreFactory : StoreFactory
{
    private HallStoreFactory(SaveGame saveGame) : base(saveGame) { }

    protected override string[] StoreOwnerNames => new string[]
    {
        nameof(HallOfRecordsStoreOwner)
    };

    public override string FeatureType => "HallOfRecords";
    public override ColourEnum Colour => ColourEnum.Yellow;
    protected override string SymbolName => nameof(NumberEightSymbol);
    public override string Description => "Hall of Records";

    public override bool ItemMatches(Item item)
    {
        return false;
    }
    public override bool MaintainsStockLevels => false;
    public override StockStoreInventoryItem[] GetStoreTable() => null;

    public override bool ShufflesOwnersAndPricing => false;
    public override string? OwnerName => "";
    public override string? Title => "Hall Of Records";
    public override StoreInventoryDisplayTypeEnum ShowInventoryDisplayType => StoreInventoryDisplayTypeEnum.DoNotShowInventory;
    protected override string? AdvertisedStoreCommand1Name => nameof(ViewRacialHeroesStoreCommand);
    protected override string? AdvertisedStoreCommand2Name => nameof(ViewClassHeroesStoreCommand);
    protected override string? AdvertisedStoreCommand3Name => null; // The examine command does not work here because there is no inventory.
    protected override string? AdvertisedStoreCommand4Name => nameof(BuyHouseStoreCommand);
    public override bool PerformsMaintenanceWhenResting => false;
}
