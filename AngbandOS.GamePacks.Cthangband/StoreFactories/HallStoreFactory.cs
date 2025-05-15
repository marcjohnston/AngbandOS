// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HallStoreFactory : StoreFactoryGameConfiguration
{

    public override string[] ShopkeeperNames => new string[]
    {
        nameof(HallOfRecordsShopkeeper)
    };

    public override string TileName => nameof(HallOfRecordsStoreTile);

    /// <summary>
    /// Returns an empty array of item criteria names because the hall doesn't buy items.
    /// </summary>
    public override string[] ItemFilterNames => new string[] { };

    public override bool MaintainsStockLevels => false;
    public override bool StoreMaintainsInventory => false;
    public override bool ShufflesOwnersAndPricing => false;
    public override string? OwnerName => "";
    public override string? Title => "Hall Of Records";
    public override string? AdvertisedStoreCommand1Name => nameof(ViewRacialHeroesStoreCommand);
    public override string? AdvertisedStoreCommand2Name => nameof(ViewClassHeroesStoreCommand);
    public override string? AdvertisedStoreCommand3Name => null; // The examine command does not work here because there is no inventory.
    public override string? AdvertisedStoreCommand4Name => nameof(BuyHouseStoreCommand);
    public override bool PerformsMaintenanceWhenResting => false;
}
