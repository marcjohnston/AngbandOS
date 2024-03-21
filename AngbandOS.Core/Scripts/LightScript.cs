// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class LightScript : Script, IScript
{
    private LightScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Lights the map.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        for (int y = 1; y < SaveGame.CurHgt - 1; y++)
        {
            for (int x = 1; x < SaveGame.CurWid - 1; x++)
            {
                GridTile cPtr = SaveGame.Grid[y][x];
                if (!cPtr.FeatureType.IsWall)
                {
                    for (int i = 0; i < 9; i++)
                    {
                        int yy = y + SaveGame.OrderedDirectionYOffset[i];
                        int xx = x + SaveGame.OrderedDirectionXOffset[i];
                        cPtr = SaveGame.Grid[yy][xx];
                        cPtr.TileFlags.Set(GridTile.SelfLit);
                        if (!cPtr.FeatureType.IsOpenFloor)
                        {
                            cPtr.TileFlags.Set(GridTile.PlayerMemorized);
                        }
                        cPtr.TileFlags.Set(GridTile.PlayerMemorized);
                    }
                }
                foreach (Item oPtr in cPtr.Items)
                {
                    oPtr.Marked = true;
                }
            }
        }
        SaveGame.SingletonRepository.FlaggedActions.Get(nameof(UpdateMonstersFlaggedAction)).Set();
        SaveGame.SingletonRepository.FlaggedActions.Get(nameof(RedrawMapFlaggedAction)).Set();
    }
}
