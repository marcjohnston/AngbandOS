﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class ProtectionFromEvilIdentifableAndUsedScript : Script, IIdentifableAndUsedScript
{
    private ProtectionFromEvilIdentifableAndUsedScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public (bool identified, bool used) ExecuteIdentifableAndUsedScript()
    {
        int i = 3 * Game.ExperienceLevel.IntValue;
        if (!Game.ProtectionFromEvilTimer.AddTimer(Game.DieRoll(25) + i))
        {
            return (false, true);
        }
        return (true, true);
    }
}

