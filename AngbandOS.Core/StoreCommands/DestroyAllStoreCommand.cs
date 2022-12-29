using AngbandOS.Commands;
using AngbandOS.Enumerations;

namespace AngbandOS.StoreCommands
{
    /// <summary>
    /// Destroy all worthless items in your pack
    /// </summary>
    [Serializable]
    internal class DestroyAllStoreCommand : IStoreCommand
    {
        public char Key => 'K';

        public bool IsEnabled(Store store) => true;


        public string Description => "";

        public bool RequiresRerendering => false;

        public void Execute(SaveGame saveGame, Store store)
        {
            DoCmdDestroyAll(saveGame);
        }

        public static void DoCmdDestroyAll(SaveGame saveGame)
        {
            int count = 0;
            // Look for worthless items
            for (int i = InventorySlot.PackCount - 1; i >= 0; i--)
            {
                Item item = saveGame.Player.Inventory[i];
                if (item.BaseItemCategory == null)
                {
                    continue;
                }
                // Only destroy if it's stompable (i.e. worthless or marked as unwanted)
                if (!item.Stompable())
                {
                    continue;
                }
                string itemName = item.Description(true, 3);
                saveGame.MsgPrint($"You destroy {itemName}.");
                count++;
                int amount = item.Count;
                saveGame.Player.Inventory.InvenItemIncrease(i, -amount);
                saveGame.Player.Inventory.InvenItemOptimize(i);
            }
            if (count == 0)
            {
                saveGame.MsgPrint("You are carrying nothing worth destroying.");
                saveGame.EnergyUse = 0;
            }
            else
            {
                // If we destroyed at least one thing, take a turn
                saveGame.EnergyUse = 100;
            }

        }
    }
}
