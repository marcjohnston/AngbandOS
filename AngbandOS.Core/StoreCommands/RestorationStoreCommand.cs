using AngbandOS.Commands;
using AngbandOS.Enumerations;

namespace AngbandOS.StoreCommands
{
    internal class RestorationStoreCommand : IStoreCommand

    {
        public char Key => 'r';

        public bool RequiresRerendering => false;

        public string Description => "buy Restoration";

        public void Execute(SaveGame saveGame, Store store)
        {
            store.Restoration();
        }

        public bool IsEnabled(Store store)
        {
            return (store.StoreType == StoreType.StoreAlchemist);
        }
    }
}
