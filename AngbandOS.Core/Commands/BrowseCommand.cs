using AngbandOS.StoreCommands;

namespace AngbandOS.Commands
{
    /// <summary>
    /// Browse a book
    /// </summary>
    [Serializable]
    internal class BrowseCommand : ICommand
    {
        private BrowseCommand() { } // This object is a singleton.

        public char Key => 'b';

        public int? Repeat => 0;

        public bool IsEnabled => true;

        public void Execute(SaveGame saveGame)
        {
            BrowseStoreCommand.DoCmdBrowse(saveGame);
        }
    }
}
