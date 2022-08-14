using Cthangband.Commands;
using Cthangband.Enumerations;

namespace Cthangband.StoreCommands
{
    internal class HireEscortStoreCommand : IStoreCommand

    {
        public char Key => 'r';

        public bool RequiresRerendering => false;

        public string Description => "Hire an escort";

        public void Execute(SaveGame saveGame, Store store)
        {
            store.HireAnEscort();
        }

        public bool IsEnabled(Store store)
        {
            return (store.StoreType == StoreType.StoreGeneral);
        }
    }
}
