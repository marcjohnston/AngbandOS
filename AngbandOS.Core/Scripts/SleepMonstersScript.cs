// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class SleepMonstersScript : Script, IScript, ISuccessByChanceScript, IIdentifiedAndUsedScript
{
    private SleepMonstersScript(Game game) : base(game) { }

    public bool ExecuteSuccessByChanceScript()
    {
        return Game.ProjectAtAllInLos(Game.SingletonRepository.Get<Projectile>(nameof(OldSleepProjectile)), Game.ExperienceLevel.IntValue);
    }

    /// <summary>
    /// Executes the successful script and disposes of the result.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        ExecuteSuccessByChanceScript();
    }

    public (bool identified, bool used) ExecuteIdentifiedAndUsedScript()
    {
        bool identified = ExecuteSuccessByChanceScript();
        return (identified, true);
    }
}
