﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.RoomTypes;

[Serializable]
internal class Type6RoomLayout : RoomLayout
{
    private Type6RoomLayout(SaveGame saveGame) : base(saveGame) { }
    public override int Type => 6;
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
        if (tmp < 20)
        {
            getMonNumHook = new OrcMonsterSelector();
        }
        else if (tmp < 40)
        {
            getMonNumHook = new TrollMonsterSelector();
        }
        else if (tmp < 55)
        {
            getMonNumHook = new GiantMonsterSelector();
        }
        else if (tmp < 70)
        {
            if (SaveGame.Rng.DieRoll(4) != 1)
            {
                int _templateRace;
                do
                {
                    _templateRace = SaveGame.Rng.DieRoll(SaveGame.SingletonRepository.MonsterRaces.Count - 2);
                } while (SaveGame.SingletonRepository.MonsterRaces[_templateRace].Unique ||
                         SaveGame.SingletonRepository.MonsterRaces[_templateRace].Level + SaveGame.Rng.DieRoll(5) >
                         SaveGame.Difficulty + SaveGame.Rng.DieRoll(5));
                getMonNumHook = new SymbolMonsterSelector(SaveGame.SingletonRepository.MonsterRaces[_templateRace].Symbol.Character);
            }
            else
            {
                if (SaveGame.Rng.DieRoll(2) == 1)
                {
                    getMonNumHook = new CultMonsterSelector();
                }
                else
                {
                    getMonNumHook = new ChapelMonsterSelector();
                }
            }
        }
        else if (tmp < 80)
        {
            switch (SaveGame.Rng.RandomLessThan(6))
            {
                case 0:
                    {
                        getMonNumHook = new AcidBreathingDragonMonsterSelector();
                        break;
                    }
                case 1:
                    {
                        getMonNumHook = new LightningBreathingDragonMonsterSelector();
                        break;
                    }
                case 2:
                    {
                        getMonNumHook = new FireBreathingDragonMonsterSelector();
                        break;
                    }
                case 3:
                    {
                        getMonNumHook = new ColdBreathingDragonMonsterSelector();
                        break;
                    }
                case 4:
                    {
                        getMonNumHook = new PoisonBreathingDragonMonsterSelector();
                        break;
                    }
                default:
                    {
                        getMonNumHook = new AnyBreathingDragonMonsterSelector();
                        break;
                    }
            }
        }
        else
        {
            getMonNumHook = new SymbolMonsterSelector('U');
        }
        for (i = 0; i < 16; i++)
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
        for (i = 0; i < 16 - 1; i++)
        {
            for (int j = 0; j < 16 - 1; j++)
            {
                int i1 = j;
                int i2 = j + 1;
                int p1 = SaveGame.SingletonRepository.MonsterRaces[what[i1]].Level;
                int p2 = SaveGame.SingletonRepository.MonsterRaces[what[i2]].Level;
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
        SaveGame.DangerRating += 10;
        if (SaveGame.Difficulty <= 40 &&
            SaveGame.Rng.DieRoll((SaveGame.Difficulty * SaveGame.Difficulty) + 50) < 300)
        {
            SaveGame.SpecialDanger = true;
        }
        for (x = xval - 9; x <= xval + 9; x++)
        {
            SaveGame.PlaceMonsterByIndex(yval - 2, x, what[0], false, false, false);
            SaveGame.PlaceMonsterByIndex(yval + 2, x, what[0], false, false, false);
        }
        for (y = yval - 1; y <= yval + 1; y++)
        {
            SaveGame.PlaceMonsterByIndex(y, xval - 9, what[0], false, false, false);
            SaveGame.PlaceMonsterByIndex(y, xval + 9, what[0], false, false, false);
            SaveGame.PlaceMonsterByIndex(y, xval - 8, what[1], false, false, false);
            SaveGame.PlaceMonsterByIndex(y, xval + 8, what[1], false, false, false);
            SaveGame.PlaceMonsterByIndex(y, xval - 7, what[1], false, false, false);
            SaveGame.PlaceMonsterByIndex(y, xval + 7, what[1], false, false, false);
            SaveGame.PlaceMonsterByIndex(y, xval - 6, what[2], false, false, false);
            SaveGame.PlaceMonsterByIndex(y, xval + 6, what[2], false, false, false);
            SaveGame.PlaceMonsterByIndex(y, xval - 5, what[2], false, false, false);
            SaveGame.PlaceMonsterByIndex(y, xval + 5, what[2], false, false, false);
            SaveGame.PlaceMonsterByIndex(y, xval - 4, what[3], false, false, false);
            SaveGame.PlaceMonsterByIndex(y, xval + 4, what[3], false, false, false);
            SaveGame.PlaceMonsterByIndex(y, xval - 3, what[3], false, false, false);
            SaveGame.PlaceMonsterByIndex(y, xval + 3, what[3], false, false, false);
            SaveGame.PlaceMonsterByIndex(y, xval - 2, what[4], false, false, false);
            SaveGame.PlaceMonsterByIndex(y, xval + 2, what[4], false, false, false);
        }
        for (x = xval - 1; x <= xval + 1; x++)
        {
            SaveGame.PlaceMonsterByIndex(yval + 1, x, what[5], false, false, false);
            SaveGame.PlaceMonsterByIndex(yval - 1, x, what[5], false, false, false);
        }
        SaveGame.PlaceMonsterByIndex(yval, xval + 1, what[6], false, false, false);
        SaveGame.PlaceMonsterByIndex(yval, xval - 1, what[6], false, false, false);
        SaveGame.PlaceMonsterByIndex(yval, xval, what[7], false, false, false);
    }
}