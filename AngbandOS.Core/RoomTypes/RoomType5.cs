﻿using AngbandOS.Core.MonsterRaces;
using AngbandOS.Core.MonsterSelectors;
using AngbandOS.Enumerations;

namespace AngbandOS.Core.RoomTypes
{
    internal class RoomType5 : RoomType
    {
        public override int Type => 5;
        public override void Build(SaveGame saveGame, int yval, int xval)
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
            if (tmp < 25 && Program.Rng.DieRoll(2) != 1)
            {
                int _templateRace;

                do
                {
                    _templateRace = Program.Rng.DieRoll(saveGame.MonsterRaces.Count - 2);
                } while ((saveGame.MonsterRaces[_templateRace].Flags1 & MonsterFlag1.Unique) != 0 ||
                         saveGame.MonsterRaces[_templateRace].Level + Program.Rng.DieRoll(5) >
                         saveGame.Difficulty + Program.Rng.DieRoll(5));
                if (Program.Rng.DieRoll(2) != 1 && saveGame.Difficulty >= 25 + Program.Rng.DieRoll(15))
                {
                    getMonNumHook = new SymbolMonsterSelector(saveGame.MonsterRaces[_templateRace].Character);
                }
                else
                {
                    getMonNumHook = new CloneMonsterSelector(saveGame.MonsterRaces[_templateRace]);
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
                if (Program.Rng.DieRoll(3) == 1)
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
                if (Program.Rng.DieRoll(3) == 1)
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
            saveGame.Level.DangerRating += 10;
            if (saveGame.Difficulty <= 40 && Program.Rng.DieRoll((saveGame.Difficulty * saveGame.Difficulty) + 50) < 300)
            {
                saveGame.Level.SpecialDanger = true;
            }
            for (y = yval - 2; y <= yval + 2; y++)
            {
                for (x = xval - 9; x <= xval + 9; x++)
                {
                    int rIdx = what[Program.Rng.RandomLessThan(64)];
                    MonsterRace race = saveGame.MonsterRaces[rIdx];
                    saveGame.Level.Monsters.PlaceMonsterAux(y, x, race, false, false, false);
                }
            }
        }

    }
}