﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class CureSeriousWounds4d8Script : Script, INoticeableScript
{
    private CureSeriousWounds4d8Script(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns true because the action is always noticed.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteNoticeableScript()
    {
        bool identified = false;

        // Cure serious wounds heals you 4d8 health, cures blindness and confusion, and
        // reduces bleeding
        if (Game.RestoreHealth(Game.DiceRoll(4, 8)))
        {
            identified = true;
        }
        if (Game.BlindnessTimer.ResetTimer())
        {
            identified = true;
        }
        if (Game.ConfusedTimer.ResetTimer())
        {
            identified = true;
        }
        if (Game.BleedingTimer.SetTimer((Game.BleedingTimer.Value / 2) - 50))
        {
            identified = true;
        }
        return identified;
    }
}