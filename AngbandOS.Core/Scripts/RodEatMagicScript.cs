// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class RodEatMagicScript : Script, IScriptItem
{
    private RodEatMagicScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScriptItem(Item item)
    {
        if (item.RodRechargeTimeRemaining > 0)
        {
            Game.MsgPrint("You can't absorb energy from a discharged rod.");
        }
        else
        {
            Game.Mana.IntValue += 2 * item.LevelNormallyFound;
            item.RodRechargeTimeRemaining = 500;
        }
    }
}
