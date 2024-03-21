// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class DispelEvil4xScript : Script, ISuccessfulScriptInt, IScriptInt, IScript
{
    private DispelEvil4xScript(Game game) : base(game) { }

    /// <summary>
    /// Projects dispel evil at all monsters in the players line-of-sight and return true, if the project actually hits and affects a monster; false, otherwise.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteSuccessfulScriptInt(int dam)
    {
        return Game.ProjectAtAllInLos(Game.SingletonRepository.Projectiles.Get(nameof(DispEvilProjectile)), dam);
    }

    /// <summary>
    /// Executes the successful script and disposes of the result.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScriptInt(int dam)
    {
        ExecuteSuccessfulScriptInt(dam);
    }

    /// <summary>
    /// Executes the Int script with a damage value of 4x the players experience.
    /// </summary>
    public void ExecuteScript()
    {
        ExecuteScriptInt(Game.ExperienceLevel.Value * 4);
    }
}
