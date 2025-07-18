﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class WieldScript : Script, IScript, ICastSpellScript, IGameCommandScript, IStoreCommandScript
{
    private WieldScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Returns information about the script, or blank if there is no detailed information.  Returns blank, by default.
    /// </summary>
    public string LearnedDetails => "";

    /// <summary>
    /// Executes the wield script.  Does not modify any of the store flags.
    /// </summary>
    /// <returns></returns>
    public void ExecuteStoreCommandScript(StoreCommandEvent storeCommandEvent)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Executes the wield script and returns false.
    /// </summary>
    /// <returns></returns>
    public RepeatableResultEnum ExecuteGameCommandScript()
    {
        ExecuteScript();
        return RepeatableResultEnum.False;
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

        // Check if the selection was cancelled.
        if (item == null)
        {
            return;
        }

        // Check to see if there are any wield slots for this item.
        if (item.WieldSlots.Length == 0)
        {
            Game.MsgPrint("You look around yourself and do not see a way to wield this item.");
            return;
        }

        // Find and empty inventory slot where the item is to be wielded.
        WieldSlot slot;
        int slotIndex = 0;
        do
        {
            // Get this slot position.
            slot = item.WieldSlots[slotIndex];

            // Determine if the slot has room for another item or if we ran out of more slots to check.
            if (slot.Count < slot.InventorySlots.Length || slotIndex + 1 >= item.WieldSlots.Length)
            {
                break;
            }
            slotIndex++;
        } while (true);

        // Determine the inventory item that is open or the position of the item to remove.
        int inventoryItem = slot.InventorySlots[0];

        // Check to see if there is room for the item.
        if (slot.Count < slot.InventorySlots.Length)
        {
            // Find an open item index or the item index to remove.  Each slot has one or more inventory slots.
            int inventorySlot = 0;
            do
            {
                inventoryItem = slot.InventorySlots[inventorySlot];
                if (Game.GetInventoryItem(inventoryItem) == null || inventorySlot >= slot.InventorySlots.Length)
                {
                    break;
                }
                inventorySlot++;
            } while (true);
        }

        // Get the current item.
        Item? wieldingItem = Game.GetInventoryItem(inventoryItem);

        // Can't replace a cursed item
        if (wieldingItem != null)
        {
            if (wieldingItem.EffectiveItemPropertySet.IsCursed)
            {
                string cursedItemName = wieldingItem.GetDescription(false);
                Game.MsgPrint($"The {cursedItemName} you are {slot.DescribeItemLocation(wieldingItem)} appears to be cursed.");
                return;
            }
        }

        // If we know the item to be cursed, confirm its wearing
        if (item.EffectiveItemPropertySet.IsCursed && (item.IsKnown() || item.IdentSense))
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
        Item wornItem = item.TakeFromStack(1);
        item.ItemOptimize();

        // Take off the old item
        if (wieldingItem != null)
        {
            Item? wasWieldingItem = wieldingItem.Takeoff(255);
            if (wasWieldingItem == null)
            {
                Game.MsgPrint("Unable to take off item!");
                return;
            }
        }

        // Put the item into the wield slot
        Game.SetInventoryItem(inventoryItem, wornItem);
        // Add the weight of the item
        Game.WeightCarried += wornItem.Weight;

        // Inform us what we did
        string wieldPhrase = slot.WieldPhrase;
        string itemName = wornItem.GetFullDescription(true);
        Game.MsgPrint($"{wieldPhrase} {itemName} ({slot.Label(wornItem)}).");

        // Let us know if it's cursed
        if (wornItem.EffectiveItemPropertySet.IsCursed)
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
