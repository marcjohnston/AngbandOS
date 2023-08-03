// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FlaggedActions;

[Serializable]
internal class UpdateLightFlaggedAction : FlaggedAction
{
    private UpdateLightFlaggedAction(SaveGame saveGame) : base(saveGame) { }
    private void CaveLightHack(int y, int x)
    {
        SaveGame.Grid[y][x].TileFlags.Set(GridTile.PlayerLit);
        SaveGame.Light.Add(new GridCoordinate(x, y));
    }

    protected override void Execute()
    {
        if (SaveGame.LightLevel <= 0)
        {
            SaveGame.SingletonRepository.FlaggedActions.Get<RemoveLightFlaggedAction>().Check(true);
            SaveGame.RedrawSingleLocation(SaveGame.MapY, SaveGame.MapX);
            return;
        }
        foreach (GridCoordinate gridCoordinate in SaveGame.Light)
        {
            SaveGame.Grid[gridCoordinate.Y][gridCoordinate.X].TileFlags.Clear(GridTile.PlayerLit);
            SaveGame.Grid[gridCoordinate.Y][gridCoordinate.X].TileFlags.Set(GridTile.TempFlag);
            SaveGame.TempY[SaveGame.TempN] = gridCoordinate.Y;
            SaveGame.TempX[SaveGame.TempN] = gridCoordinate.X;
            SaveGame.TempN++;
        }
        SaveGame.Light.Clear();
        CaveLightHack(SaveGame.MapY, SaveGame.MapX);
        if (SaveGame.LightLevel >= 1)
        {
            CaveLightHack(SaveGame.MapY + 1, SaveGame.MapX);
            CaveLightHack(SaveGame.MapY - 1, SaveGame.MapX);
            CaveLightHack(SaveGame.MapY, SaveGame.MapX + 1);
            CaveLightHack(SaveGame.MapY, SaveGame.MapX - 1);
            CaveLightHack(SaveGame.MapY + 1, SaveGame.MapX + 1);
            CaveLightHack(SaveGame.MapY + 1, SaveGame.MapX - 1);
            CaveLightHack(SaveGame.MapY - 1, SaveGame.MapX + 1);
            CaveLightHack(SaveGame.MapY - 1, SaveGame.MapX - 1);
        }
        if (SaveGame.LightLevel >= 2)
        {
            if (SaveGame.GridPassable(SaveGame.MapY + 1, SaveGame.MapX))
            {
                CaveLightHack(SaveGame.MapY + 2, SaveGame.MapX);
                CaveLightHack(SaveGame.MapY + 2, SaveGame.MapX + 1);
                CaveLightHack(SaveGame.MapY + 2, SaveGame.MapX - 1);
            }
            if (SaveGame.GridPassable(SaveGame.MapY - 1, SaveGame.MapX))
            {
                CaveLightHack(SaveGame.MapY - 2, SaveGame.MapX);
                CaveLightHack(SaveGame.MapY - 2, SaveGame.MapX + 1);
                CaveLightHack(SaveGame.MapY - 2, SaveGame.MapX - 1);
            }
            if (SaveGame.GridPassable(SaveGame.MapY, SaveGame.MapX + 1))
            {
                CaveLightHack(SaveGame.MapY, SaveGame.MapX + 2);
                CaveLightHack(SaveGame.MapY + 1, SaveGame.MapX + 2);
                CaveLightHack(SaveGame.MapY - 1, SaveGame.MapX + 2);
            }
            if (SaveGame.GridPassable(SaveGame.MapY, SaveGame.MapX - 1))
            {
                CaveLightHack(SaveGame.MapY, SaveGame.MapX - 2);
                CaveLightHack(SaveGame.MapY + 1, SaveGame.MapX - 2);
                CaveLightHack(SaveGame.MapY - 1, SaveGame.MapX - 2);
            }
        }
        if (SaveGame.LightLevel >= 3)
        {
            int p = SaveGame.LightLevel;
            if (p > 5)
            {
                p = 5;
            }
            if (SaveGame.GridPassable(SaveGame.MapY + 1, SaveGame.MapX + 1))
            {
                CaveLightHack(SaveGame.MapY + 2, SaveGame.MapX + 2);
            }
            if (SaveGame.GridPassable(SaveGame.MapY + 1, SaveGame.MapX - 1))
            {
                CaveLightHack(SaveGame.MapY + 2, SaveGame.MapX - 2);
            }
            if (SaveGame.GridPassable(SaveGame.MapY - 1, SaveGame.MapX + 1))
            {
                CaveLightHack(SaveGame.MapY - 2, SaveGame.MapX + 2);
            }
            if (SaveGame.GridPassable(SaveGame.MapY - 1, SaveGame.MapX - 1))
            {
                CaveLightHack(SaveGame.MapY - 2, SaveGame.MapX - 2);
            }
            int minY = SaveGame.MapY - p;
            if (minY < 0)
            {
                minY = 0;
            }
            int maxY = SaveGame.MapY + p;
            if (maxY > SaveGame.CurHgt - 1)
            {
                maxY = SaveGame.CurHgt - 1;
            }
            int minX = SaveGame.MapX - p;
            if (minX < 0)
            {
                minX = 0;
            }
            int maxX = SaveGame.MapX + p;
            if (maxX > SaveGame.CurWid - 1)
            {
                maxX = SaveGame.CurWid - 1;
            }
            for (int y = minY; y <= maxY; y++)
            {
                for (int x = minX; x <= maxX; x++)
                {
                    int dy = SaveGame.MapY > y ? SaveGame.MapY - y : y - SaveGame.MapY;
                    int dx = SaveGame.MapX > x ? SaveGame.MapX - x : x - SaveGame.MapX;
                    if (dy <= 2 && dx <= 2)
                    {
                        continue;
                    }
                    int d = dy > dx ? dy + (dx >> 1) : dx + (dy >> 1);
                    if (d > p)
                    {
                        continue;
                    }
                    if (SaveGame.PlayerHasLosBold(y, x))
                    {
                        CaveLightHack(y, x);
                    }
                }
            }
        }
        foreach (GridCoordinate gridCoordinate in SaveGame.Light)
        {
            if (SaveGame.Grid[gridCoordinate.Y][gridCoordinate.X].TileFlags.IsSet(GridTile.TempFlag))
            {
                continue;
            }
            SaveGame.NoteSpot(gridCoordinate.Y, gridCoordinate.X);
            SaveGame.RedrawSingleLocation(gridCoordinate.Y, gridCoordinate.X);
        }
        for (int i = 0; i < SaveGame.TempN; i++)
        {
            int y = SaveGame.TempY[i];
            int x = SaveGame.TempX[i];
            SaveGame.Grid[y][x].TileFlags.Clear(GridTile.TempFlag);
            if (SaveGame.Grid[y][x].TileFlags.IsSet(GridTile.PlayerLit))
            {
                continue;
            }
            SaveGame.RedrawSingleLocation(y, x);
        }
        SaveGame.TempN = 0;
    }
}
