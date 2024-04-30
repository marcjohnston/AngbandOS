// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.RoomTypes;

[Serializable]
internal class Type5RoomLayout : RoomLayout
{
    private Type5RoomLayout(Game game) : base(game) { }
    public override int Type => 5;
    public override int Dy1 => 0;
    public override int Dy2 => 0;
    public override int Dx1 => -1;
    public override int Dx2 => 1;
    public override int Level => 5;
    public override void Build(int yval, int xval)
    {
        int y, x;
        int[] what = new int[64];
        GridTile cPtr;
        bool empty = false;
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
        Tile wallOuterTile = Game.SingletonRepository.Get<Tile>(nameof(WallOuterTile));
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
        Tile wallInnerTile = Game.SingletonRepository.Get<Tile>(nameof(WallInnerTile));
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
        if (tmp < 25 && Game.DieRoll(2) != 1)
        {
            int _templateRace;

            do
            {
                _templateRace = Game.DieRoll(Game.SingletonRepository.Get<MonsterRace>().Length - 2);
            } while (Game.SingletonRepository.Get<MonsterRace>(_templateRace).Unique || Game.SingletonRepository.Get<MonsterRace>(_templateRace).Level + Game.DieRoll(5) > Game.Difficulty + Game.DieRoll(5));
            if (Game.DieRoll(2) != 1 && Game.Difficulty >= 25 + Game.DieRoll(15))
            {
                getMonNumHook = new SymbolDynamicMonsterFilter(Game, Game.SingletonRepository.Get<MonsterRace>(_templateRace).Symbol.Character);
            }
            else
            {
                getMonNumHook = new CloneDynamicMonsterFilter(Game, Game.SingletonRepository.Get<MonsterRace>(_templateRace));
            }
        }
        else if (tmp < 25)
        {
            getMonNumHook = Game.SingletonRepository.Get<MonsterFilter>(nameof(JellyMonsterFilter));
        }
        else if (tmp < 50)
        {
            getMonNumHook = Game.SingletonRepository.Get<MonsterFilter>(nameof(TreasureMonsterFilter));
        }
        else if (tmp < 65)
        {
            if (Game.DieRoll(3) == 1)
            {
                getMonNumHook = Game.SingletonRepository.Get<MonsterFilter>(nameof(KennelMonsterFilter));
            }
            else
            {
                getMonNumHook = Game.SingletonRepository.Get<MonsterFilter>(nameof(AnimalMonsterFilter));
            }
        }
        else
        {
            if (Game.DieRoll(3) == 1)
            {
                getMonNumHook = Game.SingletonRepository.Get<MonsterFilter>(nameof(ChapelMonsterFilter));
            }
            else
            {
                getMonNumHook = Game.SingletonRepository.Get<MonsterFilter>(nameof(UndeadMonsterFilter));
            }
        }
        for (int i = 0; i < 64; i++)
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
        Game.DangerRating += 10;
        if (Game.Difficulty <= 40 && Game.DieRoll((Game.Difficulty * Game.Difficulty) + 50) < 300)
        {
            Game.SpecialDanger = true;
        }
        for (y = yval - 2; y <= yval + 2; y++)
        {
            for (x = xval - 9; x <= xval + 9; x++)
            {
                int rIdx = what[Game.RandomLessThan(64)];
                MonsterRace race = Game.SingletonRepository.Get<MonsterRace>(rIdx);
                Game.PlaceMonsterAux(y, x, race, false, false, false);
            }
        }
    }

}
