// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class DetectNonlivingScript : Script, IScript, ICastSpellScript
{
    private DetectNonlivingScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Detects monsters that are not-living.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
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
            if (rPtr.Nonliving || rPtr.Undead ||
                rPtr.Cthuloid || rPtr.Demon)
            {
                Game.RepairMonsters = true;
                mPtr.IndividualMonsterFlags |= Constants.MflagMark | Constants.MflagShow;
                mPtr.IsVisible = true;
                Game.ConsoleView.RefreshMapLocation(y, x);
                flag = true;
            }
        }
        if (flag)
        {
            Game.MsgPrint("You sense the presence of unnatural beings!");
        }
    }
    public string LearnedDetails => "";
}
