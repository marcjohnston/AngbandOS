// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class DestroyItemScript : Script, IScript, ICastSpellScript, IGameCommandScript, IStoreCommandScript
{
    private DestroyItemScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Returns information about the script, or blank if there is no detailed information.  Returns blank, by default.
    /// </summary>
    public string LearnedDetails => "";

    /// <summary>
    /// Executes the destroy script.  Does not modify any of the store flags.
    /// </summary>
    /// <returns></returns>
    public void ExecuteStoreCommandScript(StoreCommandEvent storeCommandEvent)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Executes the destroy script and returns false.
    /// </summary>
    /// <returns></returns>
    public RepeatableResultEnum ExecuteGameCommandScript()
    {
        ExecuteScript();
        return RepeatableResultEnum.False;
    }

    /// <summary>
    /// Destroys an item in the inventory.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        int count = 1;
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
        if (item.StackCount > 1)
        {
            count = Game.GetQuantity(item.StackCount, true);
            if (count <= 0)
            {
                return;
            }
        }
        int oldNumber = item.StackCount;
        item.StackCount = count;
        string itemName = item.GetFullDescription(true);
        item.StackCount = oldNumber;
        //Only confirm if it's not a worthless item
        if (!force)
        {
            if (!item.Stompable)
            {
                string outVal = $"Really destroy {itemName}? ";
                if (!Game.GetCheck(outVal))
                {
                    return;
                }

                // If it was something we might want to destroy again, ask
                if (item.IsKnown() && item.AskDestroyAll)
                {
                    if (Game.GetCheck($"Always destroy {itemName}?"))
                    {
                        item.Stompable = true;
                    }
                }
            }
        }
        // Destroying something takes a turn
        Game.EnergyUse = 100;

        // Can't destroy an artifact.
        if (item.IsArtifact)
        {
            string feel = "special";
            Game.EnergyUse = 0;
            Game.MsgPrint($"You cannot destroy {itemName}.");
            RoItemPropertySet effectiveItemCharacteristics = item.GetEffectiveItemProperties();
            if (effectiveItemCharacteristics.IsCursed || item.IsBroken)
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

        if (Game.BaseCharacterClass.ItemActions != null)
        {
            // Test each of the item filters.
            foreach (ItemAction itemAction in Game.BaseCharacterClass.ItemActions)
            {
                // Loop through all of the associated item filters.
                foreach (ItemFilter itemFilter in itemAction.ItemFilters)
                {
                    // Check to see if the item filter matches.
                    if (itemFilter.Matches(item))
                    {
                        // Perform the item destroy action.
                        itemAction.ItemDestroyed(item, count);
                    }
                }
            }
        }

        // Tidy up the player's inventory
        item.ModifyStackCount(-count);
        item.ItemDescribe();
        item.ItemOptimize();
        return;
    }
}
