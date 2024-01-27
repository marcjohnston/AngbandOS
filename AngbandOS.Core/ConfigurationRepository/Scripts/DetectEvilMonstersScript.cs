// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class DetectEvilMonstersScript : Script, IScript, ISuccessfulScript
{
    private DetectEvilMonstersScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Detects evil monsters and returns true, if monsters were revealed; false, otherwise.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteSuccessfulScript()
    {
        bool flag = false;
        for (int i = 1; i < SaveGame.MMax; i++)
        {
            Monster mPtr = SaveGame.Monsters[i];
            MonsterRace rPtr = mPtr.Race;
            if (mPtr.Race == null)
            {
                continue;
            }
            int y = mPtr.MapY;
            int x = mPtr.MapX;
            if (!SaveGame.PanelContains(y, x))
            {
                continue;
            }
            if (rPtr.Evil)
            {
                rPtr.Knowledge.Characteristics.Evil = true;
                SaveGame.RepairMonsters = true;
                mPtr.IndividualMonsterFlags |= Constants.MflagMark | Constants.MflagShow;
                mPtr.IsVisible = true;
                SaveGame.RedrawSingleLocation(y, x);
                flag = true;
            }
        }
        if (flag)
        {
            SaveGame.MsgPrint("You sense the presence of evil creatures!");
        }
        return flag;
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
