using AngbandOS.StoreCommands;

namespace AngbandOS.Commands
{
    /// <summary>
    /// Show the player what a particular symbol represents
    /// </summary>
    [Serializable]
    internal class QuerySymbolCommand : ICommand
    {
        private QuerySymbolCommand() { } // This object is a singleton.

        public char Key => '/';

        public int? Repeat => 0;

        public bool IsEnabled => true;

        public void Execute(SaveGame saveGame)
        {
            QuerySymbolStoreCommand.DoCmdQuerySymbol(saveGame);
        }
    }
}
