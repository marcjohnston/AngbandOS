namespace AngbandOS.StoreCommands
{
    internal class IdentifyAllStoreCommand : BaseStoreCommand

    {
        public override char Key => 'r';

        public override string Description => "Identify all";

        public override void Execute(StoreCommandEvent storeCommandEvent)
        {
            storeCommandEvent.Store.IdentifyAll();
        }

        public override bool IsEnabled(Store store) => (store.StoreType == StoreType.StorePawn);
    }
}
