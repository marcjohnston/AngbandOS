// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core;

[Serializable]
internal class StandardDungeonGenerator : DungeonGenerator
{
    private GridCoordinate[] Cent;
    private GridCoordinate[] Door;
    private bool[][] RoomMap;
    private GridCoordinate[] Tunn;
    private GridCoordinate[] Wall;
    private const int CentMax = 100;
    private const int DoorMax = 200;
    private const int _blockHgt = 21;
    private const int _blockWid = 11;
    private const int MaxRoomsCol = SaveGame.MaxWid / _blockWid;
    private const int MaxRoomsRow = SaveGame.MaxHgt / _blockHgt;
    private const int _allocSetBoth = 3;
    private const int _allocSetCorr = 1;
    private const int _allocSetRoom = 2;
    private const int _allocTypGold = 4;
    private const int _allocTypObject = 5;
    private const int _allocTypRubble = 1;
    private const int _allocTypTrap = 3;
    private const int _darkEmpty = 5;
    private const int _dunAmtGold = 3;
    private const int _dunAmtItem = 3;
    private const int _dunAmtRoom = 9;
    private const int _dunDest = 18;
    private const int _dunRooms = 50;
    private const int _dunStrDen = 5;
    private const int _dunStrMag = 3;
    private const int _dunStrMc = 90;
    private const int _dunStrQc = 40;
    private const int _dunStrQua = 2;
    private const int _dunStrRng = 2;
    private const int _dunTunChg = 30;
    private const int _dunTunCon = 15;
    private const int _dunTunJct = 90;
    private const int _dunTunPen = 25;
    private const int _dunTunRnd = 10;
    private const int _dunUnusual = 194;
    private const int _emptyLevel = 15;
    private const int TunnMax = 900;
    private const int WallMax = 500;

    private int CentN;
    private int ColRooms;
    private bool Crowded;
    private int DoorN;
    private int RowRooms;
    private int TunnN;
    private int WallN;

    public StandardDungeonGenerator(SaveGame saveGame) : base(saveGame) { }


    /// <summary>
    /// Generates an underground level.
    /// </summary>
    /// <returns></returns>
    public override bool GenerateDungeon()
    {
        ResetGuardians();
        if (SaveGame.IsQuest(SaveGame.CurrentDepth))
        {
            SaveGame.SingletonRepository.MonsterRaces[GetQuestMonster()].Guardian = true;
        }
        if (SaveGame.PercentileRoll(4) && !SaveGame.CurDungeon.Tower)
        {
            MakeCavernLevel();
        }
        else
        {
            MakeDungeonLevel();
        }

        // Generate downstairs.
        AllocStairs(SaveGame.SingletonRepository.Tiles.Get(nameof(DownStaircaseTile)), SaveGame.RandomBetween(3, 4), 3);

        // Generate upstairs.
        AllocStairs(SaveGame.SingletonRepository.Tiles.Get(nameof(UpStaircaseTile)), SaveGame.RandomBetween(1, 2), 3);

        // Choose a spot for the player.
        if (!SaveGame.NewPlayerSpot())
        {
            return false;
        }

        int k = SaveGame.Difficulty / 3;
        if (k > 10)
        {
            k = 10;
        }
        if (k < 2)
        {
            k = 2;
        }
        if (SaveGame.IsQuest(SaveGame.CurrentDepth))
        {
            int rIdx = GetQuestMonster();
            int qIdx = SaveGame.GetQuestNumber();
            while (SaveGame.SingletonRepository.MonsterRaces[rIdx].CurNum < (SaveGame.Quests[qIdx].ToKill - SaveGame.Quests[qIdx].Killed))
            {
                PutQuestMonster(SaveGame.Quests[qIdx].RIdx);
            }
        }
        int i = Constants.MinMAllocLevel;
        if (SaveGame.CurHgt < SaveGame.MaxHgt || SaveGame.CurWid < SaveGame.MaxWid)
        {
            int smallTester = i;
            i = i * SaveGame.CurHgt / SaveGame.MaxHgt;
            i = i * SaveGame.CurWid / SaveGame.MaxWid;
            i++;
            if (i > smallTester)
            {
                i = smallTester;
            }
        }
        i += SaveGame.DieRoll(8);
        for (i += k; i > 0; i--)
        {
            SaveGame.AllocMonster(0, true);
        }
        AllocObject(_allocSetBoth, _allocTypTrap, SaveGame.DieRoll(k));
        AllocObject(_allocSetCorr, _allocTypRubble, SaveGame.DieRoll(k));
        AllocObject(_allocSetRoom, _allocTypObject, SaveGame.RandomNormal(_dunAmtRoom, 3));
        AllocObject(_allocSetBoth, _allocTypObject, SaveGame.RandomNormal(_dunAmtItem, 3));
        AllocObject(_allocSetBoth, _allocTypGold, SaveGame.RandomNormal(_dunAmtGold, 3));
        return true;
    }

    private bool RoomBuild(int y0, int x0, RoomLayout roomType, int difficulty)
    {
        if (difficulty < roomType.Level)
        {
            return false;
        }
        if (Crowded && (roomType.Type == 5 || roomType.Type == 6))
        {
            return false;
        }
        int y1 = y0 + roomType.Dy1;
        int y2 = y0 + roomType.Dy2;
        int x1 = x0 + roomType.Dx1;
        int x2 = x0 + roomType.Dx2;
        if (y1 < 0 || y2 >= RowRooms)
        {
            return false;
        }
        if (x1 < 0 || x2 >= ColRooms)
        {
            return false;
        }
        int y;
        int x;
        for (y = y1; y <= y2; y++)
        {
            for (x = x1; x <= x2; x++)
            {
                if (RoomMap[y][x])
                {
                    return false;
                }
            }
        }
        y = (y1 + y2 + 1) * _blockHgt / 2;
        x = (x1 + x2 + 1) * _blockWid / 2;
        roomType.Build(y, x);
        if (CentN < CentMax)
        {
            Cent[CentN] = new GridCoordinate(x, y);
            CentN++;
        }
        for (y = y1; y <= y2; y++)
        {
            for (x = x1; x <= x2; x++)
            {
                RoomMap[y][x] = true;
            }
        }
        if (roomType.Type == 5 || roomType.Type == 6)
        {
            Crowded = true;
        }
        return true;
    }

    private void DestroyLevel()
    {
        Tile wallBasicTile = SaveGame.SingletonRepository.Tiles.Get(nameof(WallBasicTile));
        Tile quartzTile = SaveGame.SingletonRepository.Tiles.Get(nameof(QuartzTile));
        Tile magmaTile = SaveGame.SingletonRepository.Tiles.Get(nameof(MagmaTile));
        for (int n = 0; n < SaveGame.DieRoll(5); n++)
        {
            int x1 = SaveGame.RandomBetween(5, SaveGame.CurWid - 1 - 5);
            int y1 = SaveGame.RandomBetween(5, SaveGame.CurHgt - 1 - 5);
            int y;
            for (y = y1 - 15; y <= y1 + 15; y++)
            {
                int x;
                for (x = x1 - 15; x <= x1 + 15; x++)
                {
                    if (!SaveGame.InBounds(y, x))
                    {
                        continue;
                    }
                    int k = SaveGame.Distance(y1, x1, y, x);
                    if (k >= 16)
                    {
                        continue;
                    }
                    SaveGame.DeleteMonster(y, x);
                    if (SaveGame.CaveValidBold(y, x))
                    {
                        SaveGame.DeleteObject(y, x);
                        GridTile cPtr = SaveGame.Grid[y][x];
                        int t = SaveGame.RandomLessThan(200);
                        if (t < 20)
                        {
                            cPtr.SetFeature(wallBasicTile);
                        }
                        else if (t < 70)
                        {
                            cPtr.SetFeature(quartzTile);
                        }
                        else if (t < 100)
                        {
                            cPtr.SetFeature(magmaTile);
                        }
                        else
                        {
                            cPtr.RevertToBackground();
                        }
                        cPtr.TileFlags.Clear(GridTile.InRoom | GridTile.InVault);
                        cPtr.TileFlags.Clear(GridTile.PlayerMemorized | GridTile.SelfLit);
                    }
                }
            }
        }
    }

    private void BuildStreamer(Tile tile, int chance)
    {
        int dummy = 0;
        int y = SaveGame.RandomSpread(SaveGame.CurHgt / 2, 10);
        int x = SaveGame.RandomSpread(SaveGame.CurWid / 2, 15);
        int dir = SaveGame.OrderedDirection[SaveGame.RandomLessThan(8)];
        while (dummy < SaveGame.SafeMaxAttempts)
        {
            dummy++;
            for (int i = 0; i < _dunStrDen; i++)
            {
                const int d = _dunStrRng;
                int tx;
                int ty;
                while (true)
                {
                    ty = SaveGame.RandomSpread(y, d);
                    tx = SaveGame.RandomSpread(x, d);
                    if (!SaveGame.InBounds2(ty, tx))
                    {
                        continue;
                    }
                    break;
                }
                GridTile cPtr = SaveGame.Grid[ty][tx];

                if (!cPtr.FeatureType.IsBasicWall)
                {
                    continue;
                }
                cPtr.SetFeature(tile);
                if (SaveGame.RandomLessThan(chance) == 0)
                {
                    Tile? visibleTreasureTile = cPtr.FeatureType.VisibleTreasureForTile;
                    if (visibleTreasureTile == null)
                    {
                        throw new Exception("No visible treasure tile configured.");
                    }
                    cPtr.SetFeature(visibleTreasureTile);
                }
            }
            if (dummy >= SaveGame.SafeMaxAttempts)
            {
                return;
            }
            y += SaveGame.KeypadDirectionYOffset[dir];
            x += SaveGame.KeypadDirectionXOffset[dir];
            if (!SaveGame.InBounds(y, x))
            {
                break;
            }
        }
    }

    /// <summary>
    /// Generates a cavern level.
    /// </summary>
    private void MakeCavernLevel()
    {
        PerlinNoise perlinNoise = new PerlinNoise(SaveGame.RandomBetween(0, int.MaxValue - 1));
        double widthDivisor = 1 / (double)SaveGame.CurWid;
        double heightDivisor = 1 / (double)SaveGame.CurHgt;
        for (int y = 0; y < SaveGame.CurHgt; y++)
        {
            for (int x = 0; x < SaveGame.CurWid; x++)
            {
                GridTile cPtr = SaveGame.Grid[y][x];
                double v = perlinNoise.Noise(10 * x * widthDivisor, 10 * y * heightDivisor, -0.5);
                v = (v + 1) / 2;
                double dX = Math.Abs(x - (SaveGame.CurWid / 2)) * widthDivisor;
                double dY = Math.Abs(y - (SaveGame.CurHgt / 2)) * heightDivisor;
                double d = Math.Max(dX, dY);
                const double elevation = 0.05;
                const double steepness = 6.0;
                const double dropoff = 50.0;
                v += elevation - (dropoff * Math.Pow(d, steepness));
                v = Math.Min(1, Math.Max(0, v));
                int rounded = (int)(v * 10);
                if (rounded < 2 || rounded > 5)
                {
                    cPtr.SetFeature(SaveGame.SingletonRepository.Tiles.Get(nameof(WallBasicTile)));
                }
                else
                {
                    cPtr.SetFeature(SaveGame.SingletonRepository.Tiles.Get(nameof(DungeonFloorTile)));
                }
            }
        }
        for (int i = 0; i < _dunStrMag; i++)
        {
            BuildStreamer(SaveGame.SingletonRepository.Tiles.Get(nameof(MagmaTile)), _dunStrMc);
        }
        for (int i = 0; i < _dunStrQua; i++)
        {
            BuildStreamer(SaveGame.SingletonRepository.Tiles.Get(nameof(QuartzTile)), _dunStrQc);
        }
        for (int x = 0; x < SaveGame.CurWid; x++)
        {
            GridTile cPtr = SaveGame.Grid[0][x];
            cPtr.SetFeature(SaveGame.SingletonRepository.Tiles.Get(nameof(WallPermentSolidTile)));
        }
        for (int x = 0; x < SaveGame.CurWid; x++)
        {
            GridTile cPtr = SaveGame.Grid[SaveGame.CurHgt - 1][x];
            cPtr.SetFeature(SaveGame.SingletonRepository.Tiles.Get(nameof(WallPermentSolidTile)));
        }
        for (int y = 0; y < SaveGame.CurHgt; y++)
        {
            GridTile cPtr = SaveGame.Grid[y][0];
            cPtr.SetFeature(SaveGame.SingletonRepository.Tiles.Get(nameof(WallPermentSolidTile)));
        }
        for (int y = 0; y < SaveGame.CurHgt; y++)
        {
            GridTile cPtr = SaveGame.Grid[y][SaveGame.CurWid - 1];
            cPtr.SetFeature(SaveGame.SingletonRepository.Tiles.Get(nameof(WallPermentSolidTile)));
        }
        if (SaveGame.DieRoll(_darkEmpty) != 1 || SaveGame.DieRoll(100) > SaveGame.Difficulty)
        {
            SaveGame.RunScript(nameof(LightScript));
        }
    }

    private void ResetGuardians()
    {
        foreach (MonsterRace race in SaveGame.SingletonRepository.MonsterRaces)
        {
            race.Guardian = false;
        }
    }

    private int NextToWalls(int y, int x)
    {
        int k = 0;
        if (SaveGame.Grid[y + 1][x].FeatureType.IsWall)
        {
            k++;
        }
        if (SaveGame.Grid[y - 1][x].FeatureType.IsWall)
        {
            k++;
        }
        if (SaveGame.Grid[y][x + 1].FeatureType.IsWall)
        {
            k++;
        }
        if (SaveGame.Grid[y][x - 1].FeatureType.IsWall)
        {
            k++;
        }
        return k;
    }

    private void AllocStairs(Tile stairsTile, int num, int walls)
    {
        for (int i = 0; i < num; i++)
        {
            for (bool flag = false; !flag;)
            {
                for (int j = 0; !flag && j <= 3000; j++)
                {
                    int y = SaveGame.RandomLessThan(SaveGame.CurHgt);
                    int x = SaveGame.RandomLessThan(SaveGame.CurWid);
                    if (!SaveGame.GridOpenNoItemOrCreature(y, x))
                    {
                        continue;
                    }
                    if (NextToWalls(y, x) < walls)
                    {
                        continue;
                    }
                    GridTile cPtr = SaveGame.Grid[y][x];
                    if (SaveGame.CurrentDepth <= 0)
                    {
                        cPtr.SetFeature(SaveGame.SingletonRepository.Tiles.Get(nameof(DownStaircaseTile)));
                    }
                    else if (SaveGame.IsQuest(SaveGame.CurrentDepth) || SaveGame.CurrentDepth == SaveGame.CurDungeon.MaxLevel)
                    {
                        cPtr.SetFeature(SaveGame.CurDungeon.Tower ? SaveGame.SingletonRepository.Tiles.Get(nameof(DownStaircaseTile)) : SaveGame.SingletonRepository.Tiles.Get(nameof(UpStaircaseTile)));
                    }
                    else
                    {
                        cPtr.SetFeature(stairsTile);
                    }
                    flag = true;
                }
                if (walls != 0)
                {
                    walls--;
                }
            }
        }
    }

    private int GetQuestMonster()
    {
        for (int i = 0; i < SaveGame.Quests.Count; i++)
        {
            if (SaveGame.Quests[i].Level == SaveGame.CurrentDepth && SaveGame.Quests[i].Dungeon == SaveGame.CurDungeon)
            {
                return SaveGame.Quests[i].RIdx;
            }
        }
        return 0;
    }

    private void PutQuestMonster(int rIdx)
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
                y = SaveGame.RandomLessThan(SaveGame.MaxHgt);
                x = SaveGame.RandomLessThan(SaveGame.MaxWid);
                if (!SaveGame.GridOpenNoItemOrCreature(y, x))
                {
                    continue;
                }
                {
                    if (SaveGame.Distance(y, x, SaveGame.MapY, SaveGame.MapX) > 15)
                    {
                        break;
                    }
                }
            }
        } while (!SaveGame.PlaceMonsterByIndex(y, x, rIdx, false, false, false));
    }

    private void PlaceRubble(int y, int x)
    {
        GridTile cPtr = SaveGame.Grid[y][x];
        cPtr.SetFeature(SaveGame.SingletonRepository.Tiles.Get(nameof(RubbleTile)));
    }

    private void AllocObject(int set, int typ, int num)
    {
        int y = 0;
        int x = 0;
        int dummy = 0;
        for (int k = 0; k < num; k++)
        {
            while (dummy < SaveGame.SafeMaxAttempts)
            {
                dummy++;
                y = SaveGame.RandomLessThan(SaveGame.CurHgt);
                x = SaveGame.RandomLessThan(SaveGame.CurWid);
                if (!SaveGame.GridOpenNoItemOrCreature(y, x))
                {
                    continue;
                }
                bool isRoom = SaveGame.Grid[y][x].TileFlags.IsSet(GridTile.InRoom);
                if (set == _allocSetCorr && isRoom)
                {
                    continue;
                }
                if (set == _allocSetRoom && !isRoom)
                {
                    continue;
                }
                break;
            }
            if (dummy >= SaveGame.SafeMaxAttempts)
            {
                return;
            }
            switch (typ)
            {
                case _allocTypRubble:
                    {
                        PlaceRubble(y, x);
                        break;
                    }
                case _allocTypTrap:
                    {
                        SaveGame.PlaceTrap(y, x);
                        break;
                    }
                case _allocTypGold:
                    {
                        SaveGame.PlaceGold(y, x);
                        break;
                    }
                case _allocTypObject:
                    {
                        SaveGame.PlaceObject(y, x, false, false);
                        break;
                    }
            }
        }
    }

    private int NextToCorr(int y1, int x1)
    {
        int k = 0;
        for (int i = 0; i < 4; i++)
        {
            int y = y1 + SaveGame.OrderedDirectionYOffset[i];
            int x = x1 + SaveGame.OrderedDirectionXOffset[i];
            if (!SaveGame.GridPassable(y, x))
            {
                continue;
            }
            GridTile cPtr = SaveGame.Grid[y][x];
            if (!cPtr.FeatureType.IsOpenFloor)
            {
                continue;
            }
            if (cPtr.TileFlags.IsSet(GridTile.InRoom))
            {
                continue;
            }
            k++;
        }
        return k;
    }

    private bool PossibleDoorway(int y, int x)
    {
        if (NextToCorr(y, x) >= 2)
        {
            if (SaveGame.Grid[y - 1][x].FeatureType.IsWall && SaveGame.Grid[y + 1][x].FeatureType.IsWall)
            {
                return true;
            }
            if (SaveGame.Grid[y][x - 1].FeatureType.IsWall && SaveGame.Grid[y][x + 1].FeatureType.IsWall)
            {
                return true;
            }
        }
        return false;
    }

    private void TryDoor(int y, int x)
    {
        if (!SaveGame.InBounds(y, x))
        {
            return;
        }
        if (SaveGame.Grid[y][x].FeatureType.IsWall)
        {
            return;
        }
        if (SaveGame.Grid[y][x].TileFlags.IsSet(GridTile.InRoom))
        {
            return;
        }
        if (SaveGame.RandomLessThan(100) < _dunTunJct && PossibleDoorway(y, x))
        {
            SaveGame.PlaceRandomDoor(y, x);
        }
    }

    private void CorrectDir(out int rdir, out int cdir, int y1, int x1, int y2, int x2)
    {
        rdir = y1 == y2 ? 0 : y1 < y2 ? 1 : -1;
        cdir = x1 == x2 ? 0 : x1 < x2 ? 1 : -1;
        if (rdir != 0 && cdir != 0)
        {
            if (SaveGame.RandomLessThan(100) < 50)
            {
                rdir = 0;
            }
            else
            {
                cdir = 0;
            }
        }
    }

    private void RandDir(out int rdir, out int cdir)
    {
        int i = SaveGame.RandomLessThan(4);
        rdir = SaveGame.OrderedDirectionYOffset[i];
        cdir = SaveGame.OrderedDirectionXOffset[i];
    }

    private void BuildTunnel(int row1, int col1, int row2, int col2)
    {
        int i, y, x;
        int mainLoopCount = 0;
        bool doorFlag = false;
        GridTile cPtr;
        TunnN = 0;
        WallN = 0;
        int startRow = row1;
        int startCol = col1;
        CorrectDir(out int rowDir, out int colDir, row1, col1, row2, col2);
        while (row1 != row2 || col1 != col2)
        {
            if (mainLoopCount++ > 2000)
            {
                break;
            }
            if (SaveGame.RandomLessThan(100) < _dunTunChg)
            {
                CorrectDir(out rowDir, out colDir, row1, col1, row2, col2);
                if (SaveGame.RandomLessThan(100) < _dunTunRnd)
                {
                    RandDir(out rowDir, out colDir);
                }
            }
            int tmpRow = row1 + rowDir;
            int tmpCol = col1 + colDir;
            while (!SaveGame.InBounds(tmpRow, tmpCol))
            {
                CorrectDir(out rowDir, out colDir, row1, col1, row2, col2);
                if (SaveGame.RandomLessThan(100) < _dunTunRnd)
                {
                    RandDir(out rowDir, out colDir);
                }
                tmpRow = row1 + rowDir;
                tmpCol = col1 + colDir;
            }
            cPtr = SaveGame.Grid[tmpRow][tmpCol];
            if (cPtr.FeatureType is WallPermentSolidTile)
            {
                continue;
            }
            if (cPtr.FeatureType is WallPermanentOuterTile)
            {
                continue;
            }
            if (cPtr.FeatureType is WallSolidTile)
            {
                continue;
            }
            if (cPtr.FeatureType is WallOuterTile)
            {
                y = tmpRow + rowDir;
                x = tmpCol + colDir;
                if (SaveGame.Grid[y][x].FeatureType is WallPermentSolidTile)
                {
                    continue;
                }
                if (SaveGame.Grid[y][x].FeatureType is WallPermanentOuterTile)
                {
                    continue;
                }
                if (SaveGame.Grid[y][x].FeatureType is WallOuterTile)
                {
                    continue;
                }
                if (SaveGame.Grid[y][x].FeatureType is WallSolidTile)
                {
                    continue;
                }
                row1 = tmpRow;
                col1 = tmpCol;
                if (WallN < WallMax)
                {
                    Wall[WallN] = new GridCoordinate(col1, row1);
                    WallN++;
                }
                for (y = row1 - 1; y <= row1 + 1; y++)
                {
                    for (x = col1 - 1; x <= col1 + 1; x++)
                    {
                        if (SaveGame.Grid[y][x].FeatureType is WallOuterTile)
                        {
                            SaveGame.Grid[y][x].SetFeature(SaveGame.SingletonRepository.Tiles.Get(nameof(WallSolidTile)));
                        }
                    }
                }
            }
            else if (cPtr.TileFlags.IsSet(GridTile.InRoom))
            {
                row1 = tmpRow;
                col1 = tmpCol;
            }
            else if (cPtr.FeatureType.IsWall)
            {
                row1 = tmpRow;
                col1 = tmpCol;
                if (TunnN < TunnMax)
                {
                    Tunn[TunnN] = new GridCoordinate(col1, row1);
                    TunnN++;
                }
                doorFlag = false;
            }
            else
            {
                row1 = tmpRow;
                col1 = tmpCol;
                if (!doorFlag)
                {
                    if (DoorN < DoorMax)
                    {
                        Door[DoorN] = new GridCoordinate(col1, row1);
                        DoorN++;
                    }
                    doorFlag = true;
                }
                if (SaveGame.RandomLessThan(100) >= _dunTunCon)
                {
                    tmpRow = row1 - startRow;
                    if (tmpRow < 0)
                    {
                        tmpRow = -tmpRow;
                    }
                    tmpCol = col1 - startCol;
                    if (tmpCol < 0)
                    {
                        tmpCol = -tmpCol;
                    }
                    if (tmpRow > 10 || tmpCol > 10)
                    {
                        break;
                    }
                }
            }
        }
        for (i = 0; i < TunnN; i++)
        {
            y = Tunn[i].Y;
            x = Tunn[i].X;
            cPtr = SaveGame.Grid[y][x];
            cPtr.RevertToBackground();
        }
        for (i = 0; i < WallN; i++)
        {
            y = Wall[i].Y;
            x = Wall[i].X;
            cPtr = SaveGame.Grid[y][x];
            cPtr.RevertToBackground();
            if (SaveGame.RandomLessThan(100) < _dunTunPen)
            {
                SaveGame.PlaceRandomDoor(y, x);
            }
        }
    }

    private void MakeDungeonLevel()
    {
        int k;
        int y;
        int x;
        int maxVaultOk = 2;
        bool destroyed = false;
        bool emptyLevel = false;

        Cent = new GridCoordinate[CentMax];
        Door = new GridCoordinate[DoorMax];
        Wall = new GridCoordinate[WallMax];
        Tunn = new GridCoordinate[TunnMax];
        RoomMap = new bool[MaxRoomsRow][];
        for (int i = 0; i < MaxRoomsRow; i++)
        {
            RoomMap[i] = new bool[MaxRoomsCol];
        }

        if (SaveGame.MaxPanelRows == 0)
        {
            maxVaultOk--;
        }
        if (SaveGame.MaxPanelCols == 0)
        {
            maxVaultOk--;
        }
        if (SaveGame.DieRoll(_emptyLevel) == 1)
        {
            emptyLevel = true;
        }
        for (y = 0; y < SaveGame.CurHgt; y++)
        {
            for (x = 0; x < SaveGame.CurWid; x++)
            {
                GridTile cPtr = SaveGame.Grid[y][x];
                if (emptyLevel)
                {
                    cPtr.RevertToBackground();
                }
                else
                {
                    cPtr.SetFeature(SaveGame.SingletonRepository.Tiles.Get(nameof(WallBasicTile)));
                }
            }
        }
        if (SaveGame.Difficulty > 10 && SaveGame.RandomLessThan(_dunDest) == 0)
        {
            destroyed = true;
        }
        if (SaveGame.IsQuest(SaveGame.CurrentDepth))
        {
            destroyed = false;
        }
        RowRooms = SaveGame.CurHgt / _blockHgt;
        ColRooms = SaveGame.CurWid / _blockWid;
        for (y = 0; y < RowRooms; y++)
        {
            for (x = 0; x < ColRooms; x++)
            {
                RoomMap[y][x] = false;
            }
        }
        Crowded = false;
        CentN = 0;
        for (int i = 0; i < _dunRooms; i++)
        {
            y = SaveGame.RandomLessThan(RowRooms);
            x = SaveGame.RandomLessThan(ColRooms);
            if (x % 3 == 0)
            {
                x++;
            }
            if (x % 3 == 2)
            {
                x--;
            }
            if (destroyed)
            {
                if (RoomBuild(y, x, SaveGame.SingletonRepository.RoomLayouts.Get(nameof(Type1RoomLayout)), SaveGame.Difficulty))
                {
                }
                continue;
            }
            if (SaveGame.RandomLessThan(_dunUnusual) < SaveGame.Difficulty)
            {
                k = SaveGame.RandomLessThan(100);
                if (SaveGame.RandomLessThan(_dunUnusual) < SaveGame.Difficulty)
                {
                    if (k < 10)
                    {
                        if (maxVaultOk > 1)
                        {
                            if (RoomBuild(y, x, SaveGame.SingletonRepository.RoomLayouts.Get(nameof(Type8RoomLayout)), SaveGame.Difficulty))
                            {
                                continue;
                            }
                        }
                    }
                    if (k < 25)
                    {
                        if (maxVaultOk > 0)
                        {
                            if (RoomBuild(y, x, SaveGame.SingletonRepository.RoomLayouts.Get(nameof(Type7RoomLayout)), SaveGame.Difficulty))
                            {
                                continue;
                            }
                        }
                    }
                    if (k < 40 && RoomBuild(y, x, SaveGame.SingletonRepository.RoomLayouts.Get(nameof(Type5RoomLayout)), SaveGame.Difficulty))
                    {
                        continue;
                    }
                    if (k < 55 && RoomBuild(y, x, SaveGame.SingletonRepository.RoomLayouts.Get(nameof(Type6RoomLayout)), SaveGame.Difficulty))
                    {
                        continue;
                    }
                }
                if (k < 25 && RoomBuild(y, x, SaveGame.SingletonRepository.RoomLayouts.Get(nameof(Type4RoomLayout)), SaveGame.Difficulty))
                {
                    continue;
                }
                if (k < 50 && RoomBuild(y, x, SaveGame.SingletonRepository.RoomLayouts.Get(nameof(Type3RoomLayout)), SaveGame.Difficulty))
                {
                    continue;
                }
                if (k < 100 && RoomBuild(y, x, SaveGame.SingletonRepository.RoomLayouts.Get(nameof(Type2RoomLayout)), SaveGame.Difficulty))
                {
                    continue;
                }
            }
            if (RoomBuild(y, x, SaveGame.SingletonRepository.RoomLayouts.Get(nameof(Type1RoomLayout)), SaveGame.Difficulty))
            {
            }
        }
        for (x = 0; x < SaveGame.CurWid; x++)
        {
            GridTile cPtr = SaveGame.Grid[0][x];
            cPtr.SetFeature(SaveGame.SingletonRepository.Tiles.Get(nameof(WallPermentSolidTile)));
        }
        for (x = 0; x < SaveGame.CurWid; x++)
        {
            GridTile cPtr = SaveGame.Grid[SaveGame.CurHgt - 1][x];
            cPtr.SetFeature(SaveGame.SingletonRepository.Tiles.Get(nameof(WallPermentSolidTile)));
        }
        for (y = 0; y < SaveGame.CurHgt; y++)
        {
            GridTile cPtr = SaveGame.Grid[y][0];
            cPtr.SetFeature(SaveGame.SingletonRepository.Tiles.Get(nameof(WallPermentSolidTile)));
        }
        for (y = 0; y < SaveGame.CurHgt; y++)
        {
            GridTile cPtr = SaveGame.Grid[y][SaveGame.CurWid - 1];
            cPtr.SetFeature(SaveGame.SingletonRepository.Tiles.Get(nameof(WallPermentSolidTile)));
        }
        for (int i = 0; i < CentN; i++)
        {
            int pick1 = SaveGame.RandomLessThan(CentN);
            int pick2 = SaveGame.RandomLessThan(CentN);
            int y1 = Cent[pick1].Y;
            int x1 = Cent[pick1].X;
            Cent[pick1] = Cent[pick2].Clone();
            Cent[pick2] = new GridCoordinate(x1, y1);
        }
        DoorN = 0;
        try // TODO: THIS IS DUE TO AN INDEX OUT OF BOUNDS ERROR
        {
            y = Cent[CentN - 1].Y;
            x = Cent[CentN - 1].X;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        for (int i = 0; i < CentN; i++)
        {
            BuildTunnel(Cent[i].Y, Cent[i].X, y, x);
            y = Cent[i].Y;
            x = Cent[i].X;
        }
        for (int i = 0; i < DoorN; i++)
        {
            y = Door[i].Y;
            x = Door[i].X;
            TryDoor(y, x - 1);
            TryDoor(y, x + 1);
            TryDoor(y - 1, x);
            TryDoor(y + 1, x);
        }
        for (int i = 0; i < _dunStrMag; i++)
        {
            BuildStreamer(SaveGame.SingletonRepository.Tiles.Get(nameof(MagmaTile)), _dunStrMc);
        }
        for (int i = 0; i < _dunStrQua; i++)
        {
            BuildStreamer(SaveGame.SingletonRepository.Tiles.Get(nameof(QuartzTile)), _dunStrQc);
        }
        if (destroyed)
        {
            DestroyLevel();
        }
        if (emptyLevel && (SaveGame.DieRoll(_darkEmpty) != 1 || SaveGame.DieRoll(100) > SaveGame.Difficulty))
        {
            SaveGame.RunScript(nameof(LightScript));
        }
    }
}
