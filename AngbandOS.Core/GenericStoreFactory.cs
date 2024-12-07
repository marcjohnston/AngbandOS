// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core;

[Serializable]
internal class GenericStoreFactory : StoreFactory
{
    public GenericStoreFactory(Game game, StoreFactoryGameConfiguration storeFactoryDefinition) : base(game)
    {
        IsEmptyLot = storeFactoryDefinition.IsEmptyLot;
        BuildingsMadeFromPermanentRock = storeFactoryDefinition.BuildingsMadeFromPermanentRock;
        StoreEntranceDoorsAreBlownOff = storeFactoryDefinition.StoreEntranceDoorsAreBlownOff;
        Key = storeFactoryDefinition.Key;
        PageSize = storeFactoryDefinition.PageSize;
        UseHomeCarry = storeFactoryDefinition.UseHomeCarry;
        ItemFilterNames = storeFactoryDefinition.ItemFilterNames;
        IsHomeThatCanBeBought = storeFactoryDefinition.IsHomeThatCanBeBought;
        MaintainsStockLevels = storeFactoryDefinition.MaintainsStockLevels;
        MaxInventory = storeFactoryDefinition.MaxInventory;
        MinInventory = storeFactoryDefinition.MinInventory;
        StoreTurnover = storeFactoryDefinition.StoreTurnover;
        StoreStockManifestDefinitions = storeFactoryDefinition.StoreStockManifestDefinitions?.Select(_storeStockManifestDefinition => (_storeStockManifestDefinition.ItemFactoryName, _storeStockManifestDefinition.Weight)).ToArray();
        ShufflesOwnersAndPricing = storeFactoryDefinition.ShufflesOwnersAndPricing;
        ShopkeeperNames = storeFactoryDefinition.ShopkeeperNames;
        AdvertisedStoreCommand1Name = storeFactoryDefinition.AdvertisedStoreCommand1Name;
        AdvertisedStoreCommand2Name = storeFactoryDefinition.AdvertisedStoreCommand2Name;
        AdvertisedStoreCommand3Name = storeFactoryDefinition.AdvertisedStoreCommand3Name;
        AdvertisedStoreCommand4Name = storeFactoryDefinition.AdvertisedStoreCommand4Name;
        AdvertisedStoreCommand5Name = storeFactoryDefinition.AdvertisedStoreCommand5Name;
        WidthOfDescriptionColumn = storeFactoryDefinition.WidthOfDescriptionColumn;
        RenderWeightUnitOfMeasurement = storeFactoryDefinition.RenderWeightUnitOfMeasurement;
        TileName = storeFactoryDefinition.TileName;
        ItemsRenderFlavorAware = storeFactoryDefinition.ItemsRenderFlavorAware;
        OwnerName = storeFactoryDefinition.OwnerName;
        Title = storeFactoryDefinition.Title;
        StoreMaintainsInventory = storeFactoryDefinition.StoreMaintainsInventory;
        ShowItemPricing = storeFactoryDefinition.ShowItemPricing;
        MarkupRate = storeFactoryDefinition.MarkupRate;
        MarkdownRate = storeFactoryDefinition.MarkdownRate;
        PerformsMaintenanceWhenResting = storeFactoryDefinition.PerformsMaintenanceWhenResting;
        LevelForRandomItemCreation = storeFactoryDefinition.LevelForRandomItemCreation;
        MinimumItemValue = storeFactoryDefinition.MinimumItemValue;
        NoStockMessage = storeFactoryDefinition.NoStockMessage;
        PurchaseMessage = storeFactoryDefinition.PurchaseMessage;
        StoreSellsItems = storeFactoryDefinition.StoreSellsItems;
        BoughtMessageAsBoughtBack = storeFactoryDefinition.BoughtMessageAsBoughtBack;
        SellPrompt = storeFactoryDefinition.SellPrompt;
        StoreFullMessage = storeFactoryDefinition.StoreFullMessage;
        StoreMaintainsInscription = storeFactoryDefinition.StoreMaintainsInscription;
        StoreBuysItems = storeFactoryDefinition.StoreBuysItems;
        BoughtVerb = storeFactoryDefinition.BoughtVerb;
        StoreIdentifiesItems = storeFactoryDefinition.StoreIdentifiesItems;
        StoreAnalyzesPurchases = storeFactoryDefinition.StoreAnalyzesPurchases;
    }

    /// <summary>
    /// Returns true, if the store is an empty lot; false, if it is a store.  Empty lots render as either grave yards or fields.
    /// </summary>
    public override bool IsEmptyLot { get; }

    /// <summary>
    /// Returns true, if the store (non-empty lot) is built from permanent rock.  Abandoned stores are created from inner walls and removeable rubble.
    /// </summary>
    public override bool BuildingsMadeFromPermanentRock { get; }

    /// <summary>
    /// Returns true, if the entrances to the stores are are randomly placed.
    /// </summary>
    public override bool StoreEntranceDoorsAreBlownOff { get; } 

    public override string Key { get; }

    /// <summary>
    /// Returns the number of items in a page for the store.
    /// </summary>
    public override int PageSize { get; } 

    public override bool UseHomeCarry { get; } 

    /// <summary>
    /// Returns the names of the item matching criterion used to determine which items the store buys.  Returns an empty arrary, by default, to
    /// indicate that the store does not buy any items.
    /// </summary>
    protected override string[] ItemFilterNames { get; } 

    /// <summary>
    /// Returns true, if the store is a home that can be bought; false, otherwise.  When true, the doors locked will return true, if the store/home 
    /// is in the correct town.  Returns false, by default.
    /// </summary>
    public override bool IsHomeThatCanBeBought { get; } 

    /// <summary>
    /// Returns whether or not the store should perform maintenance.  When true, the store will automatically maintain stock levels based on the 
    /// MinKeep, MaxKeep and Turnover values.  Returns true, by default.
    /// </summary>
    public override  bool MaintainsStockLevels { get; }

    /// <summary>
    /// Returns the maximum number of items the store should maintain.  Returns one pagesize (26), by default.
    /// </summary>
    public override int MaxInventory { get; }

    /// <summary>
    /// Returns the minimum number of items the store should maintain.  Applies only when MaintainsStockLevels returns true.  Returns 6, by default.
    /// </summary>
    public override int MinInventory { get; } = 6;

    /// <summary>
    /// Returns the number of items the store should delete during maintenance.  Applies only when MaintainsStockLevels returns true.  Returns 9, by default.
    /// </summary>
    public override int StoreTurnover { get; } = 9;

    protected override (string ItemFactoryName, int Weight)[]? StoreStockManifestDefinitions { get; } 

    /// <summary>
    /// Returns whether or not the store should occasionally change the owner and put items on sale.  When true, which is by default, the store will
    /// automatically perform this shuffling.
    /// </summary>
    public override bool ShufflesOwnersAndPricing { get; } = true;

    protected override string[] ShopkeeperNames { get; }

    protected override string? AdvertisedStoreCommand1Name { get; }
    protected override string? AdvertisedStoreCommand2Name { get; }
    protected override string? AdvertisedStoreCommand3Name { get; }
    protected override string? AdvertisedStoreCommand4Name { get; }
    protected override string? AdvertisedStoreCommand5Name { get; }

    /// <summary>
    /// Returns the width of the description column for rendering items in the store inventory.  The HomeStore defines a wider column for the description.
    /// </summary>
    public override int WidthOfDescriptionColumn { get; } = 58;

    /// <summary>
    /// Returns whether the weight column should render the lb. units of measurement.  The players home has sufficient space to render, but the other stores do not.
    /// </summary>
    public override bool RenderWeightUnitOfMeasurement { get; }

    protected override string TileName { get; }

    /// <summary>
    /// Returns true, if the items should render as flavor aware; false, otherwise.  Stores will render their items as flavor aware.  The flavor
    /// awareness is factory related.  Stores override the factory value.  Pawnshops and the home stores render items as they are seen in the dungeon.
    /// Returns true, by default.  Pawnshops and the home store return false.
    /// </summary>
    public override bool ItemsRenderFlavorAware { get; }

    /// <summary>
    /// Returns the name of the owner of the store; or null, if the store owner should reflect the store owner.
    /// </summary>
    public override string? OwnerName { get; } 

    /// <summary>
    /// Returns the title of the store; or null, if the store title should reflect the store owner.
    /// </summary>
    public override string? Title { get; }

    /// <summary>
    /// Returns true, if the store maintains an inventory.  When false, the various buying, selling and inventory maintenace properties are ignored.
    /// Returns true, by default.  The Hall store returns false.
    /// </summary>
    public override bool StoreMaintainsInventory { get; }

    /// <summary>
    /// Returns whether or not the store should show prices with items in the inventory.  Return true, by default.  The home does not show prices.
    /// </summary>
    public override bool ShowItemPricing { get; } = true;

    /// <summary>
    /// Returns the rate at which the store marks up items.  Returns 1, by default.
    /// </summary>
    public override int MarkupRate { get; }

    /// <summary>
    /// Returns the rate at which the store down items.  Returns 1, by default.
    /// </summary>
    public override int MarkdownRate { get; } = 1;

    public override bool PerformsMaintenanceWhenResting { get; }

    /// <summary>
    /// Allows the store factory the option to create a random item using the value as the base level for the item; or null, if the store should 
    /// choose from the StoreStockManifests.  The black market store will override this method.
    /// </summary>
    /// <param name="store"></param>
    /// <returns></returns>
    public override int? LevelForRandomItemCreation { get; } 

    public override int MinimumItemValue { get; } = 0;

    public override string NoStockMessage { get; }
    public override string PurchaseMessage { get; } 

    /// <summary>
    /// Returns true, if the store sells items for gold to the player when the player retrieves items from the store.  Returns true, by default.
    /// The home does not sell items.
    /// </summary>
    public override bool StoreSellsItems { get; } = true;

    /// <summary>
    /// Returns true, if the store indicates that the player bought "back" the item.  False, otherwise.  Returns false, by default.  The pawnbroker
    /// store returns true.
    /// </summary>
    public override bool BoughtMessageAsBoughtBack { get; } = false;

    public override string SellPrompt { get; }

    public override string StoreFullMessage { get; }

    /// <summary>
    /// Returns true, if the store keeps inscriptions on items it acquires.  Only the players home does this.
    /// </summary>
    public override bool StoreMaintainsInscription { get; } 

    /// <summary>
    /// Returns true, if the store buys items for gold from the player.  Returns true, by default.  The home store doesn't buy items.
    /// </summary>
    public override bool StoreBuysItems { get; } 

    /// <summary>
    /// Returns the verb when the player sells or drops an item to the store.  Normally, "sold", but the home "drops" and the pawn shop "pawns".
    /// </summary>
    public override string BoughtVerb { get; } 

    /// <summary>
    /// Returns true, if the store identifies items when the player sells an item to the store.  Does not apply to stores that do not buy items.
    /// </summary>
    public override bool StoreIdentifiesItems { get; }

    public override bool StoreAnalyzesPurchases { get; }
}
