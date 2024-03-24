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
    private UpdateLightFlaggedAction(Game game) : base(game) { }
    private void CaveLightHack(int y, int x)
    {
        Game.Grid[y][x].TileFlags.Set(GridTile.PlayerLit);
        Game.Light.Add(new GridCoordinate(x, y));
    }

    protected override void Execute()
    {
        if (Game.LightLevel <= 0)
        {
            Game.SingletonRepository.FlaggedActions.Get(nameof(RemoveLightFlaggedAction)).Check(true);
            Game.MainForm.RefreshMapLocation(Game.MapY, Game.MapX);
            return;
        }
        foreach (GridCoordinate gridCoordinate in Game.Light)
        {
            Game.Grid[gridCoordinate.Y][gridCoordinate.X].TileFlags.Clear(GridTile.PlayerLit);
            Game.Grid[gridCoordinate.Y][gridCoordinate.X].TileFlags.Set(GridTile.TempFlag);
            Game.TempY[Game.TempN] = gridCoordinate.Y;
            Game.TempX[Game.TempN] = gridCoordinate.X;
            Game.TempN++;
        }
        Game.Light.Clear();
        CaveLightHack(Game.MapY, Game.MapX);
        if (Game.LightLevel >= 1)
        {
            CaveLightHack(Game.MapY + 1, Game.MapX);
            CaveLightHack(Game.MapY - 1, Game.MapX);
            CaveLightHack(Game.MapY, Game.MapX + 1);
            CaveLightHack(Game.MapY, Game.MapX - 1);
            CaveLightHack(Game.MapY + 1, Game.MapX + 1);
            CaveLightHack(Game.MapY + 1, Game.MapX - 1);
            CaveLightHack(Game.MapY - 1, Game.MapX + 1);
            CaveLightHack(Game.MapY - 1, Game.MapX - 1);
        }
        if (Game.LightLevel >= 2)
        {
            if (Game.GridPassable(Game.MapY + 1, Game.MapX))
            {
                CaveLightHack(Game.MapY + 2, Game.MapX);
                CaveLightHack(Game.MapY + 2, Game.MapX + 1);
                CaveLightHack(Game.MapY + 2, Game.MapX - 1);
            }
            if (Game.GridPassable(Game.MapY - 1, Game.MapX))
            {
                CaveLightHack(Game.MapY - 2, Game.MapX);
                CaveLightHack(Game.MapY - 2, Game.MapX + 1);
                CaveLightHack(Game.MapY - 2, Game.MapX - 1);
            }
            if (Game.GridPassable(Game.MapY, Game.MapX + 1))
            {
                CaveLightHack(Game.MapY, Game.MapX + 2);
                CaveLightHack(Game.MapY + 1, Game.MapX + 2);
                CaveLightHack(Game.MapY - 1, Game.MapX + 2);
            }
            if (Game.GridPassable(Game.MapY, Game.MapX - 1))
            {
                CaveLightHack(Game.MapY, Game.MapX - 2);
                CaveLightHack(Game.MapY + 1, Game.MapX - 2);
                CaveLightHack(Game.MapY - 1, Game.MapX - 2);
            }
        }
        if (Game.LightLevel >= 3)
        {
            int p = Game.LightLevel;
            if (p > 5)
            {
                p = 5;
            }
            if (Game.GridPassable(Game.MapY + 1, Game.MapX + 1))
            {
                CaveLightHack(Game.MapY + 2, Game.MapX + 2);
            }
            if (Game.GridPassable(Game.MapY + 1, Game.MapX - 1))
            {
                CaveLightHack(Game.MapY + 2, Game.MapX - 2);
            }
            if (Game.GridPassable(Game.MapY - 1, Game.MapX + 1))
            {
                CaveLightHack(Game.MapY - 2, Game.MapX + 2);
            }
            if (Game.GridPassable(Game.MapY - 1, Game.MapX - 1))
            {
                CaveLightHack(Game.MapY - 2, Game.MapX - 2);
            }
            int minY = Game.MapY - p;
            if (minY < 0)
            {
                minY = 0;
            }
            int maxY = Game.MapY + p;
            if (maxY > Game.CurHgt - 1)
            {
                maxY = Game.CurHgt - 1;
            }
            int minX = Game.MapX - p;
            if (minX < 0)
            {
                minX = 0;
            }
            int maxX = Game.MapX + p;
            if (maxX > Game.CurWid - 1)
            {
                maxX = Game.CurWid - 1;
            }
            for (int y = minY; y <= maxY; y++)
            {
                for (int x = minX; x <= maxX; x++)
                {
                    int dy = Game.MapY > y ? Game.MapY - y : y - Game.MapY;
                    int dx = Game.MapX > x ? Game.MapX - x : x - Game.MapX;
                    if (dy <= 2 && dx <= 2)
                    {
                        continue;
                    }
                    int d = dy > dx ? dy + (dx >> 1) : dx + (dy >> 1);
                    if (d > p)
                    {
                        continue;
                    }
                    if (Game.PlayerHasLosBold(y, x))
                    {
                        CaveLightHack(y, x);
                    }
                }
            }
        }
        foreach (GridCoordinate gridCoordinate in Game.Light)
        {
            if (Game.Grid[gridCoordinate.Y][gridCoordinate.X].TileFlags.IsSet(GridTile.TempFlag))
            {
                continue;
            }
            Game.NoteSpot(gridCoordinate.Y, gridCoordinate.X);
            Game.MainForm.RefreshMapLocation(gridCoordinate.Y, gridCoordinate.X);
        }
        for (int i = 0; i < Game.TempN; i++)
        {
            int y = Game.TempY[i];
            int x = Game.TempX[i];
            Game.Grid[y][x].TileFlags.Clear(GridTile.TempFlag);
            if (Game.Grid[y][x].TileFlags.IsSet(GridTile.PlayerLit))
            {
                continue;
            }
            Game.MainForm.RefreshMapLocation(y, x);
        }
        Game.TempN = 0;
    }
}
