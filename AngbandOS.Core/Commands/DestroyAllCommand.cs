using Cthangband.Enumerations;
using Cthangband.StoreCommands;
using System;

namespace Cthangband.Commands
{
    /// <summary>
    /// Destroy all worthless items in your pack
    /// </summary>
    [Serializable]
    internal class DestroyAllCommand : ICommand
    {
        public char Key => 'K';

        public int? Repeat => 0;

        public bool IsEnabled => true;

        public void Execute(SaveGame saveGame)
        {
            DestroyAllStoreCommand.DoCmdDestroyAll(saveGame.Player);
        }
    }
}
