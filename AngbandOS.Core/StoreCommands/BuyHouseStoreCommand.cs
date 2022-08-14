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

        public void Execute(Player player, Store store)
        {
            HomeStore homeStore = HomeStore.FindHomeStore(store.SaveGame, SaveGame.Instance.CurTown.Index);
            homeStore.BuyHouse(player);
        }

        public bool IsEnabled(Store store)
        {
            return (store.StoreType == StoreType.StoreHall);
        }
    }
}
