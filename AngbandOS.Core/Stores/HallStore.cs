using Cthangband.Commands;
using Cthangband.Enumerations;
using Cthangband.StoreCommands;
using System;

namespace Cthangband.Stores
{
    [Serializable]
    internal class HallStore : Store
    {
        public HallStore() : base(StoreType.StoreHall)
        {
        }

        protected override StoreOwner[] StoreOwners => new StoreOwner[]
        {
            new StoreOwner("Hall of Records", 0, 100, 99)
        };

        public override string FeatureType => "HallOfRecords";

        protected override bool StoreWillBuy(Item item)
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
        protected override IStoreCommand AdvertisedStoreCommand1 => new ViewRacialHeroesStoreCommand();
        protected override IStoreCommand AdvertisedStoreCommand2 => new ViewClassHeroesStoreCommand();
        protected override IStoreCommand AdvertisedStoreCommand3 => null; // The examine command does not work here because there is no inventory.
        protected override IStoreCommand AdvertisedStoreCommand4 => new BuyHouseStoreCommand();
        protected override bool PerformsMaintenanceWhenResting => false;
    }
}
