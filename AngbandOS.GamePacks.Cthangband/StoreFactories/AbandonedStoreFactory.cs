// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class AbandonedStoreFactory : StoreFactoryGameConfiguration
{

    public override string[] ShopkeeperNames => new string[]
    {
        nameof(EmptyLotShopkeeper)
    };

    public override string TileName => nameof(EmptyLotStoreTile);
    public override bool BuildingsMadeFromPermanentRock => false;
    public override bool StoreEntranceDoorsAreBlownOff => true;

    public override bool MaintainsStockLevels => false;
    public override bool ShufflesOwnersAndPricing => false;
    public override bool PerformsMaintenanceWhenResting => false;
}
