namespace AngbandOS.Core.StoreCommands;

[Serializable]
internal class SellStoreCommand : BaseStoreCommand
{
    private SellStoreCommand(SaveGame saveGame) : base(saveGame) { }
    public override char Key => 's';

    public override string Description => "Sell an item";

    public override bool IsEnabled(Store store) => (store.StoreType != StoreType.StoreHall);

    public override void Execute(StoreCommandEvent storeCommandEvent)
    {
        storeCommandEvent.Store.StoreSell();
    }
}
