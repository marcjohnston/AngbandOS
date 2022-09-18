using AngbandOS.StoreCommands;
using System;

namespace AngbandOS.Commands
{
    /// <summary>
    /// Wield/wear an item
    /// </summary>
    [Serializable]
    internal class WieldCommand : ICommand
    {
        public char Key => 'w';

        public int? Repeat => 0;

        public bool IsEnabled => true;

        public void Execute(SaveGame saveGame)
        {
            WieldStoreCommand.DoCmdWield(saveGame);
        }
    }
}
