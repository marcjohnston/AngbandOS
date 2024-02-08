// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core;

[Serializable]
/// <summary>
/// Represents a repository for all game singletons.
/// </summary>
internal class SingletonRepository
{
    private readonly SaveGame SaveGame;
    private readonly List<ILoadable> _repositories = new();

    public FlaggedActionsRepository FlaggedActions;
    public TownsRepository Towns;
    public ItemFactoriesRepository ItemFactories;
    public StoreFactoriesRepository StoreFactories;
    public ItemClassesRepository ItemClasses;
    public MutationsRepository Mutations;
    public ChestTrapsRepository ChestTraps;
    public AttacksRepository Attacks;
    public AttackEffectsRepository AttackEffects;
    public SpellResistantDetectionsRepository SpellResistantDetections;
    public RoomLayoutsRepository RoomLayouts;
    public MonsterSpellsRepository MonsterSpells;
    public TalentsRepository Talents;
    public AlterActionsRepository AlterActions;
    public SymbolsRepository Symbols;
    public MartialArtsAttacksRepository MartialArtsAttacks;
    public ScriptsRepository Scripts;
    public DungeonsRepository Dungeons;
    public GendersRepository Genders;
    public BirthStagesRepository BirthStages;
    public ProjectilesRepository Projectiles;
    public PatronsRepository Patrons;
    public AnimationsRepository Animations;
    public FixedArtifactsRepository FixedArtifacts;
    public GameCommandsRepository GameCommands;
    public ArtifactBiasesRepository ArtifactBiases;
    public InventorySlotsRepository InventorySlots;
    public MonsterRacesRepository MonsterRaces;
    public ProjectileGraphicsRepository ProjectileGraphics;
    public ActivationsRepository Activations;
    public RacesRepository Races;
    public StoreCommandsRepository StoreCommands;
    public VaultsRepository Vaults;
    public WizardCommandsRepository WizardCommands;
    public TimedActionsRepository TimedActions;
    public CharacterClassesRepository CharacterClasses;
    public RealmsRepository Realms;
    public AmuletFlavorsRepository AmuletFlavors;
    public MushroomFlavorsRepository MushroomFlavors;
    public PotionFlavorsRepository PotionFlavors;
    public RingFlavorsRepository RingFlavors;
    public RodFlavorsRepository RodFlavors;
    public ScrollFlavorsRepository ScrollFlavors;
    public StaffFlavorsRepository StaffFlavors;
    public WandFlavorsRepository WandFlavors;
    public ChestTrapConfigurationsRepository ChestTrapConfigurations;
    public HelpGroupsRepository HelpGroups;
    public ShopkeepersRepository Shopkeepers;
    public SpellsRepository Spells;
    public CastingTypesRepository CastingTypes;
    public RewardsRepository Rewards;
    public TilesRepository Tiles;
    public RareItemsRepository RareItems;
    public ClassSpellsRepository ClassSpells;
    public ShopkeeperGoodCommentsRepository ShopkeeperGoodComments;
    public ShopkeeperBargainCommentsRepository ShopkeeperBargainComments;
    public ElvishTextRepository ElvishText;
    public FunnyDescriptionsRepository FunnyDescriptions;
    public FunnyCommentsRepository FunnyComments;
    public HorrificDescriptionsRepository HorrificDescriptions;
    public InsultPlayerAttacksRepository InsultPlayerAttacks;
    public MoanPlayerAttacksRepository MoanPlayerAttacks;                    
    public ShopkeeperLessThanGuessComments ShopkeeperLessThanGuessComments;
    public ShopkeeperWorthlessCommentsRepository ShopkeeperWorthlessComments;
    public SingingPlayerAttacksRepository SingingPlayerAttacks;
    public ShopkeeperAcceptedCommentsRepository ShopkeeperAcceptedComments;
    public WorshipPlayerAttacksRepository WorshipPlayerAttacks;
    public FindQuestsRepository FindQuests;
    public ItemFiltersRepository ItemFilters;
    public MonsterFiltersRepository MonsterFilters;
    public DungeonGuardiansRepository DungeonGuardians;

    public SingletonRepository(SaveGame saveGame)
    {
        SaveGame = saveGame;
    }

    private T AddRepository<T>(T repository) where T : ILoadable
    {
        _repositories.Add(repository);
        return repository;
    }

    private void LoadRepositoryItems()
    {
        foreach (ILoadable repository in _repositories)
        {
            repository.Load();
        }
    }

    private void BindRepositoryItems()
    {
        foreach (ILoadable repository in _repositories)
        {
            repository.Bind();
        }
    }

    /// <summary>
    /// Performs the load phase of the singleton repository.  This phase reads all of the types from the assembly and adds it into its respective
    /// collection--if the ExcludeFromRepository property returns false.  If the ExcludeFromRepository is true, the singleton object will be discarded.
    /// </summary>
    /// <param name="saveGame"></param>
    public void Load()
    {
        // Create all of the repositories.  All of the repositories will be empty and have an instance to the save game.
        FlaggedActions = AddRepository<FlaggedActionsRepository>(new FlaggedActionsRepository(SaveGame));
        Towns = AddRepository<TownsRepository>(new TownsRepository(SaveGame));
        ItemFactories = AddRepository<ItemFactoriesRepository>(new ItemFactoriesRepository(SaveGame));
        StoreFactories = AddRepository<StoreFactoriesRepository>(new StoreFactoriesRepository(SaveGame));
        ItemClasses = AddRepository<ItemClassesRepository>(new ItemClassesRepository(SaveGame));
        Mutations = AddRepository<MutationsRepository>(new MutationsRepository(SaveGame));
        ChestTraps = AddRepository<ChestTrapsRepository>(new ChestTrapsRepository(SaveGame));
        Attacks = AddRepository<AttacksRepository>(new AttacksRepository(SaveGame));
        AttackEffects = AddRepository<AttackEffectsRepository>(new AttackEffectsRepository(SaveGame));
        SpellResistantDetections = AddRepository<SpellResistantDetectionsRepository>(new SpellResistantDetectionsRepository(SaveGame));
        RoomLayouts = AddRepository<RoomLayoutsRepository>(new RoomLayoutsRepository(SaveGame));
        MonsterSpells = AddRepository<MonsterSpellsRepository>(new MonsterSpellsRepository(SaveGame));
        Talents = AddRepository<TalentsRepository>(new TalentsRepository(SaveGame));
        AlterActions = AddRepository<AlterActionsRepository>(new AlterActionsRepository(SaveGame));
        Symbols = AddRepository<SymbolsRepository>(new SymbolsRepository(SaveGame));
        MartialArtsAttacks = AddRepository<MartialArtsAttacksRepository>(new MartialArtsAttacksRepository(SaveGame));
        Scripts = AddRepository<ScriptsRepository>(new ScriptsRepository(SaveGame));
        Dungeons = AddRepository<DungeonsRepository>(new DungeonsRepository(SaveGame));
        Genders = AddRepository<GendersRepository>(new GendersRepository(SaveGame));
        BirthStages = AddRepository<BirthStagesRepository>(new BirthStagesRepository(SaveGame));
        Projectiles = AddRepository<ProjectilesRepository>(new ProjectilesRepository(SaveGame));
        Patrons = AddRepository<PatronsRepository>(new PatronsRepository(SaveGame));
        Animations = AddRepository<AnimationsRepository>(new AnimationsRepository(SaveGame));
        FixedArtifacts = AddRepository<FixedArtifactsRepository>(new FixedArtifactsRepository(SaveGame));
        GameCommands = AddRepository<GameCommandsRepository>(new GameCommandsRepository(SaveGame));
        ArtifactBiases = AddRepository<ArtifactBiasesRepository>(new ArtifactBiasesRepository(SaveGame));
        InventorySlots = AddRepository<InventorySlotsRepository>(new InventorySlotsRepository(SaveGame));
        MonsterRaces = AddRepository<MonsterRacesRepository>(new MonsterRacesRepository(SaveGame));
        ProjectileGraphics = AddRepository<ProjectileGraphicsRepository>(new ProjectileGraphicsRepository(SaveGame));
        Activations = AddRepository<ActivationsRepository>(new ActivationsRepository(SaveGame));
        Races = AddRepository<RacesRepository>(new RacesRepository(SaveGame));
        StoreCommands = AddRepository<StoreCommandsRepository>(new StoreCommandsRepository(SaveGame));
        Vaults = AddRepository<VaultsRepository>(new VaultsRepository(SaveGame));
        WizardCommands = AddRepository<WizardCommandsRepository>(new WizardCommandsRepository(SaveGame));
        TimedActions = AddRepository<TimedActionsRepository>(new TimedActionsRepository(SaveGame));
        CharacterClasses = AddRepository<CharacterClassesRepository>(new CharacterClassesRepository(SaveGame));
        Realms = AddRepository<RealmsRepository>(new RealmsRepository(SaveGame));
        AmuletFlavors = AddRepository<AmuletFlavorsRepository>(new AmuletFlavorsRepository(SaveGame));
        MushroomFlavors = AddRepository<MushroomFlavorsRepository>(new MushroomFlavorsRepository(SaveGame));
        PotionFlavors = AddRepository<PotionFlavorsRepository>(new PotionFlavorsRepository(SaveGame));
        RingFlavors = AddRepository<RingFlavorsRepository>(new RingFlavorsRepository(SaveGame));
        RodFlavors = AddRepository<RodFlavorsRepository>(new RodFlavorsRepository(SaveGame));
        ScrollFlavors = AddRepository<ScrollFlavorsRepository>(new ScrollFlavorsRepository(SaveGame));
        StaffFlavors = AddRepository<StaffFlavorsRepository>(new StaffFlavorsRepository(SaveGame));
        WandFlavors = AddRepository<WandFlavorsRepository>(new WandFlavorsRepository(SaveGame));
        ChestTrapConfigurations = AddRepository<ChestTrapConfigurationsRepository>(new ChestTrapConfigurationsRepository(SaveGame));
        HelpGroups = AddRepository<HelpGroupsRepository>(new HelpGroupsRepository(SaveGame));
        Shopkeepers = AddRepository<ShopkeepersRepository>(new ShopkeepersRepository(SaveGame));
        Spells = AddRepository<SpellsRepository>(new SpellsRepository(SaveGame));
        CastingTypes = AddRepository<CastingTypesRepository>(new CastingTypesRepository(SaveGame));
        Rewards = AddRepository<RewardsRepository>(new RewardsRepository(SaveGame));
        Tiles = AddRepository<TilesRepository>(new TilesRepository(SaveGame));
        RareItems = AddRepository<RareItemsRepository>(new RareItemsRepository(SaveGame));
        ClassSpells = AddRepository<ClassSpellsRepository>(new ClassSpellsRepository(SaveGame));
        ShopkeeperGoodComments = AddRepository<ShopkeeperGoodCommentsRepository>(new ShopkeeperGoodCommentsRepository(SaveGame));
        ShopkeeperBargainComments = AddRepository<ShopkeeperBargainCommentsRepository>(new ShopkeeperBargainCommentsRepository(SaveGame));
        ElvishText = AddRepository<ElvishTextRepository>(new ElvishTextRepository(SaveGame));
        FunnyDescriptions = AddRepository<FunnyDescriptionsRepository>(new FunnyDescriptionsRepository(SaveGame));
        FunnyComments = AddRepository<FunnyCommentsRepository>(new FunnyCommentsRepository(SaveGame));
        HorrificDescriptions = AddRepository<HorrificDescriptionsRepository>(new HorrificDescriptionsRepository(SaveGame));
        InsultPlayerAttacks = AddRepository<InsultPlayerAttacksRepository>(new InsultPlayerAttacksRepository(SaveGame));
        MoanPlayerAttacks = AddRepository<MoanPlayerAttacksRepository>(new MoanPlayerAttacksRepository(SaveGame));
        ShopkeeperLessThanGuessComments = AddRepository<ShopkeeperLessThanGuessComments>(new ShopkeeperLessThanGuessComments(SaveGame));
        ShopkeeperWorthlessComments = AddRepository<ShopkeeperWorthlessCommentsRepository>(new ShopkeeperWorthlessCommentsRepository(SaveGame));
        SingingPlayerAttacks = AddRepository<SingingPlayerAttacksRepository>(new SingingPlayerAttacksRepository(SaveGame));
        ShopkeeperAcceptedComments = AddRepository<ShopkeeperAcceptedCommentsRepository>(new ShopkeeperAcceptedCommentsRepository(SaveGame));
        WorshipPlayerAttacks = AddRepository<WorshipPlayerAttacksRepository>(new WorshipPlayerAttacksRepository(SaveGame));
        FindQuests = AddRepository<FindQuestsRepository>(new FindQuestsRepository(SaveGame));
        ItemFilters = AddRepository<ItemFiltersRepository>(new ItemFiltersRepository(SaveGame));
        MonsterFilters = AddRepository<MonsterFiltersRepository>(new MonsterFiltersRepository(SaveGame));
        DungeonGuardians = AddRepository<DungeonGuardiansRepository>(new DungeonGuardiansRepository(SaveGame));

        // Load all of the objects into each repository.  This is where the assembly will be scanned or the database will be read.
        LoadRepositoryItems();
        BindRepositoryItems();
    }
}
