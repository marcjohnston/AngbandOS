using Cthangband.Commands;
using Cthangband.Enumerations;

namespace Cthangband.StoreCommands
{
    internal class SacrificeStoreCommand : IStoreCommand
    {
        public char Key => 'v';

        public bool RequiresRerendering => false;

        public string Description => "Sacrifice Item";

        public void Execute(Player player, Store store)
        {
            store.SacrificeItem();
        }

        public bool IsEnabled(Store store)
        {
            return (store.StoreType == StoreType.StoreTemple);
        }
    }
}
