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
    private readonly List<ILoadable> _repositoryCollections = new();

    public FlaggedActionsRepositoryCollection FlaggedActions;
    public TownsRepositoryCollection Towns;
    public ItemFactoriesRepositoryCollection ItemFactories;
    public StoresRepositoryCollection Stores;
    public ItemClassesRepositoryCollection ItemClasses;
    public MutationsRepositoryCollection Mutations;
    public ChestTrapsRepositoryCollection ChestTraps;
    public AttacksRepositoryCollection Attacks;
    public AttackEffectsRepositoryCollection AttackEffects;
    public SpellResistantDetectionsRepositoryCollection SpellResistantDetections;
    public RoomLayoutsRepositoryCollection RoomLayouts;
    public MonsterSpellsRepositoryCollection MonsterSpells;
    public TalentsRepositoryCollection Talents;
    public AlterActionsRepositoryCollection AlterActions;
    public SymbolsRepositoryCollection Symbols;
    public MartialArtsAttacksRepositoryCollection MartialArtsAttacks;
    public ScriptsRepositoryCollection Scripts;
    public DungeonsRepositoryCollection Dungeons;
    public GendersRepositoryCollection Genders;
    public BirthStagesRepositoryCollection BirthStages;
    public ProjectilesRepositoryCollection Projectiles;
    public PatronsRepositoryCollection Patrons;
    public AnimationsRepositoryCollection Animations;
    public FixedArtifactsRepositoryCollection FixedArtifacts;
    public GameCommandsRepositoryCollection GameCommands;
    public ArtifactBiasesRepositoryCollection ArtifactBiases;
    public InventorySlotsRepositoryCollection InventorySlots;
    public MonsterRacesRepositoryCollection MonsterRaces;
    public ProjectileGraphicsRepositoryCollection ProjectileGraphics;
    public ActivationsRepositoryCollection Activations;
    public RacesRepositoryCollection Races;
    public StoreCommandsRepositoryCollection StoreCommands;
    public VaultsRepositoryCollection Vaults;
    public WizardCommandsRepositoryCollection WizardCommands;
    public TimedActionsRepositoryCollection TimedActions;
    public CharacterClassesRepositoryCollection CharacterClasses;
    public RealmsRepositoryCollection Realms;
    public AmuletFlavoursRepositoryCollection AmuletFlavours;
    public MushroomFlavoursRepositoryCollection MushroomFlavours;
    public PotionFlavoursRepositoryCollection PotionFlavours;
    public RingFlavoursRepositoryCollection RingFlavours;
    public RodFlavoursRepositoryCollection RodFlavours;
    public ScrollFlavoursRepositoryCollection ScrollFlavours;
    public StaffFlavoursRepositoryCollection StaffFlavours;
    public WandFlavoursRepositoryCollection WandFlavours;
    public ChestTrapConfigurationsRepositoryCollection ChestTrapConfigurations;
    public HelpGroupsRepositoryCollection HelpGroups;
    public StoreOwnersRepositoryCollection StoreOwners;
    public SpellsRepositoryCollection Spells;
    public CastingTypesRepositoryCollection CastingTypes;
    public RewardsRepositoryCollection Rewards;
    public TilesRepositoryCollection Tiles;
    public RareItemsRepositoryCollection RareItems;
    public ClassSpellsRepositoryCollection ClassSpells;
    public ShopKeeperGoodCommentsRepositoryCollection ShopKeeperGoodComments;
    public ShopKeeperBargainCommentsRepositoryCollection ShopKeeperBargainComments;
    public ElvishTextRepositoryCollection ElvishText;
    public FunnyDescriptionsRepositoryCollection FunnyDescriptions;
    public FunnyCommentsRepositoryCollection FunnyComments;
    public HorrificDescriptionsRepositoryCollection HorrificDescriptions;
    public InsultPlayerAttacksRepositoryCollection InsultPlayerAttacks;
    public MoanPlayerAttacksRepositoryCollection MoanPlayerAttacks;                    
    public ShopKeeperLessThanGuessCommentsRepositoryCollection ShopKeeperLessThanGuessComments;
    public ShopKeeperWorthlessCommentsRepositoryCollection ShopKeeperWorthlessComments;
    public SingingPlayerAttacksRepositoryCollection SingingPlayerAttacks;
    public StoreOwnerAcceptedCommentsRepositoryCollection StoreOwnerAcceptedComments;
    public WorshipPlayerAttacksRepositoryCollection WorshipPlayerAttacks;
    public FindQuestsRepositoryCollection FindQuests;

    public SingletonRepository(SaveGame saveGame)
    {
        SaveGame = saveGame;
    }

    private T AddRepositoryCollection<T>(T repositoryCollection) where T : ILoadable
    {
        _repositoryCollections.Add(repositoryCollection);
        return repositoryCollection;
    }

    private void LoadRepositoryItems()
    {
        foreach (ILoadable repositoryCollection in _repositoryCollections)
        {
            repositoryCollection.Load();
        }
    }

    private void LoadedRepositoryItems()
    {
        foreach (ILoadable repositoryCollection in _repositoryCollections)
        {
            repositoryCollection.Loaded();
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
        FlaggedActions = AddRepositoryCollection<FlaggedActionsRepositoryCollection>(new FlaggedActionsRepositoryCollection(SaveGame));
        Towns = AddRepositoryCollection<TownsRepositoryCollection>(new TownsRepositoryCollection(SaveGame));
        ItemFactories = AddRepositoryCollection<ItemFactoriesRepositoryCollection>(new ItemFactoriesRepositoryCollection(SaveGame));
        Stores = AddRepositoryCollection<StoresRepositoryCollection>(new StoresRepositoryCollection(SaveGame));
        ItemClasses = AddRepositoryCollection<ItemClassesRepositoryCollection>(new ItemClassesRepositoryCollection(SaveGame));
        Mutations = AddRepositoryCollection<MutationsRepositoryCollection>(new MutationsRepositoryCollection(SaveGame));
        ChestTraps = AddRepositoryCollection<ChestTrapsRepositoryCollection>(new ChestTrapsRepositoryCollection(SaveGame));
        Attacks = AddRepositoryCollection<AttacksRepositoryCollection>(new AttacksRepositoryCollection(SaveGame));
        AttackEffects = AddRepositoryCollection<AttackEffectsRepositoryCollection>(new AttackEffectsRepositoryCollection(SaveGame));
        SpellResistantDetections = AddRepositoryCollection<SpellResistantDetectionsRepositoryCollection>(new SpellResistantDetectionsRepositoryCollection(SaveGame));
        RoomLayouts = AddRepositoryCollection<RoomLayoutsRepositoryCollection>(new RoomLayoutsRepositoryCollection(SaveGame));
        MonsterSpells = AddRepositoryCollection<MonsterSpellsRepositoryCollection>(new MonsterSpellsRepositoryCollection(SaveGame));
        Talents = AddRepositoryCollection<TalentsRepositoryCollection>(new TalentsRepositoryCollection(SaveGame));
        AlterActions = AddRepositoryCollection<AlterActionsRepositoryCollection>(new AlterActionsRepositoryCollection(SaveGame));
        Symbols = AddRepositoryCollection<SymbolsRepositoryCollection>(new SymbolsRepositoryCollection(SaveGame));
        MartialArtsAttacks = AddRepositoryCollection<MartialArtsAttacksRepositoryCollection>(new MartialArtsAttacksRepositoryCollection(SaveGame));
        Scripts = AddRepositoryCollection<ScriptsRepositoryCollection>(new ScriptsRepositoryCollection(SaveGame));
        Dungeons = AddRepositoryCollection<DungeonsRepositoryCollection>(new DungeonsRepositoryCollection(SaveGame));
        Genders = AddRepositoryCollection<GendersRepositoryCollection>(new GendersRepositoryCollection(SaveGame));
        BirthStages = AddRepositoryCollection<BirthStagesRepositoryCollection>(new BirthStagesRepositoryCollection(SaveGame));
        Projectiles = AddRepositoryCollection<ProjectilesRepositoryCollection>(new ProjectilesRepositoryCollection(SaveGame));
        Patrons = AddRepositoryCollection<PatronsRepositoryCollection>(new PatronsRepositoryCollection(SaveGame));
        Animations = AddRepositoryCollection<AnimationsRepositoryCollection>(new AnimationsRepositoryCollection(SaveGame));
        FixedArtifacts = AddRepositoryCollection<FixedArtifactsRepositoryCollection>(new FixedArtifactsRepositoryCollection(SaveGame));
        GameCommands = AddRepositoryCollection<GameCommandsRepositoryCollection>(new GameCommandsRepositoryCollection(SaveGame));
        ArtifactBiases = AddRepositoryCollection<ArtifactBiasesRepositoryCollection>(new ArtifactBiasesRepositoryCollection(SaveGame));
        InventorySlots = AddRepositoryCollection<InventorySlotsRepositoryCollection>(new InventorySlotsRepositoryCollection(SaveGame));
        MonsterRaces = AddRepositoryCollection<MonsterRacesRepositoryCollection>(new MonsterRacesRepositoryCollection(SaveGame));
        ProjectileGraphics = AddRepositoryCollection<ProjectileGraphicsRepositoryCollection>(new ProjectileGraphicsRepositoryCollection(SaveGame));
        Activations = AddRepositoryCollection<ActivationsRepositoryCollection>(new ActivationsRepositoryCollection(SaveGame));
        Races = AddRepositoryCollection<RacesRepositoryCollection>(new RacesRepositoryCollection(SaveGame));
        StoreCommands = AddRepositoryCollection<StoreCommandsRepositoryCollection>(new StoreCommandsRepositoryCollection(SaveGame));
        Vaults = AddRepositoryCollection<VaultsRepositoryCollection>(new VaultsRepositoryCollection(SaveGame));
        WizardCommands = AddRepositoryCollection<WizardCommandsRepositoryCollection>(new WizardCommandsRepositoryCollection(SaveGame));
        TimedActions = AddRepositoryCollection<TimedActionsRepositoryCollection>(new TimedActionsRepositoryCollection(SaveGame));
        CharacterClasses = AddRepositoryCollection<CharacterClassesRepositoryCollection>(new CharacterClassesRepositoryCollection(SaveGame));
        Realms = AddRepositoryCollection<RealmsRepositoryCollection>(new RealmsRepositoryCollection(SaveGame));
        AmuletFlavours = AddRepositoryCollection<AmuletFlavoursRepositoryCollection>(new AmuletFlavoursRepositoryCollection(SaveGame));
        MushroomFlavours = AddRepositoryCollection<MushroomFlavoursRepositoryCollection>(new MushroomFlavoursRepositoryCollection(SaveGame));
        PotionFlavours = AddRepositoryCollection<PotionFlavoursRepositoryCollection>(new PotionFlavoursRepositoryCollection(SaveGame));
        RingFlavours = AddRepositoryCollection<RingFlavoursRepositoryCollection>(new RingFlavoursRepositoryCollection(SaveGame));
        RodFlavours = AddRepositoryCollection<RodFlavoursRepositoryCollection>(new RodFlavoursRepositoryCollection(SaveGame));
        ScrollFlavours = AddRepositoryCollection<ScrollFlavoursRepositoryCollection>(new ScrollFlavoursRepositoryCollection(SaveGame));
        StaffFlavours = AddRepositoryCollection<StaffFlavoursRepositoryCollection>(new StaffFlavoursRepositoryCollection(SaveGame));
        WandFlavours = AddRepositoryCollection<WandFlavoursRepositoryCollection>(new WandFlavoursRepositoryCollection(SaveGame));
        ChestTrapConfigurations = AddRepositoryCollection<ChestTrapConfigurationsRepositoryCollection>(new ChestTrapConfigurationsRepositoryCollection(SaveGame));
        HelpGroups = AddRepositoryCollection<HelpGroupsRepositoryCollection>(new HelpGroupsRepositoryCollection(SaveGame));
        StoreOwners = AddRepositoryCollection<StoreOwnersRepositoryCollection>(new StoreOwnersRepositoryCollection(SaveGame));
        Spells = AddRepositoryCollection<SpellsRepositoryCollection>(new SpellsRepositoryCollection(SaveGame));
        CastingTypes = AddRepositoryCollection<CastingTypesRepositoryCollection>(new CastingTypesRepositoryCollection(SaveGame));
        Rewards = AddRepositoryCollection<RewardsRepositoryCollection>(new RewardsRepositoryCollection(SaveGame));
        Tiles = AddRepositoryCollection<TilesRepositoryCollection>(new TilesRepositoryCollection(SaveGame));
        RareItems = AddRepositoryCollection<RareItemsRepositoryCollection>(new RareItemsRepositoryCollection(SaveGame));
        ClassSpells = AddRepositoryCollection<ClassSpellsRepositoryCollection>(new ClassSpellsRepositoryCollection(SaveGame));
        ShopKeeperGoodComments = AddRepositoryCollection<ShopKeeperGoodCommentsRepositoryCollection>(new ShopKeeperGoodCommentsRepositoryCollection(SaveGame));
        ShopKeeperBargainComments = AddRepositoryCollection<ShopKeeperBargainCommentsRepositoryCollection>(new ShopKeeperBargainCommentsRepositoryCollection(SaveGame));
        ElvishText = AddRepositoryCollection<ElvishTextRepositoryCollection>(new ElvishTextRepositoryCollection(SaveGame));
        FunnyDescriptions = AddRepositoryCollection<FunnyDescriptionsRepositoryCollection>(new FunnyDescriptionsRepositoryCollection(SaveGame));
        FunnyComments = AddRepositoryCollection<FunnyCommentsRepositoryCollection>(new FunnyCommentsRepositoryCollection(SaveGame));
        HorrificDescriptions = AddRepositoryCollection<HorrificDescriptionsRepositoryCollection>(new HorrificDescriptionsRepositoryCollection(SaveGame));
        InsultPlayerAttacks = AddRepositoryCollection<InsultPlayerAttacksRepositoryCollection>(new InsultPlayerAttacksRepositoryCollection(SaveGame));
        MoanPlayerAttacks = AddRepositoryCollection<MoanPlayerAttacksRepositoryCollection>(new MoanPlayerAttacksRepositoryCollection(SaveGame));
        ShopKeeperLessThanGuessComments = AddRepositoryCollection<ShopKeeperLessThanGuessCommentsRepositoryCollection>(new ShopKeeperLessThanGuessCommentsRepositoryCollection(SaveGame));
        ShopKeeperWorthlessComments = AddRepositoryCollection<ShopKeeperWorthlessCommentsRepositoryCollection>(new ShopKeeperWorthlessCommentsRepositoryCollection(SaveGame));
        SingingPlayerAttacks = AddRepositoryCollection<SingingPlayerAttacksRepositoryCollection>(new SingingPlayerAttacksRepositoryCollection(SaveGame));
        StoreOwnerAcceptedComments = AddRepositoryCollection<StoreOwnerAcceptedCommentsRepositoryCollection>(new StoreOwnerAcceptedCommentsRepositoryCollection(SaveGame));
        WorshipPlayerAttacks = AddRepositoryCollection<WorshipPlayerAttacksRepositoryCollection>(new WorshipPlayerAttacksRepositoryCollection(SaveGame));
        FindQuests = AddRepositoryCollection<FindQuestsRepositoryCollection>(new FindQuestsRepositoryCollection(SaveGame));

        // Load all of the objects into each repository.  This is where the assembly will be scanned or the database will be read.
        LoadRepositoryItems();
        LoadedRepositoryItems();
    }

    /// <summary>
    /// Persist the entities to the core persistent storage medium.  This method is only being used to generate database entities from objects.
    /// </summary>
    /// <param name="corePersistentStorage"></param>
    public void Persist<T>(ICorePersistentStorage corePersistentStorage, RepositoryCollection<T> repository, string name) where T : IToJson
    {
        // Check to see if there is a name.  If not, then the persist isn't enabled for this repository.
        if (name != null)
        {
            List<string> jsonEntityList = new();
            foreach (T item in repository)
            {
                string serializedEntity = item.ToJson();
                if (serializedEntity == null)
                {
                    throw new Exception("Entity did not serialize.");
                }
                jsonEntityList.Add(serializedEntity);
            }
            corePersistentStorage.PersistEntities(name, jsonEntityList.ToArray());
        }
    }
    public void Persist(ICorePersistentStorage corePersistentStorage)
    {
        Persist<StoreOwner>(corePersistentStorage, StoreOwners, "StoreOwner");
        Persist<Town>(corePersistentStorage, Towns, "Town");
    }
}
