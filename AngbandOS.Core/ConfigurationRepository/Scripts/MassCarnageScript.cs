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
    private MassCarnageScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScriptBool(bool playerCast)
    {
        int msec = Constants.DelayFactorInMilliseconds;
        for (int i = 1; i < SaveGame.MMax; i++)
        {
            Monster mPtr = SaveGame.Monsters[i];
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
            SaveGame.DeleteMonsterByIndex(i, true);
            if (playerCast)
            {
                SaveGame.TakeHit(SaveGame.DieRoll(3), "the strain of casting Mass Carnage");
            }
            SaveGame.MoveCursorRelative(SaveGame.MapY, SaveGame.MapX);
            SaveGame.SingletonRepository.FlaggedActions.Get(nameof(RedrawHealthPointsFlaggedAction)).Set();
            SaveGame.HandleStuff();
            SaveGame.UpdateScreen();
            SaveGame.Pause(msec);
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
