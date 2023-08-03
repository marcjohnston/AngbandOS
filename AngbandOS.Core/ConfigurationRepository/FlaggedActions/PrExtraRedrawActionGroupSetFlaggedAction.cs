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
    private PrExtraRedrawActionGroupSetFlaggedAction(SaveGame saveGame) : base(saveGame) { }

    public override void Loaded()
    {
        RedrawActions = new FlaggedAction[] {
            SaveGame.SingletonRepository.FlaggedActions.Get<RedrawCutFlaggedAction>(),
            SaveGame.SingletonRepository.FlaggedActions.Get<RedrawHungerFlaggedAction>(),
            SaveGame.SingletonRepository.FlaggedActions.Get<RedrawDTrapFlaggedAction>(),
            SaveGame.SingletonRepository.FlaggedActions.Get<RedrawBlindFlaggedAction>(),
            SaveGame.SingletonRepository.FlaggedActions.Get<RedrawConfusedFlaggedAction>(),
            SaveGame.SingletonRepository.FlaggedActions.Get<RedrawAfraidFlaggedAction>(),
            SaveGame.SingletonRepository.FlaggedActions.Get<RedrawPoisonedFlaggedAction>(),
            SaveGame.SingletonRepository.FlaggedActions.Get<RedrawStateFlaggedAction>(),
            SaveGame.SingletonRepository.FlaggedActions.Get<RedrawSpeedFlaggedAction>(),
            SaveGame.SingletonRepository.FlaggedActions.Get<RedrawStudyFlaggedAction>()
        };
    }
}