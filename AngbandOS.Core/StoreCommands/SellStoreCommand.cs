using AngbandOS.Commands;
using AngbandOS.Enumerations;

namespace AngbandOS.StoreCommands
{
    internal class SellStoreCommand : IStoreCommand
    {
        public char Key => 's';

        public bool RequiresRerendering => false;

        public string Description => "Sell an item";

        public void Execute(SaveGame saveGame, Store store)
        {
            store.StoreSell();
        }

        public bool IsEnabled(Store store) => (store.StoreType != StoreType.StoreHall);
    }
}
