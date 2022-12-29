namespace AngbandOS.StoreCommands
{
    internal class HireEscortStoreCommand : BaseStoreCommand

    {
        public override char Key => 'r';

        public override string Description => "Hire an escort";

        public override void Execute(StoreCommandEvent storeCommandEvent)
        {
            storeCommandEvent.Store.HireAnEscort();
        }

        public override bool IsEnabled(Store store) => (store.StoreType == StoreType.StoreGeneral);
    }
}
