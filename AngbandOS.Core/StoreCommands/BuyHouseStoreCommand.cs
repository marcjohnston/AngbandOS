using Cthangband.Commands;
using Cthangband.Enumerations;
using Cthangband.Stores;
using Cthangband.UI;
using System;

namespace Cthangband.StoreCommands
{
    internal class BuyHouseStoreCommand : IStoreCommand

    {
        public char Key => 'r';

        public bool RequiresRerendering => false;

        public string Description => "Buy a house";

        public void Execute(SaveGame saveGame, Store store)
        {
            HomeStore homeStore = HomeStore.FindHomeStore(saveGame, saveGame.CurTown.Index);
            homeStore.BuyHouse(saveGame.Player);
        }

        public bool IsEnabled(Store store)
        {
            return (store.StoreType == StoreType.StoreHall);
        }
    }
}
