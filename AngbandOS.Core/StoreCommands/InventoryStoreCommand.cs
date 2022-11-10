using AngbandOS.Commands;
using AngbandOS.Enumerations;
using System;

namespace AngbandOS.StoreCommands
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
            saveGame.SaveScreen();
            // We want to see everything
            saveGame.ItemFilterAll = true;
            saveGame.Player.Inventory.ShowInven(null);
            saveGame.ItemFilterAll = false;
            // Get a new command
            string outVal =
                $"Inventory: carrying {saveGame.Player.WeightCarried / 10}.{saveGame.Player.WeightCarried % 10} pounds ({saveGame.Player.WeightCarried * 100 / (saveGame.Player.AbilityScores[Ability.Strength].StrCarryingCapacity * 100 / 2)}% of capacity). Command: ";
            saveGame.PrintLine(outVal, 0, 0);
            saveGame.QueuedCommand = saveGame.Inkey();
            saveGame.Load();
            // Display details if the player wants
            if (saveGame.QueuedCommand == '\x1b')
            {
                saveGame.QueuedCommand = (char)0;
                saveGame.ItemDisplayColumn = 50;
            }
            else
            {
                saveGame.ViewingItemList = true;
            }
        }
    }
}
