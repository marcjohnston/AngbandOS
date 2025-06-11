// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Timers;

[Serializable]
internal class SuperheroismTimer : Timer
{
    private SuperheroismTimer(Game game) : base(game) { } // This object is a singleton.
    protected override void EffectStopped()
    {
        Game.MsgPrint("You feel less Berserk.");
    }
    protected override void OnRateIncreased(int newRate, int currentRate)
    {
        Game.MsgPrint("You feel like a killing machine!");
    }
    protected override void Noticed()
    {
        Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateBonusesFlaggedAction)).Set();
        Game.SingletonRepository.Get<FlaggedAction>(nameof(UpdateHealthFlaggedAction)).Set();
        base.Noticed();
    }
}
