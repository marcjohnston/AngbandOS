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
internal sealed class SingletonRepository : IGameSerialize
{
    #region Constructors
    public SingletonRepository(Game game)
    {
        Game = game;
    }
    #endregion

    #region Publics
    public DictionaryGameStateBag Serialize(SaveGameState saveGameState)
    {
        // The singleton repository is going to use a dictionary for all of the singletons.  The IGetKey will provide the unique key.
        var result = new Dictionary<string, GameStateBag>();

        foreach (IGetKey singleton in _allSingletonsList)
        {
            string key = singleton.GetKey;

            GameStateBag singletonGameStateBag = saveGameState.CreateObjectGameStateBag(singleton);
            result.Add(key, singletonGameStateBag);
        }

        return new DictionaryGameStateBag(result);
    }

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
    /// Retrieves an API Object by its <paramref name="key"/> from the registered repository (see <see cref="RegisterIndex"/> for more information) of type <typeparamref name="T"/> and returns null, if it isn't found.
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
    /// Retrieves an API Object by its <paramref name="key"/> from the registered repository (see <see cref="RegisterIndex"/> for more information) of type <typeparamref name="T"/> and throws an exception if it isn't found.
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

    public int GetIndex<T>(T singleton) where T : class
    {
        string typeName = typeof(T).Name;
        return _allGenericRepositoriesDictionary[typeName].GetIndex(singleton);
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
    /// Returns the number of API Objects in a registered repository (see <see cref="RegisterIndex"/> for more information).
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public int Count<T>()
    {
        string typeName = typeof(T).Name;
        return _allGenericRepositoriesDictionary[typeName].Count;
    }

    /// <summary>
    /// Returns an array of API Objects from the registered repository (see <see cref="RegisterIndex"/> for more information) of type <typeparamref name="T"/> by their unique key 
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
            Game.MsgPrint("The persistence interface does not support entity persistence.");
            return;
        }
        catch (Exception ex)
        {
            Game.MsgPrint($"The persistence interface failed to save the configuration '{ex.Message}'.");
            return;
        }
    }

    /// <summary>
    /// Performs the load phase of the singleton repository.  This phase reads all of the types from the assembly and adds it into its respective
    /// collection--if the ExcludeFromRepository property returns false.  If the ExcludeFromRepository is true, the singleton object will be discarded.
    /// </summary>
    /// <param name="gameConfiguration"></param>
    /// <param name="gameStateBag">Supply the <see cref="GameStateBag"/> that contains the field values for the singletons to rehydrate with.  The <see cref="GameStateBag"/> must be an instance of the <see cref="DictionaryGameStateBag"/>.</param>
    public void LoadAndBind(GameConfiguration gameConfiguration, RestoreGameState? restoreGameState)
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
        RegisterInterface<MonsterRace>(); 
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
        RegisterInterface<EquipmentWieldSlot>();
        RegisterInterface<Widget>(); // View will be loading different types of widgets, so we need them registered to retrieval.

        // Load system singletons.
        LoadAllAssemblyTypes<IGetKey>(restoreGameState);

        // Validate the system scripts exist, before we load the user configurable ones.
        ValidateSystemScriptsEnum();
        
        // Preload
        LoadFromConfiguration<OrAttribute, OrAttributeGameConfiguration>(gameConfiguration.OrAttributes, restoreGameState);
        LoadFromConfiguration<SumAttribute, SumAttributeGameConfiguration>(gameConfiguration.SumAttributes, restoreGameState);
        LoadFromConfiguration<BoolAttribute, BoolAttributeGameConfiguration>(gameConfiguration.BoolAttributes, restoreGameState);

        // Now load the user-configured singletons.  These singletons have been exported to the GamePack.
        LoadFromConfiguration<AbilityScoreScript, AbilityScoreScriptGameConfiguration>(gameConfiguration.AbilityScoreScripts, restoreGameState);
        LoadFromConfiguration<Activation, ActivationGameConfiguration>(gameConfiguration.Activations, restoreGameState);
        LoadFromConfiguration<Animation, AnimationGameConfiguration>(gameConfiguration.Animations, restoreGameState);
        LoadFromConfiguration<ArtifactBiasWeightedRandom, ArtifactBiasWeightedRandomGameConfiguration>(gameConfiguration.ArtifactBiasWeightedRandoms, restoreGameState);
        LoadFromConfiguration<Attack, AttackGameConfiguration>(gameConfiguration.Attacks, restoreGameState);
        LoadFromConfiguration<AttributeFilter, AttributeFilterGameConfiguration>(gameConfiguration.AttributeFilters, restoreGameState);
        LoadFromConfiguration<Conditional, ConditionalGameConfiguration>(gameConfiguration.ProductOfSumsBoolFunctions, restoreGameState);
        LoadFromConfiguration<CharacterClassAbility, CharacterClassAbilityGameConfiguration>(gameConfiguration.CharacterClassAbilities, restoreGameState); // Composite singleton // Composite singleton
        LoadFromConfiguration<CharacterClassSpell, CharacterClassSpellGameConfiguration>(gameConfiguration.ClassSpells, restoreGameState);
        LoadFromConfiguration<ChestTrap, ChestTrapGameConfiguration>(gameConfiguration.ChestTraps, restoreGameState);
        LoadFromConfiguration<ChestTrapCombination, ChestTrapCombinationGameConfiguration>(gameConfiguration.ChestTrapCombinations, restoreGameState);
        LoadFromConfiguration<ConditionalWidget, ConditionalWidgetGameConfiguration>(gameConfiguration.ConditionalWidgets, restoreGameState);
        LoadFromConfiguration<ConditionalScript, ConditionalScriptGameConfiguration>(gameConfiguration.ConditionalScripts, restoreGameState);
        LoadFromConfiguration<DateWidget, DateWidgetGameConfiguration>(gameConfiguration.DateWidgets, restoreGameState);
        LoadFromConfiguration<DungeonGuardian, DungeonGuardianGameConfiguration>(gameConfiguration.DungeonGuardians, restoreGameState);
        LoadFromConfiguration<Dungeon, DungeonGameConfiguration>(gameConfiguration.Dungeons, restoreGameState);
        LoadFromConfiguration<GameCommand, GameCommandGameConfiguration>(gameConfiguration.GameCommands, restoreGameState);
        LoadFromConfiguration<GameMessageWidget, GameMessageWidgetGameConfiguration>(gameConfiguration.GameMessageWidgets, restoreGameState);
        LoadFromConfiguration<Gender, GenderGameConfiguration>(gameConfiguration.Genders, restoreGameState);
        LoadFromConfiguration<God, GodGameConfiguration>(gameConfiguration.Gods, restoreGameState);
        LoadFromConfiguration<HelpGroup, HelpGroupGameConfiguration>(gameConfiguration.HelpGroups, restoreGameState);
        LoadFromConfiguration<IntWidget, IntWidgetGameConfiguration>(gameConfiguration.IntWidgets, restoreGameState);
        LoadFromConfiguration<ItemClass, ItemClassGameConfiguration>(gameConfiguration.ItemClasses, restoreGameState);
        LoadFromConfiguration<ItemEnhancement, ItemEnhancementGameConfiguration>(gameConfiguration.ItemEnhancements, restoreGameState);
        LoadFromConfiguration<ItemEnhancementWeightedRandom, ItemEnhancementWeightedRandomGameConfiguration>(gameConfiguration.ItemEnhancementWeightedRandoms, restoreGameState);       
        LoadFromConfiguration<ItemIdentification, ItemIdentificationGameConfiguration>(gameConfiguration.ItemIdentifications, restoreGameState);
        LoadFromConfiguration<ItemFactory, ItemFactoryGameConfiguration>(gameConfiguration.ItemFactories, restoreGameState);
        LoadFromConfiguration<ItemFactoryWeightedRandom, ItemFactoryWeightedRandomGameConfiguration>(gameConfiguration.ItemFactoryWeightedRandoms, restoreGameState);
        LoadFromConfiguration<ItemFilter, ItemFilterGameConfiguration>(gameConfiguration.ItemFilters, restoreGameState);
        LoadFromConfiguration<ItemFlavor, ItemFlavorGameConfiguration>(gameConfiguration.ItemFlavors, restoreGameState);
        LoadFromConfiguration<MappedSpellScript, MappedSpellScriptGameConfiguration>(gameConfiguration.MappedSpellScripts, restoreGameState);
        LoadFromConfiguration<MappedItemEnhancement, MappedItemEnhancementGameConfiguration>(gameConfiguration.MappedItemEnhancements, restoreGameState);
        LoadFromConfiguration<MapWidget, MapWidgetGameConfiguration>(gameConfiguration.MapWidgets, restoreGameState);
        LoadFromConfiguration<MartialArtsAttack, MartialArtsAttackGameConfiguration>(gameConfiguration.MartialArtsAttacks, restoreGameState);
        LoadFromConfiguration<MaxRangedWidget, MaxRangedWidgetGameConfiguration>(gameConfiguration.MaxRangedWidgets, restoreGameState);
        LoadFromConfiguration<MonsterRace, MonsterRaceGameConfiguration>(gameConfiguration.MonsterRaces, restoreGameState);
        LoadFromConfiguration<OutfitManifest, OutfitManifestGameConfiguration>(gameConfiguration.OutfitManifests, restoreGameState); // Composite singleton    
        LoadFromConfiguration<Patron, PatronGameConfiguration>(gameConfiguration.Patrons, restoreGameState);
        LoadFromConfiguration<PhysicalAttributeSet, PhysicalAttributeSetGameConfiguration>(gameConfiguration.PhysicalAttributeSets, restoreGameState);
        LoadFromConfiguration<Plural, PluralGameConfiguration>(gameConfiguration.Plurals, restoreGameState);
        LoadFromConfiguration<ProjectileGraphic, ProjectileGraphicGameConfiguration>(gameConfiguration.ProjectileGraphics, restoreGameState);
        LoadFromConfiguration<Projectile, ProjectileGameConfiguration>(gameConfiguration.Projectiles, restoreGameState);
        LoadFromConfiguration<ProjectileScript, ProjectileScriptGameConfiguration>(gameConfiguration.ProjectileScripts, restoreGameState);
        LoadFromConfiguration<ProjectileScriptWeightedRandom, ProjectileScriptWeightedRandomGameConfiguration>(gameConfiguration.ProjectileWeightedRandomScripts, restoreGameState);
        LoadFromConfiguration<RaceAbility, RaceAbilityGameConfiguration>(gameConfiguration.RaceAbilities, restoreGameState); // Composite singleton
        LoadFromConfiguration<RaceGender, RaceGenderGameConfiguration>(gameConfiguration.RaceGenders, restoreGameState); // Composite singleton
        LoadFromConfiguration<RacePower, RacePowerGameConfiguration>(gameConfiguration.RacialPowers, restoreGameState); // Composite singleton
        LoadFromConfiguration<RacialPowerTest, RacialPowerTestGameConfiguration>(gameConfiguration.RacialPowerTests, restoreGameState);
        LoadFromConfiguration<RangedWidget, RangedWidgetGameConfiguration>(gameConfiguration.RangedWidgets, restoreGameState);
        LoadFromConfiguration<RangedWeaponBonus, RangedWeaponBonusGameConfiguration>(gameConfiguration.RangedWeaponBonuses, restoreGameState);
        LoadFromConfiguration<Realm, RealmGameConfiguration>(gameConfiguration.Realms, restoreGameState);
        LoadFromConfiguration<RealmCharacterClass, RealmCharacterClassGameConfiguration>(gameConfiguration.RealmCharacterClasses, restoreGameState); // Composite singleton
        LoadFromConfiguration<RechargeItemScript, RechargeItemScriptGameConfiguration>(gameConfiguration.RechargeItemScripts, restoreGameState);
        LoadFromConfiguration<RenderMessageScript, RenderMessageScriptGameConfiguration>(gameConfiguration.RenderMessageScripts, restoreGameState);
        LoadFromConfiguration<Shopkeeper, ShopkeeperGameConfiguration>(gameConfiguration.Shopkeepers, restoreGameState);
        LoadFromConfiguration<Spell, SpellGameConfiguration>(gameConfiguration.Spells, restoreGameState);
        LoadFromConfiguration<StoreCommand, StoreCommandGameConfiguration>(gameConfiguration.StoreCommands, restoreGameState);
        LoadFromConfiguration<StoreFactory, StoreFactoryGameConfiguration>(gameConfiguration.StoreFactories, restoreGameState);
        LoadFromConfiguration<StringWidget, StringWidgetGameConfiguration>(gameConfiguration.StringWidgets, restoreGameState);
        LoadFromConfiguration<SummonScript, SummonScriptGameConfiguration>(gameConfiguration.SummonScripts, restoreGameState);
        LoadFromConfiguration<SummonWeightedRandom, SummonWeightedRandomGameConfiguration>(gameConfiguration.SummonWeightedRandoms, restoreGameState);
        LoadFromConfiguration<SyllableSet, SyllableSetGameConfiguration>(gameConfiguration.SyllableSets, restoreGameState);
        LoadFromConfiguration<Symbol, SymbolGameConfiguration>(gameConfiguration.Symbols, restoreGameState);
        LoadFromConfiguration<LabelWidget, LabelWidgetGameConfiguration>(gameConfiguration.LabelWidgets, restoreGameState);
        LoadFromConfiguration<TeleportSelfScript, TeleportSelfScriptGameConfiguration>(gameConfiguration.TeleportSelfScripts, restoreGameState);        
        LoadFromConfiguration<TextWidget, TextWidgetGameConfiguration>(gameConfiguration.NullableStringsTextAreaWidgets, restoreGameState);
        LoadFromConfiguration<Tile, TileGameConfiguration>(gameConfiguration.Tiles, restoreGameState);
        LoadFromConfiguration<TimerScript, TimerScriptGameConfiguration>(gameConfiguration.TimerScripts, restoreGameState);
        LoadFromConfiguration<TimeWidget, TimeWidgetGameConfiguration>(gameConfiguration.TimeWidgets, restoreGameState);
        LoadFromConfiguration<Town, TownGameConfiguration>(gameConfiguration.Towns, restoreGameState);
        LoadFromConfiguration<Vault, VaultGameConfiguration>(gameConfiguration.Vaults, restoreGameState);
        LoadFromConfiguration<View, ViewGameConfiguration>(gameConfiguration.Views, restoreGameState);
        LoadFromConfiguration<WizardCommand, WizardCommandGameConfiguration>(gameConfiguration.WizardCommands, restoreGameState);

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
            RestoreGameState? singletonRestoreGameState = restoreGameState?.Get(singleton.GetKey);

            // Allow the singleton to bind now.  Provide the restore game state, if we are restoring.
            singleton.Bind(singletonRestoreGameState);

            // If we are restoring, perform a verification process.
            if (singletonRestoreGameState is not null)
            {
                VerifyRestore(singletonRestoreGameState, singleton);
            }
        }

        //foreach (FixedArtifact fixedArtifact in Get<FixedArtifact>())
        //{
        //    MappedItemEnhancement[] allMappedItemEnhancements = Game.SingletonRepository.Get<MappedItemEnhancement>(); // TODO: This is slow
        //    MappedItemEnhancement[]? mappedItemEnhancements = allMappedItemEnhancements.Where(_mappedItemEnhancement => (_mappedItemEnhancement.FixedArtifactBindingKeys is not null && _mappedItemEnhancement.FixedArtifactBindingKeys.Contains(fixedArtifact.Key))).ToArray();
        //    if (mappedItemEnhancements is not null)
        //    {
        //        bool done = false;
        //        foreach (MappedItemEnhancement mappedItemEnhancement in mappedItemEnhancements)
        //        {
        //            if (mappedItemEnhancement.ItemEnhancements is not null)
        //            {
        //                foreach (IItemEnhancement iitemEnhancement in mappedItemEnhancement.ItemEnhancements)
        //                {
        //                    ItemEnhancement itemEnhancement = iitemEnhancement.GetItemEnhancement();
        //                    if (iitemEnhancement.GetItemEnhancement().Color is not null)
        //                    {
        //                        string? prop1 = Game.CutProperty(@"D:\Programming\AngbandOS\AngbandOS.GamePacks.Cthangband\ItemEnhancements\", itemEnhancement.GetKey, "public override ColorEnum");
        //                        if (prop1 is null && itemEnhancement.Color is not null)
        //                            throw new Exception();
        //                        if (prop1 is not null)
        //                            Game.PasteProperty(@$"D:\Programming\AngbandOS\AngbandOS.Core\FixedArtifacts", fixedArtifact.Key, $"    public override ColorEnum Color => ColorEnum.{Enum.GetName<ColorEnum>(itemEnhancement.Color.Value)};");
        //                        done = true;
        //                        break;
        //                    }
        //                }
        //            }
        //            if (done)
        //                break;

        //        }
        //    }
        //}
    }

    private void VerifyRestore(RestoreGameState restoreGameState, object? singleton)
    {
        string singletonTypeName = singleton?.GetType().Name ?? "null";

        // Perform a verification of the restore process.
        restoreGameState.Verify(singleton);
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
            throw new Exception($"There is no corresponding system script for the {String.Join("\t", missing)} enum.  A system script that implements the {nameof(IGetKey)} is required to be loaded.");
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
    private Game Game { get; }
    private Dictionary<string, GenericRepository> _allGenericRepositoriesDictionary { get; } = new Dictionary<string, GenericRepository>();
    private List<GenericRepository> _indexedRepositories { get; } = new List<GenericRepository>();


    /// <summary>
    /// Returns a list of all singletons.  This is used to track all of the loaded singletons so that they can be bound quickly and only once.
    /// </summary>
    private List<IGetKey> _allSingletonsList = new List<IGetKey>();

    /// <summary>
    /// Registers an additional index for singleton entities by an interface.  Persistence for the index is not enabled.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    private void RegisterInterface<T>()
    {
        RegisterIndex<T>(false);
    }

    private bool IsDirectlyAssignableFrom<TInterface>(Type type)
    {
        return type.GetInterfaces()
            .Except(type.BaseType?.GetInterfaces() ?? Type.EmptyTypes)
            .Contains(typeof(TInterface));
    }

    /// <summary>
    /// Registers a repository to build an index for a specific type of singletons specified by the <typeparamref name="T"/> type parameter.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <exception cref="Exception"></exception>
    private void RegisterIndex<T>(bool enablePersistance = true)
    {
        string typeName = typeof(T).Name;
        if (!_allGenericRepositoriesDictionary.TryGetValue(typeName, out GenericRepository? genericRepository))
        {
            genericRepository = new GenericRepository(enablePersistance);

            // Check to see if the singletons implements the IIndexedSingletons interface.  If it does, we need to add the repository to the list of indexed repositories so that the singletons can be indexed after they are loaded.
            if (IsDirectlyAssignableFrom<IIndexedSingletons>(typeof(T)))
            {
                _indexedRepositories.Add(genericRepository);
            }
            _allGenericRepositoriesDictionary.Add(typeName, genericRepository);
        }
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

                // Now that the singleton is added, we need to check to see if the singleton needs to be indexed.
                if (IsDirectlyAssignableFrom<IIndexedSingletons>(interfaceType))
                {
                    IIndexedSingletons indexedSingleton = (IIndexedSingletons)singleton;
                    if (indexedSingleton.Index != -1)
                    {
                        throw new Exception($"{nameof(RegisterSingleton)} has detected an index overwrite condition.");
                    }
                    indexedSingleton.Index = genericRepository.GetIndex(singleton);
                }
            }
        }
    }

    private void RegisterSingletonWithRestoreGameState(IGetKey singleton, RestoreGameState restoreGameState)
    {
        // Retrieve the restore state for this singleton.
        RestoreGameState? singletonRestoreGameState = restoreGameState.Get(singleton.GetKey);
        if (singletonRestoreGameState is null)
        {
            throw new Exception($"There is a mismatch between the save game and the game configuration.  The {singleton.GetType().Name} bag was not found in the save game.");
        }
        singletonRestoreGameState.RegisterSingleton(singleton);
    }

    private void LoadAllAssemblyTypes<T>(RestoreGameState? restoreGameState) // TODO: WHY CANT THIS BE where T: IGETKEY
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
                        if (restoreGameState is not null)
                        {
                            RegisterSingletonWithRestoreGameState(singleton, restoreGameState);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"An error occurred instantiating the {type.Name} singleton '{ex.Message}'.  Check to ensure the constructor is private(Game game).");
                    }
                }
            }
        }
    }

    private void LoadFromConfiguration<T, TConfiguration>(TConfiguration[]? entityConfigurations, RestoreGameState? restoreGameState) where T : IGetKey where TConfiguration : notnull
    {
        // For persistence validation, we need to ensure the type T implements IToJson.
        if (!typeof(IToJson).IsAssignableFrom(typeof(T)))
        {
            throw new Exception($"The type {typeof(T).Name} does not implement {nameof(IToJson)} to support the persistance for {nameof(GameConfiguration)}.");
        }

        // Register the repository with persistence.
        RegisterInterface<T>();

        string typeName = typeof(T).Name;
        if (entityConfigurations is not null)
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
                T singleton = (T)constructor.Invoke(new object[] { Game, entityConfiguration });
                RegisterSingleton(singleton);

                if (restoreGameState is not null)
                {
                    RegisterSingletonWithRestoreGameState(singleton, restoreGameState);
                }
            }
        }
    }
    #endregion
}
