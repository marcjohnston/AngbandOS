using AngbandOS.Commands;
using AngbandOS.Core.ItemFilters;
using AngbandOS.Enumerations;
using System;

namespace AngbandOS.StoreCommands
{
    /// <summary>
    /// Equip an item
    /// </summary>
    [Serializable]
    internal class EquipStoreCommand : IStoreCommand
    {
        public char Key => 'e';

        public bool IsEnabled(Store store) => true;

        public string Description => "";

        public bool RequiresRerendering => false;

        public void Execute(SaveGame saveGame, Store store)
        {
            DoCmdEquip(saveGame);
        }

        public static void DoCmdEquip(SaveGame saveGame)
        {
            // We're viewing equipment
            saveGame.ViewingEquipment = true;
            saveGame.SaveScreen();
            // We're interested in seeing everything
            saveGame.Player.Inventory.ShowEquip(null);
            // Get a command
            string outVal = $"Equipment: carrying {saveGame.Player.WeightCarried / 10}.{saveGame.Player.WeightCarried % 10} pounds ({saveGame.Player.WeightCarried * 100 / (saveGame.Player.AbilityScores[Ability.Strength].StrCarryingCapacity * 100 / 2)}% of capacity). Command: ";
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
