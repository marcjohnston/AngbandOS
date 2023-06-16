namespace AngbandOS.Core.StoreCommands;

[Serializable]
internal class HireEscortStoreCommand : BaseStoreCommand

{
    private HireEscortStoreCommand(SaveGame saveGame) : base(saveGame) { }
    public override char Key => 'r';

    public override string Description => "Hire an escort";

    public override bool IsEnabled(Store store) => (store.StoreType == StoreType.StoreGeneral);

    public override void Execute(StoreCommandEvent storeCommandEvent)
    {
        storeCommandEvent.Store.HireAnEscort();
    }
}
