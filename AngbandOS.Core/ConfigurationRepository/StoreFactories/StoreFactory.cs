// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using System.Text.Json;

namespace AngbandOS.Core.StoreFactories;

[Serializable]
internal abstract class StoreFactory : IItemFilter, IGetKey<string>
{
    protected readonly SaveGame SaveGame;
    public string GetKey => Key;

    /// <summary>
    /// Returns the entity serialized into a Json string.
    /// </summary>
    /// <returns></returns>
    public string ToJson()
    {
        return "";
    }

    protected StoreFactory(SaveGame saveGame)
    {
        SaveGame = saveGame;
    }

    public void Bind()
    {
        // Bind the advertised commands.
        AdvertisedStoreCommand1 = AdvertisedStoreCommand1Name == null ? null : SaveGame.SingletonRepository.StoreCommands.Get(AdvertisedStoreCommand1Name);
        AdvertisedStoreCommand2 = AdvertisedStoreCommand2Name == null ? null : SaveGame.SingletonRepository.StoreCommands.Get(AdvertisedStoreCommand2Name);
        AdvertisedStoreCommand3 = AdvertisedStoreCommand3Name == null ? null : SaveGame.SingletonRepository.StoreCommands.Get(AdvertisedStoreCommand3Name);
        AdvertisedStoreCommand4 = AdvertisedStoreCommand4Name == null ? null : SaveGame.SingletonRepository.StoreCommands.Get(AdvertisedStoreCommand4Name);
        AdvertisedStoreCommand5 = AdvertisedStoreCommand5Name == null ? null : SaveGame.SingletonRepository.StoreCommands.Get(AdvertisedStoreCommand5Name);

        // Bind the store owners.
        List<Shopkeeper> shopkeepersList = new();
        foreach (string shopkeeperName in ShopkeeperNames)
        {
            shopkeepersList.Add(SaveGame.SingletonRepository.Shopkeepers.Get(shopkeeperName));
        }
        Shopkeepers = shopkeepersList.ToArray();

        // Bind the symbol.
        Tile = SaveGame.SingletonRepository.Tiles.Get(TileName);

        // Bind the item filters.
        List<ItemFilter> itemFilters = new();
        foreach (string itemFilterName in ItemFilterNames)
        {
            itemFilters.Add(SaveGame.SingletonRepository.ItemFilters.Get(itemFilterName));
        }
        ItemFilters = itemFilters.ToArray();

        // Bind the store stock manifests.
        List<StoreStockManifest> storeStockManifestList = new();
        if (StoreStockManifestDefinitions != null) {
            foreach (StoreStockManifestDefinition storeStockManifestDefinition in StoreStockManifestDefinitions)
            {
                ItemFactory itemFactory = SaveGame.SingletonRepository.ItemFactories.Get(storeStockManifestDefinition.ItemFactoryName);
                storeStockManifestList.Add(new StoreStockManifest(itemFactory, storeStockManifestDefinition.Weight));
            }
        }
        StoreStockManifests = storeStockManifestList.ToArray();
    }

    /// <summary>
    /// Returns true, if the store is an empty lot; false, if it is a store.  Empty lots render as either grave yards or fields.
    /// </summary>
    public virtual bool IsEmptyLot => false;

    /// <summary>
    /// Returns true, if the store (non-empty lot) is built from permanent rock.  Abandoned stores are created from inner walls and removeable rubble.
    /// </summary>
    public virtual bool BuildingsMadeFromPermanentRock => true;

    /// <summary>
    /// Returns true, if the entrances to the stores are are randomly placed.
    /// </summary>
    public virtual bool StoreEntranceDoorsAreBlownOff => false;

    public virtual string Key => GetType().Name;

    /// <summary>
    /// Returns the number of items in a page for the store.
    /// </summary>
    public virtual int PageSize => 26;

    public virtual bool UseHomeCarry => false;

    /// <summary>
    /// Returns true, if the store will accept items from the player (e.g. sell or drop).  An item matches, if any ItemFilter
    /// matches the item.
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public bool ItemMatches(Item item)
    {
        // Loop through all of the item filters.  If the filter matches, then the item matches.
        foreach (ItemFilter itemFilter in ItemFilters)
        {
            if (itemFilter.ItemMatches(item))
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
    protected virtual string[] ItemFilterNames => new string[] { };

    /// <summary>
    /// Returns true, if the store is a home that can be bought; false, otherwise.  When true, the doors locked will return true, if the store/home 
    /// is in the correct town.  Returns false, by default.
    /// </summary>
    public virtual bool IsHomeThatCanBeBought => false;

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
        if (SaveGame.TownWithHouse == null)
        {
            return true;
        }

        // Make sure this town matches the town where the player bought the home.
        return SaveGame.TownWithHouse != SaveGame.CurTown;
    }

    /// <summary>
    /// Returns whether or not the store should perform maintenance.  When true, the store will automatically maintain stock levels based on the 
    /// MinKeep, MaxKeep and Turnover values.  Returns true, by default.
    /// </summary>
    public virtual bool MaintainsStockLevels => true;

    /// <summary>
    /// Returns the maximum number of items the store should maintain.  Returns one pagesize (26), by default.
    /// </summary>
    public virtual int MaxInventory => PageSize;

    /// <summary>
    /// Returns the minimum number of items the store should maintain.  Applies only when MaintainsStockLevels returns true.  Returns 6, by default.
    /// </summary>
    public virtual int MinInventory => 6;

    /// <summary>
    /// Returns the number of items the store should delete during maintenance.  Applies only when MaintainsStockLevels returns true.  Returns 9, by default.
    /// </summary>
    public virtual int StoreTurnover => 9;

    /// <summary>
    /// Returns an array of item types that the store carries; or null, if the store does not carry items for sale or if the factory overrides the
    /// CreateItem method.  Returns null by default.  When the Factory.CreateItem method returns null, this property should return a manifest for the
    /// store to create items from.  If the store doesn't sell items, the Factory.CreateItem should return null and this property should return null.
    /// </summary>
    /// <returns></returns>
    public StoreStockManifest[]? StoreStockManifests { get; private set; } = null;

    protected virtual StoreStockManifestDefinition[]? StoreStockManifestDefinitions => null;

    /// <summary>
    /// Returns whether or not the store should occasionally change the owner and put items on sale.  When true, which is by default, the store will
    /// automatically perform this shuffling.
    /// </summary>
    public virtual bool ShufflesOwnersAndPricing => true;

    protected abstract string[] ShopkeeperNames { get; }

    /// <summary>
    /// Represents a pool of possible store owners for the store.
    /// </summary>
    public Shopkeeper[] Shopkeepers { get; private set; }

    protected virtual string? AdvertisedStoreCommand1Name => nameof(PurchaseStoreCommand);
    protected virtual string? AdvertisedStoreCommand2Name => nameof(SellStoreCommand);
    protected virtual string? AdvertisedStoreCommand3Name => nameof(ExamineStoreItemCommand);
    protected virtual string? AdvertisedStoreCommand4Name => null;
    protected virtual string? AdvertisedStoreCommand5Name => null;
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
    public virtual int WidthOfDescriptionColumn => 58;

    /// <summary>
    /// Returns whether the weight column should render the lb. units of measurement.  The players home has sufficient space to render, but the other stores do not.
    /// </summary>
    public virtual bool RenderWeightUnitOfMeasurement => false;

    /// <summary>
    /// The tile to use for for the door.
    /// </summary>
    public Tile Tile { get; private set; }

    protected abstract string TileName { get; }

    /// <summary>
    /// Returns true, if the items should render as flavour aware; false, otherwise.  Stores will render their items as flavour aware.  The flavour
    /// awareness is factory related.  Stores override the factory value.  Pawnshops and the home stores render items as they are seen in the dungeon.
    /// Returns true, by default.  Pawnshops and the home store return false.
    /// </summary>
    public virtual bool ItemsRenderFlavourAware => true;

    /// <summary>
    /// Returns the description of an item that is rendered in the store inventory.  Pawn shops and the players home render different descriptions.
    /// </summary>
    /// <param name="oPtr"></param>
    /// <returns></returns>
    public string GetItemDescription(Item oPtr)
    {
        if (ItemsRenderFlavourAware)
        {
            return oPtr.Description(true, 3, true);
        }
        else
        {
            return oPtr.Description(true, 3);
        }
    }

    /// <summary>
    /// Returns the name of the owner of the store; or null, if the store owner should reflect the store owner.
    /// </summary>
    public virtual string? OwnerName => null;

    /// <summary>
    /// Returns the title of the store; or null, if the store title should reflect the store owner.
    /// </summary>
    public virtual string? Title => null;

    /// <summary>
    /// Returns true, if the store maintains an inventory.  When false, the various buying, selling and inventory maintenace properties are ignored.
    /// Returns true, by default.  The Hall store returns false.
    /// </summary>
    public virtual bool StoreMaintainsInventory => true;

    /// <summary>
    /// Returns whether or not the store should show prices with items in the inventory.  Return true, by default.  The home does not show prices.
    /// </summary>
    public virtual bool ShowItemPricing => true;

    /// <summary>
    /// Returns the rate at which the store marks up items.  Returns 1, by default.
    /// </summary>
    public virtual double MarkupRate => 1;

    /// <summary>
    /// Returns the rate at which the store marks down items.  Returns 1, by default.
    /// </summary>
    public virtual double MarkdownRate => 1;

    public int MarkupItem(int price)
    {
        return (int)((double)price * MarkupRate);
    }

    public int MarkdownItem(int price)
    {
        return (int)((double)price * MarkdownRate);
    }

    /// <summary>
    /// Returns true, if two objects are similar for a store to combine them.  This method does not take into account, whether or not the object is known because the store
    /// is assumed to auto-identify it.
    /// </summary>
    /// <param name="oPtr"></param>
    /// <param name="jPtr"></param>
    /// <returns></returns>
    public bool StoreObjectSimilar(Item oPtr, Item jPtr)
    {
        if (oPtr == jPtr)
        {
            return false;
        }
        if (oPtr.Factory != jPtr.Factory)
        {
            return false;
        }
        if (oPtr.TypeSpecificValue != jPtr.TypeSpecificValue)
        {
            return false;
        }
        if (oPtr.BonusToHit != jPtr.BonusToHit)
        {
            return false;
        }
        if (oPtr.BonusDamage != jPtr.BonusDamage)
        {
            return false;
        }
        if (oPtr.BonusArmorClass != jPtr.BonusArmorClass)
        {
            return false;
        }
        if (oPtr.FixedArtifact != jPtr.FixedArtifact)
        {
            return false;
        }
        if (oPtr.RareItemTypeIndex != jPtr.RareItemTypeIndex)
        {
            return false;
        }
        if (!string.IsNullOrEmpty(oPtr.RandartName) || !string.IsNullOrEmpty(jPtr.RandartName))
        {
            return false;
        }
        if (oPtr.RandartItemCharacteristics != jPtr.RandartItemCharacteristics)
        {
            return false;
        }
        if (oPtr.BonusPowerType != 0 || jPtr.BonusPowerType != 0)
        {
            return false;
        }
        if (oPtr.RechargeTimeLeft != 0 || jPtr.RechargeTimeLeft != 0)
        {
            return false;
        }
        if (oPtr.BaseArmorClass != jPtr.BaseArmorClass)
        {
            return false;
        }
        if (oPtr.DamageDice != jPtr.DamageDice)
        {
            return false;
        }
        if (oPtr.DamageDiceSides != jPtr.DamageDiceSides)
        {
            return false;
        }
        if (oPtr.Category == ItemTypeEnum.Chest)
        {
            return false;
        }
        if (oPtr.Discount != jPtr.Discount)
        {
            return false;
        }
        return true;
    }

    public virtual bool PerformsMaintenanceWhenResting => true;

    /// <summary>
    /// Allows the store factory the option to create a random item using the value as the base level for the item; or null, if the store should 
    /// choose from the StoreStockManifests.  The black market store will override this method.
    /// </summary>
    /// <param name="store"></param>
    /// <returns></returns>
    public virtual int? LevelForRandomItemCreation => null;

    public virtual int MinimumItemValue => 0;

    public virtual string NoStockMessage => "I am currently out of stock.";
    public virtual string PurchaseMessage => "Which item are you interested in? ";

    /// <summary>
    /// Returns true, if the store sells items for gold to the player when the player retrieves items from the store.  Returns true, by default.
    /// The home does not sell items.
    /// </summary>
    public virtual bool StoreSellsItems => true;

    /// <summary>
    /// Returns true, if the store indicates that the player bought "back" the item.  False, otherwise.  Returns false, by default.  The pawnbroker
    /// store returns true.
    /// </summary>
    public virtual bool BoughtMessageAsBoughtBack => false;

    public virtual string SellPrompt => "Sell which item? ";
    public virtual string StoreFullMessage => "I have not the room in my Stores to keep it.";

    /// <summary>
    /// Returns true, if the store keeps inscriptions on items it acquires.  Only the players home does this.
    /// </summary>
    public virtual bool StoreMaintainsInscription => false;

    /// <summary>
    /// Returns true, if the store buys items for gold from the player.  Returns true, by default.  The home store doesn't buy items.
    /// </summary>
    public virtual bool StoreBuysItems => true;

    /// <summary>
    /// Returns the verb when the player sells or drops an item to the store.  Normally, "sold", but the home "drops" and the pawn shop "pawns".
    /// </summary>
    public virtual string BoughtVerb => "sold";

    /// <summary>
    /// Returns true, if the store identifies items when the player sells an item to the store.  Does not apply to stores that do not buy items.
    /// </summary>
    public virtual bool StoreIdentifiesItems => true;

    public virtual bool StoreAnalyzesPurchases => true;
}