// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core
{
    [Serializable]
    internal class Level
    {
        public const int MaxHgt = 126;
        public const int MaxWid = 198;
        public readonly GridTile[][] Grid = new GridTile[MaxHgt][];
        public readonly int[] KeypadDirectionXOffset = { 0, -1, 0, 1, -1, 0, 1, -1, 0, 1 };
        public readonly int[] KeypadDirectionYOffset = { 0, 1, 1, 1, 0, 0, 0, -1, -1, -1 };
        public readonly int[] OrderedDirection = { 2, 8, 6, 4, 3, 1, 9, 7, 5 };
        public readonly int[] OrderedDirectionXOffset = { 0, 0, 1, -1, 1, -1, 1, -1, 0 };
        public readonly int[] OrderedDirectionYOffset = { 1, -1, 0, 0, 1, 1, -1, -1, 0 };
        public readonly int[] TempX = new int[Constants.TempMax]; // TODO: Use CursorPositon and combine TempX and TempY into a list to absolve TempN
        public readonly int[] TempY = new int[Constants.TempMax];
        public int CurHgt;
        public int CurWid;
        public int DangerFeeling;
        public int DangerRating;
        public int MaxPanelCols;
        public int MaxPanelRows;
        public int MCnt;
        public int MMax = 1;
        public int MonsterLevel;
        public int ObjectLevel;

        public int PanelCol;
        public int PanelColMax;
        public int PanelColMin;
        public int PanelColPrt;
        public int PanelRow;
        public int PanelRowMax;
        public int PanelRowMin;
        public int PanelRowPrt;
        public bool SpecialDanger;
        public bool SpecialTreasure;
        public int TempN;
        public int TreasureFeeling;
        public int TreasureRating;

        private const string _imageMonsterHack = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string _imageObjectHack = "?/|\\\"!$()_-=[]{},~";
        private const int _mapHgt = MaxHgt / _ratio;
        private const int _mapWid = MaxWid / _ratio;
        private const int _ratio = 3;

        public readonly List<GridCoordinate> Light = new List<GridCoordinate>(); // TODO: This belongs to UpdateLightFlaggedActions and should be private.
        public readonly List<GridCoordinate> View = new List<GridCoordinate>(); // TODO: This belongs to UpdateViewFlaggedActions and should be private.

        private readonly SaveGame SaveGame;

        public Level(SaveGame saveGame)
        {
            SaveGame = saveGame;
            for (int i = 0; i < MaxHgt; i++)
            {
                Grid[i] = new GridTile[MaxWid];
                for (int j = 0; j < MaxWid; j++)
                {
                    Grid[i][j] = new GridTile(saveGame);
                }
            }
            Monsters = new Monster[Constants.MaxMIdx];
            for (int j = 0; j < Constants.MaxMIdx; j++)
            {
                Monsters[j] = new Monster(saveGame);
            }
        }

        public void PanelBounds()
        {
            PanelRowMin = PanelRow * (Constants.ScreenHgt / 2);
            PanelRowMax = PanelRowMin + Constants.ScreenHgt - 1;
            PanelRowPrt = PanelRowMin - 1;
            PanelColMin = PanelCol * (Constants.ScreenWid / 2);
            PanelColMax = PanelColMin + Constants.ScreenWid - 1;
            PanelColPrt = PanelColMin - 13;
        }

        public void PanelBoundsCenter()
        {
            PanelRow = PanelRowMin / (Constants.ScreenHgt / 2);
            PanelRowMax = PanelRowMin + Constants.ScreenHgt - 1;
            PanelRowPrt = PanelRowMin - 1;
            PanelCol = PanelColMin / (Constants.ScreenWid / 2);
            PanelColMax = PanelColMin + Constants.ScreenWid - 1;
            PanelColPrt = PanelColMin - 13;
        }

        public void Acquirement(int y1, int x1, int num, bool great)
        {
            while (num-- != 0)
            {
                Item? qPtr = SaveGame.MakeObject(true, great, false);
                if (qPtr == null)
                {
                    continue;
                }
                DropNear(qPtr, -1, y1, x1);
            }
        }

        public void CaveSetBackground(int y, int x, string feat)
        {
            GridTile cPtr = Grid[y][x];
            cPtr.BackgroundFeature = SaveGame.SingletonRepository.FloorTileTypes[feat];
        }

        public void CaveSetFeat(int y, int x, string feat)
        {
            GridTile cPtr = Grid[y][x];
            cPtr.FeatureType = SaveGame.SingletonRepository.FloorTileTypes[feat];
            NoteSpot(y, x);
            RedrawSingleLocation(y, x);
        }

        public bool CaveValidBold(int y, int x)
        {
            GridTile cPtr = Grid[y][x];
            if (cPtr.FeatureType.IsPermanent)
            {
                return false;
            }
            foreach (Item oPtr in cPtr.Items)
            {
                if (!string.IsNullOrEmpty(oPtr.RandartName) || oPtr.IsFixedArtifact())
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Checks the stack of items at a grid coordinate for a chest and returns the first chest item found.   Returns null, if no chest is found.
        /// </summary>
        /// <param name="y"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public Item? ChestCheck(int y, int x)
        {
            GridTile cPtr = Grid[y][x];
            foreach (Item oPtr in cPtr.Items) 
            {
                if (oPtr.Category == ItemTypeEnum.Chest)
                {
                    return oPtr;
                }
            }
            return null;
        }

        public int CoordsToDir(int y, int x)
        {
            int[][] d = { new[] { 7, 4, 1 }, new[] { 8, 5, 2 }, new[] { 9, 6, 3 } };
            int dy = y - SaveGame.Player.MapY;
            int dx = x - SaveGame.Player.MapX;
            if (Math.Abs(dx) > 1 || Math.Abs(dy) > 1)
            {
                return 0;
            }
            return d[dx + 1][dy + 1];
        }

        public void DeleteMonster(int y, int x)
        {
            if (!InBounds(y, x))
            {
                return;
            }
            GridTile cPtr = Grid[y][x];
            if (cPtr.MonsterIndex != 0)
            {
                DeleteMonsterByIndex(cPtr.MonsterIndex, true);
            }
        }

        public void DeleteObject(Item jPtr)
        {
            ExciseObject(jPtr);
            if (jPtr.HoldingMonsterIndex == 0)
            {
                int y = jPtr.Y;
                int x = jPtr.X;
                RedrawSingleLocation(y, x);
            }
        }

        public void DisplayMap(out int cy, out int cx)
        {
            int x, y, maxy;
            Colour ta;
            char tc;
            Colour[][] ma = new Colour[_mapHgt + 2][];
            for (int i = 0; i < _mapHgt + 2; i++)
            {
                ma[i] = new Colour[_mapWid + 2];
            }
            char[][] mc = new char[_mapHgt + 2][];
            for (int i = 0; i < _mapHgt + 2; i++)
            {
                mc[i] = new char[_mapWid + 2];
            }
            int[][] mp = new int[_mapHgt + 2][];
            for (int i = 0; i < _mapHgt + 2; i++)
            {
                mp[i] = new int[_mapWid + 2];
            }
            for (y = 0; y < _mapHgt + 2; ++y)
            {
                for (x = 0; x < _mapWid + 2; ++x)
                {
                    ma[y][x] = Colour.White;
                    mc[y][x] = ' ';
                    mp[y][x] = 0;
                }
            }
            int maxx = maxy = 0;
            for (int i = 0; i < CurWid; ++i)
            {
                for (int j = 0; j < CurHgt; ++j)
                {
                    x = (i / _ratio) + 1;
                    y = (j / _ratio) + 1;
                    if (x > maxx)
                    {
                        maxx = x;
                    }
                    if (y > maxy)
                    {
                        maxy = y;
                    }
                    MapInfo(j, i, out ta, out tc);
                    int tp = Grid[j][i].FeatureType.MapPriority;
                    if (ta == Colour.Background)
                    {
                        tp = 0;
                    }
                    if (mp[y][x] < tp)
                    {
                        mc[y][x] = tc;
                        ma[y][x] = ta;
                        mp[y][x] = tp;
                    }
                }
            }
            x = maxx + 1;
            y = maxy + 1;
            int xOffset = (80 - x) / 2;
            int yOffset = (44 - y) / 2;
            mc[0][0] = '+';
            ma[0][0] = Colour.Purple;
            mc[0][x] = '+';
            ma[0][x] = Colour.Purple;
            mc[y][0] = '+';
            ma[y][0] = Colour.Purple;
            mc[y][x] = '+';
            ma[y][x] = Colour.Purple;
            for (x = 1; x <= maxx; x++)
            {
                mc[0][x] = '-';
                ma[0][x] = Colour.Purple;
                mc[maxy + 1][x] = '-';
                ma[maxy + 1][x] = Colour.Purple;
            }
            for (y = 1; y <= maxy; y++)
            {
                mc[y][0] = '|';
                ma[y][0] = Colour.Purple;
                mc[y][maxx + 1] = '|';
                ma[y][maxx + 1] = Colour.Purple;
            }
            for (y = 0; y < maxy + 2; ++y)
            {
                SaveGame.Screen.Goto(yOffset + y, xOffset);
                for (x = 0; x < maxx + 2; ++x)
                {
                    ta = ma[y][x];
                    tc = mc[y][x];
                    if (SaveGame.Player.TimedInvulnerability.TurnsRemaining != 0)
                    {
                        ta = Colour.White;
                    }
                    else if (SaveGame.Player.TimedEtherealness.TurnsRemaining != 0)
                    {
                        ta = Colour.Black;
                    }
                    SaveGame.Screen.Print(ta, tc.ToString());
                }
            }
            cy = yOffset + (SaveGame.Player.MapY / _ratio) + 1;
            cx = xOffset + (SaveGame.Player.MapX / _ratio) + 1;
        }

        public int Distance(int y1, int x1, int y2, int x2)
        {
            int dy = y1 > y2 ? y1 - y2 : y2 - y1;
            int dx = x1 > x2 ? x1 - x2 : x2 - x1;
            int d = dy > dx ? dy + (dx >> 1) : dx + (dy >> 1);
            return d;
        }

        public void DropNear(Item jPtr, int chance, int y, int x)
        {
            int ty, tx;
            int thisOIdx, nextOIdx;
            GridTile cPtr;
            bool flag = false;
            bool done = false;
            bool plural = jPtr.Count != 1;
            string oName = jPtr.Description(false, 0);
            if (!(!string.IsNullOrEmpty(jPtr.RandartName) || jPtr.IsFixedArtifact()) && Program.Rng.RandomLessThan(100) < chance)
            {
                string p = plural ? "" : "s";
                SaveGame.MsgPrint($"The {oName} disappear{p}.");
                return;
            }
            int bs = -1;
            int bn = 0;
            int by = y;
            int bx = x;
            for (int dy = -3; dy <= 3; dy++)
            {
                for (int dx = -3; dx <= 3; dx++)
                {
                    bool comb = false;
                    int d = (dy * dy) + (dx * dx);
                    if (d > 10)
                    {
                        continue;
                    }
                    ty = y + dy;
                    tx = x + dx;
                    if (!InBounds(ty, tx))
                    {
                        continue;
                    }
                    if (!Los(y, x, ty, tx))
                    {
                        continue;
                    }
                    cPtr = Grid[ty][tx];
                    if (!cPtr.FeatureType.IsOpenFloor)
                    {
                        continue;
                    }
                    int k = 0;
                    foreach (Item oPtr in cPtr.Items)
                    {
                        if (oPtr.CanAbsorb(jPtr))
                        {
                            comb = true;
                        }
                        k++;
                    }
                    if (!comb)
                    {
                        k++;
                    }
                    if (k > 99)
                    {
                        continue;
                    }
                    int s = 1000 - (d + (k * 5));
                    if (s < bs)
                    {
                        continue;
                    }
                    if (s > bs)
                    {
                        bn = 0;
                    }
                    if (++bn >= 2 && Program.Rng.RandomLessThan(bn) != 0)
                    {
                        continue;
                    }
                    bs = s;
                    by = ty;
                    bx = tx;
                    flag = true;
                }
            }
            if (!flag && !(jPtr.IsFixedArtifact() || !string.IsNullOrEmpty(jPtr.RandartName)))
            {
                string p = plural ? "" : "s";
                SaveGame.MsgPrint($"The {oName} disappear{p}.");
                return;
            }
            for (int i = 0; !flag; i++)
            {
                if (i < 1000)
                {
                    ty = Program.Rng.RandomSpread(by, 1);
                    tx = Program.Rng.RandomSpread(bx, 1);
                }
                else
                {
                    ty = Program.Rng.RandomLessThan(CurHgt);
                    tx = Program.Rng.RandomLessThan(CurWid);
                }
                cPtr = Grid[ty][tx];
                if (!cPtr.FeatureType.IsOpenFloor)
                {
                    continue;
                }
                by = ty;
                bx = tx;
                if (!GridOpenNoItem(by, bx))
                {
                    continue;
                }
                flag = true;
            }
            cPtr = Grid[by][bx];
            foreach (Item oPtr in cPtr.Items)
            {
                if (oPtr.CanAbsorb(jPtr))
                {
                    oPtr.Absorb(jPtr);
                    done = true;
                    break;
                }
            }

            if (!done)
            {
                Item oPtr = jPtr.Clone();
                if (!SaveGame.AddItemToGrid(oPtr, bx, by))
                {
                    string p = plural ? "" : "s";
                    SaveGame.MsgPrint($"The {oName} disappear{p}.");
                    if (jPtr.FixedArtifactIndex != 0)
                    {
                        SaveGame.SingletonRepository.FixedArtifacts[jPtr.FixedArtifactIndex].CurNum = 0;
                    }
                    return;
                }
            }
            NoteSpot(by, bx);
            RedrawSingleLocation(by, bx);
            SaveGame.PlaySound(SoundEffect.Drop);
            if (chance != 0 && by == SaveGame.Player.MapY && bx == SaveGame.Player.MapX)
            {
                SaveGame.MsgPrint("You feel something roll beneath your feet.");
            }
        }

        public void ExciseObject(Item jPtr)
        {
            int thisOIdx, nextOIdx;
            int prevOIdx = 0;

            // Check to see if the object is being held by a monster.
            if (jPtr.HoldingMonsterIndex != 0)
            {
                // It is.  Get the monster.
                Monster mPtr = Monsters[jPtr.HoldingMonsterIndex];

                mPtr.Items.Remove(jPtr);
            }
            else
            {
                // The object is not being held by a monster.
                int y = jPtr.Y;
                int x = jPtr.X;
                GridTile cPtr = Grid[y][x];
                cPtr.Items.Remove(jPtr);
            }
        }

        public bool GridOpenNoItem(int y, int x)
        {
            return Grid[y][x].FeatureType.IsOpenFloor && Grid[y][x].Items.Count == 0;
        }

        public bool GridOpenNoItemOrCreature(int y, int x)
        {
            return Grid[y][x].FeatureType.IsOpenFloor && Grid[y][x].Items.Count == 0 && Grid[y][x].MonsterIndex == 0 && !(y == SaveGame.Player.MapY && x == SaveGame.Player.MapX);
        }

        public bool GridPassable(int y, int x)
        {
            return Grid[y][x].FeatureType.IsPassable;
        }

        public bool GridPassableNoCreature(int y, int x)
        {
            return GridPassable(y, x) && Grid[y][x].MonsterIndex == 0 && !(y == SaveGame.Player.MapY && x == SaveGame.Player.MapX);
        }

        public bool InBounds(int y, int x)
        {
            return y > 0 && x > 0 && y < CurHgt - 1 && x < CurWid - 1;
        }

        public bool InBounds2(int y, int x)
        {
            return y >= 0 && x >= 0 && y < CurHgt && x < CurWid;
        }

        public bool Los(int y1, int x1, int y2, int x2)
        {
            int tx, ty;
            int m;
            int dy = y2 - y1;
            int dx = x2 - x1;
            int ay = Math.Abs(dy);
            int ax = Math.Abs(dx);
            if (ax < 2 && ay < 2)
            {
                return true;
            }
            if (dx == 0)
            {
                if (dy > 0)
                {
                    for (ty = y1 + 1; ty < y2; ty++)
                    {
                        if (GridBlocksLos(ty, x1))
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    for (ty = y1 - 1; ty > y2; ty--)
                    {
                        if (GridBlocksLos(ty, x1))
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            if (dy == 0)
            {
                if (dx > 0)
                {
                    for (tx = x1 + 1; tx < x2; tx++)
                    {
                        if (GridBlocksLos(y1, tx))
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    for (tx = x1 - 1; tx > x2; tx--)
                    {
                        if (GridBlocksLos(y1, tx))
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            int sx = dx < 0 ? -1 : 1;
            int sy = dy < 0 ? -1 : 1;
            if (ax == 1)
            {
                if (ay == 2)
                {
                    if (!GridBlocksLos(y1 + sy, x1))
                    {
                        return true;
                    }
                }
            }
            else if (ay == 1)
            {
                if (ax == 2)
                {
                    if (!GridBlocksLos(y1, x1 + sx))
                    {
                        return true;
                    }
                }
            }
            int f2 = ax * ay;
            int f1 = f2 << 1;
            if (ax >= ay)
            {
                int qy = ay * ay;
                m = qy << 1;
                tx = x1 + sx;
                if (qy == f2)
                {
                    ty = y1 + sy;
                    qy -= f1;
                }
                else
                {
                    ty = y1;
                }
                while (x2 - tx != 0)
                {
                    if (GridBlocksLos(ty, tx))
                    {
                        return false;
                    }
                    qy += m;
                    if (qy < f2)
                    {
                        tx += sx;
                    }
                    else if (qy > f2)
                    {
                        ty += sy;
                        if (GridBlocksLos(ty, tx))
                        {
                            return false;
                        }
                        qy -= f1;
                        tx += sx;
                    }
                    else
                    {
                        ty += sy;
                        qy -= f1;
                        tx += sx;
                    }
                }
            }
            else
            {
                int qx = ax * ax;
                m = qx << 1;
                ty = y1 + sy;
                if (qx == f2)
                {
                    tx = x1 + sx;
                    qx -= f1;
                }
                else
                {
                    tx = x1;
                }
                while (y2 - ty != 0)
                {
                    if (GridBlocksLos(ty, tx))
                    {
                        return false;
                    }
                    qx += m;
                    if (qx < f2)
                    {
                        ty += sy;
                    }
                    else if (qx > f2)
                    {
                        tx += sx;
                        if (GridBlocksLos(ty, tx))
                        {
                            return false;
                        }
                        qx -= f1;
                        ty += sy;
                    }
                    else
                    {
                        tx += sx;
                        qx -= f1;
                        ty += sy;
                    }
                }
            }
            return true;
        }

        public void MapArea()
        {
            int y1 = PanelRowMin - Program.Rng.DieRoll(10);
            int y2 = PanelRowMax + Program.Rng.DieRoll(10);
            int x1 = PanelColMin - Program.Rng.DieRoll(20);
            int x2 = PanelColMax + Program.Rng.DieRoll(20);
            if (y1 < 1)
            {
                y1 = 1;
            }
            if (y2 > CurHgt - 2)
            {
                y2 = CurHgt - 2;
            }
            if (x1 < 1)
            {
                x1 = 1;
            }
            if (x2 > CurWid - 2)
            {
                x2 = CurWid - 2;
            }
            for (int y = y1; y <= y2; y++)
            {
                for (int x = x1; x <= x2; x++)
                {
                    GridTile cPtr = Grid[y][x];
                    if (!cPtr.FeatureType.IsWall)
                    {
                        if (!cPtr.FeatureType.IsOpenFloor)
                        {
                            cPtr.TileFlags.Set(GridTile.PlayerMemorised);
                        }
                        for (int i = 0; i < 8; i++)
                        {
                            cPtr = Grid[y + OrderedDirectionYOffset[i]][x + OrderedDirectionXOffset[i]];
                            if (cPtr.FeatureType.IsWall)
                            {
                                cPtr.TileFlags.Set(GridTile.PlayerMemorised);
                            }
                        }
                    }
                }
            }
            SaveGame.RedrawMapFlaggedAction.Set();
        }

        public void MoveCursorRelative(int row, int col)
        {
            row -= PanelRowPrt;
            col -= PanelColPrt;
            SaveGame.Screen.Goto(row, col);
        }

        public void MoveOneStepTowards(out int newY, out int newX, int currentY, int currentX, int startY, int startX, int targetY, int targetX)
        {
            newY = currentY;
            newX = currentX;
            int shift;
            int dY = newY < startY ? startY - newY : newY - startY;
            int dX = newX < startX ? startX - newX : newX - startX;
            int distance = dY > dX ? dY : dX;
            distance++;
            dY = targetY < startY ? startY - targetY : targetY - startY;
            dX = targetX < startX ? startX - targetX : targetX - startX;
            if (dY == 0 && dX == 0)
            {
                return;
            }
            if (dY > dX)
            {
                shift = ((distance * dX) + ((dY - 1) / 2)) / dY;
                newX = targetX < startX ? startX - shift : startX + shift;
                newY = targetY < startY ? startY - distance : startY + distance;
            }
            else
            {
                shift = ((distance * dY) + ((dX - 1) / 2)) / dX;
                newY = targetY < startY ? startY - shift : startY + shift;
                newX = targetX < startX ? startX - distance : startX + distance;
            }
        }

        public bool NoLight()
        {
            return !PlayerCanSeeBold(SaveGame.Player.MapY, SaveGame.Player.MapX);
        }

        public void NoteSpot(int y, int x)
        {
            GridTile cPtr = Grid[y][x];
            int nextOIdx;
            if (SaveGame.Player.TimedBlindness.TurnsRemaining != 0)
            {
                return;
            }
            if (cPtr.TileFlags.IsClear(GridTile.PlayerLit))
            {
                if (cPtr.TileFlags.IsClear(GridTile.IsVisible))
                {
                    return;
                }
                if (cPtr.TileFlags.IsClear(GridTile.SelfLit))
                {
                    return;
                }
            }
            foreach (Item oPtr in cPtr.Items)
            {
                oPtr.Marked = true;
            }
            if (cPtr.TileFlags.IsClear(GridTile.PlayerMemorised))
            {
                if (cPtr.FeatureType.IsOpenFloor)
                {
                    cPtr.TileFlags.Set(GridTile.PlayerMemorised);
                }
                else if (cPtr.FeatureType.IsPassable)
                {
                    cPtr.TileFlags.Set(GridTile.PlayerMemorised);
                }
                else if (cPtr.TileFlags.IsSet(GridTile.PlayerLit))
                {
                    cPtr.TileFlags.Set(GridTile.PlayerMemorised);
                }
                else
                {
                    int yy = y < SaveGame.Player.MapY ? y + 1 : y > SaveGame.Player.MapY ? y - 1 : y;
                    int xx = x < SaveGame.Player.MapX ? x + 1 : x > SaveGame.Player.MapX ? x - 1 : x;
                    if (Grid[yy][xx].TileFlags.IsSet(GridTile.SelfLit))
                    {
                        cPtr.TileFlags.Set(GridTile.PlayerMemorised);
                    }
                }
            }
        }

        public bool PanelContains(int y, int x)
        {
            return y >= PanelRowMin && y <= PanelRowMax && x >= PanelColMin && x <= PanelColMax;
        }

        public void PickTrap(int y, int x)
        {
            string feat;
            GridTile cPtr = Grid[y][x];
            if (cPtr.FeatureType.Name != "Invis")
            {
                return;
            }
            int trapType = Program.Rng.DieRoll(16);
            if (SaveGame.IsQuest(SaveGame.CurrentDepth))
            {
                trapType = Program.Rng.DieRoll(15);
            }
            if (SaveGame.CurrentDepth >= SaveGame.CurDungeon.MaxLevel)
            {
                trapType = Program.Rng.DieRoll(15);
            }
            switch (trapType)
            {
                case 1:
                    feat = "AcidTrap";
                    break;

                case 2:
                    feat = "FireTrap";
                    break;

                case 3:
                    feat = "StrDart";
                    break;

                case 4:
                    feat = "ConDart";
                    break;

                case 5:
                    feat = "DexDart";
                    break;

                case 6:
                    feat = "SlowDart";
                    break;

                case 7:
                    feat = "PoisonGas";
                    break;

                case 8:
                    feat = "ConfuseGas";
                    break;

                case 9:
                    feat = "SleepGas";
                    break;

                case 10:
                    feat = "BlindGas";
                    break;

                case 11:
                    feat = "SummonRune";
                    break;

                case 12:
                    feat = "TeleportRune";
                    break;

                case 13:
                    feat = "Pit";
                    break;

                case 14:
                    feat = "SpikedPit";
                    break;

                case 15:
                    feat = "PoisonPit";
                    break;

                default:
                    feat = "TrapDoor";
                    break;
            }
            CaveSetFeat(y, x, feat);
        }

        public void PlaceGold(int y, int x)
        {
            if (!InBounds(y, x))
            {
                return;
            }
            if (!GridOpenNoItem(y, x))
            {
                return;
            }
            Item oPtr = SaveGame.MakeGold();
            if (SaveGame.AddItemToGrid(oPtr, x, y))
            {
                NoteSpot(y, x);
                RedrawSingleLocation(y, x);
            }
        }

        public void PlaceObject(int y, int x, bool good, bool great)
        {
            if (!InBounds(y, x))
            {
                return;
            }
            if (!GridOpenNoItem(y, x))
            {
                return;
            }
            Item? qPtr = SaveGame.MakeObject(good, great, false);
            if (qPtr == null)
            {
                return;
            }

            if (SaveGame.AddItemToGrid(qPtr, x, y))
            {
                NoteSpot(y, x);
                RedrawSingleLocation(y, x);
            }
            else
            {
                if (qPtr.FixedArtifactIndex != 0)
                {
                    SaveGame.SingletonRepository.FixedArtifacts[qPtr.FixedArtifactIndex].CurNum = 0;
                }
            }
        }

        public void PlaceTrap(int y, int x)
        {
            if (!InBounds(y, x))
            {
                return;
            }
            if (!GridOpenNoItemOrCreature(y, x))
            {
                return;
            }
            CaveSetFeat(y, x, "Invis");
        }

        public bool PlayerCanSeeBold(int y, int x)
        {
            if (SaveGame.Player.TimedBlindness.TurnsRemaining != 0)
            {
                return false;
            }
            GridTile cPtr = Grid[y][x];
            if (cPtr.TileFlags.IsSet(GridTile.PlayerLit))
            {
                return true;
            }
            if (!PlayerHasLosBold(y, x))
            {
                return false;
            }
            if (cPtr.TileFlags.IsClear(GridTile.SelfLit))
            {
                return false;
            }
            if (GridPassable(y, x))
            {
                return true;
            }
            int yy = y < SaveGame.Player.MapY ? y + 1 : y > SaveGame.Player.MapY ? y - 1 : y;
            int xx = x < SaveGame.Player.MapX ? x + 1 : x > SaveGame.Player.MapX ? x - 1 : x;
            return Grid[yy][xx].TileFlags.IsSet(GridTile.SelfLit);
        }

        public bool PlayerHasLosBold(int y, int x)
        {
            return Grid[y][x].TileFlags.IsSet(GridTile.IsVisible);
        }

        public void PrintCharacterAtMapLocation(char c, Colour a, int y, int x)
        {
            if (PanelContains(y, x))
            {
                if (SaveGame.Player.TimedInvulnerability.TurnsRemaining != 0)
                {
                    a = Colour.White;
                }
                else if (SaveGame.Player.TimedEtherealness.TurnsRemaining != 0)
                {
                    a = Colour.Black;
                }
                SaveGame.Screen.PutChar(a, c, y - PanelRowPrt, x - PanelColPrt);
            }
        }

        public bool Projectable(int y1, int x1, int y2, int x2)
        {
            int y = y1;
            int x = x1;
            for (int dist = 0; dist <= Constants.MaxRange; dist++)
            {
                if (x == x2 && y == y2)
                {
                    return true;
                }
                if (dist != 0 && !GridPassable(y, x) && Grid[y][x].FeatureType.Name != "YellowSign")
                {
                    break;
                }
                MoveOneStepTowards(out y, out x, y, x, y1, x1, y2, x2);
            }
            return false;
        }

        public void PutQuestMonster(int rIdx)
        {
            int y, x;
            if (SaveGame.SingletonRepository.MonsterRaces[rIdx].MaxNum == 0)
            {
                SaveGame.SingletonRepository.MonsterRaces[rIdx].MaxNum++;
                SaveGame.MsgPrint("Resurrecting guardian to fix corrupted savefile...");
            }
            do
            {
                while (true)
                {
                    y = Program.Rng.RandomLessThan(MaxHgt);
                    x = Program.Rng.RandomLessThan(MaxWid);
                    if (!GridOpenNoItemOrCreature(y, x))
                    {
                        continue;
                    }
                    {
                        if (Distance(y, x, SaveGame.Player.MapY, SaveGame.Player.MapX) > 15)
                        {
                            break;
                        }
                    }
                }
            } while (!PlaceMonsterByIndex(y, x, rIdx, false, false, false));
        }

        public void RedrawSingleLocation(int y, int x)
        {
            if (PanelContains(y, x))
            {
                Colour a;
                char c;
                {
                    MapInfo(y, x, out a, out c);
                }
                if (SaveGame.Player.TimedInvulnerability.TurnsRemaining != 0)
                {
                    a = Colour.White;
                }
                else if (SaveGame.Player.TimedEtherealness.TurnsRemaining != 0)
                {
                    a = Colour.Black;
                }
                SaveGame.Screen.Print(a, c, y - PanelRowPrt, x - PanelColPrt);
            }
        }

        public void ReplacePets(int y, int x, List<Monster> petList)
        {
            foreach (Monster monster in petList)
            {
                ReplacePet(y, x, monster);
            }
        }

        public void ReplaceSecretDoor(int y, int x)
        {
            int tmp = Program.Rng.RandomLessThan(400);
            if (tmp < 300)
            {
                CaveSetFeat(y, x, "LockedDoor0");
            }
            else if (tmp < 999)
            {
                CaveSetFeat(y, x, $"LockedDoor{Program.Rng.DieRoll(7)}");
            }
            else
            {
                CaveSetFeat(y, x, $"JammedDoor{Program.Rng.RandomLessThan(8)}");
            }
        }

        public void RevertTileToBackground(int y, int x)
        {
            GridTile cPtr = Grid[y][x];
            cPtr.RevertToBackground();
            NoteSpot(y, x);
            RedrawSingleLocation(y, x);
        }

        public void Scatter(out int yp, out int xp, int y, int x, int d)
        {
            int nx = 0;
            int ny = 0;
            yp = y;
            xp = x;
            int attemptsLeft = 5000;
            while (--attemptsLeft != 0)
            {
                ny = Program.Rng.RandomSpread(y, d);
                nx = Program.Rng.RandomSpread(x, d);
                if (!InBounds(y, x))
                {
                    continue;
                }
                if (d > 1 && Distance(y, x, ny, nx) > d)
                {
                    continue;
                }
                if (Los(y, x, ny, nx))
                {
                    break;
                }
            }
            if (attemptsLeft > 0)
            {
                yp = ny;
                xp = nx;
            }
        }

        public void WizDark()
        {
            for (int y = 0; y < CurHgt; y++)
            {
                for (int x = 0; x < CurWid; x++)
                {
                    GridTile cPtr = Grid[y][x];
                    cPtr.TileFlags.Clear(GridTile.PlayerMemorised);
                    foreach (Item oPtr in cPtr.Items)
                    {
                        oPtr.Marked = false;
                    }
                }
            }
            SaveGame.RemoveLightFlaggedAction.Set();
            SaveGame.RemoveViewFlaggedAction.Set();
            SaveGame.UpdateLightFlaggedAction.Set();
            SaveGame.UpdateViewFlaggedAction.Set();
            SaveGame.UpdateMonstersFlaggedAction.Set();
            SaveGame.RedrawMapFlaggedAction.Set();
        }

        public void WizLight()
        {
            for (int y = 1; y < CurHgt - 1; y++)
            {
                for (int x = 1; x < CurWid - 1; x++)
                {
                    GridTile cPtr = Grid[y][x];
                    if (!cPtr.FeatureType.IsWall)
                    {
                        for (int i = 0; i < 9; i++)
                        {
                            int yy = y + OrderedDirectionYOffset[i];
                            int xx = x + OrderedDirectionXOffset[i];
                            cPtr = Grid[yy][xx];
                            cPtr.TileFlags.Set(GridTile.SelfLit);
                            if (!cPtr.FeatureType.IsOpenFloor)
                            {
                                cPtr.TileFlags.Set(GridTile.PlayerMemorised);
                            }
                            cPtr.TileFlags.Set(GridTile.PlayerMemorised);
                        }
                    }
                    foreach (Item oPtr in cPtr.Items)
                    {
                        oPtr.Marked = true;    
                    }
                }
            }
            SaveGame.UpdateMonstersFlaggedAction.Set();
            SaveGame.RedrawMapFlaggedAction.Set();
        }

        private Colour DimColour(Colour a)
        {
            switch (a)
            {
                case Colour.BrightBlue:
                    return Colour.Blue;

                case Colour.BrightGreen:
                    return Colour.Green;

                case Colour.BrightRed:
                    return Colour.Red;

                case Colour.BrightWhite:
                    return Colour.White;

                case Colour.BrightBeige:
                    return Colour.Beige;

                case Colour.BrightChartreuse:
                    return Colour.Chartreuse;

                case Colour.BrightGrey:
                    return Colour.Grey;

                case Colour.BrightOrange:
                    return Colour.Orange;

                case Colour.BrightYellow:
                    return Colour.Yellow;

                case Colour.BrightBrown:
                    return Colour.Brown;

                case Colour.BrightTurquoise:
                    return Colour.Turquoise;

                case Colour.BrightPink:
                    return Colour.Pink;

                case Colour.Grey:
                    return Colour.Black;

                case Colour.White:
                    return Colour.Grey;

                case Colour.Yellow:
                    return Colour.BrightBrown;

                default:
                    return a;
            }
        }

        private bool GridBlocksLos(int y, int x)
        {
            return Grid[y][x].FeatureType.BlocksLos;
        }

        private void ImageMonster(out Colour ap, out char cp)
        {
            cp = SaveGame.SingletonRepository.MonsterRaces[Program.Rng.DieRoll(SaveGame.SingletonRepository.MonsterRaces.Count - 2)].Character;
            ap = SaveGame.SingletonRepository.MonsterRaces[Program.Rng.DieRoll(SaveGame.SingletonRepository.MonsterRaces.Count - 2)].Colour;
        }

        private void ImageObject(out Colour ap, out char cp)
        {
            cp = SaveGame.SingletonRepository.ItemCategories[Program.Rng.DieRoll(SaveGame.SingletonRepository.ItemCategories.Count - 1)].FlavorCharacter;
            ap = SaveGame.SingletonRepository.ItemCategories[Program.Rng.DieRoll(SaveGame.SingletonRepository.ItemCategories.Count - 1)].FlavorColour;
        }

        private void ImageRandom(out Colour ap, out char cp)
        {
            if (Program.Rng.RandomLessThan(100) < 75)
            {
                ImageMonster(out ap, out cp);
            }
            else
            {
                ImageObject(out ap, out cp);
            }
        }

        public void MapInfo(int y, int x, out Colour ap, out char cp)
        {
            int nextOIdx;
            Colour a;
            char c;
            GridTile cPtr = Grid[y][x];
            FloorTileType feat = cPtr.FeatureType;
            if (feat.IsOpenFloor)
            {
                if (cPtr.TileFlags.IsSet(GridTile.PlayerMemorised) ||
                    ((cPtr.TileFlags.IsSet(GridTile.PlayerLit) || (cPtr.TileFlags.IsSet(GridTile.SelfLit) &&
                     cPtr.TileFlags.IsSet(GridTile.IsVisible))) && SaveGame.Player.TimedBlindness.TurnsRemaining == 0))
                {
                    c = feat.Character;
                    a = feat.Colour;
                    if (feat.DimsOutsideLOS)
                    {
                        if (SaveGame.Player.TimedBlindness.TurnsRemaining != 0)
                        {
                            a = Colour.Black;
                        }
                        else if (cPtr.TileFlags.IsSet(GridTile.PlayerLit))
                        {
                            if (feat.YellowInTorchlight)
                            {
                                a = Colour.BrightYellow;
                            }
                        }
                        else if (cPtr.TileFlags.IsClear(GridTile.SelfLit))
                        {
                            a = Colour.Black;
                        }
                        else if (cPtr.TileFlags.IsClear(GridTile.IsVisible))
                        {
                            a = DimColour(a);
                        }
                        if (cPtr.TileFlags.IsSet(GridTile.TrapsDetected))
                        {
                            int count = 0;
                            if (Grid[y - 1][x].TileFlags.IsSet(GridTile.TrapsDetected))
                            {
                                count++;
                            }
                            if (Grid[y + 1][x].TileFlags.IsSet(GridTile.TrapsDetected))
                            {
                                count++;
                            }
                            if (Grid[y][x - 1].TileFlags.IsSet(GridTile.TrapsDetected))
                            {
                                count++;
                            }
                            if (Grid[y][x + 1].TileFlags.IsSet(GridTile.TrapsDetected))
                            {
                                count++;
                            }
                            if (count != 4)
                            {
                                a = Colour.BrightChartreuse;
                            }
                        }
                    }
                }
                else
                {
                    a = SaveGame.SingletonRepository.FloorTileTypes["Nothing"].Colour;
                    c = SaveGame.SingletonRepository.FloorTileTypes["Nothing"].Character;
                }
            }
            else
            {
                if (cPtr.TileFlags.IsSet(GridTile.PlayerMemorised))
                {
                    feat = string.IsNullOrEmpty(feat.AppearAs)
                        ? SaveGame.SingletonRepository.FloorTileTypes[cPtr.BackgroundFeature.AppearAs]
                        : SaveGame.SingletonRepository.FloorTileTypes[feat.AppearAs];
                    c = feat.Character;
                    a = feat.Colour;
                    if (feat.DimsOutsideLOS)
                    {
                        if (SaveGame.Player.TimedBlindness.TurnsRemaining != 0)
                        {
                            a = Colour.Black;
                        }
                        else if (cPtr.TileFlags.IsSet(GridTile.PlayerLit))
                        {
                            if (feat.YellowInTorchlight)
                            {
                                a = Colour.Yellow;
                            }
                        }
                        else
                        {
                            if (cPtr.TileFlags.IsClear(GridTile.IsVisible))
                            {
                                a = DimColour(a);
                            }
                            else if (cPtr.TileFlags.IsClear(GridTile.SelfLit))
                            {
                                a = DimColour(a);
                            }
                            else
                            {
                                int yy = y < SaveGame.Player.MapY ? y + 1 : y > SaveGame.Player.MapY ? y - 1 : y;
                                int xx = x < SaveGame.Player.MapX ? x + 1 : x > SaveGame.Player.MapX ? x - 1 : x;
                                if (Grid[yy][xx].TileFlags.IsClear(GridTile.SelfLit))
                                {
                                    a = DimColour(a);
                                }
                            }
                        }
                    }
                }
                else
                {
                    a = SaveGame.SingletonRepository.FloorTileTypes["Nothing"].Colour;
                    c = SaveGame.SingletonRepository.FloorTileTypes["Nothing"].Character;
                }
            }
            if (SaveGame.Player.TimedHallucinations.TurnsRemaining != 0 && Program.Rng.RandomLessThan(256) == 0 && (!cPtr.FeatureType.IsWall))
            {
                ImageRandom(out ap, out cp);
            }
            else
            {
                ap = a;
                cp = c;
            }
            foreach (Item oPtr in cPtr.Items)
            {
                if (oPtr.Marked)
                {
                    cp = oPtr.BaseItemCategory.FlavorCharacter;
                    ap = oPtr.BaseItemCategory.FlavorColour;
                    if (SaveGame.Player.TimedHallucinations.TurnsRemaining != 0)
                    {
                        ImageObject(out ap, out cp);
                    }
                    break;
                }
            }
            if (cPtr.MonsterIndex != 0)
            {
                Monster mPtr = Monsters[cPtr.MonsterIndex];
                if (mPtr.IsVisible)
                {
                    MonsterRace rPtr = mPtr.Race;
                    a = rPtr.Colour;
                    c = rPtr.Character;
                    if (rPtr.AttrMulti)
                    {
                        if (rPtr.Shapechanger)
                        {
                            cp = Program.Rng.DieRoll(25) == 1
                                ? _imageObjectHack[Program.Rng.RandomLessThan(_imageObjectHack.Length)]
                                : _imageMonsterHack[Program.Rng.RandomLessThan(_imageMonsterHack.Length)];
                        }
                        else
                        {
                            cp = c;
                        }
                        if (rPtr.AttrAny)
                        {
                            ap = (Colour)Program.Rng.DieRoll(15);
                        }
                        else
                        {
                            switch (Program.Rng.DieRoll(7))
                            {
                                case 1:
                                    ap = Colour.Red;
                                    break;

                                case 2:
                                    ap = Colour.BrightRed;
                                    break;

                                case 3:
                                    ap = Colour.White;
                                    break;

                                case 4:
                                    ap = Colour.BrightGreen;
                                    break;

                                case 5:
                                    ap = Colour.Blue;
                                    break;

                                case 6:
                                    ap = Colour.Black;
                                    break;

                                case 7:
                                    ap = Colour.Green;
                                    break;
                            }
                        }
                    }
                    else if (!rPtr.AttrClear && !rPtr.CharClear)
                    {
                        cp = c;
                        ap = a;
                    }
                    else
                    {
                        if (!rPtr.CharClear)
                        {
                            cp = c;
                        }
                        else if (!rPtr.AttrClear)
                        {
                            ap = a;
                        }
                    }
                    if (SaveGame.Player.TimedHallucinations.TurnsRemaining != 0)
                    {
                        ImageMonster(out ap, out cp);
                    }
                }
            }
            if (y == SaveGame.Player.MapY && x == SaveGame.Player.MapX)
            {
                MonsterRace rPtr = SaveGame.SingletonRepository.MonsterRaces[0];
                a = rPtr.Colour;
                c = rPtr.Character;
                ap = a;
                cp = c;
            }
        }

        ///////////////////////////////////
        public int CurrentlyActingMonster;
        public MonsterSelector? DunBias = null; // The dungeon does not have a bias for monsters.
        public int NumRepro;
        public bool RepairMonsters;
        public bool ShimmerMonsters;

        public readonly Monster[] Monsters;
        private int _hackMIdxIi;

        public void ProcessWorld()
        {
            foreach (Monster monster in Monsters)
            {
                monster.ProcessWorld();
            }
        }

        /// <summary>
        /// Returns the index of this monster in the monster list.  This method is provided for backwards compatability and should NOT be used.  Will be deleted when no longer needed.
        /// </summary>
        /// <param name="monster"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public int GetMonsterIndex(Monster monster) // TODO: Needs to be removed.
        {
            for (int i = 0; i < Monsters.Length; i++)
            {
                if (Monsters[i] == monster)
                    return i;
            }
            throw new Exception("Internal error monster not found for get monster index.");
        }
        public bool AllocHorde(int y, int x)
        {
            MonsterRace rPtr = null;
            int attempts = 1000;
            while (--attempts != 0)
            {
                int rIdx = GetMonNum(SaveGame.Level.MonsterLevel, null);
                if (rIdx == 0)
                {
                    return false;
                }
                rPtr = SaveGame.SingletonRepository.MonsterRaces[rIdx];
                if (!rPtr.Unique && !rPtr.EscortsGroup)
                {
                    break;
                }
            }
            if (attempts < 1)
            {
                return false;
            }
            attempts = 1000;
            while (--attempts == 0)
            {
                if (PlaceMonsterAux(y, x, rPtr, false, false, false))
                {
                    break;
                }
            }
            if (attempts < 1)
            {
                return false;
            }
            Monster mPtr = Monsters[_hackMIdxIi];
            for (attempts = Program.Rng.DieRoll(10) + 5; attempts != 0; attempts--)
            {
                SummonSpecific(mPtr.MapY, mPtr.MapX, SaveGame.Difficulty, new KinMonsterSelector(rPtr.Character));
            }
            return true;
        }

        public void AllocMonster(int dis, bool slp)
        {
            int y = 0;
            int x = 0;
            int attemptsLeft = 10000;
            while (attemptsLeft != 0)
            {
                y = Program.Rng.RandomLessThan(SaveGame.Level.CurHgt);
                x = Program.Rng.RandomLessThan(SaveGame.Level.CurWid);
                if (!SaveGame.Level.GridOpenNoItemOrCreature(y, x))
                {
                    continue;
                }
                if (SaveGame.Level.Distance(y, x, SaveGame.Player.MapY, SaveGame.Player.MapX) > dis)
                {
                    break;
                }
                attemptsLeft--;
            }
            if (attemptsLeft == 0)
            {
                return;
            }
            if (Program.Rng.DieRoll(5000) <= SaveGame.Difficulty)
            {
                if (AllocHorde(y, x))
                {
                }
            }
            else
            {
                if (DunBias != null && Program.Rng.RandomBetween(1, 10) > 6)
                {
                    if (SummonSpecific(y, x, SaveGame.Difficulty, DunBias))
                    {
                    }
                }
                else
                {
                    if (PlaceMonster(y, x, slp, true))
                    {
                    }
                }
            }
        }

        public void CompactMonsters(int size)
        {
            int i, num, cnt;
            if (size != 0)
            {
                SaveGame.MsgPrint("Compacting monsters...");
            }
            for (num = 0, cnt = 1; num < size; cnt++)
            {
                int curLev = 5 * cnt;
                int curDis = 5 * (20 - cnt);
                for (i = 1; i < SaveGame.Level.MMax; i++)
                {
                    Monster mPtr = Monsters[i];
                    MonsterRace rPtr = mPtr.Race;
                    if (mPtr.Race == null)
                    {
                        continue;
                    }
                    if (rPtr.Level > curLev)
                    {
                        continue;
                    }
                    if (curDis > 0 && mPtr.DistanceFromPlayer < curDis)
                    {
                        continue;
                    }
                    int chance = 90;
                    if (rPtr.Unique)
                    {
                        chance = 99;
                    }
                    if (rPtr.Guardian && cnt < 1000)
                    {
                        chance = 100;
                    }
                    if (Program.Rng.RandomLessThan(100) < chance)
                    {
                        continue;
                    }
                    DeleteMonsterByIndex(i, true);
                    num++;
                }
            }
            for (i = SaveGame.Level.MMax - 1; i >= 1; i--)
            {
                Monster mPtr = Monsters[i];
                if (mPtr.Race != null)
                {
                    continue;
                }
                CompactMonstersAux(SaveGame.Level.MMax - 1, i);
                SaveGame.Level.MMax--;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mIdx"></param>
        /// <param name="dam"></param>
        /// <param name="fear"></param>
        /// <param name="note"></param>
        /// <returns>True, if the monster dies; false, otherwise.</returns>
        public bool DamageMonster(int mIdx, int dam, out bool fear, string note)
        {
            fear = false;
            Monster mPtr = Monsters[mIdx];
            MonsterRace rPtr = mPtr.Race;
            if (SaveGame.TrackedMonsterIndex == mIdx)
            {
                SaveGame.RedrawHealthFlaggedAction.Set();
            }
            mPtr.SleepLevel = 0;
            mPtr.Health -= dam;
            if (mPtr.Health < 0)
            {
                string mName = mPtr.Name;
                if (rPtr.GreatOldOne && Program.Rng.DieRoll(2) == 1)
                {
                    SaveGame.MsgPrint($"{mName} retreats into another dimension!");
                    if (Program.Rng.DieRoll(5) == 1)
                    {
                        int curses = 1 + Program.Rng.DieRoll(3);
                        SaveGame.MsgPrint("Nyarlathotep puts a terrible curse on you!");
                        SaveGame.Player.CurseEquipment(100, 50);
                        do
                        {
                            SaveGame.ActivateDreadCurse();
                        } while (--curses != 0);
                    }
                }
                SaveGame.PlaySound(SoundEffect.MonsterDies);
                if (string.IsNullOrEmpty(note) == false)
                {
                    SaveGame.MsgPrint($"{mName}{note}");
                }
                else if (!mPtr.IsVisible)
                {
                    SaveGame.MsgPrint($"You have killed {mName}.");
                }
                else if (rPtr.Demon || rPtr.Undead ||
                         rPtr.Cthuloid || rPtr.Stupid ||
                         rPtr.Nonliving || "Evg".Contains(rPtr.Character.ToString()))
                {
                    SaveGame.MsgPrint($"You have destroyed {mName}.");
                }
                else
                {
                    SaveGame.MsgPrint($"You have slain {mName}.");
                }
                int div = 10 * SaveGame.Player.MaxLevelGained;
                if (rPtr.Knowledge.RPkills >= 19)
                {
                    div *= 2;
                }
                if (rPtr.Knowledge.RPkills == 0)
                {
                    div /= 3;
                }
                if (rPtr.Knowledge.RPkills == 1)
                {
                    div /= 2;
                }
                if (rPtr.Knowledge.RPkills == 2)
                {
                    div /= 2;
                }
                if (div < 1)
                {
                    div = 1;
                }
                int newExp = rPtr.Mexp * rPtr.Level * 10 / div;
                int newExpFrac = (rPtr.Mexp * rPtr.Level % div * 0x10000 / div) + SaveGame.Player.FractionalExperiencePoints;
                if (newExpFrac >= 0x10000)
                {
                    newExp++;
                    SaveGame.Player.FractionalExperiencePoints = newExpFrac - 0x10000;
                }
                else
                {
                    SaveGame.Player.FractionalExperiencePoints = newExpFrac;
                }
                SaveGame.Player.GainExperience(newExp);
                SaveGame.MonsterDeath(mIdx);
                if (rPtr.Unique)
                {
                    rPtr.MaxNum = 0;
                }
                if (mPtr.IsVisible || rPtr.Unique)
                {
                    if (rPtr.Knowledge.RPkills < int.MaxValue)
                    {
                        rPtr.Knowledge.RPkills++;
                    }
                    if (rPtr.Knowledge.RTkills < int.MaxValue)
                    {
                        rPtr.Knowledge.RTkills++;
                    }
                }
                DeleteMonsterByIndex(mIdx, true);
                fear = false;
                return true;
            }
            if (mPtr.FearLevel != 0 && dam > 0)
            {
                int tmp = Program.Rng.DieRoll(dam);
                if (tmp < mPtr.FearLevel)
                {
                    mPtr.FearLevel -= tmp;
                }
                else
                {
                    mPtr.FearLevel = 0;
                    fear = false;
                }
            }
            if (mPtr.FearLevel == 0 && !rPtr.ImmuneFear)
            {
                int percentage = 100 * mPtr.Health / mPtr.MaxHealth;
                if ((percentage <= 10 && Program.Rng.RandomLessThan(10) < percentage) || (dam >= mPtr.Health && Program.Rng.RandomLessThan(100) < 80))
                {
                    fear = true;
                    mPtr.FearLevel = Program.Rng.DieRoll(10) + (dam >= mPtr.Health && percentage > 7 ? 20 : (11 - percentage) * 5);
                }
            }
            return false;
        }

        public void DeleteMonsterByIndex(int i, bool visibly)
        {
            Monster mPtr = Monsters[i];
            MonsterRace rPtr = mPtr.Race;
            if (rPtr == null)
            {
                return;
            }
            int nextOIdx;
            int y = mPtr.MapY;
            int x = mPtr.MapX;
            rPtr.CurNum--;
            if (rPtr.Multiply)
            {
                NumRepro--;
            }
            if (i == SaveGame.TargetWho)
            {
                SaveGame.TargetWho = 0;
            }
            if (i == SaveGame.TrackedMonsterIndex)
            {
                SaveGame.HealthTrack(0);
            }
            SaveGame.Level.Grid[y][x].MonsterIndex = 0;
            mPtr.Items.Clear();
            Monsters[i] = new Monster(SaveGame);
            SaveGame.Level.MCnt--;
            if (visibly)
            {
                SaveGame.Level.RedrawSingleLocation(y, x);
            }
        }

        /// <summary>
        /// Returns the index of a monster.
        /// </summary>
        /// <param name="level"></param>
        /// <param name="getMonNumHook"></param>
        /// <returns></returns>
        public int GetMonNum(int level, MonsterSelector? getMonNumHook)
        {
            int i, j;
            AllocationEntry[] table = SaveGame.AllocRaceTable;
            if (level > 0)
            {
                if (Program.Rng.RandomLessThan(Constants.NastyMon) == 0)
                {
                    int d = (level / 4) + 2;
                    level += d < 5 ? d : 5;
                }
                if (Program.Rng.RandomLessThan(Constants.NastyMon) == 0)
                {
                    int d = (level / 4) + 2;
                    level += d < 5 ? d : 5;
                }
            }
            int total = 0;
            for (i = 0; i < SaveGame.AllocRaceSize; i++)
            {
                if (table[i].Level > level)
                {
                    break;
                }
                table[i].FinalProbability = 0;
                if (level > 0 && table[i].Level <= 0)
                {
                    continue;
                }
                int rIdx = table[i].Index;
                MonsterRace rPtr = SaveGame.SingletonRepository.MonsterRaces[rIdx];

                // Do not allow more than 1 unique of this type to be created.
                if (rPtr.Unique && rPtr.CurNum >= rPtr.MaxNum)
                {
                    continue;
                }

                if (getMonNumHook == null || getMonNumHook.Matches(SaveGame, rPtr))
                {
                    table[i].FinalProbability = table[i].BaseProbability;
                }
                else
                {
                    table[i].FinalProbability = 0;
                }

                total += table[i].FinalProbability;
            }
            if (total <= 0)
            {
                return 0;
            }
            long value = Program.Rng.RandomLessThan(total);
            for (i = 0; i < SaveGame.AllocRaceSize; i++)
            {
                if (value < table[i].FinalProbability)
                {
                    break;
                }
                value -= table[i].FinalProbability;
            }
            int p = Program.Rng.RandomLessThan(100);
            if (p < 60)
            {
                j = i;
                value = Program.Rng.RandomLessThan(total);
                for (i = 0; i < SaveGame.AllocRaceSize; i++)
                {
                    if (value < table[i].FinalProbability)
                    {
                        break;
                    }
                    value -= table[i].FinalProbability;
                }
                if (table[i].Level < table[j].Level)
                {
                    i = j;
                }
            }
            if (p < 10)
            {
                j = i;
                value = Program.Rng.RandomLessThan(total);
                for (i = 0; i < SaveGame.AllocRaceSize; i++)
                {
                    if (value < table[i].FinalProbability)
                    {
                        break;
                    }
                    value -= table[i].FinalProbability;
                }
                if (table[i].Level < table[j].Level)
                {
                    i = j;
                }
            }
            return table[i].Index;
        }

        public List<Monster> GetPets()
        {
            List<Monster> list = new List<Monster>();
            foreach (Monster monster in Monsters)
            {
                if (monster.SmFriendly)
                {
                    list.Add(monster);
                }
            }
            return list;
        }

        public void LoreDoProbe(int mIdx)
        {
            Monster mPtr = Monsters[mIdx];
            MonsterRace rPtr = mPtr.Race;
            var knowledge = rPtr.Knowledge;
            if (rPtr.Attacks != null)
            {
                for (var m = 0; m < rPtr.Attacks.Length; m++)
                {
                    if (rPtr.Attacks[m].Effect != null || rPtr.Attacks[m].Method != null)
                    {
                        knowledge.RBlows[m] = Constants.MaxUchar;
                    }
                }
            }
            knowledge.RProbed = true;
            knowledge.RWake = Constants.MaxUchar;
            knowledge.RIgnore = Constants.MaxUchar;
            knowledge.RDropItem = (rPtr.Drop_4D2 ? 8 : 0) +
                                  (rPtr.Drop_3D2 ? 6 : 0) +
                                  (rPtr.Drop_2D2 ? 4 : 0) +
                                  (rPtr.Drop_1D2 ? 2 : 0) +
                                  (rPtr.Drop90 ? 1 : 0) +
                                  (rPtr.Drop60 ? 1 : 0);
            knowledge.RDropGold = knowledge.RDropItem;
            if (rPtr.OnlyDropGold)
            {
                knowledge.RDropItem = 0;
            }
            if (rPtr.OnlyDropItem)
            {
                knowledge.RDropGold = 0;
            }
            knowledge.RCastInate = Constants.MaxUchar;
            knowledge.RCastSpell = Constants.MaxUchar;
            knowledge.Characteristics = new MonsterCharacteristics(rPtr);
            knowledge.RSpells = rPtr.Spells;
        }

        public void LoreTreasure(int mIdx, int numItem, int numGold)
        {
            Monster mPtr = Monsters[mIdx];
            MonsterRace rPtr = mPtr.Race;
            if (numItem > rPtr.Knowledge.RDropItem)
            {
                rPtr.Knowledge.RDropItem = numItem;
            }
            if (numGold > rPtr.Knowledge.RDropGold)
            {
                rPtr.Knowledge.RDropGold = numGold;
            }
            if (rPtr.DropGood)
            {
                rPtr.Knowledge.Characteristics.DropGood = true;
            }
            if (rPtr.DropGreat)
            {
                rPtr.Knowledge.Characteristics.DropGreat = true;
            }
        }

        public void MessagePain(int mIdx, int dam)
        {
            Monster mPtr = Monsters[mIdx];
            MonsterRace rPtr = mPtr.Race;
            string mName = mPtr.Name;
            if (dam == 0)
            {
                SaveGame.MsgPrint($"{mName} is unharmed.");
                return;
            }
            long newhp = mPtr.Health;
            long oldhp = newhp + dam;
            long tmp = newhp * 100L / oldhp;
            int percentage = (int)tmp;
            if ("jmvQ".Contains(rPtr.Character.ToString()))
            {
                if (percentage > 95)
                {
                    SaveGame.MsgPrint($"{mName} barely notices.");
                }
                else if (percentage > 75)
                {
                    SaveGame.MsgPrint($"{mName} flinches.");
                }
                else if (percentage > 50)
                {
                    SaveGame.MsgPrint($"{mName} squelches.");
                }
                else if (percentage > 35)
                {
                    SaveGame.MsgPrint($"{mName} quivers in pain.");
                }
                else if (percentage > 20)
                {
                    SaveGame.MsgPrint($"{mName} writhes about.");
                }
                else if (percentage > 10)
                {
                    SaveGame.MsgPrint($"{mName} writhes in agony.");
                }
                else
                {
                    SaveGame.MsgPrint($"{mName} jerks limply.");
                }
            }
            else if ("CZ".Contains(rPtr.Character.ToString()))
            {
                if (percentage > 95)
                {
                    SaveGame.MsgPrint($"{mName} shrugs off the attack.");
                }
                else if (percentage > 75)
                {
                    SaveGame.MsgPrint($"{mName} snarls with pain.");
                }
                else if (percentage > 50)
                {
                    SaveGame.MsgPrint($"{mName} yelps in pain.");
                }
                else if (percentage > 35)
                {
                    SaveGame.MsgPrint($"{mName} howls in pain.");
                }
                else if (percentage > 20)
                {
                    SaveGame.MsgPrint($"{mName} howls in agony.");
                }
                else if (percentage > 10)
                {
                    SaveGame.MsgPrint($"{mName} writhes in agony.");
                }
                else
                {
                    SaveGame.MsgPrint($"{mName} yelps feebly.");
                }
            }
            else if ("FIKMRSXabclqrst".Contains(rPtr.Character.ToString()))
            {
                if (percentage > 95)
                {
                    SaveGame.MsgPrint($"{mName} ignores the attack.");
                }
                else if (percentage > 75)
                {
                    SaveGame.MsgPrint($"{mName} grunts with pain.");
                }
                else if (percentage > 50)
                {
                    SaveGame.MsgPrint($"{mName} squeals in pain.");
                }
                else if (percentage > 35)
                {
                    SaveGame.MsgPrint($"{mName} shrieks in pain.");
                }
                else if (percentage > 20)
                {
                    SaveGame.MsgPrint($"{mName} shrieks in agony.");
                }
                else if (percentage > 10)
                {
                    SaveGame.MsgPrint($"{mName} writhes in agony.");
                }
                else
                {
                    SaveGame.MsgPrint($"{mName} cries out feebly.");
                }
            }
            else
            {
                if (percentage > 95)
                {
                    SaveGame.MsgPrint($"{mName} shrugs off the attack.");
                }
                else if (percentage > 75)
                {
                    SaveGame.MsgPrint($"{mName} grunts with pain.");
                }
                else if (percentage > 50)
                {
                    SaveGame.MsgPrint($"{mName} cries out in pain.");
                }
                else if (percentage > 35)
                {
                    SaveGame.MsgPrint($"{mName} screams in pain.");
                }
                else if (percentage > 20)
                {
                    SaveGame.MsgPrint($"{mName} screams in agony.");
                }
                else if (percentage > 10)
                {
                    SaveGame.MsgPrint($"{mName} writhes in agony.");
                }
                else
                {
                    SaveGame.MsgPrint($"{mName} cries out feebly.");
                }
            }
        }

        public bool MultiplyMonster(Monster mPtr, bool charm, bool clone)
        {
            bool result = false;
            for (int i = 0; i < 18; i++)
            {
                int d = 1;
                SaveGame.Level.Scatter(out int y, out int x, mPtr.MapY, mPtr.MapX, d);
                if (!SaveGame.Level.GridPassableNoCreature(y, x))
                {
                    continue;
                }
                result = PlaceMonsterAux(y, x, mPtr.Race, false, false, charm);
                break;
            }
            if (clone && result)
            {
                Monsters[_hackMIdxIi].SmCloned = true;
            }
            mPtr.Generation++;
            Monsters[_hackMIdxIi].Generation = mPtr.Generation;
            return result;
        }

        public bool PlaceMonster(int y, int x, bool slp, bool grp)
        {
            int rIdx = GetMonNum(SaveGame.Level.MonsterLevel, null);
            if (rIdx == 0)
            {
                return false;
            }
            if (PlaceMonsterByIndex(y, x, rIdx, slp, grp, false))
            {
                return true;
            }
            return false;
        }

        public bool PlaceMonsterAux(int y, int x, MonsterRace rPtr, bool slp, bool grp, bool charm)
        {
            if (!PlaceMonsterOne(y, x, rPtr, slp, charm))
            {
                return false;
            }
            if (rPtr.Escorted)
            {
                for (int i = 0; i < 50; i++)
                {
                    int d = 3;
                    SaveGame.Level.Scatter(out int ny, out int nx, y, x, d);
                    if (!SaveGame.Level.GridPassableNoCreature(ny, nx))
                    {
                        continue;
                    }
                    int z = GetMonNum(rPtr.Level, new PlaceMonsterOkayMonsterSelector(rPtr.Index));
                    if (z == 0)
                    {
                        break;
                    }
                    MonsterRace race = SaveGame.SingletonRepository.MonsterRaces[z];
                    PlaceMonsterOne(ny, nx, race, slp, charm);
                    if (race.Friends ||
                        rPtr.EscortsGroup)
                    {
                        PlaceMonsterGroup(ny, nx, z, slp, charm);
                    }
                }
            }
            if (!grp)
            {
                return true;
            }
            if (rPtr.Friends)
            {
                PlaceMonsterGroup(y, x, rPtr.Index, slp, charm);
            }
            return true;
        }

        public bool PlaceMonsterByIndex(int y, int x, int index, bool slp, bool grp, bool charm)
        {
            return PlaceMonsterAux(y, x, SaveGame.SingletonRepository.MonsterRaces[index], slp, grp, charm);
        }

        public void ReplacePet(int y1, int x1, Monster monster)
        {
            int i;
            int x = x1;
            int y = y1;
            for (i = 0; i < 20; ++i)
            {
                int d = (i / 15) + 1;
                SaveGame.Level.Scatter(out y, out x, y1, x1, d);
                if (!SaveGame.Level.GridPassableNoCreature(y, x))
                {
                    continue;
                }
                if (SaveGame.Level.Grid[y][x].FeatureType.Category == FloorTileTypeCategory.Sigil)
                {
                    continue;
                }
                break;
            }
            if (i == 20)
            {
                SaveGame.MsgPrint($"You lose sight of {monster.Name}.");
                return;
            }
            GridTile cPtr = SaveGame.Level.Grid[y][x];
            cPtr.MonsterIndex = MPop();
            if (cPtr.MonsterIndex == 0)
            {
                SaveGame.MsgPrint($"You lose sight of {monster.Name}.");
                return;
            }
            Monsters[cPtr.MonsterIndex] = monster;
            monster.MapY = y;
            monster.MapX = x;
            MonsterRace rPtr = monster.Race;
            if (rPtr.Multiply)
            {
                NumRepro++;
            }
            if (rPtr.AttrMulti)
            {
                ShimmerMonsters = true;
            }
        }

        public bool SummonSpecific(int y1, int x1, int lev, MonsterSelector? monsterSelector, bool groupOk = true)
        {
            int i;
            int x = x1;
            int y = y1;
            for (i = 0; i < 20; ++i)
            {
                int d = (i / 15) + 1;
                SaveGame.Level.Scatter(out y, out x, y1, x1, d);
                if (!SaveGame.Level.GridPassableNoCreature(y, x))
                {
                    continue;
                }
                if (SaveGame.Level.Grid[y][x].FeatureType.Category == FloorTileTypeCategory.Sigil)
                {
                    continue;
                }
                break;
            }
            if (i == 20)
            {
                return false;
            }
            int rIdx = GetMonNum(((SaveGame.Difficulty + lev) / 2) + 5, monsterSelector);
            if (rIdx == 0)
            {
                return false;
            }
            MonsterRace race = SaveGame.SingletonRepository.MonsterRaces[rIdx];
            if (!PlaceMonsterAux(y, x, race, false, groupOk, false))
            {
                return false;
            }
            return true;
        }

        public bool SummonSpecificFriendly(int y1, int x1, int lev, MonsterSelector? monsterSelector, bool groupOk) // TODO: The floor Sigil and Charm are the only differences from SummonSpecific.
        {
            int i;
            int x = 0;
            int y = 0;
            for (i = 0; i < 20; ++i)
            {
                int d = (i / 15) + 1;
                SaveGame.Level.Scatter(out y, out x, y1, x1, d);
                if (!SaveGame.Level.GridPassableNoCreature(y, x))
                {
                    continue;
                }
                if (SaveGame.Level.Grid[y][x].FeatureType.Name == "ElderSign")
                {
                    continue;
                }
                if (SaveGame.Level.Grid[y][x].FeatureType.Name == "YellowSign")
                {
                    continue;
                }
                break;
            }
            if (i == 20)
            {
                return false;
            }
            int rIdx = GetMonNum(((SaveGame.Difficulty + lev) / 2) + 5, monsterSelector);
            if (rIdx == 0)
            {
                return false;
            }
            MonsterRace race = SaveGame.SingletonRepository.MonsterRaces[rIdx];
            if (!PlaceMonsterAux(y, x, race, false, groupOk, true))
            {
                return false;
            }
            return true;
        }

        public void UpdateMonsterVisibility(int mIdx, bool full)
        {
            Monster mPtr = Monsters[mIdx];
            MonsterRace rPtr = mPtr.Race;
            if (rPtr == null)
            {
                return;
            }
            int fy = mPtr.MapY;
            int fx = mPtr.MapX;
            if (full)
            {
                int dy = SaveGame.Player.MapY > fy
                    ? SaveGame.Player.MapY - fy
                    : fy - SaveGame.Player.MapY;
                int dx = SaveGame.Player.MapX > fx
                    ? SaveGame.Player.MapX - fx
                    : fx - SaveGame.Player.MapX;
                int d = dy > dx ? dy + (dx >> 1) : dx + (dy >> 1);
                mPtr.DistanceFromPlayer = d < 255 ? d : 255;
            }
            bool flag = false;
            bool easy = false;
            bool hard = false;
            bool doEmptyMind = false;
            bool doWeirdMind = false;
            bool doInvisible = false;
            bool doColdBlood = false;
            bool oldMl = mPtr.IsVisible;
            if (mPtr.DistanceFromPlayer > Constants.MaxSight)
            {
                if (!mPtr.IsVisible)
                {
                    return;
                }
                if ((mPtr.IndividualMonsterFlags & Constants.MflagMark) != 0)
                {
                    flag = true;
                }
            }
            else if (SaveGame.Level.PanelContains(fy, fx))
            {
                GridTile cPtr = SaveGame.Level.Grid[fy][fx];
                if (cPtr.TileFlags.IsSet(GridTile.IsVisible) && SaveGame.Player.TimedBlindness.TurnsRemaining == 0)
                {
                    if (mPtr.DistanceFromPlayer <= SaveGame.Player.InfravisionRange)
                    {
                        if (rPtr.ColdBlood)
                        {
                            doColdBlood = true;
                        }
                        if (!doColdBlood)
                        {
                            easy = true;
                            flag = true;
                        }
                    }
                    if (cPtr.TileFlags.IsSet(GridTile.PlayerLit | GridTile.SelfLit))
                    {
                        if (rPtr.Invisible)
                        {
                            doInvisible = true;
                        }
                        if (!doInvisible || SaveGame.Player.HasSeeInvisibility)
                        {
                            easy = true;
                            flag = true;
                        }
                    }
                }
                if (SaveGame.Player.HasTelepathy)
                {
                    if (rPtr.EmptyMind)
                    {
                        doEmptyMind = true;
                    }
                    else if (rPtr.WeirdMind)
                    {
                        doWeirdMind = true;
                        if (Program.Rng.RandomLessThan(100) < 10)
                        {
                            hard = true;
                            flag = true;
                        }
                    }
                    else
                    {
                        hard = true;
                        flag = true;
                    }
                }
                if ((mPtr.IndividualMonsterFlags & Constants.MflagMark) != 0)
                {
                    flag = true;
                }
                if (SaveGame.Player.IsWizard)
                {
                    flag = true;
                }
            }
            if (flag)
            {
                if (!mPtr.IsVisible)
                {
                    mPtr.IsVisible = true;
                    SaveGame.Level.RedrawSingleLocation(fy, fx);
                    if (SaveGame.TrackedMonsterIndex == mIdx)
                    {
                        SaveGame.RedrawHealthFlaggedAction.Set();
                    }
                    if (rPtr.Knowledge.RSights < Constants.MaxShort)
                    {
                        rPtr.Knowledge.RSights++;
                    }
                }
                if (hard)
                {
                    if (rPtr.Smart)
                    {
                        rPtr.Knowledge.Characteristics.Smart = true;
                    }
                    if (rPtr.Stupid)
                    {
                        rPtr.Knowledge.Characteristics.Stupid = true;
                    }
                }
                if (doEmptyMind)
                {
                    rPtr.Knowledge.Characteristics.EmptyMind = true;
                }
                if (doWeirdMind)
                {
                    rPtr.Knowledge.Characteristics.WeirdMind = true;
                }
                if (doColdBlood)
                {
                    rPtr.Knowledge.Characteristics.ColdBlood = true;
                }
                if (doInvisible)
                {
                    rPtr.Knowledge.Characteristics.Invisible = true;
                }
            }
            else
            {
                if (mPtr.IsVisible)
                {
                    mPtr.IsVisible = false;
                    SaveGame.Level.RedrawSingleLocation(fy, fx);
                    if (SaveGame.TrackedMonsterIndex == mIdx)
                    {
                        SaveGame.RedrawHealthFlaggedAction.Set();
                    }
                }
            }
            if (easy)
            {
                if (mPtr.IsVisible != oldMl)
                {
                    if (rPtr.EldritchHorror)
                    {
                        mPtr.SanityBlast(SaveGame, false);
                    }
                }
                if ((mPtr.IndividualMonsterFlags & Constants.MflagView) == 0)
                {
                    mPtr.IndividualMonsterFlags |= Constants.MflagView;
                    if (!mPtr.SmFriendly)
                    {
                        SaveGame.Disturb(true);
                    }
                }
            }
            else
            {
                if ((mPtr.IndividualMonsterFlags & Constants.MflagView) != 0)
                {
                    mPtr.IndividualMonsterFlags &= ~Constants.MflagView;
                    if (!mPtr.SmFriendly)
                    {
                        SaveGame.Disturb(true);
                    }
                }
            }
        }

        public void UpdateSmartLearn(Monster monster, SpellResistantDetection what)
        {
            MonsterRace rPtr = monster.Race;
            if (rPtr == null)
            {
                return;
            }
            if (rPtr.Stupid)
            {
                return;
            }
            if (!rPtr.Smart && Program.Rng.RandomLessThan(100) < 50)
            {
                return;
            }
            what.Learn(SaveGame, monster);
        }

        public void WipeMList()
        {
            for (int i = SaveGame.Level.MMax - 1; i >= 1; i--)
            {
                Monster mPtr = Monsters[i];
                MonsterRace rPtr = mPtr.Race;
                if (mPtr.Race == null)
                {
                    continue;
                }
                rPtr.CurNum--;
                SaveGame.Level.Grid[mPtr.MapY][mPtr.MapX].MonsterIndex = 0;
                Monsters[i] = new Monster(SaveGame);
            }
            SaveGame.Level.MMax = 1;
            SaveGame.Level.MCnt = 0;
            NumRepro = 0;
            SaveGame.TargetWho = 0;
            SaveGame.HealthTrack(0);
        }

        private void CompactMonstersAux(int i1, int i2)
        {
            if (i1 == i2)
            {
                return;
            }
            Monster mPtr = Monsters[i1];
            int y = mPtr.MapY;
            int x = mPtr.MapX;
            GridTile cPtr = SaveGame.Level.Grid[y][x];
            cPtr.MonsterIndex = i2;
            Monster mPtr2 = Monsters[i2];
            mPtr2.Items.AddRange(mPtr.Items);
            if (SaveGame.TargetWho == i1)
            {
                SaveGame.TargetWho = i2;
            }
            if (SaveGame.TrackedMonsterIndex == i1)
            {
                SaveGame.HealthTrack(i2);
            }
            Monsters[i2] = Monsters[i1];
            Monsters[i1] = new Monster(SaveGame);
        }

        private int MPop()
        {
            int i;
            if (SaveGame.Level.MMax < Constants.MaxMIdx)
            {
                i = SaveGame.Level.MMax;
                SaveGame.Level.MMax++;
                SaveGame.Level.MCnt++;
                return i;
            }
            for (i = 1; i < SaveGame.Level.MMax; i++)
            {
                Monster mPtr = Monsters[i];
                if (mPtr.Race != null)
                {
                    continue;
                }
                SaveGame.Level.MCnt++;
                return i;
            }
            if (SaveGame.Level != null)
            {
                SaveGame.MsgPrint("Too many monsters!");
            }
            return 0;
        }

        private void PlaceMonsterGroup(int y, int x, int rIdx, bool slp, bool charm)
        {
            MonsterRace rPtr = SaveGame.SingletonRepository.MonsterRaces[rIdx];
            int extra = 0;
            int[] hackY = new int[Constants.GroupMax];
            int[] hackX = new int[Constants.GroupMax];
            int total = Program.Rng.DieRoll(13);
            if (rPtr.Level > SaveGame.Difficulty)
            {
                extra = rPtr.Level - SaveGame.Difficulty;
                extra = 0 - Program.Rng.DieRoll(extra);
            }
            else if (rPtr.Level < SaveGame.Difficulty)
            {
                extra = SaveGame.Difficulty - rPtr.Level;
                extra = Program.Rng.DieRoll(extra);
            }
            if (extra > 12)
            {
                extra = 12;
            }
            total += extra;
            if (total < 1)
            {
                total = 1;
            }
            if (total > Constants.GroupMax)
            {
                total = Constants.GroupMax;
            }
            int old = SaveGame.Level.DangerRating;
            int hackN = 1;
            hackX[0] = x;
            hackY[0] = y;
            for (int n = 0; n < hackN && hackN < total; n++)
            {
                int hx = hackX[n];
                int hy = hackY[n];
                for (int i = 0; i < 8 && hackN < total; i++)
                {
                    int mx = hx + SaveGame.Level.OrderedDirectionXOffset[i];
                    int my = hy + SaveGame.Level.OrderedDirectionYOffset[i];
                    if (!SaveGame.Level.GridPassableNoCreature(my, mx))
                    {
                        continue;
                    }
                    if (PlaceMonsterOne(my, mx, rPtr, slp, charm))
                    {
                        hackY[hackN] = my;
                        hackX[hackN] = mx;
                        hackN++;
                    }
                }
            }
            SaveGame.Level.DangerRating = old;
        }

        private bool PlaceMonsterOne(int y, int x, MonsterRace rPtr, bool slp, bool charm)
        {
            if (rPtr == null)
            {
                return false;
            }
            if (rPtr.Name.StartsWith("Player"))
            {
                return false;
            }
            string name = rPtr.Name;
            if (!SaveGame.Level.InBounds(y, x))
            {
                return false;
            }
            if (!SaveGame.Level.GridPassableNoCreature(y, x))
            {
                return false;
            }
            if (SaveGame.Level.Grid[y][x].FeatureType.Category == FloorTileTypeCategory.Sigil)
            {
                return false;
            }
            if (string.IsNullOrEmpty(rPtr.Name))
            {
                return false;
            }
            if (rPtr.Unique && rPtr.CurNum >= rPtr.MaxNum)
            {
                return false;
            }
            if (rPtr.OnlyGuardian || rPtr.Guardian)
            {
                int qIdx = SaveGame.GetQuestNumber();
                if (qIdx < 0)
                {
                    return false;
                }
                if (rPtr.Index != SaveGame.Quests[qIdx].RIdx)
                {
                    return false;
                }
                if (rPtr.CurNum >= SaveGame.Quests[qIdx].ToKill - SaveGame.Quests[qIdx].Killed)
                {
                    return false;
                }
            }
            if (rPtr.Level > SaveGame.Difficulty)
            {
                if (rPtr.Unique)
                {
                    SaveGame.Level.DangerRating += (rPtr.Level - SaveGame.Difficulty) * 2;
                }
                else
                {
                    SaveGame.Level.DangerRating += rPtr.Level - SaveGame.Difficulty;
                }
            }
            GridTile cPtr = SaveGame.Level.Grid[y][x];
            cPtr.MonsterIndex = MPop();
            _hackMIdxIi = cPtr.MonsterIndex;
            if (cPtr.MonsterIndex == 0)
            {
                return false;
            }
            Monster mPtr = Monsters[cPtr.MonsterIndex];
            mPtr.Race = rPtr;
            mPtr.MapY = y;
            mPtr.MapX = x;
            mPtr.Generation = 1;
            mPtr.StunLevel = 0;
            mPtr.ConfusionLevel = 0;
            mPtr.FearLevel = 0;
            if (charm)
            {
                mPtr.SmFriendly = true;
            }
            mPtr.SleepLevel = 0;
            if (slp && rPtr.Sleep != 0)
            {
                int val = rPtr.Sleep;
                mPtr.SleepLevel = (val * 2) + Program.Rng.DieRoll(val * 10);
            }
            mPtr.DistanceFromPlayer = 0;
            mPtr.IndividualMonsterFlags = 0;
            mPtr.IsVisible = false;
            mPtr.MaxHealth = rPtr.ForceMaxHp
                ? Program.Rng.DiceRollMax(rPtr.Hdice, rPtr.Hside)
                : Program.Rng.DiceRoll(rPtr.Hdice, rPtr.Hside);
            mPtr.Health = mPtr.MaxHealth;
            mPtr.Speed = rPtr.Speed;
            if (!rPtr.Unique)
            {
                int i = Constants.ExtractEnergy[rPtr.Speed] / 10;
                if (i != 0)
                {
                    mPtr.Speed += Program.Rng.RandomSpread(0, i);
                }
            }
            mPtr.Energy = Program.Rng.RandomLessThan(100);
            if (rPtr.ForceSleep)
            {
                mPtr.IndividualMonsterFlags |= Constants.MflagNice;
                RepairMonsters = true;
            }
            if (cPtr.MonsterIndex < CurrentlyActingMonster)
            {
                mPtr.IndividualMonsterFlags |= Constants.MflagBorn;
            }
            UpdateMonsterVisibility(cPtr.MonsterIndex, true);
            rPtr.CurNum++;
            if (rPtr.Multiply)
            {
                NumRepro++;
            }
            if (rPtr.AttrMulti)
            {
                ShimmerMonsters = true;
            }
            return true;
        }
    }
}