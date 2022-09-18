using AngbandOS.Commands;
using AngbandOS.Enumerations;

namespace AngbandOS.StoreCommands
{
    internal class ResearchSpellStoreCommand : IStoreCommand

    {
        public char Key => 'r';

        public bool RequiresRerendering => false;

        public string Description => "Research a spell";

        public void Execute(SaveGame saveGame, Store store)
        {
            store.ResearchSpell();
        }

        public bool IsEnabled(Store store)
        {
            return (store.StoreType == StoreType.StoreLibrary);
        }
    }
}
