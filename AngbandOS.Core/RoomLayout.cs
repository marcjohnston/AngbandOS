// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal abstract class RoomLayout : IGetKey
{
    protected readonly Game Game;
    protected RoomLayout(Game game)
    {
        Game = game;
    }

    /// <summary>
    /// Returns the entity serialized into a Json string.
    /// </summary>
    /// <returns></returns>
    public string ToJson()
    {
        return "";
    }

    public virtual string Key => GetType().Name;

    public string GetKey => Key;
    public void Bind() { }

    /// <summary>
    /// Returns the number of grid blocks to the left this type of room occupies.
    /// </summary>
    public abstract int Dx1 { get; }

    /// <summary>
    /// Returns the number of grid blocks to the right this type of room occupies.
    /// </summary>
    public abstract int Dx2 { get; }

    /// <summary>
    /// Returns the number of grid blocks to the top this type of room occupies.
    /// </summary>
    public abstract int Dy1 { get; }

    /// <summary>
    /// Returns the number of grid blocks to the bottom this type of room occupies.
    /// </summary>
    public abstract int Dy2 { get; }

    public abstract int Level { get; }

    public abstract int Type { get; }
    public abstract void Build(int yval, int xval);

    /// <summary>
    /// Returns the number of grid blocks wide this type of room occupies.
    /// </summary>
    public int Width => -Dx1 + Dx2 + 1;

    /// <summary>
    /// Returns the number of grid blocks wide this type of room occupies.
    /// </summary>
    public int Height => -Dy1 + Dy2 + 1;

    protected void BuildVault(int yval, int xval, int ymax, int xmax, string data)
    {
        int dx, dy, x, y;
        char t;
        int index = 0;
        Tile wallOuter = Game.SingletonRepository.Get<Tile>(nameof(WallOuterTile));
        Tile wallInner = Game.SingletonRepository.Get<Tile>(nameof(WallInnerTile));
        Tile wallPermInner = Game.SingletonRepository.Get<Tile>(nameof(WallPermanentInnerTile));
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
                GridTile cPtr = Game.Map.Grid[y][x];
                cPtr.RevertToBackground();
                cPtr.InVault = true;
                cPtr.InRoom = true;
                switch (t)
                {
                    case '%':
                        cPtr.SetFeature(wallOuter);
                        break;

                    case '#':
                        cPtr.SetFeature(wallInner);
                        break;

                    case 'X':
                        cPtr.SetFeature(wallPermInner);
                        break;

                    case '*':
                        if (Game.RandomLessThan(100) < 75)
                        {
                            Game.PlaceObject(y, x, false, false);
                        }
                        else
                        {
                            Game.PlaceTrap(y, x);
                        }
                        break;

                    case '+':
                        PlaceSecretDoor(y, x);
                        break;

                    case '^':
                        Game.PlaceTrap(y, x);
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
                            Game.MonsterLevel = Game.Difficulty + 5;
                            Game.PlaceMonster(y, x, true, true);
                            Game.MonsterLevel = Game.Difficulty;
                            break;
                        }
                    case '@':
                        {
                            Game.MonsterLevel = Game.Difficulty + 11;
                            Game.PlaceMonster(y, x, true, true);
                            Game.MonsterLevel = Game.Difficulty;
                            break;
                        }
                    case '9':
                        {
                            Game.MonsterLevel = Game.Difficulty + 9;
                            Game.PlaceMonster(y, x, true, true);
                            Game.MonsterLevel = Game.Difficulty;
                            Game.ObjectLevel = Game.Difficulty + 7;
                            Game.PlaceObject(y, x, true, false);
                            Game.ObjectLevel = Game.Difficulty;
                            break;
                        }
                    case '8':
                        {
                            Game.MonsterLevel = Game.Difficulty + 40;
                            Game.PlaceMonster(y, x, true, true);
                            Game.MonsterLevel = Game.Difficulty;
                            Game.ObjectLevel = Game.Difficulty + 20;
                            Game.PlaceObject(y, x, true, true);
                            Game.ObjectLevel = Game.Difficulty;
                            break;
                        }
                    case ',':
                        {
                            if (Game.RandomLessThan(100) < 50)
                            {
                                Game.MonsterLevel = Game.Difficulty + 3;
                                Game.PlaceMonster(y, x, true, true);
                                Game.MonsterLevel = Game.Difficulty;
                            }
                            if (Game.RandomLessThan(100) < 50)
                            {
                                Game.ObjectLevel = Game.Difficulty + 7;
                                Game.PlaceObject(y, x, false, false);
                                Game.ObjectLevel = Game.Difficulty;
                            }
                            break;
                        }
                    case 'A':
                        {
                            Game.ObjectLevel = Game.Difficulty + 12;
                            Game.PlaceObject(y, x, true, false);
                            Game.ObjectLevel = Game.Difficulty;
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
            while (dummy < Game.SafeMaxAttempts)
            {
                y1 = Game.RandomSpread(y, yd);
                x1 = Game.RandomSpread(x, xd);
                dummy++;
                if (!Game.InBounds(y1, x1))
                {
                    continue;
                }
                break;
            }
            if (!Game.GridOpenNoItemOrCreature(y1, x1))
            {
                continue;
            }
            Game.PlaceTrap(y1, x1);
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
                (int y, int x) = Game.Scatter(y1, x1, d);
                if (!Game.GridPassableNoCreature(y, x))
                {
                    continue;
                }
                Game.MonsterLevel = Game.Difficulty + 2;
                Game.PlaceMonster(y, x, true, true);
                Game.MonsterLevel = Game.Difficulty;
            }
        }
    }

    protected void PlaceSecretDoor(int y, int x)
    {
        GridTile cPtr = Game.Map.Grid[y][x];
        cPtr.SetFeature(Game.SingletonRepository.Get<Tile>(nameof(SecretDoorTile)));
    }
}
