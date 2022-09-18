using AngbandOS.Enumerations;
using AngbandOS.StaticData;
using AngbandOS.StoreCommands;
using AngbandOS.UI;
using System;

namespace AngbandOS.Commands
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
