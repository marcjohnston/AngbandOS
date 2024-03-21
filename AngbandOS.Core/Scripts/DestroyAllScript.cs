// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class DestroyAllScript : Script, IScript, IRepeatableScript, IStoreScript
{
    private DestroyAllScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Executes the destroy all script.  Does not modify any of the store flags.
    /// </summary>
    /// <returns></returns>
    public void ExecuteStoreScript(StoreCommandEvent storeCommandEvent)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Executes the destroy all script and returns false.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteRepeatableScript()
    {
        ExecuteScript();
        return false;
    }

    /// <summary>
    /// Destroy all items in the inventory that are considered stompable.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        int count = 0;
        // Look for worthless items
        for (int i = InventorySlot.PackCount - 1; i >= 0; i--)
        {
            Item? item = SaveGame.GetInventoryItem(i);
            if (item == null)
            {
                continue;
            }
            // Only destroy if it's stompable (i.e. worthless or marked as unwanted)
            if (!item.Stompable())
            {
                continue;
            }
            string itemName = item.Description(true, 3);
            SaveGame.MsgPrint($"You destroy {itemName}.");
            count++;
            int amount = item.Count;
            SaveGame.InvenItemIncrease(i, -amount);
            SaveGame.InvenItemOptimize(i);
        }
        if (count == 0)
        {
            SaveGame.MsgPrint("You are carrying nothing worth destroying.");
            SaveGame.EnergyUse = 0;
        }
        else
        {
            // If we destroyed at least one thing, take a turn
            SaveGame.EnergyUse = 100;
        }
    }
}
