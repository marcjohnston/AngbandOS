// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FlaggedActions;

[Serializable]
internal class PrBasicRedrawActionGroupSetFlaggedAction : GroupSetFlaggedAction
{
    private PrBasicRedrawActionGroupSetFlaggedAction(SaveGame saveGame) : base(saveGame) { }

    public override void Loaded()
    {
        RedrawActions = new FlaggedAction[] {
            SaveGame.SingletonRepository.FlaggedActions.Get<RedrawPlayerFlaggedAction>(),
            SaveGame.SingletonRepository.FlaggedActions.Get<RedrawTitleFlaggedAction>(),
            SaveGame.SingletonRepository.FlaggedActions.Get<RedrawStatsFlaggedAction>(),
            SaveGame.SingletonRepository.FlaggedActions.Get<RedrawLevelFlaggedAction>(),
            SaveGame.SingletonRepository.FlaggedActions.Get<RedrawExpFlaggedAction>(),
            SaveGame.SingletonRepository.FlaggedActions.Get<RedrawGoldFlaggedAction>(),
            SaveGame.SingletonRepository.FlaggedActions.Get<RedrawArmorFlaggedAction>(),
            SaveGame.SingletonRepository.FlaggedActions.Get<RedrawHpFlaggedAction>(),
            SaveGame.SingletonRepository.FlaggedActions.Get<RedrawManaFlaggedAction>(),
            SaveGame.SingletonRepository.FlaggedActions.Get<RedrawDepthFlaggedAction>(),
            SaveGame.SingletonRepository.FlaggedActions.Get<RedrawHealthFlaggedAction>(),
            SaveGame.SingletonRepository.FlaggedActions.Get<RedrawSpeedFlaggedAction>()
        };
    }
}