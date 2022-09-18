using AngbandOS.Enumerations;
using System;

namespace AngbandOS.Stores
{
    [Serializable]
    internal class EmptyLotStore : Store
    {
        public EmptyLotStore(SaveGame saveGame) : base(saveGame, StoreType.StoreEmptyLot)
        {
        }

        protected override StoreOwner[] StoreOwners => new StoreOwner[]
        {
            new StoreOwner("Empty lot", 0, 100, 99)
        };

        public override string FeatureType => "";

        protected override bool StoreWillBuy(Item item)
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
