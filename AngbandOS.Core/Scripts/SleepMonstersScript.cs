// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class SleepMonstersScript : Script, IScript, ISuccessfulScript
{
    private SleepMonstersScript(SaveGame saveGame) : base(saveGame) { }

    public bool ExecuteSuccessfulScript()
    {
        return SaveGame.ProjectAtAllInLos(SaveGame.SingletonRepository.Projectiles.Get(nameof(OldSleepProjectile)), SaveGame.ExperienceLevel.Value);
    }

    /// <summary>
    /// Executes the successful script and disposes of the result.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        ExecuteSuccessfulScript();
    }
}
