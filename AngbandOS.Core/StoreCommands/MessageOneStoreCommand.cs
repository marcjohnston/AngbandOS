namespace AngbandOS.StoreCommands
{
    /// <summary>
    /// Show the previous message
    /// </summary>
    [Serializable]
    internal class MessageOneStoreCommand : BaseStoreCommand
    {
        private MessageOneStoreCommand(SaveGame saveGame) : base(saveGame) { }
        public override char Key => 'O';

        public override string Description => "";

        public override void Execute(StoreCommandEvent storeCommandEvent)
        {
            SaveGame.DoCmdMessageOne();
        }
    }
}
