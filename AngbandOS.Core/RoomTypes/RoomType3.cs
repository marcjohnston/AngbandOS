namespace AngbandOS.Core.RoomTypes
{
    internal class RoomType3 : RoomType
    {
        public override int Type => 3;
        public override void Build(SaveGame saveGame, int yval, int xval)
        {
            int y, x, wy;
            GridTile cPtr;
            bool light = saveGame.Difficulty <= Program.Rng.DieRoll(25);
            int wx = wy = 1;
            int dy = Program.Rng.RandomBetween(3, 4);
            int dx = Program.Rng.RandomBetween(3, 11);
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
                    cPtr = saveGame.Level.Grid[y][x];
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
                    cPtr = saveGame.Level.Grid[y][x];
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
                cPtr = saveGame.Level.Grid[y][x1A - 1];
                cPtr.SetFeature("WallOuter");
                cPtr = saveGame.Level.Grid[y][x2A + 1];
                cPtr.SetFeature("WallOuter");
            }
            for (x = x1A - 1; x <= x2A + 1; x++)
            {
                cPtr = saveGame.Level.Grid[y1A - 1][x];
                cPtr.SetFeature("WallOuter");
                cPtr = saveGame.Level.Grid[y2A + 1][x];
                cPtr.SetFeature("WallOuter");
            }
            for (y = y1B - 1; y <= y2B + 1; y++)
            {
                cPtr = saveGame.Level.Grid[y][x1B - 1];
                cPtr.SetFeature("WallOuter");
                cPtr = saveGame.Level.Grid[y][x2B + 1];
                cPtr.SetFeature("WallOuter");
            }
            for (x = x1B - 1; x <= x2B + 1; x++)
            {
                cPtr = saveGame.Level.Grid[y1B - 1][x];
                cPtr.SetFeature("WallOuter");
                cPtr = saveGame.Level.Grid[y2B + 1][x];
                cPtr.SetFeature("WallOuter");
            }
            for (y = y1A; y <= y2A; y++)
            {
                for (x = x1A; x <= x2A; x++)
                {
                    cPtr = saveGame.Level.Grid[y][x];
                    cPtr.RevertToBackground();
                }
            }
            for (y = y1B; y <= y2B; y++)
            {
                for (x = x1B; x <= x2B; x++)
                {
                    cPtr = saveGame.Level.Grid[y][x];
                    cPtr.RevertToBackground();
                }
            }
            switch (Program.Rng.RandomLessThan(4))
            {
                case 1:
                    {
                        for (y = y1B; y <= y2B; y++)
                        {
                            for (x = x1A; x <= x2A; x++)
                            {
                                cPtr = saveGame.Level.Grid[y][x];
                                cPtr.SetFeature("WallInner");
                            }
                        }
                        break;
                    }
                case 2:
                    {
                        for (y = y1B; y <= y2B; y++)
                        {
                            cPtr = saveGame.Level.Grid[y][x1A];
                            cPtr.SetFeature("WallInner");
                            cPtr = saveGame.Level.Grid[y][x2A];
                            cPtr.SetFeature("WallInner");
                        }
                        for (x = x1A; x <= x2A; x++)
                        {
                            cPtr = saveGame.Level.Grid[y1B][x];
                            cPtr.SetFeature("WallInner");
                            cPtr = saveGame.Level.Grid[y2B][x];
                            cPtr.SetFeature("WallInner");
                        }
                        switch (Program.Rng.RandomLessThan(4))
                        {
                            case 0:
                                PlaceSecretDoor(saveGame, y1B, xval);
                                break;

                            case 1:
                                PlaceSecretDoor(saveGame, y2B, xval);
                                break;

                            case 2:
                                PlaceSecretDoor(saveGame, yval, x1A);
                                break;

                            case 3:
                                PlaceSecretDoor(saveGame, yval, x2A);
                                break;
                        }
                        saveGame.Level.PlaceObject(yval, xval, false, false);
                        VaultMonsters(saveGame, yval, xval, Program.Rng.RandomLessThan(2) + 3);
                        VaultTraps(saveGame, yval, xval, 4, 4, Program.Rng.RandomLessThan(3) + 2);
                        break;
                    }
                case 3:
                    {
                        if (Program.Rng.RandomLessThan(3) == 0)
                        {
                            for (y = y1B; y <= y2B; y++)
                            {
                                if (y == yval)
                                {
                                    continue;
                                }
                                cPtr = saveGame.Level.Grid[y][x1A - 1];
                                cPtr.SetFeature("WallInner");
                                cPtr = saveGame.Level.Grid[y][x2A + 1];
                                cPtr.SetFeature("WallInner");
                            }
                            for (x = x1A; x <= x2A; x++)
                            {
                                if (x == xval)
                                {
                                    continue;
                                }
                                cPtr = saveGame.Level.Grid[y1B - 1][x];
                                cPtr.SetFeature("WallInner");
                                cPtr = saveGame.Level.Grid[y2B + 1][x];
                                cPtr.SetFeature("WallInner");
                            }
                            if (Program.Rng.RandomLessThan(3) == 0)
                            {
                                PlaceSecretDoor(saveGame, yval, x1A - 1);
                                PlaceSecretDoor(saveGame, yval, x2A + 1);
                                PlaceSecretDoor(saveGame, y1B - 1, xval);
                                PlaceSecretDoor(saveGame, y2B + 1, xval);
                            }
                        }
                        else if (Program.Rng.RandomLessThan(3) == 0)
                        {
                            cPtr = saveGame.Level.Grid[yval][xval];
                            cPtr.SetFeature("WallInner");
                            cPtr = saveGame.Level.Grid[y1B][xval];
                            cPtr.SetFeature("WallInner");
                            cPtr = saveGame.Level.Grid[y2B][xval];
                            cPtr.SetFeature("WallInner");
                            cPtr = saveGame.Level.Grid[yval][x1A];
                            cPtr.SetFeature("WallInner");
                            cPtr = saveGame.Level.Grid[yval][x2A];
                            cPtr.SetFeature("WallInner");
                        }
                        else if (Program.Rng.RandomLessThan(3) == 0)
                        {
                            cPtr = saveGame.Level.Grid[yval][xval];
                            cPtr.SetFeature("Pillar");
                        }
                        break;
                    }
            }
        }

    }
}
