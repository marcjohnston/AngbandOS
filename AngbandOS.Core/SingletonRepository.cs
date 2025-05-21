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

    private GenericRepository? ValidateAndLookupRepository<T>()
    {
        string typeName = typeof(T).Name;
        if (!_singletonsDictionary.TryGetValue(typeName, out GenericRepository? genericRepository))
        {
            throw new Exception($"The {typeof(T).Name} singleton interface was not registered.");
        }
        return genericRepository;
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
        // Check to see if the dictionary has a dictionary for this type of object.
        GenericRepository? genericRepository = ValidateAndLookupRepository<T>();

        if (key == null)
        {
            return null;
        }

        T? value = TryGet<T>(key);
        if (value == null)
        {
            throw new Exception($"The {typeof(T).Name} repository was registered but the singleton {key} does not exist.\n\n1. Ensure the {nameof(IGetKey)} interface was implemented on the {typeof(T).Name} class.\n\n2. There is only one private constructor and that it only accepts the Game parameter.\n\n3. The singletons are either loaded fromt the Assembly or the configuration.\n\n");
        }
        return value;
    }

    public T? TryGetNullable<T>(string? key) where T : class
    {
        if (key is null)
        {
            return null;
        }
        return TryGet<T>(key);
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
        ValidateNonNullKey(key);

        // Check to see if the dictionary has a dictionary for this type of object.
        GenericRepository? genericRepository = ValidateAndLookupRepository<T>();

        // We will only take the last token when a period is found.  This is to support game-packs use of the nameof(*Enum.object) references.  The enum is included as the first token and needs to be removed.
        // Composite keyed objects will use a dash.
        string[] keyTokens = key.Split('.');
        key = keyTokens[keyTokens.Length - 1];

        // Retrieve the singleton by key name.
        if (!genericRepository.Dictionary.TryGetValue(key, out object? singleton))
        {
            return null;
        }
        return (T)singleton;
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
        ValidateNonNullKey(key);

        T? singleton = GetNullable<T>(key);
        if (singleton == null)
        {
            throw new Exception($"The singleton {typeof(T).Name}.{key} does not exist.");
        }
        return singleton;
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

    private void ValidateNonNullKey(string? key)
    {
        if (key == null)
        {
            throw new Exception($"A null key has been presented to a non-nullable binding request.  Use the {nameof(GetNullable)} method.");
        }
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
        catch (Exception ex)
        {
            Game.MsgPrint($"The persistance interface failed to save the configuration '{ex.Message}'.");
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
        RegisterRepository<BoolWidget>();
        RegisterRepository<ChestTrap>();
        RegisterRepository<ChestTrapConfiguration>();
        RegisterRepository<ClassSpell>();
        RegisterRepository<DateWidget>();
        RegisterRepository<Dungeon>();
        RegisterRepository<DungeonGuardian>();
        RegisterRepository<FixedArtifact>();
        RegisterRepository<FlaggedAction>();
        RegisterRepository<FloorEffect>();
        RegisterRepository<Form>();
        RegisterRepository<Function>();
        RegisterRepository<GameCommand>();
        RegisterRepository<Gender>();
        RegisterRepository<God>();
        RegisterRepository<HelpGroup>();
        RegisterRepository<IntWidget>();
        RegisterRepository<ItemAction>();
        RegisterRepository<ItemClass>();
        RegisterRepository<ItemEffect>();
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
        RegisterRepository<MapWidget>();
        RegisterRepository<MartialArtsAttack>();
        RegisterRepository<MaxRangedWidget>();
        RegisterRepository<MonsterEffect>();
        RegisterRepository<MonsterFilter>();
        RegisterRepository<MonsterRace>();
        RegisterRepository<MonsterRaceFilter>();
        RegisterRepository<MonsterSelector>();
        RegisterRepository<MonsterSpell>();
        RegisterRepository<Mutation>();
        RegisterRepository<NullableStringsTextAreaWidget>();
        RegisterRepository<Patron>();
        RegisterRepository<PhysicalAttributeSet>();
        RegisterRepository<PlayerEffect>();
        RegisterRepository<Plural>();
        RegisterRepository<ProbabilityExpression>();
        RegisterRepository<Projectile>();
        RegisterRepository<ProjectileGraphic>();
        RegisterRepository<ProjectileScript>();
        RegisterRepository<Property>();
        RegisterRepository<Race>();
        RegisterRepository<RaceGender>();
        RegisterRepository<RangedWidget>();
        RegisterRepository<Realm>();
        RegisterRepository<RealmCharacterClass>();
        RegisterRepository<RenderMessageScript>();
        RegisterRepository<Reward>();
        RegisterRepository<RoomLayout>();
        RegisterRepository<Shopkeeper>();
        RegisterRepository<Spell>();
        RegisterRepository<SpellResistantDetection>();
        RegisterRepository<StoreCommand>();
        RegisterRepository<StoreFactory>();
        RegisterRepository<StringWidget>();
        RegisterRepository<SummonScript>();
        RegisterRepository<SyllableSet>();
        RegisterRepository<Symbol>();
        RegisterRepository<Talent>();
        RegisterRepository<TextWidget>();
        RegisterRepository<Tile>();
        RegisterRepository<Timer>();
        RegisterRepository<Town>();
        RegisterRepository<Vault>();
        RegisterRepository<TimeWidget>();
        RegisterRepository<WieldSlot>();
        RegisterRepository<Widget>();
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

        // Now load the user-configured singletons.  These singletons have been exported to the GamePack.
        LoadFromConfiguration<Animation, AnimationGameConfiguration, Animation>(gameConfiguration.Animations);
        LoadFromConfiguration<ArtifactBiasWeightedRandom, ArtifactBiasWeightedRandomGameConfiguration, GenericArtifactBiasWeightedRandom>(gameConfiguration.ArtifactBiasWeightedRandoms);
        LoadFromConfiguration<Attack, AttackGameConfiguration, Attack>(gameConfiguration.Attacks);
        LoadFromConfiguration<BoolWidget, BoolWidgetGameConfiguration, GenericBoolWidget>(gameConfiguration.BoolWidgets);
        LoadFromConfiguration<ClassSpell, ClassSpellGameConfiguration, GenericClassSpell>(gameConfiguration.ClassSpells);
        LoadFromConfiguration<ConditionalWidget, ConditionalWidgetGameConfiguration, GenericConditionalWidget>(gameConfiguration.ConditionalWidgets);
        LoadFromConfiguration<DateWidget, DateWidgetGameConfiguration, GenericDateWidget>(gameConfiguration.DateWidgets);
        LoadFromConfiguration<DungeonGuardian, DungeonGuardianGameConfiguration, GenericDungeonGuardian>(gameConfiguration.DungeonGuardians);
        LoadFromConfiguration<Dungeon, DungeonGameConfiguration, GenericDungeon>(gameConfiguration.Dungeons);
        LoadFromConfiguration<GameCommand, GameCommandGameConfiguration, GameCommand>(gameConfiguration.GameCommands);
        LoadFromConfiguration<Gender, GenderGameConfiguration, Gender>(gameConfiguration.Genders);
        LoadFromConfiguration<God, GodGameConfiguration, GenericGod>(gameConfiguration.Gods);
        LoadFromConfiguration<HelpGroup, HelpGroupGameConfiguration, GenericHelpGroup>(gameConfiguration.HelpGroups);
        LoadFromConfiguration<IntWidget, IntWidgetGameConfiguration, GenericIntWidget>(gameConfiguration.IntWidgets);
        LoadFromConfiguration<ItemClass, ItemClassGameConfiguration, GenericItemClass>(gameConfiguration.ItemClasses);
        LoadFromConfiguration<ItemEnhancement, ItemEnhancementGameConfiguration, GenericItemEnhancement>(gameConfiguration.ItemEnhancements);
        LoadFromConfiguration<ItemEnhancementWeightedRandom, ItemEnhancementWeightedRandomGameConfiguration, GenericItemEnhancementWeightedRandom>(gameConfiguration.ItemEnhancementWeightedRandoms);
        LoadFromConfiguration<ItemFactory, ItemFactoryGameConfiguration, GenericItemFactory>(gameConfiguration.ItemFactories);
        LoadFromConfiguration<ItemFlavor, ItemFlavorGameConfiguration, GenericItemFlavor>(gameConfiguration.ItemFlavors);
        LoadFromConfiguration<MapWidget, MapWidgetGameConfiguration, GenericMapWidget>(gameConfiguration.MapWidgets);
        LoadFromConfiguration<MaxRangedWidget, MaxRangedWidgetGameConfiguration, GenericMaxRangedWidget>(gameConfiguration.MaxRangedWidgets);
        LoadFromConfiguration<MonsterRace, MonsterRaceGameConfiguration, GenericMonsterRace>(gameConfiguration.MonsterRaces);
        LoadFromConfiguration<NullableStringsTextAreaWidget, NullableStringsTextAreaWidgetGameConfiguration, GenericNullableStringsTextAreaWidget>(gameConfiguration.NullableStringsTextAreaWidgets);
        LoadFromConfiguration<PhysicalAttributeSet, PhysicalAttributeSetGameConfiguration, PhysicalAttributeSet>(gameConfiguration.PhysicalAttributeSets);
        LoadFromConfiguration<Plural, PluralGameConfiguration, GenericPlural>(gameConfiguration.Plurals);
        LoadFromConfiguration<ProjectileGraphic, ProjectileGraphicGameConfiguration, GenericProjectileGraphic>(gameConfiguration.ProjectileGraphics);
        LoadFromConfiguration<Projectile, ProjectileGameConfiguration, GenericProjectile>(gameConfiguration.Projectiles);
        LoadFromConfiguration<ProjectileScript, ProjectileScriptGameConfiguration, GenericProjectileScript>(gameConfiguration.ProjectileScripts);
        LoadFromConfiguration<ProjectileWeightedRandom, ProjectileWeightedRandomGameConfiguration, GenericProjectileWeightedRandomScript>(gameConfiguration.ProjectileWeightedRandomScripts);
        LoadFromConfiguration<RaceGender, RaceGenderGameConfiguration, RaceGender>(gameConfiguration.RaceGenders);
        LoadFromConfiguration<RangedWidget, RangedWidgetGameConfiguration, GenericRangedWidget>(gameConfiguration.RangedWidgets);
        LoadFromConfiguration<Realm, RealmGameConfiguration, Realm>(gameConfiguration.Realms);
        LoadFromConfiguration<RealmCharacterClass, RealmCharacterClassGameConfiguration, RealmCharacterClass>(gameConfiguration.RealmCharacterClasses);
        LoadFromConfiguration<Shopkeeper, ShopkeeperGameConfiguration, GenericShopkeeper>(gameConfiguration.Shopkeepers);
        LoadFromConfiguration<Spell, SpellGameConfiguration, GenericSpell>(gameConfiguration.Spells);
        LoadFromConfiguration<StoreCommand, StoreCommandGameConfiguration, GenericStoreCommand>(gameConfiguration.StoreCommands);
        LoadFromConfiguration<StoreFactory, StoreFactoryGameConfiguration, GenericStoreFactory>(gameConfiguration.StoreFactories);
        LoadFromConfiguration<StringWidget, StringWidgetGameConfiguration, GenericStringWidget>(gameConfiguration.StringWidgets);
        LoadFromConfiguration<SyllableSet, SyllableSetGameConfiguration, GenericSyllableSet>(gameConfiguration.SyllableSets);
        LoadFromConfiguration<Symbol, SymbolGameConfiguration, GenericSymbol>(gameConfiguration.Symbols);
        LoadFromConfiguration<TextWidget, TextWidgetGameConfiguration, GenericTextWidget>(gameConfiguration.TextWidgets);
        LoadFromConfiguration<Tile, TileGameConfiguration, GenericTile>(gameConfiguration.Tiles);
        LoadFromConfiguration<TimeWidget, TimeWidgetGameConfiguration, GenericTimeWidget>(gameConfiguration.TimeWidgets);
        LoadFromConfiguration<Town, TownGameConfiguration, GenericTown>(gameConfiguration.Towns);
        LoadFromConfiguration<Vault, VaultGameConfiguration, GenericVault>(gameConfiguration.Vaults);
        LoadFromConfiguration<WizardCommand, WizardCommandGameConfiguration, WizardCommand>(gameConfiguration.WizardCommands);

        // Load the remaining user-configured singletons from the assembly.  These singletons have not been exported to the GamePack yet.
        LoadAllAssemblyTypes<Activation>();
        LoadAllAssemblyTypes<ActivationWeightedRandom>();
        LoadAllAssemblyTypes<AlterAction>();
        LoadAllAssemblyTypes<ArtifactBias>();
        LoadAllAssemblyTypes<AttackEffect>();
        LoadAllAssemblyTypes<BirthStage>();
        LoadAllAssemblyTypes<BaseCharacterClass>();
        LoadAllAssemblyTypes<ChestTrapConfiguration>();
        LoadAllAssemblyTypes<ChestTrap>();
        LoadAllAssemblyTypes<DungeonGenerator>();
        LoadAllAssemblyTypes<FixedArtifact>();
        LoadAllAssemblyTypes<FloorEffect>();
        LoadAllAssemblyTypes<Form>();
        LoadAllAssemblyTypes<ItemAction>();
        LoadAllAssemblyTypes<ItemEffect>();
        LoadAllAssemblyTypes<ItemFactoryGenericWeightedRandom>();
        LoadAllAssemblyTypes<ItemFilter>();
        LoadAllAssemblyTypes<ItemQualityRating>();
        LoadAllAssemblyTypes<ItemTest>();
        LoadAllAssemblyTypes<MartialArtsAttack>();
        LoadAllAssemblyTypes<MonsterEffect>();
        LoadAllAssemblyTypes<MonsterFilter>();
        LoadAllAssemblyTypes<MonsterRaceFilter>();
        LoadAllAssemblyTypes<MonsterSpell>();
        LoadAllAssemblyTypes<Mutation>();
        LoadAllAssemblyTypes<Patron>();
        LoadAllAssemblyTypes<PlayerEffect>();
        LoadAllAssemblyTypes<Race>();
        LoadAllAssemblyTypes<RenderMessageScript>();
        LoadAllAssemblyTypes<Reward>();
        LoadAllAssemblyTypes<RoomLayout>();
        LoadAllAssemblyTypes<Script>();
        LoadAllAssemblyTypes<SpellResistantDetection>();
        LoadAllAssemblyTypes<SummonScript>();
        LoadAllAssemblyTypes<SummonWeightedRandom>();
        LoadAllAssemblyTypes<Talent>();
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

    /// <summary>
    /// Registers a singleton with all of the repositories by determining all of the interfaces and base classes that the singleton supports and registering the singleton
    /// with each associated repository.
    /// </summary>
    /// <param name="singleton"></param>
    /// <exception cref="Exception"></exception>
    private void RegisterSingleton(IGetKey singleton)
    {
        // Enumerate all of the interfaces that the singleton implements.
        Type? type = singleton.GetType();
        string name = type.Name;
        List<Type> interfaceTypeNames = new List<Type>();
        interfaceTypeNames.AddRange(type.GetInterfaces());
        while (type != null)
        {
            interfaceTypeNames.Add(type);
            type = type.BaseType;
        }

        // Place the singleton into the respective dictionary repositories for each interface.
        foreach (Type interfaceType in interfaceTypeNames)
        {
            string typeName = interfaceType.Name;

            // Check to see if there is a repository that is registered for this type.  There is none; we simple ignore this interface.
            if (_singletonsDictionary.TryGetValue(typeName, out GenericRepository? genericRepository))
            {
                string? key = singleton.GetKey;
                if (key is null)
                {
                    throw new Exception($"The singleton {singleton.GetType().Name} has a null key value.  This may be the result of a the json deserialization.");
                }

                // Add the singleton to the list of singletons so that they can be bound.  Only add the singleton once.
                if (!_allSingletonsList.Contains(singleton))
                {
                    _allSingletonsList.Add(singleton);
                }

                // If the singleton hasn't been registered, register it now.  The singleton may belong to many repositories.
                if (!genericRepository.Dictionary.TryGetValue(key, out _))
                {
                    genericRepository.Add(key, singleton);
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
                    try
                    {
                        IGetKey singleton = (IGetKey)constructors[0].Invoke(new object[] { Game });
                        RegisterSingleton(singleton);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"An error occurred instantiating the {type.Name} singleton '{ex.Message}'.  Check to ensure the constructor is private(Game game).");
                    }
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
                throw new Exception($"Invalid number of constructors {constructors.Length} for {typeof(TGeneric)}.  Expecting exactly one public (Game, {typeof(TConfiguration).Name})");
            }
            foreach (TConfiguration entityConfiguration in entityConfigurations)
            {
                // We need to convert from the GameConfiguration object to the entity object.  Create the generic object
                TGeneric entity = (TGeneric)constructors[0].Invoke(new object[] { Game, entityConfiguration });
                RegisterSingleton(entity);
            }
        }
        else
        {
            LoadAllAssemblyTypes<T>();
        }
    }
    #endregion
}
