namespace AngbandOS.StoreCommands
{
    [Serializable]
    internal class IdentifyAllStoreCommand : BaseStoreCommand
    {
        private IdentifyAllStoreCommand(SaveGame saveGame) : base(saveGame) { }
        public override char Key => 'r';

        public override string Description => "Identify all";

        public override bool IsEnabled(Store store) => (store.StoreType == StoreType.StorePawn);

        public override void Execute(StoreCommandEvent storeCommandEvent)
        {
            storeCommandEvent.Store.IdentifyAll();
        }
    }
}
