// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.Enumerations;
using AngbandOS.StaticData;
using System;

namespace AngbandOS
{
    internal class LevelFactory
    {
        public const int CentMax = 100;
        public const int DoorMax = 200;
        public const int MaxRoomsCol = Level.MaxWid / _blockWid;
        public const int MaxRoomsRow = Level.MaxHgt / _blockHgt;
        public const int SafeMaxAttempts = 5000;
        public const int TunnMax = 900;
        public const int WallMax = 500;

        private const int _allocSetBoth = 3;
        private const int _allocSetCorr = 1;
        private const int _allocSetRoom = 2;
        private const int _allocTypGold = 4;
        private const int _allocTypObject = 5;
        private const int _allocTypRubble = 1;
        private const int _allocTypTrap = 3;
        private const int _blockHgt = 21;
        private const int _blockWid = 11;
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
        private const int _smallLevel = 3;

        private readonly Room[] _room =
        {
            new Room(0, 0, 0, 0, 0), new Room(0, 0, -1, 1, 1), new Room(0, 0, -1, 1, 1), new Room(0, 0, -1, 1, 3),
            new Room(0, 0, -1, 1, 3), new Room(0, 0, -1, 1, 5), new Room(0, 0, -1, 1, 5), new Room(0, 1, -1, 1, 5),
            new Room(-1, 2, -2, 3, 10), new Room(0, 1, -1, 1, 1)
        };

        private LevelBuildInfo _dun;
        private SaveGame _saveGame;

        public LevelFactory(SaveGame saveGame)
        {
            _saveGame = saveGame;
        }

        public void GenerateNewLevel()
        {
            for (int num = 0; ; num++)
            {
                bool okay = true;
                _saveGame.Level.OMax = 1;
                int i;
                for (i = 0; i < Level.MaxHgt; i++)
                {
                    _saveGame.Level.Grid[i] = new GridTile[Level.MaxWid];
                    for (int j = 0; j < Level.MaxWid; j++)
                    {
                        _saveGame.Level.Grid[i][j] = new GridTile(_saveGame);
                        if (_saveGame.CurrentDepth == 0)
                        {
                            _saveGame.Level.Grid[i][j].SetBackgroundFeature("Grass");
                        }
                        else if (_saveGame.Wilderness[_saveGame.Player.WildernessY][_saveGame.Player.WildernessX].Dungeon.Tower)
                        {
                            _saveGame.Level.Grid[i][j].SetBackgroundFeature("TowerFloor");
                        }
                        else
                        {
                            _saveGame.Level.Grid[i][j].SetBackgroundFeature("DungeonFloor");
                        }
                    }
                }
                _saveGame.Level.PanelRowMin = 0;
                _saveGame.Level.PanelRowMax = 0;
                _saveGame.Level.PanelColMin = 0;
                _saveGame.Level.PanelColMax = 0;
                if (_saveGame.CurrentDepth == 0)
                {
                    if (_saveGame.Wilderness[_saveGame.Player.WildernessY][_saveGame.Player.WildernessX]
                            .Town != null)
                    {
                        _saveGame.CurTown =
                            _saveGame.Wilderness[_saveGame.Player.WildernessY][_saveGame.Player.WildernessX]
                                .Town;
                        _saveGame.DungeonDifficulty = 0;
                        _saveGame.Level.Monsters.DunBias = 0;
                        if (_saveGame.Wilderness[_saveGame.Player.WildernessY][_saveGame.Player.WildernessX]
                                .Town.Char == 'K')
                        {
                            _saveGame.DungeonDifficulty = 35;
                            _saveGame.Level.Monsters.DunBias = Constants.SummonCthuloid;
                        }
                    }
                    else if (_saveGame.Wilderness[_saveGame.Player.WildernessY][
                                 _saveGame.Player.WildernessX].Dungeon != null)
                    {
                        _saveGame.DungeonDifficulty =
                            _saveGame.Wilderness[_saveGame.Player.WildernessY][_saveGame.Player.WildernessX]
                                .Dungeon.Offset / 2;
                        if (_saveGame.DungeonDifficulty < 4)
                        {
                            _saveGame.DungeonDifficulty = 4;
                        }
                        _saveGame.Level.Monsters.DunBias =
                            _saveGame.Wilderness[_saveGame.Player.WildernessY][_saveGame.Player.WildernessX]
                                .Dungeon.Bias;
                    }
                    else
                    {
                        _saveGame.DungeonDifficulty = 2;
                        _saveGame.Level.Monsters.DunBias = Constants.SummonAnimal;
                    }
                }
                else
                {
                    _saveGame.DungeonDifficulty = _saveGame.CurDungeon.Offset;
                    _saveGame.Level.Monsters.DunBias = _saveGame.CurDungeon.Bias;
                }
                _saveGame.Level.MonsterLevel = _saveGame.Difficulty;
                _saveGame.Level.ObjectLevel = _saveGame.Difficulty;
                _saveGame.Level.SpecialTreasure = false;
                _saveGame.Level.SpecialDanger = false;
                _saveGame.Level.TreasureRating = 0;
                _saveGame.Level.DangerRating = 0;
                if (_saveGame.CurrentDepth == 0)
                {
                    _saveGame.Level.CurHgt = Constants.ScreenHgt;
                    _saveGame.Level.CurWid = Constants.ScreenWid;
                    _saveGame.Level.MaxPanelRows = (_saveGame.Level.CurHgt / Constants.ScreenHgt * 2) - 2;
                    _saveGame.Level.MaxPanelCols = (_saveGame.Level.CurWid / Constants.ScreenWid * 2) - 2;
                    _saveGame.Level.PanelRow = _saveGame.Level.MaxPanelRows;
                    _saveGame.Level.PanelCol = _saveGame.Level.MaxPanelCols;
                    if (_saveGame.Wilderness[_saveGame.Player.WildernessY][_saveGame.Player.WildernessX]
                            .Town != null)
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
                    if (_saveGame.CurDungeon.Tower)
                    {
                        _saveGame.Level.CurHgt = Constants.ScreenHgt;
                        _saveGame.Level.CurWid = Constants.ScreenWid;
                        _saveGame.Level.MaxPanelRows = 0;
                        _saveGame.Level.MaxPanelCols = 0;
                        _saveGame.Level.PanelRow = 0;
                        _saveGame.Level.PanelCol = 0;
                    }
                    else
                    {
                        if (Program.Rng.DieRoll(_smallLevel) == 1)
                        {
                            int tester1 = Program.Rng.DieRoll(Level.MaxHgt / Constants.ScreenHgt);
                            int tester2 = Program.Rng.DieRoll(Level.MaxWid / Constants.ScreenWid);
                            _saveGame.Level.CurHgt = tester1 * Constants.ScreenHgt;
                            _saveGame.Level.CurWid = tester2 * Constants.ScreenWid;
                            _saveGame.Level.MaxPanelRows = (_saveGame.Level.CurHgt / Constants.ScreenHgt * 2) - 2;
                            _saveGame.Level.MaxPanelCols = (_saveGame.Level.CurWid / Constants.ScreenWid * 2) - 2;
                            _saveGame.Level.PanelRow = _saveGame.Level.MaxPanelRows;
                            _saveGame.Level.PanelCol = _saveGame.Level.MaxPanelCols;
                        }
                        else
                        {
                            _saveGame.Level.CurHgt = Level.MaxHgt;
                            _saveGame.Level.CurWid = Level.MaxWid;
                            _saveGame.Level.MaxPanelRows = (_saveGame.Level.CurHgt / Constants.ScreenHgt * 2) - 2;
                            _saveGame.Level.MaxPanelCols = (_saveGame.Level.CurWid / Constants.ScreenWid * 2) - 2;
                            _saveGame.Level.PanelRow = _saveGame.Level.MaxPanelRows;
                            _saveGame.Level.PanelCol = _saveGame.Level.MaxPanelCols;
                        }
                    }
                    if (!UndergroundGen())
                    {
                        okay = false;
                    }
                }
                if (_saveGame.Level.TreasureRating > 100)
                {
                    _saveGame.Level.TreasureFeeling = 2;
                }
                else if (_saveGame.Level.TreasureRating > 80)
                {
                    _saveGame.Level.TreasureFeeling = 3;
                }
                else if (_saveGame.Level.TreasureRating > 60)
                {
                    _saveGame.Level.TreasureFeeling = 4;
                }
                else if (_saveGame.Level.TreasureRating > 40)
                {
                    _saveGame.Level.TreasureFeeling = 5;
                }
                else if (_saveGame.Level.TreasureRating > 30)
                {
                    _saveGame.Level.TreasureFeeling = 6;
                }
                else if (_saveGame.Level.TreasureRating > 20)
                {
                    _saveGame.Level.TreasureFeeling = 7;
                }
                else if (_saveGame.Level.TreasureRating > 10)
                {
                    _saveGame.Level.TreasureFeeling = 8;
                }
                else if (_saveGame.Level.TreasureRating > 0)
                {
                    _saveGame.Level.TreasureFeeling = 9;
                }
                else
                {
                    _saveGame.Level.TreasureFeeling = 10;
                }
                if (_saveGame.Level.SpecialTreasure)
                {
                    _saveGame.Level.TreasureRating = 1;
                }
                if (_saveGame.Level.DangerRating > 100)
                {
                    _saveGame.Level.DangerFeeling = 2;
                }
                else if (_saveGame.Level.DangerRating > 80)
                {
                    _saveGame.Level.DangerFeeling = 3;
                }
                else if (_saveGame.Level.DangerRating > 60)
                {
                    _saveGame.Level.DangerFeeling = 4;
                }
                else if (_saveGame.Level.DangerRating > 40)
                {
                    _saveGame.Level.DangerFeeling = 5;
                }
                else if (_saveGame.Level.DangerRating > 30)
                {
                    _saveGame.Level.DangerFeeling = 6;
                }
                else if (_saveGame.Level.DangerRating > 20)
                {
                    _saveGame.Level.DangerFeeling = 7;
                }
                else if (_saveGame.Level.DangerRating > 10)
                {
                    _saveGame.Level.DangerFeeling = 8;
                }
                else if (_saveGame.Level.DangerRating > 0)
                {
                    _saveGame.Level.DangerFeeling = 9;
                }
                else
                {
                    _saveGame.Level.DangerFeeling = 10;
                }
                if (_saveGame.Level.SpecialDanger)
                {
                    _saveGame.Level.DangerFeeling = 1;
                }
                if (_saveGame.CurrentDepth <= 0)
                {
                    _saveGame.Level.TreasureFeeling = 0;
                    _saveGame.Level.DangerFeeling = 0;
                }
                if (_saveGame.Level.OMax >= Constants.MaxOIdx)
                {
                    okay = false;
                }
                if (_saveGame.Level.MMax >= Constants.MaxMIdx)
                {
                    okay = false;
                }
                if (num < 100)
                {
                    int totalFeeling = _saveGame.Level.TreasureFeeling + _saveGame.Level.DangerFeeling;
                    if (totalFeeling > 18 ||
                        (_saveGame.Difficulty >= 5 && totalFeeling > 16) ||
                        (_saveGame.Difficulty >= 10 && totalFeeling > 14) ||
                        (_saveGame.Difficulty >= 20 && totalFeeling > 12) ||
                        (_saveGame.Difficulty >= 40 && totalFeeling > 10))
                    {
                        okay = false;
                    }
                }
                if (okay)
                {
                    break;
                }
                _saveGame.Level.WipeOList();
                _saveGame.Level.Monsters.WipeMList();
            }
            _saveGame.Player.GameTime.MarkLevelEntry();
        }

        private void AllocObject(int set, int typ, int num)
        {
            int y = 0;
            int x = 0;
            int dummy = 0;
            for (int k = 0; k < num; k++)
            {
                while (dummy < SafeMaxAttempts)
                {
                    dummy++;
                    y = Program.Rng.RandomLessThan(_saveGame.Level.CurHgt);
                    x = Program.Rng.RandomLessThan(_saveGame.Level.CurWid);
                    if (!_saveGame.Level.GridOpenNoItemOrCreature(y, x))
                    {
                        continue;
                    }
                    bool isRoom = _saveGame.Level.Grid[y][x].TileFlags.IsSet(GridTile.InRoom);
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
                if (dummy >= SafeMaxAttempts)
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
                            _saveGame.Level.PlaceTrap(y, x);
                            break;
                        }
                    case _allocTypGold:
                        {
                            _saveGame.Level.PlaceGold(y, x);
                            break;
                        }
                    case _allocTypObject:
                        {
                            _saveGame.Level.PlaceObject(y, x, false, false);
                            break;
                        }
                }
            }
        }

        private void AllocStairs(string feat, int num, int walls)
        {
            for (int i = 0; i < num; i++)
            {
                for (bool flag = false; !flag;)
                {
                    for (int j = 0; !flag && j <= 3000; j++)
                    {
                        int y = Program.Rng.RandomLessThan(_saveGame.Level.CurHgt);
                        int x = Program.Rng.RandomLessThan(_saveGame.Level.CurWid);
                        if (!_saveGame.Level.GridOpenNoItemOrCreature(y, x))
                        {
                            continue;
                        }
                        if (NextToWalls(y, x) < walls)
                        {
                            continue;
                        }
                        GridTile cPtr = _saveGame.Level.Grid[y][x];
                        if (_saveGame.CurrentDepth <= 0)
                        {
                            cPtr.SetFeature("DownStair");
                        }
                        else if (_saveGame.Quests.IsQuest(_saveGame.CurrentDepth) ||
                                 _saveGame.CurrentDepth == _saveGame.CurDungeon.MaxLevel)
                        {
                            cPtr.SetFeature(_saveGame.CurDungeon.Tower ? "DownStair" : "UpStair");
                        }
                        else
                        {
                            cPtr.SetFeature(feat);
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

        private void BuildField(int yy, int xx)
        {
            int y0 = (yy * 9) + 8;
            int x0 = (xx * 15) + 10;
            int y1 = y0 - Program.Rng.DieRoll(2) - 1;
            int y2 = y0 + Program.Rng.DieRoll(2) + 1;
            int x1 = x0 - Program.Rng.DieRoll(3) - 2;
            int x2 = x0 + Program.Rng.DieRoll(3) + 2;
            const string feature = "Field";
            for (int x = x1; x < x2; x++)
            {
                for (int y = y1; y < y2; y++)
                {
                    _saveGame.Level.Grid[y][x].SetFeature(feature);
                    _saveGame.Level.Grid[y][x].SetBackgroundFeature(feature);
                }
            }
            if (Program.Rng.DieRoll(5) == 4)
            {
                int x = Program.Rng.RandomBetween(x1, x2);
                int y = Program.Rng.RandomBetween(y1, y2);
                _saveGame.Level.Grid[y][x].SetFeature("Scarecrow");
            }
        }

        private void BuildGraveyard(int yy, int xx)
        {
            int y0 = (yy * 9) + 8;
            int x0 = (xx * 15) + 10;
            int y1 = y0 - Program.Rng.DieRoll(2) - 1;
            int y2 = y0 + Program.Rng.DieRoll(2) + 1;
            int x1 = x0 - Program.Rng.DieRoll(3) - 2;
            int x2 = x0 + Program.Rng.DieRoll(3) + 2;
            for (int i = 0; i < Program.Rng.RandomBetween(10, 20); i++)
            {
                int x = (Program.Rng.RandomBetween(x1, x2) / 2 * 2) + 1;
                int y = (Program.Rng.RandomBetween(y1, y2) / 2 * 2) + 1;
                _saveGame.Level.Grid[y][x].SetFeature("Grave");
            }
        }

        private void BuildStore(Store store, int yy, int xx)
        {
            int y, x;
            GridTile cPtr;
            if (_saveGame.CurTown.Char != 'K')
            {
                if (store.StoreType == StoreType.StoreEmptyLot)
                {
                    switch (Program.Rng.DieRoll(10))
                    {
                        case 3:
                        case 7:
                        case 9:
                            break;

                        case 6:
                            BuildGraveyard(yy, xx);
                            break;

                        default:
                            BuildField(yy, xx);
                            break;
                    }
                    return;
                }
            }
            int y0 = (yy * 9) + 6;
            int x0 = (xx * 15) + 10;
            int y1 = y0 - Program.Rng.DieRoll(2);
            int y2 = y0 + Program.Rng.DieRoll(2) + 1;
            int x1 = x0 - Program.Rng.DieRoll(3) - 2;
            int x2 = x0 + Program.Rng.DieRoll(3) + 2;
            if ((y2 - y1) % 2 == 0)
            {
                y2++;
            }
            for (y = y1; y <= y2; y++)
            {
                for (x = x1; x <= x2; x++)
                {
                    cPtr = _saveGame.Level.Grid[y][x];
                    if (_saveGame.CurTown.Char == 'K')
                    {
                        switch (Program.Rng.DieRoll(6))
                        {
                            case 1:
                                cPtr.SetFeature("WallInner");
                                break;

                            case 2:
                            case 3:
                            case 4:
                                cPtr.SetFeature("Rubble");
                                break;
                        }
                    }
                    else
                    {
                        if (y == y2)
                        {
                            cPtr.SetFeature("WallPermBuilding");
                        }
                        else
                        {
                            cPtr.SetFeature("Roof");
                        }
                    }
                    cPtr.TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                }
            }
            y = y2;
            x = Program.Rng.RandomBetween(x1 + 1, x2 - 2);
            cPtr = _saveGame.Level.Grid[y][x];
            if (_saveGame.CurTown.Char == 'K')
            {
                if (Program.Rng.DieRoll(8) == 6)
                {
                    PlaceRandomDoor(y, x);
                }
            }
            else
            {
                cPtr.SetFeature(store.FeatureType);
            }
            store.SetLocation(x, y);
            for (++y; y < y0 + 7; y++)
            {
                cPtr = _saveGame.Level.Grid[y][x];
                cPtr.SetFeature("PathBase");
            }
            y--;
            int dX = Math.Sign((_saveGame.Level.CurWid / 2) - x);
            for (x += dX; x != _saveGame.Level.CurWid / 2; x += dX)
            {
                cPtr = _saveGame.Level.Grid[y][x];
                cPtr.SetFeature("PathBase");
            }
        }

        private void BuildStreamer(string feat, int chance)
        {
            int dummy = 0;
            int y = Program.Rng.RandomSpread(_saveGame.Level.CurHgt / 2, 10);
            int x = Program.Rng.RandomSpread(_saveGame.Level.CurWid / 2, 15);
            int dir = _saveGame.Level.OrderedDirection[Program.Rng.RandomLessThan(8)];
            while (dummy < SafeMaxAttempts)
            {
                dummy++;
                for (int i = 0; i < _dunStrDen; i++)
                {
                    const int d = _dunStrRng;
                    int tx;
                    int ty;
                    while (true)
                    {
                        ty = Program.Rng.RandomSpread(y, d);
                        tx = Program.Rng.RandomSpread(x, d);
                        if (!_saveGame.Level.InBounds2(ty, tx))
                        {
                            continue;
                        }
                        break;
                    }
                    GridTile cPtr = _saveGame.Level.Grid[ty][tx];

                    if (!cPtr.FeatureType.IsBasicWall)
                    {
                        continue;
                    }
                    cPtr.SetFeature(feat);
                    if (Program.Rng.RandomLessThan(chance) == 0)
                    {
                        cPtr.SetFeature(cPtr.FeatureType.Name + "VisTreas");
                    }
                }
                if (dummy >= SafeMaxAttempts)
                {
                    return;
                }
                y += _saveGame.Level.KeypadDirectionYOffset[dir];
                x += _saveGame.Level.KeypadDirectionXOffset[dir];
                if (!_saveGame.Level.InBounds(y, x))
                {
                    break;
                }
            }
        }

        private void BuildTunnel(int row1, int col1, int row2, int col2)
        {
            int i, y, x;
            int mainLoopCount = 0;
            bool doorFlag = false;
            GridTile cPtr;
            _dun.TunnN = 0;
            _dun.WallN = 0;
            int startRow = row1;
            int startCol = col1;
            CorrectDir(out int rowDir, out int colDir, row1, col1, row2, col2);
            while (row1 != row2 || col1 != col2)
            {
                if (mainLoopCount++ > 2000)
                {
                    break;
                }
                if (Program.Rng.RandomLessThan(100) < _dunTunChg)
                {
                    CorrectDir(out rowDir, out colDir, row1, col1, row2, col2);
                    if (Program.Rng.RandomLessThan(100) < _dunTunRnd)
                    {
                        RandDir(out rowDir, out colDir);
                    }
                }
                int tmpRow = row1 + rowDir;
                int tmpCol = col1 + colDir;
                while (!_saveGame.Level.InBounds(tmpRow, tmpCol))
                {
                    CorrectDir(out rowDir, out colDir, row1, col1, row2, col2);
                    if (Program.Rng.RandomLessThan(100) < _dunTunRnd)
                    {
                        RandDir(out rowDir, out colDir);
                    }
                    tmpRow = row1 + rowDir;
                    tmpCol = col1 + colDir;
                }
                cPtr = _saveGame.Level.Grid[tmpRow][tmpCol];
                if (cPtr.FeatureType.Name == "WallPermSolid")
                {
                    continue;
                }
                if (cPtr.FeatureType.Name == "WallPermOuter")
                {
                    continue;
                }
                if (cPtr.FeatureType.Name == "WallSolid")
                {
                    continue;
                }
                if (cPtr.FeatureType.Name == "WallOuter")
                {
                    y = tmpRow + rowDir;
                    x = tmpCol + colDir;
                    if (_saveGame.Level.Grid[y][x].FeatureType.Name == "WallPermSolid")
                    {
                        continue;
                    }
                    if (_saveGame.Level.Grid[y][x].FeatureType.Name == "WallPermOuter")
                    {
                        continue;
                    }
                    if (_saveGame.Level.Grid[y][x].FeatureType.Name == "WallOuter")
                    {
                        continue;
                    }
                    if (_saveGame.Level.Grid[y][x].FeatureType.Name == "WallSolid")
                    {
                        continue;
                    }
                    row1 = tmpRow;
                    col1 = tmpCol;
                    if (_dun.WallN < WallMax)
                    {
                        _dun.Wall[_dun.WallN].Y = row1;
                        _dun.Wall[_dun.WallN].X = col1;
                        _dun.WallN++;
                    }
                    for (y = row1 - 1; y <= row1 + 1; y++)
                    {
                        for (x = col1 - 1; x <= col1 + 1; x++)
                        {
                            if (_saveGame.Level.Grid[y][x].FeatureType.Name == "WallOuter")
                            {
                                _saveGame.Level.Grid[y][x].SetFeature("WallSolid");
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
                    if (_dun.TunnN < TunnMax)
                    {
                        _dun.Tunn[_dun.TunnN].Y = row1;
                        _dun.Tunn[_dun.TunnN].X = col1;
                        _dun.TunnN++;
                    }
                    doorFlag = false;
                }
                else
                {
                    row1 = tmpRow;
                    col1 = tmpCol;
                    if (!doorFlag)
                    {
                        if (_dun.DoorN < DoorMax)
                        {
                            _dun.Door[_dun.DoorN].Y = row1;
                            _dun.Door[_dun.DoorN].X = col1;
                            _dun.DoorN++;
                        }
                        doorFlag = true;
                    }
                    if (Program.Rng.RandomLessThan(100) >= _dunTunCon)
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
            for (i = 0; i < _dun.TunnN; i++)
            {
                y = _dun.Tunn[i].Y;
                x = _dun.Tunn[i].X;
                cPtr = _saveGame.Level.Grid[y][x];
                cPtr.RevertToBackground();
            }
            for (i = 0; i < _dun.WallN; i++)
            {
                y = _dun.Wall[i].Y;
                x = _dun.Wall[i].X;
                cPtr = _saveGame.Level.Grid[y][x];
                cPtr.RevertToBackground();
                if (Program.Rng.RandomLessThan(100) < _dunTunPen)
                {
                    PlaceRandomDoor(y, x);
                }
            }
        }

        private void CorrectDir(out int rdir, out int cdir, int y1, int x1, int y2, int x2)
        {
            rdir = y1 == y2 ? 0 : y1 < y2 ? 1 : -1;
            cdir = x1 == x2 ? 0 : x1 < x2 ? 1 : -1;
            if (rdir != 0 && cdir != 0)
            {
                if (Program.Rng.RandomLessThan(100) < 50)
                {
                    rdir = 0;
                }
                else
                {
                    cdir = 0;
                }
            }
        }

        private void DestroyLevel()
        {
            for (int n = 0; n < Program.Rng.DieRoll(5); n++)
            {
                int x1 = Program.Rng.RandomBetween(5, _saveGame.Level.CurWid - 1 - 5);
                int y1 = Program.Rng.RandomBetween(5, _saveGame.Level.CurHgt - 1 - 5);
                int y;
                for (y = y1 - 15; y <= y1 + 15; y++)
                {
                    int x;
                    for (x = x1 - 15; x <= x1 + 15; x++)
                    {
                        if (!_saveGame.Level.InBounds(y, x))
                        {
                            continue;
                        }
                        int k = _saveGame.Level.Distance(y1, x1, y, x);
                        if (k >= 16)
                        {
                            continue;
                        }
                        _saveGame.Level.DeleteMonster(y, x);
                        if (_saveGame.Level.CaveValidBold(y, x))
                        {
                            _saveGame.Level.DeleteObject(y, x);
                            GridTile cPtr = _saveGame.Level.Grid[y][x];
                            int t = Program.Rng.RandomLessThan(200);
                            if (t < 20)
                            {
                                cPtr.SetFeature("WallBasic");
                            }
                            else if (t < 70)
                            {
                                cPtr.SetFeature("Quartz");
                            }
                            else if (t < 100)
                            {
                                cPtr.SetFeature("Magma");
                            }
                            else
                            {
                                cPtr.RevertToBackground();
                            }
                            cPtr.TileFlags.Clear(GridTile.InRoom | GridTile.InVault);
                            cPtr.TileFlags.Clear(GridTile.PlayerMemorised | GridTile.SelfLit);
                        }
                    }
                }
            }
        }

        private void MakeCavernLevel()
        {
            PerlinNoise perlinNoise = new PerlinNoise(Program.Rng.RandomBetween(0, int.MaxValue - 1));
            double widthDivisor = 1 / (double)_saveGame.Level.CurWid;
            double heightDivisor = 1 / (double)_saveGame.Level.CurHgt;
            for (int y = 0; y < _saveGame.Level.CurHgt; y++)
            {
                for (int x = 0; x < _saveGame.Level.CurWid; x++)
                {
                    GridTile cPtr = _saveGame.Level.Grid[y][x];
                    double v = perlinNoise.Noise(10 * x * widthDivisor, 10 * y * heightDivisor, -0.5);
                    v = (v + 1) / 2;
                    double dX = Math.Abs(x - (_saveGame.Level.CurWid / 2)) * widthDivisor;
                    double dY = Math.Abs(y - (_saveGame.Level.CurHgt / 2)) * heightDivisor;
                    double d = Math.Max(dX, dY);
                    const double elevation = 0.05;
                    const double steepness = 6.0;
                    const double dropoff = 50.0;
                    v += elevation - (dropoff * Math.Pow(d, steepness));
                    v = Math.Min(1, Math.Max(0, v));
                    int rounded = (int)(v * 10);
                    if (rounded < 2 || rounded > 5)
                    {
                        cPtr.SetFeature("WallBasic");
                    }
                    else
                    {
                        cPtr.SetFeature("DungeonFloor");
                    }
                }
            }
            for (int i = 0; i < _dunStrMag; i++)
            {
                BuildStreamer("Magma", _dunStrMc);
            }
            for (int i = 0; i < _dunStrQua; i++)
            {
                BuildStreamer("Quartz", _dunStrQc);
            }
            for (int x = 0; x < _saveGame.Level.CurWid; x++)
            {
                GridTile cPtr = _saveGame.Level.Grid[0][x];
                cPtr.SetFeature("WallPermSolid");
            }
            for (int x = 0; x < _saveGame.Level.CurWid; x++)
            {
                GridTile cPtr = _saveGame.Level.Grid[_saveGame.Level.CurHgt - 1][x];
                cPtr.SetFeature("WallPermSolid");
            }
            for (int y = 0; y < _saveGame.Level.CurHgt; y++)
            {
                GridTile cPtr = _saveGame.Level.Grid[y][0];
                cPtr.SetFeature("WallPermSolid");
            }
            for (int y = 0; y < _saveGame.Level.CurHgt; y++)
            {
                GridTile cPtr = _saveGame.Level.Grid[y][_saveGame.Level.CurWid - 1];
                cPtr.SetFeature("WallPermSolid");
            }
            if (Program.Rng.DieRoll(_darkEmpty) != 1 || Program.Rng.DieRoll(100) > _saveGame.Difficulty)
            {
                _saveGame.Level.WizLight();
            }
        }

        private void MakeCornerTowers(int wildX, int wildY)
        {
            Island wilderness = _saveGame.Wilderness;
            int height = _saveGame.Level.CurHgt;
            int width = _saveGame.Level.CurWid;
            if ((wilderness[wildY][wildX].Town != null) || (wilderness[wildY - 1][wildX].Town != null) ||
                (wilderness[wildY][wildX - 1].Town != null) || (wilderness[wildY - 1][wildX - 1].Town != null))
            {
                _saveGame.Level.Grid[0][0].SetBackgroundFeature("InsideGatehouse");
                _saveGame.Level.Grid[0][0].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[1][0].SetBackgroundFeature("InsideGatehouse");
                _saveGame.Level.Grid[1][0].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[1][1].SetBackgroundFeature("InsideGatehouse");
                _saveGame.Level.Grid[1][1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[0][1].SetBackgroundFeature("InsideGatehouse");
                _saveGame.Level.Grid[0][1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[0][0].RevertToBackground();
                _saveGame.Level.Grid[0][0].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[1][0].SetFeature("TownWall");
                _saveGame.Level.Grid[1][0].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[1][1].SetFeature("TownWall");
                _saveGame.Level.Grid[1][1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[0][1].SetFeature("TownWall");
                _saveGame.Level.Grid[0][1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            }
            if ((wilderness[wildY][wildX].Town != null) || (wilderness[wildY - 1][wildX].Town != null) ||
                (wilderness[wildY][wildX + 1].Town != null) || (wilderness[wildY - 1][wildX + 1].Town != null))
            {
                _saveGame.Level.Grid[0][width - 1].SetBackgroundFeature("InsideGatehouse");
                _saveGame.Level.Grid[0][width - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[1][width - 1].SetBackgroundFeature("InsideGatehouse");
                _saveGame.Level.Grid[1][width - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[1][width - 2].SetBackgroundFeature("InsideGatehouse");
                _saveGame.Level.Grid[1][width - 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[0][width - 2].SetBackgroundFeature("InsideGatehouse");
                _saveGame.Level.Grid[0][width - 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[0][width - 1].RevertToBackground();
                _saveGame.Level.Grid[0][width - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[1][width - 1].SetFeature("TownWall");
                _saveGame.Level.Grid[1][width - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[1][width - 2].SetFeature("TownWall");
                _saveGame.Level.Grid[1][width - 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[0][width - 2].SetFeature("TownWall");
                _saveGame.Level.Grid[0][width - 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            }
            if ((wilderness[wildY][wildX].Town != null) || (wilderness[wildY + 1][wildX].Town != null) ||
                (wilderness[wildY][wildX + 1].Town != null) || (wilderness[wildY + 1][wildX + 1].Town != null))
            {
                _saveGame.Level.Grid[height - 1][width - 1].SetBackgroundFeature("InsideGatehouse");
                _saveGame.Level.Grid[height - 1][width - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[height - 2][width - 1].SetBackgroundFeature("InsideGatehouse");
                _saveGame.Level.Grid[height - 2][width - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[height - 2][width - 2].SetBackgroundFeature("InsideGatehouse");
                _saveGame.Level.Grid[height - 2][width - 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[height - 1][width - 2].SetBackgroundFeature("InsideGatehouse");
                _saveGame.Level.Grid[height - 1][width - 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[height - 1][width - 1].RevertToBackground();
                _saveGame.Level.Grid[height - 1][width - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[height - 2][width - 1].SetFeature("TownWall");
                _saveGame.Level.Grid[height - 2][width - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[height - 2][width - 2].SetFeature("TownWall");
                _saveGame.Level.Grid[height - 2][width - 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[height - 1][width - 2].SetFeature("TownWall");
                _saveGame.Level.Grid[height - 1][width - 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            }
            if ((wilderness[wildY][wildX].Town != null) || (wilderness[wildY + 1][wildX].Town != null) ||
                (wilderness[wildY][wildX - 1].Town != null) || (wilderness[wildY + 1][wildX - 1].Town != null))
            {
                _saveGame.Level.Grid[height - 1][0].SetBackgroundFeature("InsideGatehouse");
                _saveGame.Level.Grid[height - 1][0].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[height - 2][0].SetBackgroundFeature("InsideGatehouse");
                _saveGame.Level.Grid[height - 2][0].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[height - 2][1].SetBackgroundFeature("InsideGatehouse");
                _saveGame.Level.Grid[height - 2][1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[height - 1][1].SetBackgroundFeature("InsideGatehouse");
                _saveGame.Level.Grid[height - 1][1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[height - 1][0].RevertToBackground();
                _saveGame.Level.Grid[height - 1][0].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[height - 2][0].SetFeature("TownWall");
                _saveGame.Level.Grid[height - 2][0].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[height - 2][1].SetFeature("TownWall");
                _saveGame.Level.Grid[height - 2][1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[height - 1][1].SetFeature("TownWall");
                _saveGame.Level.Grid[height - 1][1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            }
        }

        private void MakeDungeonEntrance(int left, int top, int width, int height, out int stairX, out int stairY)
        {
            int dummy = 0;
            int x = 1;
            int y = 1;
            while (dummy < SafeMaxAttempts)
            {
                dummy++;
                y = Program.Rng.RandomBetween(top, top + height);
                x = Program.Rng.RandomBetween(left, left + width);
                if (_saveGame.Level.GridOpenNoItemOrCreature(y, x))
                {
                    break;
                }
            }
            _saveGame.Level.Grid[y - 2][x].RevertToBackground();
            _saveGame.Level.Grid[y - 1][x - 1].RevertToBackground();
            _saveGame.Level.Grid[y - 1][x].RevertToBackground();
            _saveGame.Level.Grid[y - 1][x + 1].RevertToBackground();
            _saveGame.Level.Grid[y][x - 2].RevertToBackground();
            _saveGame.Level.Grid[y][x - 1].RevertToBackground();
            _saveGame.Level.Grid[y][x].SetFeature("DownStair");
            stairX = x;
            stairY = y;
            _saveGame.Level.Grid[y][x + 1].RevertToBackground();
            _saveGame.Level.Grid[y][x + 2].RevertToBackground();
            _saveGame.Level.Grid[y + 1][x - 1].RevertToBackground();
            _saveGame.Level.Grid[y + 1][x].RevertToBackground();
            _saveGame.Level.Grid[y + 1][x + 1].RevertToBackground();
            _saveGame.Level.Grid[y + 2][x].RevertToBackground();
        }

        private void MakeDungeonLevel()
        {
            int i;
            int k;
            int y;
            int x;
            int maxVaultOk = 2;
            bool destroyed = false;
            bool emptyLevel = false;
            _dun = new LevelBuildInfo();
            if (_saveGame.Level.MaxPanelRows == 0)
            {
                maxVaultOk--;
            }
            if (_saveGame.Level.MaxPanelCols == 0)
            {
                maxVaultOk--;
            }
            if (Program.Rng.DieRoll(_emptyLevel) == 1)
            {
                emptyLevel = true;
            }
            for (y = 0; y < _saveGame.Level.CurHgt; y++)
            {
                for (x = 0; x < _saveGame.Level.CurWid; x++)
                {
                    GridTile cPtr = _saveGame.Level.Grid[y][x];
                    if (emptyLevel)
                    {
                        cPtr.RevertToBackground();
                    }
                    else
                    {
                        cPtr.SetFeature("WallBasic");
                    }
                }
            }
            if (_saveGame.Difficulty > 10 && Program.Rng.RandomLessThan(_dunDest) == 0)
            {
                destroyed = true;
            }
            if (_saveGame.Quests.IsQuest(_saveGame.CurrentDepth))
            {
                destroyed = false;
            }
            _dun.RowRooms = _saveGame.Level.CurHgt / _blockHgt;
            _dun.ColRooms = _saveGame.Level.CurWid / _blockWid;
            for (y = 0; y < _dun.RowRooms; y++)
            {
                for (x = 0; x < _dun.ColRooms; x++)
                {
                    _dun.RoomMap[y][x] = false;
                }
            }
            _dun.Crowded = false;
            _dun.CentN = 0;
            for (i = 0; i < _dunRooms; i++)
            {
                y = Program.Rng.RandomLessThan(_dun.RowRooms);
                x = Program.Rng.RandomLessThan(_dun.ColRooms);
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
                    if (RoomBuild(y, x, 1))
                    {
                    }
                    continue;
                }
                if (Program.Rng.RandomLessThan(_dunUnusual) < _saveGame.Difficulty)
                {
                    k = Program.Rng.RandomLessThan(100);
                    if (Program.Rng.RandomLessThan(_dunUnusual) < _saveGame.Difficulty)
                    {
                        if (k < 10)
                        {
                            if (maxVaultOk > 1)
                            {
                                if (RoomBuild(y, x, 8))
                                {
                                    continue;
                                }
                            }
                        }
                        if (k < 25)
                        {
                            if (maxVaultOk > 0)
                            {
                                if (RoomBuild(y, x, 7))
                                {
                                    continue;
                                }
                            }
                        }
                        if (k < 40 && RoomBuild(y, x, 5))
                        {
                            continue;
                        }
                        if (k < 55 && RoomBuild(y, x, 6))
                        {
                            continue;
                        }
                    }
                    if (k < 25 && RoomBuild(y, x, 4))
                    {
                        continue;
                    }
                    if (k < 50 && RoomBuild(y, x, 3))
                    {
                        continue;
                    }
                    if (k < 100 && RoomBuild(y, x, 2))
                    {
                        continue;
                    }
                }
                if (RoomBuild(y, x, 1))
                {
                }
            }
            for (x = 0; x < _saveGame.Level.CurWid; x++)
            {
                GridTile cPtr = _saveGame.Level.Grid[0][x];
                cPtr.SetFeature("WallPermSolid");
            }
            for (x = 0; x < _saveGame.Level.CurWid; x++)
            {
                GridTile cPtr = _saveGame.Level.Grid[_saveGame.Level.CurHgt - 1][x];
                cPtr.SetFeature("WallPermSolid");
            }
            for (y = 0; y < _saveGame.Level.CurHgt; y++)
            {
                GridTile cPtr = _saveGame.Level.Grid[y][0];
                cPtr.SetFeature("WallPermSolid");
            }
            for (y = 0; y < _saveGame.Level.CurHgt; y++)
            {
                GridTile cPtr = _saveGame.Level.Grid[y][_saveGame.Level.CurWid - 1];
                cPtr.SetFeature("WallPermSolid");
            }
            for (i = 0; i < _dun.CentN; i++)
            {
                int pick1 = Program.Rng.RandomLessThan(_dun.CentN);
                int pick2 = Program.Rng.RandomLessThan(_dun.CentN);
                int y1 = _dun.Cent[pick1].Y;
                int x1 = _dun.Cent[pick1].X;
                _dun.Cent[pick1].Y = _dun.Cent[pick2].Y;
                _dun.Cent[pick1].X = _dun.Cent[pick2].X;
                _dun.Cent[pick2].Y = y1;
                _dun.Cent[pick2].X = x1;
            }
            _dun.DoorN = 0;
            y = _dun.Cent[_dun.CentN - 1].Y;
            x = _dun.Cent[_dun.CentN - 1].X;
            for (i = 0; i < _dun.CentN; i++)
            {
                BuildTunnel(_dun.Cent[i].Y, _dun.Cent[i].X, y, x);
                y = _dun.Cent[i].Y;
                x = _dun.Cent[i].X;
            }
            for (i = 0; i < _dun.DoorN; i++)
            {
                y = _dun.Door[i].Y;
                x = _dun.Door[i].X;
                TryDoor(y, x - 1);
                TryDoor(y, x + 1);
                TryDoor(y - 1, x);
                TryDoor(y + 1, x);
            }
            for (i = 0; i < _dunStrMag; i++)
            {
                BuildStreamer("Magma", _dunStrMc);
            }
            for (i = 0; i < _dunStrQua; i++)
            {
                BuildStreamer("Quartz", _dunStrQc);
            }
            if (destroyed)
            {
                DestroyLevel();
            }
            if (emptyLevel && (Program.Rng.DieRoll(_darkEmpty) != 1 ||
                               Program.Rng.DieRoll(100) > _saveGame.Difficulty))
            {
                _saveGame.Level.WizLight();
            }
        }

        private void MakeHenge(int left, int top, int width, int height)
        {
            int midX = left + (width / 2);
            int midY = top + (height / 2);
            for (int y = midY - 3; y < midY + 3; y++)
            {
                _saveGame.Level.Grid[y][midX - 7].SetBackgroundFeature("Grass");
                _saveGame.Level.Grid[y][midX - 7].SetFeature("Grass");
            }
            for (int y = midY - 5; y < midY + 5; y++)
            {
                _saveGame.Level.Grid[y][midX - 6].SetBackgroundFeature("Grass");
                _saveGame.Level.Grid[y][midX - 6].SetFeature("Grass");
            }
            for (int y = midY - 6; y < midY + 6; y++)
            {
                _saveGame.Level.Grid[y][midX - 5].SetBackgroundFeature("Grass");
                _saveGame.Level.Grid[y][midX - 5].SetFeature("Grass");
            }
            for (int y = midY - 6; y < midY + 6; y++)
            {
                _saveGame.Level.Grid[y][midX - 4].SetBackgroundFeature("Grass");
                _saveGame.Level.Grid[y][midX - 4].SetFeature("Grass");
            }
            for (int y = midY - 7; y < midY + 6; y++)
            {
                _saveGame.Level.Grid[y][midX - 3].SetBackgroundFeature("Grass");
                _saveGame.Level.Grid[y][midX - 3].SetFeature("Grass");
            }
            for (int y = midY - 7; y < midY + 6; y++)
            {
                _saveGame.Level.Grid[y][midX - 2].SetBackgroundFeature("Grass");
                _saveGame.Level.Grid[y][midX - 2].SetFeature("Grass");
            }
            for (int y = midY - 6; y < midY + 6; y++)
            {
                _saveGame.Level.Grid[y][midX - 1].SetBackgroundFeature("Grass");
                _saveGame.Level.Grid[y][midX - 1].SetFeature("Grass");
            }
            for (int y = midY - 7; y < midY + 6; y++)
            {
                _saveGame.Level.Grid[y][midX].SetBackgroundFeature("Grass");
                _saveGame.Level.Grid[y][midX].SetFeature("Grass");
            }
            for (int y = midY - 7; y < midY + 6; y++)
            {
                _saveGame.Level.Grid[y][midX + 1].SetBackgroundFeature("Grass");
                _saveGame.Level.Grid[y][midX + 1].SetFeature("Grass");
            }
            for (int y = midY - 6; y < midY + 6; y++)
            {
                _saveGame.Level.Grid[y][midX + 2].SetBackgroundFeature("Grass");
                _saveGame.Level.Grid[y][midX + 2].SetFeature("Grass");
            }
            for (int y = midY - 7; y < midY + 6; y++)
            {
                _saveGame.Level.Grid[y][midX + 3].SetBackgroundFeature("Grass");
                _saveGame.Level.Grid[y][midX + 3].SetFeature("Grass");
            }
            for (int y = midY - 6; y < midY + 6; y++)
            {
                _saveGame.Level.Grid[y][midX + 4].SetBackgroundFeature("Grass");
                _saveGame.Level.Grid[y][midX + 4].SetFeature("Grass");
            }
            for (int y = midY - 5; y < midY + 5; y++)
            {
                _saveGame.Level.Grid[y][midX + 5].SetBackgroundFeature("Grass");
                _saveGame.Level.Grid[y][midX + 5].SetFeature("Grass");
            }
            for (int y = midY - 3; y < midY + 3; y++)
            {
                _saveGame.Level.Grid[y][midX + 6].SetBackgroundFeature("Grass");
                _saveGame.Level.Grid[y][midX + 6].SetFeature("Grass");
            }
            _saveGame.Level.Grid[midY - 6][midX].SetFeature("Rock");
            _saveGame.Level.Grid[midY - 6][midX - 1].SetFeature("Rock");
            _saveGame.Level.Grid[midY - 5][midX - 4].SetFeature("Rock");
            _saveGame.Level.Grid[midY - 4][midX - 5].SetFeature("Rock");
            _saveGame.Level.Grid[midY - 1][midX - 6].SetFeature("Rock");
            _saveGame.Level.Grid[midY][midX - 6].SetFeature("Rock");
            _saveGame.Level.Grid[midY + 3][midX - 5].SetFeature("Rock");
            _saveGame.Level.Grid[midY + 4][midX - 4].SetFeature("Rock");
            _saveGame.Level.Grid[midY + 5][midX - 1].SetFeature("Rock");
            _saveGame.Level.Grid[midY + 5][midX].SetFeature("Rock");
            _saveGame.Level.Grid[midY + 4][midX + 3].SetFeature("Rock");
            _saveGame.Level.Grid[midY + 3][midX + 4].SetFeature("Rock");
            _saveGame.Level.Grid[midY][midX + 5].SetFeature("Rock");
            _saveGame.Level.Grid[midY - 1][midX + 5].SetFeature("Rock");
            _saveGame.Level.Grid[midY - 4][midX + 4].SetFeature("Rock");
            _saveGame.Level.Grid[midY - 5][midX + 3].SetFeature("Rock");
        }

        private void MakeLake(int minX, int minY, int width, int height)
        {
            PerlinNoise perlinNoise = new PerlinNoise(Program.Rng.RandomBetween(0, int.MaxValue - 1));
            double widthDivisor = 1 / (double)width;
            double heightDivisor = 1 / (double)height;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    GridTile cPtr = _saveGame.Level.Grid[minY + y][minX + x];
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
                        cPtr.SetBackgroundFeature("Water");
                        cPtr.SetFeature("Water");
                    }
                    else if (rounded == 3)
                    {
                        cPtr.SetBackgroundFeature("Grass");
                        cPtr.SetFeature("Grass");
                    }
                }
            }
        }

        private void MakeTower(int left, int top, int width, int height, out int stairX, out int stairY)
        {
            int i;
            int y = top + height;
            int x = left + (width / 2);
            stairX = x;
            stairY = y;
            for (i = -2; i < 3; i++)
            {
                _saveGame.Level.Grid[y][x + i].SetFeature("WallPermBuilding");
                _saveGame.Level.Grid[y][x + i].TileFlags.Set(GridTile.PlayerMemorised | GridTile.SelfLit);
            }
            for (i = -4; i < 5; i++)
            {
                _saveGame.Level.Grid[y - 1][x + i].SetFeature("WallPermBuilding");
                _saveGame.Level.Grid[y - 1][x + i].TileFlags.Set(GridTile.PlayerMemorised | GridTile.SelfLit);
            }
            for (i = -5; i < 6; i++)
            {
                _saveGame.Level.Grid[y - 2][x + i].SetFeature("WallPermBuilding");
                _saveGame.Level.Grid[y - 2][x + i].TileFlags.Set(GridTile.PlayerMemorised | GridTile.SelfLit);
            }
            for (i = -6; i < 7; i++)
            {
                _saveGame.Level.Grid[y - 3][x + i].SetFeature("WallPermBuilding");
                _saveGame.Level.Grid[y - 3][x + i].TileFlags.Set(GridTile.PlayerMemorised | GridTile.SelfLit);
            }
            for (i = -6; i < 7; i++)
            {
                _saveGame.Level.Grid[y - 4][x + i].SetFeature("WallPermBuilding");
                _saveGame.Level.Grid[y - 4][x + i].TileFlags.Set(GridTile.PlayerMemorised | GridTile.SelfLit);
            }
            for (i = -7; i < 8; i++)
            {
                _saveGame.Level.Grid[y - 5][x + i].SetFeature("WallPermBuilding");
                _saveGame.Level.Grid[y - 5][x + i].TileFlags.Set(GridTile.PlayerMemorised | GridTile.SelfLit);
            }
            for (i = -7; i < 8; i++)
            {
                _saveGame.Level.Grid[y - 6][x + i].SetFeature("WallPermBuilding");
                _saveGame.Level.Grid[y - 6][x + i].TileFlags.Set(GridTile.PlayerMemorised | GridTile.SelfLit);
            }
            for (i = -7; i < 8; i++)
            {
                _saveGame.Level.Grid[y - 7][x + i].SetFeature("WallPermBuilding");
                _saveGame.Level.Grid[y - 7][x + i].TileFlags.Set(GridTile.PlayerMemorised | GridTile.SelfLit);
            }
            for (i = -7; i < 8; i++)
            {
                _saveGame.Level.Grid[y - 8][x + i].SetFeature("WallPermBuilding");
                _saveGame.Level.Grid[y - 8][x + i].TileFlags.Set(GridTile.PlayerMemorised | GridTile.SelfLit);
            }
            for (i = -7; i < 8; i++)
            {
                _saveGame.Level.Grid[y - 9][x + i].SetFeature("WallPermBuilding");
                _saveGame.Level.Grid[y - 9][x + i].TileFlags.Set(GridTile.PlayerMemorised | GridTile.SelfLit);
            }
            for (i = -6; i < 7; i++)
            {
                _saveGame.Level.Grid[y - 10][x + i].SetFeature("WallPermBuilding");
                _saveGame.Level.Grid[y - 10][x + i].TileFlags.Set(GridTile.PlayerMemorised | GridTile.SelfLit);
            }
            for (i = -6; i < 7; i++)
            {
                _saveGame.Level.Grid[y - 11][x + i].SetFeature("WallPermBuilding");
                _saveGame.Level.Grid[y - 11][x + i].TileFlags.Set(GridTile.PlayerMemorised | GridTile.SelfLit);
            }
            for (i = -5; i < 6; i++)
            {
                _saveGame.Level.Grid[y - 12][x + i].SetFeature("WallPermBuilding");
                _saveGame.Level.Grid[y - 12][x + i].TileFlags.Set(GridTile.PlayerMemorised | GridTile.SelfLit);
            }
            for (i = -4; i < 5; i++)
            {
                _saveGame.Level.Grid[y - 13][x + i].SetFeature("WallPermBuilding");
                _saveGame.Level.Grid[y - 13][x + i].TileFlags.Set(GridTile.PlayerMemorised | GridTile.SelfLit);
            }
            for (i = -2; i < 4; i++)
            {
                _saveGame.Level.Grid[y - 14][x + i].SetFeature("WallPermBuilding");
                _saveGame.Level.Grid[y - 14][x + i].TileFlags.Set(GridTile.PlayerMemorised | GridTile.SelfLit);
            }
            _saveGame.Level.Grid[y][x].SetFeature("UpStair");
            _saveGame.Level.Grid[y][x].TileFlags.Set(GridTile.PlayerMemorised | GridTile.SelfLit);
            for (i = -3; i < 4; i++)
            {
                if (_saveGame.Level.Grid[y + 1][x + i].FeatureType.Category == FloorTileTypeCategory.Tree)
                {
                    _saveGame.Level.Grid[y + 1][x + i].RevertToBackground();
                }
            }
            for (i = -2; i < 3; i++)
            {
                if (_saveGame.Level.Grid[y + 2][x + i].FeatureType.Category == FloorTileTypeCategory.Tree)
                {
                    _saveGame.Level.Grid[y + 2][x + i].RevertToBackground();
                }
            }
        }

        private void MakeTownCentre()
        {
            int xx = _saveGame.Level.CurWid / 2;
            int yy = _saveGame.Level.CurHgt / 2;
            switch (Program.Rng.DieRoll(12))
            {
                case 1:
                case 3:
                    _saveGame.Level.Grid[yy - 1][xx - 1].SetFeature("PathBase");
                    _saveGame.Level.Grid[yy][xx - 1].SetFeature("PathBase");
                    _saveGame.Level.Grid[yy + 1][xx - 1].SetFeature("PathBase");
                    _saveGame.Level.Grid[yy - 1][xx].SetFeature("PathBase");
                    _saveGame.Level.Grid[yy + 1][xx].SetFeature("PathBase");
                    _saveGame.Level.Grid[yy - 1][xx + 1].SetFeature("PathBase");
                    _saveGame.Level.Grid[yy][xx + 1].SetFeature("PathBase");
                    _saveGame.Level.Grid[yy + 1][xx + 1].SetFeature("PathBase");
                    switch (Program.Rng.DieRoll(6))
                    {
                        case 4:
                        case 1:
                            _saveGame.Level.Grid[yy][xx].RevertToBackground();
                            break;

                        case 2:
                            _saveGame.Level.Grid[yy][xx].SetFeature("Statue");
                            break;

                        default:
                            _saveGame.Level.Grid[yy][xx].SetFeature("Fountain");
                            break;
                    }
                    return;

                case 2:
                case 8:
                case 9:
                case 12:
                    int x = xx - 1;
                    if (Program.Rng.DieRoll(2) == 1)
                    {
                        x = xx + 1;
                    }
                    int y = yy - 1;
                    if (Program.Rng.DieRoll(2) == 1)
                    {
                        y = yy + 1;
                    }
                    _saveGame.Level.Grid[y][x].SetFeature("Signpost");
                    break;

                default:
                    return;
            }
        }

        private void MakeTownContents()
        {
            int x, n;
            int dummy = 0;
            GridTile cPtr;
            int[] rooms = new int[12];
            Program.Rng.UseFixed = true;
            Program.Rng.FixedSeed = _saveGame.CurTown.Seed;
            for (n = 0; n < 12; n++)
            {
                rooms[n] = n;
            }
            int y = _saveGame.Level.CurHgt / 2;
            for (x = 1; x < _saveGame.Level.CurWid - 1; x++)
            {
                _saveGame.Level.Grid[y][x].SetFeature("PathBase");
            }
            x = _saveGame.Level.CurWid / 2;
            for (y = 1; y < _saveGame.Level.CurHgt - 1; y++)
            {
                _saveGame.Level.Grid[y][x].SetFeature("PathBase");
            }
            for (y = 0; y < 4; y++)
            {
                for (x = 0; x < 4; x++)
                {
                    if (x == 1 || x == 2 || y == 1 || y == 2)
                    {
                        int k = Program.Rng.RandomLessThan(n);
                        BuildStore(_saveGame.CurTown.Stores[rooms[k]], y, x);
                        rooms[k] = rooms[--n];
                    }
                    else
                    {
                        switch (Program.Rng.DieRoll(10))
                        {
                            case 3:
                            case 7:
                            case 9:
                                break;

                            default:
                                if (_saveGame.CurTown.Char == 'K')
                                {
                                    BuildGraveyard(y, x);
                                }
                                else
                                {
                                    BuildField(y, x);
                                }
                                break;
                        }
                    }
                }
            }
            for (n = 0; n < Program.Rng.RandomBetween(1, 10) - 6; n++)
            {
                x = Program.Rng.RandomBetween(1, _saveGame.Level.CurWid - 2);
                y = Program.Rng.RandomBetween(1, _saveGame.Level.CurHgt - 2);
                cPtr = _saveGame.Level.Grid[y][x];
                if (cPtr.FeatureType.Name == cPtr.BackgroundFeature.Name)
                {
                    cPtr.SetFeature("Rock");
                    cPtr.TileFlags.Set(GridTile.PlayerMemorised);
                }
            }
            for (n = 0; n < Program.Rng.RandomBetween(5, 10); n++)
            {
                x = Program.Rng.RandomBetween(1, _saveGame.Level.CurWid - 2);
                y = Program.Rng.RandomBetween(1, _saveGame.Level.CurHgt - 2);
                cPtr = _saveGame.Level.Grid[y][x];
                if (cPtr.FeatureType.Name == cPtr.BackgroundFeature.Name)
                {
                    cPtr.SetFeature("Tree");
                    cPtr.TileFlags.Set(GridTile.PlayerMemorised);
                }
            }
            for (n = 0; n < Program.Rng.RandomBetween(5, 10); n++)
            {
                x = Program.Rng.RandomBetween(1, _saveGame.Level.CurWid - 2);
                y = Program.Rng.RandomBetween(1, _saveGame.Level.CurHgt - 2);
                cPtr = _saveGame.Level.Grid[y][x];
                if (cPtr.FeatureType.Name == cPtr.BackgroundFeature.Name)
                {
                    cPtr.SetFeature("Bush");
                    cPtr.TileFlags.Set(GridTile.PlayerMemorised);
                }
            }
            MakeTownCentre();
            x = _saveGame.Level.CurWid / 2;
            cPtr = _saveGame.Level.Grid[0][x];
            cPtr.SetFeature("PathBorderNS");
            cPtr.TileFlags.Set(GridTile.PlayerMemorised);
            x = _saveGame.Level.CurWid - 2;
            y = _saveGame.Level.CurHgt / 2;
            cPtr = _saveGame.Level.Grid[y][x + 1];
            cPtr.SetFeature("PathBorderEW");
            cPtr.TileFlags.Set(GridTile.PlayerMemorised);
            x = _saveGame.Level.CurWid / 2;
            y = _saveGame.Level.CurHgt - 2;
            cPtr = _saveGame.Level.Grid[y + 1][x];
            cPtr.SetFeature("PathBorderNS");
            cPtr.TileFlags.Set(GridTile.PlayerMemorised);
            x = 1;
            y = _saveGame.Level.CurHgt / 2;
            cPtr = _saveGame.Level.Grid[y][0];
            cPtr.SetFeature("PathBorderEW");
            cPtr.TileFlags.Set(GridTile.PlayerMemorised);
            while (dummy < SafeMaxAttempts)
            {
                dummy++;
                y = Program.Rng.RandomBetween(12, 29);
                x = Program.Rng.RandomBetween(17, 46);
                if (_saveGame.Level.GridOpenNoItemOrCreature(y, x))
                {
                    break;
                }
            }
            cPtr = _saveGame.Level.Grid[y][x];
            cPtr.SetFeature("DownStair");
            cPtr.TileFlags.Set(GridTile.PlayerMemorised);
            Program.Rng.UseFixed = false;
            switch (_saveGame.CameFrom)
            {
                case LevelStart.StartRandom:
                    NewPlayerSpot();
                    break;

                case LevelStart.StartStairs:
                    _saveGame.Player.MapY = y;
                    _saveGame.Player.MapX = x;
                    break;

                case LevelStart.StartWalk:
                    break;

                case LevelStart.StartHouse:
                    foreach (Store store in _saveGame.CurTown.Stores)
                    {
                        if (store.StoreType != StoreType.StoreHome)
                        {
                            continue;
                        }
                        _saveGame.Player.MapY = store.Y;
                        _saveGame.Player.MapX = store.X;
                    }
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void MakeTownWalls()
        {
            int x;
            int y;
            GridTile cPtr;
            for (x = 0; x < _saveGame.Level.CurWid; x++)
            {
                cPtr = _saveGame.Level.Grid[0][x];
                cPtr.SetFeature("TownWall");
                cPtr.TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                cPtr = _saveGame.Level.Grid[_saveGame.Level.CurHgt - 1][x];
                cPtr.SetFeature("TownWall");
                cPtr.TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            }
            for (y = 0; y < _saveGame.Level.CurHgt; y++)
            {
                cPtr = _saveGame.Level.Grid[y][0];
                cPtr.SetFeature("TownWall");
                cPtr.TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                cPtr = _saveGame.Level.Grid[y][_saveGame.Level.CurWid - 1];
                cPtr.SetFeature("TownWall");
                cPtr.TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            }
            _saveGame.Level.Grid[0][(_saveGame.Level.CurWid / 2) - 2].SetBackgroundFeature("InsideGatehouse");
            _saveGame.Level.Grid[0][(_saveGame.Level.CurWid / 2) - 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            _saveGame.Level.Grid[0][(_saveGame.Level.CurWid / 2) - 1].SetBackgroundFeature("InsideGatehouse");
            _saveGame.Level.Grid[0][(_saveGame.Level.CurWid / 2) - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            _saveGame.Level.Grid[0][(_saveGame.Level.CurWid / 2) + 1].SetBackgroundFeature("InsideGatehouse");
            _saveGame.Level.Grid[0][(_saveGame.Level.CurWid / 2) + 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            _saveGame.Level.Grid[0][(_saveGame.Level.CurWid / 2) + 2].SetBackgroundFeature("InsideGatehouse");
            _saveGame.Level.Grid[0][(_saveGame.Level.CurWid / 2) + 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            _saveGame.Level.Grid[1][(_saveGame.Level.CurWid / 2) - 2].SetBackgroundFeature("InsideGatehouse");
            _saveGame.Level.Grid[1][(_saveGame.Level.CurWid / 2) - 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            _saveGame.Level.Grid[1][(_saveGame.Level.CurWid / 2) - 1].SetBackgroundFeature("InsideGatehouse");
            _saveGame.Level.Grid[1][(_saveGame.Level.CurWid / 2) - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            _saveGame.Level.Grid[1][(_saveGame.Level.CurWid / 2) + 1].SetBackgroundFeature("InsideGatehouse");
            _saveGame.Level.Grid[1][(_saveGame.Level.CurWid / 2) + 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            _saveGame.Level.Grid[1][(_saveGame.Level.CurWid / 2) + 2].SetBackgroundFeature("InsideGatehouse");
            _saveGame.Level.Grid[1][(_saveGame.Level.CurWid / 2) + 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            _saveGame.Level.Grid[0][(_saveGame.Level.CurWid / 2) - 2].SetFeature("TownWall");
            _saveGame.Level.Grid[0][(_saveGame.Level.CurWid / 2) - 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            _saveGame.Level.Grid[0][(_saveGame.Level.CurWid / 2) - 1].SetFeature("TownWall");
            _saveGame.Level.Grid[0][(_saveGame.Level.CurWid / 2) - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            _saveGame.Level.Grid[0][_saveGame.Level.CurWid / 2].SetFeature("PathBorderNS");
            _saveGame.Level.Grid[0][_saveGame.Level.CurWid / 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            _saveGame.Level.Grid[0][(_saveGame.Level.CurWid / 2) + 1].SetFeature("TownWall");
            _saveGame.Level.Grid[0][(_saveGame.Level.CurWid / 2) + 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            _saveGame.Level.Grid[0][(_saveGame.Level.CurWid / 2) + 2].SetFeature("TownWall");
            _saveGame.Level.Grid[0][(_saveGame.Level.CurWid / 2) + 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            _saveGame.Level.Grid[1][(_saveGame.Level.CurWid / 2) - 2].SetFeature("TownWall");
            _saveGame.Level.Grid[1][(_saveGame.Level.CurWid / 2) - 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            _saveGame.Level.Grid[1][(_saveGame.Level.CurWid / 2) - 1].SetFeature("TownWall");
            _saveGame.Level.Grid[1][(_saveGame.Level.CurWid / 2) - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            _saveGame.Level.Grid[1][_saveGame.Level.CurWid / 2].SetFeature("PathBase");
            _saveGame.Level.Grid[1][_saveGame.Level.CurWid / 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            _saveGame.Level.Grid[1][(_saveGame.Level.CurWid / 2) + 1].SetFeature("TownWall");
            _saveGame.Level.Grid[1][(_saveGame.Level.CurWid / 2) + 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            _saveGame.Level.Grid[1][(_saveGame.Level.CurWid / 2) + 2].SetFeature("TownWall");
            _saveGame.Level.Grid[1][(_saveGame.Level.CurWid / 2) + 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            _saveGame.Level.Grid[_saveGame.Level.CurHgt - 1][(_saveGame.Level.CurWid / 2) - 2].SetBackgroundFeature("InsideGatehouse");
            _saveGame.Level.Grid[_saveGame.Level.CurHgt - 1][(_saveGame.Level.CurWid / 2) - 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            _saveGame.Level.Grid[_saveGame.Level.CurHgt - 1][(_saveGame.Level.CurWid / 2) - 1].SetBackgroundFeature("InsideGatehouse");
            _saveGame.Level.Grid[_saveGame.Level.CurHgt - 1][(_saveGame.Level.CurWid / 2) - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            _saveGame.Level.Grid[_saveGame.Level.CurHgt - 1][(_saveGame.Level.CurWid / 2) + 1].SetBackgroundFeature("InsideGatehouse");
            _saveGame.Level.Grid[_saveGame.Level.CurHgt - 1][(_saveGame.Level.CurWid / 2) + 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            _saveGame.Level.Grid[_saveGame.Level.CurHgt - 1][(_saveGame.Level.CurWid / 2) + 2].SetBackgroundFeature("InsideGatehouse");
            _saveGame.Level.Grid[_saveGame.Level.CurHgt - 1][(_saveGame.Level.CurWid / 2) + 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            _saveGame.Level.Grid[_saveGame.Level.CurHgt - 2][(_saveGame.Level.CurWid / 2) - 2].SetBackgroundFeature("InsideGatehouse");
            _saveGame.Level.Grid[_saveGame.Level.CurHgt - 2][(_saveGame.Level.CurWid / 2) - 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            _saveGame.Level.Grid[_saveGame.Level.CurHgt - 2][(_saveGame.Level.CurWid / 2) - 1].SetBackgroundFeature("InsideGatehouse");
            _saveGame.Level.Grid[_saveGame.Level.CurHgt - 2][(_saveGame.Level.CurWid / 2) - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            _saveGame.Level.Grid[_saveGame.Level.CurHgt - 2][(_saveGame.Level.CurWid / 2) + 1].SetBackgroundFeature("InsideGatehouse");
            _saveGame.Level.Grid[_saveGame.Level.CurHgt - 2][(_saveGame.Level.CurWid / 2) + 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            _saveGame.Level.Grid[_saveGame.Level.CurHgt - 2][(_saveGame.Level.CurWid / 2) + 2].SetBackgroundFeature("InsideGatehouse");
            _saveGame.Level.Grid[_saveGame.Level.CurHgt - 2][(_saveGame.Level.CurWid / 2) + 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            _saveGame.Level.Grid[_saveGame.Level.CurHgt - 1][(_saveGame.Level.CurWid / 2) - 2].SetFeature("TownWall");
            _saveGame.Level.Grid[_saveGame.Level.CurHgt - 1][(_saveGame.Level.CurWid / 2) - 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            _saveGame.Level.Grid[_saveGame.Level.CurHgt - 1][(_saveGame.Level.CurWid / 2) - 1].SetFeature("TownWall");
            _saveGame.Level.Grid[_saveGame.Level.CurHgt - 1][(_saveGame.Level.CurWid / 2) - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            _saveGame.Level.Grid[_saveGame.Level.CurHgt - 1][_saveGame.Level.CurWid / 2].SetFeature("PathBorderNS");
            _saveGame.Level.Grid[_saveGame.Level.CurHgt - 1][_saveGame.Level.CurWid / 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            _saveGame.Level.Grid[_saveGame.Level.CurHgt - 1][(_saveGame.Level.CurWid / 2) + 1].SetFeature("TownWall");
            _saveGame.Level.Grid[_saveGame.Level.CurHgt - 1][(_saveGame.Level.CurWid / 2) + 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            _saveGame.Level.Grid[_saveGame.Level.CurHgt - 1][(_saveGame.Level.CurWid / 2) + 2].SetFeature("TownWall");
            _saveGame.Level.Grid[_saveGame.Level.CurHgt - 1][(_saveGame.Level.CurWid / 2) + 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            _saveGame.Level.Grid[_saveGame.Level.CurHgt - 2][(_saveGame.Level.CurWid / 2) - 2].SetFeature("TownWall");
            _saveGame.Level.Grid[_saveGame.Level.CurHgt - 2][(_saveGame.Level.CurWid / 2) - 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            _saveGame.Level.Grid[_saveGame.Level.CurHgt - 2][(_saveGame.Level.CurWid / 2) - 1].SetFeature("TownWall");
            _saveGame.Level.Grid[_saveGame.Level.CurHgt - 2][(_saveGame.Level.CurWid / 2) - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            _saveGame.Level.Grid[_saveGame.Level.CurHgt - 2][_saveGame.Level.CurWid / 2].SetFeature("PathBase");
            _saveGame.Level.Grid[_saveGame.Level.CurHgt - 2][_saveGame.Level.CurWid / 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            _saveGame.Level.Grid[_saveGame.Level.CurHgt - 2][(_saveGame.Level.CurWid / 2) + 1].SetFeature("TownWall");
            _saveGame.Level.Grid[_saveGame.Level.CurHgt - 2][(_saveGame.Level.CurWid / 2) + 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            _saveGame.Level.Grid[_saveGame.Level.CurHgt - 2][(_saveGame.Level.CurWid / 2) + 2].SetFeature("TownWall");
            _saveGame.Level.Grid[_saveGame.Level.CurHgt - 2][(_saveGame.Level.CurWid / 2) + 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            _saveGame.Level.Grid[(_saveGame.Level.CurHgt / 2) - 2][0].SetBackgroundFeature("InsideGatehouse");
            _saveGame.Level.Grid[(_saveGame.Level.CurHgt / 2) - 2][0].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            _saveGame.Level.Grid[(_saveGame.Level.CurHgt / 2) - 1][0].SetBackgroundFeature("InsideGatehouse");
            _saveGame.Level.Grid[(_saveGame.Level.CurHgt / 2) - 1][0].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            _saveGame.Level.Grid[(_saveGame.Level.CurHgt / 2) + 1][0].SetBackgroundFeature("InsideGatehouse");
            _saveGame.Level.Grid[(_saveGame.Level.CurHgt / 2) + 1][0].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            _saveGame.Level.Grid[(_saveGame.Level.CurHgt / 2) + 2][0].SetBackgroundFeature("InsideGatehouse");
            _saveGame.Level.Grid[(_saveGame.Level.CurHgt / 2) + 2][0].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            _saveGame.Level.Grid[(_saveGame.Level.CurHgt / 2) - 2][1].SetBackgroundFeature("InsideGatehouse");
            _saveGame.Level.Grid[(_saveGame.Level.CurHgt / 2) - 2][1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            _saveGame.Level.Grid[(_saveGame.Level.CurHgt / 2) - 1][1].SetBackgroundFeature("InsideGatehouse");
            _saveGame.Level.Grid[(_saveGame.Level.CurHgt / 2) - 1][1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            _saveGame.Level.Grid[(_saveGame.Level.CurHgt / 2) + 1][1].SetBackgroundFeature("InsideGatehouse");
            _saveGame.Level.Grid[(_saveGame.Level.CurHgt / 2) + 1][1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            _saveGame.Level.Grid[(_saveGame.Level.CurHgt / 2) + 2][1].SetBackgroundFeature("InsideGatehouse");
            _saveGame.Level.Grid[(_saveGame.Level.CurHgt / 2) + 2][1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            _saveGame.Level.Grid[(_saveGame.Level.CurHgt / 2) - 2][0].SetFeature("TownWall");
            _saveGame.Level.Grid[(_saveGame.Level.CurHgt / 2) - 2][0].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            _saveGame.Level.Grid[(_saveGame.Level.CurHgt / 2) - 1][0].SetFeature("TownWall");
            _saveGame.Level.Grid[(_saveGame.Level.CurHgt / 2) - 1][0].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            _saveGame.Level.Grid[_saveGame.Level.CurHgt / 2][0].SetFeature("PathBorderEW");
            _saveGame.Level.Grid[_saveGame.Level.CurHgt / 2][0].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            _saveGame.Level.Grid[(_saveGame.Level.CurHgt / 2) + 1][0].SetFeature("TownWall");
            _saveGame.Level.Grid[(_saveGame.Level.CurHgt / 2) + 1][0].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            _saveGame.Level.Grid[(_saveGame.Level.CurHgt / 2) + 2][0].SetFeature("TownWall");
            _saveGame.Level.Grid[(_saveGame.Level.CurHgt / 2) + 2][0].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            _saveGame.Level.Grid[(_saveGame.Level.CurHgt / 2) - 2][1].SetFeature("TownWall");
            _saveGame.Level.Grid[(_saveGame.Level.CurHgt / 2) - 2][1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            _saveGame.Level.Grid[(_saveGame.Level.CurHgt / 2) - 1][1].SetFeature("TownWall");
            _saveGame.Level.Grid[(_saveGame.Level.CurHgt / 2) - 1][1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            _saveGame.Level.Grid[_saveGame.Level.CurHgt / 2][1].SetFeature("PathBase");
            _saveGame.Level.Grid[_saveGame.Level.CurHgt / 2][1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            _saveGame.Level.Grid[(_saveGame.Level.CurHgt / 2) + 1][1].SetFeature("TownWall");
            _saveGame.Level.Grid[(_saveGame.Level.CurHgt / 2) + 1][1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            _saveGame.Level.Grid[(_saveGame.Level.CurHgt / 2) + 2][1].SetFeature("TownWall");
            _saveGame.Level.Grid[(_saveGame.Level.CurHgt / 2) + 2][1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            _saveGame.Level.Grid[(_saveGame.Level.CurHgt / 2) - 2][_saveGame.Level.CurWid - 1].SetBackgroundFeature("InsideGatehouse");
            _saveGame.Level.Grid[(_saveGame.Level.CurHgt / 2) - 2][_saveGame.Level.CurWid - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            _saveGame.Level.Grid[(_saveGame.Level.CurHgt / 2) - 1][_saveGame.Level.CurWid - 1].SetBackgroundFeature("InsideGatehouse");
            _saveGame.Level.Grid[(_saveGame.Level.CurHgt / 2) - 1][_saveGame.Level.CurWid - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            _saveGame.Level.Grid[(_saveGame.Level.CurHgt / 2) + 1][_saveGame.Level.CurWid - 1].SetBackgroundFeature("InsideGatehouse");
            _saveGame.Level.Grid[(_saveGame.Level.CurHgt / 2) + 1][_saveGame.Level.CurWid - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            _saveGame.Level.Grid[(_saveGame.Level.CurHgt / 2) + 2][_saveGame.Level.CurWid - 1].SetBackgroundFeature("InsideGatehouse");
            _saveGame.Level.Grid[(_saveGame.Level.CurHgt / 2) + 2][_saveGame.Level.CurWid - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            _saveGame.Level.Grid[(_saveGame.Level.CurHgt / 2) - 2][_saveGame.Level.CurWid - 2].SetBackgroundFeature("InsideGatehouse");
            _saveGame.Level.Grid[(_saveGame.Level.CurHgt / 2) - 2][_saveGame.Level.CurWid - 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            _saveGame.Level.Grid[(_saveGame.Level.CurHgt / 2) - 1][_saveGame.Level.CurWid - 2].SetBackgroundFeature("InsideGatehouse");
            _saveGame.Level.Grid[(_saveGame.Level.CurHgt / 2) - 1][_saveGame.Level.CurWid - 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            _saveGame.Level.Grid[(_saveGame.Level.CurHgt / 2) + 1][_saveGame.Level.CurWid - 2].SetBackgroundFeature("InsideGatehouse");
            _saveGame.Level.Grid[(_saveGame.Level.CurHgt / 2) + 1][_saveGame.Level.CurWid - 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            _saveGame.Level.Grid[(_saveGame.Level.CurHgt / 2) + 2][_saveGame.Level.CurWid - 2].SetBackgroundFeature("InsideGatehouse");
            _saveGame.Level.Grid[(_saveGame.Level.CurHgt / 2) + 2][_saveGame.Level.CurWid - 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            _saveGame.Level.Grid[(_saveGame.Level.CurHgt / 2) - 2][_saveGame.Level.CurWid - 1].SetFeature("TownWall");
            _saveGame.Level.Grid[(_saveGame.Level.CurHgt / 2) - 2][_saveGame.Level.CurWid - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            _saveGame.Level.Grid[(_saveGame.Level.CurHgt / 2) - 1][_saveGame.Level.CurWid - 1].SetFeature("TownWall");
            _saveGame.Level.Grid[(_saveGame.Level.CurHgt / 2) - 1][_saveGame.Level.CurWid - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            _saveGame.Level.Grid[_saveGame.Level.CurHgt / 2][_saveGame.Level.CurWid - 1].SetFeature("PathBorderEW");
            _saveGame.Level.Grid[_saveGame.Level.CurHgt / 2][_saveGame.Level.CurWid - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            _saveGame.Level.Grid[(_saveGame.Level.CurHgt / 2) + 1][_saveGame.Level.CurWid - 1].SetFeature("TownWall");
            _saveGame.Level.Grid[(_saveGame.Level.CurHgt / 2) + 1][_saveGame.Level.CurWid - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            _saveGame.Level.Grid[(_saveGame.Level.CurHgt / 2) + 2][_saveGame.Level.CurWid - 1].SetFeature("TownWall");
            _saveGame.Level.Grid[(_saveGame.Level.CurHgt / 2) + 2][_saveGame.Level.CurWid - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            _saveGame.Level.Grid[(_saveGame.Level.CurHgt / 2) - 2][_saveGame.Level.CurWid - 2].SetFeature("TownWall");
            _saveGame.Level.Grid[(_saveGame.Level.CurHgt / 2) - 2][_saveGame.Level.CurWid - 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            _saveGame.Level.Grid[(_saveGame.Level.CurHgt / 2) - 1][_saveGame.Level.CurWid - 2].SetFeature("TownWall");
            _saveGame.Level.Grid[(_saveGame.Level.CurHgt / 2) - 1][_saveGame.Level.CurWid - 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            _saveGame.Level.Grid[_saveGame.Level.CurHgt / 2][_saveGame.Level.CurWid - 2].SetFeature("PathBase");
            _saveGame.Level.Grid[_saveGame.Level.CurHgt / 2][_saveGame.Level.CurWid - 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            _saveGame.Level.Grid[(_saveGame.Level.CurHgt / 2) + 1][_saveGame.Level.CurWid - 2].SetFeature("TownWall");
            _saveGame.Level.Grid[(_saveGame.Level.CurHgt / 2) + 1][_saveGame.Level.CurWid - 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            _saveGame.Level.Grid[(_saveGame.Level.CurHgt / 2) + 2][_saveGame.Level.CurWid - 2].SetFeature("TownWall");
            _saveGame.Level.Grid[(_saveGame.Level.CurHgt / 2) + 2][_saveGame.Level.CurWid - 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
        }

        private void MakeWildernessFeatures(int wildx, int wildy, out int stairX, out int stairY)
        {
            stairX = _saveGame.Level.CurWid / 2;
            stairY = _saveGame.Level.CurHgt / 2;
            if (wildx == 1 || wildx == 10 || wildy == 1 || wildy == 10)
            {
                return;
            }
            int dungeonX = 0;
            int dungeonY = 0;
            switch (Program.Rng.DieRoll(4))
            {
                case 1:
                    dungeonX = 0;
                    dungeonY = 0;
                    break;

                case 2:
                    dungeonX = _saveGame.Level.CurWid / 2;
                    dungeonY = 0;
                    break;

                case 3:
                    dungeonX = 0;
                    dungeonY = _saveGame.Level.CurHgt / 2;
                    break;

                case 4:
                    dungeonX = _saveGame.Level.CurWid / 2;
                    dungeonY = _saveGame.Level.CurHgt / 2;
                    break;
            }
            for (int offsetX = 0; offsetX < _saveGame.Level.CurWid - 1; offsetX += _saveGame.Level.CurWid / 2)
            {
                for (int offsetY = 0; offsetY < _saveGame.Level.CurHgt - 1; offsetY += _saveGame.Level.CurHgt / 2)
                {
                    if (offsetX == dungeonX && offsetY == dungeonY)
                    {
                        if (_saveGame.Wilderness[wildy][wildx].Dungeon != null)
                        {
                            if (_saveGame.Wilderness[wildy][wildx].Dungeon.Tower)
                            {
                                MakeTower(offsetX + 4, offsetY + 4, (_saveGame.Level.CurWid / 2) - 8, (_saveGame.Level.CurHgt / 2) - 8, out int x, out int y);
                                stairX = x;
                                stairY = y;
                            }
                            else
                            {
                                MakeDungeonEntrance(offsetX + 4, offsetY + 4, (_saveGame.Level.CurWid / 2) - 8, (_saveGame.Level.CurHgt / 2) - 8, out int x, out int y);
                                stairX = x;
                                stairY = y;
                            }
                        }
                    }
                    else
                    {
                        switch (Program.Rng.DieRoll(30))
                        {
                            case 7:
                            case 22:
                                MakeLake(offsetX + 4, offsetY + 4, (_saveGame.Level.CurWid / 2) - 8, (_saveGame.Level.CurHgt / 2) - 8);
                                break;

                            case 15:
                                MakeHenge(offsetX + 4, offsetY + 4, (_saveGame.Level.CurWid / 2) - 8, (_saveGame.Level.CurHgt / 2) - 8);
                                break;
                        }
                    }
                }
            }
        }

        private void MakeWildernessPaths(int wildx, int wildy)
        {
            int x;
            int y;

            int midX = _saveGame.Level.CurWid / 2;
            int midY = _saveGame.Level.CurHgt / 2;
            if (_saveGame.Wilderness[wildy][wildx].RoadMap == 0)
            {
                return;
            }
            _saveGame.Level.Grid[midY - 1][midX - 1].SetFeature("Grass");
            _saveGame.Level.Grid[midY - 1][midX].SetFeature("Grass");
            _saveGame.Level.Grid[midY - 1][midX + 1].SetFeature("Grass");
            _saveGame.Level.Grid[midY][midX - 1].SetFeature("Grass");
            _saveGame.Level.Grid[midY][midX].SetFeature("PathBase");
            _saveGame.Level.Grid[midY][midX + 1].SetFeature("Grass");
            _saveGame.Level.Grid[midY + 1][midX - 1].SetFeature("Grass");
            _saveGame.Level.Grid[midY + 1][midX].SetFeature("Grass");
            _saveGame.Level.Grid[midY + 1][midX + 1].SetFeature("Grass");
            if ((_saveGame.Wilderness[wildy][wildx].RoadMap & Constants.RoadUp) != 0)
            {
                x = 0;
                _saveGame.Level.Grid[0][midX].SetFeature("PathBorderNS");
                _saveGame.Level.Grid[1][midX].SetFeature("PathBase");
                _saveGame.Level.Grid[midY - 1][midX].SetFeature("PathBase");
                for (y = 2; y < midY - 1; y++)
                {
                    x += Program.Rng.RandomBetween(-2, 2) / 2;
                    if (x > midY - 1 - y)
                    {
                        x = midY - 1 - y;
                    }
                    if (x < -(midY - 1 - y))
                    {
                        x = -(midY - 1 - y);
                    }
                    if (!_saveGame.Level.Grid[y][midX - 1 + x].FeatureType.Name.StartsWith("WildPath"))
                    {
                        _saveGame.Level.Grid[y][midX - 1 + x].SetFeature("Grass");
                    }
                    _saveGame.Level.Grid[y][midX + x].SetFeature("WildPathNS");
                    if (!_saveGame.Level.Grid[y][midX + 1 + x].FeatureType.Name.StartsWith("WildPath"))
                    {
                        _saveGame.Level.Grid[y][midX + 1 + x].SetFeature("Grass");
                    }
                }
            }
            if ((_saveGame.Wilderness[wildy][wildx].RoadMap & Constants.RoadDown) != 0)
            {
                x = 0;
                _saveGame.Level.Grid[_saveGame.Level.CurHgt - 1][midX].SetFeature("PathBorderNS");
                _saveGame.Level.Grid[_saveGame.Level.CurHgt - 2][midX].SetFeature("PathBase");
                _saveGame.Level.Grid[midY + 1][midX].SetFeature("PathBase");
                for (y = _saveGame.Level.CurHgt - 3; y > midY + 1; y--)
                {
                    x += Program.Rng.RandomBetween(-2, 2) / 2;
                    if (x > y - (midY + 1))
                    {
                        x = y - (midY + 1);
                    }
                    if (x < -(y - (midY + 1)))
                    {
                        x = -(y - (midY + 1));
                    }
                    if (!_saveGame.Level.Grid[y][midX - 1 + x].FeatureType.Name.StartsWith("WildPath"))
                    {
                        _saveGame.Level.Grid[y][midX - 1 + x].SetFeature("Grass");
                    }
                    _saveGame.Level.Grid[y][midX + x].SetFeature("WildPathNS");
                    if (!_saveGame.Level.Grid[y][midX + 1 + x].FeatureType.Name.StartsWith("WildPath"))
                    {
                        _saveGame.Level.Grid[y][midX + 1 + x].SetFeature("Grass");
                    }
                }
            }
            if ((_saveGame.Wilderness[wildy][wildx].RoadMap & Constants.RoadLeft) != 0)
            {
                y = 0;
                _saveGame.Level.Grid[midY][0].SetFeature("PathBorderEW");
                _saveGame.Level.Grid[midY][1].SetFeature("PathBase");
                _saveGame.Level.Grid[midY][midX - 1].SetFeature("PathBase");
                for (x = 2; x < midX - 1; x++)
                {
                    y += Program.Rng.RandomBetween(-2, 2) / 2;
                    if (y > midX - 1 - x)
                    {
                        y = midX - 1 - x;
                    }
                    if (y < -(midX - 1 - x))
                    {
                        y = -(midX - 1 - x);
                    }
                    if (!_saveGame.Level.Grid[midY - 1 + y][x].FeatureType.Name.StartsWith("WildPath"))
                    {
                        _saveGame.Level.Grid[midY - 1 + y][x].SetFeature("Grass");
                    }
                    _saveGame.Level.Grid[midY + y][x].SetFeature("WildPathEW");
                    if (!_saveGame.Level.Grid[midY + 1 + y][x].FeatureType.Name.StartsWith("WildPath"))
                    {
                        _saveGame.Level.Grid[midY + 1 + y][x].SetFeature("Grass");
                    }
                }
            }
            if ((_saveGame.Wilderness[wildy][wildx].RoadMap & Constants.RoadRight) != 0)
            {
                y = 0;
                _saveGame.Level.Grid[midY][_saveGame.Level.CurWid - 1].SetFeature("PathBorderEW");
                _saveGame.Level.Grid[midY][_saveGame.Level.CurWid - 2].SetFeature("PathBase");
                _saveGame.Level.Grid[midY][midX + 1].SetFeature("PathBase");
                for (x = _saveGame.Level.CurWid - 3; x > midX + 1; x--)
                {
                    y += Program.Rng.RandomBetween(-2, 2) / 2;
                    if (y > x - (midX + 1))
                    {
                        y = x - (midX + 1);
                    }
                    if (y < -(x - (midX + 1)))
                    {
                        y = -(x - (midX + 1));
                    }
                    if (!_saveGame.Level.Grid[midY - 1 + y][x].FeatureType.Name.StartsWith("WildPath"))
                    {
                        _saveGame.Level.Grid[midY - 1 + y][x].SetFeature("Grass");
                    }
                    _saveGame.Level.Grid[midY + y][x].SetFeature("WildPathEW");
                    if (!_saveGame.Level.Grid[midY + 1 + y][x].FeatureType.Name.StartsWith("WildPath"))
                    {
                        _saveGame.Level.Grid[midY + 1 + y][x].SetFeature("Grass");
                    }
                }
            }
        }

        private void MakeWildernessWalls(int wildX, int wildY)
        {
            Island wilderness = _saveGame.Wilderness;
            int height = _saveGame.Level.CurHgt;
            int width = _saveGame.Level.CurWid;
            if (wilderness[wildY - 1][wildX].Town != null)
            {
                for (int x = 0; x < width; x++)
                {
                    _saveGame.Level.Grid[0][x].SetFeature("TownWall");
                    _saveGame.Level.Grid[0][x].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                }
                _saveGame.Level.Grid[0][(width / 2) - 2].SetBackgroundFeature("InsideGatehouse");
                _saveGame.Level.Grid[0][(width / 2) - 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[0][(width / 2) - 1].SetBackgroundFeature("InsideGatehouse");
                _saveGame.Level.Grid[0][(width / 2) - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[0][(width / 2) + 1].SetBackgroundFeature("InsideGatehouse");
                _saveGame.Level.Grid[0][(width / 2) + 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[0][(width / 2) + 2].SetBackgroundFeature("InsideGatehouse");
                _saveGame.Level.Grid[0][(width / 2) + 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[1][(width / 2) - 2].SetBackgroundFeature("InsideGatehouse");
                _saveGame.Level.Grid[1][(width / 2) - 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[1][(width / 2) - 1].SetBackgroundFeature("InsideGatehouse");
                _saveGame.Level.Grid[1][(width / 2) - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[1][(width / 2) + 1].SetBackgroundFeature("InsideGatehouse");
                _saveGame.Level.Grid[1][(width / 2) + 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[1][(width / 2) + 2].SetBackgroundFeature("InsideGatehouse");
                _saveGame.Level.Grid[1][(width / 2) + 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[0][(width / 2) - 2].SetFeature("TownWall");
                _saveGame.Level.Grid[0][(width / 2) - 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[0][(width / 2) - 1].SetFeature("TownWall");
                _saveGame.Level.Grid[0][(width / 2) - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[0][width / 2].SetFeature("PathBorderNS");
                _saveGame.Level.Grid[0][width / 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[0][(width / 2) + 1].SetFeature("TownWall");
                _saveGame.Level.Grid[0][(width / 2) + 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[0][(width / 2) + 2].SetFeature("TownWall");
                _saveGame.Level.Grid[0][(width / 2) + 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[1][(width / 2) - 2].SetFeature("TownWall");
                _saveGame.Level.Grid[1][(width / 2) - 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[1][(width / 2) - 1].SetFeature("TownWall");
                _saveGame.Level.Grid[1][(width / 2) - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[1][width / 2].SetFeature("PathBase");
                _saveGame.Level.Grid[1][width / 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[1][(width / 2) + 1].SetFeature("TownWall");
                _saveGame.Level.Grid[1][(width / 2) + 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[1][(width / 2) + 2].SetFeature("TownWall");
                _saveGame.Level.Grid[1][(width / 2) + 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            }
            if (wilderness[wildY + 1][wildX].Town != null)
            {
                for (int x = 0; x < width; x++)
                {
                    _saveGame.Level.Grid[height - 1][x].SetFeature("TownWall");
                    _saveGame.Level.Grid[height - 1][x].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                }
                _saveGame.Level.Grid[height - 1][(width / 2) - 2].SetBackgroundFeature("InsideGatehouse");
                _saveGame.Level.Grid[height - 1][(width / 2) - 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[height - 1][(width / 2) - 1].SetBackgroundFeature("InsideGatehouse");
                _saveGame.Level.Grid[height - 1][(width / 2) - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[height - 1][(width / 2) + 1].SetBackgroundFeature("InsideGatehouse");
                _saveGame.Level.Grid[height - 1][(width / 2) + 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[height - 1][(width / 2) + 2].SetBackgroundFeature("InsideGatehouse");
                _saveGame.Level.Grid[height - 1][(width / 2) + 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[height - 2][(width / 2) - 2].SetBackgroundFeature("InsideGatehouse");
                _saveGame.Level.Grid[height - 2][(width / 2) - 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[height - 2][(width / 2) - 1].SetBackgroundFeature("InsideGatehouse");
                _saveGame.Level.Grid[height - 2][(width / 2) - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[height - 2][(width / 2) + 1].SetBackgroundFeature("InsideGatehouse");
                _saveGame.Level.Grid[height - 2][(width / 2) + 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[height - 2][(width / 2) + 2].SetBackgroundFeature("InsideGatehouse");
                _saveGame.Level.Grid[height - 2][(width / 2) + 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[height - 1][(width / 2) - 2].SetFeature("TownWall");
                _saveGame.Level.Grid[height - 1][(width / 2) - 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[height - 1][(width / 2) - 1].SetFeature("TownWall");
                _saveGame.Level.Grid[height - 1][(width / 2) - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[height - 1][width / 2].SetFeature("PathBorderNS");
                _saveGame.Level.Grid[height - 1][width / 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[height - 1][(width / 2) + 1].SetFeature("TownWall");
                _saveGame.Level.Grid[height - 1][(width / 2) + 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[height - 1][(width / 2) + 2].SetFeature("TownWall");
                _saveGame.Level.Grid[height - 1][(width / 2) + 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[height - 2][(width / 2) - 2].SetFeature("TownWall");
                _saveGame.Level.Grid[height - 2][(width / 2) - 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[height - 2][(width / 2) - 1].SetFeature("TownWall");
                _saveGame.Level.Grid[height - 2][(width / 2) - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[height - 2][width / 2].SetFeature("PathBase");
                _saveGame.Level.Grid[height - 2][width / 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[height - 2][(width / 2) + 1].SetFeature("TownWall");
                _saveGame.Level.Grid[height - 2][(width / 2) + 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[height - 2][(width / 2) + 2].SetFeature("TownWall");
                _saveGame.Level.Grid[height - 2][(width / 2) + 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            }
            if (wilderness[wildY][wildX - 1].Town != null)
            {
                for (int y = 0; y < height; y++)
                {
                    _saveGame.Level.Grid[y][0].SetFeature("TownWall");
                    _saveGame.Level.Grid[y][0].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                }
                _saveGame.Level.Grid[(height / 2) - 2][0].SetBackgroundFeature("InsideGatehouse");
                _saveGame.Level.Grid[(height / 2) - 2][0].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[(height / 2) - 1][0].SetBackgroundFeature("InsideGatehouse");
                _saveGame.Level.Grid[(height / 2) - 1][0].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[(height / 2) + 1][0].SetBackgroundFeature("InsideGatehouse");
                _saveGame.Level.Grid[(height / 2) + 1][0].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[(height / 2) + 2][0].SetBackgroundFeature("InsideGatehouse");
                _saveGame.Level.Grid[(height / 2) + 2][0].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[(height / 2) - 2][1].SetBackgroundFeature("InsideGatehouse");
                _saveGame.Level.Grid[(height / 2) - 2][1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[(height / 2) - 1][1].SetBackgroundFeature("InsideGatehouse");
                _saveGame.Level.Grid[(height / 2) - 1][1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[(height / 2) + 1][1].SetBackgroundFeature("InsideGatehouse");
                _saveGame.Level.Grid[(height / 2) + 1][1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[(height / 2) + 2][1].SetBackgroundFeature("InsideGatehouse");
                _saveGame.Level.Grid[(height / 2) + 2][1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[(height / 2) - 2][0].SetFeature("TownWall");
                _saveGame.Level.Grid[(height / 2) - 2][0].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[(height / 2) - 1][0].SetFeature("TownWall");
                _saveGame.Level.Grid[(height / 2) - 1][0].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[height / 2][0].SetFeature("PathBorderEW");
                _saveGame.Level.Grid[height / 2][0].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[(height / 2) + 1][0].SetFeature("TownWall");
                _saveGame.Level.Grid[(height / 2) + 1][0].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[(height / 2) + 2][0].SetFeature("TownWall");
                _saveGame.Level.Grid[(height / 2) + 2][0].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[(height / 2) - 2][1].SetFeature("TownWall");
                _saveGame.Level.Grid[(height / 2) - 2][1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[(height / 2) - 1][1].SetFeature("TownWall");
                _saveGame.Level.Grid[(height / 2) - 1][1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[height / 2][1].SetFeature("PathBase");
                _saveGame.Level.Grid[height / 2][1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[(height / 2) + 1][1].SetFeature("TownWall");
                _saveGame.Level.Grid[(height / 2) + 1][1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[(height / 2) + 2][1].SetFeature("TownWall");
                _saveGame.Level.Grid[(height / 2) + 2][1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            }
            if (wilderness[wildY][wildX + 1].Town != null)
            {
                for (int y = 0; y < height; y++)
                {
                    _saveGame.Level.Grid[y][width - 1].SetFeature("TownWall");
                    _saveGame.Level.Grid[y][width - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                }
                _saveGame.Level.Grid[(height / 2) - 2][width - 1].SetBackgroundFeature("InsideGatehouse");
                _saveGame.Level.Grid[(height / 2) - 2][width - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[(height / 2) - 1][width - 1].SetBackgroundFeature("InsideGatehouse");
                _saveGame.Level.Grid[(height / 2) - 1][width - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[(height / 2) + 1][width - 1].SetBackgroundFeature("InsideGatehouse");
                _saveGame.Level.Grid[(height / 2) + 1][width - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[(height / 2) + 2][width - 1].SetBackgroundFeature("InsideGatehouse");
                _saveGame.Level.Grid[(height / 2) + 2][width - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[(height / 2) - 2][width - 2].SetBackgroundFeature("InsideGatehouse");
                _saveGame.Level.Grid[(height / 2) - 2][width - 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[(height / 2) - 1][width - 2].SetBackgroundFeature("InsideGatehouse");
                _saveGame.Level.Grid[(height / 2) - 1][width - 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[(height / 2) + 1][width - 2].SetBackgroundFeature("InsideGatehouse");
                _saveGame.Level.Grid[(height / 2) + 1][width - 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[(height / 2) + 2][width - 2].SetBackgroundFeature("InsideGatehouse");
                _saveGame.Level.Grid[(height / 2) + 2][width - 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[(height / 2) - 2][width - 1].SetFeature("TownWall");
                _saveGame.Level.Grid[(height / 2) - 2][width - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[(height / 2) - 1][width - 1].SetFeature("TownWall");
                _saveGame.Level.Grid[(height / 2) - 1][width - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[height / 2][width - 1].SetFeature("PathBorderEW");
                _saveGame.Level.Grid[height / 2][width - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[(height / 2) + 1][width - 1].SetFeature("TownWall");
                _saveGame.Level.Grid[(height / 2) + 1][width - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[(height / 2) + 2][width - 1].SetFeature("TownWall");
                _saveGame.Level.Grid[(height / 2) + 2][width - 1].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[(height / 2) - 2][width - 2].SetFeature("TownWall");
                _saveGame.Level.Grid[(height / 2) - 2][width - 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[(height / 2) - 1][width - 2].SetFeature("TownWall");
                _saveGame.Level.Grid[(height / 2) - 1][width - 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[height / 2][width - 2].SetFeature("PathBase");
                _saveGame.Level.Grid[height / 2][width - 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[(height / 2) + 1][width - 2].SetFeature("TownWall");
                _saveGame.Level.Grid[(height / 2) + 1][width - 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
                _saveGame.Level.Grid[(height / 2) + 2][width - 2].SetFeature("TownWall");
                _saveGame.Level.Grid[(height / 2) + 2][width - 2].TileFlags.Set(GridTile.SelfLit | GridTile.PlayerMemorised);
            }
        }

        private bool NewPlayerSpot()
        {
            int y = 0;
            int x = 0;
            int maxAttempts = 5000;
            while (maxAttempts-- != 0)
            {
                y = Program.Rng.RandomBetween(1, _saveGame.Level.CurHgt - 2);
                x = Program.Rng.RandomBetween(1, _saveGame.Level.CurWid - 2);
                if (!_saveGame.Level.GridOpenNoItemOrCreature(y, x))
                {
                    continue;
                }
                if (_saveGame.Level.Grid[y][x].TileFlags.IsSet(GridTile.InVault))
                {
                    continue;
                }
                break;
            }
            if (maxAttempts < 1)
            {
                return false;
            }
            _saveGame.Player.MapY = y;
            _saveGame.Player.MapX = x;
            return true;
        }

        private int NextToCorr(int y1, int x1)
        {
            int k = 0;
            for (int i = 0; i < 4; i++)
            {
                int y = y1 + _saveGame.Level.OrderedDirectionYOffset[i];
                int x = x1 + _saveGame.Level.OrderedDirectionXOffset[i];
                if (!_saveGame.Level.GridPassable(y, x))
                {
                    continue;
                }
                GridTile cPtr = _saveGame.Level.Grid[y][x];
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

        private int NextToWalls(int y, int x)
        {
            int k = 0;
            if (_saveGame.Level.Grid[y + 1][x].FeatureType.IsWall)
            {
                k++;
            }
            if (_saveGame.Level.Grid[y - 1][x].FeatureType.IsWall)
            {
                k++;
            }
            if (_saveGame.Level.Grid[y][x + 1].FeatureType.IsWall)
            {
                k++;
            }
            if (_saveGame.Level.Grid[y][x - 1].FeatureType.IsWall)
            {
                k++;
            }
            return k;
        }

        private void PlaceRandomDoor(int y, int x)
        {
            GridTile cPtr = _saveGame.Level.Grid[y][x];
            int tmp = Program.Rng.RandomLessThan(1000);
            if (tmp < 300)
            {
                cPtr.SetFeature("OpenDoor");
            }
            else if (tmp < 400)
            {
                cPtr.SetFeature("BrokenDoor");
            }
            else if (tmp < 600)
            {
                cPtr.SetFeature("SecretDoor");
            }
            else if (tmp < 900)
            {
                cPtr.SetFeature("LockedDoor0");
            }
            else if (tmp < 999)
            {
                cPtr.SetFeature($"LockedDoor{Program.Rng.DieRoll(7)}");
            }
            else
            {
                cPtr.SetFeature($"JammedDoor{Program.Rng.RandomLessThan(8)}");
            }
        }

        private void PlaceRubble(int y, int x)
        {
            GridTile cPtr = _saveGame.Level.Grid[y][x];
            cPtr.SetFeature("Rubble");
        }

        private bool PossibleDoorway(int y, int x)
        {
            if (NextToCorr(y, x) >= 2)
            {
                if (_saveGame.Level.Grid[y - 1][x].FeatureType.IsWall &&
                    _saveGame.Level.Grid[y + 1][x].FeatureType.IsWall)
                {
                    return true;
                }
                if (_saveGame.Level.Grid[y][x - 1].FeatureType.IsWall &&
                    _saveGame.Level.Grid[y][x + 1].FeatureType.IsWall)
                {
                    return true;
                }
            }
            return false;
        }

        private void RandDir(out int rdir, out int cdir)
        {
            int i = Program.Rng.RandomLessThan(4);
            rdir = _saveGame.Level.OrderedDirectionYOffset[i];
            cdir = _saveGame.Level.OrderedDirectionXOffset[i];
        }

        private void ResolvePaths()
        {
            for (int x = 1; x < _saveGame.Level.CurWid - 1; x++)
            {
                for (int y = 1; y < _saveGame.Level.CurHgt - 1; y++)
                {
                    if (_saveGame.Level.Grid[y][x].FeatureType.Name != "PathBase")
                    {
                        continue;
                    }
                    int map = 0;
                    if (_saveGame.Level.Grid[y - 1][x].FeatureType.Name.StartsWith("Path"))
                    {
                        map++;
                    }
                    if (_saveGame.Level.Grid[y][x + 1].FeatureType.Name.StartsWith("Path"))
                    {
                        map += 2;
                    }
                    if (_saveGame.Level.Grid[y + 1][x].FeatureType.Name.StartsWith("Path"))
                    {
                        map += 4;
                    }
                    if (_saveGame.Level.Grid[y][x - 1].FeatureType.Name.StartsWith("Path"))
                    {
                        map += 8;
                    }
                    switch (map)
                    {
                        case 1:
                        case 4:
                        case 5:
                            _saveGame.Level.Grid[y][x].SetFeature("PathNS");
                            break;

                        case 2:
                        case 8:
                        case 10:
                            _saveGame.Level.Grid[y][x].SetFeature("PathEW");
                            break;

                        default:
                            _saveGame.Level.Grid[y][x].SetFeature("PathJunction");
                            break;
                    }
                }
            }
        }

        private bool RoomBuild(int y0, int x0, int typ)
        {
            VaultFactory vaultFactory = new VaultFactory(_saveGame);
            if (_saveGame.Difficulty < _room[typ].Level)
            {
                return false;
            }
            if (_dun.Crowded && (typ == 5 || typ == 6))
            {
                return false;
            }
            int y1 = y0 + _room[typ].Dy1;
            int y2 = y0 + _room[typ].Dy2;
            int x1 = x0 + _room[typ].Dx1;
            int x2 = x0 + _room[typ].Dx2;
            if (y1 < 0 || y2 >= _dun.RowRooms)
            {
                return false;
            }
            if (x1 < 0 || x2 >= _dun.ColRooms)
            {
                return false;
            }
            int y;
            int x;
            for (y = y1; y <= y2; y++)
            {
                for (x = x1; x <= x2; x++)
                {
                    if (_dun.RoomMap[y][x])
                    {
                        return false;
                    }
                }
            }
            y = (y1 + y2 + 1) * _blockHgt / 2;
            x = (x1 + x2 + 1) * _blockWid / 2;
            switch (typ)
            {
                case 8:
                    vaultFactory.BuildType8(y, x);
                    break;

                case 7:
                    vaultFactory.BuildType7(y, x);
                    break;

                case 6:
                    vaultFactory.BuildType6(y, x);
                    break;

                case 5:
                    vaultFactory.BuildType5(y, x);
                    break;

                case 4:
                    vaultFactory.BuildType4(y, x);
                    break;

                case 3:
                    vaultFactory.BuildType3(y, x);
                    break;

                case 2:
                    vaultFactory.BuildType2(y, x);
                    break;

                case 1:
                    vaultFactory.BuildType1(y, x);
                    break;

                default:
                    return false;
            }
            if (_dun.CentN < CentMax)
            {
                _dun.Cent[_dun.CentN].Y = y;
                _dun.Cent[_dun.CentN].X = x;
                _dun.CentN++;
            }
            for (y = y1; y <= y2; y++)
            {
                for (x = x1; x <= x2; x++)
                {
                    _dun.RoomMap[y][x] = true;
                }
            }
            if (typ == 5 || typ == 6)
            {
                _dun.Crowded = true;
            }
            return true;
        }

        private void TownGen()
        {
            int i, y, x;
            GridTile cPtr;
            for (y = 0; y < _saveGame.Level.CurHgt; y++)
            {
                for (x = 0; x < _saveGame.Level.CurWid; x++)
                {
                    cPtr = _saveGame.Level.Grid[y][x];
                    cPtr.RevertToBackground();
                }
            }
            MakeTownWalls();
            MakeCornerTowers(_saveGame.Player.WildernessX, _saveGame.Player.WildernessY);
            MakeTownContents();
            ResolvePaths();
            if (_saveGame.Player.GameTime.IsLight)
            {
                for (y = 0; y < _saveGame.Level.CurHgt; y++)
                {
                    for (x = 0; x < _saveGame.Level.CurWid; x++)
                    {
                        cPtr = _saveGame.Level.Grid[y][x];
                        cPtr.TileFlags.Set(GridTile.SelfLit);
                        cPtr.TileFlags.Set(GridTile.PlayerMemorised);
                    }
                }
                for (i = 0; i < Constants.MinMAllocTd; i++)
                {
                    _saveGame.Level.Monsters.AllocMonster(3, true);
                }
            }
            else
            {
                for (i = 0; i < Constants.MinMAllocTn; i++)
                {
                    _saveGame.Level.Monsters.AllocMonster(3, true);
                }
            }
        }

        private void TryDoor(int y, int x)
        {
            if (!_saveGame.Level.InBounds(y, x))
            {
                return;
            }
            if (_saveGame.Level.Grid[y][x].FeatureType.IsWall)
            {
                return;
            }
            if (_saveGame.Level.Grid[y][x].TileFlags.IsSet(GridTile.InRoom))
            {
                return;
            }
            if (Program.Rng.RandomLessThan(100) < _dunTunJct && PossibleDoorway(y, x))
            {
                PlaceRandomDoor(y, x);
            }
        }

        private bool UndergroundGen()
        {
            int i;
            int k;
            _saveGame.MonsterRaces.ResetGuardians();
            if (_saveGame.Quests.IsQuest(_saveGame.CurrentDepth))
            {
                _saveGame.MonsterRaces[_saveGame.Quests.GetQuestMonster()].Flags1 |=
                    MonsterFlag1.Guardian;
            }
            if (Program.Rng.PercentileRoll(4) && !_saveGame.CurDungeon.Tower)
            {
                MakeCavernLevel();
            }
            else
            {
                MakeDungeonLevel();
            }
            AllocStairs("DownStair", Program.Rng.RandomBetween(3, 4), 3);
            AllocStairs("UpStair", Program.Rng.RandomBetween(1, 2), 3);
            if (!NewPlayerSpot())
            {
                return false;
            }
            k = _saveGame.Difficulty / 3;
            if (k > 10)
            {
                k = 10;
            }
            if (k < 2)
            {
                k = 2;
            }
            if (_saveGame.Quests.IsQuest(_saveGame.CurrentDepth))
            {
                int rIdx = _saveGame.Quests.GetQuestMonster();
                int qIdx = _saveGame.Quests.GetQuestNumber();
                while (_saveGame.MonsterRaces[rIdx].CurNum < (_saveGame.Quests[qIdx].ToKill - _saveGame.Quests[qIdx].Killed))
                {
                    _saveGame.Level.PutQuestMonster(_saveGame.Quests[qIdx].RIdx);
                }
            }
            i = Constants.MinMAllocLevel;
            if (_saveGame.Level.CurHgt < Level.MaxHgt || _saveGame.Level.CurWid < Level.MaxWid)
            {
                int smallTester = i;
                i = i * _saveGame.Level.CurHgt / Level.MaxHgt;
                i = i * _saveGame.Level.CurWid / Level.MaxWid;
                i++;
                if (i > smallTester)
                {
                    i = smallTester;
                }
            }
            i += Program.Rng.DieRoll(8);
            for (i += k; i > 0; i--)
            {
                _saveGame.Level.Monsters.AllocMonster(0, true);
            }
            AllocObject(_allocSetBoth, _allocTypTrap, Program.Rng.DieRoll(k));
            AllocObject(_allocSetCorr, _allocTypRubble, Program.Rng.DieRoll(k));
            AllocObject(_allocSetRoom, _allocTypObject, Program.Rng.RandomNormal(_dunAmtRoom, 3));
            AllocObject(_allocSetBoth, _allocTypObject, Program.Rng.RandomNormal(_dunAmtItem, 3));
            AllocObject(_allocSetBoth, _allocTypGold, Program.Rng.RandomNormal(_dunAmtGold, 3));
            return true;
        }

        private void WildernessGen()
        {
            Program.Rng.UseFixed = true;
            Program.Rng.FixedSeed =
                _saveGame.Wilderness[_saveGame.Player.WildernessY][_saveGame.Player.WildernessX].Seed;
            Island island = _saveGame.Wilderness;
            Player player = _saveGame.Player;
            int x;
            int y;
            for (y = 0; y < _saveGame.Level.CurHgt; y++)
            {
                for (x = 0; x < _saveGame.Level.CurWid; x++)
                {
                    byte elevation = island.Elevation(player.WildernessY, player.WildernessX, y, x);
                    string floorName = "Water";
                    string featureName = "Water";
                    if (elevation > 0)
                    {
                        floorName = "Grass";
                        if (Program.Rng.DieRoll(10) < elevation)
                        {
                            if (Program.Rng.DieRoll(10) < elevation)
                            {
                                featureName = "Tree";
                            }
                            else
                            {
                                featureName = "Bush";
                            }
                        }
                        else
                        {
                            featureName = "Grass";
                        }
                    }
                    _saveGame.Level.Grid[y][x].SetFeature(featureName);
                    _saveGame.Level.Grid[y][x].SetBackgroundFeature(floorName);
                }
            }
            for (x = 0; x < _saveGame.Level.CurWid; x++)
            {
                GridTile cPtr = _saveGame.Level.Grid[0][x];
                cPtr.SetFeature(cPtr.BackgroundFeature.Name.StartsWith("Water") ? "WaterBorder" : "WildBorder");
                cPtr = _saveGame.Level.Grid[_saveGame.Level.CurHgt - 1][x];
                cPtr.SetFeature(cPtr.BackgroundFeature.Name.StartsWith("Water") ? "WaterBorder" : "WildBorder");
            }
            for (y = 0; y < _saveGame.Level.CurHgt; y++)
            {
                GridTile cPtr = _saveGame.Level.Grid[y][0];
                cPtr.SetFeature(cPtr.BackgroundFeature.Name.StartsWith("Water") ? "WaterBorder" : "WildBorder");
                cPtr = _saveGame.Level.Grid[y][_saveGame.Level.CurWid - 1];
                cPtr.SetFeature(cPtr.BackgroundFeature.Name.StartsWith("Water") ? "WaterBorder" : "WildBorder");
            }
            MakeWildernessWalls(_saveGame.Player.WildernessX, _saveGame.Player.WildernessY);
            MakeCornerTowers(_saveGame.Player.WildernessX, _saveGame.Player.WildernessY);
            MakeWildernessPaths(_saveGame.Player.WildernessX, _saveGame.Player.WildernessY);
            MakeWildernessFeatures(_saveGame.Player.WildernessX, _saveGame.Player.WildernessY, out int stairX, out int stairY);
            int rocks = Program.Rng.RandomBetween(1, 10);
            for (int i = 0; i < rocks; i++)
            {
                x = Program.Rng.DieRoll(_saveGame.Level.CurWid - 2);
                y = Program.Rng.DieRoll(_saveGame.Level.CurHgt - 2);
                if (_saveGame.Level.Grid[y][x].FeatureType.Name != "Grass")
                {
                    continue;
                }
                _saveGame.Level.Grid[y][x].SetFeature("Rock");
            }
            Program.Rng.UseFixed = false;
            if (_saveGame.CameFrom == LevelStart.StartRandom)
            {
                NewPlayerSpot();
            }
            else if (_saveGame.CameFrom == LevelStart.StartStairs)
            {
                _saveGame.Player.MapY = stairY;
                _saveGame.Player.MapX = stairX;
            }
            else if (_saveGame.CameFrom == LevelStart.StartWalk)
            {
                if (_saveGame.Level.Grid[_saveGame.Player.MapY][_saveGame.Player.MapX].FeatureType.Category == FloorTileTypeCategory.Tree ||
                    _saveGame.Level.Grid[_saveGame.Player.MapY][_saveGame.Player.MapX].FeatureType.Name == "Water")
                {
                    _saveGame.Level.Grid[_saveGame.Player.MapY][_saveGame.Player.MapX].RevertToBackground();
                }
            }
            ResolvePaths();
            for (y = 1; y < _saveGame.Level.CurHgt - 1; y++)
            {
                for (x = 1; x < _saveGame.Level.CurWid - 1; x++)
                {
                    if (_saveGame.Level.Grid[y][x].FeatureType.IsOpenFloor)
                    {
                        _saveGame.Level.Grid[y][x].TileFlags.Set(GridTile.InRoom);
                    }
                }
            }
            if (_saveGame.Player.GameTime.IsLight)
            {
                for (y = 0; y < _saveGame.Level.CurHgt; y++)
                {
                    for (x = 0; x < _saveGame.Level.CurWid; x++)
                    {
                        _saveGame.Level.Grid[y][x].TileFlags.Set(GridTile.SelfLit);
                        _saveGame.Level.Grid[y][x].TileFlags.Set(GridTile.PlayerMemorised);
                    }
                }
            }
            for (x = 0; x < Constants.MinMAllocLevel; x++)
            {
                _saveGame.Level.Monsters.AllocMonster(3, true);
            }
        }
    }
}