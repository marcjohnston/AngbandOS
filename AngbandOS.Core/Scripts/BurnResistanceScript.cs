﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class BurnResistanceScript : Script, IScript
{
    private BurnResistanceScript(Game game) : base(game) { }

    /// <summary>
    /// Adds temporary fire, lightning and acid resistance.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        Game.FireResistanceTimer.AddTimer(Game.DieRoll(20) + 20);
        Game.LightningResistanceTimer.AddTimer(Game.DieRoll(20) + 20);
        Game.AcidResistanceTimer.AddTimer(Game.DieRoll(20) + 20);
    }
}