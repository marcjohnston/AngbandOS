using AngbandOS.Commands;
using AngbandOS.Enumerations;

namespace AngbandOS.StoreCommands
{
    internal class HireRoomStoreCommand : IStoreCommand

    {
        public char Key => 'r';

        public bool RequiresRerendering => false;

        public string Description => "hire a Room";

        public void Execute(SaveGame saveGame, Store store)
        {
            store.HireRoom();
        }

        public bool IsEnabled(Store store)
        {
            return (store.StoreType == StoreType.StoreInn);
        }
    }
}
