// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class ToggleSearchScript : Script
{
    private ToggleSearchScript(SaveGame saveGame) : base(saveGame) { }

    public override bool Execute()
    {
        SaveGame.IsSearching = !SaveGame.IsSearching;
        SaveGame.SingletonRepository.FlaggedActions.Get(nameof(RedrawSpeedFlaggedAction)).Set();
        SaveGame.SingletonRepository.FlaggedActions.Get(nameof(UpdateBonusesFlaggedAction)).Set();
        SaveGame.SingletonRepository.FlaggedActions.Get(nameof(RedrawStateFlaggedAction)).Set();
        return false;
    }
}
