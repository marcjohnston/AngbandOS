namespace AngbandOS.StoreCommands
{
    internal class GetStoreCommand : BaseStoreCommand
    {
        public override char Key => 'g';

        public override string Description => "Get an item";

        public override void Execute(StoreCommandEvent storeCommandEvent)
        {
            storeCommandEvent.Store.StorePurchase();
        }

        public override bool IsEnabled(Store store) => (store.StoreType != StoreType.StoreHall);
    }
}
