using AngbandOS.Commands;
using AngbandOS.Enumerations;

namespace AngbandOS.StoreCommands
{
    internal class IdentifyAllStoreCommand : IStoreCommand

    {
        public char Key => 'r';

        public bool RequiresRerendering => false;

        public string Description => "Identify all";

        public void Execute(SaveGame saveGame, Store store)
        {
            store.IdentifyAll();
        }

        public bool IsEnabled(Store store)
        {
            return (store.StoreType == StoreType.StorePawn);
        }
    }
}
