﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class TargetScript : Script, IScript, IRepeatableScript
{
    private TargetScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the target script and returns false.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteRepeatableScript()
    {
        ExecuteScript();
        return false;
    }

    /// <summary>
    /// Executes the target script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        if (Game.TargetSet(Constants.TargetKill))
        {
            Game.MsgPrint(Game.TargetWho > 0 ? "Target Selected." : "Location Targeted.");
        }
        else
        {
            Game.MsgPrint("Target Aborted.");
        }
    }
}