using AngbandOS.StoreCommands;

namespace AngbandOS.Commands
{
    /// <summary>
    /// Look in the player's journal for any one of a number of different reasons
    /// </summary>
    [Serializable]
    internal class JournalCommand : ICommand
    {
        private JournalCommand() { } // This object is a singleton.

        public char Key => 'J';

        public int? Repeat => 0;

        public bool IsEnabled => true;

        public void Execute(SaveGame saveGame)
        {
            JournalStoreCommand.DoCmdJournal(saveGame);
        }
    }
}
