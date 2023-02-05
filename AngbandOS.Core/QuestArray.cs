// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core
{
    [Serializable]
    internal class QuestArray : List<Quest>
    {
        private const int _maxQuests = 50;
        private readonly SaveGame SaveGame;

        private readonly string[] _findQuest =
        {
            "You find the following inscription in the floor",
            "You see a message inscribed in the wall",
            "There is a sign saying",
            "Something is writen on the staircase",
            "You find a scroll with the following message"
        };

        public QuestArray(SaveGame saveGame)
        {
            SaveGame = saveGame;
            for (int i = 0; i < _maxQuests; i++)
            {
                Add(new Quest());
            }
        }

        public int ActiveQuests => this.Where(q => q.IsActive).Count();

        public string DescribeQuest(int qIdx)
        {
            string buf;
            MonsterRace rPtr = SaveGame.SingletonRepository.MonsterRaces[this[qIdx].RIdx];
            string name = rPtr.Name;
            int qNum = this[qIdx].ToKill;
            string dunName = SaveGame.Dungeons[this[qIdx].Dungeon].Name;
            int lev = this[qIdx].Level;
            if (this[qIdx].Level == 0)
            {
                if (qNum == 1)
                {
                    buf = $"You have defeated {name} in {dunName}";
                }
                else
                {
                    string plural = name.PluraliseMonsterName();
                    buf = $"You have defeated {qNum} {plural} in {dunName}";
                }
            }
            else
            {
                if (this[qIdx].Discovered)
                {
                    if (qNum == 1)
                    {
                        buf = $"You must defeat {name} at lvl {lev} of {dunName}";
                    }
                    else
                    {
                        if (this[qIdx].ToKill - this[qIdx].Killed > 1)
                        {
                            string plural = name.PluraliseMonsterName();
                            buf = $"You must defeat {qNum} {plural} at lvl {lev} of {dunName}";
                        }
                        else
                        {
                            buf = $"You must defeat 1 {name} at lvl {lev} of {dunName}";
                        }
                    }
                }
                else
                {
                    buf = $"You must defeat something at lvl {lev} of {dunName}";
                }
            }
            return buf;
        }

        public int GetQuestMonster()
        {
            for (int i = 0; i < Count; i++)
            {
                if (this[i].Level == SaveGame.CurrentDepth &&
                    this[i].Dungeon == SaveGame.CurDungeon.Index)
                {
                    return this[i].RIdx;
                }
            }
            return 0;
        }

        public int GetQuestNumber()
        {
            for (int i = 0; i < Count; i++)
            {
                if (this[i].Level == SaveGame.CurrentDepth &&
                    this[i].Dungeon == SaveGame.CurDungeon.Index)
                {
                    return i;
                }
            }
            return -1;
        }

        public bool IsQuest(int level)
        {
            if (level == 0)
            {
                return false;
            }
            for (int i = 0; i < Count; i++)
            {
                if (this[i].Level == level && this[i].Dungeon == SaveGame.CurDungeon.Index)
                {
                    return true;
                }
            }
            return false;
        }

        public void PlayerBirthQuests()
        {
            SaveGame.ResetUniqueOnlyGuardianStatus();
            int index = 0;
            Clear();
            for (int i = 0; i < _maxQuests; i++)
            {
                Add(new Quest());
            }
            for (int i = 0; i < Constants.MaxCaves; i++)
            {
                if (SaveGame.Dungeons[i].FirstGuardian != "")
                {
                    this[index].Level = SaveGame.Dungeons[i].FirstLevel;
                    this[index].RIdx = SaveGame.GetMonsterIndexFromName(SaveGame.Dungeons[i].FirstGuardian);
                    SaveGame.SingletonRepository.MonsterRaces[this[index].RIdx].OnlyGuardian = true;
                    this[index].Dungeon = i;
                    this[index].ToKill = 1;
                    this[index].Killed = 0;
                    index++;
                }
                if (SaveGame.Dungeons[i].SecondGuardian != "")
                {
                    this[index].Level = SaveGame.Dungeons[i].SecondLevel;
                    this[index].RIdx = SaveGame.GetMonsterIndexFromName(SaveGame.Dungeons[i].SecondGuardian);
                    SaveGame.SingletonRepository.MonsterRaces[this[index].RIdx].OnlyGuardian = true;
                    this[index].Dungeon = i;
                    this[index].ToKill = 1;
                    this[index].Killed = 0;
                    index++;
                }
            }
            for (int i = 0; i < 26; i++)
            {
                int j;
                bool sameLevel;
                do
                {
                    sameLevel = false;
                    do
                    {
                        this[index].RIdx = GetRndQMonster(index);
                    } while (this[index].RIdx == 0);
                    this[index].Level = SaveGame.SingletonRepository.MonsterRaces[this[index].RIdx].Level;
                    this[index].Level -= Program.Rng.RandomBetween(2, 3 + (this[index].Level / 6));
                    for (j = 0; j < index; j++)
                    {
                        if (this[index].Level == this[j].Level)
                        {
                            sameLevel = true;
                            break;
                        }
                    }
                } while (sameLevel);
                if (SaveGame.SingletonRepository.MonsterRaces[this[index].RIdx].Unique)
                {
                    SaveGame.SingletonRepository.MonsterRaces[this[index].RIdx].OnlyGuardian = true;
                }
                j = Program.Rng.RandomBetween(1, Constants.MaxCaves) - 1;
                while (this[index].Level <= SaveGame.Dungeons[j].Offset ||
                       this[index].Level >
                       SaveGame.Dungeons[j].MaxLevel + SaveGame.Dungeons[j].Offset ||
                       this[index].Level == SaveGame.Dungeons[j].FirstLevel +
                       SaveGame.Dungeons[j].Offset || this[index].Level ==
                       SaveGame.Dungeons[j].SecondLevel + SaveGame.Dungeons[j].Offset)
                {
                    j = Program.Rng.RandomBetween(1, Constants.MaxCaves) - 1;
                }
                this[index].Dungeon = j;
                this[index].Level -= SaveGame.Dungeons[j].Offset;
                this[index].ToKill = GetNumberMonster(index);
                this[index].Killed = 0;
                index++;
            }
        }

        public void PrintQuestMessage()
        {
            int qIdx = GetQuestNumber();
            MonsterRace rPtr = SaveGame.SingletonRepository.MonsterRaces[this[qIdx].RIdx];
            string name = rPtr.Name;
            int qNum = this[qIdx].ToKill - this[qIdx].Killed;
            if (this[qIdx].ToKill == 1)
            {
                SaveGame.MsgPrint($"You still have to kill {name}.");
            }
            else if (qNum > 1)
            {
                string plural = name.PluraliseMonsterName();
                SaveGame.MsgPrint($"You still have to kill {qNum} {plural}.");
            }
            else
            {
                SaveGame.MsgPrint($"You still have to kill 1 {name}.");
            }
        }

        public void QuestDiscovery()
        {
            int qIdx = GetQuestNumber();
            MonsterRace rPtr = SaveGame.SingletonRepository.MonsterRaces[this[qIdx].RIdx];
            string name = rPtr.Name;
            int qNum = this[qIdx].ToKill;
            SaveGame.MsgPrint(_findQuest[Program.Rng.RandomBetween(0, 4)]);
            SaveGame.MsgPrint(null);
            if (qNum == 1)
            {
                SaveGame.MsgPrint($"Beware, this level is protected by {name}!");
            }
            else
            {
                string plural = name.PluraliseMonsterName();
                SaveGame.MsgPrint($"Be warned, this level is guarded by {qNum} {plural}!");
            }
            this[qIdx].Discovered = true;
        }

        private int GetNumberMonster(int i)
        {
            if (SaveGame.SingletonRepository.MonsterRaces[this[i].RIdx].Unique || SaveGame.SingletonRepository.MonsterRaces[this[i].RIdx].Multiply)
            {
                return 1;
            }
            int num = SaveGame.SingletonRepository.MonsterRaces[this[i].RIdx].Friends ? 10 : 5;
            num += Program.Rng.RandomBetween(1, (this[i].Level / 3) + 5);
            return num;
        }

        private int GetRndQMonster(int qIdx)
        {
            int rIdx;
            int tmp = Program.Rng.RandomBetween(1, 10);
            switch (tmp)
            {
                case 1:
                    rIdx = Program.Rng.RandomBetween(181, 220);
                    break;

                case 2:
                    rIdx = Program.Rng.RandomBetween(221, 260);
                    break;

                case 3:
                    rIdx = Program.Rng.RandomBetween(261, 300);
                    break;

                case 4:
                    rIdx = Program.Rng.RandomBetween(301, 340);
                    break;

                case 5:
                    rIdx = Program.Rng.RandomBetween(341, 380);
                    break;

                case 6:
                    rIdx = Program.Rng.RandomBetween(381, 420);
                    break;

                case 7:
                    rIdx = Program.Rng.RandomBetween(421, 460);
                    break;

                case 8:
                    rIdx = Program.Rng.RandomBetween(461, 500);
                    break;

                case 9:
                    rIdx = Program.Rng.RandomBetween(501, 530);
                    break;

                case 10:
                    rIdx = Program.Rng.RandomBetween(531, 560);
                    break;

                default:
                    rIdx = Program.Rng.RandomBetween(87, 573);
                    break;
            }
            if (SaveGame.SingletonRepository.MonsterRaces[rIdx].Multiply)
            {
                return 0;
            }
            for (int j = 2; j < qIdx; j++)
            {
                if (this[j].RIdx == rIdx)
                {
                    return 0;
                }
            }
            return rIdx;
        }
    }
}