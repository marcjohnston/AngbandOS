// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts
{
    [Serializable]
    internal class InventoryScript : Script
    {
        private InventoryScript(SaveGame saveGame) : base(saveGame) { }

        public override bool Execute()
        {
            // We're not viewing equipment
            SaveGame.ViewingEquipment = false;
            ScreenBuffer savedScreen = SaveGame.Screen.Clone();
            // We want to see everything
            bool inventoryShown = SaveGame.Player.ShowInven(_inventorySlot => !_inventorySlot.IsEquipment, null);
            if (!inventoryShown)
            {
                SaveGame.MsgPrint("You have nothing.");
                return false;
            }
            // Get a new command
            string outVal = $"Inventory: carrying {SaveGame.Player.WeightCarried / 10}.{SaveGame.Player.WeightCarried % 10} pounds ({SaveGame.Player.WeightCarried * 100 / (SaveGame.Player.AbilityScores[Ability.Strength].StrCarryingCapacity * 100 / 2)}% of capacity). Command: ";
            SaveGame.Screen.PrintLine(outVal, 0, 0);
            SaveGame.QueuedCommand = SaveGame.Inkey();
            SaveGame.Screen.Restore(savedScreen);
            // Display details if the player wants
            if (SaveGame.QueuedCommand == '\x1b')
            {
                SaveGame.QueuedCommand = (char)0;
            }
            else
            {
                // If the player selected a command that needs to select an item, it will automatically
                // show the inventory
                SaveGame.ViewingItemList = true;
            }
            return false;
        }
    }
}
