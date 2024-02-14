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

    public ActivationsRepository Activations;
    public AlterActionsRepository AlterActions;
    public AmuletReadableFlavorsRepository AmuletReadableFlavors;
    public AnimationsRepository Animations;
    public ArtifactBiasesRepository ArtifactBiases;
    public AttackEffectsRepository AttackEffects;
    public AttacksRepository Attacks;
    public BirthStagesRepository BirthStages;
    public CastingTypesRepository CastingTypes;
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
    public FunnyCommentsRepository FunnyComments;
    public FunnyDescriptionsRepository FunnyDescriptions;
    public GameCommandsRepository GameCommands;
    public GendersRepository Genders;
    public HelpGroupsRepository HelpGroups;
    public HorrificDescriptionsRepository HorrificDescriptions;
    public InsultPlayerAttacksRepository InsultPlayerAttacks;
    public InventorySlotsRepository InventorySlots;
    public ItemClassesRepository ItemClasses;
    public ItemFactoriesRepository ItemFactories;
    public ItemFiltersRepository ItemFilters;
    public ItemQualityRatingsRepository ItemQualityRatings;
    public MartialArtsAttacksRepository MartialArtsAttacks;
    public MoanPlayerAttacksRepository MoanPlayerAttacks;
    public MonsterFiltersRepository MonsterFilters;
    public MonsterRacesRepository MonsterRaces;
    public MonsterSpellsRepository MonsterSpells;
    public MushroomReadableFlavorsRepository MushroomReadableFlavors;
    public MutationsRepository Mutations;
    public PatronsRepository Patrons;
    public PotionReadableFlavorsRepository PotionReadableFlavors;
    public PowersRepository Powers;
    public ProjectileGraphicsRepository ProjectileGraphics;
    public ProjectilesRepository Projectiles;
    public RacesRepository Races;
    public RareItemsRepository RareItems;
    public RealmsRepository Realms;
    public RewardsRepository Rewards;
    public RingReadableFlavorsRepository RingReadableFlavors;
    public RodReadableFlavorsRepository RodReadableFlavors;
    public RoomLayoutsRepository RoomLayouts;
    public ScriptsRepository Scripts;
    public ScrollReadableFlavorsRepository ScrollReadableFlavors;
    public UnreadableFlavorSyllablesRepository UnreadableFlavorSyllables;
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
    public TimedActionsRepository TimedActions;
    public TownsRepository Towns;
    public VaultsRepository Vaults;
    public WandReadableFlavorsRepository WandReadableFlavors;
    public WizardCommandsRepository WizardCommands;
    public WorshipPlayerAttacksRepository WorshipPlayerAttacks;

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
        Activations = AddRepository<ActivationsRepository>(new ActivationsRepository(SaveGame));
        AlterActions = AddRepository<AlterActionsRepository>(new AlterActionsRepository(SaveGame));
        AmuletReadableFlavors = AddRepository<AmuletReadableFlavorsRepository>(new AmuletReadableFlavorsRepository(SaveGame));
        Animations = AddRepository<AnimationsRepository>(new AnimationsRepository(SaveGame));
        ArtifactBiases = AddRepository<ArtifactBiasesRepository>(new ArtifactBiasesRepository(SaveGame));
        AttackEffects = AddRepository<AttackEffectsRepository>(new AttackEffectsRepository(SaveGame));
        Attacks = AddRepository<AttacksRepository>(new AttacksRepository(SaveGame));
        BirthStages = AddRepository<BirthStagesRepository>(new BirthStagesRepository(SaveGame));
        CastingTypes = AddRepository<CastingTypesRepository>(new CastingTypesRepository(SaveGame));
        CharacterClasses = AddRepository<CharacterClassesRepository>(new CharacterClassesRepository(SaveGame));
        ChestTrapConfigurations = AddRepository<ChestTrapConfigurationsRepository>(new ChestTrapConfigurationsRepository(SaveGame));
        ChestTraps = AddRepository<ChestTrapsRepository>(new ChestTrapsRepository(SaveGame));
        ClassSpells = AddRepository<ClassSpellsRepository>(new ClassSpellsRepository(SaveGame));
        DungeonGuardians = AddRepository<DungeonGuardiansRepository>(new DungeonGuardiansRepository(SaveGame));
        Dungeons = AddRepository<DungeonsRepository>(new DungeonsRepository(SaveGame));
        ElvishText = AddRepository<ElvishTextRepository>(new ElvishTextRepository(SaveGame));
        FindQuests = AddRepository<FindQuestsRepository>(new FindQuestsRepository(SaveGame));
        FixedArtifacts = AddRepository<FixedArtifactsRepository>(new FixedArtifactsRepository(SaveGame));
        FlaggedActions = AddRepository<FlaggedActionsRepository>(new FlaggedActionsRepository(SaveGame));
        FunnyComments = AddRepository<FunnyCommentsRepository>(new FunnyCommentsRepository(SaveGame));
        FunnyDescriptions = AddRepository<FunnyDescriptionsRepository>(new FunnyDescriptionsRepository(SaveGame));
        GameCommands = AddRepository<GameCommandsRepository>(new GameCommandsRepository(SaveGame));
        Genders = AddRepository<GendersRepository>(new GendersRepository(SaveGame));
        HelpGroups = AddRepository<HelpGroupsRepository>(new HelpGroupsRepository(SaveGame));
        HorrificDescriptions = AddRepository<HorrificDescriptionsRepository>(new HorrificDescriptionsRepository(SaveGame));
        InsultPlayerAttacks = AddRepository<InsultPlayerAttacksRepository>(new InsultPlayerAttacksRepository(SaveGame));
        InventorySlots = AddRepository<InventorySlotsRepository>(new InventorySlotsRepository(SaveGame));
        ItemClasses = AddRepository<ItemClassesRepository>(new ItemClassesRepository(SaveGame));
        ItemFactories = AddRepository<ItemFactoriesRepository>(new ItemFactoriesRepository(SaveGame));
        ItemFilters = AddRepository<ItemFiltersRepository>(new ItemFiltersRepository(SaveGame));
        ItemQualityRatings = AddRepository<ItemQualityRatingsRepository>(new ItemQualityRatingsRepository(SaveGame));
        MartialArtsAttacks = AddRepository<MartialArtsAttacksRepository>(new MartialArtsAttacksRepository(SaveGame));
        MoanPlayerAttacks = AddRepository<MoanPlayerAttacksRepository>(new MoanPlayerAttacksRepository(SaveGame));
        MonsterFilters = AddRepository<MonsterFiltersRepository>(new MonsterFiltersRepository(SaveGame));
        MonsterRaces = AddRepository<MonsterRacesRepository>(new MonsterRacesRepository(SaveGame));
        MonsterSpells = AddRepository<MonsterSpellsRepository>(new MonsterSpellsRepository(SaveGame));
        MushroomReadableFlavors = AddRepository<MushroomReadableFlavorsRepository>(new MushroomReadableFlavorsRepository(SaveGame));
        Mutations = AddRepository<MutationsRepository>(new MutationsRepository(SaveGame));
        Patrons = AddRepository<PatronsRepository>(new PatronsRepository(SaveGame));
        PotionReadableFlavors = AddRepository<PotionReadableFlavorsRepository>(new PotionReadableFlavorsRepository(SaveGame));
        Powers = AddRepository<PowersRepository>(new PowersRepository(SaveGame));
        ProjectileGraphics = AddRepository<ProjectileGraphicsRepository>(new ProjectileGraphicsRepository(SaveGame));
        Projectiles = AddRepository<ProjectilesRepository>(new ProjectilesRepository(SaveGame));
        Races = AddRepository<RacesRepository>(new RacesRepository(SaveGame));
        RareItems = AddRepository<RareItemsRepository>(new RareItemsRepository(SaveGame));
        Realms = AddRepository<RealmsRepository>(new RealmsRepository(SaveGame));
        Rewards = AddRepository<RewardsRepository>(new RewardsRepository(SaveGame));
        RingReadableFlavors = AddRepository<RingReadableFlavorsRepository>(new RingReadableFlavorsRepository(SaveGame));
        RodReadableFlavors = AddRepository<RodReadableFlavorsRepository>(new RodReadableFlavorsRepository(SaveGame));
        RoomLayouts = AddRepository<RoomLayoutsRepository>(new RoomLayoutsRepository(SaveGame));
        Scripts = AddRepository<ScriptsRepository>(new ScriptsRepository(SaveGame));
        ScrollReadableFlavors = AddRepository<ScrollReadableFlavorsRepository>(new ScrollReadableFlavorsRepository(SaveGame));
        UnreadableFlavorSyllables = AddRepository<UnreadableFlavorSyllablesRepository>(new UnreadableFlavorSyllablesRepository(SaveGame));
        ShopkeeperAcceptedComments = AddRepository<ShopkeeperAcceptedCommentsRepository>(new ShopkeeperAcceptedCommentsRepository(SaveGame));
        ShopkeeperBargainComments = AddRepository<ShopkeeperBargainCommentsRepository>(new ShopkeeperBargainCommentsRepository(SaveGame));
        ShopkeeperGoodComments = AddRepository<ShopkeeperGoodCommentsRepository>(new ShopkeeperGoodCommentsRepository(SaveGame));
        ShopkeeperLessThanGuessComments = AddRepository<ShopkeeperLessThanGuessCommentsRepository>(new ShopkeeperLessThanGuessCommentsRepository(SaveGame));
        Shopkeepers = AddRepository<ShopkeepersRepository>(new ShopkeepersRepository(SaveGame));
        ShopkeeperWorthlessComments = AddRepository<ShopkeeperWorthlessCommentsRepository>(new ShopkeeperWorthlessCommentsRepository(SaveGame));
        SingingPlayerAttacks = AddRepository<SingingPlayerAttacksRepository>(new SingingPlayerAttacksRepository(SaveGame));
        SpellResistantDetections = AddRepository<SpellResistantDetectionsRepository>(new SpellResistantDetectionsRepository(SaveGame));
        Spells = AddRepository<SpellsRepository>(new SpellsRepository(SaveGame));
        StaffReadableFlavors = AddRepository<StaffReadableFlavorsRepository>(new StaffReadableFlavorsRepository(SaveGame));
        StoreCommands = AddRepository<StoreCommandsRepository>(new StoreCommandsRepository(SaveGame));
        StoreFactories = AddRepository<StoreFactoriesRepository>(new StoreFactoriesRepository(SaveGame));
        Symbols = AddRepository<SymbolsRepository>(new SymbolsRepository(SaveGame));
        Talents = AddRepository<TalentsRepository>(new TalentsRepository(SaveGame));
        Tiles = AddRepository<TilesRepository>(new TilesRepository(SaveGame));
        TimedActions = AddRepository<TimedActionsRepository>(new TimedActionsRepository(SaveGame));
        Towns = AddRepository<TownsRepository>(new TownsRepository(SaveGame));
        Vaults = AddRepository<VaultsRepository>(new VaultsRepository(SaveGame));
        WandReadableFlavors = AddRepository<WandReadableFlavorsRepository>(new WandReadableFlavorsRepository(SaveGame));
        WizardCommands = AddRepository<WizardCommandsRepository>(new WizardCommandsRepository(SaveGame));
        WorshipPlayerAttacks = AddRepository<WorshipPlayerAttacksRepository>(new WorshipPlayerAttacksRepository(SaveGame));

        // Load all of the objects into each repository.  This is where the assembly will be scanned or the database will be read.
        LoadRepositoryItems();
        BindRepositoryItems();
    }
}
