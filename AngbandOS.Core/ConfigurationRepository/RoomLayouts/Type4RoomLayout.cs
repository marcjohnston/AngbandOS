// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.RoomTypes;

[Serializable]
internal class Type4RoomLayout : RoomLayout
{
    private Type4RoomLayout(SaveGame saveGame) : base(saveGame) { }
    public override int Type => 4;
    public override void Build(int yval, int xval)
    {
        int y, x;
        GridTile cPtr;
        bool light = SaveGame.Difficulty <= SaveGame.DieRoll(25);
        int y1 = yval - 4;
        int y2 = yval + 4;
        int x1 = xval - 11;
        int x2 = xval + 11;
        for (y = y1 - 1; y <= y2 + 1; y++)
        {
            for (x = x1 - 1; x <= x2 + 1; x++)
            {
                cPtr = SaveGame.Grid[y][x];
                cPtr.RevertToBackground();
                cPtr.TileFlags.Set(GridTile.InRoom);
                if (light)
                {
                    cPtr.TileFlags.Set(GridTile.SelfLit);
                }
            }
        }
        Tile wallOuterTile = SaveGame.SingletonRepository.Tiles.Get(nameof(WallOuterTile));
        for (y = y1 - 1; y <= y2 + 1; y++)
        {
            cPtr = SaveGame.Grid[y][x1 - 1];
            cPtr.SetFeature(wallOuterTile);
            cPtr = SaveGame.Grid[y][x2 + 1];
            cPtr.SetFeature(wallOuterTile);
        }
        for (x = x1 - 1; x <= x2 + 1; x++)
        {
            cPtr = SaveGame.Grid[y1 - 1][x];
            cPtr.SetFeature(wallOuterTile);
            cPtr = SaveGame.Grid[y2 + 1][x];
            cPtr.SetFeature(wallOuterTile);
        }
        y1 += 2;
        y2 -= 2;
        x1 += 2;
        x2 -= 2;
        Tile wallInnerTile = SaveGame.SingletonRepository.Tiles.Get(nameof(WallInnerTile));
        for (y = y1 - 1; y <= y2 + 1; y++)
        {
            cPtr = SaveGame.Grid[y][x1 - 1];
            cPtr.SetFeature(wallInnerTile);
            cPtr = SaveGame.Grid[y][x2 + 1];
            cPtr.SetFeature(wallInnerTile);
        }
        for (x = x1 - 1; x <= x2 + 1; x++)
        {
            cPtr = SaveGame.Grid[y1 - 1][x];
            cPtr.SetFeature(wallInnerTile);
            cPtr = SaveGame.Grid[y2 + 1][x];
            cPtr.SetFeature(wallInnerTile);
        }
        switch (SaveGame.DieRoll(5))
        {
            case 1:
                switch (SaveGame.DieRoll(4))
                {
                    case 1:
                        PlaceSecretDoor(y1 - 1, xval);
                        break;

                    case 2:
                        PlaceSecretDoor(y2 + 1, xval);
                        break;

                    case 3:
                        PlaceSecretDoor(yval, x1 - 1);
                        break;

                    case 4:
                        PlaceSecretDoor(yval, x2 + 1);
                        break;
                }
                VaultMonsters(yval, xval, 1);
                break;

            case 2:
                switch (SaveGame.DieRoll(4))
                {
                    case 1:
                        PlaceSecretDoor(y1 - 1, xval);
                        break;

                    case 2:
                        PlaceSecretDoor(y2 + 1, xval);
                        break;

                    case 3:
                        PlaceSecretDoor(yval, x1 - 1);
                        break;

                    case 4:
                        PlaceSecretDoor(yval, x2 + 1);
                        break;
                }
                for (y = yval - 1; y <= yval + 1; y++)
                {
                    for (x = xval - 1; x <= xval + 1; x++)
                    {
                        if (x == xval && y == yval)
                        {
                            continue;
                        }
                        cPtr = SaveGame.Grid[y][x];
                        cPtr.SetFeature(wallInnerTile);
                    }
                }
                switch (SaveGame.DieRoll(4))
                {
                    case 1:
                        PlaceLockedDoor(yval - 1, xval);
                        break;

                    case 2:
                        PlaceLockedDoor(yval + 1, xval);
                        break;

                    case 3:
                        PlaceLockedDoor(yval, xval - 1);
                        break;

                    case 4:
                        PlaceLockedDoor(yval, xval + 1);
                        break;
                }
                VaultMonsters(yval, xval, SaveGame.DieRoll(3) + 2);
                if (SaveGame.RandomLessThan(100) < 80)
                {
                    SaveGame.PlaceObject(yval, xval, false, false);
                }
                else
                {
                    PlaceRandomStairs(yval, xval);
                }
                VaultTraps(yval, xval, 4, 10, 2 + SaveGame.DieRoll(3));
                break;

            case 3:
                switch (SaveGame.DieRoll(4))
                {
                    case 1:
                        PlaceSecretDoor(y1 - 1, xval);
                        break;

                    case 2:
                        PlaceSecretDoor(y2 + 1, xval);
                        break;

                    case 3:
                        PlaceSecretDoor(yval, x1 - 1);
                        break;

                    case 4:
                        PlaceSecretDoor(yval, x2 + 1);
                        break;
                }
                for (y = yval - 1; y <= yval + 1; y++)
                {
                    for (x = xval - 1; x <= xval + 1; x++)
                    {
                        cPtr = SaveGame.Grid[y][x];
                        cPtr.SetFeature(wallInnerTile);
                    }
                }
                if (SaveGame.RandomLessThan(2) == 0)
                {
                    int tmp = SaveGame.DieRoll(2);
                    for (y = yval - 1; y <= yval + 1; y++)
                    {
                        for (x = xval - 5 - tmp; x <= xval - 3 - tmp; x++)
                        {
                            cPtr = SaveGame.Grid[y][x];
                            cPtr.SetFeature(wallInnerTile);
                        }
                        for (x = xval + 3 + tmp; x <= xval + 5 + tmp; x++)
                        {
                            cPtr = SaveGame.Grid[y][x];
                            cPtr.SetFeature(wallInnerTile);
                        }
                    }
                }
                if (SaveGame.RandomLessThan(3) == 0)
                {
                    for (x = xval - 5; x <= xval + 5; x++)
                    {
                        cPtr = SaveGame.Grid[yval - 1][x];
                        cPtr.SetFeature(wallInnerTile);
                        cPtr = SaveGame.Grid[yval + 1][x];
                        cPtr.SetFeature(wallInnerTile);
                    }
                    cPtr = SaveGame.Grid[yval][xval - 5];
                    cPtr.SetFeature(wallInnerTile);
                    cPtr = SaveGame.Grid[yval][xval + 5];
                    cPtr.SetFeature(wallInnerTile);
                    PlaceSecretDoor(yval - 3 + (SaveGame.DieRoll(2) * 2), xval - 3);
                    PlaceSecretDoor(yval - 3 + (SaveGame.DieRoll(2) * 2), xval + 3);
                    VaultMonsters(yval, xval - 2, SaveGame.DieRoll(2));
                    VaultMonsters(yval, xval + 2, SaveGame.DieRoll(2));
                    if (SaveGame.RandomLessThan(3) == 0)
                    {
                        SaveGame.PlaceObject(yval, xval - 2, false, false);
                    }
                    if (SaveGame.RandomLessThan(3) == 0)
                    {
                        SaveGame.PlaceObject(yval, xval + 2, false, false);
                    }
                }
                break;

            case 4:
                switch (SaveGame.DieRoll(4))
                {
                    case 1:
                        PlaceSecretDoor(y1 - 1, xval);
                        break;

                    case 2:
                        PlaceSecretDoor(y2 + 1, xval);
                        break;

                    case 3:
                        PlaceSecretDoor(yval, x1 - 1);
                        break;

                    case 4:
                        PlaceSecretDoor(yval, x2 + 1);
                        break;
                }
                for (y = y1; y <= y2; y++)
                {
                    for (x = x1; x <= x2; x++)
                    {
                        if ((1 & (x + y)) != 0)
                        {
                            cPtr = SaveGame.Grid[y][x];
                            cPtr.SetFeature(wallInnerTile);
                        }
                    }
                }
                VaultMonsters(yval, xval - 5, SaveGame.DieRoll(3));
                VaultMonsters(yval, xval + 5, SaveGame.DieRoll(3));
                VaultTraps(yval, xval - 3, 2, 8, SaveGame.DieRoll(3));
                VaultTraps(yval, xval + 3, 2, 8, SaveGame.DieRoll(3));
                VaultObjects(yval, xval, 3);
                break;

            case 5:
                for (y = y1; y <= y2; y++)
                {
                    cPtr = SaveGame.Grid[y][xval];
                    cPtr.SetFeature(wallInnerTile);
                }
                for (x = x1; x <= x2; x++)
                {
                    cPtr = SaveGame.Grid[yval][x];
                    cPtr.SetFeature(wallInnerTile);
                }
                if (SaveGame.RandomLessThan(100) < 50)
                {
                    int i = SaveGame.DieRoll(10);
                    PlaceSecretDoor(y1 - 1, xval - i);
                    PlaceSecretDoor(y1 - 1, xval + i);
                    PlaceSecretDoor(y2 + 1, xval - i);
                    PlaceSecretDoor(y2 + 1, xval + i);
                }
                else
                {
                    int i = SaveGame.DieRoll(3);
                    PlaceSecretDoor(yval + i, x1 - 1);
                    PlaceSecretDoor(yval - i, x1 - 1);
                    PlaceSecretDoor(yval + i, x2 + 1);
                    PlaceSecretDoor(yval - i, x2 + 1);
                }
                VaultObjects(yval, xval, 2 + SaveGame.DieRoll(2));
                VaultMonsters(yval + 1, xval - 4, SaveGame.DieRoll(4));
                VaultMonsters(yval + 1, xval + 4, SaveGame.DieRoll(4));
                VaultMonsters(yval - 1, xval - 4, SaveGame.DieRoll(4));
                VaultMonsters(yval - 1, xval + 4, SaveGame.DieRoll(4));
                break;
        }
    }

    private void PlaceRandomStairs(int y, int x)
    {
        if (!SaveGame.GridOpenNoItem(y, x))
        {
            return;
        }
        if (SaveGame.CurrentDepth <= 0)
        {
        }
        if (SaveGame.IsQuest(SaveGame.CurrentDepth) || SaveGame.CurrentDepth == SaveGame.CurDungeon.MaxLevel)
        {
            if (SaveGame.CurDungeon.Tower)
            {
                PlaceDownStairs(y, x);
            }
            else
            {
                PlaceUpStairs(y, x);
            }
        }
        else if (SaveGame.RandomLessThan(100) < 50)
        {
            PlaceDownStairs(y, x);
        }
        else
        {
            PlaceUpStairs(y, x);
        }
    }

    private void PlaceDownStairs(int y, int x)
    {
        GridTile cPtr = SaveGame.Grid[y][x];
        cPtr.SetFeature(SaveGame.SingletonRepository.Tiles.Get(nameof(DownStaircaseTile)));
    }

    private void PlaceUpStairs(int y, int x)
    {
        GridTile cPtr = SaveGame.Grid[y][x];
        cPtr.SetFeature(SaveGame.SingletonRepository.Tiles.Get(nameof(UpStaircaseTile)));
    }

    private void VaultObjects(int y, int x, int num)
    {
        int dummy = 0;
        int j = y, k = x;
        for (; num > 0; --num)
        {
            int i;
            for (i = 0; i < 11; ++i)
            {
                while (dummy < SaveGame.SafeMaxAttempts)
                {
                    j = SaveGame.RandomSpread(y, 2);
                    k = SaveGame.RandomSpread(x, 3);
                    dummy++;
                    if (!SaveGame.InBounds(j, k))
                    {
                        continue;
                    }
                    break;
                }
                if (!SaveGame.GridOpenNoItem(j, k))
                {
                    continue;
                }
                if (SaveGame.RandomLessThan(100) < 75)
                {
                    SaveGame.PlaceObject(j, k, false, false);
                }
                else
                {
                    SaveGame.PlaceGold(j, k);
                }
                break;
            }
        }
    }
    private void PlaceLockedDoor(int y, int x)
    {
        GridTile cPtr = SaveGame.Grid[y][x];
        WeightedRandom<Tile> tiles = new WeightedRandom<Tile>(SaveGame);
        tiles.Add(1, SaveGame.SingletonRepository.Tiles.Get(nameof(LockedDoor0Tile)));
        tiles.Add(1, SaveGame.SingletonRepository.Tiles.Get(nameof(LockedDoor1Tile)));
        tiles.Add(1, SaveGame.SingletonRepository.Tiles.Get(nameof(LockedDoor2Tile)));
        tiles.Add(1, SaveGame.SingletonRepository.Tiles.Get(nameof(LockedDoor3Tile)));
        tiles.Add(1, SaveGame.SingletonRepository.Tiles.Get(nameof(LockedDoor4Tile)));
        tiles.Add(1, SaveGame.SingletonRepository.Tiles.Get(nameof(LockedDoor5Tile)));
        tiles.Add(1, SaveGame.SingletonRepository.Tiles.Get(nameof(LockedDoor6Tile)));
        tiles.Add(1, SaveGame.SingletonRepository.Tiles.Get(nameof(LockedDoor7Tile)));
        Tile tile = tiles.Choose();
        cPtr.SetFeature(tile);
    }
}
