﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class DropScript : Script, IScript, IRepeatableScript, ISuccessfulScript
{
    private DropScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Executes the drop script, disposes of the successful result and returns false.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteRepeatableScript()
    {
        ExecuteSuccessfulScript();
        return false;
    }

    /// <summary>
    /// Executes the drop script and disposes of the successful result.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        ExecuteSuccessfulScript();
    }

    /// <summary>
    /// Executes the drop script and returns true, if the player dropped an item; false, otherwise.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteSuccessfulScript()
    {
        int amount = 1;
        // Get an item from the inventory/equipment
        if (!SaveGame.SelectItem(out Item? item, "Drop which item? ", true, true, false, null))
        {
            SaveGame.MsgPrint("You have nothing to drop.");
            return false;
        }
        if (item == null)
        {
            return false;
        }
        // Can't drop a cursed item
        if (item.IsInEquipment && item.IsCursed())
        {
            SaveGame.MsgPrint("Hmmm, it seems to be cursed.");
            return false;
        }
        // It's a stack, so find out how many to drop
        if (item.Count > 1)
        {
            amount = SaveGame.GetQuantity(null, item.Count, true);
            if (amount <= 0)
            {
                return false;
            }
        }
        // Dropping things takes half a turn
        SaveGame.EnergyUse = 50;
        // Drop it
        SaveGame.InvenDrop(item, amount);
        SaveGame.SingletonRepository.FlaggedActions.Get(nameof(RedrawEquippyFlaggedAction)).Set();
        return true;
    }
}