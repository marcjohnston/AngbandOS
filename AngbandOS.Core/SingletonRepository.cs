// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using System.Reflection;
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
        T[] list = _allGenericRepositoriesDictionary[typeName].Get<T>();
        return new WeightedRandom<T>(Game, list, predicate);
    }

    private GenericRepository? ValidateAndLookupRepository<T>()
    {
        string typeName = typeof(T).Name;
        if (!_allGenericRepositoriesDictionary.TryGetValue(typeName, out GenericRepository? genericRepository))
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
    public T? GetNullable<T>(string? key) where T : class // TODO: WHY CANT THIS BE where T: IGETKEY
    {
        // Check to see if the dictionary has a dictionary for this type of object.
        GenericRepository? genericRepository = ValidateAndLookupRepository<T>();

        if (key == null)
        {
            return default;
        }

        T? value = TryGet<T>(key);
        if (value == null)
        {
            throw new Exception($"The {typeof(T).Name} repository was registered but the singleton {key} does not exist.\n\n1. Ensure the {nameof(IGetKey)} interface was implemented on the {typeof(T).Name} class.\n\n2. There is only one private constructor and that it only accepts the Game parameter.\n\n3. The singletons are either loaded from the Assembly or the configuration.\n\n");
        }
        return value;
    }

    public T? TryGetNullable<T>(string? key) where T : class // TODO: WHY CANT THIS BE where T: IGETKEY
    {
        if (key is null)
        {
            return default;
        }
        return TryGet<T>(key);
    }

    /// <summary>
    /// Retrieves an API Object by its <paramref name="key"/> from the registered repository (see <see cref="RegisterInterface"/> for more information) of type <typeparamref name="T"/> and returns null, if it isn't found.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public T? TryGet<T>(string key) where T : class // TODO: WHY CANT THIS BE where T: IGETKEY
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
            return default;
        }
        return (T)singleton;
    }

    /// <summary>
    /// Retrieves an API Object by its <paramref name="key"/> from the registered repository (see <see cref="RegisterInterface"/> for more information) of type <typeparamref name="T"/> and throws an exception if it isn't found.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public T Get<T>(string key) where T : class // TODO: WHY CANT THIS BE where T: IGETKEY
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
    public T[]? GetNullable<T>(string[]? keys) where T : class // TODO: WHY CANT THIS BE where T: IGETKEY
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
    public T[] Get<T>() where T : class // TODO: WHY CANT THIS BE where T: IGETKEY (BECAUSE WE DO THINGS LIKE .Get<ICHANGETRACKER>
    {
        string typeName = typeof(T).Name;
        return _allGenericRepositoriesDictionary[typeName].Get<T>();
    }

    /// <summary>
    /// Returns the number of API Objects in a registered repository (see <see cref="RegisterInterface"/> for more information).
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public int Count<T>()
    {
        string typeName = typeof(T).Name;
        return _allGenericRepositoriesDictionary[typeName].Count;
    }

    /// <summary>
    /// Returns an array of API Objects from the registered repository (see <see cref="RegisterInterface"/> for more information) of type <typeparamref name="T"/> by their unique key 
    /// identifiers <paramref name="keys"/>.  If any the singletons do not exist, an exception is thrown.  Empty arrays are supported and will return an empty array.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="key"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public T[] Get<T>(string[] keys) where T : class // TODO: WHY CANT THIS BE where T: IGETKEY
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

    public T Get<T>(int index) where T : class // TODO: WHY CANT THIS BE where T: IGETKEY
    {
        string typeName = typeof(T).Name;
        return (T)_allGenericRepositoriesDictionary[typeName].List[index];
    }

    /// <summary>
    /// Persists the entire configuration using the CorePersistentStorage driver.
    /// </summary>
    /// <param name="name"></param>
    public void PersistConfiguration(string configurationName)
    {
        try
        {
            // Enumerate all of the repositories.
            KeyValuePair<string, GenericRepository>[] persistedRepositories = _allGenericRepositoriesDictionary.Where(_repository => _repository.Value.EnablePersistance).ToArray();
            foreach (KeyValuePair<string, GenericRepository> typeNameAndRepository in persistedRepositories)
            {
                // We need to serialize all of the entities.
                List<KeyValuePair<string, string>> jsonEntityList = new List<KeyValuePair<string, string>>();
                foreach (KeyValuePair<string, object> keyAndEntity in typeNameAndRepository.Value.Dictionary)
                {
                    object entityAsObject = keyAndEntity.Value;
                    Type entityType = entityAsObject.GetType();

                    IGetKey entityAsIGetKey = (IGetKey)keyAndEntity.Value;
                    string key = entityAsIGetKey.GetKey;
                    IToJson entityAsIToJson = (IToJson)entityAsObject;
                    string serializedEntity = entityAsIToJson.ToJson();
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
    public void LoadAndBind(GameConfiguration gameConfiguration)
    {
        // These are the types to load from the assembly.  The interfaces that are not registered here will be registered just before the configuration is loaded.
        RegisterInterface<IGetKey>(); // This repository should be needed, it is capable of retrieving all singletons.
        RegisterInterface<IActivateItemScript>();
        RegisterInterface<IAimWandScript>();
        RegisterInterface<IBoolValue>();
        RegisterInterface<ICastSpellScript>();
        RegisterInterface<IChangeTracker>();
        RegisterInterface<IDateAndTimeValue>();
        RegisterInterface<IEatOrQuaffScript>();
        RegisterInterface<IEnhancementScript>();
        RegisterInterface<IGameCommandScript>();
        RegisterInterface<IIntValue>();
        RegisterInterface<IItemEnhancement>();
        RegisterInterface<IMonsterSelector>();
        RegisterInterface<ITextValue>();
        RegisterInterface<IReadScrollOrUseStaffScript>();
        RegisterInterface<IScript>();
        RegisterInterface<IScriptBool>();
        RegisterInterface<IScriptItem>();
        RegisterInterface<IScriptItemGridTile>();
        RegisterInterface<IScriptItemInt>();
        RegisterInterface<IScriptItemMonster>();
        RegisterInterface<IStoreCommandScript>();
        RegisterInterface<IStringValue>();
        RegisterInterface<IUsedScript>();
        RegisterInterface<IZapRodScript>();

        // Base preload
        RegisterInterface<Attribute>();

        // Not configurable yet
        RegisterInterface<Ability>();
        RegisterInterface<ActivationWeightedRandom>();
        RegisterInterface<Alignment>();
        RegisterInterface<AlterAction>();
        RegisterInterface<ArtifactBias>();
        RegisterInterface<AttackEffect>();
        RegisterInterface<CharacterClass>();
        RegisterInterface<BirthStage>();
        RegisterInterface<FixedArtifact>();
        RegisterInterface<FlaggedAction>();
        RegisterInterface<GridTileScript>();
        RegisterInterface<ItemAction>();
        RegisterInterface<ItemEffect>();
        RegisterInterface<ItemMatch>();
        RegisterInterface<ItemQualityRating>();
        RegisterInterface<Justification>();
        RegisterInterface<MartialArtsEffect>();
        RegisterInterface<MonsterEffect>();
        RegisterInterface<MonsterFilter>();
        RegisterInterface<MonsterRaceFilter>();
        RegisterInterface<MonsterSelector>();
        RegisterInterface<MonsterSpell>();
        RegisterInterface<Mutation>();
        RegisterInterface<PlayerEffectUniversalScript>();
        RegisterInterface<ProbabilityExpression>();
        RegisterInterface<Property>();
        RegisterInterface<Race>();
        RegisterInterface<Reward>();
        RegisterInterface<RoomLayout>();
        RegisterInterface<SpellResistantDetection>();
        RegisterInterface<Talent>();
        RegisterInterface<Timer>();
        RegisterInterface<WieldSlot>();
        RegisterInterface<Widget>(); // View will be loading different types of widgets, so we need them registered to retrieval.

        // Load system singletons.
        LoadAllAssemblyTypes<IGetKey>();

        // Validate the system scripts exist, before we load the user configurable ones.
        ValidateSystemScriptsEnum();

        // Preload
        LoadFromConfiguration<OrAttribute, OrAttributeGameConfiguration>(gameConfiguration.OrAttributes);
        LoadFromConfiguration<SumAttribute, SumAttributeGameConfiguration>(gameConfiguration.SumAttributes);
        LoadFromConfiguration<ColorEnumAttribute, ColorEnumAttributeGameConfiguration>(gameConfiguration.ColorEnumAttributes);
        LoadFromConfiguration<BoolAttribute, BoolAttributeGameConfiguration>(gameConfiguration.BoolAttributes);

        // Now load the user-configured singletons.  These singletons have been exported to the GamePack.
        LoadFromConfiguration<AbilityScoreScript, AbilityScoreScriptGameConfiguration>(gameConfiguration.AbilityScoreScripts);
        LoadFromConfiguration<Activation, ActivationGameConfiguration>(gameConfiguration.Activations);
        LoadFromConfiguration<Animation, AnimationGameConfiguration>(gameConfiguration.Animations);
        LoadFromConfiguration<ArtifactBiasWeightedRandom, ArtifactBiasWeightedRandomGameConfiguration>(gameConfiguration.ArtifactBiasWeightedRandoms);
        LoadFromConfiguration<Attack, AttackGameConfiguration>(gameConfiguration.Attacks);
        LoadFromConfiguration<AttributeFilter, AttributeFilterGameConfiguration>(gameConfiguration.AttributeFilters);
        LoadFromConfiguration<BoolWidget, BoolWidgetGameConfiguration>(gameConfiguration.BoolWidgets);
        LoadFromConfiguration<BoolPosFunction, BoolPosFunctionGameConfiguration>(gameConfiguration.BoolPosFunctions);
        LoadFromConfiguration<CharacterClassAbility, CharacterClassAbilityGameConfiguration>(gameConfiguration.CharacterClassAbilities);
        LoadFromConfiguration<CharacterClassSpell, CharacterClassSpellGameConfiguration>(gameConfiguration.ClassSpells);
        LoadFromConfiguration<ChestTrap, ChestTrapGameConfiguration>(gameConfiguration.ChestTraps);
        LoadFromConfiguration<ChestTrapCombination, ChestTrapCombinationGameConfiguration>(gameConfiguration.ChestTrapCombinations);
        LoadFromConfiguration<ConditionalWidget, ConditionalWidgetGameConfiguration>(gameConfiguration.ConditionalWidgets);
        LoadFromConfiguration<ConditionalScript, ConditionalScriptGameConfiguration>(gameConfiguration.ConditionalScripts);
        LoadFromConfiguration<DateWidget, DateWidgetGameConfiguration>(gameConfiguration.DateWidgets);
        LoadFromConfiguration<DungeonGuardian, DungeonGuardianGameConfiguration>(gameConfiguration.DungeonGuardians);
        LoadFromConfiguration<Dungeon, DungeonGameConfiguration>(gameConfiguration.Dungeons);
        LoadFromConfiguration<GameCommand, GameCommandGameConfiguration>(gameConfiguration.GameCommands);
        LoadFromConfiguration<GameMessageWidget, GameMessageWidgetGameConfiguration>(gameConfiguration.GameMessageWidgets);
        LoadFromConfiguration<Gender, GenderGameConfiguration>(gameConfiguration.Genders);
        LoadFromConfiguration<God, GodGameConfiguration>(gameConfiguration.Gods);
        LoadFromConfiguration<HelpGroup, HelpGroupGameConfiguration>(gameConfiguration.HelpGroups);
        LoadFromConfiguration<IntWidget, IntWidgetGameConfiguration>(gameConfiguration.IntWidgets);
        LoadFromConfiguration<ItemClass, ItemClassGameConfiguration>(gameConfiguration.ItemClasses);
        LoadFromConfiguration<ItemEnhancement, ItemEnhancementGameConfiguration>(gameConfiguration.ItemEnhancements);
        LoadFromConfiguration<ItemEnhancementWeightedRandom, ItemEnhancementWeightedRandomGameConfiguration>(gameConfiguration.ItemEnhancementWeightedRandoms);       
        LoadFromConfiguration<ItemIdentification, ItemIdentificationGameConfiguration>(gameConfiguration.ItemIdentifications);
        LoadFromConfiguration<ItemFactory, ItemFactoryGameConfiguration>(gameConfiguration.ItemFactories);
        LoadFromConfiguration<ItemFactoryWeightedRandom, ItemFactoryWeightedRandomGameConfiguration>(gameConfiguration.ItemFactoryWeightedRandoms);
        LoadFromConfiguration<ItemFilter, ItemFilterGameConfiguration>(gameConfiguration.ItemFilters);
        LoadFromConfiguration<ItemFlavor, ItemFlavorGameConfiguration>(gameConfiguration.ItemFlavors);
        LoadFromConfiguration<MappedSpellScript, MappedSpellScriptGameConfiguration>(gameConfiguration.MappedSpellScripts);
        LoadFromConfiguration<MappedItemEnhancement, MappedItemEnhancementGameConfiguration>(gameConfiguration.MappedItemEnhancements);
        LoadFromConfiguration<MapWidget, MapWidgetGameConfiguration>(gameConfiguration.MapWidgets);
        LoadFromConfiguration<MartialArtsAttack, MartialArtsAttackGameConfiguration>(gameConfiguration.MartialArtsAttacks);
        LoadFromConfiguration<MaxRangedWidget, MaxRangedWidgetGameConfiguration>(gameConfiguration.MaxRangedWidgets);
        LoadFromConfiguration<MonsterRace, MonsterRaceGameConfiguration>(gameConfiguration.MonsterRaces);
        LoadFromConfiguration<OutfitManifest, OutfitManifestGameConfiguration>(gameConfiguration.OutfitManifests);        
        LoadFromConfiguration<Patron, PatronGameConfiguration>(gameConfiguration.Patrons);
        LoadFromConfiguration<PhysicalAttributeSet, PhysicalAttributeSetGameConfiguration>(gameConfiguration.PhysicalAttributeSets);
        LoadFromConfiguration<Plural, PluralGameConfiguration>(gameConfiguration.Plurals);
        LoadFromConfiguration<ProjectileGraphic, ProjectileGraphicGameConfiguration>(gameConfiguration.ProjectileGraphics);
        LoadFromConfiguration<Projectile, ProjectileGameConfiguration>(gameConfiguration.Projectiles);
        LoadFromConfiguration<ProjectileScript, ProjectileScriptGameConfiguration>(gameConfiguration.ProjectileScripts);
        LoadFromConfiguration<ProjectileScriptWeightedRandom, ProjectileScriptWeightedRandomGameConfiguration>(gameConfiguration.ProjectileWeightedRandomScripts);
        LoadFromConfiguration<RaceAbility, RaceAbilityGameConfiguration>(gameConfiguration.RaceAbilities);
        LoadFromConfiguration<RaceGender, RaceGenderGameConfiguration>(gameConfiguration.RaceGenders);
        LoadFromConfiguration<RacialPower, RacialPowerGameConfiguration>(gameConfiguration.RacialPowers);
        LoadFromConfiguration<RacialPowerTest, RacialPowerTestGameConfiguration>(gameConfiguration.RacialPowerTests);
        LoadFromConfiguration<RangedWidget, RangedWidgetGameConfiguration>(gameConfiguration.RangedWidgets);
        LoadFromConfiguration<RangedWeaponBonus, RangedWeaponBonusGameConfiguration>(gameConfiguration.RangedWeaponBonuses);
        LoadFromConfiguration<Realm, RealmGameConfiguration>(gameConfiguration.Realms);
        LoadFromConfiguration<RechargeItemScript, RechargeItemScriptGameConfiguration>(gameConfiguration.RechargeItemScripts);
        LoadFromConfiguration<RealmCharacterClass, RealmCharacterClassGameConfiguration>(gameConfiguration.RealmCharacterClasses);
        LoadFromConfiguration<RenderMessageScript, RenderMessageScriptGameConfiguration>(gameConfiguration.RenderMessageScripts);
        LoadFromConfiguration<Shopkeeper, ShopkeeperGameConfiguration>(gameConfiguration.Shopkeepers);
        LoadFromConfiguration<Spell, SpellGameConfiguration>(gameConfiguration.Spells);
        LoadFromConfiguration<StoreCommand, StoreCommandGameConfiguration>(gameConfiguration.StoreCommands);
        LoadFromConfiguration<StoreFactory, StoreFactoryGameConfiguration>(gameConfiguration.StoreFactories);
        LoadFromConfiguration<StringWidget, StringWidgetGameConfiguration>(gameConfiguration.StringWidgets);
        LoadFromConfiguration<SummonScript, SummonScriptGameConfiguration>(gameConfiguration.SummonScripts);
        LoadFromConfiguration<SummonWeightedRandom, SummonWeightedRandomGameConfiguration>(gameConfiguration.SummonWeightedRandoms);
        LoadFromConfiguration<SyllableSet, SyllableSetGameConfiguration>(gameConfiguration.SyllableSets);
        LoadFromConfiguration<Symbol, SymbolGameConfiguration>(gameConfiguration.Symbols);
        LoadFromConfiguration<LabelWidget, LabelWidgetGameConfiguration>(gameConfiguration.LabelWidgets);
        LoadFromConfiguration<TeleportSelfScript, TeleportSelfScriptGameConfiguration>(gameConfiguration.TeleportSelfScripts);        
        LoadFromConfiguration<TextWidget, TextWidgetGameConfiguration>(gameConfiguration.NullableStringsTextAreaWidgets);
        LoadFromConfiguration<Tile, TileGameConfiguration>(gameConfiguration.Tiles);
        LoadFromConfiguration<TimerScript, TimerScriptGameConfiguration>(gameConfiguration.TimerScripts);
        LoadFromConfiguration<TimeWidget, TimeWidgetGameConfiguration>(gameConfiguration.TimeWidgets);
        LoadFromConfiguration<Town, TownGameConfiguration>(gameConfiguration.Towns);
        LoadFromConfiguration<Vault, VaultGameConfiguration>(gameConfiguration.Vaults);
        LoadFromConfiguration<View, ViewGameConfiguration>(gameConfiguration.Views);
        LoadFromConfiguration<WizardCommand, WizardCommandGameConfiguration>(gameConfiguration.WizardCommands);

        //ValidateJointTable<RaceAbility, Race, Ability>((Race t1, Ability t2) => RaceAbility.GetCompositeKey(t1, t2)); 
        //ValidateJointTable<CharacterClassAbility, BaseCharacterClass, Ability>((BaseCharacterClass t1, Ability t2) => CharacterClassAbility.GetCompositeKey(t1, t2));

        // Monsters must be sorted by the LevelFound property; otherwise, the game doesn't work properly.
        MonsterRace[] monsterRaces = Get<MonsterRace>();
        MonsterRace[] sortedMonsterRaces = monsterRaces.OrderBy(_monsterRace => _monsterRace.LevelFound).ToArray();
        _allGenericRepositoriesDictionary["MonsterRace"].List.Clear();
        _allGenericRepositoriesDictionary["MonsterRace"].List.AddRange(sortedMonsterRaces);

        // Bind all of the singletons now.
        foreach (IGetKey singleton in _allSingletonsList)
        {
            singleton.Bind();
        }
    }

    private void ValidateSystemScriptsEnum()
    {
        List<string> missing = new List<string>();
        foreach (string name in Enum.GetNames(typeof(SystemScriptsEnum)))
        {
            IGetKey? singleton = TryGet<IGetKey>(name);
            if (singleton is null)
            { 
                missing.Add(name);
            }
        }
        if (missing.Count > 0)
        {
            throw new Exception($"There is no cooresponding system script for the {String.Join("\t", missing)} enum.  A system script that implements the {nameof(IGetKey)} is required to be loaded.");
        }
    }
    private void ValidateJointTable<T, T1, T2>(Func<T1, T2, string> GetCompositeKey) where T : class where T1 : class where T2 : class // TODO: WHY CANT THIS BE where T: IGETKEY
    {
        foreach (T1 t1 in Get<T1>())
        {
            foreach (T2 t2 in Get<T2>())
            {
                string compositeKey = GetCompositeKey(t1, t2);
                T t = Get<T>(compositeKey);
            }
        }

    }
    #endregion

    #region Privates
    private readonly Game Game;
    private Dictionary<string, GenericRepository> _allGenericRepositoriesDictionary = new Dictionary<string, GenericRepository>();

    /// <summary>
    /// Returns a list of all singletons.  This is used to track all of the loaded singletons so that they can be bound quickly and only once.
    /// </summary>
    private List<IGetKey> _allSingletonsList = new List<IGetKey>();

    private void RegisterInterface<T>()
    {
        RegisterInterface<T>(false);
    }

    /// <summary>
    /// Registers a repository for all singletons that implement the interface specified by <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <exception cref="Exception"></exception>
    private void RegisterInterface<T>(bool enablePersistance = true)
    {
        string typeName = typeof(T).Name;
        if (_allGenericRepositoriesDictionary.TryGetValue(typeName, out GenericRepository? genericRepository))
        {
            throw new Exception($"{typeName} repository already registered.");
        }
        genericRepository = new GenericRepository(enablePersistance);
        _allGenericRepositoriesDictionary.Add(typeName, genericRepository);
    }

    /// <summary>
    /// Registers a singleton with all of the repositories by determining all of the interfaces and base classes that the singleton supports and registering the singleton
    /// with each associated repository.
    /// </summary>
    /// <param name="singleton"></param>
    /// <exception cref="Exception"></exception>
    private void RegisterSingleton(IGetKey singleton)
    {
        // Add the singleton to the list of singletons so that they can be bound.  Only add the singleton once.
        if (!_allSingletonsList.Contains(singleton))
        {
            _allSingletonsList.Add(singleton);
        }
        else
        {
            throw new Exception($"The singleton {singleton.GetType().Name} has already been registered.  This may be the result of a the json deserialization or a public ctor(Game game) still available for a singleton that no longer supports system loading.");
        }

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
            if (_allGenericRepositoriesDictionary.TryGetValue(typeName, out GenericRepository? genericRepository))
            {
                string? key = singleton.GetKey;
                if (key is null)
                {
                    throw new Exception($"The singleton {singleton.GetType().Name} has a null key value.  This may be the result of a the json deserialization or a public ctor(Game game) still available for a singleton that no longer supports system loading.");
                }

                // If the singleton hasn't been registered, register it now.  The singleton may belong to many repositories.
                if (genericRepository.Dictionary.TryGetValue(key, out object? existing))
                {
                    throw new Exception($"The singleton key {key} has already been registered in the {typeName} repository and is conflicting with {existing.GetType().Name}.");
                }
                genericRepository.Add(key, singleton);
            }
        }
    }

    private void LoadAllAssemblyTypes<T>() // TODO: WHY CANT THIS BE where T: IGETKEY
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

    private void LoadFromConfiguration<T, TConfiguration>(TConfiguration[]? entityConfigurations) where T : IGetKey where TConfiguration : notnull
    {
        // For persistance validation, we need to ensure the type T implements IToJson.
        if (!typeof(IToJson).IsAssignableFrom(typeof(T)))
        {
            throw new Exception($"The type {typeof(T).Name} does not implement {nameof(IToJson)} to support the persistance for {nameof(GameConfiguration)}.");
        }

        // Register the repository with persistance.
        RegisterInterface<T>();

        string typeName = typeof(T).Name;
        if (entityConfigurations != null)
        {
            ConstructorInfo? constructor = typeof(T).GetConstructors(BindingFlags.Public | BindingFlags.Instance)
                .SingleOrDefault(_constructor =>
                {
                    ParameterInfo[] parameters = _constructor.GetParameters();
                    return parameters.Length == 2 && parameters[0].ParameterType == typeof(Game) && parameters[1].ParameterType == typeof(TConfiguration);
                });
            if (constructor is null)
            {
                throw new Exception($"Cannot find constructor for {typeof(T).Name}.  Expecting ctor(Game, {typeof(TConfiguration).Name})");
            }
            foreach (TConfiguration entityConfiguration in entityConfigurations)
            {
                // We need to convert from the GameConfiguration object to the entity object.  Create the generic object
                T entity = (T)constructor.Invoke(new object[] { Game, entityConfiguration });
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
