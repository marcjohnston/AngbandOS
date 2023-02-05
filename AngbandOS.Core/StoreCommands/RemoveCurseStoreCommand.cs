namespace AngbandOS.Core.StoreCommands
{
    [Serializable]
    internal class RemoveCurseStoreCommand : BaseStoreCommand
    {
        private RemoveCurseStoreCommand(SaveGame saveGame) : base(saveGame) { }
        public override char Key => 'r';

        public override string Description => "buy Remove Curse";

        public override bool IsEnabled(Store store) => (store.StoreType == StoreType.StoreTemple);

        public override void Execute(StoreCommandEvent storeCommandEvent)
        {
            storeCommandEvent.Store.RemoveCurse();
        }
    }
}
