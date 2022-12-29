namespace AngbandOS.StoreCommands
{
    internal class PurchaseStoreCommand : BaseStoreCommand
    {
        public override char Key => 'p';

        public override string Description => "Purchase an item";

        public override void Execute(StoreCommandEvent storeCommandEvent)
        {
            storeCommandEvent.Store.StorePurchase();
        }

        public override bool IsEnabled(Store store) => (store.StoreType != StoreType.StoreHall);
    }
}
