// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using System.Diagnostics;

namespace AngbandOS.Core.FlaggedActions;

/// <summary>
/// Updates the view.  The view of the player extends to a distance as Constants.MaxVision.  Tiles that block line-of-sight are required to ensure
/// the grid coordinates are not invalid.
/// </summary>
[Serializable]
internal class UpdateViewFlaggedAction : FlaggedAction
{
    private UpdateViewFlaggedAction(Game game) : base(game) { }

    /// <summary>
    /// Set the c.TileFlags as IsVisible and add the coordinate to the Game.View.
    /// </summary>
    /// <param name="c"></param>
    /// <param name="y"></param>
    /// <param name="x"></param>
    private void CaveViewHack(GridTile c, int y, int x)
    {
        c.IsVisible = true;
        Game.View.Add(new GridCoordinate(x, y));
    }

    private bool UpdateViewAux(int y, int x, int y1, int x1, int y2, int x2)
    {
        GridTile g1CPtr = Game.Grid[y1][x1];
        GridTile g2CPtr = Game.Grid[y2][x2];
        bool f1 = !g1CPtr.FeatureType.BlocksLos;
        bool f2 = !g2CPtr.FeatureType.BlocksLos;
        if (!f1 && !f2)
        {
            return true;
        }
        bool v1 = f1 && g1CPtr.IsVisible;
        bool v2 = f2 && g2CPtr.IsVisible;
        if (!v1 && !v2)
        {
            return true;
        }
        GridTile cPtr = Game.Grid[y][x];
        bool wall = cPtr.FeatureType.BlocksLos;
        bool z1 = v1 && g1CPtr.EasyVisibility;
        bool z2 = v2 && g2CPtr.EasyVisibility;
        if (z1 && z2)
        {
            cPtr.EasyVisibility= true;
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
        if (Game.Los(Game.MapY, Game.MapX, y, x))
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
        int yMax = Game.CurHgt - 1;
        int xMax = Game.CurWid - 1;
        GridTile cPtr;
        const int full = Constants.MaxSight;
        const int over = Constants.MaxSight * 3 / 2;

        // Enumerate all of the view coordinates, clear the tile and set it as temp.  Then add the coordinate to the Game.Temp array.
        foreach (GridCoordinate gridCoordinate in Game.View)
        {
            cPtr = Game.Grid[gridCoordinate.Y][gridCoordinate.X];
            cPtr.IsVisible = false;
            cPtr.TempFlag = true;
            Game.TempY[Game.TempN] = gridCoordinate.Y;
            Game.TempX[Game.TempN] = gridCoordinate.X;
            Game.TempN++;
        }

        // Now clear the view coordinates.
        Game.View.Clear();
        int y = Game.MapY;
        int x = Game.MapX;
        cPtr = Game.Grid[y][x];
        cPtr.EasyVisibility= true;
        CaveViewHack(cPtr, y, x);
        int z = full * 2 / 3;
        for (d = 1; d <= z; d++)
        {
            cPtr = Game.Grid[y + d][x + d];
            cPtr.EasyVisibility= true;
            CaveViewHack(cPtr, y + d, x + d);
            if (cPtr.FeatureType.BlocksLos)
            {
                break;
            }
            if (!Game.InBounds2(y + d, x + d))
            {
                break;
            }
        }
        for (d = 1; d <= z; d++)
        {
            cPtr = Game.Grid[y + d][x - d];
            cPtr.EasyVisibility= true;
            CaveViewHack(cPtr, y + d, x - d);
            if (cPtr.FeatureType.BlocksLos)
            {
                break;
            }
            if (!Game.InBounds2(y + d, x - d))
            {
                break;
            }
        }
        for (d = 1; d <= z; d++)
        {
            cPtr = Game.Grid[y - d][x + d];
            cPtr.EasyVisibility= true;
            CaveViewHack(cPtr, y - d, x + d);
            if (cPtr.FeatureType.BlocksLos)
            {
                break;
            }
            if (!Game.InBounds2(y - d, x + d))
            {
                break;
            }
        }
        for (d = 1; d <= z; d++)
        {
            cPtr = Game.Grid[y - d][x - d];
            cPtr.EasyVisibility= true;
            CaveViewHack(cPtr, y - d, x - d);
            if (cPtr.FeatureType.BlocksLos)
            {
                break;
            }
            if (!Game.InBounds2(y - d, x - d))
            {
                break;
            }
        }
        for (d = 1; d <= full; d++)
        {
            cPtr = Game.Grid[y + d][x];
            cPtr.EasyVisibility= true;
            CaveViewHack(cPtr, y + d, x);
            if (cPtr.FeatureType.BlocksLos)
            {
                break;
            }
            if (!Game.InBounds2(y + d, x))
            {
                break;
            }
        }
        int se = d;
        int sw = d;
        for (d = 1; d <= full; d++)
        {
            cPtr = Game.Grid[y - d][x];
            cPtr.EasyVisibility= true;
            CaveViewHack(cPtr, y - d, x);
            if (cPtr.FeatureType.BlocksLos)
            {
                break;
            }
            if (!Game.InBounds2(y - d, x))
            {
                break;
            }
        }
        int ne = d;
        int nw = d;
        for (d = 1; d <= full; d++)
        {
            cPtr = Game.Grid[y][x + d];
            cPtr.EasyVisibility= true;
            CaveViewHack(cPtr, y, x + d);
            if (cPtr.FeatureType.BlocksLos)
            {
                break;
            }
            if (!Game.InBounds2(y, x + d))
            {
                break;
            }
        }
        int es = d;
        int en = d;
        for (d = 1; d <= full; d++)
        {
            cPtr = Game.Grid[y][x - d];
            cPtr.EasyVisibility= true;
            CaveViewHack(cPtr, y, x - d);
            if (cPtr.FeatureType.BlocksLos)
            {
                break;
            }
            if (!Game.InBounds2(y, x - d))
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
        foreach (GridCoordinate gridCoordinate in Game.View)
        {
            cPtr = Game.Grid[gridCoordinate.Y][gridCoordinate.X];
            cPtr.EasyVisibility = false;
            if (cPtr.TempFlag)
            {
                continue;
            }
            Game.NoteSpot(gridCoordinate.Y, gridCoordinate.X);
            Game.MainForm.RefreshMapLocation(gridCoordinate.Y, gridCoordinate.X);
        }
        for (n = 0; n < Game.TempN; n++)
        {
            y = Game.TempY[n];
            x = Game.TempX[n];
            cPtr = Game.Grid[y][x];
            cPtr.TempFlag = false;
            if (cPtr.IsVisible)
            {
                continue;
            }
            Game.MainForm.RefreshMapLocation(y, x);
        }
        Game.TempN = 0;
    }
}
