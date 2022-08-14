using Cthangband.Commands;
using Cthangband.Enumerations;
using Cthangband.UI;
using System;

namespace Cthangband.StoreCommands
{
    /// <summary>
    /// Show the player's inventory
    /// </summary>
    [Serializable]
    internal class InventoryStoreCommand : IStoreCommand
    {
        public char Key => 'i';

        public string Description => "";

        public bool RequiresRerendering => false;

        public bool IsEnabled(Store store) => true;

        public void Execute(SaveGame saveGame, Store store)
        {
            DoCmdInventory(saveGame);
        }

        public static void DoCmdInventory(SaveGame saveGame)
        {
            // We're not viewing equipment
            saveGame.ViewingEquipment = false;
            Gui.Save();
            // We want to see everything
            saveGame.ItemFilterAll = true;
            saveGame.Player.Inventory.ShowInven();
            saveGame.ItemFilterAll = false;
            // Get a new command
            string outVal =
                $"Inventory: carrying {saveGame.Player.WeightCarried / 10}.{saveGame.Player.WeightCarried % 10} pounds ({saveGame.Player.WeightCarried * 100 / (saveGame.Player.AbilityScores[Ability.Strength].StrCarryingCapacity * 100 / 2)}% of capacity). Command: ";
            Gui.PrintLine(outVal, 0, 0);
            Gui.QueuedCommand = Gui.Inkey();
            Gui.Load();
            // Display details if the player wants
            if (Gui.QueuedCommand == '\x1b')
            {
                Gui.QueuedCommand = (char)0;
                saveGame.ItemDisplayColumn = 50;
            }
            else
            {
                saveGame.ViewingItemList = true;
            }
        }
    }
}
