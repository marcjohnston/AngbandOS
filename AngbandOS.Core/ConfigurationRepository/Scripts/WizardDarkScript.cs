// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class WizardDarkScript : Script, IScript
{
    private WizardDarkScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Darkens the map.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        for (int y = 0; y < SaveGame.CurHgt; y++)
        {
            for (int x = 0; x < SaveGame.CurWid; x++)
            {
                GridTile cPtr = SaveGame.Grid[y][x];
                cPtr.TileFlags.Clear(GridTile.PlayerMemorized);
                foreach (Item oPtr in cPtr.Items)
                {
                    oPtr.Marked = false;
                }
            }
        }
        SaveGame.SingletonRepository.FlaggedActions.Get(nameof(RemoveLightFlaggedAction)).Set();
        SaveGame.SingletonRepository.FlaggedActions.Get(nameof(RemoveViewFlaggedAction)).Set();
        SaveGame.SingletonRepository.FlaggedActions.Get(nameof(UpdateLightFlaggedAction)).Set();
        SaveGame.SingletonRepository.FlaggedActions.Get(nameof(UpdateViewFlaggedAction)).Set();
        SaveGame.SingletonRepository.FlaggedActions.Get(nameof(UpdateMonstersFlaggedAction)).Set();
        SaveGame.SingletonRepository.FlaggedActions.Get(nameof(RedrawMapFlaggedAction)).Set();
    }
}
