﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class SuperHeroism1D25P25ResetFearAndHeal30Script : Script, INoticeableScript, IScript
{
    private SuperHeroism1D25P25ResetFearAndHeal30Script(Game game) : base(game) { }

    /// <summary>
    /// Restores 30 points of health, removes fear and adds between 25 and 50 turns of super heroism.  Returns true, if any action is noticed; false, otherwise.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteNoticeableScript()
    {
        bool identified = false;

        // Berserk strength removes fear, heals 30 health, and gives you timed super heroism
        if (Game.FearTimer.ResetTimer())
        {
            identified = true;
        }
        if (Game.SuperheroismTimer.AddTimer(Game.DieRoll(25) + 25))
        {
            identified = true;
        }
        if (Game.RestoreHealth(30))
        {
            identified = true;
        }
        return identified;
    }

    /// <summary>
    /// Runs the INoticeableScript and disposes of the result.
    /// </summary>
    public void ExecuteScript()
    {
        ExecuteNoticeableScript();
    }
}
