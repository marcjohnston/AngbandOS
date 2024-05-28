// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class DetectNormalMonstersScript : Script, IScript, ISuccessByChanceScript
{
    private DetectNormalMonstersScript(Game game) : base(game) { }

    /// <summary>
    /// Detects monsters and returns true, if monsters were reveals; false, otherwise.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteSuccessByChanceScript()
    {
        bool flag = false;
        for (int i = 1; i < Game.MMax; i++)
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
            if (!rPtr.Invisible || Game.HasSeeInvisibility || Game.SeeInvisibilityTimer.Value != 0)
            {
                Game.RepairMonsters = true;
                mPtr.IndividualMonsterFlags |= Constants.MflagMark | Constants.MflagShow;
                mPtr.IsVisible = true;
                Game.MainForm.RefreshMapLocation(y, x);
                flag = true;
            }
        }
        if (flag)
        {
            Game.MsgPrint("You sense the presence of monsters!");
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
}
