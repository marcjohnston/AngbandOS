namespace AngbandOS.Core.StoreCommands
{
    [Serializable]
    internal class GetStoreCommand : BaseStoreCommand
    {
        private GetStoreCommand(SaveGame saveGame) : base(saveGame) { }
        public override char Key => 'g';

        public override string Description => "Get an item";

        public override bool IsEnabled(Store store) => (store.StoreType != StoreType.StoreHall);

        public override void Execute(StoreCommandEvent storeCommandEvent)
        {
            storeCommandEvent.Store.StorePurchase();
        }
    }
}
