using AngbandOS.Commands;
using AngbandOS.Enumerations;

namespace AngbandOS.StoreCommands
{
    internal class ResearchItemStoreCommand : IStoreCommand

    {
        public char Key => 'r';

        public bool RequiresRerendering => false;

        public string Description => "Research an item";

        public void Execute(SaveGame saveGame, Store store)
        {
            store.ResearchItem();
        }

        public bool IsEnabled(Store store)
        {
            return (store.StoreType == StoreType.StoreMagic);
        }
    }
}
