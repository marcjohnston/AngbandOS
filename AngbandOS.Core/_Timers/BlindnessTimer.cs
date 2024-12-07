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
    private BlindnessTimer(Game game) : base(game) { } // This object is a singleton.
    protected override void EffectStopped()
    {
        Game.MsgPrint("You can see again.");
    }
    protected override void OnRateIncreased(int newRate, int currentRate)
    {
        Game.MsgPrint("You are blind!");
    }
    protected override void Noticed()
    {
        Game.SingletonRepository.Get<FlaggedAction>(nameof(RemoveLightFlaggedAction)).Set();
        Game.SingletonRepository.Get<FlaggedAction>(nameof(RemoveViewFlaggedAction)).Set();
        Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateLightFlaggedAction)).Set();
        Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateViewFlaggedAction)).Set();
        Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateMonstersFlaggedAction)).Set();
        Game.RefreshMap.SetChangedFlag(); // TODO: Needs to convert to dependencies in the MapWidget
        base.Noticed();
    }
}
