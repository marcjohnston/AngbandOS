using AngbandOS.Commands;

namespace AngbandOS.StoreCommands
{
    /// <summary>
    /// Show the previous message
    /// </summary>
    [Serializable]
    internal class MessageOneStoreCommand : IStoreCommand
    {
        public char Key => 'O';

        public bool IsEnabled(Store store) => true;

        public string Description => "";

        public bool RequiresRerendering => false;

        public void Execute(SaveGame saveGame, Store store)
        {
            DoCmdMessageOne(saveGame);
        }

        public static void DoCmdMessageOne(SaveGame saveGame)
        {
            saveGame.PrintLine($"> {saveGame.MessageStr(0)}", 0, 0);
        }
    }
}
