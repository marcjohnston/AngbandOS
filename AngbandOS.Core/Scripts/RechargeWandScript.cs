// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class RechargeWandScript : Script, IScriptItemInt
{
    private RechargeWandScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScriptItemInt(Item item, int num)
    {
        int i, t;
        i = (num + 100 - item.LevelNormallyFound - (10 * item.WandChargesRemaining)) / 15;
        if (i < 1)
        {
            i = 1;
        }
        if (Game.RandomLessThan(i) == 0)
        {
            Game.MsgPrint("There is a bright flash of light.");
            item.ModifyStackCount(-999);
            item.ItemDescribe();
            item.ItemOptimize();
        }
        else
        {
            t = (num / (item.LevelNormallyFound + 2)) + 1;
            if (t > 0)
            {
                item.WandChargesRemaining += 2 + Game.DieRoll(t);
            }
            item.IdentityIsKnown = false;
            item.IdentEmpty = false;
        }
        Game.SingletonRepository.Get<FlaggedAction>(nameof(NoticeCombineAndReorderGroupSetFlaggedAction)).Set();
    }
}
