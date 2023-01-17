namespace AngbandOS.StoreCommands
{
    [Serializable]
    internal class DropStoreCommand : BaseStoreCommand
    {
        private DropStoreCommand(SaveGame saveGame) : base(saveGame) { }
        public override char Key => 'd';

        public override string Description => "Drop an item";

        public override bool IsEnabled(Store store) => (store.StoreType != StoreType.StoreHall);

        public override void Execute(StoreCommandEvent storeCommandEvent)
        {
            storeCommandEvent.Store.StoreSell();
        }
    }
}
