using Cthangband.Commands;
using Cthangband.Enumerations;

namespace Cthangband.StoreCommands
{
    internal class GetStoreCommand : IStoreCommand
    {
        public char Key => 'g';

        public bool RequiresRerendering => false;

        public string Description => "Get an item";

        public void Execute(Player player, Store store)
        {
            store.StorePurchase();
        }

        public bool IsEnabled(Store store) => (store.StoreType != StoreType.StoreHall);
    }
}
