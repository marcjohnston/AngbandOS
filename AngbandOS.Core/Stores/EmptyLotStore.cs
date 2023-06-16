namespace AngbandOS.Core.Stores;

[Serializable]
internal class EmptyLotStore : Store
{
    public EmptyLotStore(SaveGame saveGame) : base(saveGame) { }

    public override StoreType StoreType => StoreType.StoreEmptyLot;
    protected override StoreOwner[] StoreOwners => new StoreOwner[]
    {
        SaveGame.SingletonRepository.StoreOwners.Get<EmptyLotStoreOwner>()
    };

    public override string FeatureType => "";
    public override Colour Colour => Colour.White;
    public override char Character => ' ';

    public override bool ItemMatches(Item item)
    {
        return false;
    }
    protected override bool MaintainsStockLevels => false;
    public override bool ShufflesOwnersAndPricing => false;
    protected override StockStoreInventoryItem[] GetStoreTable()
    {
        return null;
    }
    protected override bool PerformsMaintenanceWhenResting => false;
}
