﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.RoomTypes;

[Serializable]
internal class Type3RoomLayout : RoomLayout
{
    private Type3RoomLayout(SaveGame saveGame) : base(saveGame) { }
    public override int Type => 3;
    public override void Build(int yval, int xval)
    {
        int y, x, wy;
        GridTile cPtr;
        bool light = SaveGame.Difficulty <= SaveGame.Rng.DieRoll(25);
        int wx = wy = 1;
        int dy = SaveGame.Rng.RandomBetween(3, 4);
        int dx = SaveGame.Rng.RandomBetween(3, 11);
        int y1A = yval - dy;
        int y2A = yval + dy;
        int x1A = xval - wx;
        int x2A = xval + wx;
        int y1B = yval - wy;
        int y2B = yval + wy;
        int x1B = xval - dx;
        int x2B = xval + dx;
        for (y = y1A - 1; y <= y2A + 1; y++)
        {
            for (x = x1A - 1; x <= x2A + 1; x++)
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
        for (y = y1B - 1; y <= y2B + 1; y++)
        {
            for (x = x1B - 1; x <= x2B + 1; x++)
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
        for (y = y1A - 1; y <= y2A + 1; y++)
        {
            cPtr = SaveGame.Grid[y][x1A - 1];
            cPtr.SetFeature("WallOuter");
            cPtr = SaveGame.Grid[y][x2A + 1];
            cPtr.SetFeature("WallOuter");
        }
        for (x = x1A - 1; x <= x2A + 1; x++)
        {
            cPtr = SaveGame.Grid[y1A - 1][x];
            cPtr.SetFeature("WallOuter");
            cPtr = SaveGame.Grid[y2A + 1][x];
            cPtr.SetFeature("WallOuter");
        }
        for (y = y1B - 1; y <= y2B + 1; y++)
        {
            cPtr = SaveGame.Grid[y][x1B - 1];
            cPtr.SetFeature("WallOuter");
            cPtr = SaveGame.Grid[y][x2B + 1];
            cPtr.SetFeature("WallOuter");
        }
        for (x = x1B - 1; x <= x2B + 1; x++)
        {
            cPtr = SaveGame.Grid[y1B - 1][x];
            cPtr.SetFeature("WallOuter");
            cPtr = SaveGame.Grid[y2B + 1][x];
            cPtr.SetFeature("WallOuter");
        }
        for (y = y1A; y <= y2A; y++)
        {
            for (x = x1A; x <= x2A; x++)
            {
                cPtr = SaveGame.Grid[y][x];
                cPtr.RevertToBackground();
            }
        }
        for (y = y1B; y <= y2B; y++)
        {
            for (x = x1B; x <= x2B; x++)
            {
                cPtr = SaveGame.Grid[y][x];
                cPtr.RevertToBackground();
            }
        }
        switch (SaveGame.Rng.RandomLessThan(4))
        {
            case 1:
                {
                    for (y = y1B; y <= y2B; y++)
                    {
                        for (x = x1A; x <= x2A; x++)
                        {
                            cPtr = SaveGame.Grid[y][x];
                            cPtr.SetFeature("WallInner");
                        }
                    }
                    break;
                }
            case 2:
                {
                    for (y = y1B; y <= y2B; y++)
                    {
                        cPtr = SaveGame.Grid[y][x1A];
                        cPtr.SetFeature("WallInner");
                        cPtr = SaveGame.Grid[y][x2A];
                        cPtr.SetFeature("WallInner");
                    }
                    for (x = x1A; x <= x2A; x++)
                    {
                        cPtr = SaveGame.Grid[y1B][x];
                        cPtr.SetFeature("WallInner");
                        cPtr = SaveGame.Grid[y2B][x];
                        cPtr.SetFeature("WallInner");
                    }
                    switch (SaveGame.Rng.RandomLessThan(4))
                    {
                        case 0:
                            PlaceSecretDoor(y1B, xval);
                            break;

                        case 1:
                            PlaceSecretDoor(y2B, xval);
                            break;

                        case 2:
                            PlaceSecretDoor(yval, x1A);
                            break;

                        case 3:
                            PlaceSecretDoor(yval, x2A);
                            break;
                    }
                    SaveGame.PlaceObject(yval, xval, false, false);
                    VaultMonsters(yval, xval, SaveGame.Rng.RandomLessThan(2) + 3);
                    VaultTraps(yval, xval, 4, 4, SaveGame.Rng.RandomLessThan(3) + 2);
                    break;
                }
            case 3:
                {
                    if (SaveGame.Rng.RandomLessThan(3) == 0)
                    {
                        for (y = y1B; y <= y2B; y++)
                        {
                            if (y == yval)
                            {
                                continue;
                            }
                            cPtr = SaveGame.Grid[y][x1A - 1];
                            cPtr.SetFeature("WallInner");
                            cPtr = SaveGame.Grid[y][x2A + 1];
                            cPtr.SetFeature("WallInner");
                        }
                        for (x = x1A; x <= x2A; x++)
                        {
                            if (x == xval)
                            {
                                continue;
                            }
                            cPtr = SaveGame.Grid[y1B - 1][x];
                            cPtr.SetFeature("WallInner");
                            cPtr = SaveGame.Grid[y2B + 1][x];
                            cPtr.SetFeature("WallInner");
                        }
                        if (SaveGame.Rng.RandomLessThan(3) == 0)
                        {
                            PlaceSecretDoor(yval, x1A - 1);
                            PlaceSecretDoor(yval, x2A + 1);
                            PlaceSecretDoor(y1B - 1, xval);
                            PlaceSecretDoor(y2B + 1, xval);
                        }
                    }
                    else if (SaveGame.Rng.RandomLessThan(3) == 0)
                    {
                        cPtr = SaveGame.Grid[yval][xval];
                        cPtr.SetFeature("WallInner");
                        cPtr = SaveGame.Grid[y1B][xval];
                        cPtr.SetFeature("WallInner");
                        cPtr = SaveGame.Grid[y2B][xval];
                        cPtr.SetFeature("WallInner");
                        cPtr = SaveGame.Grid[yval][x1A];
                        cPtr.SetFeature("WallInner");
                        cPtr = SaveGame.Grid[yval][x2A];
                        cPtr.SetFeature("WallInner");
                    }
                    else if (SaveGame.Rng.RandomLessThan(3) == 0)
                    {
                        cPtr = SaveGame.Grid[yval][xval];
                        cPtr.SetFeature("Pillar");
                    }
                    break;
                }
        }
    }

}