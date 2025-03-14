﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using AngbandOS.Core.RenderMessageScripts;
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
            throw new Exception($"The repository was registered but the singleton {typeof(T).Name}.{key} does not exist.\n\n1. Ensure the {nameof(IGetKey)} interface was implemented on the {typeof(T).Name} class.\n\n2. There is only one private constructor and that it only accepts the Game parameter.\n\n3. The singletons are either loaded fromt the Assembly or the configuration.\n\n");
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
    /// Persists the entire configuration using the CorePersistentStorage driver.
    /// </summary>
    /// <param name="name"></param>
    public void PersistConfiguration(string configurationName)
    {
        try
        {
            // Dictionary repositories.
            foreach (KeyValuePair<string, GenericRepository> typeNameAndRepository in _singletonsDictionary)
            {
                List<KeyValuePair<string, string>> jsonEntityList = new List<KeyValuePair<string, string>>();
                foreach (KeyValuePair<string, object> keyAndEntity in typeNameAndRepository.Value.Dictionary)
                {
                    string key = keyAndEntity.Key; // entity.GetKey.ToString(); // TODO: The use of .ToString is because TKey needs to be strings
                    IGetKey entity = (IGetKey)keyAndEntity.Value;
                    string serializedEntity = entity.ToJson();
                    jsonEntityList.Add(new KeyValuePair<string, string>(key, serializedEntity));
                }
                string pluralName = Game.Pluralize(typeNameAndRepository.Key);
                Game.CorePersistentStorage.PersistEntities(configurationName, pluralName, jsonEntityList.ToArray());
            }
        }
        catch (NotImplementedException)
        {
            Game.MsgPrint("The persistance interface does not support entity persistance.");
            return;
        }
        catch (Exception)
        {
            Game.MsgPrint("The persistance interface failed to save the configuration.");
            return;
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
        RegisterRepository<IActivateItemScript>();
        RegisterRepository<IAimWandScript>();
        RegisterRepository<IBoolValue>();
        RegisterRepository<ICastSpellScript>();
        RegisterRepository<IChangeTracker>();
        RegisterRepository<IDateAndTimeValue>();
        RegisterRepository<IEatOrQuaffScript>();
        RegisterRepository<IEnhancementScript>();
        RegisterRepository<IGameCommandScript>();
        RegisterRepository<IIntValue>();
        RegisterRepository<IMonsterSelector>();
        RegisterRepository<INullableStringsValue>();
        RegisterRepository<IReadScrollOrUseStaffScript>();
        RegisterRepository<IScript>();
        RegisterRepository<IScriptBool>();
        RegisterRepository<IScriptInt>();
        RegisterRepository<IScriptIntInt>();
        RegisterRepository<IScriptItem>();
        RegisterRepository<IScriptItemGridTile>();
        RegisterRepository<IScriptItemInt>();
        RegisterRepository<IScriptItemMonster>();
        RegisterRepository<IStoreCommandScript>();
        RegisterRepository<IStringValue>();
        RegisterRepository<ITileScript>();
        RegisterRepository<IUsedScriptInt>();
        RegisterRepository<IZapRodScript>();

        RegisterRepository<ActivationWeightedRandom>();
        RegisterRepository<AffectMonsterScript>();
        RegisterRepository<Alignment>();
        RegisterRepository<AlterAction>();
        RegisterRepository<Animation>();
        RegisterRepository<ArtifactBias>();
        RegisterRepository<ArtifactBiasWeightedRandom>();
        RegisterRepository<Attack>();
        RegisterRepository<AttackEffect>();
        RegisterRepository<Activation>();
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
        RegisterRepository<MonsterRaceFilter>();
        RegisterRepository<MonsterSelector>();
        RegisterRepository<MonsterSpell>();
        RegisterRepository<Mutation>();
        RegisterRepository<Patron>();
        RegisterRepository<Plural>();
        RegisterRepository<ProbabilityExpression>();
        RegisterRepository<Projectile>();
        RegisterRepository<ProjectileGraphic>();
        RegisterRepository<ProjectileScript>();
        RegisterRepository<Property>();
        RegisterRepository<Race>();
        RegisterRepository<Realm>();
        RegisterRepository<RenderMessageScript>();
        RegisterRepository<Reward>();
        RegisterRepository<RoomLayout>();
        RegisterRepository<Shopkeeper>();
        RegisterRepository<Spell>();
        RegisterRepository<SpellResistantDetection>();
        RegisterRepository<StoreCommand>();
        RegisterRepository<StoreFactory>();
        RegisterRepository<SummonScript>();
        RegisterRepository<SyllableSet>();
        RegisterRepository<Symbol>();
        RegisterRepository<Talent>();
        RegisterRepository<Tile>();
        RegisterRepository<Timer>();
        RegisterRepository<Town>();
        RegisterRepository<Vault>();
        RegisterRepository<Widget>();
        RegisterRepository<WieldSlot>();
        RegisterRepository<WizardCommand>();

        // Load system singletons.
        LoadAllAssemblyTypes<Alignment>();
        LoadAllAssemblyTypes<ConsoleElement>();
        LoadAllAssemblyTypes<FlaggedAction>();
        LoadAllAssemblyTypes<Justification>();
        LoadAllAssemblyTypes<MonsterSelector>();
        LoadAllAssemblyTypes<Function>();
        LoadAllAssemblyTypes<ProbabilityExpression>();
        LoadAllAssemblyTypes<Property>();
        LoadAllAssemblyTypes<Timer>();

        // Now load the user-configured singletons.
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
        LoadFromConfiguration<SyllableSet, SyllableSetGameConfiguration, GenericSyllableSet>(gameConfiguration.SyllableSets);
        LoadFromConfiguration<Symbol, SymbolGameConfiguration, GenericSymbol>(gameConfiguration.Symbols);
        LoadFromConfiguration<Tile, TileGameConfiguration, GenericTile>(gameConfiguration.Tiles);
        LoadFromConfiguration<Town, TownGameConfiguration, GenericTown>(gameConfiguration.Towns);
        LoadFromConfiguration<Vault, VaultGameConfiguration, GenericVault>(gameConfiguration.Vaults);
        LoadFromConfiguration<WizardCommand, WizardCommandGameConfiguration, GenericWizardCommand>(gameConfiguration.WizardCommands);

        // Load the remaining user-configured singletons from the assembly.
        LoadAllAssemblyTypes<Activation>();
        LoadAllAssemblyTypes<ActivationWeightedRandom>();
        LoadAllAssemblyTypes<AffectMonsterScript>();
        LoadAllAssemblyTypes<AlterAction>();
        LoadAllAssemblyTypes<ArtifactBias>();
        LoadAllAssemblyTypes<ArtifactBiasWeightedRandom>();
        LoadAllAssemblyTypes<AttackEffect>();
        LoadAllAssemblyTypes<BirthStage>();
        LoadAllAssemblyTypes<BaseCharacterClass>();
        LoadAllAssemblyTypes<ChestTrapConfiguration>();
        LoadAllAssemblyTypes<ChestTrap>();
        LoadAllAssemblyTypes<DungeonGenerator>();
        LoadAllAssemblyTypes<FixedArtifact>();
        LoadAllAssemblyTypes<Form>();
        LoadAllAssemblyTypes<Gender>();
        LoadAllAssemblyTypes<ItemAction>();
        LoadAllAssemblyTypes<ItemClass>();
        LoadAllAssemblyTypes<ItemEnhancement>();
        LoadAllAssemblyTypes<ItemEnhancementWeightedRandom>();
        LoadAllAssemblyTypes<ItemFactory>();
        LoadAllAssemblyTypes<ItemFactoryGenericWeightedRandom>();
        LoadAllAssemblyTypes<ItemFilter>();
        LoadAllAssemblyTypes<ItemQualityRating>();
        LoadAllAssemblyTypes<ItemTest>();
        LoadAllAssemblyTypes<MartialArtsAttack>();
        LoadAllAssemblyTypes<MonsterFilter>();
        LoadAllAssemblyTypes<MonsterRaceFilter>();
        LoadAllAssemblyTypes<MonsterSpell>();
        LoadAllAssemblyTypes<Mutation>();
        LoadAllAssemblyTypes<Patron>();
        LoadAllAssemblyTypes<Projectile>();
        LoadAllAssemblyTypes<ProjectileScript>();
        LoadAllAssemblyTypes<ProjectileWeightedRandomScript>();
        LoadAllAssemblyTypes<Race>();
        LoadAllAssemblyTypes<Realm>();
        LoadAllAssemblyTypes<RenderMessageScript>();
        LoadAllAssemblyTypes<Reward>();
        LoadAllAssemblyTypes<RoomLayout>();
        LoadAllAssemblyTypes<Script>();
        LoadAllAssemblyTypes<SpellResistantDetection>();
        LoadAllAssemblyTypes<StoreFactory>();
        LoadAllAssemblyTypes<SummonScript>();
        LoadAllAssemblyTypes<SummonWeightedRandom>();
        LoadAllAssemblyTypes<Talent>();
        LoadAllAssemblyTypes<Widget>();
        LoadAllAssemblyTypes<WieldSlot>();

        // Monsters must be sorted by the LevelFound property; otherwise, the game doesn't work properly.
        MonsterRace[] monsterRaces = Get<MonsterRace>();
        MonsterRace[] sortedMonsterRaces = monsterRaces.OrderBy(_monsterRace => _monsterRace.LevelFound).ToArray();
        _singletonsDictionary["MonsterRace"].List.Clear();
        _singletonsDictionary["MonsterRace"].List.AddRange(sortedMonsterRaces);

        // Bind all of the singletons now.
        foreach (IGetKey singleton in _allSingletonsList)
        {
            singleton.Bind();
        }
    }
    #endregion

    #region Privates
    private readonly Game Game;
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

    private void LoadAllAssemblyTypes<T>()
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        Type[] types = assembly.GetTypes();
        foreach (Type type in types)
        {
            // Ensure the type is not abstract and inherits the IGetKey interface.
            // TODO: No test for IGetKey is done
            if (!type.IsAbstract && typeof(IGetKey).IsAssignableFrom(type) && typeof(T).IsAssignableFrom(type))
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
                // We need to convert from the GameConfiguration object to the entity object.  Create the generic object
                TGeneric entity = (TGeneric)constructors[0].Invoke(new object[] { Game, entityConfiguration });
                LoadSingleton(entity);
            }
        }
        else
        {
            LoadAllAssemblyTypes<T>();
        }
    }
    #endregion
}
