// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.RoomTypes;

[Serializable]
internal abstract class RoomLayout
{
    protected readonly SaveGame SaveGame;
    protected RoomLayout(SaveGame saveGame)
    {
        SaveGame = saveGame;
    }

    public abstract int Type { get; }
    public abstract void Build(int yval, int xval);

    protected void BuildVault(int yval, int xval, int ymax, int xmax, string data)
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
                GridTile cPtr = SaveGame.Grid[y][x];
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
                            SaveGame.PlaceObject(y, x, false, false);
                        }
                        else
                        {
                            SaveGame.PlaceTrap(y, x);
                        }
                        break;

                    case '+':
                        PlaceSecretDoor(y, x);
                        break;

                    case '^':
                        SaveGame.PlaceTrap(y, x);
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
                            SaveGame.MonsterLevel = SaveGame.Difficulty + 5;
                            SaveGame.PlaceMonster(y, x, true, true);
                            SaveGame.MonsterLevel = SaveGame.Difficulty;
                            break;
                        }
                    case '@':
                        {
                            SaveGame.MonsterLevel = SaveGame.Difficulty + 11;
                            SaveGame.PlaceMonster(y, x, true, true);
                            SaveGame.MonsterLevel = SaveGame.Difficulty;
                            break;
                        }
                    case '9':
                        {
                            SaveGame.MonsterLevel = SaveGame.Difficulty + 9;
                            SaveGame.PlaceMonster(y, x, true, true);
                            SaveGame.MonsterLevel = SaveGame.Difficulty;
                            SaveGame.ObjectLevel = SaveGame.Difficulty + 7;
                            SaveGame.PlaceObject(y, x, true, false);
                            SaveGame.ObjectLevel = SaveGame.Difficulty;
                            break;
                        }
                    case '8':
                        {
                            SaveGame.MonsterLevel = SaveGame.Difficulty + 40;
                            SaveGame.PlaceMonster(y, x, true, true);
                            SaveGame.MonsterLevel = SaveGame.Difficulty;
                            SaveGame.ObjectLevel = SaveGame.Difficulty + 20;
                            SaveGame.PlaceObject(y, x, true, true);
                            SaveGame.ObjectLevel = SaveGame.Difficulty;
                            break;
                        }
                    case ',':
                        {
                            if (Program.Rng.RandomLessThan(100) < 50)
                            {
                                SaveGame.MonsterLevel = SaveGame.Difficulty + 3;
                                SaveGame.PlaceMonster(y, x, true, true);
                                SaveGame.MonsterLevel = SaveGame.Difficulty;
                            }
                            if (Program.Rng.RandomLessThan(100) < 50)
                            {
                                SaveGame.ObjectLevel = SaveGame.Difficulty + 7;
                                SaveGame.PlaceObject(y, x, false, false);
                                SaveGame.ObjectLevel = SaveGame.Difficulty;
                            }
                            break;
                        }
                    case 'A':
                        {
                            SaveGame.ObjectLevel = SaveGame.Difficulty + 12;
                            SaveGame.PlaceObject(y, x, true, false);
                            SaveGame.ObjectLevel = SaveGame.Difficulty;
                        }
                        break;
                }
            }
        }
    }

    protected void VaultTraps(int y, int x, int yd, int xd, int num)
    {
        for (int i = 0; i < num; i++)
        {
            VaultTrapAux(y, x, yd, xd);
        }
    }

    private void VaultTrapAux(int y, int x, int yd, int xd)
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
                if (!SaveGame.InBounds(y1, x1))
                {
                    continue;
                }
                break;
            }
            if (!SaveGame.GridOpenNoItemOrCreature(y1, x1))
            {
                continue;
            }
            SaveGame.PlaceTrap(y1, x1);
            break;
        }
    }

    protected void VaultMonsters(int y1, int x1, int num)
    {
        for (int k = 0; k < num; k++)
        {
            for (int i = 0; i < 9; i++)
            {
                const int d = 1;
                SaveGame.Scatter(out int y, out int x, y1, x1, d);
                if (!SaveGame.GridPassableNoCreature(y, x))
                {
                    continue;
                }
                SaveGame.MonsterLevel = SaveGame.Difficulty + 2;
                SaveGame.PlaceMonster(y, x, true, true);
                SaveGame.MonsterLevel = SaveGame.Difficulty;
            }
        }
    }

    protected void PlaceSecretDoor(int y, int x)
    {
        GridTile cPtr = SaveGame.Grid[y][x];
        cPtr.SetFeature("SecretDoor");
    }

}
