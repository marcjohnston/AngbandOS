using AngbandOS.Commands;
using AngbandOS.Enumerations;

namespace AngbandOS.StoreCommands
{
    internal class EnchantWeaponStoreCommand : IStoreCommand

    {
        public char Key => 'r';

        public bool RequiresRerendering => false;

        public string Description => "Enchant your weapon";

        public void Execute(SaveGame saveGame, Store store)
        {
            store.EnchantWeapon();
        }

        public bool IsEnabled(Store store)
        {
            return (store.StoreType == StoreType.StoreWeapon);
        }
    }
}
