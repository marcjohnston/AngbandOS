using AngbandOS.Commands;
using AngbandOS.Enumerations;

namespace AngbandOS.StoreCommands
{
    internal class EnchantArmorStoreCommand : IStoreCommand

    {
        public char Key => 'r';

        public bool RequiresRerendering => false;

        public string Description => "Enchant your armour";

        public void Execute(SaveGame saveGame, Store store)
        {
            store.EnchantArmour();
        }

        public bool IsEnabled(Store store)
        {
            return (store.StoreType == StoreType.StoreArmoury);
        }
    }
}
