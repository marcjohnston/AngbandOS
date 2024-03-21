// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class MapAreaScript : Script, IScript
{
    private MapAreaScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        int y1 = SaveGame.PanelRowMin - SaveGame.DieRoll(10);
        int y2 = SaveGame.PanelRowMax + SaveGame.DieRoll(10);
        int x1 = SaveGame.PanelColMin - SaveGame.DieRoll(20);
        int x2 = SaveGame.PanelColMax + SaveGame.DieRoll(20);
        if (y1 < 1)
        {
            y1 = 1;
        }
        if (y2 > SaveGame.CurHgt - 2)
        {
            y2 = SaveGame.CurHgt - 2;
        }
        if (x1 < 1)
        {
            x1 = 1;
        }
        if (x2 > SaveGame.CurWid - 2)
        {
            x2 = SaveGame.CurWid - 2;
        }
        for (int y = y1; y <= y2; y++)
        {
            for (int x = x1; x <= x2; x++)
            {
                GridTile cPtr = SaveGame.Grid[y][x];
                if (!cPtr.FeatureType.IsWall)
                {
                    if (!cPtr.FeatureType.IsOpenFloor)
                    {
                        cPtr.TileFlags.Set(GridTile.PlayerMemorized);
                    }
                    for (int i = 0; i < 8; i++)
                    {
                        cPtr = SaveGame.Grid[y + SaveGame.OrderedDirectionYOffset[i]][x + SaveGame.OrderedDirectionXOffset[i]];
                        if (cPtr.FeatureType.IsWall)
                        {
                            cPtr.TileFlags.Set(GridTile.PlayerMemorized);
                        }
                    }
                }
            }
        }
        SaveGame.SingletonRepository.FlaggedActions.Get(nameof(RedrawMapFlaggedAction)).Set();
    }
}
