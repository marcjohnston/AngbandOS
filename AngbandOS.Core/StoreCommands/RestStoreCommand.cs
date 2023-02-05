namespace AngbandOS.Core.StoreCommands
{
    [Serializable]
    internal class RestStoreCommand : BaseStoreCommand

    {
        private RestStoreCommand(SaveGame saveGame) : base(saveGame) { }
        public override char Key => 'r';

        public override string Description => "Rest a while";

        public override bool IsEnabled(Store store) => (store.StoreType == StoreType.StoreHome);

        public override void Execute(StoreCommandEvent storeCommandEvent)
        {
            storeCommandEvent.Store.Rest();
        }
    }
}
