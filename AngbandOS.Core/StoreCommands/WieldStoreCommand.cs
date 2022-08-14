using Cthangband.Commands;
using Cthangband.Enumerations;
using Cthangband.StaticData;
using Cthangband.UI;
using System;

namespace Cthangband.StoreCommands
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

        public void Execute(Player player, Store store)
        {
            DoCmdWield(store.SaveGame); // TODO: Store.SaveGame was made public just for this
        }

        public static void DoCmdWield(SaveGame saveGame)
        {
            string weildPhrase;
            string itemName;
            // Only interested in wearable items
            SaveGame.Instance.ItemFilter = SaveGame.Instance.ItemFilterWearable;
            if (!SaveGame.Instance.GetItem(out int itemIndex, "Wear/Wield which item? ", false, true, true))
            {
                if (itemIndex == -2)
                {
                    SaveGame.Instance.MsgPrint("You have nothing you can wear or wield.");
                }
                return;
            }
            Item item = itemIndex >= 0 ? saveGame.Player.Inventory[itemIndex] : SaveGame.Instance.Level.Items[0 - itemIndex]; // TODO: Remove access to Level
            // Find the correct item slot
            int slot = saveGame.Player.Inventory.WieldSlot(item);
            // Can't replace a cursed item
            if (saveGame.Player.Inventory[slot].IsCursed())
            {
                itemName = saveGame.Player.Inventory[slot].Description(false, 0);
                SaveGame.Instance.MsgPrint($"The {itemName} you are {saveGame.Player.DescribeWieldLocation(slot)} appears to be cursed.");
                return;
            }
            // If we know the item to be cursed, confirm its wearing
            if (item.IsCursed() && (item.IsKnown() || item.IdentifyFlags.IsSet(Constants.IdentSense)))
            {
                itemName = item.Description(false, 0);
                string dummy = $"Really use the {itemName} {{cursed}}? ";
                if (!Gui.GetCheck(dummy))
                {
                    return;
                }
            }
            // Use some energy
            SaveGame.Instance.EnergyUse = 100;
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
                SaveGame.Instance.Level.FloorItemIncrease(0 - itemIndex, -1);
                SaveGame.Instance.Level.FloorItemOptimize(0 - itemIndex);
            }
            // Take off the old item
            item = saveGame.Player.Inventory[slot];
            if (item.ItemType != null)
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
            SaveGame.Instance.MsgPrint($"{weildPhrase} {itemName} ({slot.IndexToLabel()}).");
            // Let us know if it's cursed
            if (wornItem.IsCursed())
            {
                SaveGame.Instance.MsgPrint("Oops! It feels deathly cold!");
                wornItem.IdentifyFlags.Set(Constants.IdentSense);
            }
            saveGame.Player.UpdatesNeeded.Set(UpdateFlags.UpdateBonuses);
            saveGame.Player.UpdatesNeeded.Set(UpdateFlags.UpdateTorchRadius);
            saveGame.Player.UpdatesNeeded.Set(UpdateFlags.UpdateMana);
            saveGame.Player.RedrawNeeded.Set(RedrawFlag.PrEquippy);
        }
    }
}
