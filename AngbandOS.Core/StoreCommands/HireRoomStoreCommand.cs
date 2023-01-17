namespace AngbandOS.StoreCommands
{
    [Serializable]
    internal class HireRoomStoreCommand : BaseStoreCommand

    {
        private HireRoomStoreCommand(SaveGame saveGame) : base(saveGame) { }
        public override char Key => 'r';

        public override string Description => "hire a Room";

        public override bool IsEnabled(Store store) => (store.StoreType == StoreType.StoreInn);

        public override void Execute(StoreCommandEvent storeCommandEvent)
        {
            storeCommandEvent.Store.HireRoom();
        }
    }
}