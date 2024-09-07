// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using System.ComponentModel;

namespace AngbandOS.Core.Interface.Definitions;

[Serializable]
public class StoreFactoryDefinition : IPoco
{
    public StoreFactoryDefinition()
    {
        Key = GetType().Name;
        MaxInventory = PageSize;
        AdvertisedStoreCommand1Name = "PurchaseStoreCommand";
        AdvertisedStoreCommand2Name = "SellStoreCommand";
        AdvertisedStoreCommand3Name = "ExamineStoreItemCommand";
    }

    /// <summary>
    /// Returns true, if the store is an empty lot; false, if it is a store.  Empty lots render as either grave yards or fields.
    /// </summary>
    public virtual bool IsEmptyLot { get; set; } = false;

    /// <summary>
    /// Returns true, if the store (non-empty lot) is built from permanent rock.  Abandoned stores are created from inner walls and removeable rubble.
    /// </summary>
    public virtual bool BuildingsMadeFromPermanentRock { get; set; } = true;

    /// <summary>
    /// Returns true, if the entrances to the stores are are randomly placed.
    /// </summary>
    public virtual bool StoreEntranceDoorsAreBlownOff { get; set; } = false;

    public virtual string Key { get; set; }

    /// <summary>
    /// Returns the number of items in a page for the store.
    /// </summary>
    public virtual int PageSize { get; set; } = 26;

    public virtual bool UseHomeCarry { get; set; } = false;

    /// <summary>
    /// Returns the names of the item matching criterion used to determine which items the store buys.  Returns an empty arrary, by default, to
    /// indicate that the store does not buy any items.
    /// </summary>
    public virtual string[] ItemFilterNames { get; set; } = new string[] { };

    /// <summary>
    /// Returns true, if the store is a home that can be bought; false, otherwise.  When true, the doors locked will return true, if the store/home 
    /// is in the correct town.  Returns false, by default.
    /// </summary>
    public virtual bool IsHomeThatCanBeBought { get; set; } = false;

    /// <summary>
    /// Returns whether or not the store should perform maintenance.  When true, the store will automatically maintain stock levels based on the 
    /// MinKeep, MaxKeep and Turnover values.  Returns true, by default.
    /// </summary>
    public virtual bool MaintainsStockLevels { get; set; } = true;

    /// <summary>
    /// Returns the maximum number of items the store should maintain.  Returns one pagesize (26), by default.
    /// </summary>
    public virtual int MaxInventory { get; set; }

    /// <summary>
    /// Returns the minimum number of items the store should maintain.  Applies only when MaintainsStockLevels returns true.  Returns 6, by default.
    /// </summary>
    public virtual int MinInventory { get; set; } = 6;

    /// <summary>
    /// Returns the number of items the store should delete during maintenance.  Applies only when MaintainsStockLevels returns true.  Returns 9, by default.
    /// </summary>
    public virtual int StoreTurnover { get; set; } = 9;

    public virtual StoreStockManifestDefinition[]? StoreStockManifestDefinitions { get; set; } = null;

    /// <summary>
    /// Returns whether or not the store should occasionally change the owner and put items on sale.  When true, which is by default, the store will
    /// automatically perform this shuffling.
    /// </summary>
    public virtual bool ShufflesOwnersAndPricing { get; set; } = true;

    public virtual string[] ShopkeeperNames { get; set; }

    public virtual string? AdvertisedStoreCommand1Name { get; set; }
    public virtual string? AdvertisedStoreCommand2Name { get; set; }
    public virtual string? AdvertisedStoreCommand3Name { get; set; }
    public virtual string? AdvertisedStoreCommand4Name { get; set; } = null;
    public virtual string? AdvertisedStoreCommand5Name { get; set; } = null;

    /// <summary>
    /// Returns the width of the description column for rendering items in the store inventory.  The HomeStore defines a wider column for the description.
    /// </summary>
    public virtual int WidthOfDescriptionColumn { get; set; } = 58;

    /// <summary>
    /// Returns whether the weight column should render the lb. units of measurement.  The players home has sufficient space to render, but the other stores do not.
    /// </summary>
    public virtual bool RenderWeightUnitOfMeasurement { get; set; } = false;

    public virtual string TileName { get; set; }

    /// <summary>
    /// Returns true, if the items should render as flavor aware; false, otherwise.  Stores will render their items as flavor aware.  The flavor
    /// awareness is factory related.  Stores override the factory value.  Pawnshops and the home stores render items as they are seen in the dungeon.
    /// Returns true, by default.  Pawnshops and the home store return false.
    /// </summary>
    public virtual bool ItemsRenderFlavorAware { get; set; } = true;

    /// <summary>
    /// Returns the name of the owner of the store; or null, if the store owner should reflect the store owner.
    /// </summary>
    public virtual string? OwnerName { get; set; } = null;

    /// <summary>
    /// Returns the title of the store; or null, if the store title should reflect the store owner.
    /// </summary>
    public virtual string? Title { get; set; } = null;

    /// <summary>
    /// Returns true, if the store maintains an inventory.  When false, the various buying, selling and inventory maintenace properties are ignored.
    /// Returns true, by default.  The Hall store returns false.
    /// </summary>
    public virtual bool StoreMaintainsInventory { get; set; } = true;

    /// <summary>
    /// Returns whether or not the store should show prices with items in the inventory.  Return true, by default.  The home does not show prices.
    /// </summary>
    public virtual bool ShowItemPricing { get; set; } = true;

    /// <summary>
    /// Returns the rate at which the store marks up items.  Returns 1, by default.
    /// </summary>
    public virtual int MarkupRate { get; set; } = 1;

    /// <summary>
    /// Returns the rate at which the store marks down items.  Returns 1, by default.
    /// </summary>
    public virtual int MarkdownRate { get; set; } = 1;

    public virtual bool PerformsMaintenanceWhenResting { get; set; } = true;

    /// <summary>
    /// Allows the store factory the option to create a random item using the value as the base level for the item; or null, if the store should 
    /// choose from the StoreStockManifests.  The black market store will override this method.
    /// </summary>
    /// <param name="store"></param>
    /// <returns></returns>
    public virtual int? LevelForRandomItemCreation { get; set; } = null;

    public virtual int MinimumItemValue { get; set; } = 0;

    public virtual string NoStockMessage { get; set; } = "I am currently out of stock.";
    public virtual string PurchaseMessage { get; set; } = "Which item are you interested in? ";

    /// <summary>
    /// Returns true, if the store sells items for gold to the player when the player retrieves items from the store.  Returns true, by default.
    /// The home does not sell items.
    /// </summary>
    public virtual bool StoreSellsItems { get; set; } = true;

    /// <summary>
    /// Returns true, if the store indicates that the player bought "back" the item.  False, otherwise.  Returns false, by default.  The pawnbroker
    /// store returns true.
    /// </summary>
    public virtual bool BoughtMessageAsBoughtBack { get; set; } = false;

    public virtual string SellPrompt { get; set; } = "Sell which item? ";

    public virtual string StoreFullMessage { get; set; } = "I have not the room in my Stores to keep it.";

    /// <summary>
    /// Returns true, if the store keeps inscriptions on items it acquires.  Only the players home does this.
    /// </summary>
    public virtual bool StoreMaintainsInscription { get; set; } = false;

    /// <summary>
    /// Returns true, if the store buys items for gold from the player.  Returns true, by default.  The home store doesn't buy items.
    /// </summary>
    public virtual bool StoreBuysItems { get; set; } = true;

    /// <summary>
    /// Returns the verb when the player sells or drops an item to the store.  Normally, "sold", but the home "drops" and the pawn shop "pawns".
    /// </summary>
    public virtual string BoughtVerb { get; set; } = "sold";

    /// <summary>
    /// Returns true, if the store identifies items when the player sells an item to the store.  Does not apply to stores that do not buy items.
    /// </summary>
    public virtual bool StoreIdentifiesItems { get; set; } = true;

    public virtual bool StoreAnalyzesPurchases { get; set; } = true;

    public bool IsValid()
    {
        return true;
    }
}
