namespace AngbandOS.StoreCommands
{
    internal class RestStoreCommand : BaseStoreCommand

    {
        public override char Key => 'r';

        public override string Description => "Rest a while";

        public override void Execute(StoreCommandEvent storeCommandEvent)
        {
            storeCommandEvent.Store.Rest();
        }

        public override bool IsEnabled(Store store) => (store.StoreType == StoreType.StoreHome);
    }
}
