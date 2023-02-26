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
        public SingletonFactory<Town> Towns;
        public SingletonFactory<AmuletFlavour> AmuletFlavours;
        public SingletonFactory<MushroomFlavour> MushroomFlavours;

        public SingletonFactory<PotionFlavour> PotionFlavours;
        public SingletonFactory<RingFlavour> RingFlavours;
        public SingletonFactory<RodFlavour> RodFlavours;
        public SingletonFactory<BaseScrollFlavour> ScrollFlavours;
        public SingletonFactory<StaffFlavour> StaffFlavours;
        public SingletonFactory<WandFlavour> WandFlavours;
        public SingletonFactory<ChestTrapConfiguration> ChestTrapConfigurations;

        private T[] LoadTypesFromAssembly<T>(SaveGame saveGame)
        {
            List<T> typeList = new List<T>();
            Assembly assembly = Assembly.GetExecutingAssembly();
            foreach (Type type in assembly.GetTypes())
            {
                // Load Commands.
                if (!type.IsAbstract && typeof(T).IsAssignableFrom(type))
                {
                    ConstructorInfo[] constructors = type.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance);
                    if (constructors.Length == 0)
                    {
                        throw new Exception($"{type.Name} does not have a private constructor.  Loading singletons requires the object to have a private constructor to ensure it isn't publically created.");
                    }
                    T command = (T)constructors[0].Invoke(new object[] { saveGame });
                    typeList.Add(command);
                }
            }
            return typeList.ToArray();
        }

        public void Initialize(SaveGame saveGame)
        {
            InGameCommands = new SingletonFactory<InGameCommand>(saveGame, LoadTypesFromAssembly<InGameCommand>(saveGame));
            WizardCommands = new SingletonFactory<WizardCommand>(saveGame, LoadTypesFromAssembly<WizardCommand>(saveGame));
            ItemCategories = new SingletonFactory<ItemClass>(saveGame, LoadTypesFromAssembly<ItemClass>(saveGame));
            BaseFixedArtifacts = new SingletonFactory<BaseFixedArtifact>(saveGame, LoadTypesFromAssembly<BaseFixedArtifact>(saveGame));
            InventorySlots = new SingletonFactory<BaseInventorySlot>(saveGame, LoadTypesFromAssembly<BaseInventorySlot>(saveGame));
            StoreCommands = new SingletonFactory<BaseStoreCommand>(saveGame, LoadTypesFromAssembly<BaseStoreCommand>(saveGame));
            CharacterClasses = new SingletonFactory<BaseCharacterClass>(saveGame, LoadTypesFromAssembly<BaseCharacterClass>(saveGame));
            Realms = new SingletonFactory<BaseRealm>(saveGame, LoadTypesFromAssembly<BaseRealm>(saveGame));
            Towns = new SingletonFactory<Town>(saveGame, LoadTypesFromAssembly<Town>(saveGame));
            AmuletFlavours = new SingletonFactory<AmuletFlavour>(saveGame, LoadTypesFromAssembly<AmuletFlavour>(saveGame));
            MushroomFlavours = new SingletonFactory<MushroomFlavour>(saveGame, LoadTypesFromAssembly<MushroomFlavour>(saveGame));
            PotionFlavours = new SingletonFactory<PotionFlavour>(saveGame, LoadTypesFromAssembly<PotionFlavour>(saveGame));
            RingFlavours = new SingletonFactory<RingFlavour>(saveGame, LoadTypesFromAssembly<RingFlavour>(saveGame));
            RodFlavours = new SingletonFactory<RodFlavour>(saveGame, LoadTypesFromAssembly<RodFlavour>(saveGame));
            ScrollFlavours = new SingletonFactory<BaseScrollFlavour>(saveGame, LoadTypesFromAssembly<BaseScrollFlavour>(saveGame));
            StaffFlavours = new SingletonFactory<StaffFlavour>(saveGame, LoadTypesFromAssembly<StaffFlavour>(saveGame));
            WandFlavours = new SingletonFactory<WandFlavour>(saveGame, LoadTypesFromAssembly<WandFlavour>(saveGame));
            ChestTrapConfigurations = new SingletonFactory<ChestTrapConfiguration>(saveGame, LoadTypesFromAssembly<ChestTrapConfiguration>(saveGame));

            Dictionary<FixedArtifactId, FixedArtifact> dictionary = new Dictionary<FixedArtifactId, FixedArtifact>();
            foreach (BaseFixedArtifact baseFixedArtifact in BaseFixedArtifacts)
            {
                dictionary.Add(baseFixedArtifact.FixedArtifactID, new FixedArtifact(baseFixedArtifact));
            }
            FixedArtifacts = new SingletonDictionaryFactory<FixedArtifactId, FixedArtifact>(saveGame, dictionary);

            MonsterRace[] monsterRaces = LoadTypesFromAssembly<MonsterRace>(saveGame).OrderBy(_monsterRace => _monsterRace.LevelFound).ToArray();
            MonsterRaces = new SingletonFactory<MonsterRace>(saveGame, monsterRaces);
            Races = new SingletonFactory<Race>(saveGame, LoadTypesFromAssembly<Race>(saveGame));
        }
    }
}