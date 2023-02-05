namespace AngbandOS.Core.StoreCommands
{
    /// <summary>
    /// Take off an item
    /// </summary>
    [Serializable]
    internal class TakeOffStoreCommand : BaseStoreCommand
    {
        private TakeOffStoreCommand(SaveGame saveGame) : base(saveGame) { }
        public override char Key => 't';

        public override string Description => "";

        public override void Execute(StoreCommandEvent storeCommandEvent)
        {
            SaveGame.DoCmdTakeOff();
        }
    }
}
