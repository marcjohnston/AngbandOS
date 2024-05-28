// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class RechargeItemCancellableScriptInt : Script, IScript, ICancellableScriptInt
{
    private RechargeItemCancellableScriptInt(Game game) : base(game) { }

    public bool ExecuteCancellableScriptInt(int num)
    {
        if (!Game.SelectItem(out Item? oPtr, "Recharge which item? ", false, true, true, Game.SingletonRepository.Get<ItemFilter>(nameof(CanBeRechargedItemFilter))))
        {
            Game.MsgPrint("You have nothing to recharge.");
            return false;
        }
        if (oPtr == null)
        {
            return false;
        }
        oPtr.Recharge(num);
        return true;
    }

    /// <summary>
    /// Executes the successful script with a value of 2x the players experience and disposes of the result.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        ExecuteCancellableScriptInt(Game.ExperienceLevel.IntValue * 2);
    }
}
