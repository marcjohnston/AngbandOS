﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Timers;

[Serializable]
internal class PoisonedTimer : Timer
{
    private PoisonedTimer(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    protected override void EffectStopped()
    {
        SaveGame.MsgPrint("You are no longer poisoned.");
    }
    protected override void EffectIncreased(int newRate, int currentRate)
    {
        SaveGame.MsgPrint("You are poisoned!");
    }
    public override void ProcessWorld()
    {
        if (Value != 0)
        {
            int adjust = SaveGame.AbilityScores[Ability.Constitution].ConRecoverySpeed + 1;
            AddTimer(-adjust);
        }
    }   
}