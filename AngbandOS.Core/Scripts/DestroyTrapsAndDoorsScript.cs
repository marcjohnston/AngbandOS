﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class DestroyTrapsAndDoorsScript : Script, IIdentifableAndUsedScript
{
    private DestroyTrapsAndDoorsScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public (bool identified, bool used) ExecuteIdentifableAndUsedScript()
    {
        if (!Game.RunSuccessByChanceScript(nameof(DestroyAdjacentDoorsScript)))
        {
            // If nothing was destroyed, then we do not know what happened.
            return (false, true);
        }
        return (true, true);
    }
}
