namespace AngbandOS.StoreCommands
{
    [Serializable]
    internal class LeaveStoreCommand : BaseStoreCommand
    {
        private LeaveStoreCommand(SaveGame saveGame) : base(saveGame) { }
        public override char Key => '\x1b';

        public override string Description => "";

        public override void Execute(StoreCommandEvent storeCommandEvent)
        {
            storeCommandEvent.LeaveStore = true;
        }
    }
}
