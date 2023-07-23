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
        bool light = SaveGame.Difficulty <= SaveGame.Rng.DieRoll(25);
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
        for (y = y1 - 1; y <= y2 + 1; y++)
        {
            cPtr = SaveGame.Grid[y][x1 - 1];
            cPtr.SetFeature("WallOuter");
            cPtr = SaveGame.Grid[y][x2 + 1];
            cPtr.SetFeature("WallOuter");
        }
        for (x = x1 - 1; x <= x2 + 1; x++)
        {
            cPtr = SaveGame.Grid[y1 - 1][x];
            cPtr.SetFeature("WallOuter");
            cPtr = SaveGame.Grid[y2 + 1][x];
            cPtr.SetFeature("WallOuter");
        }
        y1 += 2;
        y2 -= 2;
        x1 += 2;
        x2 -= 2;
        for (y = y1 - 1; y <= y2 + 1; y++)
        {
            cPtr = SaveGame.Grid[y][x1 - 1];
            cPtr.SetFeature("WallInner");
            cPtr = SaveGame.Grid[y][x2 + 1];
            cPtr.SetFeature("WallInner");
        }
        for (x = x1 - 1; x <= x2 + 1; x++)
        {
            cPtr = SaveGame.Grid[y1 - 1][x];
            cPtr.SetFeature("WallInner");
            cPtr = SaveGame.Grid[y2 + 1][x];
            cPtr.SetFeature("WallInner");
        }
        switch (SaveGame.Rng.DieRoll(5))
        {
            case 1:
                switch (SaveGame.Rng.DieRoll(4))
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
                switch (SaveGame.Rng.DieRoll(4))
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
                        cPtr.SetFeature("WallInner");
                    }
                }
                switch (SaveGame.Rng.DieRoll(4))
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
                VaultMonsters(yval, xval, SaveGame.Rng.DieRoll(3) + 2);
                if (SaveGame.Rng.RandomLessThan(100) < 80)
                {
                    SaveGame.PlaceObject(yval, xval, false, false);
                }
                else
                {
                    PlaceRandomStairs(yval, xval);
                }
                VaultTraps(yval, xval, 4, 10, 2 + SaveGame.Rng.DieRoll(3));
                break;

            case 3:
                switch (SaveGame.Rng.DieRoll(4))
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
                        cPtr.SetFeature("WallInner");
                    }
                }
                if (SaveGame.Rng.RandomLessThan(2) == 0)
                {
                    int tmp = SaveGame.Rng.DieRoll(2);
                    for (y = yval - 1; y <= yval + 1; y++)
                    {
                        for (x = xval - 5 - tmp; x <= xval - 3 - tmp; x++)
                        {
                            cPtr = SaveGame.Grid[y][x];
                            cPtr.SetFeature("WallInner");
                        }
                        for (x = xval + 3 + tmp; x <= xval + 5 + tmp; x++)
                        {
                            cPtr = SaveGame.Grid[y][x];
                            cPtr.SetFeature("WallInner");
                        }
                    }
                }
                if (SaveGame.Rng.RandomLessThan(3) == 0)
                {
                    for (x = xval - 5; x <= xval + 5; x++)
                    {
                        cPtr = SaveGame.Grid[yval - 1][x];
                        cPtr.SetFeature("WallInner");
                        cPtr = SaveGame.Grid[yval + 1][x];
                        cPtr.SetFeature("WallInner");
                    }
                    cPtr = SaveGame.Grid[yval][xval - 5];
                    cPtr.SetFeature("WallInner");
                    cPtr = SaveGame.Grid[yval][xval + 5];
                    cPtr.SetFeature("WallInner");
                    PlaceSecretDoor(yval - 3 + (SaveGame.Rng.DieRoll(2) * 2), xval - 3);
                    PlaceSecretDoor(yval - 3 + (SaveGame.Rng.DieRoll(2) * 2), xval + 3);
                    VaultMonsters(yval, xval - 2, SaveGame.Rng.DieRoll(2));
                    VaultMonsters(yval, xval + 2, SaveGame.Rng.DieRoll(2));
                    if (SaveGame.Rng.RandomLessThan(3) == 0)
                    {
                        SaveGame.PlaceObject(yval, xval - 2, false, false);
                    }
                    if (SaveGame.Rng.RandomLessThan(3) == 0)
                    {
                        SaveGame.PlaceObject(yval, xval + 2, false, false);
                    }
                }
                break;

            case 4:
                switch (SaveGame.Rng.DieRoll(4))
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
                            cPtr.SetFeature("WallInner");
                        }
                    }
                }
                VaultMonsters(yval, xval - 5, SaveGame.Rng.DieRoll(3));
                VaultMonsters(yval, xval + 5, SaveGame.Rng.DieRoll(3));
                VaultTraps(yval, xval - 3, 2, 8, SaveGame.Rng.DieRoll(3));
                VaultTraps(yval, xval + 3, 2, 8, SaveGame.Rng.DieRoll(3));
                VaultObjects(yval, xval, 3);
                break;

            case 5:
                for (y = y1; y <= y2; y++)
                {
                    cPtr = SaveGame.Grid[y][xval];
                    cPtr.SetFeature("WallInner");
                }
                for (x = x1; x <= x2; x++)
                {
                    cPtr = SaveGame.Grid[yval][x];
                    cPtr.SetFeature("WallInner");
                }
                if (SaveGame.Rng.RandomLessThan(100) < 50)
                {
                    int i = SaveGame.Rng.DieRoll(10);
                    PlaceSecretDoor(y1 - 1, xval - i);
                    PlaceSecretDoor(y1 - 1, xval + i);
                    PlaceSecretDoor(y2 + 1, xval - i);
                    PlaceSecretDoor(y2 + 1, xval + i);
                }
                else
                {
                    int i = SaveGame.Rng.DieRoll(3);
                    PlaceSecretDoor(yval + i, x1 - 1);
                    PlaceSecretDoor(yval - i, x1 - 1);
                    PlaceSecretDoor(yval + i, x2 + 1);
                    PlaceSecretDoor(yval - i, x2 + 1);
                }
                VaultObjects(yval, xval, 2 + SaveGame.Rng.DieRoll(2));
                VaultMonsters(yval + 1, xval - 4, SaveGame.Rng.DieRoll(4));
                VaultMonsters(yval + 1, xval + 4, SaveGame.Rng.DieRoll(4));
                VaultMonsters(yval - 1, xval - 4, SaveGame.Rng.DieRoll(4));
                VaultMonsters(yval - 1, xval + 4, SaveGame.Rng.DieRoll(4));
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
        else if (SaveGame.Rng.RandomLessThan(100) < 50)
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
        cPtr.SetFeature("DownStair");
    }

    private void PlaceUpStairs(int y, int x)
    {
        GridTile cPtr = SaveGame.Grid[y][x];
        cPtr.SetFeature("UpStair");
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
                    j = SaveGame.Rng.RandomSpread(y, 2);
                    k = SaveGame.Rng.RandomSpread(x, 3);
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
                if (SaveGame.Rng.RandomLessThan(100) < 75)
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
        cPtr.SetFeature($"LockedDoor{SaveGame.Rng.DieRoll(7)}");
    }
}
