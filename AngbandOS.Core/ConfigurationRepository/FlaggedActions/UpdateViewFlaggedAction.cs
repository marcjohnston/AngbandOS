﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FlaggedActions;

[Serializable]
internal class UpdateViewFlaggedAction : FlaggedAction
{
    private UpdateViewFlaggedAction(SaveGame saveGame) : base(saveGame) { }

    private void CaveViewHack(GridTile c, int y, int x)
    {
        c.TileFlags.Set(GridTile.IsVisible);
        SaveGame.View.Add(new GridCoordinate(x, y));
    }

    private bool UpdateViewAux(int y, int x, int y1, int x1, int y2, int x2)
    {
        GridTile g1CPtr = SaveGame.Grid[y1][x1];
        GridTile g2CPtr = SaveGame.Grid[y2][x2];
        bool f1 = !g1CPtr.FeatureType.BlocksLos;
        bool f2 = !g2CPtr.FeatureType.BlocksLos;
        if (!f1 && !f2)
        {
            return true;
        }
        bool v1 = f1 && g1CPtr.TileFlags.IsSet(GridTile.IsVisible);
        bool v2 = f2 && g2CPtr.TileFlags.IsSet(GridTile.IsVisible);
        if (!v1 && !v2)
        {
            return true;
        }
        GridTile cPtr = SaveGame.Grid[y][x];
        bool wall = cPtr.FeatureType.BlocksLos;
        bool z1 = v1 && g1CPtr.TileFlags.IsSet(GridTile.EasyVisibility);
        bool z2 = v2 && g2CPtr.TileFlags.IsSet(GridTile.EasyVisibility);
        if (z1 && z2)
        {
            cPtr.TileFlags.Set(GridTile.EasyVisibility);
            CaveViewHack(cPtr, y, x);
            return wall;
        }
        if (z1)
        {
            CaveViewHack(cPtr, y, x);
            return wall;
        }
        if (v1 && v2)
        {
            CaveViewHack(cPtr, y, x);
            return wall;
        }
        if (wall)
        {
            CaveViewHack(cPtr, y, x);
            return true;
        }
        if (SaveGame.Los(SaveGame.MapY, SaveGame.MapX, y, x))
        {
            CaveViewHack(cPtr, y, x);
            return false;
        }
        return true;
    }
    protected override void Execute()
    {
        int n;
        int d;
        int y, x;
        int yMax = SaveGame.CurHgt - 1;
        int xMax = SaveGame.CurWid - 1;
        GridTile cPtr;
        const int full = Constants.MaxSight;
        const int over = Constants.MaxSight * 3 / 2;
        foreach (GridCoordinate gridCoordinate in SaveGame.View)
        {
            cPtr = SaveGame.Grid[gridCoordinate.Y][gridCoordinate.X];
            cPtr.TileFlags.Clear(GridTile.IsVisible);
            cPtr.TileFlags.Set(GridTile.TempFlag);
            SaveGame.TempY[SaveGame.TempN] = gridCoordinate.Y;
            SaveGame.TempX[SaveGame.TempN] = gridCoordinate.X;
            SaveGame.TempN++;
        }
        SaveGame.View.Clear();
        y = SaveGame.MapY;
        x = SaveGame.MapX;
        cPtr = SaveGame.Grid[y][x];
        cPtr.TileFlags.Set(GridTile.EasyVisibility);
        CaveViewHack(cPtr, y, x);
        int z = full * 2 / 3;
        for (d = 1; d <= z; d++)
        {
            cPtr = SaveGame.Grid[y + d][x + d];
            cPtr.TileFlags.Set(GridTile.EasyVisibility);
            CaveViewHack(cPtr, y + d, x + d);
            if (cPtr.FeatureType.BlocksLos)
            {
                break;
            }
            if (!SaveGame.InBounds2(y + d, x + d))
            {
                break;
            }
        }
        for (d = 1; d <= z; d++)
        {
            cPtr = SaveGame.Grid[y + d][x - d];
            cPtr.TileFlags.Set(GridTile.EasyVisibility);
            CaveViewHack(cPtr, y + d, x - d);
            if (cPtr.FeatureType.BlocksLos)
            {
                break;
            }
            if (!SaveGame.InBounds2(y + d, x - d))
            {
                break;
            }
        }
        for (d = 1; d <= z; d++)
        {
            cPtr = SaveGame.Grid[y - d][x + d];
            cPtr.TileFlags.Set(GridTile.EasyVisibility);
            CaveViewHack(cPtr, y - d, x + d);
            if (cPtr.FeatureType.BlocksLos)
            {
                break;
            }
            if (!SaveGame.InBounds2(y - d, x + d))
            {
                break;
            }
        }
        for (d = 1; d <= z; d++)
        {
            cPtr = SaveGame.Grid[y - d][x - d];
            cPtr.TileFlags.Set(GridTile.EasyVisibility);
            CaveViewHack(cPtr, y - d, x - d);
            if (cPtr.FeatureType.BlocksLos)
            {
                break;
            }
            if (!SaveGame.InBounds2(y - d, x - d))
            {
                break;
            }
        }
        for (d = 1; d <= full; d++)
        {
            cPtr = SaveGame.Grid[y + d][x];
            cPtr.TileFlags.Set(GridTile.EasyVisibility);
            CaveViewHack(cPtr, y + d, x);
            if (cPtr.FeatureType.BlocksLos)
            {
                break;
            }
            if (!SaveGame.InBounds2(y + d, x))
            {
                break;
            }
        }
        int se = d;
        int sw = d;
        for (d = 1; d <= full; d++)
        {
            cPtr = SaveGame.Grid[y - d][x];
            cPtr.TileFlags.Set(GridTile.EasyVisibility);
            CaveViewHack(cPtr, y - d, x);
            if (cPtr.FeatureType.BlocksLos)
            {
                break;
            }
            if (!SaveGame.InBounds2(y - d, x))
            {
                break;
            }
        }
        int ne = d;
        int nw = d;
        for (d = 1; d <= full; d++)
        {
            cPtr = SaveGame.Grid[y][x + d];
            cPtr.TileFlags.Set(GridTile.EasyVisibility);
            CaveViewHack(cPtr, y, x + d);
            if (cPtr.FeatureType.BlocksLos)
            {
                break;
            }
            if (!SaveGame.InBounds2(y, x + d))
            {
                break;
            }
        }
        int es = d;
        int en = d;
        for (d = 1; d <= full; d++)
        {
            cPtr = SaveGame.Grid[y][x - d];
            cPtr.TileFlags.Set(GridTile.EasyVisibility);
            CaveViewHack(cPtr, y, x - d);
            if (cPtr.FeatureType.BlocksLos)
            {
                break;
            }
            if (!SaveGame.InBounds2(y, x - d))
            {
                break;
            }
        }
        int ws = d;
        int wn = d;
        for (n = 1; n <= over / 2; n++)
        {
            z = over - n - n;
            if (z > full - n)
            {
                z = full - n;
            }
            while (z + n + (n >> 1) > full)
            {
                z--;
            }
            int ypn = y + n;
            int ymn = y - n;
            int xpn = x + n;
            int xmn = x - n;
            int m;
            int k;
            if (ypn < yMax)
            {
                m = Math.Min(z, yMax - ypn);
                if (xpn <= xMax && n < se)
                {
                    for (k = n, d = 1; d <= m; d++)
                    {
                        if (UpdateViewAux(ypn + d, xpn, ypn + d - 1, xpn - 1, ypn + d - 1, xpn))
                        {
                            if (n + d >= se)
                            {
                                break;
                            }
                        }
                        else
                        {
                            k = n + d;
                        }
                    }
                    se = k + 1;
                }
                if (xmn >= 0 && n < sw)
                {
                    for (k = n, d = 1; d <= m; d++)
                    {
                        if (UpdateViewAux(ypn + d, xmn, ypn + d - 1, xmn + 1, ypn + d - 1, xmn))
                        {
                            if (n + d >= sw)
                            {
                                break;
                            }
                        }
                        else
                        {
                            k = n + d;
                        }
                    }
                    sw = k + 1;
                }
            }
            if (ymn > 0)
            {
                m = Math.Min(z, ymn);
                if (xpn <= xMax && n < ne)
                {
                    for (k = n, d = 1; d <= m; d++)
                    {
                        if (UpdateViewAux(ymn - d, xpn, ymn - d + 1, xpn - 1, ymn - d + 1, xpn))
                        {
                            if (n + d >= ne)
                            {
                                break;
                            }
                        }
                        else
                        {
                            k = n + d;
                        }
                    }
                    ne = k + 1;
                }
                if (xmn >= 0 && n < nw)
                {
                    for (k = n, d = 1; d <= m; d++)
                    {
                        if (UpdateViewAux(ymn - d, xmn, ymn - d + 1, xmn + 1, ymn - d + 1, xmn))
                        {
                            if (n + d >= nw)
                            {
                                break;
                            }
                        }
                        else
                        {
                            k = n + d;
                        }
                    }
                    nw = k + 1;
                }
            }
            if (xpn < xMax)
            {
                m = Math.Min(z, xMax - xpn);
                if (ypn <= yMax && n < es)
                {
                    for (k = n, d = 1; d <= m; d++)
                    {
                        if (UpdateViewAux(ypn, xpn + d, ypn - 1, xpn + d - 1, ypn, xpn + d - 1))
                        {
                            if (n + d >= es)
                            {
                                break;
                            }
                        }
                        else
                        {
                            k = n + d;
                        }
                    }
                    es = k + 1;
                }
                if (ymn >= 0 && n < en)
                {
                    for (k = n, d = 1; d <= m; d++)
                    {
                        if (UpdateViewAux(ymn, xpn + d, ymn + 1, xpn + d - 1, ymn, xpn + d - 1))
                        {
                            if (n + d >= en)
                            {
                                break;
                            }
                        }
                        else
                        {
                            k = n + d;
                        }
                    }
                    en = k + 1;
                }
            }
            if (xmn > 0)
            {
                m = Math.Min(z, xmn);
                if (ypn <= yMax && n < ws)
                {
                    for (k = n, d = 1; d <= m; d++)
                    {
                        if (UpdateViewAux(ypn, xmn - d, ypn - 1, xmn - d + 1, ypn, xmn - d + 1))
                        {
                            if (n + d >= ws)
                            {
                                break;
                            }
                        }
                        else
                        {
                            k = n + d;
                        }
                    }
                    ws = k + 1;
                }
                if (ymn >= 0 && n < wn)
                {
                    for (k = n, d = 1; d <= m; d++)
                    {
                        if (UpdateViewAux(ymn, xmn - d, ymn + 1, xmn - d + 1, ymn, xmn - d + 1))
                        {
                            if (n + d >= wn)
                            {
                                break;
                            }
                        }
                        else
                        {
                            k = n + d;
                        }
                    }
                    wn = k + 1;
                }
            }
        }
        foreach (GridCoordinate gridCoordinate in SaveGame.View)
        {
            cPtr = SaveGame.Grid[gridCoordinate.Y][gridCoordinate.X];
            cPtr.TileFlags.Clear(GridTile.EasyVisibility);
            if (cPtr.TileFlags.IsSet(GridTile.TempFlag))
            {
                continue;
            }
            SaveGame.NoteSpot(gridCoordinate.Y, gridCoordinate.X);
            SaveGame.RedrawSingleLocation(gridCoordinate.Y, gridCoordinate.X);
        }
        for (n = 0; n < SaveGame.TempN; n++)
        {
            y = SaveGame.TempY[n];
            x = SaveGame.TempX[n];
            cPtr = SaveGame.Grid[y][x];
            cPtr.TileFlags.Clear(GridTile.TempFlag);
            if (cPtr.TileFlags.IsSet(GridTile.IsVisible))
            {
                continue;
            }
            SaveGame.RedrawSingleLocation(y, x);
        }
        SaveGame.TempN = 0;
    }
}