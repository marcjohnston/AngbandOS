// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class IdentifyFullyScript : Script, IScript, ISuccessfulScript
{
    private IdentifyFullyScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Identifies an item completely and returns true, if an item was chosen to be identified; false, of the item selection was cancelled.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteSuccessfulScript()
    {
        if (!SaveGame.SelectItem(out Item? oPtr, "Identify which item? ", true, true, true, null))
        {
            SaveGame.MsgPrint("You have nothing to identify.");
            return false;
        }
        if (oPtr == null)
        {
            return false;
        }
        oPtr.BecomeFlavorAware();
        oPtr.BecomeKnown();
        oPtr.IdentMental = true;
        SaveGame.SingletonRepository.FlaggedActions.Get(nameof(UpdateBonusesFlaggedAction)).Set();
        SaveGame.SingletonRepository.FlaggedActions.Get(nameof(NoticeCombineAndReorderGroupSetFlaggedAction)).Set();
        SaveGame.HandleStuff();
        string oName = oPtr.Description(true, 3);

        SaveGame.MsgPrint($"{oPtr.DescribeLocation()}: {oName} ({oPtr.Label}).");

        // Check to see if the player is carrying the item and it is stompable.
        if (oPtr.IsInInventory && oPtr.Stompable())
        {
            string itemName = oPtr.Description(true, 3);
            SaveGame.MsgPrint($"You destroy {oName}.");
            int amount = oPtr.Count;
            oPtr.ItemIncrease(-amount);
            oPtr.ItemOptimize();
        }

        oPtr.IdentifyFully();
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
