﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.TimedActions;

[Serializable]
internal class StoneskinTimedAction : TimedAction
{
    public StoneskinTimedAction(SaveGame saveGame) : base(saveGame) { }
    protected override void EffectStopped()
    {
        SaveGame.MsgPrint("Your skin returns to normal.");
    }
    protected override void EffectIncreased(int newRate, int currentRate)
    {
        SaveGame.MsgPrint("Your skin turns to stone.");
    }
    protected override void Noticed()
    {
        SaveGame.SingletonRepository.FlaggedActions.Get<UpdateBonusesFlaggedAction>().Set();
        base.Noticed();
    }
}