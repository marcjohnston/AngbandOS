// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class StoreFactory : IItemFilter, IGetKey
{
    protected readonly Game Game;
    public StoreFactory(Game game, StoreFactoryGameConfiguration storeFactoryGameConfiguration)
    {
        Game = game;
        IsEmptyLot = storeFactoryGameConfiguration.IsEmptyLot;
        BuildingsMadeFromPermanentRock = storeFactoryGameConfiguration.BuildingsMadeFromPermanentRock;
        StoreEntranceDoorsAreBlownOff = storeFactoryGameConfiguration.StoreEntranceDoorsAreBlownOff;
        Key = storeFactoryGameConfiguration.Key ?? storeFactoryGameConfiguration.GetType().Name;
        PageSize = storeFactoryGameConfiguration.PageSize;
        UseHomeCarry = storeFactoryGameConfiguration.UseHomeCarry;
        ItemFilterNames = storeFactoryGameConfiguration.ItemFilterNames;
        IsHomeThatCanBeBought = storeFactoryGameConfiguration.IsHomeThatCanBeBought;
        MaintainsStockLevels = storeFactoryGameConfiguration.MaintainsStockLevels;
        MaxInventory = storeFactoryGameConfiguration.MaxInventory;
        MinInventory = storeFactoryGameConfiguration.MinInventory;
        StoreTurnover = storeFactoryGameConfiguration.StoreTurnover;
        StoreStockManifestDefinitions = storeFactoryGameConfiguration.StoreStockManifestDefinitions?.Select(_storeStockManifestDefinition => (_storeStockManifestDefinition.ItemFactoryName, _storeStockManifestDefinition.Weight)).ToArray();
        ShufflesOwnersAndPricing = storeFactoryGameConfiguration.ShufflesOwnersAndPricing;
        ShopkeeperNames = storeFactoryGameConfiguration.ShopkeeperNames;
        AdvertisedStoreCommand1Name = storeFactoryGameConfiguration.AdvertisedStoreCommand1Name;
        AdvertisedStoreCommand2Name = storeFactoryGameConfiguration.AdvertisedStoreCommand2Name;
        AdvertisedStoreCommand3Name = storeFactoryGameConfiguration.AdvertisedStoreCommand3Name;
        AdvertisedStoreCommand4Name = storeFactoryGameConfiguration.AdvertisedStoreCommand4Name;
        AdvertisedStoreCommand5Name = storeFactoryGameConfiguration.AdvertisedStoreCommand5Name;
        WidthOfDescriptionColumn = storeFactoryGameConfiguration.WidthOfDescriptionColumn;
        RenderWeightUnitOfMeasurement = storeFactoryGameConfiguration.RenderWeightUnitOfMeasurement;
        TileName = storeFactoryGameConfiguration.TileName;
        ItemsRenderFlavorAware = storeFactoryGameConfiguration.ItemsRenderFlavorAware;
        OwnerName = storeFactoryGameConfiguration.OwnerName;
        Title = storeFactoryGameConfiguration.Title;
        StoreMaintainsInventory = storeFactoryGameConfiguration.StoreMaintainsInventory;
        ShowItemPricing = storeFactoryGameConfiguration.ShowItemPricing;
        MarkupRate = storeFactoryGameConfiguration.MarkupRate;
        MarkdownRate = storeFactoryGameConfiguration.MarkdownRate;
        PerformsMaintenanceWhenResting = storeFactoryGameConfiguration.PerformsMaintenanceWhenResting;
        LevelForRandomItemCreation = storeFactoryGameConfiguration.LevelForRandomItemCreation;
        MinimumItemValue = storeFactoryGameConfiguration.MinimumItemValue;
        NoStockMessage = storeFactoryGameConfiguration.NoStockMessage;
        PurchaseMessage = storeFactoryGameConfiguration.PurchaseMessage;
        StoreSellsItems = storeFactoryGameConfiguration.StoreSellsItems;
        BoughtMessageAsBoughtBack = storeFactoryGameConfiguration.BoughtMessageAsBoughtBack;
        SellPrompt = storeFactoryGameConfiguration.SellPrompt;
        StoreFullMessage = storeFactoryGameConfiguration.StoreFullMessage;
        StoreMaintainsInscription = storeFactoryGameConfiguration.StoreMaintainsInscription;
        StoreBuysItems = storeFactoryGameConfiguration.StoreBuysItems;
        BoughtVerb = storeFactoryGameConfiguration.BoughtVerb;
        StoreIdentifiesItems = storeFactoryGameConfiguration.StoreIdentifiesItems;
        StoreAnalyzesPurchases = storeFactoryGameConfiguration.StoreAnalyzesPurchases;
    }

    public string GetKey => Key;

    /// <summary>
    /// Returns the entity serialized into a Json string.
    /// </summary>
    /// <returns></returns>
    public string ToJson()
    {
        StoreFactoryGameConfiguration definition = new()
        {
            IsEmptyLot = IsEmptyLot,
            BuildingsMadeFromPermanentRock = BuildingsMadeFromPermanentRock,
            StoreEntranceDoorsAreBlownOff = StoreEntranceDoorsAreBlownOff,
            Key = Key,
            PageSize = PageSize,
            UseHomeCarry = UseHomeCarry,
            ItemFilterNames = ItemFilterNames,
            IsHomeThatCanBeBought = IsHomeThatCanBeBought,
            MaintainsStockLevels = MaintainsStockLevels,
            MaxInventory = MaxInventory,
            MinInventory = MinInventory,
            StoreTurnover = StoreTurnover,
            StoreStockManifestDefinitions = StoreStockManifestDefinitions,
            ShufflesOwnersAndPricing = ShufflesOwnersAndPricing,
            ShopkeeperNames = ShopkeeperNames,
            AdvertisedStoreCommand1Name = AdvertisedStoreCommand1Name,
            AdvertisedStoreCommand2Name = AdvertisedStoreCommand2Name,
            AdvertisedStoreCommand3Name = AdvertisedStoreCommand3Name,
            AdvertisedStoreCommand4Name = AdvertisedStoreCommand4Name,
            AdvertisedStoreCommand5Name = AdvertisedStoreCommand5Name,
            WidthOfDescriptionColumn = WidthOfDescriptionColumn,
            RenderWeightUnitOfMeasurement = RenderWeightUnitOfMeasurement,
            TileName = TileName,
            ItemsRenderFlavorAware = ItemsRenderFlavorAware,
            OwnerName = OwnerName,
            Title = Title,
            StoreMaintainsInventory = StoreMaintainsInventory,
            ShowItemPricing = ShowItemPricing,
            MarkupRate = MarkupRate,
            MarkdownRate = MarkdownRate,
            PerformsMaintenanceWhenResting = PerformsMaintenanceWhenResting,
            LevelForRandomItemCreation = LevelForRandomItemCreation,
            MinimumItemValue = MinimumItemValue,
            NoStockMessage = NoStockMessage,
            PurchaseMessage = PurchaseMessage,
            StoreSellsItems = StoreSellsItems,
            BoughtMessageAsBoughtBack = BoughtMessageAsBoughtBack,
            SellPrompt = SellPrompt,
            StoreFullMessage = StoreFullMessage,
            StoreMaintainsInscription = StoreMaintainsInscription,
            StoreBuysItems = StoreBuysItems,
            BoughtVerb = BoughtVerb,
            StoreIdentifiesItems = StoreIdentifiesItems,
            StoreAnalyzesPurchases = StoreAnalyzesPurchases
        };
        return JsonSerializer.Serialize(definition, Game.GetJsonSerializerOptions());
    }

    public void Bind()
    {
        // Bind the advertised commands.
        AdvertisedStoreCommand1 = AdvertisedStoreCommand1Name == null ? null : Game.SingletonRepository.Get<StoreCommand>(AdvertisedStoreCommand1Name);
        AdvertisedStoreCommand2 = AdvertisedStoreCommand2Name == null ? null : Game.SingletonRepository.Get<StoreCommand>(AdvertisedStoreCommand2Name);
        AdvertisedStoreCommand3 = AdvertisedStoreCommand3Name == null ? null : Game.SingletonRepository.Get<StoreCommand>(AdvertisedStoreCommand3Name);
        AdvertisedStoreCommand4 = AdvertisedStoreCommand4Name == null ? null : Game.SingletonRepository.Get<StoreCommand>(AdvertisedStoreCommand4Name);
        AdvertisedStoreCommand5 = AdvertisedStoreCommand5Name == null ? null : Game.SingletonRepository.Get<StoreCommand>(AdvertisedStoreCommand5Name);

        // Bind the store owners.
        Shopkeepers = Game.SingletonRepository.Get<Shopkeeper>(ShopkeeperNames);

        // Bind the symbol.
        Tile = Game.SingletonRepository.Get<Tile>(TileName);

        // Bind the item filters.
        List<ItemFilter> itemFilters = new();
        foreach (string itemFilterName in ItemFilterNames)
        {
            itemFilters.Add(Game.SingletonRepository.Get<ItemFilter>(itemFilterName));
        }
        ItemFilters = itemFilters.ToArray();

        // Bind the store stock manifests.
        List<(ItemFactory ItemFactory, int Weight)> storeStockManifestList = new();
        if (StoreStockManifestDefinitions != null) {
            foreach ((string ItemFactoryName, int Weight) storeStockManifestDefinition in StoreStockManifestDefinitions)
            {
                ItemFactory itemFactory = Game.SingletonRepository.Get<ItemFactory>(storeStockManifestDefinition.ItemFactoryName);
                storeStockManifestList.Add((itemFactory, storeStockManifestDefinition.Weight));
            }
        }
        StoreStockManifests = storeStockManifestList.ToArray();
    }

    /// <summary>
    /// Returns true, if the store is an empty lot; false, if it is a store.  Empty lots render as either grave yards or fields.
    /// </summary>
    public virtual bool IsEmptyLot { get; } = false;

    /// <summary>
    /// Returns true, if the store (non-empty lot) is built from permanent rock.  Abandoned stores are created from inner walls and removeable rubble.
    /// </summary>
    public virtual bool BuildingsMadeFromPermanentRock { get; } = true;

    /// <summary>
    /// Returns true, if the entrances to the stores are are randomly placed.
    /// </summary>
    public virtual bool StoreEntranceDoorsAreBlownOff { get; } = false;

    public virtual string Key { get; }

    /// <summary>
    /// Returns the number of items in a page for the store.
    /// </summary>
    public virtual int PageSize { get; } = 26;

    public virtual bool UseHomeCarry { get; } = false;

    /// <summary>
    /// Returns true, if the store will accept items from the player (e.g. sell or drop).  An item matches, if any ItemFilter matches the item.
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public bool Matches(Item item)
    {
        // Loop through all of the item filters.  If the filter matches, then the item matches.
        foreach (ItemFilter itemFilter in ItemFilters)
        {
            if (itemFilter.Matches(item))
            {
                return true;
            }
        }
        return false;
    }

    public ItemFilter[] ItemFilters { get; private set; }

    /// <summary>
    /// Returns the names of the item matching criterion used to determine which items the store buys.  Returns an empty arrary, by default, to
    /// indicate that the store does not buy any items.
    /// </summary>
    protected virtual string[] ItemFilterNames { get; } = new string[] { };

    /// <summary>
    /// Returns true, if the store is a home that can be bought; false, otherwise.  When true, the doors locked will return true, if the store/home 
    /// is in the correct town.  Returns false, by default.
    /// </summary>
    public virtual bool IsHomeThatCanBeBought { get; } = false;

    /// <summary>
    /// Returns true, if the doors to the store are locked; false, if the store is open.  Returns false, by default.
    /// </summary>
    /// <returns></returns>
    public bool DoorsLocked()
    {
        // If the store isn't a home, the doors are open.
        if (!IsHomeThatCanBeBought)
        {
            return false;
        }

        // If the player doesn't own a home, the doors are locked.
        if (Game.TownWithHouse == null)
        {
            return true;
        }

        // Make sure this town matches the town where the player bought the home.
        return Game.TownWithHouse != Game.CurTown;
    }

    /// <summary>
    /// Returns whether or not the store should perform maintenance.  When true, the store will automatically maintain stock levels based on the 
    /// MinKeep, MaxKeep and Turnover values.  Returns true, by default.
    /// </summary>
    public virtual bool MaintainsStockLevels { get; } = true;

    /// <summary>
    /// Returns the maximum number of items the store should maintain.  Returns one pagesize (26), by default.
    /// </summary>
    public virtual int MaxInventory { get; }

    /// <summary>
    /// Returns the minimum number of items the store should maintain.  Applies only when MaintainsStockLevels returns true.  Returns 6, by default.
    /// </summary>
    public virtual int MinInventory { get; } = 6;

    /// <summary>
    /// Returns the number of items the store should delete during maintenance.  Applies only when MaintainsStockLevels returns true.  Returns 9, by default.
    /// </summary>
    public virtual int StoreTurnover { get; } = 9;

    /// <summary>
    /// Returns an array of item types that the store carries; or null, if the store does not carry items for sale or if the factory overrides the
    /// CreateItem method.  Returns null by default.  When the Factory.CreateItem method returns null, this property should return a manifest for the
    /// store to create items from.  If the store doesn't sell items, the Factory.CreateItem should return null and this property should return null.
    /// </summary>
    /// <returns></returns>
    public (ItemFactory ItemFactory, int Weight)[]? StoreStockManifests { get; private set; } = null;

    protected virtual (string ItemFactoryName, int Weight)[]? StoreStockManifestDefinitions { get; } = null;

    /// <summary>
    /// Returns whether or not the store should occasionally change the owner and put items on sale.  When true, which is by default, the store will
    /// automatically perform this shuffling.
    /// </summary>
    public virtual bool ShufflesOwnersAndPricing { get; } = true;

    protected virtual string[] ShopkeeperNames { get; }

    /// <summary>
    /// Represents a pool of possible store owners for the store.
    /// </summary>
    public Shopkeeper[] Shopkeepers { get; private set; }

    protected virtual string? AdvertisedStoreCommand1Name { get; } = nameof(PurchaseStoreCommand);
    protected virtual string? AdvertisedStoreCommand2Name { get; } = nameof(SellStoreCommand);
    protected virtual string? AdvertisedStoreCommand3Name { get; } = nameof(ExamineStoreItemCommand);
    protected virtual string? AdvertisedStoreCommand4Name { get; } = null;
    protected virtual string? AdvertisedStoreCommand5Name { get; } = null;
    /// <summary>
    /// Returns the store command that should be advertised to the player @ position 42, 31; or null, if there is no command to render.
    /// </summary>
    /// <remarks>
    /// The command that is specified, shouldn't also be in the non-advertised commands list to keep the save file size down; although it 
    /// won't affect game play.
    /// </remarks>
    public StoreCommand? AdvertisedStoreCommand1 { get; private set; }

    /// <summary>
    /// Returns the store command that should be advertised to the player @ position 43, 31; or null, if there is no command to render.
    /// </summary>
    /// <remarks>
    /// The command that is specified, shouldn't also be in the non-advertised commands list to keep the save file size down; although it 
    /// won't affect game play.
    /// </remarks>
    public StoreCommand? AdvertisedStoreCommand2 { get; private set; }

    /// <summary>
    /// Returns the store command that should be advertised to the player @ position 42, 56; or null, if there is no command to render.
    /// </summary>
    /// <remarks>
    /// The command that is specified, shouldn't also be in the non-advertised commands list to keep the save file size down; although it 
    /// won't affect game play.
    /// </remarks>
    public StoreCommand? AdvertisedStoreCommand3 { get; private set; }

    /// <summary>
    /// Returns the store command that should be advertised to the player @ position 43, 56; or null, if there is no command to render.
    /// </summary>
    /// <remarks>
    /// The command that is specified, shouldn't also be in the non-advertised commands list to keep the save file size down; although it 
    /// won't affect game play.
    /// </remarks>
    public StoreCommand? AdvertisedStoreCommand4 { get; private set; }

    /// <summary>
    /// Returns the store command that should be advertised to the player @ position 43, 0; or null, if there is no command to render.
    /// </summary>
    /// <remarks>
    /// The command that is specified, shouldn't also be in the non-advertised commands list to keep the save file size down; although it 
    /// won't affect game play.
    /// </remarks>
    public StoreCommand? AdvertisedStoreCommand5 { get; private set; }

    /// <summary>
    /// Returns the width of the description column for rendering items in the store inventory.  The HomeStore defines a wider column for the description.
    /// </summary>
    public virtual int WidthOfDescriptionColumn { get; } = 58;

    /// <summary>
    /// Returns whether the weight column should render the lb. units of measurement.  The players home has sufficient space to render, but the other stores do not.
    /// </summary>
    public virtual bool RenderWeightUnitOfMeasurement { get; } = false;

    /// <summary>
    /// The tile to use for for the door.
    /// </summary>
    public Tile Tile { get; private set; }

    protected virtual string TileName { get; }

    /// <summary>
    /// Returns true, if the items should render as flavor aware; false, otherwise.  Stores will render their items as flavor aware.  Pawnshops and the home stores render items as
    /// they are seen in the dungeon.  Returns true, by default.  Pawnshops and the home store return false.
    /// </summary>
    public virtual bool ItemsRenderFlavorAware { get; } = true;

    /// <summary>
    /// Returns the name of the owner of the store; or null, if the store owner should reflect the store owner.
    /// </summary>
    public virtual string? OwnerName { get; } = null;

    /// <summary>
    /// Returns the title of the store; or null, if the store title should reflect the store owner.
    /// </summary>
    public virtual string? Title { get; } = null;

    /// <summary>
    /// Returns true, if the store maintains an inventory.  When false, the various buying, selling and inventory maintenace properties are ignored.
    /// Returns true, by default.  The Hall store returns false.
    /// </summary>
    public virtual bool StoreMaintainsInventory { get; } = true;

    /// <summary>
    /// Returns whether or not the store should show prices with items in the inventory.  Return true, by default.  The home does not show prices.
    /// </summary>
    public virtual bool ShowItemPricing { get; } = true;

    /// <summary>
    /// Returns the rate at which the store marks up items.  Returns 1, by default.
    /// </summary>
    public virtual int MarkupRate { get; } = 100;

    /// <summary>
    /// Returns the rate at which the store marks down items.  Returns 1, by default.
    /// </summary>
    public virtual int MarkdownRate { get; } = 100;

    public int MarkupItem(int price)
    {
        return price * MarkupRate / 100;
    }

    public int MarkdownItem(int price)
    {
        return price * MarkdownRate / 100;
    }

    public virtual bool PerformsMaintenanceWhenResting { get; } = true;

    /// <summary>
    /// Allows the store factory the option to create a random item using the value as the base level for the item; or null, if the store should 
    /// choose from the StoreStockManifests.  The black market store will override this method.
    /// </summary>
    /// <param name="store"></param>
    /// <returns></returns>
    public virtual int? LevelForRandomItemCreation { get; } = null;

    public virtual int MinimumItemValue { get; } = 0;

    public virtual string NoStockMessage { get; } = "I am currently out of stock.";
    public virtual string PurchaseMessage { get; } = "Which item are you interested in? ";

    /// <summary>
    /// Returns true, if the store sells items for gold to the player when the player retrieves items from the store.  Returns true, by default.
    /// The home does not sell items.
    /// </summary>
    public virtual bool StoreSellsItems { get; } = true;

    /// <summary>
    /// Returns true, if the store indicates that the player bought "back" the item.  False, otherwise.  Returns false, by default.  The pawnbroker
    /// store returns true.
    /// </summary>
    public virtual bool BoughtMessageAsBoughtBack { get; } = false;

    public virtual string SellPrompt { get; } = "Sell which item? ";
    public virtual string StoreFullMessage { get; } = "I have not the room in my Stores to keep it.";

    /// <summary>
    /// Returns true, if the store keeps inscriptions on items it acquires.  Only the players home does this.
    /// </summary>
    public virtual bool StoreMaintainsInscription { get; } = false;

    /// <summary>
    /// Returns true, if the store buys items for gold from the player.  Returns true, by default.  The home store doesn't buy items.
    /// </summary>
    public virtual bool StoreBuysItems { get; } = true;

    /// <summary>
    /// Returns the verb when the player sells or drops an item to the store.  Normally, "sold", but the home "drops" and the pawn shop "pawns".
    /// </summary>
    public virtual string BoughtVerb { get; } = "sold";

    /// <summary>
    /// Returns true, if the store identifies items when the player sells an item to the store.  Does not apply to stores that do not buy items.
    /// </summary>
    public virtual bool StoreIdentifiesItems { get; } = true;

    public virtual bool StoreAnalyzesPurchases { get; } = true;
}