using AngbandOS.Core.Interface.Definitions;

namespace AngbandOS.Core.Interface;

/// <summary>
/// Represents an interface that describes the configuration data that the GameServer.Play method accepts.  This configuration data is used to completely
/// configure a new game.  Use the ConfigurationMetadata object to get metadata details that can be used to generate configuration data.
/// </summary>
[Serializable]
public class Configuration
{
    ///// <summary>
    ///// Represents the names of the stores that are available in the game.  These store names can any preconfigured Angband store, or a store with a matching
    ///// name from the Stores Repo.
    ///// </summary>
    //public string[]? StoreNames { get; set; } = default!;
    //public StoreConfiguration[]? StoresRepo { get; set; } = default!;

    /// <summary>
    /// Returns the number of log items that the message history is allowed to store.  A null value indicates that there is no limit.  The default value is 2048.
    /// </summary>
    public int? MaxMessageLogLength { get; set; } = 2048;

    /// <summary>
    /// Returns the name of the town where the player will start, ignoring whether or not that town is a startup town; or null, for a random town to be choosen 
    /// from the available startup towns.
    /// </summary>
    public string? StartupTownName { get; set; } = null;

    /// <summary>
    /// Returns null, if Towns should be loaded from the assembly.  Otherwise, returns an array of Towns to be loaded into the SingletonRepository.
    /// </summary>
    public TownDefinition[]? Towns { get; set; } = null;

    public ShopkeeperDefinition[]? Shopkeepers { get; set; } = null;

    public GameCommandDefinition[]? GameCommands { get; set; } = null;
    public StoreCommandDefinition[]? StoreCommands { get; set; } = null;
    public HelpGroupDefinition[]? HelpGroups { get; set; } = null;
    public MonsterRaceDefinition[]? MonsterRaces { get; set; } = null;
    public SymbolDefinition[]? Symbols { get; set; } = null;
    public VaultDefinition[]? Vaults { get; set; } = null;
    public DungeonGuardianDefinition[]? DungeonGuardians { get; set; } = null;
    public DungeonDefinition[]? Dungeons { get; set; } = null;
    public StoreFactoryDefinition[]? StoreFactories { get; set; } = null;
    public ProjectileGraphicDefinition[]? ProjectileGraphics { get; set; } = null;
    public ReadableFlavorDefinition[]? AmuletReadableFlavors{ get; set; } = null;
    public ReadableFlavorDefinition[]? MushroomReadableFlavors { get; set; } = null;
    public ReadableFlavorDefinition[]? PotionReadableFlavors { get; set; } = null;
    public ReadableFlavorDefinition[]? RingReadableFlavors { get; set; } = null;
    public ReadableFlavorDefinition[]? RodReadableFlavors { get; set; } = null;
    public ReadableFlavorDefinition[]? ScrollReadableFlavors { get; set; } = null;
    public ReadableFlavorDefinition[]? StaffReadableFlavors { get; set; } = null;
    public ReadableFlavorDefinition[]? WandReadableFlavors { get; set; } = null;
    public ClassSpellDefinition[]? ClassSpells { get; set; } = null;
    public WizardCommandDefinition[]? WizardCommands { get; set; } = null;
    public TileDefinition[]? Tiles { get; set; } = null;
    public AnimationDefinition[]? Animations { get; set; } = null;
    public SpellDefinition[]? Spells { get; set; } = null;
    public PluralDefinition[]? Plurals { get; set; } = null;

    public string[]? ElvishTexts { get; set; } = null;
    public string[]? FindQuests { get; set; } = null;
    public string[]? FunnyComments { get; set; } = null;
    public string[]? FunnyDescriptions { get; set; } = null;
    public string[]? HorrificDescriptions { get; set; } = null;
    public string[]? InsultPlayerAttacks { get; set; } = null;
    public string[]? MoanPlayerAttacks { get; set; } = null;
    public string[]? UnreadableFlavorSyllables { get; set; } = null;
    public string[]? ShopkeeperAcceptedComments { get; set; } = null;
    public string[]? ShopkeeperBargainComments { get; set; } = null;
    public string[]? ShopkeeperGoodComments { get; set; } = null;
    public string[]? ShopkeeperLessThanGuessComments { get; set; } = null;
    public string[]? ShopkeeperWorthlessComments { get; set; } = null;
    public string[]? SingingPlayerAttacks { get; set; } = null;
    public string[]? WorshipPlayerAttacks { get; set; } = null;
}