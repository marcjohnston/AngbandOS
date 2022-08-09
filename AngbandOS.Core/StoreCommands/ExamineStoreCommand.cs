using Cthangband.Commands;
using Cthangband.Enumerations;

namespace Cthangband.StoreCommands
{
    internal class ExamineStoreCommand : IStoreCommand
    {
        public char Key => 'x';

        public bool RequiresRerendering => false;

        public string Description => "eXamine an item";

        public void Execute(Player player, Store store)
        {
            store.StoreExamine();
        }

        public bool IsEnabled(Store store) => (store.StoreType != StoreType.StoreHall);
    }
}
