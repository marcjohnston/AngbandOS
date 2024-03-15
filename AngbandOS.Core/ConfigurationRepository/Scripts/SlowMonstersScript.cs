// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class SlowMonstersScript : Script, IScript, ISuccessfulScript
{
    private SlowMonstersScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Fires a slow monster projectile at all monsters in the players' line-of-sight and returns true, if the projectile actually hits a monster; false, otherwise.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteSuccessfulScript()
    {
        return SaveGame.ProjectAtAllInLos(SaveGame.SingletonRepository.Projectiles.Get(nameof(OldSlowProjectile)), SaveGame.ExperienceLevel.Value);
    }

    /// <summary>
    /// Executes the successful script and disposes the result.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        ExecuteSuccessfulScript();
    }
}
