// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HomeStoreFactory : StoreFactoryGameConfiguration
{

    public override int MaxInventory => 100;
    public override string[] ShopkeeperNames => new string[]
    {
        nameof(YourHomeShopkeeper)
    };

    public override string TileName => nameof(HomeStoreTile);

    /// <summary>
    /// Returns the name of the item matching criteria for all items of any value.
    /// </summary>
    public override string[] ItemFilterNames => new string[]
    {
        nameof(ItemFiltersEnum.AllItemsItemFilter),
    };

    public override bool MaintainsStockLevels => false;

    public override bool ShufflesOwnersAndPricing => false;

    public override string? OwnerName => "";

    public override string? Title => "Your Home";
    public override bool ShowItemPricing => false;
    public override string SellPrompt => "Drop which item? ";
    public override bool StoreMaintainsInscription => true;
    public override string StoreFullMessage => "Your home is full.";
    public override bool StoreBuysItems => false;
    public override string NoStockMessage => "Your home is empty.";
    public override string PurchaseMessage => "Which item do you want to take? ";

    public override string? AdvertisedStoreCommand1Name => nameof(GetStoreCommand);
    public override string? AdvertisedStoreCommand2Name => nameof(DropStoreCommand);
    public override string? AdvertisedStoreCommand4Name => nameof(RestStoreCommand);

    /// <summary>
    /// Returns false, because items in the pawn shop are not identified and render as they would appear in the dungeon.
    /// </summary>
    public override bool ItemsRenderFlavorAware => false;

    public override int WidthOfDescriptionColumn => 65;
    public override bool RenderWeightUnitOfMeasurement => true;
    public override bool StoreSellsItems => false;

    public override bool PerformsMaintenanceWhenResting => false;

    /// <summary>
    /// Returns true, if this store is eligible to be bought as a home.
    /// </summary>
    /// <param name="game"></param>
    /// <returns></returns>
    public override bool IsHomeThatCanBeBought => true;
}