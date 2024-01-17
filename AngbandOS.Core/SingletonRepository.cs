// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using System.Text.Json.Serialization;

namespace AngbandOS.Core;

[Serializable]
/// <summary>
/// Represents a repository for all game singletons.
/// </summary>
internal class SingletonRepository
{
    private readonly SaveGame SaveGame;

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

    /// <summary>
    /// Performs the load phase of the singleton repository.  This phase reads all of the types from the assembly and adds it into its respective
    /// collection--if the ExcludeFromRepository property returns false.  If the ExcludeFromRepository is true, the singleton object will be discarded.
    /// </summary>
    /// <param name="saveGame"></param>
    public void Load()
    {
        // Create all of the repositories.  All of the repositories will be empty and have an instance to the save game.
        FlaggedActions = new FlaggedActionsRepositoryCollection(SaveGame);
        Towns = new TownsRepositoryCollection(SaveGame);
        ItemFactories = new ItemFactoriesRepositoryCollection(SaveGame);
        Stores = new StoresRepositoryCollection(SaveGame);
        ItemClasses = new ItemClassesRepositoryCollection(SaveGame);
        Mutations = new MutationsRepositoryCollection(SaveGame);
        ChestTraps = new ChestTrapsRepositoryCollection(SaveGame);
        Attacks = new AttacksRepositoryCollection(SaveGame);
        AttackEffects = new AttackEffectsRepositoryCollection(SaveGame);
        SpellResistantDetections = new SpellResistantDetectionsRepositoryCollection(SaveGame);
        RoomLayouts = new RoomLayoutsRepositoryCollection(SaveGame);
        MonsterSpells = new MonsterSpellsRepositoryCollection(SaveGame);
        Talents = new TalentsRepositoryCollection(SaveGame);
        AlterActions = new AlterActionsRepositoryCollection(SaveGame);
        Symbols = new SymbolsRepositoryCollection(SaveGame);
        MartialArtsAttacks = new MartialArtsAttacksRepositoryCollection(SaveGame);
        Scripts = new ScriptsRepositoryCollection(SaveGame);
        Dungeons = new DungeonsRepositoryCollection(SaveGame);
        Genders = new GendersRepositoryCollection(SaveGame);
        BirthStages = new BirthStagesRepositoryCollection(SaveGame);
        Projectiles = new ProjectilesRepositoryCollection(SaveGame);
        Patrons = new PatronsRepositoryCollection(SaveGame);
        Animations = new AnimationsRepositoryCollection(SaveGame);
        FixedArtifacts = new FixedArtifactsRepositoryCollection(SaveGame);
        GameCommands = new GameCommandsRepositoryCollection(SaveGame);
        ArtifactBiases = new ArtifactBiasesRepositoryCollection(SaveGame);
        InventorySlots = new InventorySlotsRepositoryCollection(SaveGame);
        MonsterRaces = new MonsterRacesRepositoryCollection(SaveGame);
        ProjectileGraphics = new ProjectileGraphicsRepositoryCollection(SaveGame);
        Activations = new ActivationsRepositoryCollection(SaveGame);
        Races = new RacesRepositoryCollection(SaveGame);
        StoreCommands = new StoreCommandsRepositoryCollection(SaveGame);
        Vaults = new VaultsRepositoryCollection(SaveGame);
        WizardCommands = new WizardCommandsRepositoryCollection(SaveGame);
        TimedActions = new TimedActionsRepositoryCollection(SaveGame);
        CharacterClasses = new CharacterClassesRepositoryCollection(SaveGame);
        Realms = new RealmsRepositoryCollection(SaveGame);
        AmuletFlavours = new AmuletFlavoursRepositoryCollection(SaveGame);
        MushroomFlavours = new MushroomFlavoursRepositoryCollection(SaveGame);
        PotionFlavours = new PotionFlavoursRepositoryCollection(SaveGame);
        RingFlavours = new RingFlavoursRepositoryCollection(SaveGame);
        RodFlavours = new RodFlavoursRepositoryCollection(SaveGame);
        ScrollFlavours = new ScrollFlavoursRepositoryCollection(SaveGame);
        StaffFlavours = new StaffFlavoursRepositoryCollection(SaveGame);
        WandFlavours = new WandFlavoursRepositoryCollection(SaveGame);
        ChestTrapConfigurations = new ChestTrapConfigurationsRepositoryCollection(SaveGame);
        HelpGroups = new HelpGroupsRepositoryCollection(SaveGame);
        StoreOwners = new StoreOwnersRepositoryCollection(SaveGame);
        Spells = new SpellsRepositoryCollection(SaveGame);
        CastingTypes = new CastingTypesRepositoryCollection(SaveGame);
        Rewards = new RewardsRepositoryCollection(SaveGame);

        Tiles = new TilesRepositoryCollection(SaveGame);
        RareItems = new RareItemsRepositoryCollection(SaveGame);

        ClassSpells = new ClassSpellsRepositoryCollection(SaveGame);
        ShopKeeperGoodComments = new ShopKeeperGoodCommentsRepositoryCollection(SaveGame);
        ShopKeeperBargainComments = new ShopKeeperBargainCommentsRepositoryCollection(SaveGame);
        ElvishText = new ElvishTextRepositoryCollection(SaveGame);
        FunnyDescriptions = new FunnyDescriptionsRepositoryCollection(SaveGame);
        FunnyComments = new FunnyCommentsRepositoryCollection(SaveGame);
        HorrificDescriptions = new HorrificDescriptionsRepositoryCollection(SaveGame);
        InsultPlayerAttacks = new InsultPlayerAttacksRepositoryCollection(SaveGame);
        MoanPlayerAttacks = new MoanPlayerAttacksRepositoryCollection(SaveGame);
        ShopKeeperLessThanGuessComments = new ShopKeeperLessThanGuessCommentsRepositoryCollection(SaveGame);
        ShopKeeperWorthlessComments = new ShopKeeperWorthlessCommentsRepositoryCollection(SaveGame);
        SingingPlayerAttacks = new SingingPlayerAttacksRepositoryCollection(SaveGame);
        StoreOwnerAcceptedComments = new StoreOwnerAcceptedCommentsRepositoryCollection(SaveGame);
        WorshipPlayerAttacks = new WorshipPlayerAttacksRepositoryCollection(SaveGame);
        FindQuests = new FindQuestsRepositoryCollection(SaveGame);

        // Load all of the objects into each repository.  This is where the assembly will be scanned or the database will be read.
        FlaggedActions.Load();
        Towns.Load();
        ItemFactories.Load();
        Stores.Load();
        ItemClasses.Load();
        Mutations.Load();
        ChestTraps.Load();
        Attacks.Load();
        AttackEffects.Load();
        SpellResistantDetections.Load();
        RoomLayouts.Load();
        MonsterSpells.Load();
        Talents.Load();
        AlterActions.Load();
        Symbols.Load();
        MartialArtsAttacks.Load();
        Scripts.Load();
        Dungeons.Load();
        Genders.Load();
        BirthStages.Load();
        Projectiles.Load();
        Patrons.Load();
        Animations.Load();
        FixedArtifacts.Load();
        GameCommands.Load();
        ArtifactBiases.Load();
        InventorySlots.Load();
        MonsterRaces.Load();
        ProjectileGraphics.Load();
        Activations.Load();
        Races.Load();
        StoreCommands.Load();
        Vaults.Load();
        WizardCommands.Load();
        TimedActions.Load();
        CharacterClasses.Load();
        Realms.Load();
        AmuletFlavours.Load();
        MushroomFlavours.Load();
        PotionFlavours.Load();
        RingFlavours.Load();
        RodFlavours.Load();
        ScrollFlavours.Load();
        StaffFlavours.Load();
        WandFlavours.Load();
        ChestTrapConfigurations.Load();
        HelpGroups.Load();
        StoreOwners.Load();
        Spells.Load();
        CastingTypes.Load();
        Rewards.Load();

        Tiles.Load();
        RareItems.Load();

        ClassSpells.Load();
        ShopKeeperGoodComments.Load();
        ShopKeeperBargainComments.Load();
        ElvishText.Load();
        FunnyDescriptions.Load();
        FunnyComments.Load();
        HorrificDescriptions.Load();
        InsultPlayerAttacks.Load();
        MoanPlayerAttacks.Load();
        ShopKeeperLessThanGuessComments.Load();
        ShopKeeperWorthlessComments.Load();
        SingingPlayerAttacks.Load();
        StoreOwnerAcceptedComments.Load();
        WorshipPlayerAttacks.Load();
        FindQuests.Load();

        // Allow objects that refer to other objects to be processed.  Now that all of the repository items exist, references will succeed.
        FlaggedActions.Loaded();
        Towns.Loaded();
        ItemFactories.Loaded();
        Stores.Loaded();
        ItemClasses.Loaded();
        Mutations.Loaded();
        ChestTraps.Loaded();
        Attacks.Loaded();
        AttackEffects.Loaded();
        SpellResistantDetections.Loaded();
        RoomLayouts.Loaded();
        MonsterSpells.Loaded();
        Talents.Loaded();
        AlterActions.Loaded();
        Symbols.Loaded();
        MartialArtsAttacks.Loaded();
        Scripts.Loaded();
        Dungeons.Loaded();
        Genders.Loaded();
        BirthStages.Loaded();
        Projectiles.Loaded();
        Patrons.Loaded();
        Animations.Loaded();
        FixedArtifacts.Loaded();
        GameCommands.Loaded();
        ArtifactBiases.Loaded();
        InventorySlots.Loaded();
        MonsterRaces.Loaded();
        ProjectileGraphics.Loaded();
        Activations.Loaded();
        Races.Loaded();
        StoreCommands.Loaded();
        Vaults.Loaded();
        WizardCommands.Loaded();
        TimedActions.Loaded();
        CharacterClasses.Loaded();
        Realms.Loaded();
        AmuletFlavours.Loaded();
        MushroomFlavours.Loaded();
        PotionFlavours.Loaded();
        RingFlavours.Loaded();
        RodFlavours.Loaded();
        ScrollFlavours.Loaded();
        StaffFlavours.Loaded();
        WandFlavours.Loaded();
        ChestTrapConfigurations.Loaded();
        HelpGroups.Loaded();
        StoreOwners.Loaded();
        Spells.Loaded();
        CastingTypes.Loaded();
        Rewards.Loaded();

        Tiles.Loaded();
        RareItems.Loaded();

        ClassSpells.Loaded();
        ShopKeeperGoodComments.Loaded();
        ShopKeeperBargainComments.Loaded();
        ElvishText.Loaded();
        FunnyDescriptions.Loaded();
        FunnyComments.Loaded();
        HorrificDescriptions.Loaded();
        InsultPlayerAttacks.Loaded();
        MoanPlayerAttacks.Loaded();
        ShopKeeperLessThanGuessComments.Loaded();
        ShopKeeperWorthlessComments.Loaded();
        SingingPlayerAttacks.Loaded();
        StoreOwnerAcceptedComments.Loaded();
        WorshipPlayerAttacks.Loaded();
        FindQuests.Loaded();
    }

    public void Persist(ICorePersistentStorage corePersistentStorage)
    {
        StoreOwners.Persist(corePersistentStorage);
    }
}
