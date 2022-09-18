using AngbandOS.Commands;

namespace AngbandOS.StoreCommands
{
    internal class CarriageReturnStoreCommand : IStoreCommand
    {
        public char Key => '\r';

        public string Description => "";

        public bool RequiresRerendering => false;

        public void Execute(SaveGame saveGame, Store store)
        {
        }

        public bool IsEnabled(Store store) => true;
    }
}
