﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.TimedActions;

[Serializable]
internal class BlindnessTimedAction : TimedAction
{
    public BlindnessTimedAction(SaveGame saveGame) : base(saveGame) { }
    protected override void EffectStopped()
    {
        SaveGame.MsgPrint("You can see again.");
    }
    protected override void EffectIncreased(int newRate, int currentRate)
    {
        SaveGame.MsgPrint("You are blind!");
    }
    protected override void Noticed()
    {
        SaveGame.SingletonRepository.FlaggedActions.Get<RemoveLightFlaggedAction>().Set();
        SaveGame.SingletonRepository.FlaggedActions.Get<RemoveViewFlaggedAction>().Set();
        SaveGame.SingletonRepository.FlaggedActions.Get<UpdateLightFlaggedAction>().Set();
        SaveGame.SingletonRepository.FlaggedActions.Get<UpdateViewFlaggedAction>().Set();
        SaveGame.SingletonRepository.FlaggedActions.Get<UpdateMonstersFlaggedAction>().Set();
        SaveGame.SingletonRepository.FlaggedActions.Get<RedrawMapFlaggedAction>().Set();
        SaveGame.SingletonRepository.FlaggedActions.Get<RedrawBlindFlaggedAction>().Set();
        base.Noticed();
    }
}