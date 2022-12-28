using AngbandOS.Commands;
using AngbandOS.Core.FixedArtifacts;
using AngbandOS.Core.ItemClasses;
using AngbandOS.Core.MonsterRaces;
using AngbandOS.Enumerations;
using System.Collections.Generic;
using System.Reflection;

namespace AngbandOS.Core
{
    [Serializable]
    /// <summary>
    /// Represents a repository for game singletons.
    /// </summary>
    internal class SingletonRepository
    {
        public SingletonFactory<ICommand> GameCommands;
 //       public SingletonFactory<ItemClass> ItemCategories;
 //       public SingletonFactory<BaseFixedArtifact> BaseFixedArtifacts;
 //       public SingletonDictionaryFactory<FixedArtifactId, FixedArtifact> FixedArtifacts;
        public SingletonFactory<MonsterRace> MonsterRaces;
        public ItemClassPropertiesSingleton ItemClassProperties;

        public void Initialize(SaveGame saveGame)
        {
            GameCommands = new SingletonFactory<ICommand>(saveGame);
            ItemClassProperties = new ItemClassPropertiesSingleton(saveGame);
    //        ItemCategories = new SingletonFactory<ItemClass>(saveGame);
   //         BaseFixedArtifacts = new SingletonFactory<BaseFixedArtifact>(saveGame);

            //Dictionary<FixedArtifactId, FixedArtifact> dictionary = new Dictionary<FixedArtifactId, FixedArtifact>();
            //foreach (BaseFixedArtifact baseFixedArtifact in BaseFixedArtifacts)
            //{
            //    dictionary.Add(baseFixedArtifact.FixedArtifactID, new FixedArtifact(baseFixedArtifact));
            //}
            //FixedArtifacts = new SingletonDictionaryFactory<FixedArtifactId, FixedArtifact>(saveGame, dictionary);

            int index = 0;
            Assembly assembly = Assembly.GetExecutingAssembly();
            List<MonsterRace> monsterRaces = new List<MonsterRace>();
            for (int level = -1; level < 128; level++)
            {
                foreach (Type type in assembly.GetTypes())
                {
                    // Check to see if the type implements the MonsterRace interface and is not an abstract class.
                    if (!type.IsAbstract && typeof(MonsterRace).IsAssignableFrom(type))
                    {
                        // Load the monster.
                        ConstructorInfo[] constructors = type.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance);
                        MonsterRace monsterRace = (MonsterRace)constructors[0].Invoke(new object[] { saveGame });

                        if (monsterRace.LevelFound == level)
                        {
                            monsterRace.Index = index;
                            monsterRaces.Add(monsterRace);
                            index++;
                        }
                    }
                }
            }
            MonsterRaces = new SingletonFactory<MonsterRace>(saveGame, monsterRaces.ToArray());
        }
    }
}