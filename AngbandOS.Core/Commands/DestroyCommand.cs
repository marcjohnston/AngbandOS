using Cthangband.Enumerations;
using Cthangband.StaticData;
using Cthangband.StoreCommands;
using Cthangband.UI;
using System;

namespace Cthangband.Commands
{
    /// <summary>
    /// Destroy a single item
    /// </summary>
    [Serializable]
    internal class DestroyCommand : ICommand
    {
        public char Key => 'k';

        public int? Repeat => 0;

        public bool IsEnabled => true;

        public void Execute(SaveGame saveGame)
        {
            DestroyStoreCommand.DoCmdDestroy(saveGame);
        }
    }
}
