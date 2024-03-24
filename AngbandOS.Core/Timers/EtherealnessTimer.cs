// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Timers;

[Serializable]
internal class EtherealnessTimer : Timer
{
    private EtherealnessTimer(Game game) : base(game) { } // This object is a singleton.
    protected override void EffectStopped()
    {
        Game.MsgPrint("You feel opaque.");
    }
    protected override void EffectIncreased(int newRate, int currentRate)
    {
        Game.MsgPrint("You leave the physical world and turn into a wraith-being!");
    }
    protected override void Noticed()
    {
        Game.Map.SetChangedFlag(); // TODO: Needs to convert to dependencies in the MapWidget
        Game.SingletonRepository.FlaggedActions.Get(nameof(UpdateMonstersFlaggedAction)).Set();
        Game.SingletonRepository.FlaggedActions.Get(nameof(UpdateBonusesFlaggedAction)).Set();
        base.Noticed();
    }
}
