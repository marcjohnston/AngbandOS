// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

internal class StandardDungeonGenerator : DungeonGenerator
{
    private const int MaximumNumberOfRooms = 100; // This is the maximum number of rooms that can be tracked when a dungeon is generated.  Any rooms generated beyond this count are not tracked as a room.
    private const int MinimumNumberOfRooms = 50; // The minimum number of rooms to attempt to create.

    private const int _smallLevel = 3;
    private const int DoorMax = 200; // TODO: This needs to be a List<Door> not a fixed size array.
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
    private const int TunnMax = 900; // TODO: This needs to be a List<Tunnel> not a fixed size array.
    private const int WallMax = 500; // TODO: This needs to be a List<Wall> not a fixed size array.

    public StandardDungeonGenerator(Game game) : base(game) { }
    public StandardDungeonGenerator(Game game, RestoreGameState restoreGameState) : this(game) { }

    public override GameStateBag? Serialize(SaveGameState saveGameState) => null;

    private bool NewPlayerSpot(GameRandom random)
    {
        int y = 0;
        int x = 0;
        int maxAttempts = 5000;
        while (maxAttempts-- != 0)
        {
            y = random.RandomBetween(1, Game.CurHgt - 2);
            x = random.RandomBetween(1, Game.CurWid - 2);
            if (!Game.GridOpenNoItemOrCreature(y, x))
            {
                continue;
            }
            if (Game.Grid[y][x].InVault)
            {
                continue;
            }
            break;
        }
        if (maxAttempts < 1)
        {
            return false;
        }
        Game.MapY.IntValue = y;
        Game.MapX.IntValue = x;
        return true;
    }

    /// <summary>
    /// Generates an underground level.
    /// </summary>
    /// <returns></returns>
    private bool GenerateDungeon(int objectLevel)
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
                Game.MaxPanelRows = Game.CurHgt / Constants.PlayableScreenHeight * 2 - 2;
                Game.MaxPanelCols = Game.CurWid / Constants.PlayableScreenWidth * 2 - 2;
                Game.PanelRow = Game.MaxPanelRows;
                Game.PanelCol = Game.MaxPanelCols;
            }
            else
            {
                Game.CurHgt = Game.MaxHgt;
                Game.CurWid = Game.MaxWid;
                Game.MaxPanelRows = Game.CurHgt / Constants.PlayableScreenHeight * 2 - 2;
                Game.MaxPanelCols = Game.CurWid / Constants.PlayableScreenWidth * 2 - 2;
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
            MakeDungeonLevel(objectLevel);
        }

        // Generate downstairs.
        AllocStairs(Game.DownStaircaseTile, Game.RandomBetween(3, 4), 3);

        // Generate upstairs.
        AllocStairs(Game.UpStaircaseTile, Game.RandomBetween(1, 2), 3);

        // Choose a spot for the player.
        if (!NewPlayerSpot(Game._mainSequence))
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
            while (Game.SingletonRepository.Get<MonsterRace>(rIdx).CurNum < Game.Quests[qIdx].ToKill - Game.Quests[qIdx].Killed)
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
        AllocObject(objectLevel, _allocSetBoth, _allocTypTrap, Game.DieRoll(k));
        AllocObject(objectLevel, _allocSetCorr, _allocTypRubble, Game.DieRoll(k));
        AllocObject(objectLevel, _allocSetRoom, _allocTypObject, Game.RandomNormal(_dunAmtRoom, 3));
        AllocObject(objectLevel, _allocSetBoth, _allocTypObject, Game.RandomNormal(_dunAmtItem, 3));
        AllocObject(objectLevel, _allocSetBoth, _allocTypGold, Game.RandomNormal(_dunAmtGold, 3));
        return true;
    }

    private bool RoomBuild(int objectLevel, int y0, int x0, RoomLayout roomType, int difficulty, bool crowded, int rowRooms, int colRooms, bool[][] roomMap, List<GridCoordinate> rooms) // TODO: This belongs to each room type
    {
        if (difficulty < roomType.Level)
        {
            return false;
        }
        if (crowded && (roomType.Type == 5 || roomType.Type == 6))
        {
            return false;
        }
        int y1 = y0 + roomType.Dy1;
        int y2 = y0 + roomType.Dy2;
        int x1 = x0 + roomType.Dx1;
        int x2 = x0 + roomType.Dx2;
        if (y1 < 0 || y2 >= rowRooms)
        {
            return false;
        }
        if (x1 < 0 || x2 >= colRooms)
        {
            return false;
        }
        int y;
        int x;
        for (y = y1; y <= y2; y++)
        {
            for (x = x1; x <= x2; x++)
            {
                if (roomMap[y][x])
                {
                    return false;
                }
            }
        }
        y = (y1 + y2 + 1) * _blockHgt / 2;
        x = (x1 + x2 + 1) * _blockWid / 2;
        roomType.Build(objectLevel, y, x);
        if (rooms.Count < MaximumNumberOfRooms)
        {
            rooms.Add(new GridCoordinate(x, y));
        }
        for (y = y1; y <= y2; y++)
        {
            for (x = x1; x <= x2; x++)
            {
                roomMap[y][x] = true;
            }
        }
        if (roomType.Type == 5 || roomType.Type == 6)
        {
            crowded = true;
        }
        return true;
    }

    private void DestroyLevel()
    {
        Tile wallBasicTile = Game.SingletonRepository.Get<Tile>(nameof(WallBasicTile));
        Tile quartzTile = Game.SingletonRepository.Get<Tile>(nameof(QuartzTile));
        Tile magmaTile = Game.SingletonRepository.Get<Tile>(nameof(MagmaTile));
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
                        GridTile cPtr = Game.Grid[y][x];
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
                GridTile cPtr = Game.Grid[ty][tx];

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
                GridTile cPtr = Game.Grid[y][x];
                double v = perlinNoise.Noise(10 * x * widthDivisor, 10 * y * heightDivisor, -0.5);
                v = (v + 1) / 2;
                double dX = Math.Abs(x - Game.CurWid / 2) * widthDivisor;
                double dY = Math.Abs(y - Game.CurHgt / 2) * heightDivisor;
                double d = Math.Max(dX, dY);
                const double elevation = 0.05;
                const double steepness = 6.0;
                const double dropoff = 50.0;
                v += elevation - dropoff * Math.Pow(d, steepness);
                v = Math.Min(1, Math.Max(0, v));
                int rounded = (int)(v * 10);
                if (rounded < 2 || rounded > 5)
                {
                    cPtr.SetFeature(Game.SingletonRepository.Get<Tile>(nameof(WallBasicTile)));
                }
                else
                {
                    cPtr.SetFeature(Game.SingletonRepository.Get<Tile>(nameof(DungeonFloorTile)));
                }
            }
        }
        for (int i = 0; i < _dunStrMag; i++)
        {
            BuildStreamer(Game.SingletonRepository.Get<Tile>(nameof(MagmaTile)), _dunStrMc);
        }
        for (int i = 0; i < _dunStrQua; i++)
        {
            BuildStreamer(Game.SingletonRepository.Get<Tile>(nameof(QuartzTile)), _dunStrQc);
        }
        for (int x = 0; x < Game.CurWid; x++)
        {
            GridTile cPtr = Game.Grid[0][x];
            cPtr.SetFeature(Game.SingletonRepository.Get<Tile>(nameof(WallPermentSolidTile)));
        }
        for (int x = 0; x < Game.CurWid; x++)
        {
            GridTile cPtr = Game.Grid[Game.CurHgt - 1][x];
            cPtr.SetFeature(Game.SingletonRepository.Get<Tile>(nameof(WallPermentSolidTile)));
        }
        for (int y = 0; y < Game.CurHgt; y++)
        {
            GridTile cPtr = Game.Grid[y][0];
            cPtr.SetFeature(Game.SingletonRepository.Get<Tile>(nameof(WallPermentSolidTile)));
        }
        for (int y = 0; y < Game.CurHgt; y++)
        {
            GridTile cPtr = Game.Grid[y][Game.CurWid - 1];
            cPtr.SetFeature(Game.SingletonRepository.Get<Tile>(nameof(WallPermentSolidTile)));
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
        if (Game.Grid[y + 1][x].FeatureType.IsWall)
        {
            k++;
        }
        if (Game.Grid[y - 1][x].FeatureType.IsWall)
        {
            k++;
        }
        if (Game.Grid[y][x + 1].FeatureType.IsWall)
        {
            k++;
        }
        if (Game.Grid[y][x - 1].FeatureType.IsWall)
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
                    GridTile cPtr = Game.Grid[y][x];
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
        if (Game.SingletonRepository.Get<MonsterRace>(rIdx).MaxNum == 0)
        {
            Game.SingletonRepository.Get<MonsterRace>(rIdx).MaxNum++;
            Game.MsgPrint("Resurrecting guardian.");
        }

        int y = Game.RandomLessThan(Game.MaxHgt);
        int x = Game.RandomLessThan(Game.MaxWid);
        int count = 0; // Prevent infinite loops.
        do
        {
            while (true)
            {
                count++;
                if (count > 100) // Prevent infinite loops.
                {
                    return;
                }

                y = Game.RandomLessThan(Game.MaxHgt);
                x = Game.RandomLessThan(Game.MaxWid);
                if (!Game.GridOpenNoItemOrCreature(y, x))
                {
                    continue;
                }
                if (Game.Distance(y, x, Game.MapY.IntValue, Game.MapX.IntValue) > 15)
                {
                    break;
                }
            }
        } while (!Game.PlaceMonsterByIndex(y, x, rIdx, false, false, false));
    }

    private void PlaceRubble(int y, int x)
    {
        GridTile cPtr = Game.Grid[y][x];
        cPtr.SetFeature(Game.SingletonRepository.Get<Tile>(nameof(RubbleTile)));
    }

    private void AllocObject(int objectLevel, int set, int typ, int num)
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
                bool isRoom = Game.Grid[y][x].InRoom;
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
                        Game.PlaceObject(objectLevel, y, x, false, false);
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
            GridTile cPtr = Game.Grid[y][x];
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
            if (Game.Grid[y - 1][x].FeatureType.IsWall && Game.Grid[y + 1][x].FeatureType.IsWall)
            {
                return true;
            }
            if (Game.Grid[y][x - 1].FeatureType.IsWall && Game.Grid[y][x + 1].FeatureType.IsWall)
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
        if (Game.Grid[y][x].FeatureType.IsWall)
        {
            return;
        }
        if (Game.Grid[y][x].InRoom)
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

    private void BuildTunnel(int row1, int col1, int row2, int col2, GridCoordinate?[] wall, GridCoordinate?[] tunn, int doorN, GridCoordinate?[] door)
    {
        int i, y, x;
        int mainLoopCount = 0;
        bool doorFlag = false;
        GridTile cPtr;
        int TunnN = 0;
        int WallN = 0;
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
            cPtr = Game.Grid[tmpRow][tmpCol];
            if (cPtr.FeatureType.IsWallPermanentSolid)
            {
                continue;
            }
            if (cPtr.FeatureType.IsWallPermanentOuter)
            {
                continue;
            }
            if (cPtr.FeatureType.IsWallSolid)
            {
                continue;
            }
            if (cPtr.FeatureType.IsWallOuter)
            {
                y = tmpRow + rowDir;
                x = tmpCol + colDir;
                if (Game.Grid[y][x].FeatureType.IsWallPermanentSolid)
                {
                    continue;
                }
                if (Game.Grid[y][x].FeatureType.IsWallPermanentOuter)
                {
                    continue;
                }
                if (Game.Grid[y][x].FeatureType.IsWallOuter)
                {
                    continue;
                }
                if (Game.Grid[y][x].FeatureType.IsWallSolid)
                {
                    continue;
                }
                row1 = tmpRow;
                col1 = tmpCol;
                if (WallN < WallMax)
                {
                    wall[WallN] = new GridCoordinate(col1, row1);
                    WallN++;
                }
                for (y = row1 - 1; y <= row1 + 1; y++)
                {
                    for (x = col1 - 1; x <= col1 + 1; x++)
                    {
                        if (Game.Grid[y][x].FeatureType.IsWallOuter)
                        {
                            Game.Grid[y][x].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(WallSolidTile)));
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
                    tunn[TunnN] = new GridCoordinate(col1, row1);
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
                    if (doorN < DoorMax)
                    {
                        door[doorN] = new GridCoordinate(col1, row1);
                        doorN++;
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
            y = tunn[i].Y;
            x = tunn[i].X;
            cPtr = Game.Grid[y][x];
            cPtr.RevertToBackground();
        }
        for (i = 0; i < WallN; i++)
        {
            y = wall[i].Y;
            x = wall[i].X;
            cPtr = Game.Grid[y][x];
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

    private void MakeDungeonLevel(int objectLevel)
    {
        //int DoorN;
        //int TunnN;
        //int WallN;
        int k;
        int y;
        int x;
        int maxVaultOk = 2;
        bool destroyed = false;
        bool emptyLevel = false;

        GridCoordinate?[] door = new GridCoordinate[DoorMax];
        GridCoordinate?[] tunn = new GridCoordinate[TunnMax];
        GridCoordinate?[] wall = new GridCoordinate[WallMax];

        // Compute the number of grid blocks for this size of dungeon.
        List<GridCoordinate> rooms = new List<GridCoordinate>(); // This is the center of each room that was generated.
        int rowRooms = Game.CurHgt / _blockHgt;
        int colRooms = Game.CurWid / _blockWid;

        // The dungeon must be large enough to support at least one type-1 room.
        Type1RoomLayout type1RoomLayout = (Type1RoomLayout)Game.SingletonRepository.Get<RoomLayout>(nameof(Type1RoomLayout));
        if (rowRooms < type1RoomLayout.Height)
        {
            Game.CurHgt = type1RoomLayout.Height * _blockHgt;
            rowRooms = Game.CurHgt / _blockHgt;
        }
        if (colRooms < type1RoomLayout.Width)
        {
            Game.CurWid = type1RoomLayout.Width * _blockWid;
            colRooms = Game.CurWid / _blockWid;
        }

        // Initialize the grid of rooms to prevent overlapping.
        bool[][] roomMap = new bool[MaxRoomsRow][]; // This is a quadrant of _blockWid wide blocks by _blockHgt blocks high map tracking if a room has been built in that quadrant.
        for (int i = 0; i < MaxRoomsRow; i++)
        {
            roomMap[i] = new bool[MaxRoomsCol];
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
                GridTile cPtr = Game.Grid[y][x];
                if (emptyLevel)
                {
                    cPtr.RevertToBackground();
                }
                else
                {
                    cPtr.SetFeature(Game.SingletonRepository.Get<Tile>(nameof(WallBasicTile)));
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
        for (y = 0; y < rowRooms; y++)
        {
            for (x = 0; x < colRooms; x++)
            {
                roomMap[y][x] = false;
            }
        }
        bool crowded = false;
        int roomAttemptCount = 0;

        // Attempt to generate rooms until we have attempted a minimum number of generations and we have reached a minimum number of rooms generated.
        while (roomAttemptCount < MinimumNumberOfRooms || rooms.Count < MinimumRoomCount)
        {
            roomAttemptCount++;

            y = Game.RandomLessThan(rowRooms);
            x = Game.RandomLessThan(colRooms);
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
                if (RoomBuild(objectLevel, y, x, Game.SingletonRepository.Get<RoomLayout>(nameof(Type1RoomLayout)), Game.Difficulty, crowded, rowRooms, colRooms, roomMap, rooms))
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
                            if (RoomBuild(objectLevel, y, x, Game.SingletonRepository.Get<RoomLayout>(nameof(Type8RoomLayout)), Game.Difficulty, crowded, rowRooms, colRooms, roomMap, rooms))
                            {
                                continue;
                            }
                        }
                    }
                    if (k < 25)
                    {
                        if (maxVaultOk > 0)
                        {
                            if (RoomBuild(objectLevel, y, x, Game.SingletonRepository.Get<RoomLayout>(nameof(Type7RoomLayout)), Game.Difficulty, crowded, rowRooms, colRooms, roomMap, rooms))
                            {
                                continue;
                            }
                        }
                    }
                    if (k < 40 && RoomBuild(objectLevel, y, x, Game.SingletonRepository.Get<RoomLayout>(nameof(Type5RoomLayout)), Game.Difficulty, crowded, rowRooms, colRooms, roomMap, rooms))
                    {
                        continue;
                    }
                    if (k < 55 && RoomBuild(objectLevel, y, x, Game.SingletonRepository.Get<RoomLayout>(nameof(Type6RoomLayout)), Game.Difficulty, crowded, rowRooms, colRooms, roomMap, rooms))
                    {
                        continue;
                    }
                }
                if (k < 25 && RoomBuild(objectLevel, y, x, Game.SingletonRepository.Get<RoomLayout>(nameof(Type4RoomLayout)), Game.Difficulty, crowded, rowRooms, colRooms, roomMap, rooms))
                {
                    continue;
                }
                if (k < 50 && RoomBuild(objectLevel, y, x, Game.SingletonRepository.Get<RoomLayout>(nameof(Type3RoomLayout)), Game.Difficulty, crowded, rowRooms, colRooms, roomMap, rooms))
                {
                    continue;
                }
                if (k < 100 && RoomBuild(objectLevel, y, x, Game.SingletonRepository.Get<RoomLayout>(nameof(Type2RoomLayout)), Game.Difficulty, crowded, rowRooms, colRooms, roomMap, rooms))
                {
                    continue;
                }
            }
            if (RoomBuild(objectLevel, y, x, Game.SingletonRepository.Get<RoomLayout>(nameof(Type1RoomLayout)), Game.Difficulty, crowded, rowRooms, colRooms, roomMap, rooms))
            {
            }
        }
        for (x = 0; x < Game.CurWid; x++)
        {
            GridTile cPtr = Game.Grid[0][x];
            cPtr.SetFeature(Game.SingletonRepository.Get<Tile>(nameof(WallPermentSolidTile)));
        }
        for (x = 0; x < Game.CurWid; x++)
        {
            GridTile cPtr = Game.Grid[Game.CurHgt - 1][x];
            cPtr.SetFeature(Game.SingletonRepository.Get<Tile>(nameof(WallPermentSolidTile)));
        }
        for (y = 0; y < Game.CurHgt; y++)
        {
            GridTile cPtr = Game.Grid[y][0];
            cPtr.SetFeature(Game.SingletonRepository.Get<Tile>(nameof(WallPermentSolidTile)));
        }
        for (y = 0; y < Game.CurHgt; y++)
        {
            GridTile cPtr = Game.Grid[y][Game.CurWid - 1];
            cPtr.SetFeature(Game.SingletonRepository.Get<Tile>(nameof(WallPermentSolidTile)));
        }
        for (int i = 0; i < rooms.Count; i++)
        {
            int pick1 = Game.RandomLessThan(rooms.Count);
            int pick2 = Game.RandomLessThan(rooms.Count);
            int y1 = rooms[pick1].Y;
            int x1 = rooms[pick1].X;
            rooms[pick1] = rooms[pick2].Clone();
            rooms[pick2] = new GridCoordinate(x1, y1);
        }
        int doorN = 0;
        y = rooms[rooms.Count - 1].Y;
        x = rooms[rooms.Count - 1].X;
        for (int i = 0; i < rooms.Count; i++)
        {
            BuildTunnel(rooms[i].Y, rooms[i].X, y, x, wall, tunn, doorN, door);
            y = rooms[i].Y;
            x = rooms[i].X;
        }
        for (int i = 0; i < doorN; i++)
        {
            y = door[i].Y;
            x = door[i].X;
            TryDoor(y, x - 1);
            TryDoor(y, x + 1);
            TryDoor(y - 1, x);
            TryDoor(y + 1, x);
        }
        for (int i = 0; i < _dunStrMag; i++)
        {
            BuildStreamer(Game.SingletonRepository.Get<Tile>(nameof(MagmaTile)), _dunStrMc);
        }
        for (int i = 0; i < _dunStrQua; i++)
        {
            BuildStreamer(Game.SingletonRepository.Get<Tile>(nameof(QuartzTile)), _dunStrQc);
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

    public override void GenerateNewLevel()
    {
        int ComputeTreasureFeelingIndex()
        {
            int treasureRating = 0;
            for (int y = 0; y < Game.CurHgt; y++)
            {
                for (int x = 0; x < Game.CurWid; x++)
                {
                    GridTile cPtr = Game.Grid[y][x];
                    foreach (Item item in cPtr.Items)
                    {
                        if (item.EffectiveAttributeSet.HasKeyedItemEnhancements(Game.FixedAttributeKey))
                        {
                            return 1;
                        }
                        if (!item.EffectiveAttributeSet.IsCursed && !item.EffectiveAttributeSet.Valueless && item.LevelNormallyFound > Game.Difficulty)
                        {
                            treasureRating += item.LevelNormallyFound - Game.Difficulty;
                        }
                        treasureRating += item.EffectiveAttributeSet.Get<SumEffectiveAttributeValue>(nameof(TreasureRatingAttribute)).Get();
                    }
                }
            }

            if (treasureRating > 100)
            {
                return 2;
            }
            else if (treasureRating > 80)
            {
                return 3;
            }
            else if (treasureRating > 60)
            {
                return 4;
            }
            else if (treasureRating > 40)
            {
                return 5;
            }
            else if (treasureRating > 30)
            {
                return 6;
            }
            else if (treasureRating > 20)
            {
                return 7;
            }
            else if (treasureRating > 10)
            {
                return 8;
            }
            else if (treasureRating > 0)
            {
                return 9;
            }
            else
            {
                return 10;
            }
        }
        void TownGen()
        {
            void MakeTownWalls()
            {
                int x;
                int y;
                GridTile cPtr;
                for (x = 0; x < Game.CurWid; x++)
                {
                    cPtr = Game.Grid[0][x];
                    cPtr.SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                    cPtr.PlayerMemorized = true;
                    cPtr.SelfLit = true;
                    cPtr = Game.Grid[Game.CurHgt - 1][x];
                    cPtr.SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                    cPtr.PlayerMemorized = true;
                    cPtr.SelfLit = true;
                }
                for (y = 0; y < Game.CurHgt; y++)
                {
                    cPtr = Game.Grid[y][0];
                    cPtr.SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                    cPtr.PlayerMemorized = true;
                    cPtr.SelfLit = true;
                    cPtr = Game.Grid[y][Game.CurWid - 1];
                    cPtr.SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                    cPtr.PlayerMemorized = true;
                    cPtr.SelfLit = true;
                }
                Game.Grid[0][(Game.CurWid / 2) - 2].SetBackgroundFeature(Game.SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
                Game.Grid[0][(Game.CurWid / 2) - 2].PlayerMemorized = true;
                Game.Grid[0][(Game.CurWid / 2) - 2].SelfLit = true;
                Game.Grid[0][(Game.CurWid / 2) - 1].SetBackgroundFeature(Game.SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
                Game.Grid[0][(Game.CurWid / 2) - 1].PlayerMemorized = true;
                Game.Grid[0][(Game.CurWid / 2) - 1].SelfLit = true;
                Game.Grid[0][(Game.CurWid / 2) + 1].SetBackgroundFeature(Game.SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
                Game.Grid[0][(Game.CurWid / 2) + 1].PlayerMemorized = true;
                Game.Grid[0][(Game.CurWid / 2) + 1].SelfLit = true;
                Game.Grid[0][(Game.CurWid / 2) + 2].SetBackgroundFeature(Game.SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
                Game.Grid[0][(Game.CurWid / 2) + 2].PlayerMemorized = true;
                Game.Grid[0][(Game.CurWid / 2) + 2].SelfLit = true;
                Game.Grid[1][(Game.CurWid / 2) - 2].SetBackgroundFeature(Game.SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
                Game.Grid[1][(Game.CurWid / 2) - 2].PlayerMemorized = true;
                Game.Grid[1][(Game.CurWid / 2) - 2].SelfLit = true;
                Game.Grid[1][(Game.CurWid / 2) - 1].SetBackgroundFeature(Game.SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
                Game.Grid[1][(Game.CurWid / 2) - 1].PlayerMemorized = true;
                Game.Grid[1][(Game.CurWid / 2) - 1].SelfLit = true;
                Game.Grid[1][(Game.CurWid / 2) + 1].SetBackgroundFeature(Game.SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
                Game.Grid[1][(Game.CurWid / 2) + 1].PlayerMemorized = true;
                Game.Grid[1][(Game.CurWid / 2) + 1].SelfLit = true;
                Game.Grid[1][(Game.CurWid / 2) + 2].SetBackgroundFeature(Game.SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
                Game.Grid[1][(Game.CurWid / 2) + 2].PlayerMemorized = true;
                Game.Grid[1][(Game.CurWid / 2) + 2].SelfLit = true;
                Game.Grid[0][(Game.CurWid / 2) - 2].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                Game.Grid[0][(Game.CurWid / 2) - 2].PlayerMemorized = true;
                Game.Grid[0][(Game.CurWid / 2) - 2].SelfLit = true;
                Game.Grid[0][(Game.CurWid / 2) - 1].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                Game.Grid[0][(Game.CurWid / 2) - 1].PlayerMemorized = true;
                Game.Grid[0][(Game.CurWid / 2) - 1].SelfLit = true;
                Game.Grid[0][Game.CurWid / 2].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(PathBorderNSTile)));
                Game.Grid[0][Game.CurWid / 2].PlayerMemorized = true;
                Game.Grid[0][Game.CurWid / 2].SelfLit = true;
                Game.Grid[0][(Game.CurWid / 2) + 1].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                Game.Grid[0][(Game.CurWid / 2) + 1].PlayerMemorized = true;
                Game.Grid[0][(Game.CurWid / 2) + 1].SelfLit = true;
                Game.Grid[0][(Game.CurWid / 2) + 2].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                Game.Grid[0][(Game.CurWid / 2) + 2].PlayerMemorized = true;
                Game.Grid[0][(Game.CurWid / 2) + 2].SelfLit = true;
                Game.Grid[1][(Game.CurWid / 2) - 2].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                Game.Grid[1][(Game.CurWid / 2) - 2].PlayerMemorized = true;
                Game.Grid[1][(Game.CurWid / 2) - 2].SelfLit = true;
                Game.Grid[1][(Game.CurWid / 2) - 1].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                Game.Grid[1][(Game.CurWid / 2) - 1].PlayerMemorized = true;
                Game.Grid[1][(Game.CurWid / 2) - 1].SelfLit = true;
                Game.Grid[1][Game.CurWid / 2].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(PathBaseTile)));
                Game.Grid[1][Game.CurWid / 2].PlayerMemorized = true;
                Game.Grid[1][Game.CurWid / 2].SelfLit = true;
                Game.Grid[1][(Game.CurWid / 2) + 1].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                Game.Grid[1][(Game.CurWid / 2) + 1].PlayerMemorized = true;
                Game.Grid[1][(Game.CurWid / 2) + 1].SelfLit = true;
                Game.Grid[1][(Game.CurWid / 2) + 2].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                Game.Grid[1][(Game.CurWid / 2) + 2].PlayerMemorized = true;
                Game.Grid[1][(Game.CurWid / 2) + 2].SelfLit = true;
                Game.Grid[Game.CurHgt - 1][(Game.CurWid / 2) - 2].SetBackgroundFeature(Game.SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
                Game.Grid[Game.CurHgt - 1][(Game.CurWid / 2) - 2].PlayerMemorized = true;
                Game.Grid[Game.CurHgt - 1][(Game.CurWid / 2) - 2].SelfLit = true;
                Game.Grid[Game.CurHgt - 1][(Game.CurWid / 2) - 1].SetBackgroundFeature(Game.SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
                Game.Grid[Game.CurHgt - 1][(Game.CurWid / 2) - 1].PlayerMemorized = true;
                Game.Grid[Game.CurHgt - 1][(Game.CurWid / 2) - 1].SelfLit = true;
                Game.Grid[Game.CurHgt - 1][(Game.CurWid / 2) + 1].SetBackgroundFeature(Game.SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
                Game.Grid[Game.CurHgt - 1][(Game.CurWid / 2) + 1].PlayerMemorized = true;
                Game.Grid[Game.CurHgt - 1][(Game.CurWid / 2) + 1].SelfLit = true;
                Game.Grid[Game.CurHgt - 1][(Game.CurWid / 2) + 2].SetBackgroundFeature(Game.SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
                Game.Grid[Game.CurHgt - 1][(Game.CurWid / 2) + 2].PlayerMemorized = true;
                Game.Grid[Game.CurHgt - 1][(Game.CurWid / 2) + 2].SelfLit = true;
                Game.Grid[Game.CurHgt - 2][(Game.CurWid / 2) - 2].SetBackgroundFeature(Game.SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
                Game.Grid[Game.CurHgt - 2][(Game.CurWid / 2) - 2].PlayerMemorized = true;
                Game.Grid[Game.CurHgt - 2][(Game.CurWid / 2) - 2].SelfLit = true;
                Game.Grid[Game.CurHgt - 2][(Game.CurWid / 2) - 1].SetBackgroundFeature(Game.SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
                Game.Grid[Game.CurHgt - 2][(Game.CurWid / 2) - 1].PlayerMemorized = true;
                Game.Grid[Game.CurHgt - 2][(Game.CurWid / 2) - 1].SelfLit = true;
                Game.Grid[Game.CurHgt - 2][(Game.CurWid / 2) + 1].SetBackgroundFeature(Game.SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
                Game.Grid[Game.CurHgt - 2][(Game.CurWid / 2) + 1].PlayerMemorized = true;
                Game.Grid[Game.CurHgt - 2][(Game.CurWid / 2) + 1].SelfLit = true;
                Game.Grid[Game.CurHgt - 2][(Game.CurWid / 2) + 2].SetBackgroundFeature(Game.SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
                Game.Grid[Game.CurHgt - 2][(Game.CurWid / 2) + 2].PlayerMemorized = true;
                Game.Grid[Game.CurHgt - 2][(Game.CurWid / 2) + 2].SelfLit = true;
                Game.Grid[Game.CurHgt - 1][(Game.CurWid / 2) - 2].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                Game.Grid[Game.CurHgt - 1][(Game.CurWid / 2) - 2].PlayerMemorized = true;
                Game.Grid[Game.CurHgt - 1][(Game.CurWid / 2) - 2].SelfLit = true;
                Game.Grid[Game.CurHgt - 1][(Game.CurWid / 2) - 1].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                Game.Grid[Game.CurHgt - 1][(Game.CurWid / 2) - 1].PlayerMemorized = true;
                Game.Grid[Game.CurHgt - 1][(Game.CurWid / 2) - 1].SelfLit = true;
                Game.Grid[Game.CurHgt - 1][Game.CurWid / 2].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(PathBorderNSTile)));
                Game.Grid[Game.CurHgt - 1][Game.CurWid / 2].PlayerMemorized = true;
                Game.Grid[Game.CurHgt - 1][Game.CurWid / 2].SelfLit = true;
                Game.Grid[Game.CurHgt - 1][(Game.CurWid / 2) + 1].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                Game.Grid[Game.CurHgt - 1][(Game.CurWid / 2) + 1].PlayerMemorized = true;
                Game.Grid[Game.CurHgt - 1][(Game.CurWid / 2) + 1].SelfLit = true;
                Game.Grid[Game.CurHgt - 1][(Game.CurWid / 2) + 2].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                Game.Grid[Game.CurHgt - 1][(Game.CurWid / 2) + 2].PlayerMemorized = true;
                Game.Grid[Game.CurHgt - 1][(Game.CurWid / 2) + 2].SelfLit = true;
                Game.Grid[Game.CurHgt - 2][(Game.CurWid / 2) - 2].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                Game.Grid[Game.CurHgt - 2][(Game.CurWid / 2) - 2].PlayerMemorized = true;
                Game.Grid[Game.CurHgt - 2][(Game.CurWid / 2) - 2].SelfLit = true;
                Game.Grid[Game.CurHgt - 2][(Game.CurWid / 2) - 1].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                Game.Grid[Game.CurHgt - 2][(Game.CurWid / 2) - 1].PlayerMemorized = true;
                Game.Grid[Game.CurHgt - 2][(Game.CurWid / 2) - 1].SelfLit = true;
                Game.Grid[Game.CurHgt - 2][Game.CurWid / 2].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(PathBaseTile)));
                Game.Grid[Game.CurHgt - 2][Game.CurWid / 2].PlayerMemorized = true;
                Game.Grid[Game.CurHgt - 2][Game.CurWid / 2].SelfLit = true;
                Game.Grid[Game.CurHgt - 2][(Game.CurWid / 2) + 1].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                Game.Grid[Game.CurHgt - 2][(Game.CurWid / 2) + 1].PlayerMemorized = true;
                Game.Grid[Game.CurHgt - 2][(Game.CurWid / 2) + 1].SelfLit = true;
                Game.Grid[Game.CurHgt - 2][(Game.CurWid / 2) + 2].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                Game.Grid[Game.CurHgt - 2][(Game.CurWid / 2) + 2].PlayerMemorized = true;
                Game.Grid[Game.CurHgt - 2][(Game.CurWid / 2) + 2].SelfLit = true;
                Game.Grid[(Game.CurHgt / 2) - 2][0].SetBackgroundFeature(Game.SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
                Game.Grid[(Game.CurHgt / 2) - 2][0].PlayerMemorized = true;
                Game.Grid[(Game.CurHgt / 2) - 2][0].SelfLit = true;
                Game.Grid[(Game.CurHgt / 2) - 1][0].SetBackgroundFeature(Game.SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
                Game.Grid[(Game.CurHgt / 2) - 1][0].PlayerMemorized = true;
                Game.Grid[(Game.CurHgt / 2) - 1][0].SelfLit = true;
                Game.Grid[(Game.CurHgt / 2) + 1][0].SetBackgroundFeature(Game.SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
                Game.Grid[(Game.CurHgt / 2) + 1][0].PlayerMemorized = true;
                Game.Grid[(Game.CurHgt / 2) + 1][0].SelfLit = true;
                Game.Grid[(Game.CurHgt / 2) + 2][0].SetBackgroundFeature(Game.SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
                Game.Grid[(Game.CurHgt / 2) + 2][0].PlayerMemorized = true;
                Game.Grid[(Game.CurHgt / 2) + 2][0].SelfLit = true;
                Game.Grid[(Game.CurHgt / 2) - 2][1].SetBackgroundFeature(Game.SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
                Game.Grid[(Game.CurHgt / 2) - 2][1].PlayerMemorized = true;
                Game.Grid[(Game.CurHgt / 2) - 2][1].SelfLit = true;
                Game.Grid[(Game.CurHgt / 2) - 1][1].SetBackgroundFeature(Game.SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
                Game.Grid[(Game.CurHgt / 2) - 1][1].PlayerMemorized = true;
                Game.Grid[(Game.CurHgt / 2) - 1][1].SelfLit = true;
                Game.Grid[(Game.CurHgt / 2) + 1][1].SetBackgroundFeature(Game.SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
                Game.Grid[(Game.CurHgt / 2) + 1][1].PlayerMemorized = true;
                Game.Grid[(Game.CurHgt / 2) + 1][1].SelfLit = true;
                Game.Grid[(Game.CurHgt / 2) + 2][1].SetBackgroundFeature(Game.SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
                Game.Grid[(Game.CurHgt / 2) + 2][1].PlayerMemorized = true;
                Game.Grid[(Game.CurHgt / 2) + 2][1].SelfLit = true;
                Game.Grid[(Game.CurHgt / 2) - 2][0].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                Game.Grid[(Game.CurHgt / 2) - 2][0].PlayerMemorized = true;
                Game.Grid[(Game.CurHgt / 2) - 2][0].SelfLit = true;
                Game.Grid[(Game.CurHgt / 2) - 1][0].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                Game.Grid[(Game.CurHgt / 2) - 1][0].PlayerMemorized = true;
                Game.Grid[(Game.CurHgt / 2) - 1][0].SelfLit = true;
                Game.Grid[Game.CurHgt / 2][0].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(PathBorderEWTile)));
                Game.Grid[Game.CurHgt / 2][0].PlayerMemorized = true;
                Game.Grid[Game.CurHgt / 2][0].SelfLit = true;
                Game.Grid[(Game.CurHgt / 2) + 1][0].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                Game.Grid[(Game.CurHgt / 2) + 1][0].PlayerMemorized = true;
                Game.Grid[(Game.CurHgt / 2) + 1][0].SelfLit = true;
                Game.Grid[(Game.CurHgt / 2) + 2][0].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                Game.Grid[(Game.CurHgt / 2) + 2][0].PlayerMemorized = true;
                Game.Grid[(Game.CurHgt / 2) + 2][0].SelfLit = true;
                Game.Grid[(Game.CurHgt / 2) - 2][1].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                Game.Grid[(Game.CurHgt / 2) - 2][1].PlayerMemorized = true;
                Game.Grid[(Game.CurHgt / 2) - 2][1].SelfLit = true;
                Game.Grid[(Game.CurHgt / 2) - 1][1].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                Game.Grid[(Game.CurHgt / 2) - 1][1].PlayerMemorized = true;
                Game.Grid[(Game.CurHgt / 2) - 1][1].SelfLit = true;
                Game.Grid[Game.CurHgt / 2][1].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(PathBaseTile)));
                Game.Grid[Game.CurHgt / 2][1].PlayerMemorized = true;
                Game.Grid[Game.CurHgt / 2][1].SelfLit = true;
                Game.Grid[(Game.CurHgt / 2) + 1][1].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                Game.Grid[(Game.CurHgt / 2) + 1][1].PlayerMemorized = true;
                Game.Grid[(Game.CurHgt / 2) + 1][1].SelfLit = true;
                Game.Grid[(Game.CurHgt / 2) + 2][1].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                Game.Grid[(Game.CurHgt / 2) + 2][1].PlayerMemorized = true;
                Game.Grid[(Game.CurHgt / 2) + 2][1].SelfLit = true;
                Game.Grid[(Game.CurHgt / 2) - 2][Game.CurWid - 1].SetBackgroundFeature(Game.SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
                Game.Grid[(Game.CurHgt / 2) - 2][Game.CurWid - 1].PlayerMemorized = true;
                Game.Grid[(Game.CurHgt / 2) - 2][Game.CurWid - 1].SelfLit = true;
                Game.Grid[(Game.CurHgt / 2) - 1][Game.CurWid - 1].SetBackgroundFeature(Game.SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
                Game.Grid[(Game.CurHgt / 2) - 1][Game.CurWid - 1].PlayerMemorized = true;
                Game.Grid[(Game.CurHgt / 2) - 1][Game.CurWid - 1].SelfLit = true;
                Game.Grid[(Game.CurHgt / 2) + 1][Game.CurWid - 1].SetBackgroundFeature(Game.SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
                Game.Grid[(Game.CurHgt / 2) + 1][Game.CurWid - 1].PlayerMemorized = true;
                Game.Grid[(Game.CurHgt / 2) + 1][Game.CurWid - 1].SelfLit = true;
                Game.Grid[(Game.CurHgt / 2) + 2][Game.CurWid - 1].SetBackgroundFeature(Game.SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
                Game.Grid[(Game.CurHgt / 2) + 2][Game.CurWid - 1].PlayerMemorized = true;
                Game.Grid[(Game.CurHgt / 2) + 2][Game.CurWid - 1].SelfLit = true;
                Game.Grid[(Game.CurHgt / 2) - 2][Game.CurWid - 2].SetBackgroundFeature(Game.SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
                Game.Grid[(Game.CurHgt / 2) - 2][Game.CurWid - 2].PlayerMemorized = true;
                Game.Grid[(Game.CurHgt / 2) - 2][Game.CurWid - 2].SelfLit = true;
                Game.Grid[(Game.CurHgt / 2) - 1][Game.CurWid - 2].SetBackgroundFeature(Game.SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
                Game.Grid[(Game.CurHgt / 2) - 1][Game.CurWid - 2].PlayerMemorized = true;
                Game.Grid[(Game.CurHgt / 2) - 1][Game.CurWid - 2].SelfLit = true;
                Game.Grid[(Game.CurHgt / 2) + 1][Game.CurWid - 2].SetBackgroundFeature(Game.SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
                Game.Grid[(Game.CurHgt / 2) + 1][Game.CurWid - 2].PlayerMemorized = true;
                Game.Grid[(Game.CurHgt / 2) + 1][Game.CurWid - 2].SelfLit = true;
                Game.Grid[(Game.CurHgt / 2) + 2][Game.CurWid - 2].SetBackgroundFeature(Game.SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
                Game.Grid[(Game.CurHgt / 2) + 2][Game.CurWid - 2].PlayerMemorized = true;
                Game.Grid[(Game.CurHgt / 2) + 2][Game.CurWid - 2].SelfLit = true;
                Game.Grid[(Game.CurHgt / 2) - 2][Game.CurWid - 1].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                Game.Grid[(Game.CurHgt / 2) - 2][Game.CurWid - 1].PlayerMemorized = true;
                Game.Grid[(Game.CurHgt / 2) - 2][Game.CurWid - 1].SelfLit = true;
                Game.Grid[(Game.CurHgt / 2) - 1][Game.CurWid - 1].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                Game.Grid[(Game.CurHgt / 2) - 1][Game.CurWid - 1].PlayerMemorized = true;
                Game.Grid[(Game.CurHgt / 2) - 1][Game.CurWid - 1].SelfLit = true;
                Game.Grid[Game.CurHgt / 2][Game.CurWid - 1].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(PathBorderEWTile)));
                Game.Grid[Game.CurHgt / 2][Game.CurWid - 1].PlayerMemorized = true;
                Game.Grid[Game.CurHgt / 2][Game.CurWid - 1].SelfLit = true;
                Game.Grid[(Game.CurHgt / 2) + 1][Game.CurWid - 1].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                Game.Grid[(Game.CurHgt / 2) + 1][Game.CurWid - 1].PlayerMemorized = true;
                Game.Grid[(Game.CurHgt / 2) + 1][Game.CurWid - 1].SelfLit = true;
                Game.Grid[(Game.CurHgt / 2) + 2][Game.CurWid - 1].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                Game.Grid[(Game.CurHgt / 2) + 2][Game.CurWid - 1].PlayerMemorized = true;
                Game.Grid[(Game.CurHgt / 2) + 2][Game.CurWid - 1].SelfLit = true;
                Game.Grid[(Game.CurHgt / 2) - 2][Game.CurWid - 2].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                Game.Grid[(Game.CurHgt / 2) - 2][Game.CurWid - 2].PlayerMemorized = true;
                Game.Grid[(Game.CurHgt / 2) - 2][Game.CurWid - 2].SelfLit = true;
                Game.Grid[(Game.CurHgt / 2) - 1][Game.CurWid - 2].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                Game.Grid[(Game.CurHgt / 2) - 1][Game.CurWid - 2].PlayerMemorized = true;
                Game.Grid[(Game.CurHgt / 2) - 1][Game.CurWid - 2].SelfLit = true;
                Game.Grid[Game.CurHgt / 2][Game.CurWid - 2].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(PathBaseTile)));
                Game.Grid[Game.CurHgt / 2][Game.CurWid - 2].PlayerMemorized = true;
                Game.Grid[Game.CurHgt / 2][Game.CurWid - 2].SelfLit = true;
                Game.Grid[(Game.CurHgt / 2) + 1][Game.CurWid - 2].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                Game.Grid[(Game.CurHgt / 2) + 1][Game.CurWid - 2].PlayerMemorized = true;
                Game.Grid[(Game.CurHgt / 2) + 1][Game.CurWid - 2].SelfLit = true;
                Game.Grid[(Game.CurHgt / 2) + 2][Game.CurWid - 2].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                Game.Grid[(Game.CurHgt / 2) + 2][Game.CurWid - 2].PlayerMemorized = true;
                Game.Grid[(Game.CurHgt / 2) + 2][Game.CurWid - 2].SelfLit = true;
            }
            void MakeTownContents()
            {
                void MakeTownCentre(GameRandom random)
                {
                    int xx = Game.CurWid / 2;
                    int yy = Game.CurHgt / 2;
                    switch (random.DieRoll(12))
                    {
                        case 1:
                        case 3:
                            Game.Grid[yy - 1][xx - 1].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(PathBaseTile)));
                            Game.Grid[yy][xx - 1].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(PathBaseTile)));
                            Game.Grid[yy + 1][xx - 1].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(PathBaseTile)));
                            Game.Grid[yy - 1][xx].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(PathBaseTile)));
                            Game.Grid[yy + 1][xx].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(PathBaseTile)));
                            Game.Grid[yy - 1][xx + 1].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(PathBaseTile)));
                            Game.Grid[yy][xx + 1].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(PathBaseTile)));
                            Game.Grid[yy + 1][xx + 1].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(PathBaseTile)));
                            switch (random.DieRoll(6))
                            {
                                case 4:
                                case 1:
                                    Game.Grid[yy][xx].RevertToBackground();
                                    break;

                                case 2:
                                    Game.Grid[yy][xx].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(StatueTile)));
                                    break;

                                default:
                                    Game.Grid[yy][xx].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(FountainTile)));
                                    break;
                            }
                            return;

                        case 2:
                        case 8:
                        case 9:
                        case 12:
                            int x = xx - 1;
                            if (random.DieRoll(2) == 1)
                            {
                                x = xx + 1;
                            }
                            int y = yy - 1;
                            if (random.DieRoll(2) == 1)
                            {
                                y = yy + 1;
                            }
                            Game.Grid[y][x].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(SignpostTile)));
                            break;

                        default:
                            return;
                    }
                }
                void BuildStores(GameRandom random)
                {
                    void BuildStore(GameRandom random, Store store, int yy, int xx)
                    {
                        int y, x;
                        GridTile cPtr;

                        if (store.StoreFactory.IsEmptyLot)
                        {
                            switch (random.DieRoll(10))
                            {
                                case 3:
                                case 7:
                                case 9:
                                    break;

                                case 6:
                                    BuildGraveyard(random, yy, xx);
                                    break;

                                default:
                                    BuildField(random, yy, xx);
                                    break;
                            }
                            return;
                        }

                        int y0 = (yy * 9) + 6;
                        int x0 = (xx * 15) + 10;
                        int y1 = y0 - random.DieRoll(2);
                        int y2 = y0 + random.DieRoll(2) + 1;
                        int x1 = x0 - random.DieRoll(3) - 2;
                        int x2 = x0 + random.DieRoll(3) + 2;
                        if ((y2 - y1) % 2 == 0)
                        {
                            y2++;
                        }
                        for (y = y1; y <= y2; y++)
                        {
                            for (x = x1; x <= x2; x++)
                            {
                                cPtr = Game.Grid[y][x];
                                if (!store.StoreFactory.BuildingsMadeFromPermanentRock)
                                {
                                    switch (random.DieRoll(6))
                                    {
                                        case 1:
                                            cPtr.SetFeature(Game.SingletonRepository.Get<Tile>(nameof(WallInnerTile)));
                                            break;

                                        case 2:
                                        case 3:
                                        case 4:
                                            cPtr.SetFeature(Game.SingletonRepository.Get<Tile>(nameof(RubbleTile)));
                                            break;
                                    }
                                }
                                else
                                {
                                    if (y == y2)
                                    {
                                        cPtr.SetFeature(Game.SingletonRepository.Get<Tile>(nameof(WallPermanentBuildingTile)));
                                    }
                                    else
                                    {
                                        cPtr.SetFeature(Game.SingletonRepository.Get<Tile>(nameof(RoofTile)));
                                    }
                                }
                                cPtr.PlayerMemorized = true;
                                cPtr.SelfLit = true;
                            }
                        }
                        y = y2;
                        x = random.RandomBetween(x1 + 1, x2 - 2);
                        cPtr = Game.Grid[y][x];
                        if (store.StoreFactory.StoreEntranceDoorsAreBlownOff)
                        {
                            if (random.DieRoll(8) == 6)
                            {
                                Game.PlaceRandomDoor(y, x);
                            }
                        }
                        else
                        {
                            cPtr.SetFeature(store.StoreFactory.Tile);
                        }
                        store.SetLocation(x, y);
                        for (++y; y < y0 + 7; y++)
                        {
                            cPtr = Game.Grid[y][x];
                            cPtr.SetFeature(Game.SingletonRepository.Get<Tile>(nameof(PathBaseTile)));
                        }
                        y--;
                        int dX = Math.Sign((Game.CurWid / 2) - x);
                        for (x += dX; x != Game.CurWid / 2; x += dX)
                        {
                            cPtr = Game.Grid[y][x];
                            cPtr.SetFeature(Game.SingletonRepository.Get<Tile>(nameof(PathBaseTile)));
                        }
                    }

                    List<string> occupied = new List<string>();
                    for (int i = 0; i < Game.CurTown.Stores.Length; i++)
                    {
                        int x;
                        int y;
                        do
                        {
                            x = random.RandomBetween(0, 3);
                            y = random.RandomBetween(0, 3);
                            if ((x == 1 || x == 2 || y == 1 || y == 2) && !occupied.Contains($"{x},{y}"))
                            {
                                break;
                            }
                        } while (true);
                        occupied.Add($"{x},{y}");
                        BuildStore(random, Game.CurTown.Stores[i], y, x);
                    }

                    int maxSpacesRemaining = 4 * 4 - Game.CurTown.Stores.Length;
                    for (int i = 0; i < maxSpacesRemaining; i++)
                    {
                        switch (random.DieRoll(10))
                        {
                            case 3:
                            case 7:
                            case 9:
                                break;

                            default:
                                int x;
                                int y;
                                do
                                {
                                    x = random.RandomBetween(0, 3);
                                    y = random.RandomBetween(0, 3);
                                    if (!occupied.Contains($"{x},{y}"))
                                    {
                                        break;
                                    }
                                } while (true);
                                occupied.Add($"{x},{y}");

                                if (Game.CurTown.UnusedStoreLotsAreGraveyards)
                                {
                                    BuildGraveyard(random, y, x);
                                }
                                else
                                {
                                    BuildField(random, y, x);
                                }
                                break;
                        }
                    }
                }
                void BuildField(GameRandom random, int yy, int xx)
                {
                    int y0 = (yy * 9) + 8;
                    int x0 = (xx * 15) + 10;
                    int y1 = y0 - random.DieRoll(2) - 1;
                    int y2 = y0 + random.DieRoll(2) + 1;
                    int x1 = x0 - random.DieRoll(3) - 2;
                    int x2 = x0 + random.DieRoll(3) + 2;
                    Tile fieldTile = Game.SingletonRepository.Get<Tile>(nameof(FieldTile));
                    for (int x = x1; x < x2; x++)
                    {
                        for (int y = y1; y < y2; y++)
                        {
                            Game.Grid[y][x].SetFeature(fieldTile);
                            Game.Grid[y][x].SetBackgroundFeature(fieldTile);
                        }
                    }
                    if (random.DieRoll(5) == 4)
                    {
                        int x = random.RandomBetween(x1, x2);
                        int y = random.RandomBetween(y1, y2);
                        Game.Grid[y][x].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(ScarecrowTile)));
                    }
                }
                void BuildGraveyard(GameRandom random, int yy, int xx)
                {
                    int y0 = (yy * 9) + 8;
                    int x0 = (xx * 15) + 10;
                    int y1 = y0 - random.DieRoll(2) - 1;
                    int y2 = y0 + random.DieRoll(2) + 1;
                    int x1 = x0 - random.DieRoll(3) - 2;
                    int x2 = x0 + random.DieRoll(3) + 2;
                    for (int i = 0; i < random.RandomBetween(10, 20); i++)
                    {
                        int x = (random.RandomBetween(x1, x2) / 2 * 2) + 1;
                        int y = (random.RandomBetween(y1, y2) / 2 * 2) + 1;
                        Game.Grid[y][x].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(GraveTile)));
                    }
                }
                void BuildPath()
                {
                    int yy = Game.CurHgt / 2;
                    for (int x = 1; x < Game.CurWid - 1; x++)
                    {
                        Game.Grid[yy][x].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(PathBaseTile)));
                    }
                    int xx = Game.CurWid / 2;
                    for (int y = 1; y < Game.CurHgt - 1; y++)
                    {
                        Game.Grid[y][xx].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(PathBaseTile)));
                    }
                }
                void BuildRocks(GameRandom random)
                {
                    GridTile cPtr;
                    for (int n = 0; n < random.RandomBetween(1, 10) - 6; n++)
                    {
                        int x = random.RandomBetween(1, Game.CurWid - 2);
                        int y = random.RandomBetween(1, Game.CurHgt - 2);
                        cPtr = Game.Grid[y][x];
                        if (cPtr.FeatureType == cPtr.BackgroundFeature)
                        {
                            cPtr.SetFeature(Game.RockTile);
                            cPtr.PlayerMemorized = true;
                        }
                    }
                }
                void BuildTrees(GameRandom random)
                {
                    GridTile cPtr;
                    for (int n = 0; n < random.RandomBetween(5, 10); n++)
                    {
                        int x = random.RandomBetween(1, Game.CurWid - 2);
                        int y = random.RandomBetween(1, Game.CurHgt - 2);
                        cPtr = Game.Grid[y][x];
                        if (cPtr.FeatureType == cPtr.BackgroundFeature)
                        {
                            cPtr.SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TreeTile)));
                            cPtr.PlayerMemorized = true;
                        }
                    }
                }
                void BuildBushes(GameRandom random)
                {
                    GridTile cPtr;
                    for (int n = 0; n < random.RandomBetween(5, 10); n++)
                    {
                        int x = random.RandomBetween(1, Game.CurWid - 2);
                        int y = random.RandomBetween(1, Game.CurHgt - 2);
                        cPtr = Game.Grid[y][x];
                        if (cPtr.FeatureType == cPtr.BackgroundFeature)
                        {
                            cPtr.SetFeature(Game.SingletonRepository.Get<Tile>(nameof(BushTile)));
                            cPtr.PlayerMemorized = true;
                        }
                    }
                }
                void AddPaths()
                {
                    GridTile cPtr;
                    int x = Game.CurWid / 2;
                    cPtr = Game.Grid[0][x];
                    cPtr.SetFeature(Game.SingletonRepository.Get<Tile>(nameof(PathBorderNSTile)));
                    cPtr.PlayerMemorized = true;
                    x = Game.CurWid - 2;
                    int y = Game.CurHgt / 2;
                    cPtr = Game.Grid[y][x + 1];
                    cPtr.SetFeature(Game.SingletonRepository.Get<Tile>(nameof(PathBorderEWTile)));
                    cPtr.PlayerMemorized = true;
                    x = Game.CurWid / 2;
                    y = Game.CurHgt - 2;
                    cPtr = Game.Grid[y + 1][x];
                    cPtr.SetFeature(Game.SingletonRepository.Get<Tile>(nameof(PathBorderNSTile)));
                    cPtr.PlayerMemorized = true;
                    x = 1;
                    y = Game.CurHgt / 2;
                    cPtr = Game.Grid[y][0];
                    cPtr.SetFeature(Game.SingletonRepository.Get<Tile>(nameof(PathBorderEWTile)));
                    cPtr.PlayerMemorized = true;
                }
                GridCoordinate AddStairsDown(GameRandom random)
                {
                    GridTile cPtr;
                    int dummy = 0;
                    int x;
                    int y;
                    do
                    {
                        dummy++;
                        y = random.RandomBetween(12, 29);
                        x = random.RandomBetween(17, 46);
                        if (Game.GridOpenNoItemOrCreature(y, x))
                        {
                            break;
                        }
                    } while (true);
                    cPtr = Game.Grid[y][x];
                    cPtr.SetFeature(Game.DownStaircaseTile);
                    cPtr.PlayerMemorized = true;
                    return new GridCoordinate(x, y);
                }
                void SetStartingLocation(GameRandom random, GridCoordinate downStairsLocation)
                {
                    switch (Game.CameFrom)
                    {
                        case LevelStartEnum.StartRandom:
                            NewPlayerSpot(random);
                            break;

                        case LevelStartEnum.StartStairs:
                            Game.MapY.IntValue = downStairsLocation.Y;
                            Game.MapX.IntValue = downStairsLocation.X;
                            break;

                        case LevelStartEnum.StartWalk:
                            break;

                        case LevelStartEnum.StartHouse:
                            foreach (Store store in Game.CurTown.Stores)
                            {
                                if (store.GetType() != typeof(HomeStoreFactory))
                                {
                                    continue;
                                }
                                Game.MapY.IntValue = store.Y;
                                Game.MapX.IntValue = store.X;
                            }
                            break;

                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }

                GameRandom random = new GameRandom(Game.CurTown.Seed);

                BuildPath();
                BuildStores(random);
                BuildRocks(random);
                BuildTrees(random);
                BuildBushes(random);
                MakeTownCentre(random);
                AddPaths();
                GridCoordinate downStairsLocation = AddStairsDown(random);
                SetStartingLocation(random, downStairsLocation);
            }

            for (int y = 0; y < Game.CurHgt; y++)
            {
                for (int x = 0; x < Game.CurWid; x++)
                {
                    GridTile cPtr = Game.Grid[y][x];
                    cPtr.RevertToBackground();
                }
            }
            MakeTownWalls();
            MakeCornerTowers(Game.WildernessX, Game.WildernessY);
            MakeTownContents();
            Game.ResolvePaths();
            if (Game.IsLight)
            {
                for (int y = 0; y < Game.CurHgt; y++)
                {
                    for (int x = 0; x < Game.CurWid; x++)
                    {
                        GridTile cPtr = Game.Grid[y][x];
                        cPtr.SelfLit = true;
                        cPtr.PlayerMemorized = true;
                    }
                }
                for (int i = 0; i < Constants.MinMAllocTd; i++)
                {
                    Game.AllocMonster(3, true);
                }
            }
            else
            {
                for (int i = 0; i < Constants.MinMAllocTn; i++)
                {
                    Game.AllocMonster(3, true);
                }
            }
        }
        void WildernessGen()
        {
            void MakeWildernessFeatures(GameRandom random, int wildx, int wildy, out int stairX, out int stairY)
            {
                void MakeDungeonEntrance(GameRandom random, int left, int top, int width, int height, out int stairX, out int stairY)
                {
                    int dummy = 0;
                    int x = 1;
                    int y = 1;
                    while (dummy < Game.SafeMaxAttempts)
                    {
                        dummy++;
                        y = random.RandomBetween(top, top + height);
                        x = random.RandomBetween(left, left + width);
                        if (Game.GridOpenNoItemOrCreature(y, x))
                        {
                            break;
                        }
                    }
                    Game.Grid[y - 2][x].RevertToBackground();
                    Game.Grid[y - 1][x - 1].RevertToBackground();
                    Game.Grid[y - 1][x].RevertToBackground();
                    Game.Grid[y - 1][x + 1].RevertToBackground();
                    Game.Grid[y][x - 2].RevertToBackground();
                    Game.Grid[y][x - 1].RevertToBackground();
                    Game.Grid[y][x].SetFeature(Game.DownStaircaseTile);
                    stairX = x;
                    stairY = y;
                    Game.Grid[y][x + 1].RevertToBackground();
                    Game.Grid[y][x + 2].RevertToBackground();
                    Game.Grid[y + 1][x - 1].RevertToBackground();
                    Game.Grid[y + 1][x].RevertToBackground();
                    Game.Grid[y + 1][x + 1].RevertToBackground();
                    Game.Grid[y + 2][x].RevertToBackground();
                }
                void MakeHenge(int left, int top, int width, int height)
                {
                    int midX = left + (width / 2);
                    int midY = top + (height / 2);
                    for (int y = midY - 3; y < midY + 3; y++)
                    {
                        Game.Grid[y][midX - 7].SetBackgroundFeature(Game.GrassTile);
                        Game.Grid[y][midX - 7].SetFeature(Game.GrassTile);
                    }
                    for (int y = midY - 5; y < midY + 5; y++)
                    {
                        Game.Grid[y][midX - 6].SetBackgroundFeature(Game.GrassTile);
                        Game.Grid[y][midX - 6].SetFeature(Game.GrassTile);
                    }
                    for (int y = midY - 6; y < midY + 6; y++)
                    {
                        Game.Grid[y][midX - 5].SetBackgroundFeature(Game.GrassTile);
                        Game.Grid[y][midX - 5].SetFeature(Game.GrassTile);
                    }
                    for (int y = midY - 6; y < midY + 6; y++)
                    {
                        Game.Grid[y][midX - 4].SetBackgroundFeature(Game.GrassTile);
                        Game.Grid[y][midX - 4].SetFeature(Game.GrassTile);
                    }
                    for (int y = midY - 7; y < midY + 6; y++)
                    {
                        Game.Grid[y][midX - 3].SetBackgroundFeature(Game.GrassTile);
                        Game.Grid[y][midX - 3].SetFeature(Game.GrassTile);
                    }
                    for (int y = midY - 7; y < midY + 6; y++)
                    {
                        Game.Grid[y][midX - 2].SetBackgroundFeature(Game.GrassTile);
                        Game.Grid[y][midX - 2].SetFeature(Game.GrassTile);
                    }
                    for (int y = midY - 6; y < midY + 6; y++)
                    {
                        Game.Grid[y][midX - 1].SetBackgroundFeature(Game.GrassTile);
                        Game.Grid[y][midX - 1].SetFeature(Game.GrassTile);
                    }
                    for (int y = midY - 7; y < midY + 6; y++)
                    {
                        Game.Grid[y][midX].SetBackgroundFeature(Game.GrassTile);
                        Game.Grid[y][midX].SetFeature(Game.GrassTile);
                    }
                    for (int y = midY - 7; y < midY + 6; y++)
                    {
                        Game.Grid[y][midX + 1].SetBackgroundFeature(Game.GrassTile);
                        Game.Grid[y][midX + 1].SetFeature(Game.GrassTile);
                    }
                    for (int y = midY - 6; y < midY + 6; y++)
                    {
                        Game.Grid[y][midX + 2].SetBackgroundFeature(Game.GrassTile);
                        Game.Grid[y][midX + 2].SetFeature(Game.GrassTile);
                    }
                    for (int y = midY - 7; y < midY + 6; y++)
                    {
                        Game.Grid[y][midX + 3].SetBackgroundFeature(Game.GrassTile);
                        Game.Grid[y][midX + 3].SetFeature(Game.GrassTile);
                    }
                    for (int y = midY - 6; y < midY + 6; y++)
                    {
                        Game.Grid[y][midX + 4].SetBackgroundFeature(Game.GrassTile);
                        Game.Grid[y][midX + 4].SetFeature(Game.GrassTile);
                    }
                    for (int y = midY - 5; y < midY + 5; y++)
                    {
                        Game.Grid[y][midX + 5].SetBackgroundFeature(Game.GrassTile);
                        Game.Grid[y][midX + 5].SetFeature(Game.GrassTile);
                    }
                    for (int y = midY - 3; y < midY + 3; y++)
                    {
                        Game.Grid[y][midX + 6].SetBackgroundFeature(Game.GrassTile);
                        Game.Grid[y][midX + 6].SetFeature(Game.GrassTile);
                    }
                    Game.Grid[midY - 6][midX].SetFeature(Game.RockTile);
                    Game.Grid[midY - 6][midX - 1].SetFeature(Game.RockTile);
                    Game.Grid[midY - 5][midX - 4].SetFeature(Game.RockTile);
                    Game.Grid[midY - 4][midX - 5].SetFeature(Game.RockTile);
                    Game.Grid[midY - 1][midX - 6].SetFeature(Game.RockTile);
                    Game.Grid[midY][midX - 6].SetFeature(Game.RockTile);
                    Game.Grid[midY + 3][midX - 5].SetFeature(Game.RockTile);
                    Game.Grid[midY + 4][midX - 4].SetFeature(Game.RockTile);
                    Game.Grid[midY + 5][midX - 1].SetFeature(Game.RockTile);
                    Game.Grid[midY + 5][midX].SetFeature(Game.RockTile);
                    Game.Grid[midY + 4][midX + 3].SetFeature(Game.RockTile);
                    Game.Grid[midY + 3][midX + 4].SetFeature(Game.RockTile);
                    Game.Grid[midY][midX + 5].SetFeature(Game.RockTile);
                    Game.Grid[midY - 1][midX + 5].SetFeature(Game.RockTile);
                    Game.Grid[midY - 4][midX + 4].SetFeature(Game.RockTile);
                    Game.Grid[midY - 5][midX + 3].SetFeature(Game.RockTile);
                }
                void MakeLake(int minX, int minY, int width, int height)
                {
                    PerlinNoise perlinNoise = new PerlinNoise(random.RandomBetween(0, int.MaxValue - 1));
                    double widthDivisor = 1 / (double)width;
                    double heightDivisor = 1 / (double)height;
                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            GridTile cPtr = Game.Grid[minY + y][minX + x];
                            double v = perlinNoise.Noise(10 * x * widthDivisor, 10 * y * heightDivisor, -0.5);
                            v = (v + 1) / 2;
                            double dX = Math.Abs(x - (width / 2)) * widthDivisor;
                            double dY = Math.Abs(y - (height / 2)) * heightDivisor;
                            double d = Math.Max(dX, dY);
                            const double elevation = 0.05;
                            const double steepness = 6.0;
                            const double dropoff = 50.0;
                            v += elevation - (dropoff * Math.Pow(d, steepness));
                            v = Math.Min(1, Math.Max(0, v));
                            int rounded = (int)(v * 10);
                            if (rounded > 3)
                            {
                                cPtr.SetBackgroundFeature(Game.WaterTile);
                                cPtr.SetFeature(Game.WaterTile);
                            }
                            else if (rounded == 3)
                            {
                                cPtr.SetBackgroundFeature(Game.GrassTile);
                                cPtr.SetFeature(Game.GrassTile);
                            }
                        }
                    }
                }
                void MakeTower(int left, int top, int width, int height, out int stairX, out int stairY)
                {
                    int i;
                    int y = top + height;
                    int x = left + (width / 2);
                    stairX = x;
                    stairY = y;
                    for (i = -2; i < 3; i++)
                    {
                        Game.Grid[y][x + i].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(WallPermanentBuildingTile)));
                        Game.Grid[y][x + i].PlayerMemorized = true;
                        Game.Grid[y][x + i].SelfLit = true;
                    }
                    for (i = -4; i < 5; i++)
                    {
                        Game.Grid[y - 1][x + i].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(WallPermanentBuildingTile)));
                        Game.Grid[y - 1][x + i].PlayerMemorized = true;
                        Game.Grid[y - 1][x + i].SelfLit = true;
                    }
                    for (i = -5; i < 6; i++)
                    {
                        Game.Grid[y - 2][x + i].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(WallPermanentBuildingTile)));
                        Game.Grid[y - 2][x + i].PlayerMemorized = true;
                        Game.Grid[y - 2][x + i].SelfLit = true;
                    }
                    for (i = -6; i < 7; i++)
                    {
                        Game.Grid[y - 3][x + i].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(WallPermanentBuildingTile)));
                        Game.Grid[y - 3][x + i].PlayerMemorized = true;
                        Game.Grid[y - 3][x + i].SelfLit = true;
                    }
                    for (i = -6; i < 7; i++)
                    {
                        Game.Grid[y - 4][x + i].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(WallPermanentBuildingTile)));
                        Game.Grid[y - 4][x + i].PlayerMemorized = true;
                        Game.Grid[y - 4][x + i].SelfLit = true;
                    }
                    for (i = -7; i < 8; i++)
                    {
                        Game.Grid[y - 5][x + i].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(WallPermanentBuildingTile)));
                        Game.Grid[y - 5][x + i].PlayerMemorized = true;
                        Game.Grid[y - 5][x + i].SelfLit = true;
                    }
                    for (i = -7; i < 8; i++)
                    {
                        Game.Grid[y - 6][x + i].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(WallPermanentBuildingTile)));
                        Game.Grid[y - 6][x + i].PlayerMemorized = true;
                        Game.Grid[y - 6][x + i].SelfLit = true;
                    }
                    for (i = -7; i < 8; i++)
                    {
                        Game.Grid[y - 7][x + i].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(WallPermanentBuildingTile)));
                        Game.Grid[y - 7][x + i].PlayerMemorized = true;
                        Game.Grid[y - 7][x + i].SelfLit = true;
                    }
                    for (i = -7; i < 8; i++)
                    {
                        Game.Grid[y - 8][x + i].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(WallPermanentBuildingTile)));
                        Game.Grid[y - 8][x + i].PlayerMemorized = true;
                        Game.Grid[y - 8][x + i].SelfLit = true;
                    }
                    for (i = -7; i < 8; i++)
                    {
                        Game.Grid[y - 9][x + i].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(WallPermanentBuildingTile)));
                        Game.Grid[y - 9][x + i].PlayerMemorized = true;
                        Game.Grid[y - 9][x + i].SelfLit = true;
                    }
                    for (i = -6; i < 7; i++)
                    {
                        Game.Grid[y - 10][x + i].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(WallPermanentBuildingTile)));
                        Game.Grid[y - 10][x + i].PlayerMemorized = true;
                        Game.Grid[y - 10][x + i].SelfLit = true;
                    }
                    for (i = -6; i < 7; i++)
                    {
                        Game.Grid[y - 11][x + i].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(WallPermanentBuildingTile)));
                        Game.Grid[y - 11][x + i].PlayerMemorized = true;
                        Game.Grid[y - 11][x + i].SelfLit = true;
                    }
                    for (i = -5; i < 6; i++)
                    {
                        Game.Grid[y - 12][x + i].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(WallPermanentBuildingTile)));
                        Game.Grid[y - 12][x + i].PlayerMemorized = true;
                        Game.Grid[y - 12][x + i].SelfLit = true;
                    }
                    for (i = -4; i < 5; i++)
                    {
                        Game.Grid[y - 13][x + i].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(WallPermanentBuildingTile)));
                        Game.Grid[y - 13][x + i].PlayerMemorized = true;
                        Game.Grid[y - 13][x + i].SelfLit = true;
                    }
                    for (i = -2; i < 4; i++)
                    {
                        Game.Grid[y - 14][x + i].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(WallPermanentBuildingTile)));
                        Game.Grid[y - 14][x + i].PlayerMemorized = true;
                        Game.Grid[y - 14][x + i].SelfLit = true;
                    }
                    Game.Grid[y][x].SetFeature(Game.UpStaircaseTile);
                    Game.Grid[y][x].PlayerMemorized = true;
                    Game.Grid[y][x].SelfLit = true;
                    for (i = -3; i < 4; i++)
                    {
                        if (Game.Grid[y + 1][x + i].FeatureType.IsTree)
                        {
                            Game.Grid[y + 1][x + i].RevertToBackground();
                        }
                    }
                    for (i = -2; i < 3; i++)
                    {
                        if (Game.Grid[y + 2][x + i].FeatureType.IsTree)
                        {
                            Game.Grid[y + 2][x + i].RevertToBackground();
                        }
                    }
                }

                stairX = Game.CurWid / 2;
                stairY = Game.CurHgt / 2;
                if (wildx == 1 || wildx == 10 || wildy == 1 || wildy == 10)
                {
                    return;
                }
                int dungeonX = 0;
                int dungeonY = 0;
                switch (random.DieRoll(4))
                {
                    case 1:
                        dungeonX = 0;
                        dungeonY = 0;
                        break;

                    case 2:
                        dungeonX = Game.CurWid / 2;
                        dungeonY = 0;
                        break;

                    case 3:
                        dungeonX = 0;
                        dungeonY = Game.CurHgt / 2;
                        break;

                    case 4:
                        dungeonX = Game.CurWid / 2;
                        dungeonY = Game.CurHgt / 2;
                        break;
                }
                for (int offsetX = 0; offsetX < Game.CurWid - 1; offsetX += Game.CurWid / 2)
                {
                    for (int offsetY = 0; offsetY < Game.CurHgt - 1; offsetY += Game.CurHgt / 2)
                    {
                        if (offsetX == dungeonX && offsetY == dungeonY)
                        {
                            if (Game.Wilderness[wildy][wildx].Dungeon != null)
                            {
                                if (Game.Wilderness[wildy][wildx].Dungeon.Tower)
                                {
                                    MakeTower(offsetX + 4, offsetY + 4, (Game.CurWid / 2) - 8, (Game.CurHgt / 2) - 8, out int x, out int y);
                                    stairX = x;
                                    stairY = y;
                                }
                                else
                                {
                                    MakeDungeonEntrance(random, offsetX + 4, offsetY + 4, (Game.CurWid / 2) - 8, (Game.CurHgt / 2) - 8, out int x, out int y);
                                    stairX = x;
                                    stairY = y;
                                }
                            }
                        }
                        else
                        {
                            switch (random.DieRoll(30))
                            {
                                case 7:
                                case 22:
                                    MakeLake(offsetX + 4, offsetY + 4, (Game.CurWid / 2) - 8, (Game.CurHgt / 2) - 8);
                                    break;

                                case 15:
                                    MakeHenge(offsetX + 4, offsetY + 4, (Game.CurWid / 2) - 8, (Game.CurHgt / 2) - 8);
                                    break;
                            }
                        }
                    }
                }
            }
            void MakeWildernessPaths(GameRandom random, int wildx, int wildy)
            {
                int x;
                int y;

                int midX = Game.CurWid / 2;
                int midY = Game.CurHgt / 2;
                if (Game.Wilderness[wildy][wildx].RoadMap == 0)
                {
                    return;
                }
                Game.Grid[midY - 1][midX - 1].SetFeature(Game.GrassTile);
                Game.Grid[midY - 1][midX].SetFeature(Game.GrassTile);
                Game.Grid[midY - 1][midX + 1].SetFeature(Game.GrassTile);
                Game.Grid[midY][midX - 1].SetFeature(Game.GrassTile);
                Game.Grid[midY][midX].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(PathBaseTile)));
                Game.Grid[midY][midX + 1].SetFeature(Game.GrassTile);
                Game.Grid[midY + 1][midX - 1].SetFeature(Game.GrassTile);
                Game.Grid[midY + 1][midX].SetFeature(Game.GrassTile);
                Game.Grid[midY + 1][midX + 1].SetFeature(Game.GrassTile);
                if ((Game.Wilderness[wildy][wildx].RoadMap & Constants.RoadUp) != 0)
                {
                    x = 0;
                    Game.Grid[0][midX].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(PathBorderNSTile)));
                    Game.Grid[1][midX].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(PathBaseTile)));
                    Game.Grid[midY - 1][midX].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(PathBaseTile)));
                    for (y = 2; y < midY - 1; y++)
                    {
                        x += random.RandomBetween(-2, 2) / 2;
                        if (x > midY - 1 - y)
                        {
                            x = midY - 1 - y;
                        }
                        if (x < -(midY - 1 - y))
                        {
                            x = -(midY - 1 - y);
                        }
                        if (!Game.Grid[y][midX - 1 + x].FeatureType.IsWildPath)
                        {
                            Game.Grid[y][midX - 1 + x].SetFeature(Game.GrassTile);
                        }
                        Game.Grid[y][midX + x].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(WildPathNSTile)));
                        if (!Game.Grid[y][midX + 1 + x].FeatureType.IsWildPath)
                        {
                            Game.Grid[y][midX + 1 + x].SetFeature(Game.GrassTile);
                        }
                    }
                }
                if ((Game.Wilderness[wildy][wildx].RoadMap & Constants.RoadDown) != 0)
                {
                    x = 0;
                    Game.Grid[Game.CurHgt - 1][midX].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(PathBorderNSTile)));
                    Game.Grid[Game.CurHgt - 2][midX].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(PathBaseTile)));
                    Game.Grid[midY + 1][midX].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(PathBaseTile)));
                    for (y = Game.CurHgt - 3; y > midY + 1; y--)
                    {
                        x += random.RandomBetween(-2, 2) / 2;
                        if (x > y - (midY + 1))
                        {
                            x = y - (midY + 1);
                        }
                        if (x < -(y - (midY + 1)))
                        {
                            x = -(y - (midY + 1));
                        }
                        if (!Game.Grid[y][midX - 1 + x].FeatureType.IsWildPath)
                        {
                            Game.Grid[y][midX - 1 + x].SetFeature(Game.GrassTile);
                        }
                        Game.Grid[y][midX + x].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(WildPathNSTile)));
                        if (!Game.Grid[y][midX + 1 + x].FeatureType.IsWildPath)
                        {
                            Game.Grid[y][midX + 1 + x].SetFeature(Game.GrassTile);
                        }
                    }
                }
                if ((Game.Wilderness[wildy][wildx].RoadMap & Constants.RoadLeft) != 0)
                {
                    y = 0;
                    Game.Grid[midY][0].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(PathBorderEWTile)));
                    Game.Grid[midY][1].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(PathBaseTile)));
                    Game.Grid[midY][midX - 1].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(PathBaseTile)));
                    for (x = 2; x < midX - 1; x++)
                    {
                        y += random.RandomBetween(-2, 2) / 2;
                        if (y > midX - 1 - x)
                        {
                            y = midX - 1 - x;
                        }
                        if (y < -(midX - 1 - x))
                        {
                            y = -(midX - 1 - x);
                        }
                        if (!Game.Grid[midY - 1 + y][x].FeatureType.IsWildPath)
                        {
                            Game.Grid[midY - 1 + y][x].SetFeature(Game.GrassTile);
                        }
                        Game.Grid[midY + y][x].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(WildPathEWTile)));
                        if (!Game.Grid[midY + 1 + y][x].FeatureType.IsWildPath)
                        {
                            Game.Grid[midY + 1 + y][x].SetFeature(Game.GrassTile);
                        }
                    }
                }
                if ((Game.Wilderness[wildy][wildx].RoadMap & Constants.RoadRight) != 0)
                {
                    y = 0;
                    Game.Grid[midY][Game.CurWid - 1].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(PathBorderEWTile)));
                    Game.Grid[midY][Game.CurWid - 2].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(PathBaseTile)));
                    Game.Grid[midY][midX + 1].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(PathBaseTile)));
                    for (x = Game.CurWid - 3; x > midX + 1; x--)
                    {
                        y += random.RandomBetween(-2, 2) / 2;
                        if (y > x - (midX + 1))
                        {
                            y = x - (midX + 1);
                        }
                        if (y < -(x - (midX + 1)))
                        {
                            y = -(x - (midX + 1));
                        }
                        if (!Game.Grid[midY - 1 + y][x].FeatureType.IsWildPath)
                        {
                            Game.Grid[midY - 1 + y][x].SetFeature(Game.GrassTile);
                        }
                        Game.Grid[midY + y][x].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(WildPathEWTile)));
                        if (!Game.Grid[midY + 1 + y][x].FeatureType.IsWildPath)
                        {
                            Game.Grid[midY + 1 + y][x].SetFeature(Game.GrassTile);
                        }
                    }
                }
            }
            void MakeWildernessWalls(int wildX, int wildY)
            {
                int height = Game.CurHgt;
                int width = Game.CurWid;
                if (Game.Wilderness[wildY - 1][wildX].Town != null)
                {
                    for (int x = 0; x < width; x++)
                    {
                        Game.Grid[0][x].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                        Game.Grid[0][x].PlayerMemorized = true;
                        Game.Grid[0][x].SelfLit = true;
                    }
                    Game.Grid[0][(width / 2) - 2].SetBackgroundFeature(Game.SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
                    Game.Grid[0][(width / 2) - 2].PlayerMemorized = true;
                    Game.Grid[0][(width / 2) - 2].SelfLit = true;
                    Game.Grid[0][(width / 2) - 1].SetBackgroundFeature(Game.SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
                    Game.Grid[0][(width / 2) - 1].PlayerMemorized = true;
                    Game.Grid[0][(width / 2) - 1].SelfLit = true;
                    Game.Grid[0][(width / 2) + 1].SetBackgroundFeature(Game.SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
                    Game.Grid[0][(width / 2) + 1].PlayerMemorized = true;
                    Game.Grid[0][(width / 2) + 1].SelfLit = true;
                    Game.Grid[0][(width / 2) + 2].SetBackgroundFeature(Game.SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
                    Game.Grid[0][(width / 2) + 2].PlayerMemorized = true;
                    Game.Grid[0][(width / 2) + 2].SelfLit = true;
                    Game.Grid[1][(width / 2) - 2].SetBackgroundFeature(Game.SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
                    Game.Grid[1][(width / 2) - 2].PlayerMemorized = true;
                    Game.Grid[1][(width / 2) - 2].SelfLit = true;
                    Game.Grid[1][(width / 2) - 1].SetBackgroundFeature(Game.SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
                    Game.Grid[1][(width / 2) - 1].PlayerMemorized = true;
                    Game.Grid[1][(width / 2) - 1].SelfLit = true;
                    Game.Grid[1][(width / 2) + 1].SetBackgroundFeature(Game.SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
                    Game.Grid[1][(width / 2) + 1].PlayerMemorized = true;
                    Game.Grid[1][(width / 2) + 1].SelfLit = true;
                    Game.Grid[1][(width / 2) + 2].SetBackgroundFeature(Game.SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
                    Game.Grid[1][(width / 2) + 2].PlayerMemorized = true;
                    Game.Grid[1][(width / 2) + 2].SelfLit = true;
                    Game.Grid[0][(width / 2) - 2].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                    Game.Grid[0][(width / 2) - 2].PlayerMemorized = true;
                    Game.Grid[0][(width / 2) - 2].SelfLit = true;
                    Game.Grid[0][(width / 2) - 1].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                    Game.Grid[0][(width / 2) - 1].PlayerMemorized = true;
                    Game.Grid[0][(width / 2) - 1].SelfLit = true;
                    Game.Grid[0][width / 2].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(PathBorderNSTile)));
                    Game.Grid[0][width / 2].PlayerMemorized = true;
                    Game.Grid[0][width / 2].SelfLit = true;
                    Game.Grid[0][(width / 2) + 1].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                    Game.Grid[0][(width / 2) + 1].PlayerMemorized = true;
                    Game.Grid[0][(width / 2) + 1].SelfLit = true;
                    Game.Grid[0][(width / 2) + 2].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                    Game.Grid[0][(width / 2) + 2].PlayerMemorized = true;
                    Game.Grid[0][(width / 2) + 2].SelfLit = true;
                    Game.Grid[1][(width / 2) - 2].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                    Game.Grid[1][(width / 2) - 2].PlayerMemorized = true;
                    Game.Grid[1][(width / 2) - 2].SelfLit = true;
                    Game.Grid[1][(width / 2) - 1].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                    Game.Grid[1][(width / 2) - 1].PlayerMemorized = true;
                    Game.Grid[1][(width / 2) - 1].SelfLit = true;
                    Game.Grid[1][width / 2].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(PathBaseTile)));
                    Game.Grid[1][width / 2].PlayerMemorized = true;
                    Game.Grid[1][width / 2].SelfLit = true;
                    Game.Grid[1][(width / 2) + 1].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                    Game.Grid[1][(width / 2) + 1].PlayerMemorized = true;
                    Game.Grid[1][(width / 2) + 1].SelfLit = true;
                    Game.Grid[1][(width / 2) + 2].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                    Game.Grid[1][(width / 2) + 2].PlayerMemorized = true;
                    Game.Grid[1][(width / 2) + 2].SelfLit = true;
                }
                if (Game.Wilderness[wildY + 1][wildX].Town != null)
                {
                    for (int x = 0; x < width; x++)
                    {
                        Game.Grid[height - 1][x].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                        Game.Grid[height - 1][x].PlayerMemorized = true;
                        Game.Grid[height - 1][x].SelfLit = true;
                    }
                    Game.Grid[height - 1][(width / 2) - 2].SetBackgroundFeature(Game.SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
                    Game.Grid[height - 1][(width / 2) - 2].PlayerMemorized = true;
                    Game.Grid[height - 1][(width / 2) - 2].SelfLit = true;
                    Game.Grid[height - 1][(width / 2) - 1].SetBackgroundFeature(Game.SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
                    Game.Grid[height - 1][(width / 2) - 1].PlayerMemorized = true;
                    Game.Grid[height - 1][(width / 2) - 1].SelfLit = true;
                    Game.Grid[height - 1][(width / 2) + 1].SetBackgroundFeature(Game.SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
                    Game.Grid[height - 1][(width / 2) + 1].PlayerMemorized = true;
                    Game.Grid[height - 1][(width / 2) + 1].SelfLit = true;
                    Game.Grid[height - 1][(width / 2) + 2].SetBackgroundFeature(Game.SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
                    Game.Grid[height - 1][(width / 2) + 2].PlayerMemorized = true;
                    Game.Grid[height - 1][(width / 2) + 2].SelfLit = true;
                    Game.Grid[height - 2][(width / 2) - 2].SetBackgroundFeature(Game.SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
                    Game.Grid[height - 2][(width / 2) - 2].PlayerMemorized = true;
                    Game.Grid[height - 2][(width / 2) - 2].SelfLit = true;
                    Game.Grid[height - 2][(width / 2) - 1].SetBackgroundFeature(Game.SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
                    Game.Grid[height - 2][(width / 2) - 1].PlayerMemorized = true;
                    Game.Grid[height - 2][(width / 2) - 1].SelfLit = true;
                    Game.Grid[height - 2][(width / 2) + 1].SetBackgroundFeature(Game.SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
                    Game.Grid[height - 2][(width / 2) + 1].PlayerMemorized = true;
                    Game.Grid[height - 2][(width / 2) + 1].SelfLit = true;
                    Game.Grid[height - 2][(width / 2) + 2].SetBackgroundFeature(Game.SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
                    Game.Grid[height - 2][(width / 2) + 2].PlayerMemorized = true;
                    Game.Grid[height - 2][(width / 2) + 2].SelfLit = true;
                    Game.Grid[height - 1][(width / 2) - 2].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                    Game.Grid[height - 1][(width / 2) - 2].PlayerMemorized = true;
                    Game.Grid[height - 1][(width / 2) - 2].SelfLit = true;
                    Game.Grid[height - 1][(width / 2) - 1].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                    Game.Grid[height - 1][(width / 2) - 1].PlayerMemorized = true;
                    Game.Grid[height - 1][(width / 2) - 1].SelfLit = true;
                    Game.Grid[height - 1][width / 2].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(PathBorderNSTile)));
                    Game.Grid[height - 1][width / 2].PlayerMemorized = true;
                    Game.Grid[height - 1][width / 2].SelfLit = true;
                    Game.Grid[height - 1][(width / 2) + 1].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                    Game.Grid[height - 1][(width / 2) + 1].PlayerMemorized = true;
                    Game.Grid[height - 1][(width / 2) + 1].SelfLit = true;
                    Game.Grid[height - 1][(width / 2) + 2].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                    Game.Grid[height - 1][(width / 2) + 2].PlayerMemorized = true;
                    Game.Grid[height - 1][(width / 2) + 2].SelfLit = true;
                    Game.Grid[height - 2][(width / 2) - 2].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                    Game.Grid[height - 2][(width / 2) - 2].PlayerMemorized = true;
                    Game.Grid[height - 2][(width / 2) - 2].SelfLit = true;
                    Game.Grid[height - 2][(width / 2) - 1].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                    Game.Grid[height - 2][(width / 2) - 1].PlayerMemorized = true;
                    Game.Grid[height - 2][(width / 2) - 1].SelfLit = true;
                    Game.Grid[height - 2][width / 2].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(PathBaseTile)));
                    Game.Grid[height - 2][width / 2].PlayerMemorized = true;
                    Game.Grid[height - 2][width / 2].SelfLit = true;
                    Game.Grid[height - 2][(width / 2) + 1].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                    Game.Grid[height - 2][(width / 2) + 1].PlayerMemorized = true;
                    Game.Grid[height - 2][(width / 2) + 1].SelfLit = true;
                    Game.Grid[height - 2][(width / 2) + 2].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                    Game.Grid[height - 2][(width / 2) + 2].PlayerMemorized = true;
                    Game.Grid[height - 2][(width / 2) + 2].SelfLit = true;
                }
                if (Game.Wilderness[wildY][wildX - 1].Town != null)
                {
                    for (int y = 0; y < height; y++)
                    {
                        Game.Grid[y][0].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                        Game.Grid[y][0].PlayerMemorized = true;
                        Game.Grid[y][0].SelfLit = true;
                    }
                    Game.Grid[(height / 2) - 2][0].SetBackgroundFeature(Game.SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
                    Game.Grid[(height / 2) - 2][0].PlayerMemorized = true;
                    Game.Grid[(height / 2) - 2][0].SelfLit = true;
                    Game.Grid[(height / 2) - 1][0].SetBackgroundFeature(Game.SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
                    Game.Grid[(height / 2) - 1][0].PlayerMemorized = true;
                    Game.Grid[(height / 2) - 1][0].SelfLit = true;
                    Game.Grid[(height / 2) + 1][0].SetBackgroundFeature(Game.SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
                    Game.Grid[(height / 2) + 1][0].PlayerMemorized = true;
                    Game.Grid[(height / 2) + 1][0].SelfLit = true;
                    Game.Grid[(height / 2) + 2][0].SetBackgroundFeature(Game.SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
                    Game.Grid[(height / 2) + 2][0].PlayerMemorized = true;
                    Game.Grid[(height / 2) + 2][0].SelfLit = true;
                    Game.Grid[(height / 2) - 2][1].SetBackgroundFeature(Game.SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
                    Game.Grid[(height / 2) - 2][1].PlayerMemorized = true;
                    Game.Grid[(height / 2) - 2][1].SelfLit = true;
                    Game.Grid[(height / 2) - 1][1].SetBackgroundFeature(Game.SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
                    Game.Grid[(height / 2) - 1][1].PlayerMemorized = true;
                    Game.Grid[(height / 2) - 1][1].SelfLit = true;
                    Game.Grid[(height / 2) + 1][1].SetBackgroundFeature(Game.SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
                    Game.Grid[(height / 2) + 1][1].PlayerMemorized = true;
                    Game.Grid[(height / 2) + 1][1].SelfLit = true;
                    Game.Grid[(height / 2) + 2][1].SetBackgroundFeature(Game.SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
                    Game.Grid[(height / 2) + 2][1].PlayerMemorized = true;
                    Game.Grid[(height / 2) + 2][1].SelfLit = true;
                    Game.Grid[(height / 2) - 2][0].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                    Game.Grid[(height / 2) - 2][0].PlayerMemorized = true;
                    Game.Grid[(height / 2) - 2][0].SelfLit = true;
                    Game.Grid[(height / 2) - 1][0].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                    Game.Grid[(height / 2) - 1][0].PlayerMemorized = true;
                    Game.Grid[(height / 2) - 1][0].SelfLit = true;
                    Game.Grid[height / 2][0].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(PathBorderEWTile)));
                    Game.Grid[height / 2][0].PlayerMemorized = true;
                    Game.Grid[height / 2][0].SelfLit = true;
                    Game.Grid[(height / 2) + 1][0].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                    Game.Grid[(height / 2) + 1][0].PlayerMemorized = true;
                    Game.Grid[(height / 2) + 1][0].SelfLit = true;
                    Game.Grid[(height / 2) + 2][0].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                    Game.Grid[(height / 2) + 2][0].PlayerMemorized = true;
                    Game.Grid[(height / 2) + 2][0].SelfLit = true;
                    Game.Grid[(height / 2) - 2][1].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                    Game.Grid[(height / 2) - 2][1].PlayerMemorized = true;
                    Game.Grid[(height / 2) - 2][1].SelfLit = true;
                    Game.Grid[(height / 2) - 1][1].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                    Game.Grid[(height / 2) - 1][1].PlayerMemorized = true;
                    Game.Grid[(height / 2) - 1][1].SelfLit = true;
                    Game.Grid[height / 2][1].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(PathBaseTile)));
                    Game.Grid[height / 2][1].PlayerMemorized = true;
                    Game.Grid[height / 2][1].SelfLit = true;
                    Game.Grid[(height / 2) + 1][1].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                    Game.Grid[(height / 2) + 1][1].PlayerMemorized = true;
                    Game.Grid[(height / 2) + 1][1].SelfLit = true;
                    Game.Grid[(height / 2) + 2][1].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                    Game.Grid[(height / 2) + 2][1].PlayerMemorized = true;
                    Game.Grid[(height / 2) + 2][1].SelfLit = true;
                }
                if (Game.Wilderness[wildY][wildX + 1].Town != null)
                {
                    for (int y = 0; y < height; y++)
                    {
                        Game.Grid[y][width - 1].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                        Game.Grid[y][width - 1].PlayerMemorized = true;
                        Game.Grid[y][width - 1].SelfLit = true;
                    }
                    Game.Grid[(height / 2) - 2][width - 1].SetBackgroundFeature(Game.SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
                    Game.Grid[(height / 2) - 2][width - 1].PlayerMemorized = true;
                    Game.Grid[(height / 2) - 2][width - 1].SelfLit = true;
                    Game.Grid[(height / 2) - 1][width - 1].SetBackgroundFeature(Game.SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
                    Game.Grid[(height / 2) - 1][width - 1].PlayerMemorized = true;
                    Game.Grid[(height / 2) - 1][width - 1].SelfLit = true;
                    Game.Grid[(height / 2) + 1][width - 1].SetBackgroundFeature(Game.SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
                    Game.Grid[(height / 2) + 1][width - 1].PlayerMemorized = true;
                    Game.Grid[(height / 2) + 1][width - 1].SelfLit = true;
                    Game.Grid[(height / 2) + 2][width - 1].SetBackgroundFeature(Game.SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
                    Game.Grid[(height / 2) + 2][width - 1].PlayerMemorized = true;
                    Game.Grid[(height / 2) + 2][width - 1].SelfLit = true;
                    Game.Grid[(height / 2) - 2][width - 2].SetBackgroundFeature(Game.SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
                    Game.Grid[(height / 2) - 2][width - 2].PlayerMemorized = true;
                    Game.Grid[(height / 2) - 2][width - 2].SelfLit = true;
                    Game.Grid[(height / 2) - 1][width - 2].SetBackgroundFeature(Game.SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
                    Game.Grid[(height / 2) - 1][width - 2].PlayerMemorized = true;
                    Game.Grid[(height / 2) - 1][width - 2].SelfLit = true;
                    Game.Grid[(height / 2) + 1][width - 2].SetBackgroundFeature(Game.SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
                    Game.Grid[(height / 2) + 1][width - 2].PlayerMemorized = true;
                    Game.Grid[(height / 2) + 1][width - 2].SelfLit = true;
                    Game.Grid[(height / 2) + 2][width - 2].SetBackgroundFeature(Game.SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
                    Game.Grid[(height / 2) + 2][width - 2].PlayerMemorized = true;
                    Game.Grid[(height / 2) + 2][width - 2].SelfLit = true;
                    Game.Grid[(height / 2) - 2][width - 1].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                    Game.Grid[(height / 2) - 2][width - 1].PlayerMemorized = true;
                    Game.Grid[(height / 2) - 2][width - 1].SelfLit = true;
                    Game.Grid[(height / 2) - 1][width - 1].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                    Game.Grid[(height / 2) - 1][width - 1].PlayerMemorized = true;
                    Game.Grid[(height / 2) - 1][width - 1].SelfLit = true;
                    Game.Grid[height / 2][width - 1].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(PathBorderEWTile)));
                    Game.Grid[height / 2][width - 1].PlayerMemorized = true;
                    Game.Grid[height / 2][width - 1].SelfLit = true;
                    Game.Grid[(height / 2) + 1][width - 1].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                    Game.Grid[(height / 2) + 1][width - 1].PlayerMemorized = true;
                    Game.Grid[(height / 2) + 1][width - 1].SelfLit = true;
                    Game.Grid[(height / 2) + 2][width - 1].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                    Game.Grid[(height / 2) + 2][width - 1].PlayerMemorized = true;
                    Game.Grid[(height / 2) + 2][width - 1].SelfLit = true;
                    Game.Grid[(height / 2) - 2][width - 2].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                    Game.Grid[(height / 2) - 2][width - 2].PlayerMemorized = true;
                    Game.Grid[(height / 2) - 2][width - 2].SelfLit = true;
                    Game.Grid[(height / 2) - 1][width - 2].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                    Game.Grid[(height / 2) - 1][width - 2].PlayerMemorized = true;
                    Game.Grid[(height / 2) - 1][width - 2].SelfLit = true;
                    Game.Grid[height / 2][width - 2].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(PathBaseTile)));
                    Game.Grid[height / 2][width - 2].PlayerMemorized = true;
                    Game.Grid[height / 2][width - 2].SelfLit = true;
                    Game.Grid[(height / 2) + 1][width - 2].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                    Game.Grid[(height / 2) + 1][width - 2].PlayerMemorized = true;
                    Game.Grid[(height / 2) + 1][width - 2].SelfLit = true;
                    Game.Grid[(height / 2) + 2][width - 2].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                    Game.Grid[(height / 2) + 2][width - 2].PlayerMemorized = true;
                    Game.Grid[(height / 2) + 2][width - 2].SelfLit = true;
                }
            }

            GameRandom random = new GameRandom(Game.Wilderness[Game.WildernessY][Game.WildernessX].Seed);
            int x;
            int y;
            for (y = 0; y < Game.CurHgt; y++)
            {
                for (x = 0; x < Game.CurWid; x++)
                {
                    byte elevation = Game.Elevation(Game.WildernessY, Game.WildernessX, y, x);
                    Tile floorTile = Game.WaterTile;
                    Tile featureTile = Game.WaterTile;
                    if (elevation > 0)
                    {
                        floorTile = Game.GrassTile;
                        if (random.DieRoll(10) < elevation)
                        {
                            if (random.DieRoll(10) < elevation)
                            {
                                featureTile = Game.SingletonRepository.Get<Tile>(nameof(TreeTile));
                            }
                            else
                            {
                                featureTile = Game.SingletonRepository.Get<Tile>(nameof(BushTile));
                            }
                        }
                        else
                        {
                            featureTile = Game.GrassTile;
                        }
                    }
                    Game.Grid[y][x].SetFeature(featureTile);
                    Game.Grid[y][x].SetBackgroundFeature(floorTile);
                }
            }
            for (x = 0; x < Game.CurWid; x++)
            {
                GridTile cPtr = Game.Grid[0][x];
                cPtr.SetFeature(cPtr.BackgroundFeature.HasWater ? Game.SingletonRepository.Get<Tile>(nameof(WaterBorderTile)) : Game.SingletonRepository.Get<Tile>(nameof(WildBorderTile)));
                cPtr = Game.Grid[Game.CurHgt - 1][x];
                cPtr.SetFeature(cPtr.BackgroundFeature.HasWater ? Game.SingletonRepository.Get<Tile>(nameof(WaterBorderTile)) : Game.SingletonRepository.Get<Tile>(nameof(WildBorderTile)));
            }
            for (y = 0; y < Game.CurHgt; y++)
            {
                GridTile cPtr = Game.Grid[y][0];
                cPtr.SetFeature(cPtr.BackgroundFeature.HasWater ? Game.SingletonRepository.Get<Tile>(nameof(WaterBorderTile)) : Game.SingletonRepository.Get<Tile>(nameof(WildBorderTile)));
                cPtr = Game.Grid[y][Game.CurWid - 1];
                cPtr.SetFeature(cPtr.BackgroundFeature.HasWater ? Game.SingletonRepository.Get<Tile>(nameof(WaterBorderTile)) : Game.SingletonRepository.Get<Tile>(nameof(WildBorderTile)));
            }
            MakeWildernessWalls(Game.WildernessX, Game.WildernessY);
            MakeCornerTowers(Game.WildernessX, Game.WildernessY);
            MakeWildernessPaths(random, Game.WildernessX, Game.WildernessY);
            MakeWildernessFeatures(random, Game.WildernessX, Game.WildernessY, out int stairX, out int stairY);
            int rocks = random.RandomBetween(1, 10);
            for (int i = 0; i < rocks; i++)
            {
                x = random.DieRoll(Game.CurWid - 2);
                y = random.DieRoll(Game.CurHgt - 2);
                if (!Game.Grid[y][x].FeatureType.IsGrass)
                {
                    continue;
                }
                Game.Grid[y][x].SetFeature(Game.RockTile);
            }
            if (Game.CameFrom == LevelStartEnum.StartRandom)
            {
                NewPlayerSpot(Game._mainSequence);
            }
            else if (Game.CameFrom == LevelStartEnum.StartStairs)
            {
                Game.MapY.IntValue = stairY;
                Game.MapX.IntValue = stairX;
            }
            else if (Game.CameFrom == LevelStartEnum.StartWalk)
            {
                if (Game.Grid[Game.MapY.IntValue][Game.MapX.IntValue].FeatureType.IsTree || Game.Grid[Game.MapY.IntValue][Game.MapX.IntValue].FeatureType.IsWater)
                {
                    Game.Grid[Game.MapY.IntValue][Game.MapX.IntValue].RevertToBackground();
                }
            }
            Game.ResolvePaths();
            for (y = 1; y < Game.CurHgt - 1; y++)
            {
                for (x = 1; x < Game.CurWid - 1; x++)
                {
                    if (Game.Grid[y][x].FeatureType.IsOpenFloor)
                    {
                        Game.Grid[y][x].InRoom = true;
                    }
                }
            }
            if (Game.IsLight)
            {
                for (y = 0; y < Game.CurHgt; y++)
                {
                    for (x = 0; x < Game.CurWid; x++)
                    {
                        Game.Grid[y][x].SelfLit = true;
                        Game.Grid[y][x].PlayerMemorized = true;
                    }
                }
            }
            for (x = 0; x < Constants.MinMAllocLevel; x++)
            {
                Game.AllocMonster(3, true);
            }
            ///LEVEL FACTORY
        }
        void MakeCornerTowers(int wildX, int wildY)
        {
            int height = Game.CurHgt;
            int width = Game.CurWid;
            if ((Game.Wilderness[wildY][wildX].Town != null) || (Game.Wilderness[wildY - 1][wildX].Town != null) ||
                (Game.Wilderness[wildY][wildX - 1].Town != null) || (Game.Wilderness[wildY - 1][wildX - 1].Town != null))
            {
                Game.Grid[0][0].SetBackgroundFeature(Game.SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
                Game.Grid[0][0].PlayerMemorized = true;
                Game.Grid[0][0].SelfLit = true;
                Game.Grid[1][0].SetBackgroundFeature(Game.SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
                Game.Grid[1][0].PlayerMemorized = true;
                Game.Grid[1][0].SelfLit = true;
                Game.Grid[1][1].SetBackgroundFeature(Game.SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
                Game.Grid[1][1].PlayerMemorized = true;
                Game.Grid[1][1].SelfLit = true;
                Game.Grid[0][1].SetBackgroundFeature(Game.SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
                Game.Grid[0][1].PlayerMemorized = true;
                Game.Grid[0][1].SelfLit = true;
                Game.Grid[0][0].RevertToBackground();
                Game.Grid[0][0].PlayerMemorized = true;
                Game.Grid[0][0].SelfLit = true;
                Game.Grid[1][0].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                Game.Grid[1][0].PlayerMemorized = true;
                Game.Grid[1][0].SelfLit = true;
                Game.Grid[1][1].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                Game.Grid[1][1].PlayerMemorized = true;
                Game.Grid[1][1].SelfLit = true;
                Game.Grid[0][1].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                Game.Grid[0][1].PlayerMemorized = true;
                Game.Grid[0][1].SelfLit = true;
            }
            if ((Game.Wilderness[wildY][wildX].Town != null) || (Game.Wilderness[wildY - 1][wildX].Town != null) ||
                (Game.Wilderness[wildY][wildX + 1].Town != null) || (Game.Wilderness[wildY - 1][wildX + 1].Town != null))
            {
                Game.Grid[0][width - 1].SetBackgroundFeature(Game.SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
                Game.Grid[0][width - 1].PlayerMemorized = true;
                Game.Grid[0][width - 1].SelfLit = true;
                Game.Grid[1][width - 1].SetBackgroundFeature(Game.SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
                Game.Grid[1][width - 1].PlayerMemorized = true;
                Game.Grid[1][width - 1].SelfLit = true;
                Game.Grid[1][width - 2].SetBackgroundFeature(Game.SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
                Game.Grid[1][width - 2].PlayerMemorized = true;
                Game.Grid[1][width - 2].SelfLit = true;
                Game.Grid[0][width - 2].SetBackgroundFeature(Game.SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
                Game.Grid[0][width - 2].PlayerMemorized = true;
                Game.Grid[0][width - 2].SelfLit = true;
                Game.Grid[0][width - 1].RevertToBackground();
                Game.Grid[0][width - 1].PlayerMemorized = true;
                Game.Grid[0][width - 1].SelfLit = true;
                Game.Grid[1][width - 1].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                Game.Grid[1][width - 1].PlayerMemorized = true;
                Game.Grid[1][width - 1].SelfLit = true;
                Game.Grid[1][width - 2].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                Game.Grid[1][width - 2].PlayerMemorized = true;
                Game.Grid[1][width - 2].SelfLit = true;
                Game.Grid[0][width - 2].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                Game.Grid[0][width - 2].PlayerMemorized = true;
                Game.Grid[0][width - 2].SelfLit = true;
            }
            if ((Game.Wilderness[wildY][wildX].Town != null) || (Game.Wilderness[wildY + 1][wildX].Town != null) ||
                (Game.Wilderness[wildY][wildX + 1].Town != null) || (Game.Wilderness[wildY + 1][wildX + 1].Town != null))
            {
                Game.Grid[height - 1][width - 1].SetBackgroundFeature(Game.SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
                Game.Grid[height - 1][width - 1].PlayerMemorized = true;
                Game.Grid[height - 1][width - 1].SelfLit = true;
                Game.Grid[height - 2][width - 1].SetBackgroundFeature(Game.SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
                Game.Grid[height - 2][width - 1].PlayerMemorized = true;
                Game.Grid[height - 2][width - 1].SelfLit = true;
                Game.Grid[height - 2][width - 2].SetBackgroundFeature(Game.SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
                Game.Grid[height - 2][width - 2].PlayerMemorized = true;
                Game.Grid[height - 2][width - 2].SelfLit = true;
                Game.Grid[height - 1][width - 2].SetBackgroundFeature(Game.SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
                Game.Grid[height - 1][width - 2].PlayerMemorized = true;
                Game.Grid[height - 1][width - 2].SelfLit = true;
                Game.Grid[height - 1][width - 1].RevertToBackground();
                Game.Grid[height - 1][width - 1].PlayerMemorized = true;
                Game.Grid[height - 1][width - 1].SelfLit = true;
                Game.Grid[height - 2][width - 1].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                Game.Grid[height - 2][width - 1].PlayerMemorized = true;
                Game.Grid[height - 2][width - 1].SelfLit = true;
                Game.Grid[height - 2][width - 2].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                Game.Grid[height - 2][width - 2].PlayerMemorized = true;
                Game.Grid[height - 2][width - 2].SelfLit = true;
                Game.Grid[height - 1][width - 2].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                Game.Grid[height - 1][width - 2].PlayerMemorized = true;
                Game.Grid[height - 1][width - 2].SelfLit = true;
            }
            if ((Game.Wilderness[wildY][wildX].Town != null) || (Game.Wilderness[wildY + 1][wildX].Town != null) ||
                (Game.Wilderness[wildY][wildX - 1].Town != null) || (Game.Wilderness[wildY + 1][wildX - 1].Town != null))
            {
                Game.Grid[height - 1][0].SetBackgroundFeature(Game.SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
                Game.Grid[height - 1][0].PlayerMemorized = true;
                Game.Grid[height - 1][0].SelfLit = true;
                Game.Grid[height - 2][0].SetBackgroundFeature(Game.SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
                Game.Grid[height - 2][0].PlayerMemorized = true;
                Game.Grid[height - 2][0].SelfLit = true;
                Game.Grid[height - 2][1].SetBackgroundFeature(Game.SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
                Game.Grid[height - 2][1].PlayerMemorized = true;
                Game.Grid[height - 2][1].SelfLit = true;
                Game.Grid[height - 1][1].SetBackgroundFeature(Game.SingletonRepository.Get<Tile>(nameof(InsideGatehouseTile)));
                Game.Grid[height - 1][1].PlayerMemorized = true;
                Game.Grid[height - 1][1].SelfLit = true;
                Game.Grid[height - 1][0].RevertToBackground();
                Game.Grid[height - 1][0].PlayerMemorized = true;
                Game.Grid[height - 1][0].SelfLit = true;
                Game.Grid[height - 2][0].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                Game.Grid[height - 2][0].PlayerMemorized = true;
                Game.Grid[height - 2][0].SelfLit = true;
                Game.Grid[height - 2][1].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                Game.Grid[height - 2][1].PlayerMemorized = true;
                Game.Grid[height - 2][1].SelfLit = true;
                Game.Grid[height - 1][1].SetFeature(Game.SingletonRepository.Get<Tile>(nameof(TownWallTile)));
                Game.Grid[height - 1][1].PlayerMemorized = true;
                Game.Grid[height - 1][1].SelfLit = true;
            }
        }

        // Reset all of the monsters.
        Game.Monsters = new Monster[Constants.MaxMIdx];
        for (int j = 0; j < Constants.MaxMIdx; j++)
        {
            Game.Monsters[j] = new Monster(Game);
        }

        // Loop until we are able to build the level and keep track of the number of attempts.
        for (int generateAttemptNumber = 0; ; generateAttemptNumber++)
        {
            bool okay = true;

            // Allocate and reset the grid tiles.
            // Create a single traps detected property that can trigger any associated widgets.  This one property will be sent to all GridTile objects.
            TrapsDetectedProperty trapsDetectedProperty = (TrapsDetectedProperty)Game.SingletonRepository.Get<Property>(nameof(TrapsDetectedProperty)); // TODO: GridTileObjects can retrieve the object themselves upon initialization or at runtime.  No need to store as state data.
            Tile GrassTile = Game.GrassTile;
            Tile dungeonFloorTile = Game.SingletonRepository.Get<Tile>(nameof(DungeonFloorTile));
            Tile towerFloorTile = Game.SingletonRepository.Get<Tile>(nameof(TowerFloorTile));

            for (int y = 0; y < Game.MaxHgt; y++)
            {
                Game.Grid[y] = new GridTile[Game.MaxWid];
                for (int x = 0; x < Game.MaxWid; x++)
                {
                    GridTile newTile = new GridTile(Game);
                    Game.Grid[y][x] = newTile;
                    if (Game.CurrentDepth == 0)
                    {
                        newTile.SetBackgroundFeature(Game.GrassTile);
                    }
                    else
                    {
                        newTile.SetBackgroundFeature(dungeonFloorTile);
                    }
                }
            }

            Game.PanelRowMin = 0;
            Game.PanelRowMax = 0;
            Game.PanelColMin = 0;
            Game.PanelColMax = 0;
            Game.MonsterLevel = Game.Difficulty;
            Game.SpecialDanger = false;
            Game.DangerRating = 0;
            if (Game.CurrentDepth == 0)
            {
                if (Game.Wilderness[Game.WildernessY][Game.WildernessX].Town != null)
                {
                    Game.CurTown = Game.Wilderness[Game.WildernessY][Game.WildernessX].Town;
                    Game.DungeonDifficulty = 0;
                    Game.DunBias = null;
                    if (Game.Wilderness[Game.WildernessY][Game.WildernessX].Town.Char == 'K')
                    {
                Game.DungeonDifficulty = 35;
                Game.DunBias = Game.SingletonRepository.Get<MonsterRaceFilter>(nameof(CthuloidMonsterRaceFilter));
                    }
                }
                else if (Game.Wilderness[Game.WildernessY][Game.WildernessX].Dungeon != null)
                {
                    Game.DungeonDifficulty = Game.Wilderness[Game.WildernessY][Game.WildernessX].Dungeon.Offset / 2;
                    if (Game.DungeonDifficulty < 4)
                    {
                        Game.DungeonDifficulty = 4;
                    }
                    Game.DunBias = Game.Wilderness[Game.WildernessY][Game.WildernessX].Dungeon.BiasMonsterFilter;
                }
                else
                {
                    Game.DungeonDifficulty = 2;
                    Game.DunBias = Game.SingletonRepository.Get<MonsterRaceFilter>(nameof(AnimalMonsterRaceFilter));
                }
                Game.CurHgt = Constants.PlayableScreenHeight;
                Game.CurWid = Constants.PlayableScreenWidth;
                Game.MaxPanelRows = (Game.CurHgt / Constants.PlayableScreenHeight * 2) - 2;
                Game.MaxPanelCols = (Game.CurWid / Constants.PlayableScreenWidth * 2) - 2;
                Game.PanelRow = Game.MaxPanelRows;
                Game.PanelCol = Game.MaxPanelCols;
                if (Game.Wilderness[Game.WildernessY][Game.WildernessX].Town != null)
                {
                    TownGen();
                }
                else
                {
                    WildernessGen();
                }
            }
            else
            {
                if (!GenerateDungeon(Game.Difficulty))
                {
                    okay = false;
                }
            }
            if (Game.DangerRating > 100)
            {
                Game.DangerFeeling = 2;
            }
            else if (Game.DangerRating > 80)
            {
                Game.DangerFeeling = 3;
            }
            else if (Game.DangerRating > 60)
            {
                Game.DangerFeeling = 4;
            }
            else if (Game.DangerRating > 40)
            {
                Game.DangerFeeling = 5;
            }
            else if (Game.DangerRating > 30)
            {
                Game.DangerFeeling = 6;
            }
            else if (Game.DangerRating > 20)
            {
                Game.DangerFeeling = 7;
            }
            else if (Game.DangerRating > 10)
            {
                Game.DangerFeeling = 8;
            }
            else if (Game.DangerRating > 0)
            {
                Game.DangerFeeling = 9;
            }
            else
            {
                Game.DangerFeeling = 10;
            }
            if (Game.SpecialDanger)
            {
                Game.DangerFeeling = 1;
            }
            if (Game.CurrentDepth <= 0)
            {
                Game.DangerFeeling = 0;
            }
            Game.TreasureFeeling = ComputeTreasureFeelingIndex();
            if (Game.MonsterMax >= Constants.MaxMIdx)
            {
                okay = false;
            }
            if (generateAttemptNumber < 100)
            {
                int totalFeeling = Game.TreasureFeeling + Game.DangerFeeling;
                if (totalFeeling > 18 || (Game.Difficulty >= 5 && totalFeeling > 16) || (Game.Difficulty >= 10 && totalFeeling > 14) || (Game.Difficulty >= 20 && totalFeeling > 12) || (Game.Difficulty >= 40 && totalFeeling > 10))
                {
                    okay = false;
                }
            }
            if (okay)
            {
                break;
            }

            // Reset the level so that we can attempt again.
            Game.WipeMList();
        }
        Game.MarkLevelEntry();
    }
}
