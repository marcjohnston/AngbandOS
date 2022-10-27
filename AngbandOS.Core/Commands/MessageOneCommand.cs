using AngbandOS.StoreCommands;
using System;

namespace AngbandOS.Commands
{
    /// <summary>
    /// Show the previous message
    /// </summary>
    [Serializable]
    internal class MessageOneCommand : ICommand
    {
        public char Key => 'O';

        public int? Repeat => 0;

        public bool IsEnabled => true;

        public void Execute(SaveGame saveGame)
        {
            MessageOneStoreCommand.DoCmdMessageOne(saveGame);
        }
    }
}
