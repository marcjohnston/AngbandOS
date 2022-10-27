namespace AngbandOS.Stores
{
    internal enum StoreInventoryDisplayTypeEnum
    {
        DoNotShowInventory,
        InventoryWithPrice,
        InventoryWithoutPrice
    }

    internal interface IStore
    {
        string FeatureType { get; }

        void EnterStore();

        void StoreInit();

        void StoreMaint();

        void StoreShuffle();
    }

}
