﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class HealingTrueScript : Script, IScript
{
    private HealingTrueScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Restores 2000 points of health and heals stun and bleeding.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        SaveGame.RestoreHealth(2000);
        SaveGame.TimedStun.ResetTimer();
        SaveGame.TimedBleeding.ResetTimer();
    }
}