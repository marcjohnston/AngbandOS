// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class MassCarnageScript : Script, IScriptBool, IScript, ICastSpellScript, IActivateItemScript
{
    private MassCarnageScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScriptBool(bool playerCast)
    {
        int msec = Constants.DelayFactorInMilliseconds;
        for (int i = 1; i < Game.MonsterMax; i++)
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
            Game.ConsoleView.MoveCursorTo(Game.MapY.IntValue, Game.MapX.IntValue);
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

    public UsedResult ExecuteActivateItemScript(Item item)
    {
        ExecuteScriptBool(true);
        return new UsedResult(true);
    }
}
