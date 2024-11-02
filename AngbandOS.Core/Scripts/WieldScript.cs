// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class WieldScript : Script, IScript, IRepeatableScript, IScriptStore
{
    private WieldScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the wield script.  Does not modify any of the store flags.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScriptStore(StoreCommandEvent storeCommandEvent)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Executes the wield script and returns false.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteRepeatableScript()
    {
        ExecuteScript();
        return false;
    }

    /// <summary>
    /// Allow an item to be wielded and/or worn.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        // Only interested in wearable items
        if (!Game.SelectItem(out Item? item, "Wear/Wield which item? ", false, true, true, Game.SingletonRepository.Get<ItemFilter>(nameof(CanBeWornOrWieldedItemFilter))))
        {
            Game.MsgPrint("You have nothing you can wear or wield.");
            return;
        }
        if (item == null)
        {
            return;
        }

        // Find the inventory slot where the item is to be wielded.
        int slot = item.WieldSlot;

        // Can't replace a cursed item
        Item? wieldingItem = Game.GetInventoryItem(slot);
        if (wieldingItem != null && wieldingItem.IsCursed)
        {
            string cursedItemName = wieldingItem.GetDescription(false);
            Game.MsgPrint($"The {cursedItemName} you are {Game.DescribeWieldLocation(slot)} appears to be cursed.");
            return;
        }

        // If we know the item to be cursed, confirm its wearing
        if (item.IsCursed && (item.IsKnown() || item.IdentSense))
        {
            string cursedItemName = item.GetDescription(false);
            string dummy = $"Really use the {cursedItemName} {{cursed}}? ";
            if (!Game.GetCheck(dummy))
            {
                return;
            }
        }

        // Use some energy
        Game.EnergyUse = 100;

        // Pull one item out of the item stack
        Item wornItem = item.Clone(1);

        // Reduce the count of the item stack accordingly
        item.ItemIncrease(-1);
        item.ItemOptimize();

        // Take off the old item
        Item? wasWieldingItem = Game.GetInventoryItem(slot);
        if (wasWieldingItem == null)
        {
            Game.MsgPrint("Unable to take off item!");
            return;
        }

        Game.InventoryTakeoff(wasWieldingItem, 255);
        // Put the item into the wield slot
        Game.SetInventoryItem(slot, wornItem);
        // Add the weight of the item
        Game.WeightCarried += wornItem.Weight;

        // Inform us what we did
        BaseInventorySlot inventorySlot = Game.SingletonRepository.Get<BaseInventorySlot>().Single(_inventorySlot => _inventorySlot.InventorySlots.Contains(slot));
        string wieldPhrase = inventorySlot.WieldPhrase;
        string itemName = wornItem.GetFullDescription(true);
        Game.MsgPrint($"{wieldPhrase} {itemName} ({slot.IndexToLabel()}).");
        // Let us know if it's cursed
        if (wornItem.IsCursed)
        {
            Game.MsgPrint("Oops! It feels deathly cold!");
            wornItem.IdentSense = true;
        }
        Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateBonusesFlaggedAction)).Set();
        Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateTorchRadiusFlaggedAction)).Set();
        Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateManaFlaggedAction)).Set();
        Game.SingletonRepository.Get<FlaggedAction>(nameof(RedrawEquippyFlaggedAction)).Set();
    }
}
