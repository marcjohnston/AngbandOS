﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.RoomTypes;

[Serializable]
internal class Type5RoomLayout : RoomLayout
{
    private Type5RoomLayout(SaveGame saveGame) : base(saveGame) { }
    public override int Type => 5;
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
        MonsterSelector getMonNumHook;
        for (y = y1 - 1; y <= y2 + 1; y++)
        {
            for (x = x1 - 1; x <= x2 + 1; x++)
            {
                cPtr = SaveGame.Grid[y][x];
                cPtr.RevertToBackground();
                cPtr.TileFlags.Set(GridTile.InRoom);
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
        int tmp = SaveGame.Rng.DieRoll(SaveGame.Difficulty);
        if (tmp < 25 && SaveGame.Rng.DieRoll(2) != 1)
        {
            int _templateRace;

            do
            {
                _templateRace = SaveGame.Rng.DieRoll(SaveGame.SingletonRepository.MonsterRaces.Count - 2);
            } while (SaveGame.SingletonRepository.MonsterRaces[_templateRace].Unique ||
                     SaveGame.SingletonRepository.MonsterRaces[_templateRace].Level + SaveGame.Rng.DieRoll(5) >
                     SaveGame.Difficulty + SaveGame.Rng.DieRoll(5));
            if (SaveGame.Rng.DieRoll(2) != 1 && SaveGame.Difficulty >= 25 + SaveGame.Rng.DieRoll(15))
            {
                getMonNumHook = new SymbolMonsterSelector(SaveGame.SingletonRepository.MonsterRaces[_templateRace].Symbol.Character);
            }
            else
            {
                getMonNumHook = new CloneMonsterSelector(SaveGame.SingletonRepository.MonsterRaces[_templateRace]);
            }
        }
        else if (tmp < 25)
        {
            getMonNumHook = new JellyMonsterSelector();
        }
        else if (tmp < 50)
        {
            getMonNumHook = new TreasureMonsterSelector();
        }
        else if (tmp < 65)
        {
            if (SaveGame.Rng.DieRoll(3) == 1)
            {
                getMonNumHook = new KennelMonsterSelector();
            }
            else
            {
                getMonNumHook = new AnimalMonsterSelector();
            }
        }
        else
        {
            if (SaveGame.Rng.DieRoll(3) == 1)
            {
                getMonNumHook = new ChapelMonsterSelector();
            }
            else
            {
                getMonNumHook = new UndeadMonsterSelector();
            }
        }
        for (int i = 0; i < 64; i++)
        {
            what[i] = SaveGame.GetMonNum(SaveGame.Difficulty + 10, getMonNumHook);
            if (what[i] == 0)
            {
                empty = true;
            }
        }
        if (empty)
        {
            return;
        }
        SaveGame.DangerRating += 10;
        if (SaveGame.Difficulty <= 40 && SaveGame.Rng.DieRoll((SaveGame.Difficulty * SaveGame.Difficulty) + 50) < 300)
        {
            SaveGame.SpecialDanger = true;
        }
        for (y = yval - 2; y <= yval + 2; y++)
        {
            for (x = xval - 9; x <= xval + 9; x++)
            {
                int rIdx = what[SaveGame.Rng.RandomLessThan(64)];
                MonsterRace race = SaveGame.SingletonRepository.MonsterRaces[rIdx];
                SaveGame.PlaceMonsterAux(y, x, race, false, false, false);
            }
        }
    }

}