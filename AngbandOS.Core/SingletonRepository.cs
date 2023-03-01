using AngbandOS.Core.ProjectileGraphics;
using System.Collections.Generic;
using System.Reflection;

namespace AngbandOS.Core
{
    [Serializable]
    /// <summary>
    /// Represents a repository for all game singletons.
    /// </summary>
    internal class SingletonRepository
    {
        public SingletonDictionary<string, Animation> Animations;
        public SingletonDictionary<FixedArtifactId, FixedArtifact> FixedArtifacts;
        public SingletonDictionary<string, FloorTileType> FloorTileTypes;
        public SingletonList<InGameCommand> InGameCommands;
        public SingletonList<BaseInventorySlot> InventorySlots;
        public SingletonList<ItemClass> ItemCategories;
        public SingletonList<MonsterRace> MonsterRaces;
        public SingletonDictionary<string, ProjectileGraphic> ProjectileGraphics;
        public SingletonList<Race> Races;
        public SingletonDictionary<RareItemTypeEnum, RareItem> RareItemTypes;
        public SingletonList<BaseStoreCommand> StoreCommands;
        public SingletonList<Vault> Vaults;
        public SingletonList<WizardCommand> WizardCommands;
        public SingletonList<TimedAction> TimedActions;
        public SingletonList<BaseCharacterClass> CharacterClasses;
        public SingletonList<BaseRealm> Realms;
        public SingletonList<Town> Towns;
        public SingletonList<AmuletFlavour> AmuletFlavours;
        public SingletonList<MushroomFlavour> MushroomFlavours;
        public SingletonList<PotionFlavour> PotionFlavours;
        public SingletonList<RingFlavour> RingFlavours;
        public SingletonList<RodFlavour> RodFlavours;
        public SingletonList<BaseScrollFlavour> ScrollFlavours;
        public SingletonList<StaffFlavour> StaffFlavours;
        public SingletonList<WandFlavour> WandFlavours;
        public SingletonList<ChestTrapConfiguration> ChestTrapConfigurations;
        public SingletonList<HelpGroup> HelpGroups;
        public SingletonList<StoreOwner> StoreOwners;
        public SingletonList<Store> Stores;

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
            InGameCommands = new SingletonList<InGameCommand>(saveGame, LoadTypesFromAssembly<InGameCommand>(saveGame));
            WizardCommands = new SingletonList<WizardCommand>(saveGame, LoadTypesFromAssembly<WizardCommand>(saveGame));
            ItemCategories = new SingletonList<ItemClass>(saveGame, LoadTypesFromAssembly<ItemClass>(saveGame));
            InventorySlots = new SingletonList<BaseInventorySlot>(saveGame, LoadTypesFromAssembly<BaseInventorySlot>(saveGame));
            StoreCommands = new SingletonList<BaseStoreCommand>(saveGame, LoadTypesFromAssembly<BaseStoreCommand>(saveGame));
            CharacterClasses = new SingletonList<BaseCharacterClass>(saveGame, LoadTypesFromAssembly<BaseCharacterClass>(saveGame));
            Realms = new SingletonList<BaseRealm>(saveGame, LoadTypesFromAssembly<BaseRealm>(saveGame));
            Towns = new SingletonList<Town>(saveGame, LoadTypesFromAssembly<Town>(saveGame));
            AmuletFlavours = new SingletonList<AmuletFlavour>(saveGame, LoadTypesFromAssembly<AmuletFlavour>(saveGame));
            MushroomFlavours = new SingletonList<MushroomFlavour>(saveGame, LoadTypesFromAssembly<MushroomFlavour>(saveGame));
            PotionFlavours = new SingletonList<PotionFlavour>(saveGame, LoadTypesFromAssembly<PotionFlavour>(saveGame));
            RingFlavours = new SingletonList<RingFlavour>(saveGame, LoadTypesFromAssembly<RingFlavour>(saveGame));
            RodFlavours = new SingletonList<RodFlavour>(saveGame, LoadTypesFromAssembly<RodFlavour>(saveGame));
            ScrollFlavours = new SingletonList<BaseScrollFlavour>(saveGame, LoadTypesFromAssembly<BaseScrollFlavour>(saveGame));
            StaffFlavours = new SingletonList<StaffFlavour>(saveGame, LoadTypesFromAssembly<StaffFlavour>(saveGame));
            WandFlavours = new SingletonList<WandFlavour>(saveGame, LoadTypesFromAssembly<WandFlavour>(saveGame));
            ChestTrapConfigurations = new SingletonList<ChestTrapConfiguration>(saveGame, LoadTypesFromAssembly<ChestTrapConfiguration>(saveGame));
            ProjectileGraphics = new SingletonDictionary<string, ProjectileGraphic>(saveGame, LoadTypesFromAssembly<ProjectileGraphic>(saveGame), (_projectileGraphic => _projectileGraphic.Name));
            Animations = new SingletonDictionary<string, Animation>(saveGame, LoadTypesFromAssembly<Animation>(saveGame), (_animation => _animation.Name));
            Vaults = new SingletonList<Vault>(saveGame, LoadTypesFromAssembly<Vault>(saveGame));
            FloorTileTypes = new SingletonDictionary<string, FloorTileType>(saveGame, LoadTypesFromAssembly<FloorTileType>(saveGame), (_floorTileType => _floorTileType.Name));
            RareItemTypes = new SingletonDictionary<RareItemTypeEnum, RareItem>(saveGame, LoadTypesFromAssembly<RareItem>(saveGame), _rareItemType => _rareItemType.RareItemType);
            FixedArtifacts = new SingletonDictionary<FixedArtifactId, FixedArtifact>(saveGame, LoadTypesFromAssembly<FixedArtifact>(saveGame), (_fixedArtifact => _fixedArtifact.FixedArtifactID));
            MonsterRaces = new SingletonList<MonsterRace>(saveGame, LoadTypesFromAssembly<MonsterRace>(saveGame).OrderBy(_monsterRace => _monsterRace.LevelFound));
            Races = new SingletonList<Race>(saveGame, LoadTypesFromAssembly<Race>(saveGame));
            HelpGroups = new SingletonList<HelpGroup>(saveGame, LoadTypesFromAssembly<HelpGroup>(saveGame));
            StoreOwners = new SingletonList<StoreOwner>(saveGame, LoadTypesFromAssembly<StoreOwner>(saveGame));
            Stores = new SingletonList<Store>(saveGame, LoadTypesFromAssembly<Store>(saveGame));
        }
    }
}