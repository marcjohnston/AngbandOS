using Cthangband.Commands;
using Cthangband.Enumerations;

namespace Cthangband.StoreCommands
{
    internal class MGetStoreCommand : IStoreCommand
    {
        public char Key => 'm';

        public string Description => "";

        public bool RequiresRerendering => false;

        public void Execute(SaveGame saveGame, Store store)
        {
            store.StorePurchase();
        }

        public bool IsEnabled(Store store) => (store.StoreType != StoreType.StoreHall);
    }
}
