using Cthangband.Commands;
using Cthangband.Enumerations;

namespace Cthangband.StoreCommands
{
    internal class DropStoreCommand : IStoreCommand
    {
        public char Key => 'd';

        public bool RequiresRerendering => false;

        public string Description => "Drop an item";

        public void Execute(SaveGame saveGame, Store store)
        {
            store.StoreSell();
        }

        public bool IsEnabled(Store store) => (store.StoreType != StoreType.StoreHall);
    }
}
