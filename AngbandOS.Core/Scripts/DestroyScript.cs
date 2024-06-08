// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class DestroyScript : Script, IScript, IRepeatableScript, IScriptStore
{
    private DestroyScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the destroy script.  Does not modify any of the store flags.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScriptStore(StoreCommandEvent storeCommandEvent)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Executes the destroy script and returns false.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteRepeatableScript()
    {
        ExecuteScript();
        return false;
    }

    /// <summary>
    /// Destroys an item in the inventory.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        int amount = 1;
        bool force = Game.CommandArgument > 0;
        // Get an item to destroy
        if (!Game.SelectItem(out Item? item, "Destroy which item? ", false, true, true, null))
        {
            Game.MsgPrint("You have nothing to destroy.");
            return;
        }
        if (item == null)
        {
            return;
        }
        // If we have more than one we might not want to destroy all of them
        if (item.Count > 1)
        {
            amount = Game.GetQuantity(item.Count, true);
            if (amount <= 0)
            {
                return;
            }
        }
        int oldNumber = item.Count;
        item.Count = amount;
        string itemName = item.GetFullDescription(true);
        item.Count = oldNumber;
        //Only confirm if it's not a worthless item
        if (!force)
        {
            if (!item.Stompable())
            {
                string outVal = $"Really destroy {itemName}? ";
                if (!Game.GetCheck(outVal))
                {
                    return;
                }

                // If it was something we might want to destroy again, ask
                if (item.IsKnown() && item.Factory.AskDestroyAll)
                {
                    if (Game.GetCheck($"Always destroy {itemName}?"))
                    {
                        item.Factory.Stompable[0] = true;
                    }
                }
            }
        }
        // Destroying something takes a turn
        Game.EnergyUse = 100;

        // Can't destroy an artifact artifact
        if (item.IsArtifact)
        {
            string feel = "special";
            Game.EnergyUse = 0;
            Game.MsgPrint($"You cannot destroy {itemName}.");
            if (item.IsCursed || item.IsBroken)
            {
                feel = "terrible";
            }
            item.Inscription = feel;
            item.IdentSense = true;
            Game.SingletonRepository.Get<FlaggedAction>(nameof(NoticeCombineFlaggedAction)).Set();
            Game.SingletonRepository.Get<FlaggedAction>(nameof(RedrawEquippyFlaggedAction)).Set();
            return;
        }
        Game.MsgPrint($"You destroy {itemName}.");

        Game.BaseCharacterClass.ItemDestroyed(item, amount);

        // Tidy up the player's inventory
        item.ItemIncrease(-amount);
        item.ItemDescribe();
        item.ItemOptimize();
        return;
    }
}
