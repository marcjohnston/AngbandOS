using AngbandOS.StoreCommands;

namespace AngbandOS.Commands
{
    /// <summary>
    /// Equip an item
    /// </summary>
    [Serializable]
    internal class EquipCommand : ICommand
    {
        private EquipCommand(SaveGame saveGame) { } // This object is a singleton.

        public char Key => 'e';

        public int? Repeat => 0;

        public bool IsEnabled => true;

        public void Execute(SaveGame saveGame)
        {
            EquipStoreCommand.DoCmdEquip(saveGame);
        }
    }
}
