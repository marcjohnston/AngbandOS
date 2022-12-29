namespace AngbandOS.StoreCommands
{
    internal class ResearchItemStoreCommand : BaseStoreCommand

    {
        public override char Key => 'r';

        public override string Description => "Research an item";

        public override void Execute(StoreCommandEvent storeCommandEvent)
        {
            storeCommandEvent.Store.ResearchItem();
        }

        public override bool IsEnabled(Store store) => (store.StoreType == StoreType.StoreMagic);
    }
}
