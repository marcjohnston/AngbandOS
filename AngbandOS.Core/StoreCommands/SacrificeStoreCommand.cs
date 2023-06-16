namespace AngbandOS.Core.StoreCommands;

[Serializable]
internal class SacrificeStoreCommand : BaseStoreCommand
{
    private SacrificeStoreCommand(SaveGame saveGame) : base(saveGame) { }
    public override char Key => 'v';

    public override string Description => "Sacrifice Item";

    public override bool IsEnabled(Store store) => (store.StoreType == StoreType.StoreTemple);

    public override void Execute(StoreCommandEvent storeCommandEvent)
    {
        storeCommandEvent.Store.SacrificeItem();
    }
}
