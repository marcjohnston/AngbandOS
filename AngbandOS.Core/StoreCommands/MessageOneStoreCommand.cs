namespace AngbandOS.StoreCommands
{
    /// <summary>
    /// Show the previous message
    /// </summary>
    [Serializable]
    internal class MessageOneStoreCommand : BaseStoreCommand
    {
        public override char Key => 'O';

        public override string Description => "";

        public override void Execute(StoreCommandEvent storeCommandEvent)
        {
            DoCmdMessageOne(storeCommandEvent.SaveGame);
        }

        public static void DoCmdMessageOne(SaveGame saveGame)
        {
            saveGame.PrintLine($"> {saveGame.MessageStr(0)}", 0, 0);
        }
    }
}
