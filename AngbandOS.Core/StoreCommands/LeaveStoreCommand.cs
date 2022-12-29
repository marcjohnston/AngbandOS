namespace AngbandOS.StoreCommands
{
    internal class LeaveStoreCommand : BaseStoreCommand
    {
        public override char Key => '\x1b';

        public override string Description => "";

        public override void Execute(StoreCommandEvent storeCommandEvent)
        {
            storeCommandEvent.LeaveStore = true;
        }
    }
}
