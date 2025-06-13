// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class RechargeRodScript : Script, IScriptItemInt
{
    private RechargeRodScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScriptItemInt(Item item, int num)
    {
        int i, t;
        i = (100 - item.LevelNormallyFound + num) / 5;
        if (i < 1)
        {
            i = 1;
        }
        if (Game.RandomLessThan(i) == 0)
        {
            Game.MsgPrint("The recharge backfires, draining the rod further!");
            if (item.RodRechargeTimeRemaining < 10000)
            {
                item.RodRechargeTimeRemaining = (item.RodRechargeTimeRemaining + 100) * 2;
            }
        }
        else
        {
            t = num * Game.DiceRoll(2, 4);
            if (item.RodRechargeTimeRemaining > t)
            {
                item.RodRechargeTimeRemaining -= t;
            }
            else
            {
                item.RodRechargeTimeRemaining = 0;
            }
        }
        Game.SingletonRepository.Get<FlaggedAction>(nameof(NoticeCombineAndReorderGroupSetFlaggedAction)).Set();
    }
}
