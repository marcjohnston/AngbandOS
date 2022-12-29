namespace AngbandOS.StoreCommands
{
    internal class ExamineStoreCommand : BaseStoreCommand
    {
        public override char Key => 'x';

        public override string Description => "eXamine an item";

        public override void Execute(StoreCommandEvent storeCommandEvent)
        {
            storeCommandEvent.Store.StoreExamine();
        }

        public override bool IsEnabled(Store store) => (store.StoreType != StoreType.StoreHall);
    }
}
