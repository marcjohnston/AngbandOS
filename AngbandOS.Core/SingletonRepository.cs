// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using System.Collections.Generic;
using System.Diagnostics;
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

    public ActivationsRepository Activations;
    public AlignmentsRepository Alignments;
    public AlterActionsRepository AlterActions;
    public AmuletReadableFlavorsRepository AmuletReadableFlavors;
    public AnimationsRepository Animations;
    public ArtifactBiasesRepository ArtifactBiases;
    public AttackEffectsRepository AttackEffects;
    public AttacksRepository Attacks;
    public BirthStagesRepository BirthStages;
    public CharacterClassesRepository CharacterClasses;
    public ChestTrapConfigurationsRepository ChestTrapConfigurations;
    public ChestTrapsRepository ChestTraps;
    public ClassSpellsRepository ClassSpells;
    public DungeonGuardiansRepository DungeonGuardians;
    public DungeonsRepository Dungeons;
    public ElvishTextRepository ElvishText;
    public FindQuestsRepository FindQuests;
    public FixedArtifactsRepository FixedArtifacts;
    public FlaggedActionsRepository FlaggedActions;
    public FormsRepository Forms;
    public FunctionsRepository Functions;
    public FunnyCommentsRepository FunnyComments;
    public FunnyDescriptionsRepository FunnyDescriptions;
    public GameCommandsRepository GameCommands;
    public GendersRepository Genders;
    public GodsRepository Gods;
    public HelpGroupsRepository HelpGroups;
    public HorrificDescriptionsRepository HorrificDescriptions;
    public InsultPlayerAttacksRepository InsultPlayerAttacks;
    public InventorySlotsRepository InventorySlots;
    public ItemClassesRepository ItemClasses;
    public ItemFactoriesRepository ItemFactories;
    public ItemFiltersRepository ItemFilters;
    public ItemQualityRatingsRepository ItemQualityRatings;
    public JustificationsRepository Justifications;
    public MartialArtsAttacksRepository MartialArtsAttacks;
    public MoanPlayerAttacksRepository MoanPlayerAttacks;
    public MonsterFiltersRepository MonsterFilters;
    public MonsterRacesRepository MonsterRaces;
    public MonsterSpellsRepository MonsterSpells;
    public MushroomReadableFlavorsRepository MushroomReadableFlavors;
    public MutationsRepository Mutations;
    public PatronsRepository Patrons;
    public PluralsRepository Plurals;
    public PotionReadableFlavorsRepository PotionReadableFlavors;
    public PowersRepository Powers;
    public ProjectileGraphicsRepository ProjectileGraphics;
    public ProjectilesRepository Projectiles;
    public PropertiesRepository Properties;
    public RacesRepository Races;
    public RareItemsRepository RareItems;
    public RealmsRepository Realms;
    public RewardsRepository Rewards;
    public RingReadableFlavorsRepository RingReadableFlavors;
    public RodReadableFlavorsRepository RodReadableFlavors;
    public RoomLayoutsRepository RoomLayouts;
    public ScriptsRepository Scripts;
    public ScrollReadableFlavorsRepository ScrollReadableFlavors;
    public ShopkeeperAcceptedCommentsRepository ShopkeeperAcceptedComments;
    public ShopkeeperBargainCommentsRepository ShopkeeperBargainComments;
    public ShopkeeperGoodCommentsRepository ShopkeeperGoodComments;
    public ShopkeeperLessThanGuessCommentsRepository ShopkeeperLessThanGuessComments;
    public ShopkeepersRepository Shopkeepers;
    public ShopkeeperWorthlessCommentsRepository ShopkeeperWorthlessComments;
    public SingingPlayerAttacksRepository SingingPlayerAttacks;
    public SpellResistantDetectionsRepository SpellResistantDetections;
    public SpellsRepository Spells;
    public StaffReadableFlavorsRepository StaffReadableFlavors;
    public StoreCommandsRepository StoreCommands;
    public StoreFactoriesRepository StoreFactories;
    public SymbolsRepository Symbols;
    public TalentsRepository Talents;
    public TilesRepository Tiles;
    public TimersRepository Timers;
    public TownsRepository Towns;
    public UnreadableFlavorSyllablesRepository UnreadableFlavorSyllables;
    public VaultsRepository Vaults;
    public WandReadableFlavorsRepository WandReadableFlavors;
    public WizardCommandsRepository WizardCommands;
    public WidgetsRepository Widgets;
    public WorshipPlayerAttacksRepository WorshipPlayerAttacks;

    private Dictionary<string, Dictionary<string, object>> _repositoryDictionary = new Dictionary<string, Dictionary<string, object>>();

    public void AddInterfaceRepository<T>()
    {
        string typeName = typeof(T).Name;
        if (_repositoryDictionary.TryGetValue(typeName, out Dictionary<string, object>? loadAndBindList))
        {
            throw new Exception("AddInterface duplicate {typeName}");
        }
        loadAndBindList = new Dictionary<string, object>();
        _repositoryDictionary.Add(typeName, loadAndBindList);
    }

    public T? GetNullable<T>(string? key) where T : class
    {
        if (key == null)
        {
            return null;
        }

        string typeName = typeof(T).Name;

        // Check to see if the dictionary has a dictionary for this type of object.
        if (!_repositoryDictionary.TryGetValue(typeName, out Dictionary<string, object>? loadAndBindList))
        {
            throw new Exception($"The {typeof(T).Name} singleton interface was not registered.");
        }

        // Retrieve the singleton by key name.
        if (!loadAndBindList.TryGetValue(key, out object? singleton))
        {
            throw new Exception($"The singleton {typeof(T).Name}.{key} does not exist.");
        }
        return (T)singleton;
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

                        // Check to see if there is a repository that is registered for this type.
                        if (_repositoryDictionary.TryGetValue(typeName, out Dictionary<string, object>? typeRepositoryDictionary))
                        {
                            // We only instantiate the object once and only if we are storing it.
                            if (singleton == null)
                            {
                                singleton = constructors[0].Invoke(new object[] { Game });
                            }
                            
                            // Ensure the singleton implements the IGetKey interface and get the key from the singleton.
                            string key;
                            switch (singleton)
                            {
                                case IGetKey getKeySingle:
                                    key = getKeySingle.GetKey;
                                    break;
                                default:
                                    throw new Exception($"The singleton {type.Name} does not implement the IGetKey interface.");
                            }

                            // Ensure there isn't already a singleton with the same name.
                            if (typeRepositoryDictionary.TryGetValue(key, out _))
                            {
                                throw new Exception($"Cannot add duplicate {type.Name} singleton with the key {key}.");
                            }
                            typeRepositoryDictionary.Add(key, singleton);
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
    /// Performs the load phase of the singleton repository.  This phase reads all of the types from the assembly and adds it into its respective
    /// collection--if the ExcludeFromRepository property returns false.  If the ExcludeFromRepository is true, the singleton object will be discarded.
    /// </summary>
    /// <param name="game"></param>
    public void Load()
    {
        // These are the types to load from the assembly.
        AddInterfaceRepository<IIntValue>();
        AddInterfaceRepository<ICastScript>();
        AddInterfaceRepository<Property>();
        AddInterfaceRepository<Timer>();
        AddInterfaceRepository<Function>();
        AddInterfaceRepository<Activation>();
        LoadAllAssemblyTypes();


        // Create all of the repositories.  All of the repositories will be empty and have an instance to the save game.
        Activations = AddRepository<ActivationsRepository>(new ActivationsRepository(Game));
        Alignments = AddRepository<AlignmentsRepository>(new AlignmentsRepository(Game));
        AlterActions = AddRepository<AlterActionsRepository>(new AlterActionsRepository(Game));
        AmuletReadableFlavors = AddRepository<AmuletReadableFlavorsRepository>(new AmuletReadableFlavorsRepository(Game));
        Animations = AddRepository<AnimationsRepository>(new AnimationsRepository(Game));
        ArtifactBiases = AddRepository<ArtifactBiasesRepository>(new ArtifactBiasesRepository(Game));
        AttackEffects = AddRepository<AttackEffectsRepository>(new AttackEffectsRepository(Game));
        Attacks = AddRepository<AttacksRepository>(new AttacksRepository(Game));
        BirthStages = AddRepository<BirthStagesRepository>(new BirthStagesRepository(Game));
        CharacterClasses = AddRepository<CharacterClassesRepository>(new CharacterClassesRepository(Game));
        ChestTrapConfigurations = AddRepository<ChestTrapConfigurationsRepository>(new ChestTrapConfigurationsRepository(Game));
        ChestTraps = AddRepository<ChestTrapsRepository>(new ChestTrapsRepository(Game));
        ClassSpells = AddRepository<ClassSpellsRepository>(new ClassSpellsRepository(Game));
        DungeonGuardians = AddRepository<DungeonGuardiansRepository>(new DungeonGuardiansRepository(Game));
        Dungeons = AddRepository<DungeonsRepository>(new DungeonsRepository(Game));
        ElvishText = AddRepository<ElvishTextRepository>(new ElvishTextRepository(Game));
        FindQuests = AddRepository<FindQuestsRepository>(new FindQuestsRepository(Game));
        FixedArtifacts = AddRepository<FixedArtifactsRepository>(new FixedArtifactsRepository(Game));
        FlaggedActions = AddRepository<FlaggedActionsRepository>(new FlaggedActionsRepository(Game));
        Forms = AddRepository<FormsRepository>(new FormsRepository(Game));
        Functions = AddRepository<FunctionsRepository>(new FunctionsRepository(Game));
        FunnyComments = AddRepository<FunnyCommentsRepository>(new FunnyCommentsRepository(Game));
        FunnyDescriptions = AddRepository<FunnyDescriptionsRepository>(new FunnyDescriptionsRepository(Game));
        GameCommands = AddRepository<GameCommandsRepository>(new GameCommandsRepository(Game));
        Genders = AddRepository<GendersRepository>(new GendersRepository(Game));
        Gods = AddRepository<GodsRepository>(new GodsRepository(Game));
        HelpGroups = AddRepository<HelpGroupsRepository>(new HelpGroupsRepository(Game));
        HorrificDescriptions = AddRepository<HorrificDescriptionsRepository>(new HorrificDescriptionsRepository(Game));
        InsultPlayerAttacks = AddRepository<InsultPlayerAttacksRepository>(new InsultPlayerAttacksRepository(Game));
        InventorySlots = AddRepository<InventorySlotsRepository>(new InventorySlotsRepository(Game));
        ItemClasses = AddRepository<ItemClassesRepository>(new ItemClassesRepository(Game));
        ItemFactories = AddRepository<ItemFactoriesRepository>(new ItemFactoriesRepository(Game));
        ItemFilters = AddRepository<ItemFiltersRepository>(new ItemFiltersRepository(Game));
        ItemQualityRatings = AddRepository<ItemQualityRatingsRepository>(new ItemQualityRatingsRepository(Game));
        Justifications = AddRepository<JustificationsRepository>(new JustificationsRepository(Game));
        MartialArtsAttacks = AddRepository<MartialArtsAttacksRepository>(new MartialArtsAttacksRepository(Game));
        MoanPlayerAttacks = AddRepository<MoanPlayerAttacksRepository>(new MoanPlayerAttacksRepository(Game));
        MonsterFilters = AddRepository<MonsterFiltersRepository>(new MonsterFiltersRepository(Game));
        MonsterRaces = AddRepository<MonsterRacesRepository>(new MonsterRacesRepository(Game));
        MonsterSpells = AddRepository<MonsterSpellsRepository>(new MonsterSpellsRepository(Game));
        MushroomReadableFlavors = AddRepository<MushroomReadableFlavorsRepository>(new MushroomReadableFlavorsRepository(Game));
        Mutations = AddRepository<MutationsRepository>(new MutationsRepository(Game));
        Patrons = AddRepository<PatronsRepository>(new PatronsRepository(Game));
        Plurals = AddRepository<PluralsRepository>(new PluralsRepository(Game));
        PotionReadableFlavors = AddRepository<PotionReadableFlavorsRepository>(new PotionReadableFlavorsRepository(Game));
        Powers = AddRepository<PowersRepository>(new PowersRepository(Game));
        ProjectileGraphics = AddRepository<ProjectileGraphicsRepository>(new ProjectileGraphicsRepository(Game));
        Projectiles = AddRepository<ProjectilesRepository>(new ProjectilesRepository(Game));
        Properties = AddRepository<PropertiesRepository>(new PropertiesRepository(Game));
        Races = AddRepository<RacesRepository>(new RacesRepository(Game));
        RareItems = AddRepository<RareItemsRepository>(new RareItemsRepository(Game));
        Realms = AddRepository<RealmsRepository>(new RealmsRepository(Game));
        Rewards = AddRepository<RewardsRepository>(new RewardsRepository(Game));
        RingReadableFlavors = AddRepository<RingReadableFlavorsRepository>(new RingReadableFlavorsRepository(Game));
        RodReadableFlavors = AddRepository<RodReadableFlavorsRepository>(new RodReadableFlavorsRepository(Game));
        RoomLayouts = AddRepository<RoomLayoutsRepository>(new RoomLayoutsRepository(Game));
        Scripts = AddRepository<ScriptsRepository>(new ScriptsRepository(Game));
        ScrollReadableFlavors = AddRepository<ScrollReadableFlavorsRepository>(new ScrollReadableFlavorsRepository(Game));
        ShopkeeperAcceptedComments = AddRepository<ShopkeeperAcceptedCommentsRepository>(new ShopkeeperAcceptedCommentsRepository(Game));
        ShopkeeperBargainComments = AddRepository<ShopkeeperBargainCommentsRepository>(new ShopkeeperBargainCommentsRepository(Game));
        ShopkeeperGoodComments = AddRepository<ShopkeeperGoodCommentsRepository>(new ShopkeeperGoodCommentsRepository(Game));
        ShopkeeperLessThanGuessComments = AddRepository<ShopkeeperLessThanGuessCommentsRepository>(new ShopkeeperLessThanGuessCommentsRepository(Game));
        Shopkeepers = AddRepository<ShopkeepersRepository>(new ShopkeepersRepository(Game));
        ShopkeeperWorthlessComments = AddRepository<ShopkeeperWorthlessCommentsRepository>(new ShopkeeperWorthlessCommentsRepository(Game));
        SingingPlayerAttacks = AddRepository<SingingPlayerAttacksRepository>(new SingingPlayerAttacksRepository(Game));
        SpellResistantDetections = AddRepository<SpellResistantDetectionsRepository>(new SpellResistantDetectionsRepository(Game));
        Spells = AddRepository<SpellsRepository>(new SpellsRepository(Game));
        StaffReadableFlavors = AddRepository<StaffReadableFlavorsRepository>(new StaffReadableFlavorsRepository(Game));
        StoreCommands = AddRepository<StoreCommandsRepository>(new StoreCommandsRepository(Game));
        StoreFactories = AddRepository<StoreFactoriesRepository>(new StoreFactoriesRepository(Game));
        Symbols = AddRepository<SymbolsRepository>(new SymbolsRepository(Game));
        Talents = AddRepository<TalentsRepository>(new TalentsRepository(Game));
        Tiles = AddRepository<TilesRepository>(new TilesRepository(Game));
        Timers = AddRepository<TimersRepository>(new TimersRepository(Game));
        Towns = AddRepository<TownsRepository>(new TownsRepository(Game));
        UnreadableFlavorSyllables = AddRepository<UnreadableFlavorSyllablesRepository>(new UnreadableFlavorSyllablesRepository(Game));
        Vaults = AddRepository<VaultsRepository>(new VaultsRepository(Game));
        WandReadableFlavors = AddRepository<WandReadableFlavorsRepository>(new WandReadableFlavorsRepository(Game));
        WizardCommands = AddRepository<WizardCommandsRepository>(new WizardCommandsRepository(Game));
        Widgets = AddRepository<WidgetsRepository>(new WidgetsRepository(Game));
        WorshipPlayerAttacks = AddRepository<WorshipPlayerAttacksRepository>(new WorshipPlayerAttacksRepository(Game));

        // Load all of the objects into each repository.  This is where the assembly will be scanned or the database will be read.
        LoadRepositoryItems();
        BindRepositoryItems();
    }
}
