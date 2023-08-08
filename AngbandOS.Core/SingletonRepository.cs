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

    /// <summary>
    /// Performs the load phase of the singleton repository.  This phase reads all of the types from the assembly and adds it into its respective
    /// collection--if the ExcludeFromRepository property returns false.  If the ExcludeFromRepository is true, the singleton object will be discarded.
    /// </summary>
    /// <param name="saveGame"></param>
    public void Load(SaveGame saveGame)
    {
        FlaggedActions = new FlaggedActionsRepositoryCollection(saveGame);
        Towns = new TownsRepositoryCollection(saveGame);
        ItemFactories = new ItemFactoriesRepositoryCollection(saveGame);
        Stores = new StoresRepositoryCollection(saveGame);
        ItemClasses = new ItemClassesRepositoryCollection(saveGame);
        Mutations = new MutationsRepositoryCollection(saveGame);
        ChestTraps = new ChestTrapsRepositoryCollection(saveGame);
        Attacks = new AttacksRepositoryCollection(saveGame);
        AttackEffects = new AttackEffectsRepositoryCollection(saveGame);
        SpellResistantDetections = new SpellResistantDetectionsRepositoryCollection(saveGame);
        RoomLayouts = new RoomLayoutsRepositoryCollection(saveGame);
        MonsterSpells = new MonsterSpellsRepositoryCollection(saveGame);
        Talents = new TalentsRepositoryCollection(saveGame);
        AlterActions = new AlterActionsRepositoryCollection(saveGame);
        Symbols = new SymbolsRepositoryCollection(saveGame);
        MartialArtsAttacks = new MartialArtsAttacksRepositoryCollection(saveGame);
        Scripts = new ScriptsRepositoryCollection(saveGame);
        Dungeons = new DungeonsRepositoryCollection(saveGame);
        Genders = new GendersRepositoryCollection(saveGame);
        BirthStages = new BirthStagesRepositoryCollection(saveGame);
        Projectiles = new ProjectilesRepositoryCollection(saveGame);
        Patrons = new PatronsRepositoryCollection(saveGame);
        Animations = new AnimationsRepositoryCollection(saveGame);
        FixedArtifacts = new FixedArtifactsRepositoryCollection(saveGame);
        GameCommands = new GameCommandsRepositoryCollection(saveGame);
        ArtifactBiases = new ArtifactBiasesRepositoryCollection(saveGame);
        InventorySlots = new InventorySlotsRepositoryCollection(saveGame);
        MonsterRaces = new MonsterRacesRepositoryCollection(saveGame);
        ProjectileGraphics = new ProjectileGraphicsRepositoryCollection(saveGame);
        Activations = new ActivationsRepositoryCollection(saveGame);
        Races = new RacesRepositoryCollection(saveGame);
        StoreCommands = new StoreCommandsRepositoryCollection(saveGame);
        Vaults = new VaultsRepositoryCollection(saveGame);
        WizardCommands = new WizardCommandsRepositoryCollection(saveGame);
        TimedActions = new TimedActionsRepositoryCollection(saveGame);
        CharacterClasses = new CharacterClassesRepositoryCollection(saveGame);
        Realms = new RealmsRepositoryCollection(saveGame);
        AmuletFlavours = new AmuletFlavoursRepositoryCollection(saveGame);
        MushroomFlavours = new MushroomFlavoursRepositoryCollection(saveGame);
        PotionFlavours = new PotionFlavoursRepositoryCollection(saveGame);
        RingFlavours = new RingFlavoursRepositoryCollection(saveGame);
        RodFlavours = new RodFlavoursRepositoryCollection(saveGame);
        ScrollFlavours = new ScrollFlavoursRepositoryCollection(saveGame);
        StaffFlavours = new StaffFlavoursRepositoryCollection(saveGame);
        WandFlavours = new WandFlavoursRepositoryCollection(saveGame);
        ChestTrapConfigurations = new ChestTrapConfigurationsRepositoryCollection(saveGame);
        HelpGroups = new HelpGroupsRepositoryCollection(saveGame);
        StoreOwners = new StoreOwnersRepositoryCollection(saveGame);
        Spells = new SpellsRepositoryCollection(saveGame);
        CastingTypes = new CastingTypesRepositoryCollection(saveGame);
        Rewards = new RewardsRepositoryCollection(saveGame);

        Tiles = new TilesRepositoryCollection(saveGame);
        RareItems = new RareItemsRepositoryCollection(saveGame);

        ClassSpells = new ClassSpellsRepositoryCollection(saveGame);
        ShopKeeperGoodComments = new ShopKeeperGoodCommentsRepositoryCollection(saveGame);
        ShopKeeperBargainComments = new ShopKeeperBargainCommentsRepositoryCollection(saveGame);
        ElvishText = new ElvishTextRepositoryCollection(saveGame);
        FunnyDescriptions = new FunnyDescriptionsRepositoryCollection(saveGame);
        FunnyComments = new FunnyCommentsRepositoryCollection(saveGame);
        HorrificDescriptions = new HorrificDescriptionsRepositoryCollection(saveGame);
        InsultPlayerAttacks = new InsultPlayerAttacksRepositoryCollection(saveGame);
        MoanPlayerAttacks = new MoanPlayerAttacksRepositoryCollection(saveGame);
        ShopKeeperLessThanGuessComments = new ShopKeeperLessThanGuessCommentsRepositoryCollection(saveGame);
        ShopKeeperWorthlessComments = new ShopKeeperWorthlessCommentsRepositoryCollection(saveGame);
        SingingPlayerAttacks = new SingingPlayerAttacksRepositoryCollection(saveGame);
        StoreOwnerAcceptedComments = new StoreOwnerAcceptedCommentsRepositoryCollection(saveGame);
        WorshipPlayerAttacks = new WorshipPlayerAttacksRepositoryCollection(saveGame);
        FindQuests = new FindQuestsRepositoryCollection(saveGame);

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
}
