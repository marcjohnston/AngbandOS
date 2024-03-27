// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class MassCarnageScript : Script, IScriptBool, IScript
{
    private MassCarnageScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScriptBool(bool playerCast)
    {
        int msec = Constants.DelayFactorInMilliseconds;
        for (int i = 1; i < Game.MMax; i++)
        {
            Monster mPtr = Game.Monsters[i];
            MonsterRace rPtr = mPtr.Race;
            if (mPtr.Race == null)
            {
                continue;
            }
            if (rPtr.Unique)
            {
                continue;
            }
            if (rPtr.Guardian)
            {
                continue;
            }
            if (mPtr.DistanceFromPlayer > Constants.MaxSight)
            {
                continue;
            }
            Game.DeleteMonsterByIndex(i, true);
            if (playerCast)
            {
                Game.TakeHit(Game.DieRoll(3), "the strain of casting Mass Carnage");
            }
            Game.MainForm.GotoMapLocation(Game.MapY.Value, Game.MapX.Value);
            Game.HandleStuff();
            Game.UpdateScreen();
            Game.Pause(msec);
        }
    }

    /// <summary>
    /// Executes the Bool script with a PlayerCast parameter value of true.
    /// </summary>
    public void ExecuteScript()
    {
        ExecuteScriptBool(true);
    }
}
