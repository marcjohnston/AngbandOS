// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Stores;

[Serializable]
internal class EmptyLotStore : Store
{
    public EmptyLotStore(SaveGame saveGame) : base(saveGame) { }

    public override StoreType StoreType => StoreType.StoreEmptyLot;
    protected override StoreOwner[] StoreOwners => new StoreOwner[]
    {
        SaveGame.SingletonRepository.StoreOwners.Get<EmptyLotStoreOwner>()
    };

    public override string FeatureType => "";
    public override Colour Colour => Colour.White;
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<SpaceBarSymbol>();

    public override bool ItemMatches(Item item)
    {
        return false;
    }
    protected override bool MaintainsStockLevels => false;
    public override bool ShufflesOwnersAndPricing => false;
    protected override StockStoreInventoryItem[] GetStoreTable()
    {
        return null;
    }
    protected override bool PerformsMaintenanceWhenResting => false;
}
