// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.RoomLayouts;

internal class Type6RoomLayout : RoomLayout
{
    private Type6RoomLayout(Game game) : base(game) { }
    public override int Type => 6;
    public override int Dy1 => 0;
    public override int Dy2 => 1;
    public override int Dx1 => -1;
    public override int Dx2 => 1;
    public override int Level => 5;
    public override void Build(int objectLevel, int yval, int xval)
    {
        int i, y, x;
        GridTile cPtr;
        int y1 = yval - 4;
        int y2 = yval + 4;
        int x1 = xval - 11;
        int x2 = xval + 11;
        MonsterRaceFilter monsterRaceFilter;
        for (y = y1 - 1; y <= y2 + 1; y++)
        {
            for (x = x1 - 1; x <= x2 + 1; x++)
            {
                cPtr = Game.Grid[y][x];
                cPtr.RevertToBackground();
                cPtr.InRoom = true;
            }
        }
        Tile wallOuterTile = Game.SingletonRepository.Get<Tile>(nameof(WallOuterTile));
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
        Tile wallInnerTile = Game.SingletonRepository.Get<Tile>(nameof(WallInnerTile));
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
            monsterRaceFilter = Game.SingletonRepository.Get<MonsterRaceFilter>(nameof(OrcMonsterRaceFilter));
        }
        else if (tmp < 40)
        {
            monsterRaceFilter = Game.SingletonRepository.Get<MonsterRaceFilter>(nameof(TrollMonsterRaceFilter));
        }
        else if (tmp < 55)
        {
            monsterRaceFilter = Game.SingletonRepository.Get<MonsterRaceFilter>(nameof(GiantMonsterRaceFilter));
        }
        else if (tmp < 70)
        {
            if (Game.DieRoll(4) != 1)
            {
                int _templateRace;
                do
                {
                    _templateRace = Game.DieRoll(Game.SingletonRepository.Count<MonsterRace>() - 2);
                } while (Game.SingletonRepository.Get<MonsterRace>(_templateRace).Unique || Game.SingletonRepository.Get<MonsterRace>(_templateRace).Level + Game.DieRoll(5) > Game.Difficulty + Game.DieRoll(5));
                monsterRaceFilter = new SymbolSystemMonsterRaceFilter(Game, Game.SingletonRepository.Get<MonsterRace>(_templateRace).Symbol.Character);
            }
            else
            {
                if (Game.DieRoll(2) == 1)
                {
                    monsterRaceFilter = Game.SingletonRepository.Get<MonsterRaceFilter>(nameof(CultMonsterRaceFilter));
                }
                else
                {
                    monsterRaceFilter = Game.SingletonRepository.Get<MonsterRaceFilter>(nameof(ChapelMonsterRaceFilter));
                }
            }
        }
        else if (tmp < 80)
        {
            switch (Game.RandomLessThan(6))
            {
                case 0:
                    {
                        monsterRaceFilter = Game.SingletonRepository.Get<MonsterRaceFilter>(nameof(AcidBreathingDragonMonsterRaceFilter));
                        break;
                    }
                case 1:
                    {
                        monsterRaceFilter = Game.SingletonRepository.Get<MonsterRaceFilter>(nameof(LightningBreathingDragonMonsterRaceFilter));
                        break;
                    }
                case 2:
                    {
                        monsterRaceFilter = Game.SingletonRepository.Get<MonsterRaceFilter>(nameof(FireBreathingDragonMonsterRaceFilter));
                        break;
                    }
                case 3:
                    {
                        monsterRaceFilter = Game.SingletonRepository.Get<MonsterRaceFilter>(nameof(ColdBreathingDragonMonsterRaceFilter));
                        break;
                    }
                case 4:
                    {
                        monsterRaceFilter = Game.SingletonRepository.Get<MonsterRaceFilter>(nameof(PoisonBreathingDragonMonsterRaceFilter));
                        break;
                    }
                default:
                    {
                        monsterRaceFilter = Game.SingletonRepository.Get<MonsterRaceFilter>(nameof(AnyBreathingDragonMonsterRaceFilter));
                        break;
                    }
            }
        }
        else
        {
            monsterRaceFilter = new SymbolSystemMonsterRaceFilter(Game, 'U');
        }
        int[] monsterRaceIndexes = new int[16];
        for (i = 0; i < 16; i++)
        {
            MonsterRace? monsterRace = Game.GetMonsterRace(Game.Difficulty + 10, monsterRaceFilter);
            if (monsterRace is null)
            {
                return;
            }
            monsterRaceIndexes[i] = monsterRace.Index;
        }
        for (i = 0; i < 16 - 1; i++)
        {
            for (int j = 0; j < 16 - 1; j++)
            {
                int i1 = j;
                int i2 = j + 1;
                int p1 = Game.SingletonRepository.Get<MonsterRace>(monsterRaceIndexes[i1]).Level;
                int p2 = Game.SingletonRepository.Get<MonsterRace>(monsterRaceIndexes[i2]).Level;
                if (p1 > p2)
                {
                    tmp = monsterRaceIndexes[i1];
                    monsterRaceIndexes[i1] = monsterRaceIndexes[i2];
                    monsterRaceIndexes[i2] = tmp;
                }
            }
        }
        for (i = 0; i < 8; i++)
        {
            monsterRaceIndexes[i] = monsterRaceIndexes[i * 2];
        }
        Game.DangerRating += 10;
        if (Game.Difficulty <= 40 &&
            Game.DieRoll((Game.Difficulty * Game.Difficulty) + 50) < 300)
        {
            Game.SpecialDanger = true;
        }
        for (x = xval - 9; x <= xval + 9; x++)
        {
            Game.PlaceMonsterByIndex(yval - 2, x, monsterRaceIndexes[0], false, false, false);
            Game.PlaceMonsterByIndex(yval + 2, x, monsterRaceIndexes[0], false, false, false);
        }
        for (y = yval - 1; y <= yval + 1; y++)
        {
            Game.PlaceMonsterByIndex(y, xval - 9, monsterRaceIndexes[0], false, false, false);
            Game.PlaceMonsterByIndex(y, xval + 9, monsterRaceIndexes[0], false, false, false);
            Game.PlaceMonsterByIndex(y, xval - 8, monsterRaceIndexes[1], false, false, false);
            Game.PlaceMonsterByIndex(y, xval + 8, monsterRaceIndexes[1], false, false, false);
            Game.PlaceMonsterByIndex(y, xval - 7, monsterRaceIndexes[1], false, false, false);
            Game.PlaceMonsterByIndex(y, xval + 7, monsterRaceIndexes[1], false, false, false);
            Game.PlaceMonsterByIndex(y, xval - 6, monsterRaceIndexes[2], false, false, false);
            Game.PlaceMonsterByIndex(y, xval + 6, monsterRaceIndexes[2], false, false, false);
            Game.PlaceMonsterByIndex(y, xval - 5, monsterRaceIndexes[2], false, false, false);
            Game.PlaceMonsterByIndex(y, xval + 5, monsterRaceIndexes[2], false, false, false);
            Game.PlaceMonsterByIndex(y, xval - 4, monsterRaceIndexes[3], false, false, false);
            Game.PlaceMonsterByIndex(y, xval + 4, monsterRaceIndexes[3], false, false, false);
            Game.PlaceMonsterByIndex(y, xval - 3, monsterRaceIndexes[3], false, false, false);
            Game.PlaceMonsterByIndex(y, xval + 3, monsterRaceIndexes[3], false, false, false);
            Game.PlaceMonsterByIndex(y, xval - 2, monsterRaceIndexes[4], false, false, false);
            Game.PlaceMonsterByIndex(y, xval + 2, monsterRaceIndexes[4], false, false, false);
        }
        for (x = xval - 1; x <= xval + 1; x++)
        {
            Game.PlaceMonsterByIndex(yval + 1, x, monsterRaceIndexes[5], false, false, false);
            Game.PlaceMonsterByIndex(yval - 1, x, monsterRaceIndexes[5], false, false, false);
        }
        Game.PlaceMonsterByIndex(yval, xval + 1, monsterRaceIndexes[6], false, false, false);
        Game.PlaceMonsterByIndex(yval, xval - 1, monsterRaceIndexes[6], false, false, false);
        Game.PlaceMonsterByIndex(yval, xval, monsterRaceIndexes[7], false, false, false);
    }
}
