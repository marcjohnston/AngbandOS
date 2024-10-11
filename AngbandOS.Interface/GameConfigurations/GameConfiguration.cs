using System.Text.Json;

namespace AngbandOS.Core.Interface;

/// <summary>
/// Represents an interface that describes the configuration data that the GameServer.Play method accepts.  This configuration data is used to completely
/// configure a new game.  Use the ConfigurationMetadata object to get metadata details that can be used to generate configuration data.
/// </summary>
[Serializable]
public class GameConfiguration //: IGameConfiguration
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

    public StoreFactoryGameConfiguration[]? StoreFactories { get; set; } = null;

    public ProjectileGraphicGameConfiguration[]? ProjectileGraphics { get; set; } = null;

    public ReadableFlavorGameConfiguration[]? AmuletReadableFlavors { get; set; } = null;

    public ReadableFlavorGameConfiguration[]? MushroomReadableFlavors { get; set; } = null;

    public ReadableFlavorGameConfiguration[]? PotionReadableFlavors { get; set; } = null;

    public ReadableFlavorGameConfiguration[]? RingReadableFlavors { get; set; } = null;

    public ReadableFlavorGameConfiguration[]? RodReadableFlavors { get; set; } = null;

    public ReadableFlavorGameConfiguration[]? ScrollReadableFlavors { get; set; } = null;

    public ReadableFlavorGameConfiguration[]? StaffReadableFlavors { get; set; } = null;

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

    //   public bool IsValid() => true;

    public static PropertyMetadata[] Metadata
    {
        get
        {
            const string CollectionsCategoryTitle = "Collections";
            const string StringCollectionsCategoryTitle = "String Collections";
            const string SettingsCategoryTitle = "";

            return new PropertyMetadata[]
            {
                new IntegerPropertyMetadata("MaxMessageLogLength")
                {
                    Description = "This value controls how many previous messages are saved.  Additional previous messages are automatically deleted.  If this value is not specified, an unlimited number of previous messages will be retained.  A default value of 2048 previous messages is recommended.",
                    CategoryTitle = SettingsCategoryTitle,
                    Title = "Previous Message Length",
                    IsNullable = true,
                    DefaultValue = 2048
                },
                new StringPropertyMetadata("StartupTownName")
                {
                    Description = "The name of the town that the player starts in.",
                    CategoryTitle = SettingsCategoryTitle,
                    Title = "Startup Town Name",
                    IsNullable = true
                },
                new IntegerPropertyMetadata("MaxMessageLogLength")
                {
                    Description = "This value controls how many previous messages are saved.  Additional previous messages are automatically deleted.  If this value is not specified, an unlimited number of previous messages will be retained.  A default value of 2048 previous messages is recommended.",
                    CategoryTitle = SettingsCategoryTitle,
                    Title = "Previous Message Length",
                    IsNullable = true,
                    DefaultValue = 2048
                },
                new StringPropertyMetadata("StartupTownName")
                {
                    Description = "The name of the town that the player starts in.",
                    CategoryTitle = SettingsCategoryTitle,
                    Title = "Startup Town Name",
                    IsNullable = true
                },
                new IntegerPropertyMetadata("MaxMessageLogLength")
                {
                    Description = "This value controls how many previous messages are saved.  Additional previous messages are automatically deleted.  If this value is not specified, an unlimited number of previous messages will be retained.  A default value of 2048 previous messages is recommended.",
                    CategoryTitle = SettingsCategoryTitle,
                    Title = "Previous Message Length",
                    IsNullable = true,
                    DefaultValue = 2048
                },
                new StringPropertyMetadata("StartupTownName")
                {
                    Description = "The name of the town that the player starts in.",
                    CategoryTitle = SettingsCategoryTitle,
                    Title = "Startup Town Name",
                    IsNullable = true
                },
                new CollectionPropertyMetadata("StoreFactories")
                {
                    Description = "Towns have various plots where buildings and/or stores may be placed.  Stores factories are used to create specific stores.  Store factories can produce more than one store per town.  Use this collection to define factories that are used to create stores.",
                    Title = "Store Factories",
                    CategoryTitle = CollectionsCategoryTitle,
                    PropertiesMetadata = new PropertyMetadata[]
                    {
                        new TuplePropertyMetadata("StoreStockManifestDefinitions")
                        {
                            Description = "Returns the number of items the store should delete during maintenance.  Applies only when MaintainsStockLevels returns true.  Returns 9, by default.",
                            IsArray = true,
                            Types = new PropertyMetadata[]
                            {
                                new ForeignKeyPropertyMetadata("ItemFactoryName", "ItemFactories")
                                {
                                    IsNullable = true
                                },
                                new IntegerPropertyMetadata("Weight")
                                {
                                    IsNullable = true
                                }
                            }
                        },
                        new BooleanPropertyMetadata("IsEmptyLot")
                        {
                            DefaultValue = false,
                            Description = "Returns true, if the store is an empty lot; false, if it is a store.  Empty lots render as either grave yards or fields.",
                        },
                        new BooleanPropertyMetadata("StoreEntranceDoorsAreBlownOff")
                        {
                            DefaultValue = false,
                            Description = "Returns true, if the entrances to the stores are are randomly placed.",
                        },
                        new BooleanPropertyMetadata("BuildingsMadeFromPermanentRock")
                        {
                            DefaultValue = true,
                            Description = "Returns true, if the store (non-empty lot) is built from permanent rock.  Abandoned stores are created from inner walls and removeable rubble.",
                        },
                        new IntegerPropertyMetadata("PageSize")
                        {
                            DefaultValue = 26,
                            Description = "Returns the number of items in a page for the store.",
                        },
                        new StringPropertyMetadata("AdvertisedStoreCommand1Name")
                        {
                            IsNullable = false
                        }
                    }
                },
                new CollectionPropertyMetadata("Towns")
                {
                    CategoryTitle = CollectionsCategoryTitle,
                },
                new CollectionPropertyMetadata("Shopkeepers")
                {
                    CategoryTitle = CollectionsCategoryTitle,
                },
                new CollectionPropertyMetadata("GameCommands")
                {
                    CategoryTitle = CollectionsCategoryTitle,
                },
                new CollectionPropertyMetadata("StoreCommands")
                {
                    CategoryTitle = CollectionsCategoryTitle,
                },
                new CollectionPropertyMetadata("HelpGroups")
                {
                    CategoryTitle = CollectionsCategoryTitle,
                },
                new CollectionPropertyMetadata("MonsterRaces")
                {
                    CategoryTitle = CollectionsCategoryTitle,
                },
                new CollectionPropertyMetadata("Symbols")
                {
                    CategoryTitle = CollectionsCategoryTitle,
                },
                new CollectionPropertyMetadata("Vaults")
                {
                    CategoryTitle = CollectionsCategoryTitle,
                },
                new CollectionPropertyMetadata("DungeonGuardians")
                {
                    CategoryTitle = CollectionsCategoryTitle,
                },
                new CollectionPropertyMetadata("Dungeons")
                {
                    CategoryTitle = CollectionsCategoryTitle,
                },
                new CollectionPropertyMetadata("ProjectileGraphics")
                {
                    CategoryTitle = CollectionsCategoryTitle,
                },
                new CollectionPropertyMetadata("AmuletReadableFlavors")
                {
                    CategoryTitle = CollectionsCategoryTitle,
                },
                new CollectionPropertyMetadata("StaffReadableFlavors")
                {
                    CategoryTitle = CollectionsCategoryTitle,
                },
                new CollectionPropertyMetadata("MushroomReadableFlavors")
                {
                    CategoryTitle = CollectionsCategoryTitle,
                },
                new CollectionPropertyMetadata("PotionReadableFlavors")
                {
                    CategoryTitle = CollectionsCategoryTitle,
                },
                new CollectionPropertyMetadata("RingReadableFlavors")
                {
                    CategoryTitle = CollectionsCategoryTitle,
                },
                new CollectionPropertyMetadata("RodReadableFlavors")
                {
                    CategoryTitle = CollectionsCategoryTitle,
                },
                new CollectionPropertyMetadata("ScrollReadableFlavors")
                {
                    CategoryTitle = CollectionsCategoryTitle,
                },
                new CollectionPropertyMetadata("WandReadableFlavors")
                {
                    CategoryTitle = CollectionsCategoryTitle,
                },
                new CollectionPropertyMetadata("ClassSpells")
                {
                    CategoryTitle = CollectionsCategoryTitle,
                },
                new CollectionPropertyMetadata("WizardCommands")
                {
                    CategoryTitle = CollectionsCategoryTitle,
                },
                new CollectionPropertyMetadata("Animations")
                {
                    CategoryTitle = CollectionsCategoryTitle,
                },
                new CollectionPropertyMetadata("Plurals")
                {
                    CategoryTitle = CollectionsCategoryTitle,
                },
                new CollectionPropertyMetadata("Attacks")
                {
                    CategoryTitle = CollectionsCategoryTitle,
                },
                new CollectionPropertyMetadata("Gods")
                {
                    CategoryTitle = CollectionsCategoryTitle,
                },
                new StringPropertyMetadata("ElvishTexts")
                {
                    IsArray = true,
                    IsNullable = false,
                    CategoryTitle = StringCollectionsCategoryTitle,
                },
                new StringPropertyMetadata("FindQuests")
                {
                    IsArray = true,
                    IsNullable = false,
                    CategoryTitle = StringCollectionsCategoryTitle,
                },
                new StringPropertyMetadata("FunnyComments")
                {
                    IsArray = true,
                    IsNullable = false,
                    CategoryTitle = StringCollectionsCategoryTitle,
                },
                new StringPropertyMetadata("FunnyDescriptions")
                {
                    IsArray = true,
                    IsNullable = false,
                    CategoryTitle = StringCollectionsCategoryTitle,
                },
                new StringPropertyMetadata("HorrificDescriptions")
                {
                    IsArray = true,
                    IsNullable = false,
                    CategoryTitle = StringCollectionsCategoryTitle,
                },
                new StringPropertyMetadata("InsultPlayerAttacks")
                {
                    IsArray = true,
                    IsNullable = false,
                    CategoryTitle = StringCollectionsCategoryTitle,
                },
                new StringPropertyMetadata("MoanPlayerAttacks")
                {
                    IsArray = true,
                    IsNullable = false,
                    CategoryTitle = StringCollectionsCategoryTitle,
                },
                new StringPropertyMetadata("UnreadableFlavorSyllables")
                {
                    IsArray = true,
                    IsNullable = false,
                    CategoryTitle = StringCollectionsCategoryTitle,
                },
                new StringPropertyMetadata("ShopkeeperAcceptedComments")
                {
                    IsArray = true,
                    IsNullable = false,
                    CategoryTitle = StringCollectionsCategoryTitle,
                },
                new StringPropertyMetadata("ShopkeeperBargainComments")
                {
                    IsArray = true,
                    IsNullable = false,
                    CategoryTitle = StringCollectionsCategoryTitle,
                },
                new StringPropertyMetadata("ShopkeeperGoodComments")
                {
                    IsArray = true,
                    IsNullable = false,
                    CategoryTitle = StringCollectionsCategoryTitle,
                },
                new StringPropertyMetadata("ShopkeeperLessThanGuessComments")
                {
                    IsArray = true,
                    IsNullable = false,
                    CategoryTitle = StringCollectionsCategoryTitle,
                },
                new StringPropertyMetadata("ShopkeeperWorthlessComments")
                {
                    IsArray = true,
                    IsNullable = false,
                    CategoryTitle = StringCollectionsCategoryTitle,
                },
                new StringPropertyMetadata("SingingPlayerAttacks")
                {
                    IsArray = true,
                    IsNullable = false,
                    CategoryTitle = StringCollectionsCategoryTitle,
                },
                new StringPropertyMetadata("WorshipPlayerAttacks")
                {
                    IsArray = true,
                    IsNullable = false,
                    CategoryTitle = StringCollectionsCategoryTitle,
                }
            };
        }
    }
    private static TConfiguration[] RetrieveEntities<TConfiguration>(ICorePersistentStorage persistentStorage, string repositoryName) //where TConfiguration : IGameConfiguration
    {
        string[] serializedEntities = persistentStorage.RetrieveEntities(repositoryName);
        List<TConfiguration> entities = new List<TConfiguration>();
        foreach (string serializedEntity in serializedEntities)
        {
            TConfiguration? deserializedEntity = JsonSerializer.Deserialize<TConfiguration>(serializedEntity, new JsonSerializerOptions() { IncludeFields = true });
            //if (deserializedEntity == null || !deserializedEntity.IsValid())
            //{
            //    throw new Exception($"Invalid {repositoryName} json.");
            //}
            entities.Add(deserializedEntity);
        }
        return entities.ToArray();
    }

    /// <summary>
    /// Returns an array of strings that represents the string list repository entities; or null, if the file doesn't exist.
    /// </summary>
    /// <param name="persistentStorage"></param>
    /// <param name="repositoryName"></param>
    /// <returns></returns>
    private static string[]? RetrieveEntity(ICorePersistentStorage persistentStorage, string repositoryName)
    {
        string? serializedEntity = persistentStorage.RetrieveEntity(repositoryName);
        if (serializedEntity == null)
        {
            return null;
        }

        string[]? values = JsonSerializer.Deserialize<string[]>(serializedEntity);
        return values;
    }

    public static GameConfiguration LoadConfiguration(ICorePersistentStorage persistentStorage)
    {
        return new GameConfiguration()
        {
            AmuletReadableFlavors = RetrieveEntities<ReadableFlavorGameConfiguration>(persistentStorage, "AmuletReadableFlavors"),
            Animations = RetrieveEntities<AnimationGameConfiguration>(persistentStorage, "Animations"),
            Attacks = RetrieveEntities<AttackGameConfiguration>(persistentStorage, "Attacks"),
            ClassSpells = RetrieveEntities<ClassSpellGameConfiguration>(persistentStorage, "ClassSpells"),
            DungeonGuardians = RetrieveEntities<DungeonGuardianGameConfiguration>(persistentStorage, "DungeonGuardians"),
            Dungeons = RetrieveEntities<DungeonGameConfiguration>(persistentStorage, "Dungeons"),
            GameCommands = RetrieveEntities<GameCommandGameConfiguration>(persistentStorage, "GameCommands"),
            Gods = RetrieveEntities<GodGameConfiguration>(persistentStorage, "Gods"),
            HelpGroups = RetrieveEntities<HelpGroupGameConfiguration>(persistentStorage, "HelpGroups"),
            MonsterRaces = RetrieveEntities<MonsterRaceGameConfiguration>(persistentStorage, "MonsterRaces"),
            MushroomReadableFlavors = RetrieveEntities<ReadableFlavorGameConfiguration>(persistentStorage, "MushroomReadableFlavors"),
            Plurals = RetrieveEntities<PluralGameConfiguration>(persistentStorage, "Plurals"),
            PotionReadableFlavors = RetrieveEntities<ReadableFlavorGameConfiguration>(persistentStorage, "PotionReadableFlavors"),
            ProjectileGraphics = RetrieveEntities<ProjectileGraphicGameConfiguration>(persistentStorage, "ProjectileGraphics"),
            RingReadableFlavors = RetrieveEntities<ReadableFlavorGameConfiguration>(persistentStorage, "RingReadableFlavors"),
            RodReadableFlavors = RetrieveEntities<ReadableFlavorGameConfiguration>(persistentStorage, "RodReadableFlavors"),
            ScrollReadableFlavors = RetrieveEntities<ReadableFlavorGameConfiguration>(persistentStorage, "ScrollReadableFlavors"),
            Shopkeepers = RetrieveEntities<ShopkeeperGameConfiguration>(persistentStorage, "Shopkeepers"),
            Spells = RetrieveEntities<SpellGameConfiguration>(persistentStorage, "Spells"),
            StaffReadableFlavors = RetrieveEntities<ReadableFlavorGameConfiguration>(persistentStorage, "StaffReadableFlavors"),
            StoreCommands = RetrieveEntities<StoreCommandGameConfiguration>(persistentStorage, "StoreCommands"),
            StoreFactories = RetrieveEntities<StoreFactoryGameConfiguration>(persistentStorage, "StoreFactories"),
            Symbols = RetrieveEntities<SymbolGameConfiguration>(persistentStorage, "Symbols"),
            //Tiles = RetrieveEntities<TileConfiguration>(persistentStorage, "Tiles"), // TODO: This is not working with generic
            Towns = RetrieveEntities<TownGameConfiguration>(persistentStorage, "Towns"),
            Vaults = RetrieveEntities<VaultGameConfiguration>(persistentStorage, "Vaults"),
            WandReadableFlavors = RetrieveEntities<ReadableFlavorGameConfiguration>(persistentStorage, "WandReadableFlavors"),
            WizardCommands = RetrieveEntities<WizardCommandGameConfiguration>(persistentStorage, "WizardCommands"),

            ElvishTexts = RetrieveEntity(persistentStorage, "ElvishTexts"),
            FindQuests = RetrieveEntity(persistentStorage, "FindQuests"),
            FunnyComments = RetrieveEntity(persistentStorage, "FunnyComments"),
            FunnyDescriptions = RetrieveEntity(persistentStorage, "FunnyDescriptions"),
            HorrificDescriptions = RetrieveEntity(persistentStorage, "HorrificDescriptions"),
            InsultPlayerAttacks = RetrieveEntity(persistentStorage, "InsultPlayerAttacks"),
            MoanPlayerAttacks = RetrieveEntity(persistentStorage, "MoanPlayerAttacks"),
            UnreadableFlavorSyllables = RetrieveEntity(persistentStorage, "UnreadableFlavorSyllables"),
            ShopkeeperAcceptedComments = RetrieveEntity(persistentStorage, "ShopkeeperAcceptedComments"),
            ShopkeeperBargainComments = RetrieveEntity(persistentStorage, "ShopkeeperBargainComments"),
            ShopkeeperGoodComments = RetrieveEntity(persistentStorage, "ShopkeeperGoodComments"),
            ShopkeeperLessThanGuessComments = RetrieveEntity(persistentStorage, "ShopkeeperLessThanGuessComments"),
            ShopkeeperWorthlessComments = RetrieveEntity(persistentStorage, "ShopkeeperWorthlessComments"),
            SingingPlayerAttacks = RetrieveEntity(persistentStorage, "SingingPlayerAttacks"),
            WorshipPlayerAttacks = RetrieveEntity(persistentStorage, "WorshipPlayerAttacks")
        };
    }
}