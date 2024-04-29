// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using System.Diagnostics;

namespace AngbandOS.Core;

[Serializable]
internal class StandardDungeonGenerator : DungeonGenerator
{
    private const int _smallLevel = 3;
    private GridCoordinate[] Cent; // This is the center of each room that was generated.
    private GridCoordinate[] Door;
    private bool[][] RoomMap; // This is a quadrant of _blockWid wide blocks by _blockHgt blocks high map tracking if a room has been built in that quadrant.
    private GridCoordinate[] Tunn;
    private GridCoordinate[] Wall;
    private const int CentMax = 100; // This is the maximum number of rooms that can be tracked when a dungeon is generated.  Any rooms generated beyond this count are not tracked as a room.
    private const int DoorMax = 200;
    private const int _blockHgt = 21; // This is the vertical height of a block that is used to divide the dungeon into grid blocks for room placement.
    private const int _blockWid = 11; // This is the horizontal width of a block that is used to divide the dungeon into grid blocks for room placement.
    private const int MaxRoomsCol = Game.MaxWid / _blockWid; // This is the number of horizontal grid blocks for the current dungeon.
    private const int MaxRoomsRow = Game.MaxHgt / _blockHgt; // This is the number of vertical grid blocks for the current dungeon.
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
    private const int MinimumNumberOfRoomsToAttemptToCreate = 50;
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

    /// <summary>
    /// Returns the number of rooms that were generated.
    /// </summary>
    private int CentN;

    private int ColRooms;
    private bool Crowded;
    private int DoorN;
    private int RowRooms;
    private int TunnN;
    private int WallN;

    public StandardDungeonGenerator(Game game) : base(game) { }


    /// <summary>
    /// Generates an underground level.
    /// </summary>
    /// <returns></returns>
    public override bool GenerateDungeon()
    {
        Game.DungeonDifficulty = Game.CurDungeon.Offset;
        Game.DunBias = Game.CurDungeon.BiasMonsterFilter;
        if (Game.CurDungeon.Tower)
        {
            Game.CurHgt = Constants.PlayableScreenHeight;
            Game.CurWid = Constants.PlayableScreenWidth;
            Game.MaxPanelRows = 0;
            Game.MaxPanelCols = 0;
            Game.PanelRow = 0;
            Game.PanelCol = 0;
        }
        else
        {
            // Test if this should be a small dungeon.  Small levels are less than the full size of the screen, but need to be at least large enough for type 1 rooms.
            if (Game.DieRoll(_smallLevel) == 1)
            {
                int tester1 = Game.DieRoll(Game.MaxHgt / Constants.PlayableScreenHeight);
                int tester2 = Game.DieRoll(Game.MaxWid / Constants.PlayableScreenWidth);
                Game.CurHgt = tester1 * Constants.PlayableScreenHeight;
                Game.CurWid = tester2 * Constants.PlayableScreenWidth;
                Game.MaxPanelRows = (Game.CurHgt / Constants.PlayableScreenHeight * 2) - 2;
                Game.MaxPanelCols = (Game.CurWid / Constants.PlayableScreenWidth * 2) - 2;
                Game.PanelRow = Game.MaxPanelRows;
                Game.PanelCol = Game.MaxPanelCols;
            }
            else
            {
                Game.CurHgt = Game.MaxHgt;
                Game.CurWid = Game.MaxWid;
                Game.MaxPanelRows = (Game.CurHgt / Constants.PlayableScreenHeight * 2) - 2;
                Game.MaxPanelCols = (Game.CurWid / Constants.PlayableScreenWidth * 2) - 2;
                Game.PanelRow = Game.MaxPanelRows;
                Game.PanelCol = Game.MaxPanelCols;
            }
        }

        ResetGuardians();
        if (Game.IsQuest(Game.CurrentDepth))
        {
            Game.SingletonRepository.Get<MonsterRace>(GetQuestMonster()).Guardian = true;
        }
        if (Game.PercentileRoll(4) && !Game.CurDungeon.Tower)
        {
            MakeCavernLevel();
        }
        else
        {
            MakeDungeonLevel();
        }

        // Generate downstairs.
        AllocStairs(Game.DownStaircaseTile, Game.RandomBetween(3, 4), 3);

        // Generate upstairs.
        AllocStairs(Game.UpStaircaseTile, Game.RandomBetween(1, 2), 3);

        // Choose a spot for the player.
        if (!Game.NewPlayerSpot())
        {
            return false;
        }

        int k = Game.Difficulty / 3;
        if (k > 10)
        {
            k = 10;
        }
        if (k < 2)
        {
            k = 2;
        }
        if (Game.IsQuest(Game.CurrentDepth))
        {
            int rIdx = GetQuestMonster();
            int qIdx = Game.GetQuestNumber();
            while (Game.SingletonRepository.Get<MonsterRace>(rIdx).CurNum < (Game.Quests[qIdx].ToKill - Game.Quests[qIdx].Killed))
            {
                PutQuestMonster(Game.Quests[qIdx].RIdx);
            }
        }
        int i = Constants.MinMAllocLevel;
        if (Game.CurHgt < Game.MaxHgt || Game.CurWid < Game.MaxWid)
        {
            int smallTester = i;
            i = i * Game.CurHgt / Game.MaxHgt;
            i = i * Game.CurWid / Game.MaxWid;
            i++;
            if (i > smallTester)
            {
                i = smallTester;
            }
        }
        i += Game.DieRoll(8);
        for (i += k; i > 0; i--)
        {
            Game.AllocMonster(0, true);
        }
        AllocObject(_allocSetBoth, _allocTypTrap, Game.DieRoll(k));
        AllocObject(_allocSetCorr, _allocTypRubble, Game.DieRoll(k));
        AllocObject(_allocSetRoom, _allocTypObject, Game.RandomNormal(_dunAmtRoom, 3));
        AllocObject(_allocSetBoth, _allocTypObject, Game.RandomNormal(_dunAmtItem, 3));
        AllocObject(_allocSetBoth, _allocTypGold, Game.RandomNormal(_dunAmtGold, 3));
        return true;
    }

    private bool RoomBuild(int y0, int x0, RoomLayout roomType, int difficulty) // TODO: This belongs to each room type
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
            CentN++; // TODO: This is a module level variable
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
        Tile wallBasicTile = Game.SingletonRepository.Tiles.Get(nameof(WallBasicTile));
        Tile quartzTile = Game.SingletonRepository.Tiles.Get(nameof(QuartzTile));
        Tile magmaTile = Game.SingletonRepository.Tiles.Get(nameof(MagmaTile));
        for (int n = 0; n < Game.DieRoll(5); n++)
        {
            int x1 = Game.RandomBetween(5, Game.CurWid - 1 - 5);
            int y1 = Game.RandomBetween(5, Game.CurHgt - 1 - 5);
            int y;
            for (y = y1 - 15; y <= y1 + 15; y++)
            {
                int x;
                for (x = x1 - 15; x <= x1 + 15; x++)
                {
                    if (!Game.InBounds(y, x))
                    {
                        continue;
                    }
                    int k = Game.Distance(y1, x1, y, x);
                    if (k >= 16)
                    {
                        continue;
                    }
                    Game.DeleteMonsterAtGridLocation(y, x);
                    if (Game.CaveValidBold(y, x))
                    {
                        Game.DeleteObject(y, x);
                        GridTile cPtr = Game.Map.Grid[y][x];
                        int t = Game.RandomLessThan(200);
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
                        cPtr.InVault = false;
                        cPtr.InRoom = false;
                        cPtr.PlayerMemorized = false;
                        cPtr.SelfLit = false;
                    }
                }
            }
        }
    }

    private void BuildStreamer(Tile tile, int chance)
    {
        int dummy = 0;
        int y = Game.RandomSpread(Game.CurHgt / 2, 10);
        int x = Game.RandomSpread(Game.CurWid / 2, 15);
        int dir = Game.OrderedDirection[Game.RandomLessThan(8)];
        while (dummy < Game.SafeMaxAttempts)
        {
            dummy++;
            for (int i = 0; i < _dunStrDen; i++)
            {
                const int d = _dunStrRng;
                int tx;
                int ty;
                while (true)
                {
                    ty = Game.RandomSpread(y, d);
                    tx = Game.RandomSpread(x, d);
                    if (!Game.InBounds2(ty, tx))
                    {
                        continue;
                    }
                    break;
                }
                GridTile cPtr = Game.Map.Grid[ty][tx];

                if (!cPtr.FeatureType.IsBasicWall)
                {
                    continue;
                }
                cPtr.SetFeature(tile);
                if (Game.RandomLessThan(chance) == 0)
                {
                    Tile? visibleTreasureTile = cPtr.FeatureType.VisibleTreasureForTile;
                    if (visibleTreasureTile == null)
                    {
                        throw new Exception("No visible treasure tile configured.");
                    }
                    cPtr.SetFeature(visibleTreasureTile);
                }
            }
            if (dummy >= Game.SafeMaxAttempts)
            {
                return;
            }
            y += Game.KeypadDirectionYOffset[dir];
            x += Game.KeypadDirectionXOffset[dir];
            if (!Game.InBounds(y, x))
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
        PerlinNoise perlinNoise = new PerlinNoise(Game.RandomBetween(0, int.MaxValue - 1));
        double widthDivisor = 1 / (double)Game.CurWid;
        double heightDivisor = 1 / (double)Game.CurHgt;
        for (int y = 0; y < Game.CurHgt; y++)
        {
            for (int x = 0; x < Game.CurWid; x++)
            {
                GridTile cPtr = Game.Map.Grid[y][x];
                double v = perlinNoise.Noise(10 * x * widthDivisor, 10 * y * heightDivisor, -0.5);
                v = (v + 1) / 2;
                double dX = Math.Abs(x - (Game.CurWid / 2)) * widthDivisor;
                double dY = Math.Abs(y - (Game.CurHgt / 2)) * heightDivisor;
                double d = Math.Max(dX, dY);
                const double elevation = 0.05;
                const double steepness = 6.0;
                const double dropoff = 50.0;
                v += elevation - (dropoff * Math.Pow(d, steepness));
                v = Math.Min(1, Math.Max(0, v));
                int rounded = (int)(v * 10);
                if (rounded < 2 || rounded > 5)
                {
                    cPtr.SetFeature(Game.SingletonRepository.Tiles.Get(nameof(WallBasicTile)));
                }
                else
                {
                    cPtr.SetFeature(Game.SingletonRepository.Tiles.Get(nameof(DungeonFloorTile)));
                }
            }
        }
        for (int i = 0; i < _dunStrMag; i++)
        {
            BuildStreamer(Game.SingletonRepository.Tiles.Get(nameof(MagmaTile)), _dunStrMc);
        }
        for (int i = 0; i < _dunStrQua; i++)
        {
            BuildStreamer(Game.SingletonRepository.Tiles.Get(nameof(QuartzTile)), _dunStrQc);
        }
        for (int x = 0; x < Game.CurWid; x++)
        {
            GridTile cPtr = Game.Map.Grid[0][x];
            cPtr.SetFeature(Game.SingletonRepository.Tiles.Get(nameof(WallPermentSolidTile)));
        }
        for (int x = 0; x < Game.CurWid; x++)
        {
            GridTile cPtr = Game.Map.Grid[Game.CurHgt - 1][x];
            cPtr.SetFeature(Game.SingletonRepository.Tiles.Get(nameof(WallPermentSolidTile)));
        }
        for (int y = 0; y < Game.CurHgt; y++)
        {
            GridTile cPtr = Game.Map.Grid[y][0];
            cPtr.SetFeature(Game.SingletonRepository.Tiles.Get(nameof(WallPermentSolidTile)));
        }
        for (int y = 0; y < Game.CurHgt; y++)
        {
            GridTile cPtr = Game.Map.Grid[y][Game.CurWid - 1];
            cPtr.SetFeature(Game.SingletonRepository.Tiles.Get(nameof(WallPermentSolidTile)));
        }
        if (Game.DieRoll(_darkEmpty) != 1 || Game.DieRoll(100) > Game.Difficulty)
        {
            Game.RunScript(nameof(LightScript));
        }
    }

    private void ResetGuardians()
    {
        foreach (MonsterRace race in Game.SingletonRepository.Get<MonsterRace>())
        {
            race.Guardian = false;
        }
    }

    private int NextToWalls(int y, int x)
    {
        int k = 0;
        if (Game.Map.Grid[y + 1][x].FeatureType.IsWall)
        {
            k++;
        }
        if (Game.Map.Grid[y - 1][x].FeatureType.IsWall)
        {
            k++;
        }
        if (Game.Map.Grid[y][x + 1].FeatureType.IsWall)
        {
            k++;
        }
        if (Game.Map.Grid[y][x - 1].FeatureType.IsWall)
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
                    int y = Game.RandomLessThan(Game.CurHgt);
                    int x = Game.RandomLessThan(Game.CurWid);
                    if (!Game.GridOpenNoItemOrCreature(y, x))
                    {
                        continue;
                    }
                    if (NextToWalls(y, x) < walls)
                    {
                        continue;
                    }
                    GridTile cPtr = Game.Map.Grid[y][x];
                    if (Game.CurrentDepth <= 0)
                    {
                        cPtr.SetFeature(Game.DownStaircaseTile);
                    }
                    else if (Game.IsQuest(Game.CurrentDepth) || Game.CurrentDepth == Game.CurDungeon.MaxLevel)
                    {
                        cPtr.SetFeature(Game.CurDungeon.Tower ? Game.DownStaircaseTile : Game.UpStaircaseTile);
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
        for (int i = 0; i < Game.Quests.Count; i++)
        {
            if (Game.Quests[i].Level == Game.CurrentDepth && Game.Quests[i].Dungeon == Game.CurDungeon)
            {
                return Game.Quests[i].RIdx;
            }
        }
        return 0;
    }

    private void PutQuestMonster(int rIdx)
    {
        int y, x;
        if (Game.SingletonRepository.Get<MonsterRace>(rIdx).MaxNum == 0)
        {
            Game.SingletonRepository.Get<MonsterRace>(rIdx).MaxNum++;
            Game.MsgPrint("Resurrecting guardian to fix corrupted savefile...");
        }
        do
        {
            while (true)
            {
                y = Game.RandomLessThan(Game.MaxHgt);
                x = Game.RandomLessThan(Game.MaxWid);
                if (!Game.GridOpenNoItemOrCreature(y, x))
                {
                    continue;
                }
                {
                    if (Game.Distance(y, x, Game.MapY.IntValue, Game.MapX.IntValue) > 15)
                    {
                        break;
                    }
                }
            }
        } while (!Game.PlaceMonsterByIndex(y, x, rIdx, false, false, false));
    }

    private void PlaceRubble(int y, int x)
    {
        GridTile cPtr = Game.Map.Grid[y][x];
        cPtr.SetFeature(Game.SingletonRepository.Tiles.Get(nameof(RubbleTile)));
    }

    private void AllocObject(int set, int typ, int num)
    {
        int y = 0;
        int x = 0;
        int dummy = 0;
        for (int k = 0; k < num; k++)
        {
            while (dummy < Game.SafeMaxAttempts)
            {
                dummy++;
                y = Game.RandomLessThan(Game.CurHgt);
                x = Game.RandomLessThan(Game.CurWid);
                if (!Game.GridOpenNoItemOrCreature(y, x))
                {
                    continue;
                }
                bool isRoom = Game.Map.Grid[y][x].InRoom;
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
            if (dummy >= Game.SafeMaxAttempts)
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
                        Game.PlaceTrap(y, x);
                        break;
                    }
                case _allocTypGold:
                    {
                        Game.PlaceGold(y, x);
                        break;
                    }
                case _allocTypObject:
                    {
                        Game.PlaceObject(y, x, false, false);
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
            int y = y1 + Game.OrderedDirectionYOffset[i];
            int x = x1 + Game.OrderedDirectionXOffset[i];
            if (!Game.GridPassable(y, x))
            {
                continue;
            }
            GridTile cPtr = Game.Map.Grid[y][x];
            if (!cPtr.FeatureType.IsOpenFloor)
            {
                continue;
            }
            if (cPtr.InRoom)
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
            if (Game.Map.Grid[y - 1][x].FeatureType.IsWall && Game.Map.Grid[y + 1][x].FeatureType.IsWall)
            {
                return true;
            }
            if (Game.Map.Grid[y][x - 1].FeatureType.IsWall && Game.Map.Grid[y][x + 1].FeatureType.IsWall)
            {
                return true;
            }
        }
        return false;
    }

    private void TryDoor(int y, int x)
    {
        if (!Game.InBounds(y, x))
        {
            return;
        }
        if (Game.Map.Grid[y][x].FeatureType.IsWall)
        {
            return;
        }
        if (Game.Map.Grid[y][x].InRoom)
        {
            return;
        }
        if (Game.RandomLessThan(100) < _dunTunJct && PossibleDoorway(y, x))
        {
            Game.PlaceRandomDoor(y, x);
        }
    }

    private void CorrectDir(out int rdir, out int cdir, int y1, int x1, int y2, int x2)
    {
        rdir = y1 == y2 ? 0 : y1 < y2 ? 1 : -1;
        cdir = x1 == x2 ? 0 : x1 < x2 ? 1 : -1;
        if (rdir != 0 && cdir != 0)
        {
            if (Game.RandomLessThan(100) < 50)
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
        int i = Game.RandomLessThan(4);
        rdir = Game.OrderedDirectionYOffset[i];
        cdir = Game.OrderedDirectionXOffset[i];
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
            if (Game.RandomLessThan(100) < _dunTunChg)
            {
                CorrectDir(out rowDir, out colDir, row1, col1, row2, col2);
                if (Game.RandomLessThan(100) < _dunTunRnd)
                {
                    RandDir(out rowDir, out colDir);
                }
            }
            int tmpRow = row1 + rowDir;
            int tmpCol = col1 + colDir;
            while (!Game.InBounds(tmpRow, tmpCol))
            {
                CorrectDir(out rowDir, out colDir, row1, col1, row2, col2);
                if (Game.RandomLessThan(100) < _dunTunRnd)
                {
                    RandDir(out rowDir, out colDir);
                }
                tmpRow = row1 + rowDir;
                tmpCol = col1 + colDir;
            }
            cPtr = Game.Map.Grid[tmpRow][tmpCol];
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
                if (Game.Map.Grid[y][x].FeatureType is WallPermentSolidTile)
                {
                    continue;
                }
                if (Game.Map.Grid[y][x].FeatureType is WallPermanentOuterTile)
                {
                    continue;
                }
                if (Game.Map.Grid[y][x].FeatureType is WallOuterTile)
                {
                    continue;
                }
                if (Game.Map.Grid[y][x].FeatureType is WallSolidTile)
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
                        if (Game.Map.Grid[y][x].FeatureType is WallOuterTile)
                        {
                            Game.Map.Grid[y][x].SetFeature(Game.SingletonRepository.Tiles.Get(nameof(WallSolidTile)));
                        }
                    }
                }
            }
            else if (cPtr.InRoom)
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
                if (Game.RandomLessThan(100) >= _dunTunCon)
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
            cPtr = Game.Map.Grid[y][x];
            cPtr.RevertToBackground();
        }
        for (i = 0; i < WallN; i++)
        {
            y = Wall[i].Y;
            x = Wall[i].X;
            cPtr = Game.Map.Grid[y][x];
            cPtr.RevertToBackground();
            if (Game.RandomLessThan(100) < _dunTunPen)
            {
                Game.PlaceRandomDoor(y, x);
            }
        }
    }

    /// <summary>
    /// Returns the minimum number of rooms to be generated.  This number must be at least 1.
    /// </summary>
    private const int MinimumRoomCount = 1;

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

        // Compute the number of grid blocks for this size of dungeon.
        RowRooms = Game.CurHgt / _blockHgt;
        ColRooms = Game.CurWid / _blockWid;

        // The dungeon must be large enough to support at least one type-1 room.
        Type1RoomLayout type1RoomLayout = (Type1RoomLayout)Game.SingletonRepository.RoomLayouts.Get(nameof(Type1RoomLayout));
        if (RowRooms < type1RoomLayout.Height)
        {
            Game.CurHgt = type1RoomLayout.Height * _blockHgt;
            RowRooms = Game.CurHgt / _blockHgt;
        }
        if (ColRooms < type1RoomLayout.Width)
        {
            Game.CurWid = type1RoomLayout.Width * _blockWid;
            ColRooms = Game.CurWid / _blockWid;
        }

        // Initialize the grid of rooms to prevent overlapping.
        RoomMap = new bool[MaxRoomsRow][];
        for (int i = 0; i < MaxRoomsRow; i++)
        {
            RoomMap[i] = new bool[MaxRoomsCol];
        }

        if (Game.MaxPanelRows == 0)
        {
            maxVaultOk--;
        }
        if (Game.MaxPanelCols == 0)
        {
            maxVaultOk--;
        }
        if (Game.DieRoll(_emptyLevel) == 1)
        {
            emptyLevel = true;
        }
        for (y = 0; y < Game.CurHgt; y++)
        {
            for (x = 0; x < Game.CurWid; x++)
            {
                GridTile cPtr = Game.Map.Grid[y][x];
                if (emptyLevel)
                {
                    cPtr.RevertToBackground();
                }
                else
                {
                    cPtr.SetFeature(Game.SingletonRepository.Tiles.Get(nameof(WallBasicTile)));
                }
            }
        }
        if (Game.Difficulty > 10 && Game.RandomLessThan(_dunDest) == 0)
        {
            destroyed = true;
        }
        if (Game.IsQuest(Game.CurrentDepth))
        {
            destroyed = false;
        }
        for (y = 0; y < RowRooms; y++)
        {
            for (x = 0; x < ColRooms; x++)
            {
                RoomMap[y][x] = false;
            }
        }
        Crowded = false;
        CentN = 0;
        int roomAttemptCount = 0;

        // Attempt to generate rooms until we have attempted a minimum number of generations and we have reached a minimum number of rooms generated.
        while (roomAttemptCount < MinimumNumberOfRoomsToAttemptToCreate || CentN < MinimumRoomCount)
        {
            roomAttemptCount++;

            y = Game.RandomLessThan(RowRooms);
            x = Game.RandomLessThan(ColRooms);
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
                if (RoomBuild(y, x, Game.SingletonRepository.RoomLayouts.Get(nameof(Type1RoomLayout)), Game.Difficulty))
                {
                }
                continue;
            }
            if (Game.RandomLessThan(_dunUnusual) < Game.Difficulty)
            {
                k = Game.RandomLessThan(100);
                if (Game.RandomLessThan(_dunUnusual) < Game.Difficulty)
                {
                    if (k < 10)
                    {
                        if (maxVaultOk > 1)
                        {
                            if (RoomBuild(y, x, Game.SingletonRepository.RoomLayouts.Get(nameof(Type8RoomLayout)), Game.Difficulty))
                            {
                                continue;
                            }
                        }
                    }
                    if (k < 25)
                    {
                        if (maxVaultOk > 0)
                        {
                            if (RoomBuild(y, x, Game.SingletonRepository.RoomLayouts.Get(nameof(Type7RoomLayout)), Game.Difficulty))
                            {
                                continue;
                            }
                        }
                    }
                    if (k < 40 && RoomBuild(y, x, Game.SingletonRepository.RoomLayouts.Get(nameof(Type5RoomLayout)), Game.Difficulty))
                    {
                        continue;
                    }
                    if (k < 55 && RoomBuild(y, x, Game.SingletonRepository.RoomLayouts.Get(nameof(Type6RoomLayout)), Game.Difficulty))
                    {
                        continue;
                    }
                }
                if (k < 25 && RoomBuild(y, x, Game.SingletonRepository.RoomLayouts.Get(nameof(Type4RoomLayout)), Game.Difficulty))
                {
                    continue;
                }
                if (k < 50 && RoomBuild(y, x, Game.SingletonRepository.RoomLayouts.Get(nameof(Type3RoomLayout)), Game.Difficulty))
                {
                    continue;
                }
                if (k < 100 && RoomBuild(y, x, Game.SingletonRepository.RoomLayouts.Get(nameof(Type2RoomLayout)), Game.Difficulty))
                {
                    continue;
                }
            }
            if (RoomBuild(y, x, Game.SingletonRepository.RoomLayouts.Get(nameof(Type1RoomLayout)), Game.Difficulty))
            {
            }
        }
        if (CentN == 0)
        {
            CentN = CentN;
        }
        for (x = 0; x < Game.CurWid; x++)
        {
            GridTile cPtr = Game.Map.Grid[0][x];
            cPtr.SetFeature(Game.SingletonRepository.Tiles.Get(nameof(WallPermentSolidTile)));
        }
        for (x = 0; x < Game.CurWid; x++)
        {
            GridTile cPtr = Game.Map.Grid[Game.CurHgt - 1][x];
            cPtr.SetFeature(Game.SingletonRepository.Tiles.Get(nameof(WallPermentSolidTile)));
        }
        for (y = 0; y < Game.CurHgt; y++)
        {
            GridTile cPtr = Game.Map.Grid[y][0];
            cPtr.SetFeature(Game.SingletonRepository.Tiles.Get(nameof(WallPermentSolidTile)));
        }
        for (y = 0; y < Game.CurHgt; y++)
        {
            GridTile cPtr = Game.Map.Grid[y][Game.CurWid - 1];
            cPtr.SetFeature(Game.SingletonRepository.Tiles.Get(nameof(WallPermentSolidTile)));
        }
        for (int i = 0; i < CentN; i++)
        {
            int pick1 = Game.RandomLessThan(CentN);
            int pick2 = Game.RandomLessThan(CentN);
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
            BuildStreamer(Game.SingletonRepository.Tiles.Get(nameof(MagmaTile)), _dunStrMc);
        }
        for (int i = 0; i < _dunStrQua; i++)
        {
            BuildStreamer(Game.SingletonRepository.Tiles.Get(nameof(QuartzTile)), _dunStrQc);
        }
        if (destroyed)
        {
            DestroyLevel();
        }
        if (emptyLevel && (Game.DieRoll(_darkEmpty) != 1 || Game.DieRoll(100) > Game.Difficulty))
        {
            Game.RunScript(nameof(LightScript));
        }
    }
}
