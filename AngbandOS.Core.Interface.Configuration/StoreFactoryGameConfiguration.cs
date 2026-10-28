// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.Core.Interface.Configuration.Annotations;

namespace AngbandOS.Core.Interface.Configuration;

[ConfigurationEntity(
    Title = "Store Factory",
    EntityNoun = "store factory")]
public class StoreFactoryGameConfiguration : NonCompositeSingletonGameConfiguration
{
    [ConfigurationMetadata(Title = "Is Empty Lot", Summary = "Determines whether the store is an empty lot.", DataType = "bool")]
    /// <summary>
    /// Returns true, if the store is an empty lot; false, if it is a store.  Empty lots render as either grave yards or fields.
    /// </summary>
    /// <title>
    /// Lot Is Empty?
    /// </title>
    /// <category>
    /// </category>
    public virtual bool IsEmptyLot { get; set; } = false;

    [ConfigurationMetadata(Title = "Buildings Made From Permanent Rock", Summary = "Determines whether store buildings are made from permanent rock.", DataType = "bool")]
    /// <summary>
    /// Returns true, if the store (non-empty lot) is built from permanent rock.  Abandoned stores are created from inner walls and removeable rubble.
    /// </summary>
    public virtual bool BuildingsMadeFromPermanentRock { get; set; } = true;

    [ConfigurationMetadata(Title = "Store Entrance Doors Are Blown Off", Summary = "Determines whether store entrance doors are randomly placed.", DataType = "bool")]
    /// <summary>
    /// Returns true, if the entrances to the stores are are randomly placed.
    /// </summary>
    public virtual bool StoreEntranceDoorsAreBlownOff { get; set; } = false;

    [ConfigurationMetadata(Title = "Page Size", Summary = "Specifies the number of items displayed on one store page.", DataType = "int")]
    /// <summary>
    /// Returns the number of items in a page for the store.
    /// </summary>
    public virtual int PageSize { get; set; } = 26;

    [ConfigurationMetadata(Title = "Use Home Carry", Summary = "Determines whether the store uses home carry behavior.", DataType = "bool")]
    public virtual bool UseHomeCarry { get; set; } = false;

    [ConfigurationMetadata(Title = "Item Filter Names", Summary = "Specifies the item filters used to determine which items the store buys.", DataType = "string[]")]
    /// <summary>
    /// Returns the names of the item matching criterion used to determine which items the store buys.  Returns an empty arrary, by default, to
    /// indicate that the store does not buy any items.
    /// </summary>
    public virtual string[] ItemFilterNames { get; set; } = new string[] { };

    [ConfigurationMetadata(Title = "Is Home That Can Be Bought", Summary = "Determines whether the store is a home that can be bought.", DataType = "bool")]
    /// <summary>
    /// Returns true, if the store is a home that can be bought; false, otherwise.  When true, the doors locked will return true, if the store/home 
    /// is in the correct town.  Returns false, by default.
    /// </summary>
    public virtual bool IsHomeThatCanBeBought { get; set; } = false;

    [ConfigurationMetadata(Title = "Maintains Stock Levels", Summary = "Determines whether the store automatically maintains its stock levels.", DataType = "bool")]
    /// <summary>
    /// Returns whether or not the store should perform maintenance.  When true, the store will automatically maintain stock levels based on the 
    /// MinKeep, MaxKeep and Turnover values.  Returns true, by default.
    /// </summary>
    public virtual bool MaintainsStockLevels { get; set; } = true;

    [ConfigurationMetadata(Title = "Maximum Inventory", Summary = "Specifies the maximum number of items maintained by the store.", DataType = "int")]
    /// <summary>
    /// Returns the maximum number of items the store should maintain.  Returns one pagesize (26), by default.
    /// </summary>
    public virtual int MaxInventory { get; set; } = 26; // TODO: This should default to the page size.

    [ConfigurationMetadata(Title = "Minimum Inventory", Summary = "Specifies the minimum number of items maintained by the store.", DataType = "int")]
    /// <summary>
    /// Returns the minimum number of items the store should maintain.  Applies only when MaintainsStockLevels returns true.  Returns 6, by default.
    /// </summary>
    public virtual int MinInventory { get; set; } = 6;

    [ConfigurationMetadata(Title = "Store Turnover", Summary = "Specifies the number of items removed during store maintenance.", DataType = "int")]
    /// <summary>
    /// Returns the number of items the store should delete during maintenance.  Applies only when MaintainsStockLevels returns true.  Returns 9, by default.
    /// </summary>
    public virtual int StoreTurnover { get; set; } = 9;

    [ConfigurationTupleItem("ItemFactoryName", Title = "Item Factory Name")]
    [ConfigurationTupleItem("Weight", Title = "Weight")]
    [ConfigurationMetadata(Title = "Store Stock Manifest Definitions", Summary = "Specifies the item factories and distribution weights used to stock the store.", DataType = "(string ItemFactoryName, int Weight)[]?")]
    /// <summary>
    /// Returns the manifests used to stock the store.  These manifests specify which item factories the store stocks and an assocated distribution weight for each item factory.
    /// </summary>
    /// <returns>
    /// ItemFactoryName:description: The name of the item factory.
    /// ItemFactoryName:foreign-collection-name: ItemFactories
    /// Weight:Description: The associated distribution weight for the item factory.
    /// </returns>
    public virtual (string ItemFactoryName, int Weight)[]? StoreStockManifestDefinitions { get; set; } = null;

    [ConfigurationMetadata(Title = "Shuffles Owners And Pricing", Summary = "Determines whether the store periodically changes its owner and pricing.", DataType = "bool")]
    /// <summary>
    /// Returns whether or not the store should occasionally change the owner and put items on sale.  When true, which is by default, the store will
    /// automatically perform this shuffling.
    /// </summary>
    public virtual bool ShufflesOwnersAndPricing { get; set; } = true;

    [ConfigurationMetadata(Title = "Shopkeeper Names", Summary = "Specifies the shopkeepers that can own the store.", DataType = "string[]")]
    /// <summary>
    /// Returns the skopkeepers that can be owners of the store.
    /// </summary>
    /// <foreign-collection-name>Shopkeepers</foreign-collection-name>
    public virtual string[] ShopkeeperNames { get; set; }

    [ConfigurationMetadata(Title = "Advertised Store Command 1 Name", Summary = "Specifies the first advertised store command name.", DataType = "string?")]
    public virtual string? AdvertisedStoreCommand1Name { get; set; } = null;

    [ConfigurationMetadata(Title = "Advertised Store Command 2 Name", Summary = "Specifies the second advertised store command name.", DataType = "string?")]
    public virtual string? AdvertisedStoreCommand2Name { get; set; } = null;

    [ConfigurationMetadata(Title = "Advertised Store Command 3 Name", Summary = "Specifies the third advertised store command name.", DataType = "string?")]
    public virtual string? AdvertisedStoreCommand3Name { get; set; } = null;

    [ConfigurationMetadata(Title = "Advertised Store Command 4 Name", Summary = "Specifies the fourth advertised store command name.", DataType = "string?")]
    public virtual string? AdvertisedStoreCommand4Name { get; set; } = null;

    [ConfigurationMetadata(Title = "Advertised Store Command 5 Name", Summary = "Specifies the fifth advertised store command name.", DataType = "string?")]
    public virtual string? AdvertisedStoreCommand5Name { get; set; } = null;

    [ConfigurationMetadata(Title = "Width Of Description Column", Summary = "Specifies the width of the item description column.", DataType = "int")]
    /// <summary>
    /// Returns the width of the description column for rendering items in the store inventory.  The HomeStore defines a wider column for the description.
    /// </summary>
    public virtual int WidthOfDescriptionColumn { get; set; } = 58;

    [ConfigurationMetadata(Title = "Render Weight Unit Of Measurement", Summary = "Determines whether weight units are rendered for items.", DataType = "bool")]
    /// <summary>
    /// Returns whether the weight column should render the lb. units of measurement.  The players home has sufficient space to render, but the other stores do not.
    /// </summary>
    public virtual bool RenderWeightUnitOfMeasurement { get; set; } = false;

    [ConfigurationMetadata(Title = "Tile Name", Summary = "Specifies the tile name used for the store.", DataType = "string")]
    public virtual string TileName { get; set; }

    [ConfigurationMetadata(Title = "Items Render Flavor Aware", Summary = "Determines whether items are rendered with flavor awareness.", DataType = "bool")]
    /// <summary>
    /// Returns true, if the items should render as flavor aware; false, otherwise.  Stores will render their items as flavor aware.  The flavor
    /// awareness is factory related.  Stores override the factory value.  Pawnshops and the home stores render items as they are seen in the dungeon.
    /// Returns true, by default.  Pawnshops and the home store return false.
    /// </summary>
    public virtual bool ItemsRenderFlavorAware { get; set; } = true;

    [ConfigurationMetadata(Title = "Owner Name", Summary = "Specifies the name of the store owner. When null, the owner is determined automatically.", DataType = "string?")]
    /// <summary>
    /// Returns the name of the owner of the store; or null, if the store owner should reflect the store owner.
    /// </summary>
    public virtual string? OwnerName { get; set; } = null;

    [ConfigurationMetadata(Title = "Title", Summary = "Specifies the title of the store. When null, the title is determined automatically.", DataType = "string?")]
    /// <summary>
    /// Returns the title of the store; or null, if the store title should reflect the store owner.
    /// </summary>
    public virtual string? Title { get; set; } = null;

    [ConfigurationMetadata(Title = "Store Maintains Inventory", Summary = "Determines whether the store maintains an inventory.", DataType = "bool")]
    /// <summary>
    /// Returns true, if the store maintains an inventory.  When false, the various buying, selling and inventory maintenace properties are ignored.
    /// Returns true, by default.  The Hall store returns false.
    /// </summary>
    public virtual bool StoreMaintainsInventory { get; set; } = true;

    [ConfigurationMetadata(Title = "Show Item Pricing", Summary = "Determines whether item prices are displayed in the inventory.", DataType = "bool")]
    /// <summary>
    /// Returns whether or not the store should show prices with items in the inventory.  Return true, by default.  The home does not show prices.
    /// </summary>
    public virtual bool ShowItemPricing { get; set; } = true;

    [ConfigurationMetadata(Title = "Markup Rate", Summary = "Specifies the rate at which the store marks up items.", DataType = "int")]
    /// <summary>
    /// Returns the rate at which the store marks up items.  Returns 100, by default.
    /// </summary>
    public virtual int MarkupRate { get; set; } = 100;

    [ConfigurationMetadata(Title = "Markdown Rate", Summary = "Specifies the rate at which the store marks down items.", DataType = "int")]
    /// <summary>
    /// Returns the rate at which the store marks down items.  Returns 100, by default.
    /// </summary>
    public virtual int MarkdownRate { get; set; } = 100;

    [ConfigurationMetadata(Title = "Performs Maintenance When Resting", Summary = "Determines whether the store performs maintenance while the player rests.", DataType = "bool")]
    public virtual bool PerformsMaintenanceWhenResting { get; set; } = true;

    [ConfigurationMetadata(Title = "Level For Random Item Creation", Summary = "Specifies the base level for random item creation. When null, the store stock manifests are used.", DataType = "int?")]
    /// <summary>
    /// Allows the store factory the option to create a random item using the value as the base level for the item; or null, if the store should 
    /// choose from the StoreStockManifests.  The black market store will override this method.
    /// </summary>
    /// <param name="store"></param>
    /// <returns></returns>
    public virtual int? LevelForRandomItemCreation { get; set; } = null;

    [ConfigurationMetadata(Title = "Minimum Item Value", Summary = "Specifies the minimum value of items handled by the store.", DataType = "int")]
    public virtual int MinimumItemValue { get; set; } = 0;

    [ConfigurationMetadata(Title = "No Stock Message", Summary = "Specifies the message displayed when the store is out of stock.", DataType = "string")]
    public virtual string NoStockMessage { get; set; } = "I am currently out of stock.";

    [ConfigurationMetadata(Title = "Purchase Message", Summary = "Specifies the prompt displayed when purchasing items.", DataType = "string")]
    public virtual string PurchaseMessage { get; set; } = "Which item are you interested in? ";

    [ConfigurationMetadata(Title = "Store Sells Items", Summary = "Determines whether the store sells items to the player.", DataType = "bool")]
    /// <summary>
    /// Returns true, if the store sells items for gold to the player when the player retrieves items from the store.  Returns true, by default.
    /// The home does not sell items.
    /// </summary>
    public virtual bool StoreSellsItems { get; set; } = true;

    [ConfigurationMetadata(Title = "Bought Message As Bought Back", Summary = "Determines whether the store indicates that an item was bought back.", DataType = "bool")]
    /// <summary>
    /// Returns true, if the store indicates that the player bought "back" the item.  False, otherwise.  Returns false, by default.  The pawnbroker
    /// store returns true.
    /// </summary>
    public virtual bool BoughtMessageAsBoughtBack { get; set; } = false;

    [ConfigurationMetadata(Title = "Sell Prompt", Summary = "Specifies the prompt displayed when selling an item.", DataType = "string")]
    public virtual string SellPrompt { get; set; } = "Sell which item? ";

    [ConfigurationMetadata(Title = "Store Full Message", Summary = "Specifies the message displayed when the store has no room for an item.", DataType = "string")]
    public virtual string StoreFullMessage { get; set; } = "I have not the room in my Stores to keep it.";

    [ConfigurationMetadata(Title = "Store Maintains Inscription", Summary = "Determines whether the store preserves item inscriptions.", DataType = "bool")]
    /// <summary>
    /// Returns true, if the store keeps inscriptions on items it acquires.  Only the players home does this.
    /// </summary>
    public virtual bool StoreMaintainsInscription { get; set; } = false;

    [ConfigurationMetadata(Title = "Store Buys Items", Summary = "Determines whether the store buys items from the player.", DataType = "bool")]
    /// <summary>
    /// Returns true, if the store buys items for gold from the player.  Returns true, by default.  The home store doesn't buy items.
    /// </summary>
    public virtual bool StoreBuysItems { get; set; } = true;

    [ConfigurationMetadata(Title = "Bought Verb", Summary = "Specifies the verb used when the player sells or drops an item.", DataType = "string")]
    /// <summary>
    /// Returns the verb when the player sells or drops an item to the store.  Normally, "sold", but the home "drops" and the pawn shop "pawns".
    /// </summary>
    public virtual string BoughtVerb { get; set; } = "sold";

    [ConfigurationMetadata(Title = "Store Identifies Items", Summary = "Determines whether the store identifies items sold by the player.", DataType = "bool")]
    /// <summary>
    /// Returns true, if the store identifies items when the player sells an item to the store.  Does not apply to stores that do not buy items.
    /// </summary>
    public virtual bool StoreIdentifiesItems { get; set; } = true;

    [ConfigurationMetadata(Title = "Store Analyzes Purchases", Summary = "Determines whether the store analyzes purchases.", DataType = "bool")]
    public virtual bool StoreAnalyzesPurchases { get; set; } = true;
}

