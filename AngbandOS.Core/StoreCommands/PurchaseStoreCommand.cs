namespace AngbandOS.StoreCommands
{
    [Serializable]
    internal class PurchaseStoreCommand : BaseStoreCommand
    {
        private PurchaseStoreCommand(SaveGame saveGame) : base(saveGame) { }
        public override char Key => 'p';

        public override string Description => "Purchase an item";

        public override bool IsEnabled(Store store) => (store.StoreType != StoreType.StoreHall);

        public override void Execute(StoreCommandEvent storeCommandEvent)
        {
            storeCommandEvent.Store.StorePurchase();
        }
    }
}
