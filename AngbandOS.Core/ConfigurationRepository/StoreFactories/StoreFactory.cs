// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.StoreFactories;

internal abstract class StoreFactory : IItemFilter, IGetKey<string>
{
    protected readonly SaveGame SaveGame;
    public string GetKey => Key;

    protected StoreFactory(SaveGame saveGame)
    {
        SaveGame = saveGame;
    }

    public virtual void Bind()
    {
        AdvertisedStoreCommand1 = AdvertisedStoreCommand1Name == null ? null : SaveGame.SingletonRepository.StoreCommands.Get(AdvertisedStoreCommand1Name);
        AdvertisedStoreCommand2 = AdvertisedStoreCommand2Name == null ? null : SaveGame.SingletonRepository.StoreCommands.Get(AdvertisedStoreCommand2Name);
        AdvertisedStoreCommand3 = AdvertisedStoreCommand3Name == null ? null : SaveGame.SingletonRepository.StoreCommands.Get(AdvertisedStoreCommand3Name);
        AdvertisedStoreCommand4 = AdvertisedStoreCommand4Name == null ? null : SaveGame.SingletonRepository.StoreCommands.Get(AdvertisedStoreCommand4Name);
        AdvertisedStoreCommand5 = AdvertisedStoreCommand5Name == null ? null : SaveGame.SingletonRepository.StoreCommands.Get(AdvertisedStoreCommand5Name);

        List<StoreOwner> storeOwnersList = new();
        foreach (string storeOwnerName in StoreOwnerNames)
        {
            storeOwnersList.Add(SaveGame.SingletonRepository.StoreOwners.Get(storeOwnerName));
        }
        StoreOwners = storeOwnersList.ToArray();
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

    public virtual int PageSize => 26;

    public virtual bool UseHomeCarry => false;

    /// <summary>
    /// Returns true, if the store will accept items from the player (e.g. sell or drop).
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public abstract bool ItemMatches(Item item);

    /// <summary>
    /// Returns true, if the doors to the store are locked; false, if the store is open.  Returns false, by default.
    /// </summary>
    /// <returns></returns>
    public virtual bool DoorsLocked() => false;

    /// <summary>
    /// Returns whether or not the store should perform maintenance.  When true, which is by default, the store will automatically 
    /// maintain stock levels based on the MinKeep, MaxKeep and Turnover values.
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
    /// Returns an array of item types that the store carries.  Returns null, if the store does not carry items for sale.
    /// </summary>
    /// <returns></returns>
    public abstract StockStoreInventoryItem[] GetStoreTable();

    public virtual string FleeMessage => "Your pack is so full that you flee the Stores...";

    public abstract string FeatureType { get; }

    /// <summary>
    /// Returns whether or not the store should occasionally change the owner and put items on sale.  When true, which is by default, the store will
    /// automatically perform this shuffling.
    /// </summary>
    public virtual bool ShufflesOwnersAndPricing => true;

    protected abstract string[] StoreOwnerNames { get; }

    /// <summary>
    /// Represents a pool of possible store owners for the store.
    /// </summary>
    public StoreOwner[] StoreOwners { get; private set; }

    protected virtual string? AdvertisedStoreCommand1Name => nameof(PurchaseStoreCommand);
    protected virtual string? AdvertisedStoreCommand2Name => nameof(SellStoreCommand);
    protected virtual string? AdvertisedStoreCommand3Name => nameof(ExamineStoreCommand);
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
    public virtual StoreCommand? AdvertisedStoreCommand5 { get; private set; }

    /// <summary>
    /// Returns the width of the description column for rendering items in the store inventory.  The HomeStore defines a wider column for the description.
    /// </summary>
    public virtual int WidthOfDescriptionColumn => 58;

    /// <summary>
    /// Returns whether the weight column should render the lb. units of measurement.  The players home has sufficient space to render, but the other stores do not.
    /// </summary>
    public virtual bool RenderWeightUnitOfMeasurement => false;

    /// <summary>
    /// The symbol to use for rendering.
    /// </summary>
    public abstract Symbol Symbol { get; }

    public abstract ColourEnum Colour { get; }

    /// <summary>
    /// Returns a description of the store.   By default, the feature type is returned.
    /// </summary>
    public virtual string Description => FeatureType;

    /// <summary>
    /// Returns the description of an item that is rendered in the store inventory.  Pawn shops and the players home render different descriptions.
    /// </summary>
    /// <param name="oPtr"></param>
    /// <returns></returns>
    public virtual string GetItemDescription(Item oPtr)
    {
        return oPtr.StoreDescription(true, 3);
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
    /// Returns whether or not the store should show an item inventory.
    /// </summary>
    public virtual StoreInventoryDisplayTypeEnum ShowInventoryDisplayType => StoreInventoryDisplayTypeEnum.InventoryWithPrice;

    public virtual int AdjustPrice(int price, bool trueToMarkDownFalseToMarkUp)
    {
        return price;
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

    public virtual bool StoreCanMergeItem(Item oPtr, Item jPtr) => StoreObjectSimilar(jPtr, oPtr);

    public virtual Item? CreateItem(Store store) => null;
    public virtual int MinimumItemValue => 0;

    public virtual string NoStockMessage => "I am currently out of stock.";
    public virtual string PurchaseMessage => "Which item are you interested in? ";

    /// <summary>
    /// Returns true, if the store sells items for gold to the player.  The home does not sell items.
    /// </summary>
    public virtual bool StoreSellsItems => true;

    public virtual string BoughtMessage(string oName, int price) => $"You bought {oName} for {price} gold.";

    public virtual string SellPrompt => "Sell which item? ";
    public virtual string StoreFullMessage => "I have not the room in my Stores to keep it.";

    /// <summary>
    /// Returns true, if the store keeps inscriptions on items it acquires.  Only the players home does this.
    /// </summary>
    public virtual bool StoreMaintainsInscription => false;

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