﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class ConfuseGasScript : Script, IScript
{
    private ConfuseGasScript(Game game) : base(game) { }

     /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        // Confuse the player
        Game.MsgPrint("A gas of scintillating colors surrounds you!");
        if (!Game.HasConfusionResistance)
        {
            Game.ConfusedTimer.AddTimer(Game.RandomLessThan(20) + 10);
        }
    }
}