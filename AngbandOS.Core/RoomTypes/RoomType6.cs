﻿using AngbandOS.Core.MonsterSelectors;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.RoomTypes
{
    internal class RoomType6 : RoomType
    {
        public override int Type => 6;
        public override void Build(SaveGame saveGame, int yval, int xval)
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
                    cPtr = saveGame.Level.Grid[y][x];
                    cPtr.RevertToBackground();
                    cPtr.TileFlags.Set(GridTile.InRoom);
                }
            }
            for (y = y1 - 1; y <= y2 + 1; y++)
            {
                cPtr = saveGame.Level.Grid[y][x1 - 1];
                cPtr.SetFeature("WallOuter");
                cPtr = saveGame.Level.Grid[y][x2 + 1];
                cPtr.SetFeature("WallOuter");
            }
            for (x = x1 - 1; x <= x2 + 1; x++)
            {
                cPtr = saveGame.Level.Grid[y1 - 1][x];
                cPtr.SetFeature("WallOuter");
                cPtr = saveGame.Level.Grid[y2 + 1][x];
                cPtr.SetFeature("WallOuter");
            }
            y1 += 2;
            y2 -= 2;
            x1 += 2;
            x2 -= 2;
            for (y = y1 - 1; y <= y2 + 1; y++)
            {
                cPtr = saveGame.Level.Grid[y][x1 - 1];
                cPtr.SetFeature("WallInner");
                cPtr = saveGame.Level.Grid[y][x2 + 1];
                cPtr.SetFeature("WallInner");
            }
            for (x = x1 - 1; x <= x2 + 1; x++)
            {
                cPtr = saveGame.Level.Grid[y1 - 1][x];
                cPtr.SetFeature("WallInner");
                cPtr = saveGame.Level.Grid[y2 + 1][x];
                cPtr.SetFeature("WallInner");
            }
            switch (Program.Rng.DieRoll(4))
            {
                case 1:
                    PlaceSecretDoor(saveGame, y1 - 1, xval);
                    break;

                case 2:
                    PlaceSecretDoor(saveGame, y2 + 1, xval);
                    break;

                case 3:
                    PlaceSecretDoor(saveGame, yval, x1 - 1);
                    break;

                case 4:
                    PlaceSecretDoor(saveGame, yval, x2 + 1);
                    break;
            }
            int tmp = Program.Rng.DieRoll(saveGame.Difficulty);
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
                if (Program.Rng.DieRoll(4) != 1)
                {
                    int _templateRace;
                    do
                    {
                        _templateRace = Program.Rng.DieRoll(saveGame.MonsterRaces.Count - 2);
                    } while ((saveGame.MonsterRaces[_templateRace].Flags1 & MonsterFlag1.Unique) != 0 ||
                             saveGame.MonsterRaces[_templateRace].Level + Program.Rng.DieRoll(5) >
                             saveGame.Difficulty + Program.Rng.DieRoll(5));
                    getMonNumHook = new SymbolMonsterSelector(saveGame.MonsterRaces[_templateRace].Character);
                }
                else
                {
                    if (Program.Rng.DieRoll(2) == 1)
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
                uint _vaultAuxDragonMask4;
                switch (Program.Rng.RandomLessThan(6))
                {
                    case 0:
                        {
                            _vaultAuxDragonMask4 = MonsterFlag4.BreatheAcid;
                            break;
                        }
                    case 1:
                        {
                            _vaultAuxDragonMask4 = MonsterFlag4.BreatheLightning;
                            break;
                        }
                    case 2:
                        {
                            _vaultAuxDragonMask4 = MonsterFlag4.BreatheFire;
                            break;
                        }
                    case 3:
                        {
                            _vaultAuxDragonMask4 = MonsterFlag4.BreatheCold;
                            break;
                        }
                    case 4:
                        {
                            _vaultAuxDragonMask4 = MonsterFlag4.BreathePoison;
                            break;
                        }
                    default:
                        {
                            _vaultAuxDragonMask4 = MonsterFlag4.BreatheAcid | MonsterFlag4.BreatheLightning |
                                                   MonsterFlag4.BreatheFire | MonsterFlag4.BreatheCold | MonsterFlag4.BreathePoison;
                            break;
                        }
                }
                getMonNumHook = new DragonAuxMonsterSelector(_vaultAuxDragonMask4);
            }
            else
            {
                getMonNumHook = new SymbolMonsterSelector('U');
            }
            for (i = 0; i < 16; i++)
            {
                what[i] = saveGame.Level.Monsters.GetMonNum(saveGame.Difficulty + 10, getMonNumHook);
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
                    int p1 = saveGame.MonsterRaces[what[i1]].Level;
                    int p2 = saveGame.MonsterRaces[what[i2]].Level;
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
            saveGame.Level.DangerRating += 10;
            if (saveGame.Difficulty <= 40 &&
                Program.Rng.DieRoll((saveGame.Difficulty * saveGame.Difficulty) + 50) < 300)
            {
                saveGame.Level.SpecialDanger = true;
            }
            for (x = xval - 9; x <= xval + 9; x++)
            {
                saveGame.Level.Monsters.PlaceMonsterByIndex(yval - 2, x, what[0], false, false, false);
                saveGame.Level.Monsters.PlaceMonsterByIndex(yval + 2, x, what[0], false, false, false);
            }
            for (y = yval - 1; y <= yval + 1; y++)
            {
                saveGame.Level.Monsters.PlaceMonsterByIndex(y, xval - 9, what[0], false, false, false);
                saveGame.Level.Monsters.PlaceMonsterByIndex(y, xval + 9, what[0], false, false, false);
                saveGame.Level.Monsters.PlaceMonsterByIndex(y, xval - 8, what[1], false, false, false);
                saveGame.Level.Monsters.PlaceMonsterByIndex(y, xval + 8, what[1], false, false, false);
                saveGame.Level.Monsters.PlaceMonsterByIndex(y, xval - 7, what[1], false, false, false);
                saveGame.Level.Monsters.PlaceMonsterByIndex(y, xval + 7, what[1], false, false, false);
                saveGame.Level.Monsters.PlaceMonsterByIndex(y, xval - 6, what[2], false, false, false);
                saveGame.Level.Monsters.PlaceMonsterByIndex(y, xval + 6, what[2], false, false, false);
                saveGame.Level.Monsters.PlaceMonsterByIndex(y, xval - 5, what[2], false, false, false);
                saveGame.Level.Monsters.PlaceMonsterByIndex(y, xval + 5, what[2], false, false, false);
                saveGame.Level.Monsters.PlaceMonsterByIndex(y, xval - 4, what[3], false, false, false);
                saveGame.Level.Monsters.PlaceMonsterByIndex(y, xval + 4, what[3], false, false, false);
                saveGame.Level.Monsters.PlaceMonsterByIndex(y, xval - 3, what[3], false, false, false);
                saveGame.Level.Monsters.PlaceMonsterByIndex(y, xval + 3, what[3], false, false, false);
                saveGame.Level.Monsters.PlaceMonsterByIndex(y, xval - 2, what[4], false, false, false);
                saveGame.Level.Monsters.PlaceMonsterByIndex(y, xval + 2, what[4], false, false, false);
            }
            for (x = xval - 1; x <= xval + 1; x++)
            {
                saveGame.Level.Monsters.PlaceMonsterByIndex(yval + 1, x, what[5], false, false, false);
                saveGame.Level.Monsters.PlaceMonsterByIndex(yval - 1, x, what[5], false, false, false);
            }
            saveGame.Level.Monsters.PlaceMonsterByIndex(yval, xval + 1, what[6], false, false, false);
            saveGame.Level.Monsters.PlaceMonsterByIndex(yval, xval - 1, what[6], false, false, false);
            saveGame.Level.Monsters.PlaceMonsterByIndex(yval, xval, what[7], false, false, false);
        }
    }
}