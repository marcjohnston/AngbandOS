using AngbandOS.Commands;
using AngbandOS.Enumerations;
using AngbandOS.Stores;
using AngbandOS.UI;
using System;

namespace AngbandOS.StoreCommands
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
