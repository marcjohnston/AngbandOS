﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Timers;

[Serializable]
internal class AcidResistanceTimer : Timer
{
    private AcidResistanceTimer(Game game) : base(game) { } // This object is a singleton.

    protected override void OnRateIncreased(int newRate, int currentRate)
    {
        Game.MsgPrint("You feel resistant to acid!");
    }
    protected override void EffectStopped()
    {
        Game.MsgPrint("You feel less resistant to acid.");
    }
}
