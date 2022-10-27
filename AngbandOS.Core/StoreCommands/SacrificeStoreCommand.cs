using AngbandOS.Commands;
using AngbandOS.Enumerations;

namespace AngbandOS.StoreCommands
{
    internal class SacrificeStoreCommand : IStoreCommand
    {
        public char Key => 'v';

        public bool RequiresRerendering => false;

        public string Description => "Sacrifice Item";

        public void Execute(SaveGame saveGame, Store store)
        {
            store.SacrificeItem();
        }

        public bool IsEnabled(Store store)
        {
            return (store.StoreType == StoreType.StoreTemple);
        }
    }
}
