// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class HolinessScript : Script, IIdentifiedAndUsedScript
{
    private HolinessScript(Game game) : base(game) { }

    /// <summary>
    /// Projects dispel evil at all monsters in the players line-of-sight and return true, if the project actually hits and affects a monster; false, otherwise.
    /// </summary>
    /// <returns></returns>
    public (bool identified, bool used) ExecuteIdentifiedAndUsedScript()
    {
        bool identified = false;
        if (Game.ProjectAtAllInLos(Game.SingletonRepository.Get<Projectile>(nameof(DispelEvilProjectile)), 120))
        {
            identified = true;
        }
        int k = 3 * Game.ExperienceLevel.IntValue;
        if (Game.ProtectionFromEvilTimer.AddTimer(Game.DieRoll(25) + k))
        {
            identified = true;
        }
        if (Game.PoisonTimer.ResetTimer())
        {
            identified = true;
        }
        if (Game.FearTimer.ResetTimer())
        {
            identified = true;
        }
        if (Game.RestoreHealth(50))
        {
            identified = true;
        }
        if (Game.StunTimer.ResetTimer())
        {
            identified = true;
        }
        if (Game.BleedingTimer.ResetTimer())
        {
            identified = true;
        }
        return (identified, true);
    }
}
