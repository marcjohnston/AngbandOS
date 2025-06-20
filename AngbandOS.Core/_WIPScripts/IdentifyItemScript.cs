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
internal class IdentifyItemScript : Script, IScript, ICastSpellScript, IReadScrollOrUseStaffScript, IActivateItemScript, IZapRodScript
{
    private IdentifyItemScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    public IdentifiedAndUsedResult ExecuteZapRodScript(Item item, int dir)
    {
        UsedResult usedResult = ExecuteUsedScript();
        return new IdentifiedAndUsedResult(true, usedResult.IsUsed);
    }

    /// <summary>
    /// Identifies a chosen item and returns true, if the item selection is cancelled; false, otherwise.
    /// </summary>
    /// <returns></returns>
    public UsedResult ExecuteUsedScript()
    {
        if (!Game.SelectItem(out Item? oPtr, "Identify which item? ", true, true, true, null))
        {
            Game.MsgPrint("You have nothing to identify.");
            return UsedResult.False;
        }
        if (oPtr == null)
        {
            return UsedResult.False;
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

        return UsedResult.True;
    }

    public UsedResult ExecuteActivateItemScript(Item item)
    {
        return ExecuteUsedScript();
    }

    public IdentifiedAndUsedResult ExecuteReadScrollOrUseStaffScript()
    {
        UsedResult usedResult = ExecuteUsedScript();
        return new IdentifiedAndUsedResult(true, usedResult.IsUsed);
    }

    /// <summary>
    /// Executes the successful script and disposes of the result.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        ExecuteUsedScript();
    }
    public string LearnedDetails => "";
}
