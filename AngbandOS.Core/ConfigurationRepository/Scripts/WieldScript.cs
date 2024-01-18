// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class WieldScript : Script
{
    private WieldScript(SaveGame saveGame) : base(saveGame) { }

    public override bool Execute()
    {
        // Only interested in wearable items
        if (!SaveGame.SelectItem(out Item? item, "Wear/Wield which item? ", false, true, true, new WearableItemFilter()))
        {
            SaveGame.MsgPrint("You have nothing you can wear or wield.");
            return false;
        }
        if (item == null)
        {
            return false;
        }

        // Find the inventory slot where the item is to be wielded.
        int slot = item.WieldSlot;

        // Can't replace a cursed item
        Item? wieldingItem = SaveGame.GetInventoryItem(slot);
        if (wieldingItem != null && wieldingItem.IsCursed())
        {
            string cursedItemName = wieldingItem.Description(false, 0);
            SaveGame.MsgPrint($"The {cursedItemName} you are {SaveGame.DescribeWieldLocation(slot)} appears to be cursed.");
            return false;
        }

        // If we know the item to be cursed, confirm its wearing
        if (item.IsCursed() && (item.IsKnown() || item.IdentSense))
        {
            string cursedItemName = item.Description(false, 0);
            string dummy = $"Really use the {cursedItemName} {{cursed}}? ";
            if (!SaveGame.GetCheck(dummy))
            {
                return false;
            }
        }

        // Use some energy
        SaveGame.EnergyUse = 100;

        // Pull one item out of the item stack
        Item wornItem = item.Clone(1);

        // Reduce the count of the item stack accordingly
        item.ItemIncrease(-1);
        item.ItemOptimize();

        // Take off the old item
        Item? wasWieldingItem = SaveGame.GetInventoryItem(slot);
        if (wasWieldingItem != null)
        {
            SaveGame.InvenTakeoff(slot, 255);
        }
        // Put the item into the wield slot
        SaveGame.SetInventoryItem(slot, wornItem);
        // Add the weight of the item
        SaveGame.WeightCarried += wornItem.Weight;

        // Inform us what we did
        BaseInventorySlot inventorySlot = SaveGame.SingletonRepository.InventorySlots.Single(_inventorySlot => _inventorySlot.InventorySlots.Contains(slot));
        string wieldPhrase = inventorySlot.WieldPhrase;
        string itemName = wornItem.Description(true, 3);
        SaveGame.MsgPrint($"{wieldPhrase} {itemName} ({slot.IndexToLabel()}).");
        // Let us know if it's cursed
        if (wornItem.IsCursed())
        {
            SaveGame.MsgPrint("Oops! It feels deathly cold!");
            wornItem.IdentSense = true;
        }
        SaveGame.SingletonRepository.FlaggedActions.Get(nameof(UpdateBonusesFlaggedAction)).Set();
        SaveGame.SingletonRepository.FlaggedActions.Get(nameof(UpdateTorchRadiusFlaggedAction)).Set();
        SaveGame.SingletonRepository.FlaggedActions.Get(nameof(UpdateManaFlaggedAction)).Set();
        SaveGame.SingletonRepository.FlaggedActions.Get(nameof(RedrawEquippyFlaggedAction)).Set();
        return false;
    }
}
