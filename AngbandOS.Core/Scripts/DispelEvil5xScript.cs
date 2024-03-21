// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class DispelEvil5xScript : Script, ISuccessfulScript, IScript, ICancellableScript
{
    private DispelEvil5xScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Executes the successful script and returns true because the player cannot cancel the script.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteCancellableScript()
    {
        ExecuteSuccessfulScript();
        return true;
    }

    /// <summary>
    /// Projects dispel evil at all monsters in the players line-of-sight and return true, if the project actually hits and affects a monster; false, otherwise.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteSuccessfulScript()
    {
        return SaveGame.ProjectAtAllInLos(SaveGame.SingletonRepository.Projectiles.Get(nameof(DispEvilProjectile)), SaveGame.ExperienceLevel.Value * 5);
    }

    /// <summary>
    /// Executes the Int script with a damage value of 4x the players experience.
    /// </summary>
    public void ExecuteScript()
    {
        ExecuteSuccessfulScript();
    }
}
