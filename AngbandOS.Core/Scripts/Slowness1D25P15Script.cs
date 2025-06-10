// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using System;
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class Slowness1D25P15Script : Script, IEatOrQuaffScript
{
    private Slowness1D25P15Script(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns true because the action is always noticed.
    /// </summary>
    /// <returns></returns>
    public IdentifiedResult ExecuteEatOrQuaffScript()
    {
        // Slowness slows you down.
        bool isIdentified = Game.SlowTimer.AddTimer(Game.DieRoll(25) + 15);
        return new IdentifiedResult(isIdentified);
    }
}
