// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.RoomTypes;

internal abstract class RoomType
{
    public abstract int Type { get; }
    public abstract void Build(SaveGame saveGame, int yval, int xval);

    protected void BuildVault(SaveGame saveGame, int yval, int xval, int ymax, int xmax, string data)
    {
        int dx, dy, x, y;
        char t;
        int index = 0;
        for (dy = 0; dy < ymax; dy++)
        {
            for (dx = 0; dx < xmax; dx++)
            {
                t = data[index];
                index++;
                x = xval - (xmax / 2) + dx;
                y = yval - (ymax / 2) + dy;
                if (t == ' ')
                {
                    continue;
                }
                GridTile cPtr = saveGame.Grid[y][x];
                cPtr.RevertToBackground();
                cPtr.TileFlags.Set(GridTile.InRoom | GridTile.InVault);
                switch (t)
                {
                    case '%':
                        cPtr.SetFeature("WallOuter");
                        break;

                    case '#':
                        cPtr.SetFeature("WallInner");
                        break;

                    case 'X':
                        cPtr.SetFeature("WallPermInner");
                        break;

                    case '*':
                        if (Program.Rng.RandomLessThan(100) < 75)
                        {
                            saveGame.PlaceObject(y, x, false, false);
                        }
                        else
                        {
                            saveGame.PlaceTrap(y, x);
                        }
                        break;

                    case '+':
                        PlaceSecretDoor(saveGame, y, x);
                        break;

                    case '^':
                        saveGame.PlaceTrap(y, x);
                        break;
                }
            }
        }
        index = 0;
        for (dy = 0; dy < ymax; dy++)
        {
            for (dx = 0; dx < xmax; dx++)
            {
                t = data[index];
                index++;
                x = xval - (xmax / 2) + dx;
                y = yval - (ymax / 2) + dy;
                if (t == ' ')
                {
                    continue;
                }
                switch (t)
                {
                    case '&':
                        {
                            saveGame.MonsterLevel = saveGame.Difficulty + 5;
                            saveGame.PlaceMonster(y, x, true, true);
                            saveGame.MonsterLevel = saveGame.Difficulty;
                            break;
                        }
                    case '@':
                        {
                            saveGame.MonsterLevel = saveGame.Difficulty + 11;
                            saveGame.PlaceMonster(y, x, true, true);
                            saveGame.MonsterLevel = saveGame.Difficulty;
                            break;
                        }
                    case '9':
                        {
                            saveGame.MonsterLevel = saveGame.Difficulty + 9;
                            saveGame.PlaceMonster(y, x, true, true);
                            saveGame.MonsterLevel = saveGame.Difficulty;
                            saveGame.ObjectLevel = saveGame.Difficulty + 7;
                            saveGame.PlaceObject(y, x, true, false);
                            saveGame.ObjectLevel = saveGame.Difficulty;
                            break;
                        }
                    case '8':
                        {
                            saveGame.MonsterLevel = saveGame.Difficulty + 40;
                            saveGame.PlaceMonster(y, x, true, true);
                            saveGame.MonsterLevel = saveGame.Difficulty;
                            saveGame.ObjectLevel = saveGame.Difficulty + 20;
                            saveGame.PlaceObject(y, x, true, true);
                            saveGame.ObjectLevel = saveGame.Difficulty;
                            break;
                        }
                    case ',':
                        {
                            if (Program.Rng.RandomLessThan(100) < 50)
                            {
                                saveGame.MonsterLevel = saveGame.Difficulty + 3;
                                saveGame.PlaceMonster(y, x, true, true);
                                saveGame.MonsterLevel = saveGame.Difficulty;
                            }
                            if (Program.Rng.RandomLessThan(100) < 50)
                            {
                                saveGame.ObjectLevel = saveGame.Difficulty + 7;
                                saveGame.PlaceObject(y, x, false, false);
                                saveGame.ObjectLevel = saveGame.Difficulty;
                            }
                            break;
                        }
                    case 'A':
                        {
                            saveGame.ObjectLevel = saveGame.Difficulty + 12;
                            saveGame.PlaceObject(y, x, true, false);
                            saveGame.ObjectLevel = saveGame.Difficulty;
                        }
                        break;
                }
            }
        }
    }

    protected void VaultTraps(SaveGame saveGame, int y, int x, int yd, int xd, int num)
    {
        for (int i = 0; i < num; i++)
        {
            VaultTrapAux(saveGame, y, x, yd, xd);
        }
    }

    private void VaultTrapAux(SaveGame saveGame, int y, int x, int yd, int xd)
    {
        int count, y1 = y, x1 = x;
        int dummy = 0;
        for (count = 0; count <= 5; count++)
        {
            while (dummy < SaveGame.SafeMaxAttempts)
            {
                y1 = Program.Rng.RandomSpread(y, yd);
                x1 = Program.Rng.RandomSpread(x, xd);
                dummy++;
                if (!saveGame.InBounds(y1, x1))
                {
                    continue;
                }
                break;
            }
            if (!saveGame.GridOpenNoItemOrCreature(y1, x1))
            {
                continue;
            }
            saveGame.PlaceTrap(y1, x1);
            break;
        }
    }

    protected void VaultMonsters(SaveGame saveGame, int y1, int x1, int num)
    {
        for (int k = 0; k < num; k++)
        {
            for (int i = 0; i < 9; i++)
            {
                const int d = 1;
                saveGame.Scatter(out int y, out int x, y1, x1, d);
                if (!saveGame.GridPassableNoCreature(y, x))
                {
                    continue;
                }
                saveGame.MonsterLevel = saveGame.Difficulty + 2;
                saveGame.PlaceMonster(y, x, true, true);
                saveGame.MonsterLevel = saveGame.Difficulty;
            }
        }
    }

    protected void PlaceSecretDoor(SaveGame saveGame, int y, int x)
    {
        GridTile cPtr = saveGame.Grid[y][x];
        cPtr.SetFeature("SecretDoor");
    }

}
