// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Timers;

[Serializable]
internal class HallucinatingTimer : Timer
{
    private HallucinatingTimer(Game game) : base(game) { } // This object is a singleton.

    protected override void EffectStopped()
    {
        Game.MsgPrint("You can see clearly again.");
    }
    protected override void OnRateIncreased(int newRate, int currentRate)
    {
        Game.MsgPrint("Oh, wow! Everything looks so cosmic now!");
    }
    protected override void Noticed()
    {
        Game.RefreshMap.SetChangedFlag(); // TODO: Needs to convert to dependencies in the MapWidget
        Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateMonstersFlaggedAction)).Set();
        base.Noticed();
    }
}
