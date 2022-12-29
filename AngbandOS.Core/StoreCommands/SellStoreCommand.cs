namespace AngbandOS.StoreCommands
{
    internal class SellStoreCommand : BaseStoreCommand
    {
        public override char Key => 's';

        public override string Description => "Sell an item";

        public override void Execute(StoreCommandEvent storeCommandEvent)
        {
            storeCommandEvent.Store.StoreSell();
        }

        public override bool IsEnabled(Store store) => (store.StoreType != StoreType.StoreHall);
    }
}
