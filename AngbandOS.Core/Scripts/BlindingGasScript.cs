﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class BlindingGasScript : Script, IScript
{
    private BlindingGasScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        // Blind the player
        Game.MsgPrint("A black gas surrounds you!");
        if (!Game.HasBlindnessResistance)
        {
            Game.BlindnessTimer.AddTimer(Game.RandomLessThan(50) + 25);
        }
    }
}