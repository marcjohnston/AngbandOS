// Cthangband: © 1997 - 2022 Dean Anderson; Based on Angband: © 1997 Ben Harrison, James E. Wilson,
// Robert A. Koeneke; Based on Moria: © 1985 Robert Alan Koeneke and Umoria: © 1989 James E.Wilson
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.Core.MonsterRaces;
using AngbandOS.Enumerations;
using AngbandOS.ItemCategories;

using System;
using System.Collections.Generic;
using System.Reflection;

namespace AngbandOS
{
    [Serializable]
    internal class MonsterRaceArray : List<MonsterRace>
    {
        private readonly SaveGame SaveGame;
        public MonsterRaceArray(SaveGame saveGame)
        {
            SaveGame = saveGame;
            Assembly assembly = Assembly.GetExecutingAssembly();
            int index = 0;
            for (int level = -1; level < 128; level++)
            {
                foreach (Type type in assembly.GetTypes())
                {
                    // Check to see if the type implements the MonsterRace interface and is not an abstract class.
                    if (!type.IsAbstract && typeof(MonsterRace).IsAssignableFrom(type))
                    {
                        // Load the monster.
                        MonsterRace monsterRace = (MonsterRace)Activator.CreateInstance(type);

                        if (monsterRace.LevelFound == level)
                        {
                            monsterRace.Index = index;
                            Add(monsterRace);
                            index++;
                        }
                    }
                }
            }
        }

        public void AddKnowledge()
        {
            foreach (MonsterRace monsterType in this)
            {
                monsterType.Knowledge = new MonsterKnowledge(SaveGame, monsterType);
            }
        }

        public int IndexFromName(string name)
        {
            foreach (MonsterRace race in this)
            {
                if (race.Name == name)
                {
                    return race.Index;
                }
            }
            return 0;
        }

        public void ResetGuardians()
        {
            foreach (MonsterRace race in this)
            {
                race.Flags1 &= ~MonsterFlag1.Guardian;
            }
        }

        public void ResetUniqueOnlyGuardianStatus()
        {
            foreach (MonsterRace race in this)
            {
                race.Flags1 &= ~MonsterFlag1.OnlyGuardian;
            }
        }
    }
}