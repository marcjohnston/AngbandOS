﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class DarknessIdentifableAndUsedScript : Script, IReadScrollOrUseStaffScript
{
    private DarknessIdentifableAndUsedScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public IdentifiedAndUsedResult ExecuteReadScrollOrUseStaffScript()
    {
        if (!Game.HasBlindnessResistance && !Game.HasDarkResistance)
        {
            Game.BlindnessTimer.AddTimer(3 + Game.DieRoll(5));
        }
        bool isIdentified = Game.UnlightArea(10, 3);
        return new IdentifiedAndUsedResult(isIdentified, true);
    }
}

