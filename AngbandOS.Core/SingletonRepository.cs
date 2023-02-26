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
        public SingletonFactory<InGameCommand> InGameCommands;
        public SingletonFactory<WizardCommand> WizardCommands;
        public SingletonFactory<ItemClass> ItemCategories;
        public SingletonFactory<BaseFixedArtifact> BaseFixedArtifacts;
        public SingletonDictionaryFactory<FixedArtifactId, FixedArtifact> FixedArtifacts;
        public SingletonFactory<MonsterRace> MonsterRaces;
        public SingletonFactory<BaseInventorySlot> InventorySlots;
        public SingletonFactory<Race> Races;
        public SingletonFactory<BaseStoreCommand> StoreCommands;
        public SingletonFactory<TimedAction> TimedActions;
        public SingletonFactory<BaseCharacterClass> CharacterClasses;
        public SingletonFactory<BaseRealm> Realms;

        public T[] LoadTypesFromAssembly<T>(SaveGame saveGame)
        {
            List<T> typeList = new List<T>();
            Assembly assembly = Assembly.GetExecutingAssembly();
            foreach (Type type in assembly.GetTypes())
            {
                // Load Commands.
                if (!type.IsAbstract && typeof(T).IsAssignableFrom(type))
                {
                    ConstructorInfo[] constructors = type.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance);
                    T command = (T)constructors[0].Invoke(new object[] { saveGame });
                    typeList.Add(command);
                }
            }
            return typeList.ToArray();
        }

        public void Initialize(SaveGame saveGame)
        {
            InGameCommands = new SingletonFactory<InGameCommand>(saveGame);
            WizardCommands = new SingletonFactory<WizardCommand>(saveGame);
            ItemCategories = new SingletonFactory<ItemClass>(saveGame);
            BaseFixedArtifacts = new SingletonFactory<BaseFixedArtifact>(saveGame);
            InventorySlots = new SingletonFactory<BaseInventorySlot>(saveGame);
            StoreCommands = new SingletonFactory<BaseStoreCommand>(saveGame);
            CharacterClasses = new SingletonFactory<BaseCharacterClass>(saveGame);
            Realms = new SingletonFactory<BaseRealm>(saveGame);

            Dictionary<FixedArtifactId, FixedArtifact> dictionary = new Dictionary<FixedArtifactId, FixedArtifact>();
            foreach (BaseFixedArtifact baseFixedArtifact in BaseFixedArtifacts)
            {
                dictionary.Add(baseFixedArtifact.FixedArtifactID, new FixedArtifact(baseFixedArtifact));
            }
            FixedArtifacts = new SingletonDictionaryFactory<FixedArtifactId, FixedArtifact>(saveGame, dictionary);

            //int index = 0;
            //Assembly assembly = Assembly.GetExecutingAssembly();
            //List<MonsterRace> monsterRaces = new List<MonsterRace>();
            //for (int level = -1; level < 128; level++)
            //{
            //    foreach (Type type in assembly.GetTypes())
            //    {
            //        // Check to see if the type implements the MonsterRace interface and is not an abstract class.
            //        if (!type.IsAbstract && typeof(MonsterRace).IsAssignableFrom(type))
            //        {
            //            // Load the monster.
            //            ConstructorInfo[] constructors = type.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance);
            //            MonsterRace monsterRace = (MonsterRace)constructors[0].Invoke(new object[] { saveGame });

            //            if (monsterRace.LevelFound == level)
            //            {
            //                monsterRace.Index = index;
            //                monsterRaces.Add(monsterRace);
            //                index++;
            //            }
            //        }
            //    }
            //}
            MonsterRace[] monsterRaces = LoadTypesFromAssembly<MonsterRace>(saveGame).OrderBy(_monsterRace => _monsterRace.Level).ToArray();
            MonsterRaces = new SingletonFactory<MonsterRace>(saveGame, monsterRaces);
            Races = new SingletonFactory<Race>(saveGame);
        }
    }
}