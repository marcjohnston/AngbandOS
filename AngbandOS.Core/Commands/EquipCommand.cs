using AngbandOS.StoreCommands;
using System;

namespace AngbandOS.Commands
{
    /// <summary>
    /// Equip an item
    /// </summary>
    [Serializable]
    internal class EquipCommand : ICommand
    {
        public char Key => 'e';

        public int? Repeat => 0;

        public bool IsEnabled => true;

        public void Execute(SaveGame saveGame)
        {
            EquipStoreCommand.DoCmdEquip(saveGame);
        }
    }
}
