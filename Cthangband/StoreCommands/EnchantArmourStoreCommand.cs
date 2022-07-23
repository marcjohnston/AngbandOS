using Cthangband.Commands;
using Cthangband.Enumerations;

namespace Cthangband.StoreCommands
{
    internal class EnchantArmorStoreCommand : IStoreCommand

    {
        public char Key => 'r';

        public bool RequiresRerendering => false;

        public string Description => "Enchant your armour";

        public void Execute(Player player, Store store)
        {
            store.EnchantArmour();
        }

        public bool IsEnabled(Store store)
        {
            return (store.StoreType == StoreType.StoreArmoury);
        }
    }
}
