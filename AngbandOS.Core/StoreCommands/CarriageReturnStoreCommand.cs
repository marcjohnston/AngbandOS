namespace AngbandOS.Core.StoreCommands
{
    [Serializable]
    internal class CarriageReturnStoreCommand : BaseStoreCommand
    {
        private CarriageReturnStoreCommand(SaveGame saveGame) : base(saveGame) { }
        public override char Key => '\r';

        public override string Description => "";

        public override void Execute(StoreCommandEvent storeCommandEvent)
        {
        }
    }
}
