using AngbandOS.Commands;
using AngbandOS.Enumerations;

namespace AngbandOS.StoreCommands
{
    internal class RestStoreCommand : IStoreCommand

    {
        public char Key => 'r';

        public bool RequiresRerendering => false;

        public string Description => "Rest a while";

        public void Execute(SaveGame saveGame, Store store)
        {
            store.Rest();
        }

        public bool IsEnabled(Store store)
        {
            return (store.StoreType == StoreType.StoreHome);
        }
    }
}
