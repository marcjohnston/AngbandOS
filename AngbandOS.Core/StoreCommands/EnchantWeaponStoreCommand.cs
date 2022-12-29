namespace AngbandOS.StoreCommands
{
    internal class EnchantWeaponStoreCommand : BaseStoreCommand

    {
        public override char Key => 'r';

        public override string Description => "Enchant your weapon";

        public override void Execute(StoreCommandEvent storeCommandEvent)
        {
            storeCommandEvent.Store.EnchantWeapon();
        }

        public override bool IsEnabled(Store store) => (store.StoreType == StoreType.StoreWeapon);
    }
}
