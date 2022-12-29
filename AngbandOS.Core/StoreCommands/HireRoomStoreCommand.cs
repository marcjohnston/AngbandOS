namespace AngbandOS.StoreCommands
{
    internal class HireRoomStoreCommand : BaseStoreCommand

    {
        public override char Key => 'r';

        public override string Description => "hire a Room";

        public override void Execute(StoreCommandEvent storeCommandEvent)
        {
            storeCommandEvent.Store.HireRoom();
        }

        public override bool IsEnabled(Store store) => (store.StoreType == StoreType.StoreInn);
    }
}