namespace AngbandOS.StoreCommands
{
    internal class SacrificeStoreCommand : BaseStoreCommand
    {
        public override char Key => 'v';

        public override string Description => "Sacrifice Item";

        public override void Execute(StoreCommandEvent storeCommandEvent)
        {
            storeCommandEvent.Store.SacrificeItem();
        }

        public override bool IsEnabled(Store store) => (store.StoreType == StoreType.StoreTemple);
    }
}
