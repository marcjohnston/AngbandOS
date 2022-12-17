using AngbandOS.StoreCommands;

namespace AngbandOS.Commands
{
    /// <summary>
    /// Let the player scroll through previous messages
    /// </summary>
    [Serializable]
    internal class MessagesCommand : ICommand
    {
        private MessagesCommand() { } // This object is a singleton.

        public char Key => 'P';

        public int? Repeat => 0;

        public bool IsEnabled => true;

        public void Execute(SaveGame saveGame)
        {
            MessagesStoreCommand.DoCmdMessages(saveGame);
        }
    }
}
