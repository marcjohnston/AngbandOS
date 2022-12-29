namespace AngbandOS.StoreCommands
{
    internal class CarriageReturnStoreCommand : BaseStoreCommand
    {
        public override char Key => '\r';

        public override string Description => "";

        public override void Execute(StoreCommandEvent storeCommandEvent)
        {
        }
    }
}
