namespace AngbandOS.Commands
{
    /// <summary>
    /// Show the player's inventory
    /// </summary>
    [Serializable]
    internal class InventoryCommand : ICommand
    {
        private InventoryCommand(SaveGame saveGame) { } // This object is a singleton.

        public char Key => 'i';

        public int? Repeat => 0;

        public bool IsEnabled => true;

        public void Execute(SaveGame saveGame)
        {
            InventoryStoreCommand.DoCmdInventory(saveGame);
        }
    }
}
