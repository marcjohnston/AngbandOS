// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FlaggedActions;

[Serializable]
internal class PrExtraRedrawActionGroupSetFlaggedAction : GroupSetFlaggedAction
{
    private PrExtraRedrawActionGroupSetFlaggedAction(Game game) : base(game) { }

    public override void Bind()
    {
        RedrawActions = new FlaggedAction[] {
            Game.SingletonRepository.FlaggedActions.Get(nameof(RedrawDTrapFlaggedAction)),
            Game.SingletonRepository.FlaggedActions.Get(nameof(RedrawStateFlaggedAction)),
            Game.SingletonRepository.FlaggedActions.Get(nameof(RedrawSpeedFlaggedAction)),
        };
    }
}