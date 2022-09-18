using AngbandOS.StoreCommands;
using System;

namespace AngbandOS.Commands
{
    /// <summary>
    /// Browse a book
    /// </summary>
    [Serializable]
    internal class BrowseCommand : ICommand
    {
        public char Key => 'b';

        public int? Repeat => 0;

        public bool IsEnabled => true;

        public void Execute(SaveGame saveGame)
        {
            BrowseStoreCommand.DoCmdBrowse(saveGame);
        }
    }
}
