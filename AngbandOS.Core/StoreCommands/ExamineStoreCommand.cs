namespace AngbandOS.Core.StoreCommands
{
    [Serializable]
    internal class ExamineStoreCommand : BaseStoreCommand
    {
        private ExamineStoreCommand(SaveGame saveGame) : base(saveGame) { }
        public override char Key => 'x';

        public override string Description => "eXamine an item";

        public override bool IsEnabled(Store store) => (store.StoreType != StoreType.StoreHall);

        public override void Execute(StoreCommandEvent storeCommandEvent)
        {
            storeCommandEvent.Store.StoreExamine();
        }
    }
}
