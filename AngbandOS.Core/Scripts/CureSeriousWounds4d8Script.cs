// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class CureSeriousWounds4d8Script : Script, IEatOrQuaffScript
{
    private CureSeriousWounds4d8Script(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns true because the action is always noticed.
    /// </summary>
    /// <returns></returns>
    public IdentifiedResult ExecuteEatOrQuaffScript()
    {
        bool isIdentified = false;

        // Cure serious wounds heals you 4d8 health, cures blindness and confusion, and
        // reduces bleeding
        if (Game.RestoreHealth(Game.DiceRoll(4, 8)))
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
        if (Game.BleedingTimer.SetTimer((Game.BleedingTimer.Value / 2) - 50))
        {
            isIdentified = true;
        }
        return new IdentifiedResult(isIdentified);
    }
}