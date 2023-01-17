namespace AngbandOS.StoreCommands
{
    [Serializable]
    internal class ResearchItemStoreCommand : BaseStoreCommand

    {
        private ResearchItemStoreCommand(SaveGame saveGame) : base(saveGame) { }
        public override char Key => 'r';

        public override string Description => "Research an item";

        public override bool IsEnabled(Store store) => (store.StoreType == StoreType.StoreMagic);

        public override void Execute(StoreCommandEvent storeCommandEvent)
        {
            storeCommandEvent.Store.ResearchItem();
        }
    }
}
