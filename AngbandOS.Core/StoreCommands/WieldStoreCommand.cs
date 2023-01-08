namespace AngbandOS.StoreCommands
{
    /// <summary>
    /// Wield/wear an item
    /// </summary>
    [Serializable]
    internal class WieldStoreCommand : BaseStoreCommand
    {
        public override char Key => 'w';

        public override string Description => "";

        public override void Execute(StoreCommandEvent storeCommandEvent)
        {
            DoCmdWield(storeCommandEvent.SaveGame);
        }

        public static void DoCmdWield(SaveGame saveGame)
        {
            // Only interested in wearable items
            if (!saveGame.GetItem(out int itemIndex, "Wear/Wield which item? ", false, true, true, new WearableItemFilter()))
            {
                if (itemIndex == -2)
                {
                    saveGame.MsgPrint("You have nothing you can wear or wield.");
                }
                return;
            }
            Item item = itemIndex >= 0 ? saveGame.Player.Inventory[itemIndex] : saveGame.Level.Items[0 - itemIndex]; 

            // Find the inventory slot where the item is to be wielded.
            int slot = item.BaseItemCategory.WieldSlot;


            // Can't replace a cursed item
            if (saveGame.Player.Inventory[slot].IsCursed())
            {
                string cursedItemName = saveGame.Player.Inventory[slot].Description(false, 0);
                saveGame.MsgPrint($"The {cursedItemName} you are {saveGame.Player.DescribeWieldLocation(slot)} appears to be cursed.");
                return;
            }

            // If we know the item to be cursed, confirm its wearing
            if (item.IsCursed() && (item.IsKnown() || item.IdentSense))
            {
                string cursedItemName = item.Description(false, 0);
                string dummy = $"Really use the {cursedItemName} {{cursed}}? ";
                if (!saveGame.GetCheck(dummy))
                {
                    return;
                }
            }

            // Use some energy
            saveGame.EnergyUse = 100;

            // Pull one item out of the item stack
            Item wornItem = item.Clone(1);

            // Reduce the count of the item stack accordingly
            if (itemIndex >= 0)
            {
                saveGame.Player.InvenItemIncrease(itemIndex, -1);
                saveGame.Player.InvenItemOptimize(itemIndex);
            }
            else
            {
                saveGame.Level.FloorItemIncrease(0 - itemIndex, -1);
                saveGame.Level.FloorItemOptimize(0 - itemIndex);
            }
            // Take off the old item
            item = saveGame.Player.Inventory[slot];
            if (item.BaseItemCategory != null)
            {
                saveGame.Player.InvenTakeoff(slot, 255);
            }
            // Put the item into the wield slot
            saveGame.Player.Inventory[slot] = wornItem;
            // Add the weight of the item
            saveGame.Player.WeightCarried += wornItem.Weight;

            // Inform us what we did
            BaseInventorySlot inventorySlot = saveGame.SingletonRepository.InventorySlots.Single(_inventorySlot => _inventorySlot.InventorySlots.Contains(slot));
            string wieldPhrase = inventorySlot.WieldPhrase;
            string itemName = wornItem.Description(true, 3);
            saveGame.MsgPrint($"{wieldPhrase} {itemName} ({slot.IndexToLabel()}).");
            // Let us know if it's cursed
            if (wornItem.IsCursed())
            {
                saveGame.MsgPrint("Oops! It feels deathly cold!");
                wornItem.IdentSense = true;
            }
            saveGame.Player.UpdatesNeeded.Set(UpdateFlags.UpdateBonuses);
            saveGame.Player.UpdatesNeeded.Set(UpdateFlags.UpdateTorchRadius);
            saveGame.Player.UpdatesNeeded.Set(UpdateFlags.UpdateMana);
            saveGame.PrEquippyRedrawAction.Set();
        }
    }
}
