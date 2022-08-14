using Cthangband.Commands;
using Cthangband.Enumerations;
using Cthangband.UI;
using System;

namespace Cthangband.StoreCommands
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
            saveGame.Gui.Save();
            // We're interested in seeing everything
            saveGame.ItemFilterAll = true;
            saveGame.Player.Inventory.ShowEquip();
            saveGame.ItemFilterAll = false;
            // Get a command
            string outVal =
                $"Equipment: carrying {saveGame.Player.WeightCarried / 10}.{saveGame.Player.WeightCarried % 10} pounds ({saveGame.Player.WeightCarried * 100 / (saveGame.Player.AbilityScores[Ability.Strength].StrCarryingCapacity * 100 / 2)}% of capacity). Command: ";
            saveGame.Gui.PrintLine(outVal, 0, 0);
            saveGame.Gui.QueuedCommand = saveGame.Gui.Inkey();
            saveGame.Gui.Load();
            // Display details if the player wants
            if (saveGame.Gui.QueuedCommand == '\x1b')
            {
                saveGame.Gui.QueuedCommand = (char)0;
                saveGame.ItemDisplayColumn = 50;
            }
            else
            {
                saveGame.ViewingItemList = true;
            }
        }
    }
}
