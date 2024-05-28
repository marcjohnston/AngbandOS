// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class SlowMonstersScript : Script, IScript, ISuccessByChanceScript
{
    private SlowMonstersScript(Game game) : base(game) { }

    /// <summary>
    /// Fires a slow monster projectile at all monsters in the players' line-of-sight and returns true, if the projectile actually hits a monster; false, otherwise.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteSuccessByChanceScript()
    {
        return Game.ProjectAtAllInLos(Game.SingletonRepository.Get<Projectile>(nameof(OldSlowProjectile)), Game.ExperienceLevel.IntValue);
    }

    /// <summary>
    /// Executes the successful script and disposes the result.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        ExecuteSuccessByChanceScript();
    }
}
