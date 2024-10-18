namespace AngbandOS.Core.Interface;

/// <summary>
/// Represents an interface that describes the configuration data that the GameServer.Play method accepts.  This configuration data is used to completely
/// configure a new game.  Use the ConfigurationMetadata object to get metadata details that can be used to generate configuration data.
/// </summary>
[Serializable]
public class GameConfiguration
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
                new CollectionPropertyMetadata("StoreFactories")
                {
                    Description = "Towns have various plots where buildings and/or stores may be placed.  Stores factories are used to create specific stores.  Store factories can produce more than one store per town.  Use this collection to define factories that are used to create stores.",
                    Title = "Store Factories",
                    EntityTitle = "Store Factory",
                    CategoryTitle = CollectionsCategoryTitle,
                    PropertyMetadatas = new PropertyMetadata[]
                    {
                        new BooleanPropertyMetadata("IsEmptyLot")
                        {
                            DefaultValue = false,
                            Description = "Returns true, if the store is an empty lot; false, if it is a store.  Empty lots render as either grave yards or fields.",
                        },
                        new BooleanPropertyMetadata("BuildingsMadeFromPermanentRock")
                        {
                            DefaultValue = true,
                            Description = "Returns true, if the store (non-empty lot) is built from permanent rock.  Abandoned stores are created from inner walls and removeable rubble.",
                        },
                        new BooleanPropertyMetadata("StoreEntranceDoorsAreBlownOff")
                        {
                            DefaultValue = false,
                            Description = "Returns true, if the entrances to the stores are are randomly placed.",
                        },
                        new StringPropertyMetadata("Key")
                        {
                        },
                        new IntegerPropertyMetadata("PageSize")
                        {
                            DefaultValue = 26,
                            Description = "Returns the number of items in a page for the store.",
                        },
                        new BooleanPropertyMetadata("UseHomeCarry")
                        {
                            DefaultValue = false,
                        },
                        new ForeignKeyArrayPropertyMetadata("ItemFilterNames", "ItemFilters")
                        {
                            Description = "Returns the names of the item matching criterion used to determine which items the store buys.  Returns an empty arrary, by default, to indicate that the store does not buy any items."
                        },
                        new BooleanPropertyMetadata("IsHomeThatCanBeBought")
                        {
                            DefaultValue = false,
                            Description = "Returns true, if the store is a home that can be bought; false, otherwise.  When true, the doors locked will return true, if the store/home is in the correct town.  Returns false, by default.",
                        },
                        new BooleanPropertyMetadata("MaintainsStockLevels")
                        {
                            DefaultValue = true,
                            Description = "Returns whether or not the store should perform maintenance.  When true, the store will automatically maintain stock levels based on the MinKeep, MaxKeep and Turnover values.  Returns true, by default.",
                        },
                        new IntegerPropertyMetadata("MaxInventory")
                        {
                            DefaultValue = 26,
                            Description = "Returns the maximum number of items the store should maintain.  Returns one pagesize (26), by default.",
                        },
                        new IntegerPropertyMetadata("MinInventory")
                        {
                            DefaultValue = 6,
                            Description = "Returns the minimum number of items the store should maintain.  Applies only when MaintainsStockLevels returns true.  Returns 6, by default.",
                        },
                        new IntegerPropertyMetadata("StoreTurnover")
                        {
                            DefaultValue = 9,
                            Description = "Returns the number of items the store should delete during maintenance.  Applies only when MaintainsStockLevels returns true.  Returns 9, by default.",
                        },
                        new TupleArrayPropertyMetadata("StoreStockManifestDefinitions")
                        {
                            IsNullable = true,
                            Description = "Returns the number of items the store should delete during maintenance.  Applies only when MaintainsStockLevels returns true.  Returns 9, by default.",
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
                        new BooleanPropertyMetadata("ShufflesOwnersAndPricing")
                        {
                            DefaultValue = true,
                            Description = "Returns whether or not the store should occasionally change the owner and put items on sale.  When true, which is by default, the store will automatically perform this shuffling.",
                        },
                        new ForeignKeyArrayPropertyMetadata("ShopkeeperNames", "Shopkeepers")
                        {
                            Title = "Shopkeepers",
                            Description = "Returns the skopkeepers that can be owners of the store."
                        },
                        new ForeignKeyPropertyMetadata("AdvertisedStoreCommand1Name", "StoreCommands")
                        {
                            IsNullable = true,
                        },
                        new ForeignKeyPropertyMetadata("AdvertisedStoreCommand2Name", "StoreCommands")
                        {
                            IsNullable = true
                        },
                        new ForeignKeyPropertyMetadata("AdvertisedStoreCommand3Name", "StoreCommands")
                        {
                            IsNullable = true
                        },
                        new ForeignKeyPropertyMetadata("AdvertisedStoreCommand4Name", "StoreCommands")
                        {
                            IsNullable = true
                        },
                        new ForeignKeyPropertyMetadata("AdvertisedStoreCommand5Name", "StoreCommands")
                        {
                            IsNullable = true
                        },
                        new IntegerPropertyMetadata("WidthOfDescriptionColumn")
                        {
                            Description = "Returns the width of the description column for rendering items in the store inventory.  The HomeStore defines a wider column for the description.",
                            DefaultValue = 58,
                        },
                        new BooleanPropertyMetadata("RenderWeightUnitOfMeasurement")
                        {
                            DefaultValue = false,
                            Description = "Returns whether the weight column should render the lb. units of measurement.  The players home has sufficient space to render, but the other stores do not.",
                        },
                        new StringPropertyMetadata("TileName")
                        {
                        },
                        new BooleanPropertyMetadata("ItemsRenderFlavorAware")
                        {
                            DefaultValue = true,
                            Description = "Returns true, if the items should render as flavor aware; false, otherwise.  Stores will render their items as flavor aware.  The flavor awareness is factory related.  Stores override the factory value.  Pawnshops and the home stores render items as they are seen in the dungeon. Returns true, by default.  Pawnshops and the home store return false.",
                        },
                        new StringPropertyMetadata("OwnerName")
                        {
                            IsNullable = true,
                            DefaultValue = null,
                            Description = "Returns the name of the owner of the store; or null, if the store owner should reflect the store owner.",
                        },
                        new StringPropertyMetadata("Title")
                        {
                            IsNullable = true,
                            DefaultValue = null,
                            Description = "Returns the title of the store; or null, if the store title should reflect the store owner.",
                        },
                        new BooleanPropertyMetadata("StoreMaintainsInventory")
                        {
                            DefaultValue = true,
                            Description = "Returns true, if the store maintains an inventory.  When false, the various buying, selling and inventory maintenace properties are ignored.  Returns true, by default.  The Hall store returns false.",
                        },
                        new BooleanPropertyMetadata("ShowItemPricing")
                        {
                            DefaultValue = true,
                            Description = "Returns whether or not the store should show prices with items in the inventory.  Return true, by default.  The home does not show prices.",
                        },
                        new IntegerPropertyMetadata("MarkupRate")
                        {
                            Description = "Returns the rate at which the store marks up items.  Returns 1, by default.",
                            DefaultValue = 1,
                        },
                        new IntegerPropertyMetadata("MarkdownRate")
                        {
                            Description = "Returns the rate at which the store marks down items.  Returns 1, by default.",
                            DefaultValue = 1,
                        },
                        new BooleanPropertyMetadata("PerformsMaintenanceWhenResting")
                        {
                            DefaultValue = true,
                        },
                        new IntegerPropertyMetadata("LevelForRandomItemCreation")
                        {
                            IsNullable = true,
                            Description = "Allows the store factory the option to create a random item using the value as the base level for the item; or null, if the store should choose from the StoreStockManifests.  The black market store will override this method.",
                            //DefaultValue = null,
                        },
                        new IntegerPropertyMetadata("MinimumItemValue")
                        {
                            DefaultValue = 0,
                        },
                        new StringPropertyMetadata("NoStockMessage")
                        {
                            DefaultValue = "I am currently out of stock.",
                        },
                        new StringPropertyMetadata("PurchaseMessage")
                        {
                            DefaultValue = "Which item are you interested in? "
                        },
                        new BooleanPropertyMetadata("StoreSellsItems")
                        {
                            DefaultValue = true,
                            Description = "Returns true, if the store sells items for gold to the player when the player retrieves items from the store.  Returns true, by default.  The home does not sell items.",
                        },
                        new BooleanPropertyMetadata("BoughtMessageAsBoughtBack")
                        {
                            DefaultValue = false,
                            Description = "Returns true, if the store indicates that the player bought \"back\" the item.  False, otherwise.  Returns false, by default.  The pawnbroker store returns true.",
                        },
                        new StringPropertyMetadata("SellPrompt")
                        {
                            DefaultValue = "Sell which item? "
                        },
                        new StringPropertyMetadata("StoreFullMessage")
                        {
                            DefaultValue = "I have not the room in my Stores to keep it."
                        },
                        new BooleanPropertyMetadata("StoreMaintainsInscription")
                        {
                            DefaultValue = false,
                            Description = "Returns true, if the store keeps inscriptions on items it acquires.  Only the players home does this.",
                        },
                        new BooleanPropertyMetadata("StoreBuysItems")
                        {
                            DefaultValue = true,
                            Description = "Returns true, if the store buys items for gold from the player.  Returns true, by default.  The home store doesn't buy items.",
                        },
                        new StringPropertyMetadata("BoughtVerb")
                        {
                            Description = "Returns the verb when the player sells or drops an item to the store.  Normally, \"sold\", but the home \"drops\" and the pawn shop \"pawns\"",
                            DefaultValue = "sold"
                        },
                        new BooleanPropertyMetadata("StoreIdentifiesItems")
                        {
                            DefaultValue = true,
                            Description = "Returns true, if the store identifies items when the player sells an item to the store.  Does not apply to stores that do not buy items.",
                        },
                        new BooleanPropertyMetadata("StoreAnalyzesPurchases")
                        {
                            DefaultValue = true,
                        },
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
                new StringArrayPropertyMetadata("ElvishTexts")
                {
                    CategoryTitle = StringCollectionsCategoryTitle,
                },
                new StringArrayPropertyMetadata("FindQuests")
                {
                    IsNullable = false,
                    CategoryTitle = StringCollectionsCategoryTitle,
                },
                new StringArrayPropertyMetadata("FunnyComments")
                {
                    IsNullable = false,
                    CategoryTitle = StringCollectionsCategoryTitle,
                },
                new StringArrayPropertyMetadata("FunnyDescriptions")
                {
                    IsNullable = false,
                    CategoryTitle = StringCollectionsCategoryTitle,
                },
                new StringArrayPropertyMetadata("HorrificDescriptions")
                {
                    IsNullable = false,
                    CategoryTitle = StringCollectionsCategoryTitle,
                },
                new StringArrayPropertyMetadata("InsultPlayerAttacks")
                {
                    IsNullable = false,
                    CategoryTitle = StringCollectionsCategoryTitle,
                },
                new StringArrayPropertyMetadata("MoanPlayerAttacks")
                {
                    IsNullable = false,
                    CategoryTitle = StringCollectionsCategoryTitle,
                },
                new StringArrayPropertyMetadata("UnreadableFlavorSyllables")
                {
                    IsNullable = false,
                    CategoryTitle = StringCollectionsCategoryTitle,
                },
                new StringArrayPropertyMetadata("ShopkeeperAcceptedComments")
                {
                    IsNullable = false,
                    CategoryTitle = StringCollectionsCategoryTitle,
                },
                new StringArrayPropertyMetadata("ShopkeeperBargainComments")
                {
                    IsNullable = false,
                    CategoryTitle = StringCollectionsCategoryTitle,
                },
                new StringArrayPropertyMetadata("ShopkeeperGoodComments")
                {
                    IsNullable = false,
                    CategoryTitle = StringCollectionsCategoryTitle,
                },
                new StringArrayPropertyMetadata("ShopkeeperLessThanGuessComments")
                {
                    IsNullable = false,
                    CategoryTitle = StringCollectionsCategoryTitle,
                },
                new StringArrayPropertyMetadata("ShopkeeperWorthlessComments")
                {
                    IsNullable = false,
                    CategoryTitle = StringCollectionsCategoryTitle,
                },
                new StringArrayPropertyMetadata("SingingPlayerAttacks")
                {
                    IsNullable = false,
                    CategoryTitle = StringCollectionsCategoryTitle,
                },
                new StringArrayPropertyMetadata("WorshipPlayerAttacks")
                {
                    IsNullable = false,
                    CategoryTitle = StringCollectionsCategoryTitle,
                }
            };
        }
    }
}