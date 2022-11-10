using AngbandOS.Commands;
using AngbandOS.Core;
using AngbandOS.Core.ItemFilters;
using AngbandOS.Enumerations;
using System;

namespace AngbandOS.StoreCommands
{
    /// <summary>
    /// Wield/wear an item
    /// </summary>
    [Serializable]
    internal class WieldStoreCommand : IStoreCommand
    {
        public char Key => 'w';

        public bool IsEnabled(Store store) => true;

        public string Description => "";

        public bool RequiresRerendering => false;

        public void Execute(SaveGame saveGame, Store store)
        {
            DoCmdWield(saveGame);
        }

        public static void DoCmdWield(SaveGame saveGame)
        {
            string weildPhrase;
            string itemName;
            // Only interested in wearable items
            if (!saveGame.GetItem(out int itemIndex, "Wear/Wield which item? ", false, true, true, new WearableItemFilter()))
            {
                if (itemIndex == -2)
                {
                    saveGame.MsgPrint("You have nothing you can wear or wield.");
                }
                return;
            }
            Item item = itemIndex >= 0 ? saveGame.Player.Inventory[itemIndex] : saveGame.Level.Items[0 - itemIndex]; // TODO: Remove access to Level
            // Find the correct item slot
            int slot = saveGame.Player.Inventory.WieldSlot(item);
            // Can't replace a cursed item
            if (saveGame.Player.Inventory[slot].IsCursed())
            {
                itemName = saveGame.Player.Inventory[slot].Description(false, 0);
                saveGame.MsgPrint($"The {itemName} you are {saveGame.Player.DescribeWieldLocation(slot)} appears to be cursed.");
                return;
            }
            // If we know the item to be cursed, confirm its wearing
            if (item.IsCursed() && (item.IsKnown() || item.IdentSense))
            {
                itemName = item.Description(false, 0);
                string dummy = $"Really use the {itemName} {{cursed}}? ";
                if (!saveGame.GetCheck(dummy))
                {
                    return;
                }
            }
            // Use some energy
            saveGame.EnergyUse = 100;
            // Pull one item out of the item stack
            Item wornItem = new Item(saveGame, item) { Count = 1 };
            // Reduce the count of the item stack accordingly
            if (itemIndex >= 0)
            {
                saveGame.Player.Inventory.InvenItemIncrease(itemIndex, -1);
                saveGame.Player.Inventory.InvenItemOptimize(itemIndex);
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
                saveGame.Player.Inventory.InvenTakeoff(slot, 255);
            }
            // Put the item into the wield slot
            saveGame.Player.Inventory[slot] = wornItem;
            // Add the weight of the item
            saveGame.Player.WeightCarried += wornItem.Weight;
            // Inform us what we did
            if (slot == InventorySlot.MeleeWeapon)
            {
                weildPhrase = "You are wielding";
            }
            else if (slot == InventorySlot.RangedWeapon)
            {
                weildPhrase = "You are shooting with";
            }
            else if (slot == InventorySlot.Lightsource)
            {
                weildPhrase = "Your light source is";
            }
            else if (slot == InventorySlot.Digger)
            {
                weildPhrase = "You are digging with";
            }
            else
            {
                weildPhrase = "You are wearing";
            }
            itemName = wornItem.Description(true, 3);
            saveGame.MsgPrint($"{weildPhrase} {itemName} ({slot.IndexToLabel()}).");
            // Let us know if it's cursed
            if (wornItem.IsCursed())
            {
                saveGame.MsgPrint("Oops! It feels deathly cold!");
                wornItem.IdentSense = true;
            }
            saveGame.Player.UpdatesNeeded.Set(UpdateFlags.UpdateBonuses);
            saveGame.Player.UpdatesNeeded.Set(UpdateFlags.UpdateTorchRadius);
            saveGame.Player.UpdatesNeeded.Set(UpdateFlags.UpdateMana);
            saveGame.Player.RedrawNeeded.Set(RedrawFlag.PrEquippy);
        }
    }
}
