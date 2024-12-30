// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class CarnageScript : Script, IScript
{
    private CarnageScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        for (int i = 1; i < Game.MonsterMax; i++)
        {
            Monster mPtr = Game.Monsters[i];
            if (mPtr.Race == null)
            {
                continue;
            }
            if (mPtr.DistanceFromPlayer <= Constants.MaxSight)
            {
                Game.DeleteMonsterByIndex(i, true);
            }
        }
    }
}
