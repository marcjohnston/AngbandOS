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
    private Type4RoomLayout(Game game) : base(game) { }
    public override int Type => 4;
    public override int Dy1 => 0;
    public override int Dy2 => 0;
    public override int Dx1 => -1;
    public override int Dx2 => 1;
    public override int Level => 3;
    public override void Build(int yval, int xval)
    {
        int y, x;
        GridTile cPtr;
        bool light = Game.Difficulty <= Game.DieRoll(25);
        int y1 = yval - 4;
        int y2 = yval + 4;
        int x1 = xval - 11;
        int x2 = xval + 11;
        for (y = y1 - 1; y <= y2 + 1; y++)
        {
            for (x = x1 - 1; x <= x2 + 1; x++)
            {
                cPtr = Game.Grid[y][x];
                cPtr.RevertToBackground();
                cPtr.TileFlags.Set(GridTile.InRoom);
                if (light)
                {
                    cPtr.TileFlags.Set(GridTile.SelfLit);
                }
            }
        }
        Tile wallOuterTile = Game.SingletonRepository.Tiles.Get(nameof(WallOuterTile));
        for (y = y1 - 1; y <= y2 + 1; y++)
        {
            cPtr = Game.Grid[y][x1 - 1];
            cPtr.SetFeature(wallOuterTile);
            cPtr = Game.Grid[y][x2 + 1];
            cPtr.SetFeature(wallOuterTile);
        }
        for (x = x1 - 1; x <= x2 + 1; x++)
        {
            cPtr = Game.Grid[y1 - 1][x];
            cPtr.SetFeature(wallOuterTile);
            cPtr = Game.Grid[y2 + 1][x];
            cPtr.SetFeature(wallOuterTile);
        }
        y1 += 2;
        y2 -= 2;
        x1 += 2;
        x2 -= 2;
        Tile wallInnerTile = Game.SingletonRepository.Tiles.Get(nameof(WallInnerTile));
        for (y = y1 - 1; y <= y2 + 1; y++)
        {
            cPtr = Game.Grid[y][x1 - 1];
            cPtr.SetFeature(wallInnerTile);
            cPtr = Game.Grid[y][x2 + 1];
            cPtr.SetFeature(wallInnerTile);
        }
        for (x = x1 - 1; x <= x2 + 1; x++)
        {
            cPtr = Game.Grid[y1 - 1][x];
            cPtr.SetFeature(wallInnerTile);
            cPtr = Game.Grid[y2 + 1][x];
            cPtr.SetFeature(wallInnerTile);
        }
        switch (Game.DieRoll(5))
        {
            case 1:
                switch (Game.DieRoll(4))
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
                switch (Game.DieRoll(4))
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
                        cPtr = Game.Grid[y][x];
                        cPtr.SetFeature(wallInnerTile);
                    }
                }
                switch (Game.DieRoll(4))
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
                VaultMonsters(yval, xval, Game.DieRoll(3) + 2);
                if (Game.RandomLessThan(100) < 80)
                {
                    Game.PlaceObject(yval, xval, false, false);
                }
                else
                {
                    PlaceRandomStairs(yval, xval);
                }
                VaultTraps(yval, xval, 4, 10, 2 + Game.DieRoll(3));
                break;

            case 3:
                switch (Game.DieRoll(4))
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
                        cPtr = Game.Grid[y][x];
                        cPtr.SetFeature(wallInnerTile);
                    }
                }
                if (Game.RandomLessThan(2) == 0)
                {
                    int tmp = Game.DieRoll(2);
                    for (y = yval - 1; y <= yval + 1; y++)
                    {
                        for (x = xval - 5 - tmp; x <= xval - 3 - tmp; x++)
                        {
                            cPtr = Game.Grid[y][x];
                            cPtr.SetFeature(wallInnerTile);
                        }
                        for (x = xval + 3 + tmp; x <= xval + 5 + tmp; x++)
                        {
                            cPtr = Game.Grid[y][x];
                            cPtr.SetFeature(wallInnerTile);
                        }
                    }
                }
                if (Game.RandomLessThan(3) == 0)
                {
                    for (x = xval - 5; x <= xval + 5; x++)
                    {
                        cPtr = Game.Grid[yval - 1][x];
                        cPtr.SetFeature(wallInnerTile);
                        cPtr = Game.Grid[yval + 1][x];
                        cPtr.SetFeature(wallInnerTile);
                    }
                    cPtr = Game.Grid[yval][xval - 5];
                    cPtr.SetFeature(wallInnerTile);
                    cPtr = Game.Grid[yval][xval + 5];
                    cPtr.SetFeature(wallInnerTile);
                    PlaceSecretDoor(yval - 3 + (Game.DieRoll(2) * 2), xval - 3);
                    PlaceSecretDoor(yval - 3 + (Game.DieRoll(2) * 2), xval + 3);
                    VaultMonsters(yval, xval - 2, Game.DieRoll(2));
                    VaultMonsters(yval, xval + 2, Game.DieRoll(2));
                    if (Game.RandomLessThan(3) == 0)
                    {
                        Game.PlaceObject(yval, xval - 2, false, false);
                    }
                    if (Game.RandomLessThan(3) == 0)
                    {
                        Game.PlaceObject(yval, xval + 2, false, false);
                    }
                }
                break;

            case 4:
                switch (Game.DieRoll(4))
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
                            cPtr = Game.Grid[y][x];
                            cPtr.SetFeature(wallInnerTile);
                        }
                    }
                }
                VaultMonsters(yval, xval - 5, Game.DieRoll(3));
                VaultMonsters(yval, xval + 5, Game.DieRoll(3));
                VaultTraps(yval, xval - 3, 2, 8, Game.DieRoll(3));
                VaultTraps(yval, xval + 3, 2, 8, Game.DieRoll(3));
                VaultObjects(yval, xval, 3);
                break;

            case 5:
                for (y = y1; y <= y2; y++)
                {
                    cPtr = Game.Grid[y][xval];
                    cPtr.SetFeature(wallInnerTile);
                }
                for (x = x1; x <= x2; x++)
                {
                    cPtr = Game.Grid[yval][x];
                    cPtr.SetFeature(wallInnerTile);
                }
                if (Game.RandomLessThan(100) < 50)
                {
                    int i = Game.DieRoll(10);
                    PlaceSecretDoor(y1 - 1, xval - i);
                    PlaceSecretDoor(y1 - 1, xval + i);
                    PlaceSecretDoor(y2 + 1, xval - i);
                    PlaceSecretDoor(y2 + 1, xval + i);
                }
                else
                {
                    int i = Game.DieRoll(3);
                    PlaceSecretDoor(yval + i, x1 - 1);
                    PlaceSecretDoor(yval - i, x1 - 1);
                    PlaceSecretDoor(yval + i, x2 + 1);
                    PlaceSecretDoor(yval - i, x2 + 1);
                }
                VaultObjects(yval, xval, 2 + Game.DieRoll(2));
                VaultMonsters(yval + 1, xval - 4, Game.DieRoll(4));
                VaultMonsters(yval + 1, xval + 4, Game.DieRoll(4));
                VaultMonsters(yval - 1, xval - 4, Game.DieRoll(4));
                VaultMonsters(yval - 1, xval + 4, Game.DieRoll(4));
                break;
        }
    }

    private void PlaceRandomStairs(int y, int x)
    {
        if (!Game.GridOpenNoItem(y, x))
        {
            return;
        }
        if (Game.CurrentDepth <= 0)
        {
        }
        if (Game.IsQuest(Game.CurrentDepth) || Game.CurrentDepth == Game.CurDungeon.MaxLevel)
        {
            if (Game.CurDungeon.Tower)
            {
                PlaceDownStairs(y, x);
            }
            else
            {
                PlaceUpStairs(y, x);
            }
        }
        else if (Game.RandomLessThan(100) < 50)
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
        GridTile cPtr = Game.Grid[y][x];
        cPtr.SetFeature(Game.SingletonRepository.Tiles.Get(nameof(DownStaircaseTile)));
    }

    private void PlaceUpStairs(int y, int x)
    {
        GridTile cPtr = Game.Grid[y][x];
        cPtr.SetFeature(Game.SingletonRepository.Tiles.Get(nameof(UpStaircaseTile)));
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
                while (dummy < Game.SafeMaxAttempts)
                {
                    j = Game.RandomSpread(y, 2);
                    k = Game.RandomSpread(x, 3);
                    dummy++;
                    if (!Game.InBounds(j, k))
                    {
                        continue;
                    }
                    break;
                }
                if (!Game.GridOpenNoItem(j, k))
                {
                    continue;
                }
                if (Game.RandomLessThan(100) < 75)
                {
                    Game.PlaceObject(j, k, false, false);
                }
                else
                {
                    Game.PlaceGold(j, k);
                }
                break;
            }
        }
    }
    private void PlaceLockedDoor(int y, int x)
    {
        GridTile cPtr = Game.Grid[y][x];
        WeightedRandom<Tile> tiles = new WeightedRandom<Tile>(Game);
        tiles.Add(1, Game.SingletonRepository.Tiles.Get(nameof(LockedDoor0Tile)));
        tiles.Add(1, Game.SingletonRepository.Tiles.Get(nameof(LockedDoor1Tile)));
        tiles.Add(1, Game.SingletonRepository.Tiles.Get(nameof(LockedDoor2Tile)));
        tiles.Add(1, Game.SingletonRepository.Tiles.Get(nameof(LockedDoor3Tile)));
        tiles.Add(1, Game.SingletonRepository.Tiles.Get(nameof(LockedDoor4Tile)));
        tiles.Add(1, Game.SingletonRepository.Tiles.Get(nameof(LockedDoor5Tile)));
        tiles.Add(1, Game.SingletonRepository.Tiles.Get(nameof(LockedDoor6Tile)));
        tiles.Add(1, Game.SingletonRepository.Tiles.Get(nameof(LockedDoor7Tile)));
        Tile tile = tiles.Choose();
        cPtr.SetFeature(tile);
    }
}
