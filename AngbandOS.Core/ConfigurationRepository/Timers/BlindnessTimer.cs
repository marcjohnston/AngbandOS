// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Timers;

[Serializable]
internal class BlindnessTimer : Timer
{
    private BlindnessTimer(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
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
        SaveGame.SingletonRepository.FlaggedActions.Get(nameof(RemoveLightFlaggedAction)).Set();
        SaveGame.SingletonRepository.FlaggedActions.Get(nameof(RemoveViewFlaggedAction)).Set();
        SaveGame.SingletonRepository.FlaggedActions.Get(nameof(UpdateLightFlaggedAction)).Set();
        SaveGame.SingletonRepository.FlaggedActions.Get(nameof(UpdateViewFlaggedAction)).Set();
        SaveGame.SingletonRepository.FlaggedActions.Get(nameof(UpdateMonstersFlaggedAction)).Set();
        SaveGame.SingletonRepository.FlaggedActions.Get(nameof(RedrawMapFlaggedAction)).Set();
        base.Noticed();
    }
}
