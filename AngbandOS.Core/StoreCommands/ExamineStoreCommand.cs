using AngbandOS.Commands;
using AngbandOS.Enumerations;

namespace AngbandOS.StoreCommands
{
    internal class ExamineStoreCommand : IStoreCommand
    {
        public char Key => 'x';

        public bool RequiresRerendering => false;

        public string Description => "eXamine an item";

        public void Execute(SaveGame saveGame, Store store)
        {
            store.StoreExamine();
        }

        public bool IsEnabled(Store store) => (store.StoreType != StoreType.StoreHall);
    }
}
