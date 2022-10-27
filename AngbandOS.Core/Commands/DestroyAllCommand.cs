using AngbandOS.Enumerations;
using AngbandOS.StoreCommands;
using System;

namespace AngbandOS.Commands
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
            DestroyAllStoreCommand.DoCmdDestroyAll(saveGame);
        }
    }
}
