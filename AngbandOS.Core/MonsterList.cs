// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.Enumerations;

using AngbandOS.Core.Interface;
using AngbandOS.Core;
using AngbandOS.Core.MonsterRaces;
using AngbandOS.Core.MonsterSelectors;

namespace AngbandOS
{
    [Serializable]
    internal class MonsterList
    {
        public int CurrentlyActingMonster;
        public MonsterSelector? DunBias = null; // The dungeon does not have a bias for monsters.
        public int NumRepro;
        public bool RepairMonsters;
        public bool ShimmerMonsters;

        private readonly Level _level;
        private readonly Monster[] _monsters;
        private int _hackMIdxIi;
        private readonly SaveGame SaveGame;

        public MonsterList(SaveGame saveGame, Level level)
        {
            SaveGame = saveGame;
            _level = level;
            _monsters = new Monster[Constants.MaxMIdx];
            for (int j = 0; j < Constants.MaxMIdx; j++)
            {
                _monsters[j] = new Monster(saveGame);
            }
        }

        public Monster this[int index] => _monsters[index];

        /// <summary>
        /// Returns the index of this monster in the monster list.  This method is provided for backwards compatability and should NOT be used.  Will be deleted when no longer needed.
        /// </summary>
        /// <param name="monster"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public int GetMonsterIndex(Monster monster) // TODO: Needs to be removed.
        {
            for (int i = 0; i < _monsters.Length; i++)
            {
                if (_monsters[i] == monster)
                    return i;
            }
            throw new Exception("Internal error monster not found for get monster index.");
        }
        public bool AllocHorde(int y, int x)
        {
            MonsterRace rPtr = null;
            int attempts = 1000;
            while (--attempts != 0)
            {
                int rIdx = GetMonNum(_level.MonsterLevel, null);
                if (rIdx == 0)
                {
                    return false;
                }
                rPtr = SaveGame.MonsterRaces[rIdx];
                if ((rPtr.Flags1 & MonsterFlag1.Unique) == 0 && (rPtr.Flags1 & MonsterFlag1.EscortsGroup) == 0)
                {
                    break;
                }
            }
            if (attempts < 1)
            {
                return false;
            }
            attempts = 1000;
            while (--attempts == 0)
            {
                if (PlaceMonsterAux(y, x, rPtr, false, false, false))
                {
                    break;
                }
            }
            if (attempts < 1)
            {
                return false;
            }
            Monster mPtr = _monsters[_hackMIdxIi];
            for (attempts = Program.Rng.DieRoll(10) + 5; attempts != 0; attempts--)
            {
                SummonSpecific(mPtr.MapY, mPtr.MapX, SaveGame.Difficulty, new KinMonsterSelector(rPtr.Character));
            }
            return true;
        }

        public void AllocMonster(int dis, bool slp)
        {
            int y = 0;
            int x = 0;
            int attemptsLeft = 10000;
            while (attemptsLeft != 0)
            {
                y = Program.Rng.RandomLessThan(_level.CurHgt);
                x = Program.Rng.RandomLessThan(_level.CurWid);
                if (!_level.GridOpenNoItemOrCreature(y, x))
                {
                    continue;
                }
                if (_level.Distance(y, x, SaveGame.Player.MapY, SaveGame.Player.MapX) > dis)
                {
                    break;
                }
                attemptsLeft--;
            }
            if (attemptsLeft == 0)
            {
                return;
            }
            if (Program.Rng.DieRoll(5000) <= SaveGame.Difficulty)
            {
                if (AllocHorde(y, x))
                {
                }
            }
            else
            {
                if (DunBias != null && Program.Rng.RandomBetween(1, 10) > 6)
                {
                    if (SummonSpecific(y, x, SaveGame.Difficulty, DunBias))
                    {
                    }
                }
                else
                {
                    if (PlaceMonster(y, x, slp, true))
                    {
                    }
                }
            }
        }

        public void CompactMonsters(int size)
        {
            int i, num, cnt;
            if (size != 0)
            {
                SaveGame.MsgPrint("Compacting monsters...");
            }
            for (num = 0, cnt = 1; num < size; cnt++)
            {
                int curLev = 5 * cnt;
                int curDis = 5 * (20 - cnt);
                for (i = 1; i < _level.MMax; i++)
                {
                    Monster mPtr = _monsters[i];
                    MonsterRace rPtr = mPtr.Race;
                    if (mPtr.Race == null)
                    {
                        continue;
                    }
                    if (rPtr.Level > curLev)
                    {
                        continue;
                    }
                    if (curDis > 0 && mPtr.DistanceFromPlayer < curDis)
                    {
                        continue;
                    }
                    int chance = 90;
                    if ((rPtr.Flags1 & MonsterFlag1.Unique) != 0)
                    {
                        chance = 99;
                    }
                    if ((rPtr.Flags1 & MonsterFlag1.Guardian) != 0 && cnt < 1000)
                    {
                        chance = 100;
                    }
                    if (Program.Rng.RandomLessThan(100) < chance)
                    {
                        continue;
                    }
                    DeleteMonsterByIndex(i, true);
                    num++;
                }
            }
            for (i = _level.MMax - 1; i >= 1; i--)
            {
                Monster mPtr = _monsters[i];
                if (mPtr.Race != null)
                {
                    continue;
                }
                CompactMonstersAux(_level.MMax - 1, i);
                _level.MMax--;
            }
        }

        public bool DamageMonster(int mIdx, int dam, out bool fear, string note)
        {
            fear = false;
            Monster mPtr = _monsters[mIdx];
            MonsterRace rPtr = mPtr.Race;
            if (SaveGame.TrackedMonsterIndex == mIdx)
            {
                SaveGame.Player.RedrawNeeded.Set(RedrawFlag.PrHealth);
            }
            mPtr.SleepLevel = 0;
            mPtr.Health -= dam;
            if (mPtr.Health < 0)
            {
                string mName = mPtr.MonsterDesc(0);
                if ((rPtr.Flags3 & MonsterFlag3.GreatOldOne) != 0 && Program.Rng.DieRoll(2) == 1)
                {
                    SaveGame.MsgPrint($"{mName} retreats into another dimension!");
                    if (Program.Rng.DieRoll(5) == 1)
                    {
                        int curses = 1 + Program.Rng.DieRoll(3);
                        SaveGame.MsgPrint("Nyarlathotep puts a terrible curse on you!");
                        SaveGame.Player.CurseEquipment(100, 50);
                        do
                        {
                            SaveGame.ActivateDreadCurse();
                        } while (--curses != 0);
                    }
                }
                SaveGame.PlaySound(SoundEffect.MonsterDies);
                if (string.IsNullOrEmpty(note) == false)
                {
                    SaveGame.MsgPrint($"{mName}{note}");
                }
                else if (!mPtr.IsVisible)
                {
                    SaveGame.MsgPrint($"You have killed {mName}.");
                }
                else if ((rPtr.Flags3 & MonsterFlag3.Demon) != 0 || (rPtr.Flags3 & MonsterFlag3.Undead) != 0 ||
                         (rPtr.Flags3 & MonsterFlag3.Cthuloid) != 0 || (rPtr.Flags2 & MonsterFlag2.Stupid) != 0 ||
                         (rPtr.Flags3 & MonsterFlag3.Nonliving) != 0 || "Evg".Contains(rPtr.Character.ToString()))
                {
                    SaveGame.MsgPrint($"You have destroyed {mName}.");
                }
                else
                {
                    SaveGame.MsgPrint($"You have slain {mName}.");
                }
                int div = 10 * SaveGame.Player.MaxLevelGained;
                if (rPtr.Knowledge.RPkills >= 19)
                {
                    div *= 2;
                }
                if (rPtr.Knowledge.RPkills == 0)
                {
                    div /= 3;
                }
                if (rPtr.Knowledge.RPkills == 1)
                {
                    div /= 2;
                }
                if (rPtr.Knowledge.RPkills == 2)
                {
                    div /= 2;
                }
                if (div < 1)
                {
                    div = 1;
                }
                int newExp = rPtr.Mexp * rPtr.Level * 10 / div;
                int newExpFrac = (rPtr.Mexp * rPtr.Level % div * 0x10000 / div) + SaveGame.Player.FractionalExperiencePoints;
                if (newExpFrac >= 0x10000)
                {
                    newExp++;
                    SaveGame.Player.FractionalExperiencePoints = newExpFrac - 0x10000;
                }
                else
                {
                    SaveGame.Player.FractionalExperiencePoints = newExpFrac;
                }
                SaveGame.Player.GainExperience(newExp);
                SaveGame.MonsterDeath(mIdx);
                if ((rPtr.Flags1 & MonsterFlag1.Unique) != 0)
                {
                    rPtr.MaxNum = 0;
                }
                if (mPtr.IsVisible || (rPtr.Flags1 & MonsterFlag1.Unique) != 0)
                {
                    if (rPtr.Knowledge.RPkills < int.MaxValue)
                    {
                        rPtr.Knowledge.RPkills++;
                    }
                    if (rPtr.Knowledge.RTkills < int.MaxValue)
                    {
                        rPtr.Knowledge.RTkills++;
                    }
                }
                DeleteMonsterByIndex(mIdx, true);
                fear = false;
                return true;
            }
            if (mPtr.FearLevel != 0 && dam > 0)
            {
                int tmp = Program.Rng.DieRoll(dam);
                if (tmp < mPtr.FearLevel)
                {
                    mPtr.FearLevel -= tmp;
                }
                else
                {
                    mPtr.FearLevel = 0;
                    fear = false;
                }
            }
            if (mPtr.FearLevel == 0 && (rPtr.Flags3 & MonsterFlag3.ImmuneFear) == 0)
            {
                int percentage = 100 * mPtr.Health / mPtr.MaxHealth;
                if ((percentage <= 10 && Program.Rng.RandomLessThan(10) < percentage) ||
                    (dam >= mPtr.Health && Program.Rng.RandomLessThan(100) < 80))
                {
                    fear = true;
                    mPtr.FearLevel = Program.Rng.DieRoll(10) +
                                   (dam >= mPtr.Health && percentage > 7 ? 20 : (11 - percentage) * 5);
                }
            }
            return false;
        }

        public void DeleteMonsterByIndex(int i, bool visibly)
        {
            Monster mPtr = _monsters[i];
            MonsterRace rPtr = mPtr.Race;
            if (rPtr == null)
            {
                return;
            }
            int nextOIdx;
            int y = mPtr.MapY;
            int x = mPtr.MapX;
            rPtr.CurNum--;
            if ((rPtr.Flags2 & MonsterFlag2.Multiply) != 0)
            {
                NumRepro--;
            }
            if (i == SaveGame.TargetWho)
            {
                SaveGame.TargetWho = 0;
            }
            if (i == SaveGame.TrackedMonsterIndex)
            {
                SaveGame.HealthTrack(0);
            }
            _level.Grid[y][x].MonsterIndex = 0;
            for (int thisOIdx = mPtr.FirstHeldItemIndex; thisOIdx != 0; thisOIdx = nextOIdx)
            {
                Item oPtr = _level.Items[thisOIdx];
                nextOIdx = oPtr.NextInStack;
                oPtr.HoldingMonsterIndex = 0;
                _level.DeleteObjectIdx(thisOIdx);
            }
            _monsters[i] = new Monster(SaveGame);
            _level.MCnt--;
            if (visibly)
            {
                _level.RedrawSingleLocation(y, x);
            }
        }

        /// <summary>
        /// Returns the index of a monster.
        /// </summary>
        /// <param name="level"></param>
        /// <param name="getMonNumHook"></param>
        /// <returns></returns>
        public int GetMonNum(int level, MonsterSelector? getMonNumHook)
        {
            int i, j;
            AllocationEntry[] table = SaveGame.AllocRaceTable;
            if (level > 0)
            {
                if (Program.Rng.RandomLessThan(Constants.NastyMon) == 0)
                {
                    int d = (level / 4) + 2;
                    level += d < 5 ? d : 5;
                }
                if (Program.Rng.RandomLessThan(Constants.NastyMon) == 0)
                {
                    int d = (level / 4) + 2;
                    level += d < 5 ? d : 5;
                }
            }
            int total = 0;
            for (i = 0; i < SaveGame.AllocRaceSize; i++)
            {
                if (table[i].Level > level)
                {
                    break;
                }
                table[i].FinalProbability = 0;
                if (level > 0 && table[i].Level <= 0)
                {
                    continue;
                }
                int rIdx = table[i].Index;
                MonsterRace rPtr = SaveGame.MonsterRaces[rIdx];

                // Do not allow more than 1 unique of this type to be created.
                if ((rPtr.Flags1 & MonsterFlag1.Unique) != 0 && rPtr.CurNum >= rPtr.MaxNum)
                {
                    continue;
                }

                if (getMonNumHook == null || getMonNumHook.Matches(SaveGame, rPtr))
                {
                    table[i].FinalProbability = table[i].BaseProbability;
                }
                else
                {
                    table[i].FinalProbability = 0;
                }

                total += table[i].FinalProbability;
            }
            if (total <= 0)
            {
                return 0;
            }
            long value = Program.Rng.RandomLessThan(total);
            for (i = 0; i < SaveGame.AllocRaceSize; i++)
            {
                if (value < table[i].FinalProbability)
                {
                    break;
                }
                value -= table[i].FinalProbability;
            }
            int p = Program.Rng.RandomLessThan(100);
            if (p < 60)
            {
                j = i;
                value = Program.Rng.RandomLessThan(total);
                for (i = 0; i < SaveGame.AllocRaceSize; i++)
                {
                    if (value < table[i].FinalProbability)
                    {
                        break;
                    }
                    value -= table[i].FinalProbability;
                }
                if (table[i].Level < table[j].Level)
                {
                    i = j;
                }
            }
            if (p < 10)
            {
                j = i;
                value = Program.Rng.RandomLessThan(total);
                for (i = 0; i < SaveGame.AllocRaceSize; i++)
                {
                    if (value < table[i].FinalProbability)
                    {
                        break;
                    }
                    value -= table[i].FinalProbability;
                }
                if (table[i].Level < table[j].Level)
                {
                    i = j;
                }
            }
            return table[i].Index;
        }

        public List<Monster> GetPets()
        {
            List<Monster> list = new List<Monster>();
            foreach (Monster monster in _monsters)
            {
                if ((monster.Mind & Constants.SmFriendly) != 0)
                {
                    list.Add(monster);
                }
            }
            return list;
        }

        public void LoreDoProbe(int mIdx)
        {
            Monster mPtr = _monsters[mIdx];
            MonsterRace rPtr = mPtr.Race;
            var knowledge = rPtr.Knowledge;
            if (rPtr.Attacks != null)
            {
                for (var m = 0; m < rPtr.Attacks.Length; m++)
                {
                    if (rPtr.Attacks[m].Effect != null || rPtr.Attacks[m].Method != 0)
                    {
                        knowledge.RBlows[m] = Constants.MaxUchar;
                    }
                }
            }
            knowledge.RProbed = true;
            knowledge.RWake = Constants.MaxUchar;
            knowledge.RIgnore = Constants.MaxUchar;
            knowledge.RDropItem = ((rPtr.Flags1 & MonsterFlag1.Drop_4D2) != 0 ? 8 : 0) +
                                  ((rPtr.Flags1 & MonsterFlag1.Drop_3D2) != 0 ? 6 : 0) +
                                  ((rPtr.Flags1 & MonsterFlag1.Drop_2D2) != 0 ? 4 : 0) +
                                  ((rPtr.Flags1 & MonsterFlag1.Drop_1D2) != 0 ? 2 : 0) +
                                  ((rPtr.Flags1 & MonsterFlag1.Drop90) != 0 ? 1 : 0) +
                                  ((rPtr.Flags1 & MonsterFlag1.Drop60) != 0 ? 1 : 0);
            knowledge.RDropGold = knowledge.RDropItem;
            if ((rPtr.Flags1 & MonsterFlag1.OnlyDropGold) != 0)
            {
                knowledge.RDropItem = 0;
            }
            if ((rPtr.Flags1 & MonsterFlag1.OnlyDropItem) != 0)
            {
                knowledge.RDropGold = 0;
            }
            knowledge.RCastInate = Constants.MaxUchar;
            knowledge.RCastSpell = Constants.MaxUchar;
            knowledge.RFlags1 = rPtr.Flags1;
            knowledge.RFlags2 = rPtr.Flags2;
            knowledge.RFlags3 = rPtr.Flags3;
            knowledge.RFlags4 = rPtr.Flags4;
            knowledge.RFlags5 = rPtr.Flags5;
            knowledge.RFlags6 = rPtr.Flags6;
        }

        public void LoreTreasure(int mIdx, int numItem, int numGold)
        {
            Monster mPtr = _monsters[mIdx];
            MonsterRace rPtr = mPtr.Race;
            if (numItem > rPtr.Knowledge.RDropItem)
            {
                rPtr.Knowledge.RDropItem = numItem;
            }
            if (numGold > rPtr.Knowledge.RDropGold)
            {
                rPtr.Knowledge.RDropGold = numGold;
            }
            if ((rPtr.Flags1 & MonsterFlag1.DropGood) != 0)
            {
                rPtr.Knowledge.RFlags1 |= MonsterFlag1.DropGood;
            }
            if ((rPtr.Flags1 & MonsterFlag1.DropGreat) != 0)
            {
                rPtr.Knowledge.RFlags1 |= MonsterFlag1.DropGreat;
            }
        }

        public void MessagePain(int mIdx, int dam)
        {
            Monster mPtr = _monsters[mIdx];
            MonsterRace rPtr = mPtr.Race;
            string mName = mPtr.MonsterDesc(0);
            if (dam == 0)
            {
                SaveGame.MsgPrint($"{mName} is unharmed.");
                return;
            }
            long newhp = mPtr.Health;
            long oldhp = newhp + dam;
            long tmp = newhp * 100L / oldhp;
            int percentage = (int)tmp;
            if ("jmvQ".Contains(rPtr.Character.ToString()))
            {
                if (percentage > 95)
                {
                    SaveGame.MsgPrint($"{mName} barely notices.");
                }
                else if (percentage > 75)
                {
                    SaveGame.MsgPrint($"{mName} flinches.");
                }
                else if (percentage > 50)
                {
                    SaveGame.MsgPrint($"{mName} squelches.");
                }
                else if (percentage > 35)
                {
                    SaveGame.MsgPrint($"{mName} quivers in pain.");
                }
                else if (percentage > 20)
                {
                    SaveGame.MsgPrint($"{mName} writhes about.");
                }
                else if (percentage > 10)
                {
                    SaveGame.MsgPrint($"{mName} writhes in agony.");
                }
                else
                {
                    SaveGame.MsgPrint($"{mName} jerks limply.");
                }
            }
            else if ("CZ".Contains(rPtr.Character.ToString()))
            {
                if (percentage > 95)
                {
                    SaveGame.MsgPrint($"{mName} shrugs off the attack.");
                }
                else if (percentage > 75)
                {
                    SaveGame.MsgPrint($"{mName} snarls with pain.");
                }
                else if (percentage > 50)
                {
                    SaveGame.MsgPrint($"{mName} yelps in pain.");
                }
                else if (percentage > 35)
                {
                    SaveGame.MsgPrint($"{mName} howls in pain.");
                }
                else if (percentage > 20)
                {
                    SaveGame.MsgPrint($"{mName} howls in agony.");
                }
                else if (percentage > 10)
                {
                    SaveGame.MsgPrint($"{mName} writhes in agony.");
                }
                else
                {
                    SaveGame.MsgPrint($"{mName} yelps feebly.");
                }
            }
            else if ("FIKMRSXabclqrst".Contains(rPtr.Character.ToString()))
            {
                if (percentage > 95)
                {
                    SaveGame.MsgPrint($"{mName} ignores the attack.");
                }
                else if (percentage > 75)
                {
                    SaveGame.MsgPrint($"{mName} grunts with pain.");
                }
                else if (percentage > 50)
                {
                    SaveGame.MsgPrint($"{mName} squeals in pain.");
                }
                else if (percentage > 35)
                {
                    SaveGame.MsgPrint($"{mName} shrieks in pain.");
                }
                else if (percentage > 20)
                {
                    SaveGame.MsgPrint($"{mName} shrieks in agony.");
                }
                else if (percentage > 10)
                {
                    SaveGame.MsgPrint($"{mName} writhes in agony.");
                }
                else
                {
                    SaveGame.MsgPrint($"{mName} cries out feebly.");
                }
            }
            else
            {
                if (percentage > 95)
                {
                    SaveGame.MsgPrint($"{mName} shrugs off the attack.");
                }
                else if (percentage > 75)
                {
                    SaveGame.MsgPrint($"{mName} grunts with pain.");
                }
                else if (percentage > 50)
                {
                    SaveGame.MsgPrint($"{mName} cries out in pain.");
                }
                else if (percentage > 35)
                {
                    SaveGame.MsgPrint($"{mName} screams in pain.");
                }
                else if (percentage > 20)
                {
                    SaveGame.MsgPrint($"{mName} screams in agony.");
                }
                else if (percentage > 10)
                {
                    SaveGame.MsgPrint($"{mName} writhes in agony.");
                }
                else
                {
                    SaveGame.MsgPrint($"{mName} cries out feebly.");
                }
            }
        }

        public bool MultiplyMonster(Monster mPtr, bool charm, bool clone)
        {
            bool result = false;
            for (int i = 0; i < 18; i++)
            {
                int d = 1;
                _level.Scatter(out int y, out int x, mPtr.MapY, mPtr.MapX, d);
                if (!_level.GridPassableNoCreature(y, x))
                {
                    continue;
                }
                result = PlaceMonsterAux(y, x, mPtr.Race, false, false, charm);
                break;
            }
            if (clone && result)
            {
                _monsters[_hackMIdxIi].Mind |= Constants.SmCloned;
            }
            mPtr.Generation++;
            _monsters[_hackMIdxIi].Generation = mPtr.Generation;
            return result;
        }

        public bool PlaceMonster(int y, int x, bool slp, bool grp)
        {
            int rIdx = GetMonNum(_level.MonsterLevel, null);
            if (rIdx == 0)
            {
                return false;
            }
            if (PlaceMonsterByIndex(y, x, rIdx, slp, grp, false))
            {
                return true;
            }
            return false;
        }

        public bool PlaceMonsterAux(int y, int x, MonsterRace rPtr, bool slp, bool grp, bool charm)
        {
            if (!PlaceMonsterOne(y, x, rPtr, slp, charm))
            {
                return false;
            }
            if ((rPtr.Flags1 & MonsterFlag1.Escorted) != 0)
            {
                for (int i = 0; i < 50; i++)
                {
                    int d = 3;
                    _level.Scatter(out int ny, out int nx, y, x, d);
                    if (!_level.GridPassableNoCreature(ny, nx))
                    {
                        continue;
                    }
                    int z = GetMonNum(rPtr.Level, new PlaceMonsterOkayMonsterSelector(rPtr.Index));
                    if (z == 0)
                    {
                        break;
                    }
                    MonsterRace race = SaveGame.MonsterRaces[z];
                    PlaceMonsterOne(ny, nx, race, slp, charm);
                    if ((race.Flags1 & MonsterFlag1.Friends) != 0 ||
                        (rPtr.Flags1 & MonsterFlag1.EscortsGroup) != 0)
                    {
                        PlaceMonsterGroup(ny, nx, z, slp, charm);
                    }
                }
            }
            if (!grp)
            {
                return true;
            }
            if ((rPtr.Flags1 & MonsterFlag1.Friends) != 0)
            {
                PlaceMonsterGroup(y, x, rPtr.Index, slp, charm);
            }
            return true;
        }

        public bool PlaceMonsterByIndex(int y, int x, int index, bool slp, bool grp, bool charm)
        {
            return PlaceMonsterAux(y, x, SaveGame.MonsterRaces[index], slp, grp, charm);
        }

        public void ReplacePet(int y1, int x1, Monster monster)
        {
            int i;
            int x = x1;
            int y = y1;
            for (i = 0; i < 20; ++i)
            {
                int d = (i / 15) + 1;
                _level.Scatter(out y, out x, y1, x1, d);
                if (!_level.GridPassableNoCreature(y, x))
                {
                    continue;
                }
                if (_level.Grid[y][x].FeatureType.Category == FloorTileTypeCategory.Sigil)
                {
                    continue;
                }
                break;
            }
            if (i == 20)
            {
                SaveGame.MsgPrint($"You lose sight of {monster.MonsterDesc(0)}.");
                return;
            }
            GridTile cPtr = _level.Grid[y][x];
            cPtr.MonsterIndex = MPop();
            if (cPtr.MonsterIndex == 0)
            {
                SaveGame.MsgPrint($"You lose sight of {monster.MonsterDesc(0)}.");
                return;
            }
            _monsters[cPtr.MonsterIndex] = monster;
            monster.MapY = y;
            monster.MapX = x;
            MonsterRace rPtr = monster.Race;
            if ((rPtr.Flags2 & MonsterFlag2.Multiply) != 0)
            {
                NumRepro++;
            }
            if ((rPtr.Flags1 & MonsterFlag1.AttrMulti) != 0)
            {
                ShimmerMonsters = true;
            }
        }

        public bool SummonSpecific(int y1, int x1, int lev, MonsterSelector? monsterSelector, bool groupOk = true)
        {
            int i;
            int x = x1;
            int y = y1;
            for (i = 0; i < 20; ++i)
            {
                int d = (i / 15) + 1;
                _level.Scatter(out y, out x, y1, x1, d);
                if (!_level.GridPassableNoCreature(y, x))
                {
                    continue;
                }
                if (_level.Grid[y][x].FeatureType.Category == FloorTileTypeCategory.Sigil)
                {
                    continue;
                }
                break;
            }
            if (i == 20)
            {
                return false;
            }
            int rIdx = GetMonNum(((SaveGame.Difficulty + lev) / 2) + 5, monsterSelector);
            if (rIdx == 0)
            {
                return false;
            }
            MonsterRace race = SaveGame.MonsterRaces[rIdx];
            if (!PlaceMonsterAux(y, x, race, false, groupOk, false))
            {
                return false;
            }
            return true;
        }

        public bool SummonSpecificFriendly(int y1, int x1, int lev, MonsterSelector monsterSelector, bool groupOk) // TODO: The floor Sigil and Charm are the only differences from SummonSpecific.
        {
            int i;
            int x = 0;
            int y = 0;
            for (i = 0; i < 20; ++i)
            {
                int d = (i / 15) + 1;
                _level.Scatter(out y, out x, y1, x1, d);
                if (!_level.GridPassableNoCreature(y, x))
                {
                    continue;
                }
                if (_level.Grid[y][x].FeatureType.Name == "ElderSign")
                {
                    continue;
                }
                if (_level.Grid[y][x].FeatureType.Name == "YellowSign")
                {
                    continue;
                }
                break;
            }
            if (i == 20)
            {
                return false;
            }
            int rIdx = GetMonNum(((SaveGame.Difficulty + lev) / 2) + 5, monsterSelector);
            if (rIdx == 0)
            {
                return false;
            }
            MonsterRace race = SaveGame.MonsterRaces[rIdx];
            if (!PlaceMonsterAux(y, x, race, false, groupOk, true))
            {
                return false;
            }
            return true;
        }

        public void UpdateMonsterVisibility(int mIdx, bool full)
        {
            Monster mPtr = _monsters[mIdx];
            MonsterRace rPtr = mPtr.Race;
            if (rPtr == null)
            {
                return;
            }
            int fy = mPtr.MapY;
            int fx = mPtr.MapX;
            if (full)
            {
                int dy = SaveGame.Player.MapY > fy
                    ? SaveGame.Player.MapY - fy
                    : fy - SaveGame.Player.MapY;
                int dx = SaveGame.Player.MapX > fx
                    ? SaveGame.Player.MapX - fx
                    : fx - SaveGame.Player.MapX;
                int d = dy > dx ? dy + (dx >> 1) : dx + (dy >> 1);
                mPtr.DistanceFromPlayer = d < 255 ? d : 255;
            }
            bool flag = false;
            bool easy = false;
            bool hard = false;
            bool doEmptyMind = false;
            bool doWeirdMind = false;
            bool doInvisible = false;
            bool doColdBlood = false;
            bool oldMl = mPtr.IsVisible;
            if (mPtr.DistanceFromPlayer > Constants.MaxSight)
            {
                if (!mPtr.IsVisible)
                {
                    return;
                }
                if ((mPtr.IndividualMonsterFlags & Constants.MflagMark) != 0)
                {
                    flag = true;
                }
            }
            else if (_level.PanelContains(fy, fx))
            {
                GridTile cPtr = _level.Grid[fy][fx];
                if (cPtr.TileFlags.IsSet(GridTile.IsVisible) && SaveGame.Player.TimedBlindness == 0)
                {
                    if (mPtr.DistanceFromPlayer <= SaveGame.Player.InfravisionRange)
                    {
                        if ((rPtr.Flags2 & MonsterFlag2.ColdBlood) != 0)
                        {
                            doColdBlood = true;
                        }
                        if (!doColdBlood)
                        {
                            easy = true;
                            flag = true;
                        }
                    }
                    if (cPtr.TileFlags.IsSet(GridTile.PlayerLit | GridTile.SelfLit))
                    {
                        if ((rPtr.Flags2 & MonsterFlag2.Invisible) != 0)
                        {
                            doInvisible = true;
                        }
                        if (!doInvisible || SaveGame.Player.HasSeeInvisibility)
                        {
                            easy = true;
                            flag = true;
                        }
                    }
                }
                if (SaveGame.Player.HasTelepathy)
                {
                    if ((rPtr.Flags2 & MonsterFlag2.EmptyMind) != 0)
                    {
                        doEmptyMind = true;
                    }
                    else if ((rPtr.Flags2 & MonsterFlag2.WeirdMind) != 0)
                    {
                        doWeirdMind = true;
                        if (Program.Rng.RandomLessThan(100) < 10)
                        {
                            hard = true;
                            flag = true;
                        }
                    }
                    else
                    {
                        hard = true;
                        flag = true;
                    }
                }
                if ((mPtr.IndividualMonsterFlags & Constants.MflagMark) != 0)
                {
                    flag = true;
                }
                if (SaveGame.Player.IsWizard)
                {
                    flag = true;
                }
            }
            if (flag)
            {
                if (!mPtr.IsVisible)
                {
                    mPtr.IsVisible = true;
                    _level.RedrawSingleLocation(fy, fx);
                    if (SaveGame.TrackedMonsterIndex == mIdx)
                    {
                        SaveGame.Player.RedrawNeeded.Set(RedrawFlag.PrHealth);
                    }
                    if (rPtr.Knowledge.RSights < Constants.MaxShort)
                    {
                        rPtr.Knowledge.RSights++;
                    }
                }
                if (hard)
                {
                    if ((rPtr.Flags2 & MonsterFlag2.Smart) != 0)
                    {
                        rPtr.Knowledge.RFlags2 |= MonsterFlag2.Smart;
                    }
                    if ((rPtr.Flags2 & MonsterFlag2.Stupid) != 0)
                    {
                        rPtr.Knowledge.RFlags2 |= MonsterFlag2.Stupid;
                    }
                }
                if (doEmptyMind)
                {
                    rPtr.Knowledge.RFlags2 |= MonsterFlag2.EmptyMind;
                }
                if (doWeirdMind)
                {
                    rPtr.Knowledge.RFlags2 |= MonsterFlag2.WeirdMind;
                }
                if (doColdBlood)
                {
                    rPtr.Knowledge.RFlags2 |= MonsterFlag2.ColdBlood;
                }
                if (doInvisible)
                {
                    rPtr.Knowledge.RFlags2 |= MonsterFlag2.Invisible;
                }
            }
            else
            {
                if (mPtr.IsVisible)
                {
                    mPtr.IsVisible = false;
                    _level.RedrawSingleLocation(fy, fx);
                    if (SaveGame.TrackedMonsterIndex == mIdx)
                    {
                        SaveGame.Player.RedrawNeeded.Set(RedrawFlag.PrHealth);
                    }
                }
            }
            if (easy)
            {
                if (mPtr.IsVisible != oldMl)
                {
                    if ((rPtr.Flags2 & MonsterFlag2.EldritchHorror) != 0)
                    {
                        mPtr.SanityBlast(SaveGame, false);
                    }
                }
                if ((mPtr.IndividualMonsterFlags & Constants.MflagView) == 0)
                {
                    mPtr.IndividualMonsterFlags |= Constants.MflagView;
                    if ((mPtr.Mind & Constants.SmFriendly) == 0)
                    {
                        SaveGame.Disturb(true);
                    }
                }
            }
            else
            {
                if ((mPtr.IndividualMonsterFlags & Constants.MflagView) != 0)
                {
                    mPtr.IndividualMonsterFlags &= ~Constants.MflagView;
                    if ((mPtr.Mind & Constants.SmFriendly) == 0)
                    {
                        SaveGame.Disturb(true);
                    }
                }
            }
        }

        public void UpdateSmartLearn(Monster monster, int what)
        {
            Player player = SaveGame.Player;
            MonsterRace rPtr = monster.Race;
            if (rPtr == null)
            {
                return;
            }
            if ((rPtr.Flags2 & MonsterFlag2.Stupid) != 0)
            {
                return;
            }
            if ((rPtr.Flags2 & MonsterFlag2.Smart) == 0 && Program.Rng.RandomLessThan(100) < 50)
            {
                return;
            }
            switch (what)
            {
                case Constants.DrsAcid:
                    if (player.HasAcidResistance)
                    {
                        monster.Mind |= Constants.SmResAcid;
                    }
                    if (player.TimedAcidResistance != 0)
                    {
                        monster.Mind |= Constants.SmOppAcid;
                    }
                    if (player.HasAcidImmunity)
                    {
                        monster.Mind |= Constants.SmImmAcid;
                    }
                    break;

                case Constants.DrsElec:
                    if (player.HasLightningResistance)
                    {
                        monster.Mind |= Constants.SmResElec;
                    }
                    if (player.TimedLightningResistance != 0)
                    {
                        monster.Mind |= Constants.SmOppElec;
                    }
                    if (player.HasLightningImmunity)
                    {
                        monster.Mind |= Constants.SmImmElec;
                    }
                    break;

                case Constants.DrsFire:
                    if (player.HasFireResistance)
                    {
                        monster.Mind |= Constants.SmResFire;
                    }
                    if (player.TimedFireResistance != 0)
                    {
                        monster.Mind |= Constants.SmOppFire;
                    }
                    if (player.HasFireImmunity)
                    {
                        monster.Mind |= Constants.SmImmFire;
                    }
                    break;

                case Constants.DrsCold:
                    if (player.HasColdResistance)
                    {
                        monster.Mind |= Constants.SmResCold;
                    }
                    if (player.TimedColdResistance != 0)
                    {
                        monster.Mind |= Constants.SmOppCold;
                    }
                    if (player.HasColdImmunity)
                    {
                        monster.Mind |= Constants.SmImmCold;
                    }
                    break;

                case Constants.DrsPois:
                    if (player.HasPoisonResistance)
                    {
                        monster.Mind |= Constants.SmResPois;
                    }
                    if (player.TimedPoisonResistance != 0)
                    {
                        monster.Mind |= Constants.SmOppPois;
                    }
                    break;

                case Constants.DrsNeth:
                    if (player.HasNetherResistance)
                    {
                        monster.Mind |= Constants.SmResNeth;
                    }
                    break;

                case Constants.DrsLight:
                    if (player.HasLightResistance)
                    {
                        monster.Mind |= Constants.SmResLight;
                    }
                    break;

                case Constants.DrsDark:
                    if (player.HasDarkResistance)
                    {
                        monster.Mind |= Constants.SmResDark;
                    }
                    break;

                case Constants.DrsFear:
                    if (player.HasFearResistance)
                    {
                        monster.Mind |= Constants.SmResFear;
                    }
                    break;

                case Constants.DrsConf:
                    if (player.HasConfusionResistance)
                    {
                        monster.Mind |= Constants.SmResConf;
                    }
                    break;

                case Constants.DrsChaos:
                    if (player.HasChaosResistance)
                    {
                        monster.Mind |= Constants.SmResChaos;
                    }
                    break;

                case Constants.DrsDisen:
                    if (player.HasDisenchantResistance)
                    {
                        monster.Mind |= Constants.SmResDisen;
                    }
                    break;

                case Constants.DrsBlind:
                    if (player.HasBlindnessResistance)
                    {
                        monster.Mind |= Constants.SmResBlind;
                    }
                    break;

                case Constants.DrsNexus:
                    if (player.HasNexusResistance)
                    {
                        monster.Mind |= Constants.SmResNexus;
                    }
                    break;

                case Constants.DrsSound:
                    if (player.HasSoundResistance)
                    {
                        monster.Mind |= Constants.SmResSound;
                    }
                    break;

                case Constants.DrsShard:
                    if (player.HasShardResistance)
                    {
                        monster.Mind |= Constants.SmResShard;
                    }
                    break;

                case Constants.DrsFree:
                    if (player.HasFreeAction)
                    {
                        monster.Mind |= Constants.SmImmFree;
                    }
                    break;

                case Constants.DrsMana:
                    if (player.MaxMana == 0)
                    {
                        monster.Mind |= Constants.SmImmMana;
                    }
                    break;

                case Constants.DrsReflect:
                    if (player.HasReflection)
                    {
                        monster.Mind |= Constants.SmImmReflect;
                    }
                    break;
            }
        }

        public void WipeMList()
        {
            for (int i = _level.MMax - 1; i >= 1; i--)
            {
                Monster mPtr = _monsters[i];
                MonsterRace rPtr = mPtr.Race;
                if (mPtr.Race == null)
                {
                    continue;
                }
                rPtr.CurNum--;
                _level.Grid[mPtr.MapY][mPtr.MapX].MonsterIndex = 0;
                _monsters[i] = new Monster(SaveGame);
            }
            _level.MMax = 1;
            _level.MCnt = 0;
            NumRepro = 0;
            SaveGame.TargetWho = 0;
            SaveGame.HealthTrack(0);
        }

        private void CompactMonstersAux(int i1, int i2)
        {
            int nextOIdx;
            if (i1 == i2)
            {
                return;
            }
            Monster mPtr = _monsters[i1];
            int y = mPtr.MapY;
            int x = mPtr.MapX;
            GridTile cPtr = _level.Grid[y][x];
            cPtr.MonsterIndex = i2;
            for (int thisOIdx = mPtr.FirstHeldItemIndex; thisOIdx != 0; thisOIdx = nextOIdx)
            {
                Item oPtr = _level.Items[thisOIdx];
                nextOIdx = oPtr.NextInStack;
                oPtr.HoldingMonsterIndex = i2;
            }
            if (SaveGame.TargetWho == i1)
            {
                SaveGame.TargetWho = i2;
            }
            if (SaveGame.TrackedMonsterIndex == i1)
            {
                SaveGame.HealthTrack(i2);
            }
            _monsters[i2] = _monsters[i1];
            _monsters[i1] = new Monster(SaveGame);
        }

        private int MPop()
        {
            int i;
            if (_level.MMax < Constants.MaxMIdx)
            {
                i = _level.MMax;
                _level.MMax++;
                _level.MCnt++;
                return i;
            }
            for (i = 1; i < _level.MMax; i++)
            {
                Monster mPtr = _monsters[i];
                if (mPtr.Race != null)
                {
                    continue;
                }
                _level.MCnt++;
                return i;
            }
            if (_level != null)
            {
                SaveGame.MsgPrint("Too many monsters!");
            }
            return 0;
        }

        private void PlaceMonsterGroup(int y, int x, int rIdx, bool slp, bool charm)
        {
            MonsterRace rPtr = SaveGame.MonsterRaces[rIdx];
            int extra = 0;
            int[] hackY = new int[Constants.GroupMax];
            int[] hackX = new int[Constants.GroupMax];
            int total = Program.Rng.DieRoll(13);
            if (rPtr.Level > SaveGame.Difficulty)
            {
                extra = rPtr.Level - SaveGame.Difficulty;
                extra = 0 - Program.Rng.DieRoll(extra);
            }
            else if (rPtr.Level < SaveGame.Difficulty)
            {
                extra = SaveGame.Difficulty - rPtr.Level;
                extra = Program.Rng.DieRoll(extra);
            }
            if (extra > 12)
            {
                extra = 12;
            }
            total += extra;
            if (total < 1)
            {
                total = 1;
            }
            if (total > Constants.GroupMax)
            {
                total = Constants.GroupMax;
            }
            int old = _level.DangerRating;
            int hackN = 1;
            hackX[0] = x;
            hackY[0] = y;
            for (int n = 0; n < hackN && hackN < total; n++)
            {
                int hx = hackX[n];
                int hy = hackY[n];
                for (int i = 0; i < 8 && hackN < total; i++)
                {
                    int mx = hx + _level.OrderedDirectionXOffset[i];
                    int my = hy + _level.OrderedDirectionYOffset[i];
                    if (!_level.GridPassableNoCreature(my, mx))
                    {
                        continue;
                    }
                    if (PlaceMonsterOne(my, mx, rPtr, slp, charm))
                    {
                        hackY[hackN] = my;
                        hackX[hackN] = mx;
                        hackN++;
                    }
                }
            }
            _level.DangerRating = old;
        }

        private bool PlaceMonsterOne(int y, int x, MonsterRace rPtr, bool slp, bool charm)
        {
            if (rPtr == null)
            {
                return false;
            }
            if (rPtr.Name.StartsWith("Player"))
            {
                return false;
            }
            string name = rPtr.Name;
            if (!_level.InBounds(y, x))
            {
                return false;
            }
            if (!_level.GridPassableNoCreature(y, x))
            {
                return false;
            }
            if (_level.Grid[y][x].FeatureType.Category == FloorTileTypeCategory.Sigil)
            {
                return false;
            }
            if (string.IsNullOrEmpty(rPtr.Name))
            {
                return false;
            }
            if ((rPtr.Flags1 & MonsterFlag1.Unique) != 0 && rPtr.CurNum >= rPtr.MaxNum)
            {
                return false;
            }
            if ((rPtr.Flags1 & MonsterFlag1.OnlyGuardian) != 0 || (rPtr.Flags1 & MonsterFlag1.Guardian) != 0)
            {
                int qIdx = SaveGame.Quests.GetQuestNumber();
                if (qIdx < 0)
                {
                    return false;
                }
                if (rPtr.Index != SaveGame.Quests[qIdx].RIdx)
                {
                    return false;
                }
                if (rPtr.CurNum >= SaveGame.Quests[qIdx].ToKill - SaveGame.Quests[qIdx].Killed)
                {
                    return false;
                }
            }
            if (rPtr.Level > SaveGame.Difficulty)
            {
                if ((rPtr.Flags1 & MonsterFlag1.Unique) != 0)
                {
                    _level.DangerRating += (rPtr.Level - SaveGame.Difficulty) * 2;
                }
                else
                {
                    _level.DangerRating += rPtr.Level - SaveGame.Difficulty;
                }
            }
            GridTile cPtr = _level.Grid[y][x];
            cPtr.MonsterIndex = MPop();
            _hackMIdxIi = cPtr.MonsterIndex;
            if (cPtr.MonsterIndex == 0)
            {
                return false;
            }
            Monster mPtr = _monsters[cPtr.MonsterIndex];
            mPtr.Race = rPtr;
            mPtr.MapY = y;
            mPtr.MapX = x;
            mPtr.Generation = 1;
            mPtr.StunLevel = 0;
            mPtr.ConfusionLevel = 0;
            mPtr.FearLevel = 0;
            if (charm)
            {
                mPtr.Mind |= Constants.SmFriendly;
            }
            mPtr.SleepLevel = 0;
            if (slp && rPtr.Sleep != 0)
            {
                int val = rPtr.Sleep;
                mPtr.SleepLevel = (val * 2) + Program.Rng.DieRoll(val * 10);
            }
            mPtr.DistanceFromPlayer = 0;
            mPtr.IndividualMonsterFlags = 0;
            mPtr.IsVisible = false;
            mPtr.MaxHealth = (rPtr.Flags1 & MonsterFlag1.ForceMaxHp) != 0
                ? Program.Rng.DiceRollMax(rPtr.Hdice, rPtr.Hside)
                : Program.Rng.DiceRoll(rPtr.Hdice, rPtr.Hside);
            mPtr.Health = mPtr.MaxHealth;
            mPtr.Speed = rPtr.Speed;
            if ((rPtr.Flags1 & MonsterFlag1.Unique) == 0)
            {
                int i = GlobalData.ExtractEnergy[rPtr.Speed] / 10;
                if (i != 0)
                {
                    mPtr.Speed += Program.Rng.RandomSpread(0, i);
                }
            }
            mPtr.Energy = Program.Rng.RandomLessThan(100);
            if ((rPtr.Flags1 & MonsterFlag1.ForceSleep) != 0)
            {
                mPtr.IndividualMonsterFlags |= Constants.MflagNice;
                RepairMonsters = true;
            }
            if (cPtr.MonsterIndex < CurrentlyActingMonster)
            {
                mPtr.IndividualMonsterFlags |= Constants.MflagBorn;
            }
            UpdateMonsterVisibility(cPtr.MonsterIndex, true);
            rPtr.CurNum++;
            if ((rPtr.Flags2 & MonsterFlag2.Multiply) != 0)
            {
                NumRepro++;
            }
            if ((rPtr.Flags1 & MonsterFlag1.AttrMulti) != 0)
            {
                ShimmerMonsters = true;
            }
            return true;
        }
    }
}