// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.RoomTypes;

[Serializable]
internal class Type6RoomLayout : RoomLayout
{
    private Type6RoomLayout(Game game) : base(game) { }
    public override int Type => 6;
    public override int Dy1 => 0;
    public override int Dy2 => 1;
    public override int Dx1 => -1;
    public override int Dx2 => 1;
    public override int Level => 5;
    public override void Build(int yval, int xval)
    {
        int[] what = new int[16];
        int i, y, x;
        bool empty = false;
        GridTile cPtr;
        int y1 = yval - 4;
        int y2 = yval + 4;
        int x1 = xval - 11;
        int x2 = xval + 11;
        IMonsterFilter getMonNumHook;
        for (y = y1 - 1; y <= y2 + 1; y++)
        {
            for (x = x1 - 1; x <= x2 + 1; x++)
            {
                cPtr = Game.Map.Grid[y][x];
                cPtr.RevertToBackground();
                cPtr.InRoom = true;
            }
        }
        Tile wallOuterTile = Game.SingletonRepository.Tiles.Get(nameof(WallOuterTile));
        for (y = y1 - 1; y <= y2 + 1; y++)
        {
            cPtr = Game.Map.Grid[y][x1 - 1];
            cPtr.SetFeature(wallOuterTile);
            cPtr = Game.Map.Grid[y][x2 + 1];
            cPtr.SetFeature(wallOuterTile);
        }
        for (x = x1 - 1; x <= x2 + 1; x++)
        {
            cPtr = Game.Map.Grid[y1 - 1][x];
            cPtr.SetFeature(wallOuterTile);
            cPtr = Game.Map.Grid[y2 + 1][x];
            cPtr.SetFeature(wallOuterTile);
        }
        y1 += 2;
        y2 -= 2;
        x1 += 2;
        x2 -= 2;
        Tile wallInnerTile = Game.SingletonRepository.Tiles.Get(nameof(WallInnerTile));
        for (y = y1 - 1; y <= y2 + 1; y++)
        {
            cPtr = Game.Map.Grid[y][x1 - 1];
            cPtr.SetFeature(wallInnerTile);
            cPtr = Game.Map.Grid[y][x2 + 1];
            cPtr.SetFeature(wallInnerTile);
        }
        for (x = x1 - 1; x <= x2 + 1; x++)
        {
            cPtr = Game.Map.Grid[y1 - 1][x];
            cPtr.SetFeature(wallInnerTile);
            cPtr = Game.Map.Grid[y2 + 1][x];
            cPtr.SetFeature(wallInnerTile);
        }
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
        int tmp = Game.DieRoll(Game.Difficulty);
        if (tmp < 20)
        {
            getMonNumHook = Game.SingletonRepository.MonsterFilters.Get(nameof(OrcMonsterFilter));
        }
        else if (tmp < 40)
        {
            getMonNumHook = Game.SingletonRepository.MonsterFilters.Get(nameof(TrollMonsterFilter));
        }
        else if (tmp < 55)
        {
            getMonNumHook = Game.SingletonRepository.MonsterFilters.Get(nameof(GiantMonsterFilter));
        }
        else if (tmp < 70)
        {
            if (Game.DieRoll(4) != 1)
            {
                int _templateRace;
                do
                {
                    _templateRace = Game.DieRoll(Game.SingletonRepository.Get<MonsterRace>().Length - 2);
                } while (Game.SingletonRepository.Get<MonsterRace>(_templateRace).Unique || Game.SingletonRepository.Get<MonsterRace>(_templateRace).Level + Game.DieRoll(5) > Game.Difficulty + Game.DieRoll(5));
                getMonNumHook = new SymbolDynamicMonsterFilter(Game, Game.SingletonRepository.Get<MonsterRace>(_templateRace).Symbol.Character);
            }
            else
            {
                if (Game.DieRoll(2) == 1)
                {
                    getMonNumHook = Game.SingletonRepository.MonsterFilters.Get(nameof(CultMonsterFilter));
                }
                else
                {
                    getMonNumHook = Game.SingletonRepository.MonsterFilters.Get(nameof(ChapelMonsterFilter));
                }
            }
        }
        else if (tmp < 80)
        {
            switch (Game.RandomLessThan(6))
            {
                case 0:
                    {
                        getMonNumHook = Game.SingletonRepository.MonsterFilters.Get(nameof(AcidBreathingDragonMonsterFilter));
                        break;
                    }
                case 1:
                    {
                        getMonNumHook = Game.SingletonRepository.MonsterFilters.Get(nameof(LightningBreathingDragonMonsterFilter));
                        break;
                    }
                case 2:
                    {
                        getMonNumHook = Game.SingletonRepository.MonsterFilters.Get(nameof(FireBreathingDragonMonsterFilter));
                        break;
                    }
                case 3:
                    {
                        getMonNumHook = Game.SingletonRepository.MonsterFilters.Get(nameof(ColdBreathingDragonMonsterFilter));
                        break;
                    }
                case 4:
                    {
                        getMonNumHook = Game.SingletonRepository.MonsterFilters.Get(nameof(PoisonBreathingDragonMonsterFilter));
                        break;
                    }
                default:
                    {
                        getMonNumHook = Game.SingletonRepository.MonsterFilters.Get(nameof(AnyBreathingDragonMonsterFilter));
                        break;
                    }
            }
        }
        else
        {
            getMonNumHook = new SymbolDynamicMonsterFilter(Game, 'U');
        }
        for (i = 0; i < 16; i++)
        {
            what[i] = Game.GetMonNum(Game.Difficulty + 10, getMonNumHook);
            if (what[i] == 0)
            {
                empty = true;
            }
        }
        if (empty)
        {
            return;
        }
        for (i = 0; i < 16 - 1; i++)
        {
            for (int j = 0; j < 16 - 1; j++)
            {
                int i1 = j;
                int i2 = j + 1;
                int p1 = Game.SingletonRepository.Get<MonsterRace>(what[i1]).Level;
                int p2 = Game.SingletonRepository.Get<MonsterRace>(what[i2]).Level;
                if (p1 > p2)
                {
                    tmp = what[i1];
                    what[i1] = what[i2];
                    what[i2] = tmp;
                }
            }
        }
        for (i = 0; i < 8; i++)
        {
            what[i] = what[i * 2];
        }
        Game.DangerRating += 10;
        if (Game.Difficulty <= 40 &&
            Game.DieRoll((Game.Difficulty * Game.Difficulty) + 50) < 300)
        {
            Game.SpecialDanger = true;
        }
        for (x = xval - 9; x <= xval + 9; x++)
        {
            Game.PlaceMonsterByIndex(yval - 2, x, what[0], false, false, false);
            Game.PlaceMonsterByIndex(yval + 2, x, what[0], false, false, false);
        }
        for (y = yval - 1; y <= yval + 1; y++)
        {
            Game.PlaceMonsterByIndex(y, xval - 9, what[0], false, false, false);
            Game.PlaceMonsterByIndex(y, xval + 9, what[0], false, false, false);
            Game.PlaceMonsterByIndex(y, xval - 8, what[1], false, false, false);
            Game.PlaceMonsterByIndex(y, xval + 8, what[1], false, false, false);
            Game.PlaceMonsterByIndex(y, xval - 7, what[1], false, false, false);
            Game.PlaceMonsterByIndex(y, xval + 7, what[1], false, false, false);
            Game.PlaceMonsterByIndex(y, xval - 6, what[2], false, false, false);
            Game.PlaceMonsterByIndex(y, xval + 6, what[2], false, false, false);
            Game.PlaceMonsterByIndex(y, xval - 5, what[2], false, false, false);
            Game.PlaceMonsterByIndex(y, xval + 5, what[2], false, false, false);
            Game.PlaceMonsterByIndex(y, xval - 4, what[3], false, false, false);
            Game.PlaceMonsterByIndex(y, xval + 4, what[3], false, false, false);
            Game.PlaceMonsterByIndex(y, xval - 3, what[3], false, false, false);
            Game.PlaceMonsterByIndex(y, xval + 3, what[3], false, false, false);
            Game.PlaceMonsterByIndex(y, xval - 2, what[4], false, false, false);
            Game.PlaceMonsterByIndex(y, xval + 2, what[4], false, false, false);
        }
        for (x = xval - 1; x <= xval + 1; x++)
        {
            Game.PlaceMonsterByIndex(yval + 1, x, what[5], false, false, false);
            Game.PlaceMonsterByIndex(yval - 1, x, what[5], false, false, false);
        }
        Game.PlaceMonsterByIndex(yval, xval + 1, what[6], false, false, false);
        Game.PlaceMonsterByIndex(yval, xval - 1, what[6], false, false, false);
        Game.PlaceMonsterByIndex(yval, xval, what[7], false, false, false);
    }
}
