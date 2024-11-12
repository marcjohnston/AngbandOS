namespace AngbandOS.Core.Interface.Configuration;

/// <summary>
/// Represents an interface that describes the configuration data that the GameServer.Play method accepts.  This configuration data is used to completely
/// configure a new game.  Use the ConfigurationMetadata object to get metadata details that can be used to generate configuration data.
/// </summary>
[Serializable]
public class GameConfiguration
{
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
    public TownGameConfiguration[]? Towns { get; set; } = null;

    public ShopkeeperGameConfiguration[]? Shopkeepers { get; set; } = null;

    public GameCommandGameConfiguration[]? GameCommands { get; set; } = null;

    public StoreCommandGameConfiguration[]? StoreCommands { get; set; } = null;

    public HelpGroupGameConfiguration[]? HelpGroups { get; set; } = null;

    public MonsterRaceGameConfiguration[]? MonsterRaces { get; set; } = null;

    public SymbolGameConfiguration[]? Symbols { get; set; } = null;

    public VaultGameConfiguration[]? Vaults { get; set; } = null;

    public DungeonGuardianGameConfiguration[]? DungeonGuardians { get; set; } = null;

    public DungeonGameConfiguration[]? Dungeons { get; set; } = null;

    /// <summary>
    /// Towns have various plots where buildings and/or stores may be placed.  Stores factories are used to create specific stores.  Store factories can produce more than one store per town.  Use this collection to define factories that are used to create stores.
    /// </summary>
    public StoreFactoryGameConfiguration[]? StoreFactories { get; set; } = null;

    public ProjectileGraphicGameConfiguration[]? ProjectileGraphics { get; set; } = null;

    /// <entity-name>AmuletReadableFlavor</entity-name>
    public ReadableFlavorGameConfiguration[]? AmuletReadableFlavors { get; set; } = null;

    /// <entity-name>MushroomReadableFlavor</entity-name>
    public ReadableFlavorGameConfiguration[]? MushroomReadableFlavors { get; set; } = null;

    /// <entity-name>PotionReadableFlavor</entity-name>
    public ReadableFlavorGameConfiguration[]? PotionReadableFlavors { get; set; } = null;

    /// <entity-name>RingReadableFlavor</entity-name>
    public ReadableFlavorGameConfiguration[]? RingReadableFlavors { get; set; } = null;

    /// <entity-name>RodReadableFlavor</entity-name>
    public ReadableFlavorGameConfiguration[]? RodReadableFlavors { get; set; } = null;

    /// <entity-name>ScrollReadableFlavor</entity-name>
    public ReadableFlavorGameConfiguration[]? ScrollReadableFlavors { get; set; } = null;

    /// <entity-name>StaffReadableFlavor</entity-name>
    public ReadableFlavorGameConfiguration[]? StaffReadableFlavors { get; set; } = null;

    /// <entity-name>WandReadableFlavor</entity-name>
    public ReadableFlavorGameConfiguration[]? WandReadableFlavors { get; set; } = null;

    public ClassSpellGameConfiguration[]? ClassSpells { get; set; } = null;

    public WizardCommandGameConfiguration[]? WizardCommands { get; set; } = null;

    public TileGameConfiguration[]? Tiles { get; set; } = null;

    public AnimationGameConfiguration[]? Animations { get; set; } = null;

    public SpellGameConfiguration[]? Spells { get; set; } = null;

    public PluralGameConfiguration[]? Plurals { get; set; } = null;

    public AttackGameConfiguration[]? Attacks { get; set; } = null;

    public GodGameConfiguration[]? Gods { get; set; } = null;

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
