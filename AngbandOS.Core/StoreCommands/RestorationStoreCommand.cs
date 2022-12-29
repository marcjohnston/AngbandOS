namespace AngbandOS.StoreCommands
{
    internal class RestorationStoreCommand : BaseStoreCommand

    {
        public override char Key => 'r';

        public override string Description => "buy Restoration";

        public override void Execute(StoreCommandEvent storeCommandEvent)
        {
            storeCommandEvent.Store.Restoration();
        }

        public override bool IsEnabled(Store store) => (store.StoreType == StoreType.StoreAlchemist);
    }
}
