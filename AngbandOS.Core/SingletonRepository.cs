// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using System.Reflection;
using Timer = AngbandOS.Core.Timers.Timer;

namespace AngbandOS.Core;

[Serializable]
/// <summary>
/// Represents a repository for all game singletons.
/// </summary>
internal class SingletonRepository
{
    private readonly Game Game;
    private readonly List<ILoadAndBind> _repositories = new();

    public ElvishTextRepository ElvishText;
    public FindQuestsRepository FindQuests;
    public FunnyCommentsRepository FunnyComments;
    public FunnyDescriptionsRepository FunnyDescriptions;
    public HorrificDescriptionsRepository HorrificDescriptions;
    public InsultPlayerAttacksRepository InsultPlayerAttacks;
    public MoanPlayerAttacksRepository MoanPlayerAttacks;
    public ShopkeeperAcceptedCommentsRepository ShopkeeperAcceptedComments;
    public ShopkeeperBargainCommentsRepository ShopkeeperBargainComments;
    public ShopkeeperGoodCommentsRepository ShopkeeperGoodComments;
    public ShopkeeperLessThanGuessCommentsRepository ShopkeeperLessThanGuessComments;
    public ShopkeeperWorthlessCommentsRepository ShopkeeperWorthlessComments;
    public SingingPlayerAttacksRepository SingingPlayerAttacks;
    public UnreadableFlavorSyllablesRepository UnreadableFlavorSyllables;
    public WorshipPlayerAttacksRepository WorshipPlayerAttacks;

    private Dictionary<string, GenericRepository> _singletonsDictionary = new Dictionary<string, GenericRepository>();

    /// <summary>
    /// Returns a list of all singletons.  This is used to track all of the loaded singletons so that they can be bound quickly and only once.
    /// </summary>
    private List<IGetKey> _allSingletonsList = new List<IGetKey>();

    /// <summary>
    /// Returns a <see cref="WeightedRandom"/> object with all of the entities in the <typeparamref name="T""Tx"/> repository.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public WeightedRandom<T> ToWeightedRandom<T>(Func<T, bool>? predicate = null)
    {
        string typeName = typeof(T).Name;
        T[] list = _singletonsDictionary[typeName].Get<T>();
        return new WeightedRandom<T>(Game, list, predicate);
    }

    /// <summary>
    /// Registers a repository for all singletons that implement the interface specified by <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <exception cref="Exception"></exception>
    private void RegisterRepository<T>()
    {
        string typeName = typeof(T).Name;
        if (_singletonsDictionary.TryGetValue(typeName, out GenericRepository? genericRepository))
        {
            throw new Exception($"{typeName} repository already registered.");
        }
        genericRepository = new GenericRepository();
        _singletonsDictionary.Add(typeName, genericRepository);
    }

    /// <summary>
    /// Returns the singleton from the repository specified by the <typeparamref name="T"/> type referenced by the unique key identifier <paramref name="key"/> or null if <paramref name="key"/> is null.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public T? GetNullable<T>(string? key) where T : class
    {
        if (key == null)
        {
            return null;
        }

        string typeName = typeof(T).Name;

        // Check to see if the dictionary has a dictionary for this type of object.
        if (!_singletonsDictionary.TryGetValue(typeName, out GenericRepository? genericRepository))
        {
            throw new Exception($"The {typeof(T).Name} singleton interface was not registered.");
        }

        // Retrieve the singleton by key name.
        if (!genericRepository.Dictionary.TryGetValue(key, out object? singleton))
        {
            throw new Exception($"The singleton {typeof(T).Name}.{key} does not exist.");
        }
        return (T)singleton;
    }

    /// <summary>
    /// Returns an array of singletons from the repository specified by the <typeparamref name="T"/> type that are references by the unique key
    /// identifiers <paramref name="keys"/> or null if <paramref name="keys"/> is null.  If any of the singletons do not exist, an exception is thrown.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public T[]? GetNullable<T>(string[]? keys) where T : class
    {
        if (keys == null)
        {
            return null;
        }
        return Get<T>(keys);
    }

    /// <summary>
    /// Returns an array of all of the singletons from the repository specified by the <typeparamref name="T"/> type.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public T[] Get<T>() where T : class
    {
        string typeName = typeof(T).Name;
        return _singletonsDictionary[typeName].Get<T>();
    }

    /// <summary>
    /// Returns an array of singletons from the repository specified by the <typeparamref name="T"/> type referenced by the unique key identifiers <paramref name="keys"/>.  If any the singletons do not exist, an exception is thrown.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public T[] Get<T>(string[] keys) where T : class
    {
        List<T> changeTrackerList = new();
        foreach (string key in keys)
        {
            changeTrackerList.Add(Get<T>(key));
        }
        return changeTrackerList.ToArray();
    }

    public T Get<T>(string key) where T : class
    {
        T? singleton = GetNullable<T>(key);
        if (singleton == null)
        {
            throw new Exception($"The singleton {typeof(T).Name}.{key} does not exist.");
        }
        return singleton;
    }

    public T? TryGet<T>(string key) where T : class
    {
        string typeName = typeof(T).Name;

        // Check to see if the dictionary has a dictionary for this type of object.
        if (!_singletonsDictionary.TryGetValue(typeName, out GenericRepository? genericRepository))
        {
            throw new Exception($"The {typeof(T).Name} singleton interface was not registered.");
        }

        // Retrieve the singleton by key name.
        if (!genericRepository.Dictionary.TryGetValue(key, out object? singleton))
        {
            return null;
        }
        return (T)singleton;
    }

    public T Get<T>(int index) where T : class
    {
        string typeName = typeof(T).Name;
        return (T)_singletonsDictionary[typeName].List[index];
    }

    private void LoadAllAssemblyTypes()
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        Type[] types = assembly.GetTypes();
        foreach (Type type in types)
        {
            // Ensure the type is not abstract and inherits the IGetKey interface.
            if (!type.IsAbstract)
            {
                // Ensure it only has one constructor.
                ConstructorInfo[] constructors = type.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance);
                if (constructors.Length == 1)
                {
                    // We will only instantiate the singleton, if we are storing it.
                    object? singleton = null;

                    // Place the singleton into the respective dictionary repositories.
                    List<Type> interfaceTypeNames = new List<Type>();
                    interfaceTypeNames.AddRange(type.GetInterfaces());
                    Type? baseType = type.BaseType;
                    while (baseType != null)
                    {
                        interfaceTypeNames.Add(baseType);
                        baseType = baseType.BaseType;
                    }

                    foreach (Type interfaceType in interfaceTypeNames)
                    {
                        string typeName = interfaceType.Name;

                        // Check to see if there is a repository that is registered for this type.  There is no else; we simple ignore this interface.
                        if (_singletonsDictionary.TryGetValue(typeName, out GenericRepository? genericRepository))
                        {
                            // We only instantiate the object once and only if we are storing it.
                            if (singleton == null)
                            {
                                singleton = constructors[0].Invoke(new object[] { Game });
                            }
                            
                            // Ensure the singleton implements the IGetKey interface and get the key from the singleton.
                            switch (singleton)
                            {
                                case IGetKey getKeySingleton:
                                    string key = getKeySingleton.GetKey;

                                    // Add the singleton to the list of singletons so that they can be bound.
                                    _allSingletonsList.Add(getKeySingleton);

                                    // Ensure there isn't already a singleton with the same name.
                                    if (genericRepository.Dictionary.TryGetValue(key, out _))
                                    {
                                        throw new Exception($"Cannot add duplicate {type.Name} singleton with the key {key}.");
                                    }
                                    genericRepository.Add(key, singleton);
                                    break;
                                default:
                                    throw new Exception($"The singleton {type.Name} does not implement the IGetKey interface.");
                            }

                        }
                    }
                }
            }
        }
    }

    public SingletonRepository(Game game)
    {
        Game = game;
    }

    private T AddRepository<T>(T repository) where T : ILoadAndBind
    {
        _repositories.Add(repository);
        return repository;
    }

    private void LoadRepositoryItems()
    {
        foreach (ILoadAndBind repository in _repositories)
        {
            repository.Load();
        }
    }

    private void BindRepositoryItems()
    {
        foreach (ILoadAndBind repository in _repositories)
        {
            repository.Bind();
        }
    }

    /// <summary>
    /// Persist the entities to the core persistent storage medium.  This method is only being used to generate database entities from objects.
    /// </summary>
    /// <param name="corePersistentStorage"></param>
    public void PersistEntities<T>() where T : class, IGetKey
    {
        List<KeyValuePair<string, string>> jsonEntityList = new List<KeyValuePair<string, string>>();
        foreach (T entity in Get<T>())
        {
            string key = entity.GetKey.ToString(); // TODO: The use of .ToString is because TKey needs to be strings
            string serializedEntity = entity.ToJson();
            jsonEntityList.Add(new KeyValuePair<string, string>(key, serializedEntity));
        }
        string pluralName = Game.Pluralize(typeof(T).Name);
        Game.CorePersistentStorage.PersistEntities(pluralName, jsonEntityList.ToArray());
    }

    private void LoadFromConfiguration<T, TDefinition, TGeneric>(TDefinition[]? definitions) where T : IGetKey where TGeneric : T
    {
        string typeName = typeof(T).Name;
        GenericRepository gameCommands = _singletonsDictionary[typeName];
        if (definitions != null)
        {
            ConstructorInfo[] constructors = typeof(TGeneric).GetConstructors(BindingFlags.Public | BindingFlags.Instance);
            if (constructors.Length != 1)
            {
                throw new Exception($"Invalid number of constructors for {typeof(TGeneric)}.");
            }
            foreach (TDefinition definition in definitions)
            {
                T gameCommand = (T)constructors[0].Invoke(new object[] { Game, definition });
                string key = gameCommand.GetKey;
                gameCommands.Add(key, gameCommand);
                _allSingletonsList.Add(gameCommand);
            }
        }
    }

    /// <summary>
    /// Performs the load phase of the singleton repository.  This phase reads all of the types from the assembly and adds it into its respective
    /// collection--if the ExcludeFromRepository property returns false.  If the ExcludeFromRepository is true, the singleton object will be discarded.
    /// </summary>
    /// <param name="game"></param>
    public void Load()
    {
        // These are the types to load from the assembly.  The interfaces that are not registered here will be registered just before the configuration is loaded.
        RegisterRepository<IBoolValue>();
        RegisterRepository<IIntValue>();
        RegisterRepository<ICastScript>();
        RegisterRepository<IChangeTracker>();
        RegisterRepository<IDateAndTimeValue>();
        RegisterRepository<INullableStringsValue>();
        RegisterRepository<IStringValue>();

        RegisterRepository<Activation>();
        RegisterRepository<AlterAction>();
        RegisterRepository<Alignment>();
        RegisterRepository<ArtifactBias>();
        RegisterRepository<AttackEffect>();
        RegisterRepository<BaseCharacterClass>();
        RegisterRepository<BaseInventorySlot>();
        RegisterRepository<BirthStage>();
        RegisterRepository<ChestTrapConfiguration>();
        RegisterRepository<ChestTrap>();
        RegisterRepository<FixedArtifact>();
        RegisterRepository<FlaggedAction>();
        RegisterRepository<Form>();
        RegisterRepository<Function>();
        RegisterRepository<Gender>();
        RegisterRepository<ItemClass>();
        RegisterRepository<ItemFactory>();
        RegisterRepository<ItemFilter>();
        RegisterRepository<ItemQualityRating>();
        RegisterRepository<Justification>();
        RegisterRepository<MartialArtsAttack>();
        RegisterRepository<MonsterFilter>();
        RegisterRepository<MonsterSpell>();
        RegisterRepository<Mutation>();
        RegisterRepository<Patron>();
        RegisterRepository<Power>();
        RegisterRepository<Projectile>();
        RegisterRepository<Property>();
        RegisterRepository<Race>();
        RegisterRepository<RareItem>();
        RegisterRepository<Realm>();
        RegisterRepository<Reward>();
        RegisterRepository<RoomLayout>();
        RegisterRepository<Script>();
        RegisterRepository<SpellResistantDetection>();
        RegisterRepository<StoreFactory>();
        RegisterRepository<Talent>();
        RegisterRepository<Timer>();
        RegisterRepository<Widget>();

        // These are already capable of Json serialization.
        RegisterRepository<AmuletReadableFlavor>();
        RegisterRepository<Animation>();
        RegisterRepository<Attack>();
        RegisterRepository<ClassSpell>();
        RegisterRepository<DungeonGuardian>();
        RegisterRepository<Dungeon>();
        RegisterRepository<GameCommand>();
        RegisterRepository<God>();
        RegisterRepository<HelpGroup>();
        RegisterRepository<MonsterRace>();
        RegisterRepository<MushroomReadableFlavor>();
        RegisterRepository<Plural>();
        RegisterRepository<PotionReadableFlavor>();
        RegisterRepository<ProjectileGraphic>();
        RegisterRepository<RingReadableFlavor>();
        RegisterRepository<RodReadableFlavor>();
        RegisterRepository<ScrollReadableFlavor>();
        RegisterRepository<Shopkeeper>();
        RegisterRepository<Spell>();
        RegisterRepository<StaffReadableFlavor>();
        RegisterRepository<StoreCommand>();
        RegisterRepository<Symbol>();
        RegisterRepository<Tile>();
        RegisterRepository<Town>();
        RegisterRepository<Vault>();
        RegisterRepository<WandReadableFlavor>();
        RegisterRepository<WizardCommand>();

        // This is the load phase for assembly.
        LoadAllAssemblyTypes();


        // Now load the configuration singletons.
        LoadFromConfiguration<AmuletReadableFlavor, ReadableFlavorDefinition, GenericAmuletReadableFlavor>(Game.Configuration.AmuletReadableFlavors);
        LoadFromConfiguration<Animation, AnimationDefinition, GenericAnimation>(Game.Configuration.Animations);
        LoadFromConfiguration<Attack, AttackDefinition, GenericAttack>(Game.Configuration.Attacks);
        LoadFromConfiguration<ClassSpell, ClassSpellDefinition, GenericClassSpell>(Game.Configuration.ClassSpells);
        LoadFromConfiguration<DungeonGuardian, DungeonGuardianDefinition, GenericDungeonGuardian>(Game.Configuration.DungeonGuardians);
        LoadFromConfiguration<Dungeon, DungeonDefinition, GenericDungeon>(Game.Configuration.Dungeons);
        LoadFromConfiguration<GameCommand, GameCommandDefinition, GenericGameCommand>(Game.Configuration.GameCommands);
        LoadFromConfiguration<God, GodDefinition, GenericGod>(Game.Configuration.Gods);
        LoadFromConfiguration<HelpGroup, HelpGroupDefinition, GenericHelpGroup>(Game.Configuration.HelpGroups);
        LoadFromConfiguration<MonsterRace, MonsterRaceDefinition, GenericMonsterRace>(Game.Configuration.MonsterRaces);
        LoadFromConfiguration<MushroomReadableFlavor, ReadableFlavorDefinition, GenericMushroomReadableFlavor>(Game.Configuration.MushroomReadableFlavors);
        LoadFromConfiguration<Plural, PluralDefinition, GenericPlural>(Game.Configuration.Plurals);
        LoadFromConfiguration<PotionReadableFlavor, ReadableFlavorDefinition, GenericPotionReadableFlavor>(Game.Configuration.PotionReadableFlavors);
        LoadFromConfiguration<ProjectileGraphic, ProjectileGraphicDefinition, GenericProjectileGraphic>(Game.Configuration.ProjectileGraphics);
        LoadFromConfiguration<RingReadableFlavor, ReadableFlavorDefinition, GenericRingReadableFlavor>(Game.Configuration.RingReadableFlavors);
        LoadFromConfiguration<RodReadableFlavor, ReadableFlavorDefinition, GenericRodReadableFlavor>(Game.Configuration.RodReadableFlavors);
        LoadFromConfiguration<ScrollReadableFlavor, ReadableFlavorDefinition, GenericScrollReadableFlavor>(Game.Configuration.ScrollReadableFlavors);
        LoadFromConfiguration<Shopkeeper, ShopkeeperDefinition, GenericShopkeeper>(Game.Configuration.Shopkeepers);
        LoadFromConfiguration<Spell, SpellDefinition, GenericSpell>(Game.Configuration.Spells);
        LoadFromConfiguration<StaffReadableFlavor, ReadableFlavorDefinition, GenericStaffReadableFlavor>(Game.Configuration.StaffReadableFlavors);
        LoadFromConfiguration<StoreCommand, StoreCommandDefinition, GenericStoreCommand>(Game.Configuration.StoreCommands);
        LoadFromConfiguration<Symbol, SymbolDefinition, GenericSymbol>(Game.Configuration.Symbols);
        LoadFromConfiguration<Tile, TileDefinition, GenericTile>(Game.Configuration.Tiles);
        LoadFromConfiguration<Town, TownDefinition, GenericTown>(Game.Configuration.Towns);
        LoadFromConfiguration<Vault, VaultDefinition, GenericVault>(Game.Configuration.Vaults);
        LoadFromConfiguration<WandReadableFlavor, ReadableFlavorDefinition, GenericWandReadableFlavor>(Game.Configuration.WandReadableFlavors);
        LoadFromConfiguration<WizardCommand, WizardCommandDefinition, GenericWizardCommand>(Game.Configuration.WizardCommands);

        MonsterRace[] monsterRaces = Get<MonsterRace>();
        MonsterRace[] sortedMonsterRaces = monsterRaces.OrderBy(_monsterRace => _monsterRace.LevelFound).ToArray();
        _singletonsDictionary["MonsterRace"].List.Clear();
        _singletonsDictionary["MonsterRace"].List.AddRange(sortedMonsterRaces);

        // Create all of the repositories.  All of the repositories will be empty and have an instance to the save game.
        ElvishText = AddRepository<ElvishTextRepository>(new ElvishTextRepository(Game));
        FunnyComments = AddRepository<FunnyCommentsRepository>(new FunnyCommentsRepository(Game));
        FunnyDescriptions = AddRepository<FunnyDescriptionsRepository>(new FunnyDescriptionsRepository(Game));
        HorrificDescriptions = AddRepository<HorrificDescriptionsRepository>(new HorrificDescriptionsRepository(Game));
        InsultPlayerAttacks = AddRepository<InsultPlayerAttacksRepository>(new InsultPlayerAttacksRepository(Game));
        MoanPlayerAttacks = AddRepository<MoanPlayerAttacksRepository>(new MoanPlayerAttacksRepository(Game));
        ShopkeeperAcceptedComments = AddRepository<ShopkeeperAcceptedCommentsRepository>(new ShopkeeperAcceptedCommentsRepository(Game));
        ShopkeeperBargainComments = AddRepository<ShopkeeperBargainCommentsRepository>(new ShopkeeperBargainCommentsRepository(Game));
        ShopkeeperGoodComments = AddRepository<ShopkeeperGoodCommentsRepository>(new ShopkeeperGoodCommentsRepository(Game));
        ShopkeeperLessThanGuessComments = AddRepository<ShopkeeperLessThanGuessCommentsRepository>(new ShopkeeperLessThanGuessCommentsRepository(Game));
        ShopkeeperWorthlessComments = AddRepository<ShopkeeperWorthlessCommentsRepository>(new ShopkeeperWorthlessCommentsRepository(Game));
        SingingPlayerAttacks = AddRepository<SingingPlayerAttacksRepository>(new SingingPlayerAttacksRepository(Game));
        UnreadableFlavorSyllables = AddRepository<UnreadableFlavorSyllablesRepository>(new UnreadableFlavorSyllablesRepository(Game));
        WorshipPlayerAttacks = AddRepository<WorshipPlayerAttacksRepository>(new WorshipPlayerAttacksRepository(Game));

        // Load all of the objects into each repository.  This is where the assembly will be scanned or the database will be read.
        LoadRepositoryItems();
        BindRepositoryItems();

        // Bind all of the singletons now.
        foreach (IGetKey singleton in _allSingletonsList)
        {
            singleton.Bind();
        }
    }
}
