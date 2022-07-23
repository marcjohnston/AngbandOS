using Cthangband.Commands;
using Cthangband.Enumerations;

namespace Cthangband.StoreCommands
{
    internal class PurchaseStoreCommand : IStoreCommand
    {
        public char Key => 'p';

        public bool RequiresRerendering => false;

        public string Description => "Purchase an item";

        public void Execute(Player player, Store store)
        {
            store.StorePurchase();
        }

        public bool IsEnabled(Store store) => (store.StoreType != StoreType.StoreHall);
    }
}
