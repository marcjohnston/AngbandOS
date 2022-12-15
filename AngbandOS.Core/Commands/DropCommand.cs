using AngbandOS.Enumerations;

namespace AngbandOS.Commands
{
    /// <summary>
    /// Drop an item
    /// </summary>
    [Serializable]
    internal class DropCommand : ICommand
    {
        public char Key => 'd';

        public int? Repeat => 0;

        public bool IsEnabled => true;

        public void Execute(SaveGame saveGame)
        {
            int amount = 1;
            // Get an item from the inventory/equipment
            if (!saveGame.GetItem(out int itemIndex, "Drop which item? ", true, true, false, null))
            {
                if (itemIndex == -2)
                {
                    saveGame.MsgPrint("You have nothing to drop.");
                }
                return;
            }
            Item item = itemIndex >= 0 ? saveGame.Player.Inventory[itemIndex] : saveGame.Level.Items[0 - itemIndex];
            // Can't drop a cursed item
            if (itemIndex >= InventorySlot.MeleeWeapon && item.IsCursed())
            {
                saveGame.MsgPrint("Hmmm, it seems to be cursed.");
                return;
            }
            // It's a stack, so find out how many to drop
            if (item.Count > 1)
            {
                amount = saveGame.GetQuantity(null, item.Count, true);
                if (amount <= 0)
                {
                    return;
                }
            }
            // Dropping things takes half a turn
            saveGame.EnergyUse = 50;
            // Drop it
            saveGame.Player.Inventory.InvenDrop(itemIndex, amount);
            saveGame.Player.RedrawNeeded.Set(RedrawFlag.PrEquippy);
        }
    }
}