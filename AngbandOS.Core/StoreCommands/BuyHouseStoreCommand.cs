namespace AngbandOS.StoreCommands
{
    [Serializable]
    internal class BuyHouseStoreCommand : BaseStoreCommand

    {
        private BuyHouseStoreCommand(SaveGame saveGame) : base(saveGame) { }
        public override char Key => 'r';

        public override string Description => "Buy a house";

        public override bool IsEnabled(Store store) => (store.StoreType == StoreType.StoreHall);

        public override void Execute(StoreCommandEvent storeCommandEvent)
        {
            HomeStore homeStore = HomeStore.FindHomeStore(SaveGame, SaveGame.CurTown.Index);
            homeStore.BuyHouse(SaveGame.Player);
        }
    }
}
