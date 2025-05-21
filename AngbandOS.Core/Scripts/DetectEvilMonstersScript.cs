// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using System;

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class DetectEvilMonstersScript : Script, IScript, ICastSpellScript, IReadScrollOrUseStaffScript, IEatOrQuaffScript
{
    private DetectEvilMonstersScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Detects evil monsters and returns true, if monsters were revealed; false, otherwise.
    /// </summary>
    /// <returns></returns>
    public IdentifiedResult ExecuteEatOrQuaffScript()
    {
        bool isIdentified = false;
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
                Game.ConsoleView.RefreshMapLocation(y, x);
                isIdentified = true;
            }
        }
        if (isIdentified)
        {
            Game.MsgPrint("You sense the presence of evil creatures!");
        }
        return new IdentifiedResult(isIdentified);
    }

    /// <summary>
    /// Executes the successful script and disposes of the result.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        ExecuteEatOrQuaffScript();
    }

    public IdentifiedAndUsedResult ExecuteReadScrollOrUseStaffScript()
    {
        IdentifiedResult identifiedResult = ExecuteEatOrQuaffScript();
        return new IdentifiedAndUsedResult(identifiedResult, true);
    }
}
