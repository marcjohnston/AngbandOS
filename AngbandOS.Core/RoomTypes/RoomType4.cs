// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.RoomTypes;

internal class RoomType4 : RoomType
{
    public override int Type => 4;
    public override void Build(SaveGame saveGame, int yval, int xval)
    {
        int y, x;
        GridTile cPtr;
        bool light = saveGame.Difficulty <= Program.Rng.DieRoll(25);
        int y1 = yval - 4;
        int y2 = yval + 4;
        int x1 = xval - 11;
        int x2 = xval + 11;
        for (y = y1 - 1; y <= y2 + 1; y++)
        {
            for (x = x1 - 1; x <= x2 + 1; x++)
            {
                cPtr = saveGame.Level.Grid[y][x];
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
            cPtr = saveGame.Level.Grid[y][x1 - 1];
            cPtr.SetFeature("WallOuter");
            cPtr = saveGame.Level.Grid[y][x2 + 1];
            cPtr.SetFeature("WallOuter");
        }
        for (x = x1 - 1; x <= x2 + 1; x++)
        {
            cPtr = saveGame.Level.Grid[y1 - 1][x];
            cPtr.SetFeature("WallOuter");
            cPtr = saveGame.Level.Grid[y2 + 1][x];
            cPtr.SetFeature("WallOuter");
        }
        y1 += 2;
        y2 -= 2;
        x1 += 2;
        x2 -= 2;
        for (y = y1 - 1; y <= y2 + 1; y++)
        {
            cPtr = saveGame.Level.Grid[y][x1 - 1];
            cPtr.SetFeature("WallInner");
            cPtr = saveGame.Level.Grid[y][x2 + 1];
            cPtr.SetFeature("WallInner");
        }
        for (x = x1 - 1; x <= x2 + 1; x++)
        {
            cPtr = saveGame.Level.Grid[y1 - 1][x];
            cPtr.SetFeature("WallInner");
            cPtr = saveGame.Level.Grid[y2 + 1][x];
            cPtr.SetFeature("WallInner");
        }
        switch (Program.Rng.DieRoll(5))
        {
            case 1:
                switch (Program.Rng.DieRoll(4))
                {
                    case 1:
                        PlaceSecretDoor(saveGame, y1 - 1, xval);
                        break;

                    case 2:
                        PlaceSecretDoor(saveGame, y2 + 1, xval);
                        break;

                    case 3:
                        PlaceSecretDoor(saveGame, yval, x1 - 1);
                        break;

                    case 4:
                        PlaceSecretDoor(saveGame, yval, x2 + 1);
                        break;
                }
                VaultMonsters(saveGame, yval, xval, 1);
                break;

            case 2:
                switch (Program.Rng.DieRoll(4))
                {
                    case 1:
                        PlaceSecretDoor(saveGame, y1 - 1, xval);
                        break;

                    case 2:
                        PlaceSecretDoor(saveGame, y2 + 1, xval);
                        break;

                    case 3:
                        PlaceSecretDoor(saveGame, yval, x1 - 1);
                        break;

                    case 4:
                        PlaceSecretDoor(saveGame, yval, x2 + 1);
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
                        cPtr = saveGame.Level.Grid[y][x];
                        cPtr.SetFeature("WallInner");
                    }
                }
                switch (Program.Rng.DieRoll(4))
                {
                    case 1:
                        PlaceLockedDoor(saveGame, yval - 1, xval);
                        break;

                    case 2:
                        PlaceLockedDoor(saveGame, yval + 1, xval);
                        break;

                    case 3:
                        PlaceLockedDoor(saveGame, yval, xval - 1);
                        break;

                    case 4:
                        PlaceLockedDoor(saveGame, yval, xval + 1);
                        break;
                }
                VaultMonsters(saveGame, yval, xval, Program.Rng.DieRoll(3) + 2);
                if (Program.Rng.RandomLessThan(100) < 80)
                {
                    saveGame.Level.PlaceObject(yval, xval, false, false);
                }
                else
                {
                    PlaceRandomStairs(saveGame, yval, xval);
                }
                VaultTraps(saveGame, yval, xval, 4, 10, 2 + Program.Rng.DieRoll(3));
                break;

            case 3:
                switch (Program.Rng.DieRoll(4))
                {
                    case 1:
                        PlaceSecretDoor(saveGame, y1 - 1, xval);
                        break;

                    case 2:
                        PlaceSecretDoor(saveGame, y2 + 1, xval);
                        break;

                    case 3:
                        PlaceSecretDoor(saveGame, yval, x1 - 1);
                        break;

                    case 4:
                        PlaceSecretDoor(saveGame, yval, x2 + 1);
                        break;
                }
                for (y = yval - 1; y <= yval + 1; y++)
                {
                    for (x = xval - 1; x <= xval + 1; x++)
                    {
                        cPtr = saveGame.Level.Grid[y][x];
                        cPtr.SetFeature("WallInner");
                    }
                }
                if (Program.Rng.RandomLessThan(2) == 0)
                {
                    int tmp = Program.Rng.DieRoll(2);
                    for (y = yval - 1; y <= yval + 1; y++)
                    {
                        for (x = xval - 5 - tmp; x <= xval - 3 - tmp; x++)
                        {
                            cPtr = saveGame.Level.Grid[y][x];
                            cPtr.SetFeature("WallInner");
                        }
                        for (x = xval + 3 + tmp; x <= xval + 5 + tmp; x++)
                        {
                            cPtr = saveGame.Level.Grid[y][x];
                            cPtr.SetFeature("WallInner");
                        }
                    }
                }
                if (Program.Rng.RandomLessThan(3) == 0)
                {
                    for (x = xval - 5; x <= xval + 5; x++)
                    {
                        cPtr = saveGame.Level.Grid[yval - 1][x];
                        cPtr.SetFeature("WallInner");
                        cPtr = saveGame.Level.Grid[yval + 1][x];
                        cPtr.SetFeature("WallInner");
                    }
                    cPtr = saveGame.Level.Grid[yval][xval - 5];
                    cPtr.SetFeature("WallInner");
                    cPtr = saveGame.Level.Grid[yval][xval + 5];
                    cPtr.SetFeature("WallInner");
                    PlaceSecretDoor(saveGame, yval - 3 + (Program.Rng.DieRoll(2) * 2), xval - 3);
                    PlaceSecretDoor(saveGame, yval - 3 + (Program.Rng.DieRoll(2) * 2), xval + 3);
                    VaultMonsters(saveGame, yval, xval - 2, Program.Rng.DieRoll(2));
                    VaultMonsters(saveGame, yval, xval + 2, Program.Rng.DieRoll(2));
                    if (Program.Rng.RandomLessThan(3) == 0)
                    {
                        saveGame.Level.PlaceObject(yval, xval - 2, false, false);
                    }
                    if (Program.Rng.RandomLessThan(3) == 0)
                    {
                        saveGame.Level.PlaceObject(yval, xval + 2, false, false);
                    }
                }
                break;

            case 4:
                switch (Program.Rng.DieRoll(4))
                {
                    case 1:
                        PlaceSecretDoor(saveGame, y1 - 1, xval);
                        break;

                    case 2:
                        PlaceSecretDoor(saveGame, y2 + 1, xval);
                        break;

                    case 3:
                        PlaceSecretDoor(saveGame, yval, x1 - 1);
                        break;

                    case 4:
                        PlaceSecretDoor(saveGame, yval, x2 + 1);
                        break;
                }
                for (y = y1; y <= y2; y++)
                {
                    for (x = x1; x <= x2; x++)
                    {
                        if ((1 & (x + y)) != 0)
                        {
                            cPtr = saveGame.Level.Grid[y][x];
                            cPtr.SetFeature("WallInner");
                        }
                    }
                }
                VaultMonsters(saveGame, yval, xval - 5, Program.Rng.DieRoll(3));
                VaultMonsters(saveGame, yval, xval + 5, Program.Rng.DieRoll(3));
                VaultTraps(saveGame, yval, xval - 3, 2, 8, Program.Rng.DieRoll(3));
                VaultTraps(saveGame, yval, xval + 3, 2, 8, Program.Rng.DieRoll(3));
                VaultObjects(saveGame, yval, xval, 3);
                break;

            case 5:
                for (y = y1; y <= y2; y++)
                {
                    cPtr = saveGame.Level.Grid[y][xval];
                    cPtr.SetFeature("WallInner");
                }
                for (x = x1; x <= x2; x++)
                {
                    cPtr = saveGame.Level.Grid[yval][x];
                    cPtr.SetFeature("WallInner");
                }
                if (Program.Rng.RandomLessThan(100) < 50)
                {
                    int i = Program.Rng.DieRoll(10);
                    PlaceSecretDoor(saveGame, y1 - 1, xval - i);
                    PlaceSecretDoor(saveGame, y1 - 1, xval + i);
                    PlaceSecretDoor(saveGame, y2 + 1, xval - i);
                    PlaceSecretDoor(saveGame, y2 + 1, xval + i);
                }
                else
                {
                    int i = Program.Rng.DieRoll(3);
                    PlaceSecretDoor(saveGame, yval + i, x1 - 1);
                    PlaceSecretDoor(saveGame, yval - i, x1 - 1);
                    PlaceSecretDoor(saveGame, yval + i, x2 + 1);
                    PlaceSecretDoor(saveGame, yval - i, x2 + 1);
                }
                VaultObjects(saveGame, yval, xval, 2 + Program.Rng.DieRoll(2));
                VaultMonsters(saveGame, yval + 1, xval - 4, Program.Rng.DieRoll(4));
                VaultMonsters(saveGame, yval + 1, xval + 4, Program.Rng.DieRoll(4));
                VaultMonsters(saveGame, yval - 1, xval - 4, Program.Rng.DieRoll(4));
                VaultMonsters(saveGame, yval - 1, xval + 4, Program.Rng.DieRoll(4));
                break;
        }
    }

    private void PlaceRandomStairs(SaveGame saveGame, int y, int x)
    {
        if (!saveGame.Level.GridOpenNoItem(y, x))
        {
            return;
        }
        if (saveGame.CurrentDepth <= 0)
        {
        }
        if (saveGame.IsQuest(saveGame.CurrentDepth) || saveGame.CurrentDepth == saveGame.CurDungeon.MaxLevel)
        {
            if (saveGame.CurDungeon.Tower)
            {
                PlaceDownStairs(saveGame, y, x);
            }
            else
            {
                PlaceUpStairs(saveGame, y, x);
            }
        }
        else if (Program.Rng.RandomLessThan(100) < 50)
        {
            PlaceDownStairs(saveGame, y, x);
        }
        else
        {
            PlaceUpStairs(saveGame, y, x);
        }
    }

    private void PlaceDownStairs(SaveGame saveGame, int y, int x)
    {
        GridTile cPtr = saveGame.Level.Grid[y][x];
        cPtr.SetFeature("DownStair");
    }

    private void PlaceUpStairs(SaveGame saveGame, int y, int x)
    {
        GridTile cPtr = saveGame.Level.Grid[y][x];
        cPtr.SetFeature("UpStair");
    }

    private void VaultObjects(SaveGame saveGame, int y, int x, int num)
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
                    j = Program.Rng.RandomSpread(y, 2);
                    k = Program.Rng.RandomSpread(x, 3);
                    dummy++;
                    if (!saveGame.Level.InBounds(j, k))
                    {
                        continue;
                    }
                    break;
                }
                if (!saveGame.Level.GridOpenNoItem(j, k))
                {
                    continue;
                }
                if (Program.Rng.RandomLessThan(100) < 75)
                {
                    saveGame.Level.PlaceObject(j, k, false, false);
                }
                else
                {
                    saveGame.Level.PlaceGold(j, k);
                }
                break;
            }
        }
    }
    private void PlaceLockedDoor(SaveGame saveGame, int y, int x)
    {
        GridTile cPtr = saveGame.Level.Grid[y][x];
        cPtr.SetFeature($"LockedDoor{Program.Rng.DieRoll(7)}");
    }
}
