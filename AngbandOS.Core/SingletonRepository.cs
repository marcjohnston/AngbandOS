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
    /// Returns a non-ambigious mapping for a 3-keyed mapping repository.  A 3-key lookup is performed first; if found, it is returned; as it is non-ambigious.  When
    /// the 3-key lookup fails to match a singleton in the repository, all three 2-key lookups are performed.  If only singleton is found for all three 2-key lookups; it is
    /// returned as non-ambigious.  If more than one 2-key lookup singletons are matched, an ambigious exception is thrown.  If no 2-key singletons are found, a lookup
    /// for all three 1-key singletons is performed.  If more than one is found, an ambigious error is thrown.  If a single 1-key singleton is found, it is returned; otherwise
    /// no 1-key singletons were found and null is returned.
    /// </summary>
    /// <typeparam name="T">Represents the mapping type of singletons stored in the repository.  E.g. MappedSpellScript</typeparam>
    /// <typeparam name="T1">Represents the type for the first key.</typeparam>
    /// <typeparam name="T2">Represents the type for the second key.</typeparam>
    /// <typeparam name="T3">Represents the type for the third key.</typeparam>
    /// <param name="getCompositeKey"></param>
    /// <param name="t1"></param>
    /// <param name="t2"></param>
    /// <param name="t3"></param>
    /// <returns></returns>
    public T? GetMapping<T, T1, T2, T3>(Func<T1?, T2?, T3?, string> getCompositeKey, T1? t1, T2? t2, T3? t3) where T : class
    {
        // Check all 3 keys.
        string t1T2T3CompositeKey = getCompositeKey(t1, t2, t3);
        T? t1T2T3mapping = Game.SingletonRepository.TryGet<T>(t1T2T3CompositeKey);
        if (t1T2T3mapping is not null)
        {
            return t1T2T3mapping;
        }

        // Check 2 keys.
        string t1T2CompositeKey = getCompositeKey(t1, t2, default);
        T? t1T2Mapping = Game.SingletonRepository.TryGet<T>(t1T2CompositeKey);

        string t1T3CompositeKey = getCompositeKey(t1, default, t3);
        T? t1T3Mapping = Game.SingletonRepository.TryGet<T>(t1T3CompositeKey);

        string t2T3CompositeKey = getCompositeKey(default, t2, t3);
        T? t2T3Mapping = Game.SingletonRepository.TryGet<T>(t2T3CompositeKey);

        if (t1T2Mapping is not null)
        {
            if (t1T3Mapping is not null)
            {
                throw new Exception($"Ambigious mapped spell script for {t1T2CompositeKey} and {t1T2CompositeKey}.");
            }
            else if (t2T3Mapping is not null)
            {
                throw new Exception($"Ambigious mapped spell script for {t1T2CompositeKey} and {t2T3CompositeKey}.");
            }
            return t1T2Mapping;
        }
        else if (t1T3Mapping is not null)
        {
            if (t2T3Mapping is not null)
            {
                throw new Exception($"Ambigious mapped spell script for {t1T2CompositeKey} and {t2T3CompositeKey}.");
            }
            return t1T3Mapping;
        }
        else if (t2T3Mapping is not null)
        {
            return t2T3Mapping;
        }

        // Check 1 key.
        string t1CompositeKey = getCompositeKey(t1, default, default);
        T? t1Mapping = Game.SingletonRepository.TryGet<T>(t1CompositeKey);

        string bySpellKey = getCompositeKey(default, t2, default);
        T? t2Mapping = Game.SingletonRepository.TryGet<T>(bySpellKey);

        string byCharacterClassKey = getCompositeKey(default, default, t3);
        T? t3Mapping = Game.SingletonRepository.TryGet<T>(byCharacterClassKey);

        if (t1Mapping is not null)
        {
            if (t2Mapping is not null)
            {
                throw new Exception($"Ambigious mapped spell script for {t1CompositeKey} and {bySpellKey}.");
            }
            else if (t3Mapping is not null)
            {
                throw new Exception($"Ambigious mapped spell script for {t1CompositeKey} and {byCharacterClassKey}.");
            }
            return t1Mapping;
        }
        else if (t2Mapping is not null)
        {
            if (t3Mapping is not null)
            {
                throw new Exception($"Ambigious mapped spell script for {bySpellKey} and {byCharacterClassKey}.");
            }
            return t2Mapping;
        }
        else if (t3Mapping is not null)
        {
            return t3Mapping;
        }

        return null;
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
            throw new Exception($"The {typeof(T).Name} repository was registered but the singleton {key} does not exist.\n\n1. Ensure the {nameof(IGetKey)} interface was implemented on the {typeof(T).Name} class.\n\n2. There is only one private constructor and that it only accepts the Game parameter.\n\n3. The singletons are either loaded fromt the Assembly or the configuration.\n\n");
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
    /// Retrieves an API Object by its <paramref name="key"/> from the registered repository (see <see cref="RegisterRepository"/> for more information) of type <typeparamref name="T"/> and returns null, if it isn't found.
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
    /// Retrieves an API Object by its <paramref name="key"/> from the registered repository (see <see cref="RegisterRepository"/> for more information) of type <typeparamref name="T"/> and throws an exception if it isn't found.
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
    public T[] Get<T>() where T : class // TODO: WHY CANT THIS BE where T: IGETKEY
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

        RegisterRepository<Ability>();
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
        RegisterRepository<CharacterClassAbility>();
        RegisterRepository<BirthStage>();
        RegisterRepository<BoolWidget>();
        RegisterRepository<ChestTrap>();
        RegisterRepository<ChestTrapConfiguration>();
        RegisterRepository<CharacterClassSpell>();
        RegisterRepository<DateWidget>();
        RegisterRepository<Dungeon>();
        RegisterRepository<DungeonGuardian>();
        RegisterRepository<FireResistanceTimer>();
        RegisterRepository<FixedArtifact>();
        RegisterRepository<FlaggedAction>();
        RegisterRepository<FloorEffect>();
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
        RegisterRepository<ItemFactoryWeightedRandom>();
        RegisterRepository<ItemFilter>();
        RegisterRepository<ItemFlavor>();
        RegisterRepository<ItemMatch>();
        RegisterRepository<ItemQualityRating>();
        RegisterRepository<ItemTest>();
        RegisterRepository<Justification>();
        RegisterRepository<MappedSpellScript>();
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
        RegisterRepository<RaceAbility>();
        RegisterRepository<RacialPower>();
        RegisterRepository<RacialPowerTest>();
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
        RegisterRepository<TimerScript>();
        RegisterRepository<Town>();
        RegisterRepository<Vault>();
        RegisterRepository<View>();
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
        LoadFromConfiguration<ArtifactBiasWeightedRandom, ArtifactBiasWeightedRandomGameConfiguration, ArtifactBiasWeightedRandom>(gameConfiguration.ArtifactBiasWeightedRandoms);
        LoadFromConfiguration<Attack, AttackGameConfiguration, Attack>(gameConfiguration.Attacks);
        LoadFromConfiguration<BoolWidget, BoolWidgetGameConfiguration, BoolWidget>(gameConfiguration.BoolWidgets);
        LoadFromConfiguration<CharacterClassSpell, CharacterClassSpellGameConfiguration, CharacterClassSpell>(gameConfiguration.ClassSpells);
        LoadFromConfiguration<ConditionalWidget, ConditionalWidgetGameConfiguration, ConditionalWidget>(gameConfiguration.ConditionalWidgets);
        LoadFromConfiguration<DateWidget, DateWidgetGameConfiguration, DateWidget>(gameConfiguration.DateWidgets);
        LoadFromConfiguration<DungeonGuardian, DungeonGuardianGameConfiguration, DungeonGuardian>(gameConfiguration.DungeonGuardians);
        LoadFromConfiguration<Dungeon, DungeonGameConfiguration, Dungeon>(gameConfiguration.Dungeons);
        LoadFromConfiguration<GameCommand, GameCommandGameConfiguration, GameCommand>(gameConfiguration.GameCommands);
        LoadFromConfiguration<Gender, GenderGameConfiguration, Gender>(gameConfiguration.Genders);
        LoadFromConfiguration<God, GodGameConfiguration, God>(gameConfiguration.Gods);
        LoadFromConfiguration<HelpGroup, HelpGroupGameConfiguration, HelpGroup>(gameConfiguration.HelpGroups);
        LoadFromConfiguration<IntWidget, IntWidgetGameConfiguration, GenericIntWidget>(gameConfiguration.IntWidgets);
        LoadFromConfiguration<ItemClass, ItemClassGameConfiguration, ItemClass>(gameConfiguration.ItemClasses);
        LoadFromConfiguration<ItemEnhancement, ItemEnhancementGameConfiguration, ItemEnhancement>(gameConfiguration.ItemEnhancements);
        LoadFromConfiguration<ItemEnhancementWeightedRandom, ItemEnhancementWeightedRandomGameConfiguration, ItemEnhancementWeightedRandom>(gameConfiguration.ItemEnhancementWeightedRandoms);
        LoadFromConfiguration<ItemFactoryWeightedRandom, ItemFactoryWeightedRandomGameConfiguration, ItemFactoryWeightedRandom>(gameConfiguration.ItemFactoryWeightedRandoms);
        LoadFromConfiguration<ItemFactory, ItemFactoryGameConfiguration, GenericItemFactory>(gameConfiguration.ItemFactories);
        LoadFromConfiguration<ItemFlavor, ItemFlavorGameConfiguration, GenericItemFlavor>(gameConfiguration.ItemFlavors);
        LoadFromConfiguration<MapWidget, MapWidgetGameConfiguration, MapWidget>(gameConfiguration.MapWidgets);
        LoadFromConfiguration<MappedSpellScript, MappedSpellScriptGameConfiguration, MappedSpellScript>(gameConfiguration.MappedSpellScripts);
        LoadFromConfiguration<MaxRangedWidget, MaxRangedWidgetGameConfiguration, GenericMaxRangedWidget>(gameConfiguration.MaxRangedWidgets);
        LoadFromConfiguration<MonsterRace, MonsterRaceGameConfiguration, GenericMonsterRace>(gameConfiguration.MonsterRaces);
        LoadFromConfiguration<NullableStringsTextAreaWidget, NullableStringsTextAreaWidgetGameConfiguration, GenericNullableStringsTextAreaWidget>(gameConfiguration.NullableStringsTextAreaWidgets);
        LoadFromConfiguration<PhysicalAttributeSet, PhysicalAttributeSetGameConfiguration, PhysicalAttributeSet>(gameConfiguration.PhysicalAttributeSets);
        LoadFromConfiguration<Plural, PluralGameConfiguration, GenericPlural>(gameConfiguration.Plurals);
        LoadFromConfiguration<ProjectileGraphic, ProjectileGraphicGameConfiguration, GenericProjectileGraphic>(gameConfiguration.ProjectileGraphics);
        LoadFromConfiguration<Projectile, ProjectileGameConfiguration, GenericProjectile>(gameConfiguration.Projectiles);
        LoadFromConfiguration<ProjectileScript, ProjectileScriptGameConfiguration, GenericProjectileScript>(gameConfiguration.ProjectileScripts);
        LoadFromConfiguration<ProjectileWeightedRandom, ProjectileWeightedRandomGameConfiguration, ProjectileWeightedRandom>(gameConfiguration.ProjectileWeightedRandomScripts);
        LoadFromConfiguration<RaceGender, RaceGenderGameConfiguration, RaceGender>(gameConfiguration.RaceGenders);
        LoadFromConfiguration<RangedWidget, RangedWidgetGameConfiguration, GenericRangedWidget>(gameConfiguration.RangedWidgets);
        LoadFromConfiguration<Realm, RealmGameConfiguration, Realm>(gameConfiguration.Realms);
        LoadFromConfiguration<RealmCharacterClass, RealmCharacterClassGameConfiguration, RealmCharacterClass>(gameConfiguration.RealmCharacterClasses);
        LoadFromConfiguration<Shopkeeper, ShopkeeperGameConfiguration, GenericShopkeeper>(gameConfiguration.Shopkeepers);
        LoadFromConfiguration<Spell, SpellGameConfiguration, Spell>(gameConfiguration.Spells);
        LoadFromConfiguration<StoreCommand, StoreCommandGameConfiguration, GenericStoreCommand>(gameConfiguration.StoreCommands);
        LoadFromConfiguration<StoreFactory, StoreFactoryGameConfiguration, StoreFactory>(gameConfiguration.StoreFactories);
        LoadFromConfiguration<StringWidget, StringWidgetGameConfiguration, GenericStringWidget>(gameConfiguration.StringWidgets);
        LoadFromConfiguration<SummonScript, SummonScriptGameConfiguration, SummonScript>(gameConfiguration.SummonScripts);
        LoadFromConfiguration<SummonWeightedRandom, SummonWeightedRandomGameConfiguration, SummonWeightedRandom>(gameConfiguration.SummonWeightedRandoms);
        LoadFromConfiguration<SyllableSet, SyllableSetGameConfiguration, SyllableSet>(gameConfiguration.SyllableSets);
        LoadFromConfiguration<Symbol, SymbolGameConfiguration, Symbol>(gameConfiguration.Symbols);
        LoadFromConfiguration<TextWidget, TextWidgetGameConfiguration, TextWidget>(gameConfiguration.TextWidgets);
        LoadFromConfiguration<Tile, TileGameConfiguration, Tile>(gameConfiguration.Tiles);
        LoadFromConfiguration<TimerScript, TimerScriptGameConfiguration, TimerScript>(gameConfiguration.TimerScripts);
        LoadFromConfiguration<TimeWidget, TimeWidgetGameConfiguration, GenericTimeWidget>(gameConfiguration.TimeWidgets);
        LoadFromConfiguration<Town, TownGameConfiguration, Town>(gameConfiguration.Towns);
        LoadFromConfiguration<Vault, VaultGameConfiguration, Vault>(gameConfiguration.Vaults);
        LoadFromConfiguration<View, ViewGameConfiguration, View>(gameConfiguration.Views);
        LoadFromConfiguration<WizardCommand, WizardCommandGameConfiguration, WizardCommand>(gameConfiguration.WizardCommands);

        // Load the remaining user-configured singletons from the assembly.  These singletons have not been exported to the GamePack yet.
        LoadAllAssemblyTypes<Activation>();
        LoadAllAssemblyTypes<Ability>();
        LoadAllAssemblyTypes<ActivationWeightedRandom>();
        LoadAllAssemblyTypes<AlterAction>();
        LoadAllAssemblyTypes<ArtifactBias>();
        LoadAllAssemblyTypes<AttackEffect>();
        LoadAllAssemblyTypes<BirthStage>();
        LoadAllAssemblyTypes<BaseCharacterClass>();
        LoadAllAssemblyTypes<CharacterClassAbility>();
        LoadAllAssemblyTypes<ChestTrapConfiguration>();
        LoadAllAssemblyTypes<ChestTrap>();
        LoadAllAssemblyTypes<ConditionalScript>();
        LoadAllAssemblyTypes<DungeonGenerator>();
        LoadAllAssemblyTypes<FixedArtifact>();
        LoadAllAssemblyTypes<FloorEffect>();
        LoadAllAssemblyTypes<ItemAction>();
        LoadAllAssemblyTypes<ItemEffect>();
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
        LoadAllAssemblyTypes<RaceAbility>();
        LoadAllAssemblyTypes<RacialPower>();
        LoadAllAssemblyTypes<RacialPowerTest>();
        LoadAllAssemblyTypes<RenderMessageScript>();
        LoadAllAssemblyTypes<Reward>();
        LoadAllAssemblyTypes<RoomLayout>();
        LoadAllAssemblyTypes<Script>();
        LoadAllAssemblyTypes<SpellResistantDetection>();
        LoadAllAssemblyTypes<Talent>();
        LoadAllAssemblyTypes<WieldSlot>();

        //ValidateJointTable<RaceAbility, Race, Ability>((Race t1, Ability t2) => RaceAbility.GetCompositeKey(t1, t2)); 
        //ValidateJointTable<CharacterClassAbility, BaseCharacterClass, Ability>((BaseCharacterClass t1, Ability t2) => CharacterClassAbility.GetCompositeKey(t1, t2));

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
