// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

/// <summary>
/// Identifies a chosen item and returns false, if the item selection is cancelled; true, otherwise.
/// </summary>
[Serializable]
internal class IdentifyItemCancellableScript : Script, IScript, ICancellableScript, IReadScrollAndUseStaffScript, IUsedScriptItem
{
    private IdentifyItemCancellableScript(Game game) : base(game) { }

    /// <summary>
    /// Identifies a chosen item and returns true, if the item selection is cancelled; false, otherwise.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteCancellableScript()
    {
        if (!Game.SelectItem(out Item? oPtr, "Identify which item? ", true, true, true, null))
        {
            Game.MsgPrint("You have nothing to identify.");
            return false;
        }
        if (oPtr == null)
        {
            return false;
        }
        oPtr.IsFlavorAware = true;
        oPtr.BecomeKnown();
        Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateBonusesFlaggedAction)).Set();
        Game.SingletonRepository.Get<FlaggedAction>(nameof(NoticeCombineAndReorderGroupSetFlaggedAction)).Set();
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

        return true;
    }

    public bool ExecuteUsedScriptItem(Item item)
    {
        return ExecuteCancellableScript();
    }

    public IdentifiedAndUsedResult ExecuteReadScrollAndUseStaffScript()
    {
        bool isUsed = ExecuteCancellableScript();
        return new IdentifiedAndUsedResult(true, isUsed);
    }

    /// <summary>
    /// Executes the successful script and disposes of the result.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        ExecuteCancellableScript();
    }
}
