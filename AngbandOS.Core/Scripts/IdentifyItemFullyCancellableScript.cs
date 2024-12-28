// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class IdentifyItemFullyCancellableScript : Script, IScript, ICancellableScript, ICancellableScriptItem
{
    private IdentifyItemFullyCancellableScript(Game game) : base(game) { }

    /// <summary>
    /// Identifies an item completely and returns true, if an item was chosen to be identified; false, of the item selection was cancelled.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteCancellableScript()
    {
        if (!Game.SelectItem(out Item? oPtr, "Identify which item? ", true, true, true, null))
        {
            Game.MsgPrint("You have nothing to identify.");
            return true;
        }
        if (oPtr == null)
        {
            return true;
        }
        oPtr.IsFlavorAware = true;
        oPtr.BecomeKnown();
        oPtr.IdentMental = true;
        Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateBonusesFlaggedAction)).Set();
        Game.SingletonRepository.Get<FlaggedAction>(nameof(NoticeCombineAndReorderGroupSetFlaggedAction)).Set();
        Game.HandleStuff();
        string oName = oPtr.GetFullDescription(true);

        Game.MsgPrint($"{oPtr.DescribeLocation()}: {oName} ({oPtr.Label}).");

        // Check to see if the player is carrying the item and it is stompable.
        if (oPtr.IsInInventory && oPtr.Stompable)
        {
            string itemName = oPtr.GetFullDescription(true);
            Game.MsgPrint($"You destroy {oName}.");
            int amount = oPtr.StackCount;
            oPtr.ModifyStackCount(-amount);
            oPtr.ItemOptimize();
        }

        oPtr.IdentifyFully();
        return false;
    }

    public bool ExecuteCancellableScriptItem(Item item)
    {
        return ExecuteCancellableScript();
    }

    /// <summary>
    /// Executes the cancellable script and disposes of the result.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        ExecuteCancellableScript();
    }
}
