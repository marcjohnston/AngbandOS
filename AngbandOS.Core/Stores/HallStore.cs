namespace AngbandOS.Stores
{
    [Serializable]
    internal class HallStore : Store
    {
        public HallStore(SaveGame saveGame) : base(saveGame, StoreType.StoreHall)
        {
        }

        protected override StoreOwner[] StoreOwners => new StoreOwner[]
        {
            new StoreOwner("Hall of Records", 0, 100, null)
        };

        public override string FeatureType => "HallOfRecords";

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
}
