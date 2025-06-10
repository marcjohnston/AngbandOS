// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class HolinessScript : Script, IReadScrollOrUseStaffScript
{
    private HolinessScript(Game game) : base(game) { }

    /// <summary>
    /// Projects dispel evil at all monsters in the players line-of-sight and return true, if the project actually hits and affects a monster; false, otherwise.
    /// </summary>
    /// <returns></returns>
    public IdentifiedAndUsedResult ExecuteReadScrollOrUseStaffScript()
    {
        bool isIdentified = false;
        if (Game.RunIdentifiedScript(nameof(DispelEvilAtLos120ProjectileScript)))
        {
            isIdentified = true;
        }
        int k = 3 * Game.ExperienceLevel.IntValue;
        if (Game.ProtectionFromEvilTimer.AddTimer(Game.DieRoll(25) + k))
        {
            isIdentified = true;
        }
        if (Game.PoisonTimer.ResetTimer())
        {
            isIdentified = true;
        }
        if (Game.FearTimer.ResetTimer())
        {
            isIdentified = true;
        }
        if (Game.RestoreHealth(50))
        {
            isIdentified = true;
        }
        if (Game.StunTimer.ResetTimer())
        {
            isIdentified = true;
        }
        if (Game.BleedingTimer.ResetTimer())
        {
            isIdentified = true;
        }
        return new IdentifiedAndUsedResult(isIdentified, true);
    }
}
