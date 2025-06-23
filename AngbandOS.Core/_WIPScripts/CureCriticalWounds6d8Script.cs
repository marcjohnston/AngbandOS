// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class CureCriticalWounds6d8Script : Script, IEatOrQuaffScript
{
    private CureCriticalWounds6d8Script(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns true because the action is always noticed.
    /// </summary>
    /// <returns></returns>
    public IdentifiedResultEnum ExecuteEatOrQuaffScript()
    {
        bool isIdentified = false;

        // Cure critical wounds heals you 6d8 health, and cures blindness, confusion, stun,
        // poison, and bleeding
        if (Game.RestoreHealth(Game.DiceRoll(6, 8)))
        {
            isIdentified = true;
        }
        if (Game.BlindnessTimer.ResetTimer())
        {
            isIdentified = true;
        }
        if (Game.ConfusionTimer.ResetTimer())
        {
            isIdentified = true;
        }
        if (Game.PoisonTimer.ResetTimer())
        {
            isIdentified = true;
        }
        if (Game.StunTimer.ResetTimer())
        {
            isIdentified = true;
        }
        if (Game.RunIdentifiedScript(nameof(BleedingResetTimerScript)))
        {
            isIdentified = true;
        }

        return isIdentified ? IdentifiedResultEnum.True : IdentifiedResultEnum.False;
    }
}