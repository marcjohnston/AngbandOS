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
    #region Constructors
    public SingletonRepository(Game game)
    {
        Game = game;
    }
    #endregion

    #region Publics
    public ElvishTextRepository ElvishText; // TODO: These cannot be hardcoded.
    public FindQuestsRepository FindQuests; // TODO: These cannot be hardcoded.
    public FunnyCommentsRepository FunnyComments; // TODO: These cannot be hardcoded.
    public FunnyDescriptionsRepository FunnyDescriptions; // TODO: These cannot be hardcoded.
    public HorrificDescriptionsRepository HorrificDescriptions; // TODO: These cannot be hardcoded.
    public InsultPlayerAttacksRepository InsultPlayerAttacks; // TODO: These cannot be hardcoded.
    public MoanPlayerAttacksRepository MoanPlayerAttacks; // TODO: These cannot be hardcoded.
    public ShopkeeperAcceptedCommentsRepository ShopkeeperAcceptedComments; // TODO: These cannot be hardcoded.
    public ShopkeeperBargainCommentsRepository ShopkeeperBargainComments; // TODO: These cannot be hardcoded.
    public ShopkeeperGoodCommentsRepository ShopkeeperGoodComments; // TODO: These cannot be hardcoded.
    public ShopkeeperLessThanGuessCommentsRepository ShopkeeperLessThanGuessComments; // TODO: These cannot be hardcoded.
    public ShopkeeperWorthlessCommentsRepository ShopkeeperWorthlessComments; // TODO: These cannot be hardcoded.
    public SingingPlayerAttacksRepository SingingPlayerAttacks; // TODO: These cannot be hardcoded.
    public IllegibleFlavorSyllablesRepository IllegibleFlavorSyllables; // TODO: These cannot be hardcoded.
    public WorshipPlayerAttacksRepository WorshipPlayerAttacks; // TODO: These cannot be hardcoded.

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
            throw new Exception($"The repository was registered but the singleton {typeof(T).Name}.{key} does not exist.  Ensure the {nameof(IGetKey)} interface was implemented on the {typeof(T).Name} class.");
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
    /// Returns the number of API Objects in a registered repository (see <see cref="RegisterRepository"/> for more information).
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public int Count<T>()
    {
        string typeName = typeof(T).Name;
        return _singletonsDictionary[typeName].Count;
    }

    /// <summary>
    /// Returns an array of API Objects from the registered repository (see <see cref="RegisterRepository"/> for more information) of type <typeparamref name="T"/> by their unique key 
    /// identifiers <paramref name="keys"/>.  If any the singletons do not exist, an exception is thrown.  Empty arrays are supported and will return an empty array.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public T[] Get<T>(string[] keys) where T : class
    {
        List<T> results = new List<T>();
        foreach (string key in keys)
        {
            results.Add(Get<T>(key));
        }
        return results.ToArray();
    }

    /// <summary>
    /// Retrieves an API Object by its <paramref name="key"/> from the registered repository (see <see cref="RegisterRepository"/> for more information) of type <typeparamref name="T"/> and throws an exception if it isn't found.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public T Get<T>(string key) where T : class
    {
        T? singleton = GetNullable<T>(key);
        if (singleton == null)
        {
            throw new Exception($"The singleton {typeof(T).Name}.{key} does not exist.");
        }
        return singleton;
    }

    /// <summary>
    /// Retrieves an API Object by its <paramref name="key"/> from the registered repository (see <see cref="RegisterRepository"/> for more information) of type <typeparamref name="T"/> and returns null, if it isn't found.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
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

    /// <summary>
    /// Persist all of the singletons to the persistent storage.
    /// </summary>
    public void PersistSingletons()
    {
        foreach (KeyValuePair<string, GenericRepository> typeNameAndRepository in _singletonsDictionary)
        {
            List<KeyValuePair<string, string>> jsonEntityList = new List<KeyValuePair<string, string>>();
            foreach (KeyValuePair<string, object> keyAndEntity in typeNameAndRepository.Value.Dictionary)
            {
                string key = keyAndEntity.Key; // entity.GetKey.ToString(); // TODO: The use of .ToString is because TKey needs to be strings
                IGetKey entity = (IGetKey)keyAndEntity.Value;
                string serializedEntity =  entity.ToJson();
                jsonEntityList.Add(new KeyValuePair<string, string>(key, serializedEntity));
            }
            string pluralName = Game.Pluralize(typeNameAndRepository.Key);
            Game.CorePersistentStorage.PersistEntities(pluralName, jsonEntityList.ToArray());
        }
    }

    /// <summary>
    /// Performs the load phase of the singleton repository.  This phase reads all of the types from the assembly and adds it into its respective
    /// collection--if the ExcludeFromRepository property returns false.  If the ExcludeFromRepository is true, the singleton object will be discarded.
    /// </summary>
    /// <param name="game"></param>
    public void Load(GameConfiguration gameConfiguration)
    {
        // These are the types to load from the assembly.  The interfaces that are not registered here will be registered just before the configuration is loaded.
        RegisterRepository<IBoolValue>();
        RegisterRepository<ICancellableScript>();
        RegisterRepository<ICancellableScriptInt>();
        RegisterRepository<ICancellableScriptItem>();
        RegisterRepository<ICastScript>();
        RegisterRepository<IChangeTracker>();
        RegisterRepository<IDateAndTimeValue>();
        RegisterRepository<IDirectionalCancellableScriptItem>();
        RegisterRepository<IEnhancementScript>();
        RegisterRepository<IIdentifableAndUsedScript>();
        RegisterRepository<IIdentifableDirectionalScript>();
        RegisterRepository<IIdentifableScript>();
        RegisterRepository<IIdentifiedAndUsedScriptItemDirection>();
        RegisterRepository<IIntValue>();
        RegisterRepository<IMonsterSelector>();
        RegisterRepository<INoticeableScript>();
        RegisterRepository<INullableStringsValue>();
        RegisterRepository<IRepeatableScript>();
        RegisterRepository<IScript>();
        RegisterRepository<IScriptBool>();
        RegisterRepository<IScriptInt>();
        RegisterRepository<IScriptIntInt>();
        RegisterRepository<IScriptItem>();
        RegisterRepository<IScriptItemGridTile>();
        RegisterRepository<IScriptItemInt>();
        RegisterRepository<IScriptItemMonster>();
        RegisterRepository<IScriptStore>();
        RegisterRepository<IStringValue>();
        RegisterRepository<ISuccessByChanceScript>();
        RegisterRepository<ISuccessByChanceScriptInt>();
        RegisterRepository<ITileScript>();
        RegisterRepository<IUnfriendlyScript>();

        RegisterRepository<ActivationWeightedRandom>();
        RegisterRepository<Alignment>();
        RegisterRepository<AlterAction>();
        RegisterRepository<Animation>();
        RegisterRepository<ArtifactBias>();
        RegisterRepository<ArtifactBiasWeightedRandom>();
        RegisterRepository<Attack>();
        RegisterRepository<AttackEffect>();
        RegisterRepository<BaseActivation>();
        RegisterRepository<BaseCharacterClass>();
        RegisterRepository<BirthStage>();
        RegisterRepository<ChestTrap>();
        RegisterRepository<ChestTrapConfiguration>();
        RegisterRepository<ClassSpell>();
        RegisterRepository<Dungeon>();
        RegisterRepository<DungeonGuardian>();
        RegisterRepository<FixedArtifact>();
        RegisterRepository<FlaggedAction>();
        RegisterRepository<Form>();
        RegisterRepository<Function>();
        RegisterRepository<GameCommand>();
        RegisterRepository<Gender>();
        RegisterRepository<God>();
        RegisterRepository<HelpGroup>();
        RegisterRepository<ItemAction>();
        RegisterRepository<ItemClass>();
        RegisterRepository<ItemEnhancement>();
        RegisterRepository<ItemEnhancementWeightedRandom>();
        RegisterRepository<ItemFactory>();
        RegisterRepository<ItemFactoryGenericWeightedRandom>();
        RegisterRepository<ItemFilter>();
        RegisterRepository<ItemFlavor>();
        RegisterRepository<ItemMatch>();
        RegisterRepository<ItemQualityRating>();
        RegisterRepository<ItemTest>();
        RegisterRepository<Justification>();
        RegisterRepository<MartialArtsAttack>();
        RegisterRepository<MonsterFilter>();
        RegisterRepository<MonsterRace>();
        RegisterRepository<MonsterSelector>();
        RegisterRepository<MonsterSpell>();
        RegisterRepository<Mutation>();
        RegisterRepository<Patron>();
        RegisterRepository<Plural>();
        RegisterRepository<Probability>();
        RegisterRepository<Projectile>();
        RegisterRepository<ProjectileGraphic>();
        RegisterRepository<ProjectileScript>();
        RegisterRepository<Property>();
        RegisterRepository<Race>();
        RegisterRepository<Realm>();
        RegisterRepository<Reward>();
        RegisterRepository<RoomLayout>();
        RegisterRepository<Shopkeeper>();
        RegisterRepository<Spell>();
        RegisterRepository<SpellResistantDetection>();
        RegisterRepository<StoreCommand>();
        RegisterRepository<StoreFactory>();
        RegisterRepository<Symbol>();
        RegisterRepository<Talent>();
        RegisterRepository<Tile>();
        RegisterRepository<Timer>();
        RegisterRepository<Town>();
        RegisterRepository<Vault>();
        RegisterRepository<Widget>();
        RegisterRepository<WieldSlot>();
        RegisterRepository<WizardCommand>();

        // Now load the configuration singletons.
        LoadFromConfiguration<Animation, AnimationGameConfiguration, GenericAnimation>(gameConfiguration.Animations);
        LoadFromConfiguration<Attack, AttackGameConfiguration, GenericAttack>(gameConfiguration.Attacks);
        LoadFromConfiguration<ClassSpell, ClassSpellGameConfiguration, GenericClassSpell>(gameConfiguration.ClassSpells);
        LoadFromConfiguration<DungeonGuardian, DungeonGuardianGameConfiguration, GenericDungeonGuardian>(gameConfiguration.DungeonGuardians);
        LoadFromConfiguration<Dungeon, DungeonGameConfiguration, GenericDungeon>(gameConfiguration.Dungeons);
        LoadFromConfiguration<GameCommand, GameCommandGameConfiguration, GenericGameCommand>(gameConfiguration.GameCommands);
        LoadFromConfiguration<God, GodGameConfiguration, GenericGod>(gameConfiguration.Gods);
        LoadFromConfiguration<HelpGroup, HelpGroupGameConfiguration, GenericHelpGroup>(gameConfiguration.HelpGroups);
        LoadFromConfiguration<ItemFlavor, ItemFlavorGameConfiguration, GenericItemFlavor>(gameConfiguration.AmuletReadableFlavors);
        LoadFromConfiguration<MonsterRace, MonsterRaceGameConfiguration, GenericMonsterRace>(gameConfiguration.MonsterRaces);
        LoadFromConfiguration<Plural, PluralGameConfiguration, GenericPlural>(gameConfiguration.Plurals);
        LoadFromConfiguration<ProjectileGraphic, ProjectileGraphicGameConfiguration, GenericProjectileGraphic>(gameConfiguration.ProjectileGraphics);
        LoadFromConfiguration<Shopkeeper, ShopkeeperGameConfiguration, GenericShopkeeper>(gameConfiguration.Shopkeepers);
        LoadFromConfiguration<Spell, SpellGameConfiguration, GenericSpell>(gameConfiguration.Spells);
        LoadFromConfiguration<StoreCommand, StoreCommandGameConfiguration, GenericStoreCommand>(gameConfiguration.StoreCommands);
        LoadFromConfiguration<Symbol, SymbolGameConfiguration, GenericSymbol>(gameConfiguration.Symbols);
        LoadFromConfiguration<Tile, TileGameConfiguration, GenericTile>(gameConfiguration.Tiles);
        LoadFromConfiguration<Town, TownGameConfiguration, GenericTown>(gameConfiguration.Towns);
        LoadFromConfiguration<Vault, VaultGameConfiguration, GenericVault>(gameConfiguration.Vaults);
        LoadFromConfiguration<WizardCommand, WizardCommandGameConfiguration, GenericWizardCommand>(gameConfiguration.WizardCommands);

        // Load the remaining types from the assembly.
        LoadAllAssemblyTypes();

        MonsterRace[] monsterRaces = Get<MonsterRace>();
        MonsterRace[] sortedMonsterRaces = monsterRaces.OrderBy(_monsterRace => _monsterRace.LevelFound).ToArray();
        _singletonsDictionary["MonsterRace"].List.Clear();
        _singletonsDictionary["MonsterRace"].List.AddRange(sortedMonsterRaces);

        // Create all of the repositories.  All of the repositories will be empty and have an instance to the save game.
        ElvishText = AddRepository<ElvishTextRepository>(new ElvishTextRepository(Game));
        FindQuests = AddRepository<FindQuestsRepository>(new FindQuestsRepository(Game));
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
        IllegibleFlavorSyllables = AddRepository<IllegibleFlavorSyllablesRepository>(new IllegibleFlavorSyllablesRepository(Game));
        WorshipPlayerAttacks = AddRepository<WorshipPlayerAttacksRepository>(new WorshipPlayerAttacksRepository(Game));

        // Load all of the objects into each repository.  This is where the assembly will be scanned or the database will be read.
        LoadRepositoryItems(gameConfiguration);
        BindRepositoryItems();

        // Bind all of the singletons now.
        foreach (IGetKey singleton in _allSingletonsList)
        {
            singleton.Bind();
        }
    }
    #endregion

    #region Privates
    private readonly Game Game;
    private readonly List<ILoadAndBind> _repositories = new();

    private Dictionary<string, GenericRepository> _singletonsDictionary = new Dictionary<string, GenericRepository>();

    /// <summary>
    /// Returns a list of all singletons.  This is used to track all of the loaded singletons so that they can be bound quickly and only once.
    /// </summary>
    private List<IGetKey> _allSingletonsList = new List<IGetKey>();

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

    private T AddRepository<T>(T repository) where T : ILoadAndBind
    {
        _repositories.Add(repository);
        return repository;
    }

    private void LoadRepositoryItems(GameConfiguration gameConfiguration)
    {
        foreach (ILoadAndBind repository in _repositories)
        {
            repository.Load(gameConfiguration);
        }
    }

    private void BindRepositoryItems()
    {
        foreach (ILoadAndBind repository in _repositories)
        {
            repository.Bind();
        }
    }

    private void LoadSingleton(object? singleton)
    {
        // Enumerate all of the interfaces that the singleton implements.
        Type type = singleton.GetType();
        string name = type.Name;
        List<Type> interfaceTypeNames = new List<Type>();
        interfaceTypeNames.AddRange(type.GetInterfaces());
        Type? baseType = type.BaseType;
        while (baseType != null)
        {
            interfaceTypeNames.Add(baseType);
            baseType = baseType.BaseType;
        }

        // Place the singleton into the respective dictionary repositories for each interface.
        foreach (Type interfaceType in interfaceTypeNames)
        {
            string typeName = interfaceType.Name;

            // Check to see if there is a repository that is registered for this type.  There is none; we simple ignore this interface.
            if (_singletonsDictionary.TryGetValue(typeName, out GenericRepository? genericRepository))
            {
                // Ensure the singleton implements the IGetKey interface and get the key from the singleton.
                switch (singleton)
                {
                    case IGetKey getKeySingleton:
                        string key = getKeySingleton.GetKey;

                        // Add the singleton to the list of singletons so that they can be bound.  Only add the singleton once.
                        if (!_allSingletonsList.Contains(getKeySingleton))
                        {
                            _allSingletonsList.Add(getKeySingleton);
                        }

                        // If the singleton hasn't been registered, register it now.  The singleton may belong to many repositories.
                        if (!genericRepository.Dictionary.TryGetValue(key, out _))
                        {
                            genericRepository.Add(key, singleton);
                        }
                        break;
                    default:
                        throw new Exception($"The singleton {type.Name} does not implement the IGetKey interface.");
                }
            }
        }
    }

    private void LoadAllAssemblyTypes()
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        Type[] types = assembly.GetTypes();
        foreach (Type type in types)
        {
            // Ensure the type is not abstract and inherits the IGetKey interface.
            // TODO: No test for IGetKey is done
            if (!type.IsAbstract && typeof(IGetKey).IsAssignableFrom(type))
            {
                // Ensure it only has one private constructor.
                // TODO: The one private constructor needs to be tested properly.
                ConstructorInfo[] constructors = type.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance);
                if (constructors.Length == 1)
                {
                    // We will only instantiate the singleton, if we are storing it.
                    object? singleton = constructors[0].Invoke(new object[] { Game });
                    LoadSingleton(singleton);
                }
            }
        }
    }

    private void LoadFromConfiguration<T, TConfiguration, TGeneric>(TConfiguration[]? entityConfigurations) where T : IGetKey where TGeneric : T where TConfiguration : notnull
    {
        string typeName = typeof(T).Name;
        if (entityConfigurations != null)
        {
            ConstructorInfo[] constructors = typeof(TGeneric).GetConstructors(BindingFlags.Public | BindingFlags.Instance);
            if (constructors.Length != 1)
            {
                throw new Exception($"Invalid number of constructors for {typeof(TGeneric)}.");
            }
            foreach (TConfiguration entityConfiguration in entityConfigurations)
            {
                T entity = (T)constructors[0].Invoke(new object[] { Game, entityConfiguration });
                LoadSingleton(entity);
            }
        }
    }
    #endregion
}
