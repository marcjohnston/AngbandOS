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
    public override StoreOwner[] StoreOwners => new StoreOwner[]
    {
        SaveGame.SingletonRepository.StoreOwners.Get(nameof(YourHomeStoreOwner))
    };

    public override string FeatureType => "Home";
    public override ColourEnum Colour => ColourEnum.Pink;
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(AtSymbol));

    public override bool ItemMatches(Item item)
    {
        return true;
    }

    public override bool MaintainsStockLevels => false;

    public override StockStoreInventoryItem[] GetStoreTable() => null;
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

    public override StoreCommand AdvertisedStoreCommand1 => SaveGame.SingletonRepository.StoreCommands.Get(nameof(GetStoreCommand));
    public override StoreCommand AdvertisedStoreCommand2 => SaveGame.SingletonRepository.StoreCommands.Get(nameof(DropStoreCommand));
    public override StoreCommand AdvertisedStoreCommand4 => SaveGame.SingletonRepository.StoreCommands.Get(nameof(RestStoreCommand));
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