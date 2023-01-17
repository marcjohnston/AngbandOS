namespace AngbandOS.StoreCommands
{
    [Serializable]
    internal class MGetStoreCommand : BaseStoreCommand
    {
        private MGetStoreCommand(SaveGame saveGame) : base(saveGame) { }
        public override char Key => 'm';

        public override string Description => "";

        public override bool IsEnabled(Store store) => (store.StoreType != StoreType.StoreHall);

        public override void Execute(StoreCommandEvent storeCommandEvent)
        {
            storeCommandEvent.Store.StorePurchase();
        }
    }
}
