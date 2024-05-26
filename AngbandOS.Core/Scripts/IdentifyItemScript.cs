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
internal class IdentifyItemScript : Script, IScript, ISuccessfulScript
{
    private IdentifyItemScript(Game game) : base(game) { }

    /// <summary>
    /// Identifies a chosen item and returns false, if the item selection is cancelled; true, otherwise.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteSuccessfulScript()
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
        oPtr.BecomeFlavorAware();
        oPtr.BecomeKnown();
        Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateBonusesFlaggedAction)).Set();
        Game.SingletonRepository.Get<FlaggedAction>(nameof(NoticeCombineAndReorderGroupSetFlaggedAction)).Set();
        string oName = oPtr.GetFullDescription(true);

        Game.MsgPrint($"{oPtr.DescribeLocation()}: {oName} ({oPtr.Label}).");

        // Check to see if the player is carrying the item and it is stompable.
        if (oPtr.IsInInventory && oPtr.Stompable())
        {
            string itemName = oPtr.GetFullDescription(true);
            Game.MsgPrint($"You destroy {oName}.");
            int amount = oPtr.Count;
            oPtr.ItemIncrease(-amount);
            oPtr.ItemOptimize();
        }

        return true;
    }

    /// <summary>
    /// Executes the successful script and disposes of the result.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        ExecuteSuccessfulScript();
    }
}
