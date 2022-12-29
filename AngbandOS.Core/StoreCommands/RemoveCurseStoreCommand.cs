namespace AngbandOS.StoreCommands
{
    internal class RemoveCurseStoreCommand : BaseStoreCommand

    {
        public override char Key => 'r';

        public override string Description => "buy Remove Curse";

        public override void Execute(StoreCommandEvent storeCommandEvent)
        {
            storeCommandEvent.Store.RemoveCurse();
        }

        public override bool IsEnabled(Store store) => (store.StoreType == StoreType.StoreTemple);
    }
}
