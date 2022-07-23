using Cthangband.Enumerations;
using System;

namespace Cthangband.Stores
{
    [Serializable]
    internal class EmptyLotStore : Store
    {
        public EmptyLotStore() : base(StoreType.StoreEmptyLot)
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
        protected override bool HasStoreTable => false;
        protected override bool PerformsMaintenanceWhenResting => false;
    }
}
