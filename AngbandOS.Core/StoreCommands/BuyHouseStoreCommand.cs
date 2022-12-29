namespace AngbandOS.StoreCommands
{
    internal class BuyHouseStoreCommand : BaseStoreCommand

    {
        public override char Key => 'r';

        public override string Description => "Buy a house";

        public override void Execute(StoreCommandEvent storeCommandEvent)
        {
            HomeStore homeStore = HomeStore.FindHomeStore(storeCommandEvent.SaveGame, storeCommandEvent.SaveGame.CurTown.Index);
            homeStore.BuyHouse(storeCommandEvent.SaveGame.Player);
        }

        public bool IsEnabled(Store store) => (store.StoreType == StoreType.StoreHall);
    }
}
