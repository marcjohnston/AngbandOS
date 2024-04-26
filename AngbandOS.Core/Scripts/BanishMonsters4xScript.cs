// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class BanishMonsters4xScript : Script, IScriptInt, IScript
{
    private BanishMonsters4xScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns a success result.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScriptInt(int dist)
    {
        Game.ProjectAtAllInLos(Game.SingletonRepository.Projectiles.Get(nameof(TeleportAwayAllProjectile)), dist);
    }

    /// <summary>
    /// Executes the Int script with a distance of 4x the players experience.
    /// </summary>
    public void ExecuteScript()
    {
        ExecuteScriptInt(Game.ExperienceLevel.IntValue * 4);
    }
}
