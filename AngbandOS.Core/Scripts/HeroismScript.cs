﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class HeroismScript : Script, IScript
{
    private HeroismScript(Game game) : base(game) { }

    /// <summary>
    /// Adds between 25 and 50 turns of heroism, restores 10 points of health and heals fear.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        Game.HeroismTimer.AddTimer(Game.DieRoll(25) + 25);
        Game.RestoreHealth(10);
        Game.FearTimer.ResetTimer();
    }
}