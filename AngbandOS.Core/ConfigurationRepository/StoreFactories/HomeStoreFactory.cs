// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.StoreFactories;

[Serializable]
internal class HomeStoreFactory : StoreFactory
{
    private HomeStoreFactory(SaveGame saveGame) : base(saveGame) { }

    public override int MaxInventory => 100;
    protected override string[] StoreOwnerNames => new string[]
    {
        nameof(YourHomeStoreOwner)
    };

    public override string FeatureType => "Home";
    public override ColorEnum Color => ColorEnum.Pink;
    protected override string SymbolName => nameof(AtSymbol);

    /// <summary>
    /// Returns the name of the item matching criteria for all items of any value.
    /// </summary>
    protected override string[] ItemFilterNames => new string[]
    {
        nameof(AllItemsItemFilter),
    };

    public override bool MaintainsStockLevels => false;

    public override StoreStockManifest[]? GetStoreTable() => null;
    public override bool ShufflesOwnersAndPricing => false;

    public override string? OwnerName => "";

    public override string? Title => "Your Home";
    public override StoreInventoryDisplayTypeEnum ShowInventoryDisplayType => StoreInventoryDisplayTypeEnum.InventoryWithoutPrice;
    public override string SellPrompt => "Drop which item? ";
    public override bool StoreMaintainsInscription => true;
    public override string StoreFullMessage => "Your home is full.";
    public override bool StoreBuysItems => false;
    public override string NoStockMessage => "Your home is empty.";
    public override string PurchaseMessage => "Which item do you want to take? ";

    protected override string? AdvertisedStoreCommand1Name => nameof(GetStoreCommand);
    protected override string? AdvertisedStoreCommand2Name => nameof(DropStoreCommand);
    protected override string? AdvertisedStoreCommand4Name => nameof(RestStoreCommand);
    public override string FleeMessage => "Your pack is so full that you flee your home...";

    public override string GetItemDescription(Item oPtr)
    {
        return oPtr.Description(true, 3);
    }
    public override int WidthOfDescriptionColumn => 65;
    public override bool RenderWeightUnitOfMeasurement => true;
    public override bool StoreCanMergeItem(Item oPtr, Item jPtr)
    {
        return jPtr.CanAbsorb(oPtr);
    }
    public override bool StoreSellsItems => false;

    public override bool PerformsMaintenanceWhenResting => false;

    /// <summary>
    /// Returns true, if the player doesn't own the home; false, if the player owns the home.
    /// </summary>
    /// <param name="saveGame"></param>
    /// <returns></returns>
    public override bool DoorsLocked()
    {
        return SaveGame.TownWithHouse != SaveGame.CurTown.Index;
    }
}