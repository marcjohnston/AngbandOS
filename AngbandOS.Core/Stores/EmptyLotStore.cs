namespace AngbandOS.Core.Stores
{
    [Serializable]
    internal class EmptyLotStore : Store
    {
        private EmptyLotStore(SaveGame saveGame) : base(saveGame, StoreType.StoreEmptyLot) { } // This object is a singleton

        protected override StoreOwner[] StoreOwners => new StoreOwner[]
        {
            SaveGame.SingletonRepository.StoreOwners.Get<EmptyLotStoreOwner>()
        };

        public override string FeatureType => "";

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
}
