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

    public override void Bind()
    {
        RedrawActions = new FlaggedAction[] {
            SaveGame.SingletonRepository.FlaggedActions.Get(nameof(RedrawPlayerFlaggedAction)),
            SaveGame.SingletonRepository.FlaggedActions.Get(nameof(RedrawTitleFlaggedAction)),
            SaveGame.SingletonRepository.FlaggedActions.Get(nameof(RedrawStatsFlaggedAction)),
            SaveGame.SingletonRepository.FlaggedActions.Get(nameof(RedrawLevelFlaggedAction)),
            SaveGame.SingletonRepository.FlaggedActions.Get(nameof(RedrawExpFlaggedAction)),
            SaveGame.SingletonRepository.FlaggedActions.Get(nameof(RedrawGoldFlaggedAction)),
            SaveGame.SingletonRepository.FlaggedActions.Get(nameof(RedrawArmorFlaggedAction)),
            SaveGame.SingletonRepository.FlaggedActions.Get(nameof(RedrawHpFlaggedAction)),
            SaveGame.SingletonRepository.FlaggedActions.Get(nameof(RedrawManaFlaggedAction)),
            SaveGame.SingletonRepository.FlaggedActions.Get(nameof(RedrawDepthFlaggedAction)),
            SaveGame.SingletonRepository.FlaggedActions.Get(nameof(RedrawHealthFlaggedAction)),
            SaveGame.SingletonRepository.FlaggedActions.Get(nameof(RedrawSpeedFlaggedAction))
        };
    }
}