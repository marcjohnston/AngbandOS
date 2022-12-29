namespace AngbandOS.StoreCommands
{
    internal class MGetStoreCommand : BaseStoreCommand
    {
        public override char Key => 'm';

        public override string Description => "";

        public override void Execute(StoreCommandEvent storeCommandEvent)
        {
            storeCommandEvent.Store.StorePurchase();
        }

        public override bool IsEnabled(Store store) => (store.StoreType != StoreType.StoreHall);
    }
}
