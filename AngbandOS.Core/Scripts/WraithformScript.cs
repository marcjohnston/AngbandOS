﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class WraithformScript : Script, IScript
{
    private WraithformScript(Game game) : base(game) { }

    /// <summary>
    /// Adds between 1/2 the player experience to 1x the player experience of etherealness.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        Game.EtherealnessTimer.AddTimer(Game.DieRoll(Game.ExperienceLevel.Value / 2) + (Game.ExperienceLevel.Value / 2));

    }
}