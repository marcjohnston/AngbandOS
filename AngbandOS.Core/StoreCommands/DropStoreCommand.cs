namespace AngbandOS.StoreCommands
{
    internal class DropStoreCommand : BaseStoreCommand
    {
        public override char Key => 'd';

        public override string Description => "Drop an item";

        public override void Execute(StoreCommandEvent storeCommandEvent)
        {
            storeCommandEvent.Store.StoreSell();
        }

        public override bool IsEnabled(Store store) => (store.StoreType != StoreType.StoreHall);
    }
}
