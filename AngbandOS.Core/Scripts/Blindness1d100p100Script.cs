// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class Blindness1d100p100Script : Script, IEatOrQuaffScript
{
    private Blindness1d100p100Script(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns true because the action is always noticed.
    /// </summary>
    /// <returns></returns>
    public IdentifiedResult ExecuteEatOrQuaffScript()
    {
        if (!Game.HasBlindnessResistance)
        {
            bool isIdentified = Game.BlindnessTimer.AddTimer(Game.RandomLessThan(100) + 100);
            return new IdentifiedResult(isIdentified);
        }
        return new IdentifiedResult(false);
    }
}