// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class SpecialHealingScript : Script, IEatOrQuaffScript
{
    private SpecialHealingScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns true because the action is always noticed.
    /// </summary>
    /// <returns></returns>
    public IdentifiedResult ExecuteEatOrQuaffScript()
    {
        bool isIdentified = false;

        // *Healing* heals you 1200 health, and cures blindness, confusion, stun, poison,
        // and bleeding
        if (Game.RestoreHealth(1200))
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
        if (Game.BleedingTimer.ResetTimer())
        {
            isIdentified = true;
        }

        return new IdentifiedResult(isIdentified);
    }
}