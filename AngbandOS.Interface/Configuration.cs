using AngbandOS.Core.Interface.Definitions;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AngbandOS.Core.Interface;

/// <summary>
/// Represents an interface that describes the configuration data that the GameServer.Play method accepts.  This configuration data is used to completely
/// configure a new game.  Use the ConfigurationMetadata object to get metadata details that can be used to generate configuration data.
/// </summary>
[Serializable]
public class Configuration
{
    // [Display(Name = "Last Name", Order = -9, Prompt = "Enter Last Name", Description = "Emp Last Name")]
    
    ///// <summary>
    ///// Represents the names of the stores that are available in the game.  These store names can any preconfigured Angband store, or a store with a matching
    ///// name from the Stores Repo.
    ///// </summary>
    //public string[]? StoreNames { get; set; } = default!;
    //public StoreConfiguration[]? StoresRepo { get; set; } = default!;

    /// <summary>
    /// Returns the number of log items that the message history is allowed to store.  A null value indicates that there is no limit.  The default value is 2048.
    /// </summary>    
    [Required]
    [DefaultValue(2048)]
    [DisplayName("Previous Message Length")]
    [Category("Settings")]
    [Description("This value controls how many previous messages are saved.  Additional previous messages are automatically deleted.  If this value is not specified, an unlimited number of previous messages will be retained.  A default value of 2048 previous messages is recommended.")]
    public int? MaxMessageLogLength { get; set; } = 2048;

    /// <summary>
    /// Returns the name of the town where the player will start, ignoring whether or not that town is a startup town; or null, for a random town to be choosen 
    /// from the available startup towns.
    /// </summary>
    public string? StartupTownName { get; set; } = null;

    /// <summary>
    /// Returns null, if Towns should be loaded from the assembly.  Otherwise, returns an array of Towns to be loaded into the SingletonRepository.
    /// </summary>
    [DisplayName("Towns")]
    public TownDefinition[]? Towns { get; set; } = null;

    [DisplayName("Shopkeepers")]
    public ShopkeeperDefinition[]? Shopkeepers { get; set; } = null;

    [DisplayName("Game Commands")]
    public GameCommandDefinition[]? GameCommands { get; set; } = null;

    [DisplayName("Store Commands")]
    public StoreCommandDefinition[]? StoreCommands { get; set; } = null;

    [DisplayName("Help Groups")]
    public HelpGroupDefinition[]? HelpGroups { get; set; } = null;

    [DisplayName("Monster Races")]
    public MonsterRaceDefinition[]? MonsterRaces { get; set; } = null;

    [DisplayName("Symbols")]
    public SymbolDefinition[]? Symbols { get; set; } = null;

    [DisplayName("Vaults")]
    public VaultDefinition[]? Vaults { get; set; } = null;

    [DisplayName("Dungeon Guardians")]
    public DungeonGuardianDefinition[]? DungeonGuardians { get; set; } = null;

    [DisplayName("Dungeons")]
    public DungeonDefinition[]? Dungeons { get; set; } = null;

    [DisplayName("Store Factories")]
    [Description("Towns have various plots where buildings and/or stores may be placed.  Stores factories are used to create specific stores.  Store factories can produce more than one store per town.  Use this collection to define factories that are used to create stores.")]
    public StoreFactoryDefinition[]? StoreFactories { get; set; } = null;

    [DisplayName("Projectile Graphics")]
    public ProjectileGraphicDefinition[]? ProjectileGraphics { get; set; } = null;

    [DisplayName("Amulet Readable Flavors")]
    public ReadableFlavorDefinition[]? AmuletReadableFlavors{ get; set; } = null;

    [DisplayName("Mushroom Readable Flavors")]
    public ReadableFlavorDefinition[]? MushroomReadableFlavors { get; set; } = null;

    [DisplayName("Potion Readable Flavors")]
    public ReadableFlavorDefinition[]? PotionReadableFlavors { get; set; } = null;

    [DisplayName("Ring Readable Flavors")]
    public ReadableFlavorDefinition[]? RingReadableFlavors { get; set; } = null;

    [DisplayName("Rod Readable Flavors")]
    public ReadableFlavorDefinition[]? RodReadableFlavors { get; set; } = null;

    [DisplayName("Scroll Readable Flavors")]
    public ReadableFlavorDefinition[]? ScrollReadableFlavors { get; set; } = null;

    [DisplayName("Staff Readable Flavors")]
    public ReadableFlavorDefinition[]? StaffReadableFlavors { get; set; } = null;

    [DisplayName("Wand Readable Flavors")]
    public ReadableFlavorDefinition[]? WandReadableFlavors { get; set; } = null;

    [DisplayName("Class Spells")]
    public ClassSpellDefinition[]? ClassSpells { get; set; } = null;

    [DisplayName("Wizard Commands")]
    public WizardCommandDefinition[]? WizardCommands { get; set; } = null;

    [DisplayName("Tiles")]
    public TileDefinition[]? Tiles { get; set; } = null;

    [DisplayName("Animations")]
    public AnimationDefinition[]? Animations { get; set; } = null;

    [DisplayName("Spells")]
    public SpellDefinition[]? Spells { get; set; } = null;

    [DisplayName("Plurals")]
    public PluralDefinition[]? Plurals { get; set; } = null;

    [DisplayName("Attacks")]
    public AttackDefinition[]? Attacks { get; set; } = null;

    [DisplayName("Gods")]
    public GodDefinition[]? Gods { get; set; } = null;

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