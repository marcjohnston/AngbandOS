namespace AngbandOS.StoreCommands
{
    [Serializable]
    internal class RestorationStoreCommand : BaseStoreCommand

    {
        private RestorationStoreCommand(SaveGame saveGame) : base(saveGame) { }
        public override char Key => 'r';

        public override string Description => "buy Restoration";

        public override bool IsEnabled(Store store) => (store.StoreType == StoreType.StoreAlchemist);

        public override void Execute(StoreCommandEvent storeCommandEvent)
        {
            storeCommandEvent.Store.Restoration();
        }
    }
}
