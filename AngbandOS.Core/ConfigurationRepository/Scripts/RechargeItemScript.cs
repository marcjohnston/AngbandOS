// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class RechargeItemScript : Script, IScript, ISuccessfulScriptInt
{
    private RechargeItemScript(SaveGame saveGame) : base(saveGame) { }

    public bool ExecuteSuccessfulScriptInt(int num)
    {
        int i, t;
        if (!SaveGame.SelectItem(out Item? oPtr, "Recharge which item? ", false, true, true, SaveGame.SingletonRepository.ItemFilters.Get(nameof(CanBeRechargedItemFilter))))
        {
            SaveGame.MsgPrint("You have nothing to recharge.");
            return false;
        }
        if (oPtr == null)
        {
            return false;
        }
        int lev = oPtr.Factory.Level;
        if (oPtr.Category == ItemTypeEnum.Rod)
        {
            i = (100 - lev + num) / 5;
            if (i < 1)
            {
                i = 1;
            }
            if (SaveGame.RandomLessThan(i) == 0)
            {
                SaveGame.MsgPrint("The recharge backfires, draining the rod further!");
                if (oPtr.TypeSpecificValue < 10000)
                {
                    oPtr.TypeSpecificValue = (oPtr.TypeSpecificValue + 100) * 2;
                }
            }
            else
            {
                t = num * SaveGame.DiceRoll(2, 4);
                if (oPtr.TypeSpecificValue > t)
                {
                    oPtr.TypeSpecificValue -= t;
                }
                else
                {
                    oPtr.TypeSpecificValue = 0;
                }
            }
        }
        else
        {
            i = (num + 100 - lev - (10 * oPtr.TypeSpecificValue)) / 15;
            if (i < 1)
            {
                i = 1;
            }
            if (SaveGame.RandomLessThan(i) == 0)
            {
                SaveGame.MsgPrint("There is a bright flash of light.");
                oPtr.ItemIncrease(-999);
                oPtr.ItemDescribe();
                oPtr.ItemOptimize();
            }
            else
            {
                t = (num / (lev + 2)) + 1;
                if (t > 0)
                {
                    oPtr.TypeSpecificValue += 2 + SaveGame.DieRoll(t);
                }
                oPtr.IdentKnown = false;
                oPtr.IdentEmpty = false;
            }
        }
        SaveGame.SingletonRepository.FlaggedActions.Get(nameof(NoticeCombineAndReorderGroupSetFlaggedAction)).Set();
        return true;
    }

    /// <summary>
    /// Executes the successful script with a value of 2x the players experience and disposes of the result.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        ExecuteSuccessfulScriptInt(SaveGame.ExperienceLevel * 2);
    }
}
