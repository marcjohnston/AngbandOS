// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class RechargeItemScript : Script, IScript, ICastSpellScript, IUsedScriptInt, IActivateItemScript
{
    private RechargeItemScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    public UsedResult ExecuteUsedScriptInt(int num)
    {
        if (!Game.SelectItem(out Item? oPtr, "Recharge which item? ", false, true, true, Game.SingletonRepository.Get<ItemFilter>(nameof(CanBeRechargedItemFilter))))
        {
            Game.MsgPrint("You have nothing to recharge.");
            return new UsedResult(false);
        }
        if (oPtr == null)
        {
            return new UsedResult(false);
        }
        // Make sure the item is rechargable
        if (oPtr.RechargeScript == null)
        {
            Game.MsgPrint("That is not a rod!");
            return new UsedResult(false);
        }
        oPtr.RechargeScript.ExecuteScriptItemInt(oPtr, num);
        return new UsedResult(true);
    }

    public UsedResult ExecuteActivateItemScript(Item item)
    {
        return ExecuteUsedScriptInt(60);
    }

    /// <summary>
    /// Executes the successful script with a value of 2x the players experience and disposes of the result.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        ExecuteUsedScriptInt(Game.ExperienceLevel.IntValue * 2);
    }
    public string LearnedDetails => "";
}
