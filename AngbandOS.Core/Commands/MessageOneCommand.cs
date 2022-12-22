using AngbandOS.StoreCommands;

namespace AngbandOS.Commands
{
    /// <summary>
    /// Show the previous message
    /// </summary>
    [Serializable]
    internal class MessageOneCommand : ICommand
    {
        private MessageOneCommand(SaveGame saveGame) { } // This object is a singleton.

        public char Key => 'O';

        public int? Repeat => 0;

        public bool IsEnabled => true;

        public void Execute(SaveGame saveGame)
        {
            MessageOneStoreCommand.DoCmdMessageOne(saveGame);
        }
    }
}
