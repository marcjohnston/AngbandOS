// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using System;

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class DetectEvilMonstersScript : Script, IScript, ISuccessByChanceScript, IReadScrollOrUseStaffScript
{
    private DetectEvilMonstersScript(Game game) : base(game) { }

    /// <summary>
    /// Detects evil monsters and returns true, if monsters were revealed; false, otherwise.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteSuccessByChanceScript()
    {
        bool flag = false;
        for (int i = 1; i < Game.MonsterMax; i++)
        {
            Monster mPtr = Game.Monsters[i];
            MonsterRace rPtr = mPtr.Race;
            if (mPtr.Race == null)
            {
                continue;
            }
            int y = mPtr.MapY;
            int x = mPtr.MapX;
            if (!Game.PanelContains(y, x))
            {
                continue;
            }
            if (rPtr.Evil)
            {
                rPtr.Knowledge.Characteristics.Evil = true;
                Game.RepairMonsters = true;
                mPtr.IndividualMonsterFlags |= Constants.MflagMark | Constants.MflagShow;
                mPtr.IsVisible = true;
                Game.MainForm.RefreshMapLocation(y, x);
                flag = true;
            }
        }
        if (flag)
        {
            Game.MsgPrint("You sense the presence of evil creatures!");
        }
        return flag;
    }

    /// <summary>
    /// Executes the successful script and disposes of the result.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        ExecuteSuccessByChanceScript();
    }

    public IdentifiedAndUsedResult ExecuteReadScrollOrUseStaffScript()
    {
        bool isIdentified = ExecuteSuccessByChanceScript();
        return new IdentifiedAndUsedResult(isIdentified, true);
    }
}
